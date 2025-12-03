using iText.Kernel.Pdf;
using iText.Signatures;
using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using iText.Bouncycastleconnector;
using iText.Commons.Bouncycastle.Cert;
using Org.BouncyCastle.X509;

namespace SIGENFirmador
{
    /// <summary>
    /// Clase para firmar digitalmente archivos PDF usando iText 9 con PKCS#7 CMS
    /// Compatible con Adobe Reader y certificados protegidos (Smart Cards, Tokens USB)
    /// </summary>
    public class PdfSigningService
    {
        /// <summary>
        /// Firma digitalmente un PDF con SHA-256 usando PKCS#7 detached signature
        /// Utiliza el método estándar de iText 9 compatible con Adobe Reader
        /// Windows mostrará automáticamente el diálogo de PIN/contraseña si es necesario
        /// </summary>
        public static void SignPdf(string inputPdfPath, string outputPdfPath, X509Certificate2 certificate, 
            string reason = "Documento firmado digitalmente", string location = "Argentina")
        {
            if (!File.Exists(inputPdfPath))
                throw new FileNotFoundException($"El archivo PDF no existe: {inputPdfPath}");

            if (certificate == null)
                throw new ArgumentNullException(nameof(certificate), "Se debe proporcionar un certificado válido");

            if (!certificate.HasPrivateKey)
                throw new ArgumentException("El certificado debe contener una clave privada");

            PdfReader pdfReader = null;
            FileStream fos = null;
            try
            {
                // Inicializar el factory de BouncyCastle
                BouncyCastleFactoryCreator.GetFactory();
                
                pdfReader = new PdfReader(inputPdfPath);
                fos = new FileStream(outputPdfPath, FileMode.Create);
                
                StampingProperties stampingProperties = new StampingProperties();
                stampingProperties.UseAppendMode();
                
                PdfSigner signer = new PdfSigner(pdfReader, fos, stampingProperties);
                
                // Crear SignerProperties para configurar metadata
                SignerProperties signerProperties = new SignerProperties();
                signerProperties.SetReason(reason);
                signerProperties.SetLocation(location);
                signerProperties.SetFieldName($"Signature{new Random().Next(1, 1000)}");
                
                // Construir la cadena de certificados
                IX509Certificate[] chain = BuildCertificateChain(certificate);
                
                // Obtener la clave privada compatible con CNG y CSP
                AsymmetricAlgorithm privateKey = GetPrivateKeyAlgorithm(certificate);
                
                if (privateKey == null)
                {
                    throw new Exception("No se pudo acceder a la clave privada del certificado. " +
                        "Asegúrese de que el certificado tenga una clave privada disponible.");
                }
                
                // Crear la firma usando nuestro wrapper de .NET
                // Esto permite que Windows muestre el diálogo de contraseña si es necesario
                IExternalSignature externalSignature = new DotNetExternalSignature(privateKey, "SHA-256");
                
                // Firmar el documento usando el método estándar de iText
                // CMS = adbe.pkcs7.detached - Compatible con Adobe Reader
                signer.SignDetached(externalSignature, chain, null, null, null, 0, PdfSigner.CryptoStandard.CMS);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al firmar el PDF: {ex.Message}", ex);
            }
            finally
            {
                fos?.Dispose();
                pdfReader?.Close();
            }
        }

        /// <summary>
        /// Obtiene la clave privada del certificado compatible con CNG y CSP
        /// Intenta primero los métodos modernos (CNG) y luego el método legacy (CSP)
        /// </summary>
        private static AsymmetricAlgorithm GetPrivateKeyAlgorithm(X509Certificate2 certificate)
        {
            // Primero intentar obtener clave RSA (CNG - moderno)
            try
            {
                RSA rsa = certificate.GetRSAPrivateKey();
                if (rsa != null)
                    return rsa;
            }
            catch
            {
                // Continuar con otros métodos
            }

            // Intentar DSA (CNG)
            try
            {
                DSA dsa = certificate.GetDSAPrivateKey();
                if (dsa != null)
                    return dsa;
            }
            catch
            {
                // Continuar con otros métodos
            }

            // Intentar ECDSA (CNG)
            try
            {
                ECDsa ecdsa = certificate.GetECDsaPrivateKey();
                if (ecdsa != null)
                    return ecdsa;
            }
            catch
            {
                // Continuar con método legacy
            }

            // Método legacy (CSP) - como último recurso
            // Este puede fallar con "tipo de proveedor no válido" en certificados CNG
            try
            {
                return certificate.PrivateKey;
            }
            catch (CryptographicException)
            {
                // Si falla, devolver null
                return null;
            }
        }

        /// <summary>
        /// Construye la cadena de certificados completa usando IX509Certificate de iText
        /// </summary>
        private static IX509Certificate[] BuildCertificateChain(X509Certificate2 certificate)
        {
            try
            {
                // Construir la cadena de certificados
                X509Chain chain = new X509Chain();
                chain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
                chain.Build(certificate);

                var certList = new System.Collections.Generic.List<IX509Certificate>();
                
                // Convertir cada certificado de la cadena
                foreach (X509ChainElement element in chain.ChainElements)
                {
                    byte[] certBytes = element.Certificate.RawData;
                    X509CertificateParser parser = new X509CertificateParser();
                    Org.BouncyCastle.X509.X509Certificate bcCert = parser.ReadCertificate(certBytes);
                    
                    // Crear el wrapper de iText
                    IX509Certificate iTextCert = BouncyCastleFactoryCreator.GetFactory().CreateX509Certificate(bcCert);
                    certList.Add(iTextCert);
                }

                return certList.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al construir cadena de certificados: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Implementación de IExternalSignature que usa AsymmetricAlgorithm de .NET
        /// Sin necesidad de exportar la clave privada
        /// Compatible con certificados protegidos, Smart Cards y Tokens USB
        /// Windows mostrará automáticamente el diálogo de PIN/contraseña si es necesario
        /// </summary>
        private class DotNetExternalSignature : IExternalSignature
        {
            private readonly AsymmetricAlgorithm _privateKey;
            private readonly string _hashAlgorithm;

            public DotNetExternalSignature(AsymmetricAlgorithm privateKey, string hashAlgorithm)
            {
                _privateKey = privateKey;
                _hashAlgorithm = hashAlgorithm;
            }

            public string GetDigestAlgorithmName()
            {
                return _hashAlgorithm;
            }

            public string GetSignatureAlgorithmName()
            {
                return _hashAlgorithm + "with" + GetAlgorithm();
            }

            public ISignatureMechanismParams GetSignatureMechanismParameters()
            {
                return null;
            }

            private string GetAlgorithm()
            {
                if (_privateKey is RSA || _privateKey is RSACryptoServiceProvider)
                    return "RSA";
                else if (_privateKey is DSA || _privateKey is DSACryptoServiceProvider)
                    return "DSA";
                else if (_privateKey is ECDsa)
                    return "ECDSA";
                
                return "RSA";
            }

            public byte[] Sign(byte[] message)
            {
                try
                {
                    if (_privateKey is RSACryptoServiceProvider rsaProvider)
                    {
                        // Windows mostrará el diálogo de PIN aquí si es necesario
                        return rsaProvider.SignData(message, HashAlgorithmName.SHA256, 
                            RSASignaturePadding.Pkcs1);
                    }
                    else if (_privateKey is RSA rsa)
                    {
                        return rsa.SignData(message, HashAlgorithmName.SHA256, 
                            RSASignaturePadding.Pkcs1);
                    }
                    else if (_privateKey is DSACryptoServiceProvider dsaProvider)
                    {
                        return dsaProvider.SignData(message);
                    }
                    else if (_privateKey is DSA dsa)
                    {
                        return dsa.SignData(message, HashAlgorithmName.SHA256);
                    }
                    else if (_privateKey is ECDsa ecdsa)
                    {
                        return ecdsa.SignData(message, HashAlgorithmName.SHA256);
                    }
                    else
                    {
                        throw new NotSupportedException($"Tipo de clave no soportado: {_privateKey?.GetType().Name ?? "null"}");
                    }
                }
                catch (CryptographicException cryptoEx)
                {
                    // Manejar específicamente errores de contraseña/PIN
                    if (cryptoEx.Message.Contains("canceled") || cryptoEx.Message.Contains("cancelado"))
                    {
                        throw new Exception("La operación fue cancelada por el usuario.", cryptoEx);
                    }
                    else if (cryptoEx.Message.Contains("PIN") || cryptoEx.Message.Contains("password"))
                    {
                        throw new Exception("PIN o contraseña incorrecta.", cryptoEx);
                    }
                    
                    throw new Exception($"Error criptográfico al firmar: {cryptoEx.Message}", cryptoEx);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error al firmar datos: {ex.Message}", ex);
                }
            }
        }
    }
}
