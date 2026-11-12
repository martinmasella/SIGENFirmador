using iText.Forms;
using iText.Kernel.Pdf;
using iText.Signatures;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using Org.BouncyCastle.X509;
using BCX509Certificate = Org.BouncyCastle.X509.X509Certificate;

namespace SIGENFirmador
{
    /// <summary>
    /// Clase para firmar digitalmente archivos PDF usando iText7 con PKCS#7 CMS
    /// Compatible con Adobe Reader y certificados protegidos (Smart Cards, Tokens USB)
    /// </summary>
    public class PdfSigningService
    {
        /// <summary>
        /// Firma digitalmente un PDF con SHA-256 usando PKCS#7 detached signature
        /// Compatible con Adobe Reader
        /// Windows mostrara automaticamente el dialogo de PIN/contrasena si es necesario
        /// </summary>
        public static void SignPdf(string inputPdfPath, string outputPdfPath, X509Certificate2 certificate, 
            string reason = "Documento firmado digitalmente", string location = "Argentina")
        {
            if (!File.Exists(inputPdfPath))
                throw new FileNotFoundException($"El archivo PDF no existe: {inputPdfPath}");

            if (certificate == null)
                throw new ArgumentNullException(nameof(certificate), "Se debe proporcionar un certificado valido");

            if (!certificate.HasPrivateKey)
                throw new ArgumentException("El certificado debe contener una clave privada");

            PdfReader pdfReader = null;
            FileStream fos = null;
            try
            {
                pdfReader = new PdfReader(inputPdfPath);
                fos = new FileStream(outputPdfPath, FileMode.Create);
                
                StampingProperties stampingProperties = new StampingProperties();
                stampingProperties.UseAppendMode();
                
                PdfSigner signer = new PdfSigner(pdfReader, fos, stampingProperties);
                
                // Configurar metadata de la firma
                PdfSignatureAppearance appearance = signer.GetSignatureAppearance();
                appearance.SetReason(reason);
                appearance.SetLocation(location);
                signer.SetFieldName($"Signature{new Random().Next(1, 1000)}");
                
                // Construir la cadena de certificados
                Org.BouncyCastle.X509.X509Certificate[] chain = BuildCertificateChain(certificate);
                
                // Obtener la clave privada compatible con CNG y CSP
                AsymmetricAlgorithm privateKey = GetPrivateKeyAlgorithm(certificate);
                
                if (privateKey == null)
                {
                    throw new Exception("No se pudo acceder a la clave privada del certificado. " +
                        "Asegurese de que el certificado tenga una clave privada disponible.");
                }
                
                // Crear la firma usando nuestro wrapper de .NET
                IExternalSignature externalSignature = new DotNetExternalSignature(privateKey, "SHA-256");
                
                // Firmar el documento usando el metodo estandar de iText7
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
        /// Detecta y elimina todas las firmas digitales de un PDF conservando su apariencia visual (texto y/o imagen).
        /// Retorna la cantidad de firmas digitales eliminadas (0 si el archivo no contenía firmas).
        /// </summary>
        public static int UnsignPdf(string inputPdfPath, string outputPdfPath)
        {
            if (!File.Exists(inputPdfPath))
                throw new FileNotFoundException($"El archivo PDF no existe: {inputPdfPath}");

            if (string.IsNullOrWhiteSpace(outputPdfPath))
                throw new ArgumentException("Se debe indicar una ruta de salida válida.", nameof(outputPdfPath));

            using (PdfReader checkReader = new PdfReader(inputPdfPath).SetUnethicalReading(true))
            using (PdfDocument checkDoc = new PdfDocument(checkReader))
            {
                SignatureUtil checkUtil = new SignatureUtil(checkDoc);
                if (checkUtil.GetSignatureNames().Count == 0)
                {
                    return 0;
                }
            }

            string tempFile = Path.Combine(Path.GetTempPath(), $"sigen_unsign_{Guid.NewGuid():N}.pdf");
            int removedCount = 0;

            try
            {
                using (PdfReader reader = new PdfReader(inputPdfPath).SetUnethicalReading(true))
                using (PdfWriter writer = new PdfWriter(tempFile))
                using (PdfDocument pdfDoc = new PdfDocument(reader, writer))
                {
                    SignatureUtil sigUtil = new SignatureUtil(pdfDoc);
                    IList<string> sigNames = sigUtil.GetSignatureNames();
                    IList<string> blankSigNames = sigUtil.GetBlankSignatureNames();

                    PdfAcroForm acroForm = PdfAcroForm.GetAcroForm(pdfDoc, false);
                    if (acroForm != null)
                    {
                        // Evitar que iText regenere la apariencia para preservar intactos el texto y/o imagen originales (/AP /N)
                        acroForm.SetGenerateAppearance(false);

                        foreach (string sigName in sigNames)
                        {
                            acroForm.PartialFormFlattening(sigName);
                            removedCount++;
                        }

                        if (removedCount > 0)
                        {
                            acroForm.FlattenFields();
                        }

                        PdfAcroForm remainingForm = PdfAcroForm.GetAcroForm(pdfDoc, false);
                        if (remainingForm != null)
                        {
                            foreach (string blankName in blankSigNames)
                            {
                                remainingForm.RemoveField(blankName);
                            }

                            remainingForm.GetPdfObject().Remove(PdfName.SigFlags);
                        }
                    }

                    // Limpiar permisos de certificación (DocMDP/UR3) y almacén LTV (DSS) para permitir volver a firmar sin advertencias
                    PdfDictionary catalogDict = pdfDoc.GetCatalog().GetPdfObject();
                    catalogDict.Remove(PdfName.Perms);
                    catalogDict.Remove(new PdfName("DSS"));
                }

                string outputDir = Path.GetDirectoryName(outputPdfPath);
                if (!string.IsNullOrEmpty(outputDir) && !Directory.Exists(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                File.Copy(tempFile, outputPdfPath, overwrite: true);
                return removedCount;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al quitar las firmas del PDF: {ex.Message}", ex);
            }
            finally
            {
                if (File.Exists(tempFile))
                {
                    try { File.Delete(tempFile); } catch { }
                }
            }
        }

        /// <summary>
        /// Obtiene la clave privada del certificado compatible con CNG y CSP
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
                // Continuar con otros metodos
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
                // Continuar con otros metodos
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
                // Continuar con metodo legacy
            }

            // Metodo legacy (CSP) - como ultimo recurso
            try
            {
                return certificate.PrivateKey;
            }
            catch (CryptographicException)
            {
                return null;
            }
        }

        /// <summary>
        /// Construye la cadena de certificados completa usando X509Certificate de BouncyCastle
        /// </summary>
        private static Org.BouncyCastle.X509.X509Certificate[] BuildCertificateChain(X509Certificate2 certificate)
        {
            try
            {
                X509Chain chain = new X509Chain();
                chain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
                chain.Build(certificate);

                var certList = new System.Collections.Generic.List<Org.BouncyCastle.X509.X509Certificate>();
                X509CertificateParser parser = new X509CertificateParser();
                
                foreach (X509ChainElement element in chain.ChainElements)
                {
                    byte[] certBytes = element.Certificate.RawData;
                    Org.BouncyCastle.X509.X509Certificate bcCert = parser.ReadCertificate(certBytes);
                    certList.Add(bcCert);
                }

                return certList.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al construir cadena de certificados: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Implementacion de IExternalSignature que usa AsymmetricAlgorithm de .NET
        /// Compatible con certificados protegidos, Smart Cards y Tokens USB
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

            public string GetHashAlgorithm()
            {
                return _hashAlgorithm;
            }

            public string GetEncryptionAlgorithm()
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
                    if (cryptoEx.Message.Contains("canceled") || cryptoEx.Message.Contains("cancelado"))
                    {
                        throw new Exception("La operacion fue cancelada por el usuario.", cryptoEx);
                    }
                    else if (cryptoEx.Message.Contains("PIN") || cryptoEx.Message.Contains("password"))
                    {
                        throw new Exception("PIN o contrasena incorrecta.", cryptoEx);
                    }
                    
                    throw new Exception($"Error criptografico al firmar: {cryptoEx.Message}", cryptoEx);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error al firmar datos: {ex.Message}", ex);
                }
            }
        }
    }
}
