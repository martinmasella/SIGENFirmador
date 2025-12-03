using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using iText.Signatures;

namespace SIGENFirmador
{
    /// <summary>
    /// Contenedor de firma externa para iText9 que implementa firma RSA con SHA-256
    /// Compatible con PAdES y CAdES
    /// </summary>
    public class RSASignatureContainer : IExternalSignatureContainer
    {
        private readonly X509Certificate2 _certificate;

        /// <param name="certificate">Certificado X509 con clave privada RSA</param>
        public RSASignatureContainer(X509Certificate2 certificate)
        {
            _certificate = certificate ?? throw new ArgumentNullException(nameof(certificate));
        }

        /// <summary>
        /// Firma los datos con RSA PKCS#1 usando SHA-256
        /// </summary>
        /// <param name="data">Stream con los datos a firmar</param>
        /// <returns>Firma digital en formato PKCS#1</returns>
        public byte[] Sign(Stream data)
        {
            try
            {
                // Leer los datos a firmar
                using (MemoryStream ms = new MemoryStream())
                {
                    data.CopyTo(ms);
                    byte[] dataToSign = ms.ToArray();

                    // Obtener la clave privada RSA del certificado
                    using (RSA rsa = _certificate.GetRSAPrivateKey())
                    {
                        if (rsa == null)
                            throw new Exception("No se pudo obtener la clave privada RSA del certificado");

                        // Firmar con SHA-256 y PKCS#1 padding
                        byte[] signature = rsa.SignData(
                            dataToSign,
                            HashAlgorithmName.SHA256,
                            RSASignaturePadding.Pkcs1
                        );

                        return signature;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al firmar los datos: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Permite modificar el diccionario de firma si es necesario
        /// iText9 maneja automáticamente los campos esenciales
        /// </summary>
        public void ModifySigningDictionary(iText.Kernel.Pdf.PdfDictionary signDictionary)
        {
            // Este método se puede dejar vacío, iText9 maneja los campos automáticamente
        }

        public void Close()
        {
            // No hay recursos no administrados para liberar
        }
    }
}
