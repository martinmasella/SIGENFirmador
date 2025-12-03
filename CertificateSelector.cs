using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace SIGENFirmador
{
    /// <summary>
    /// Clase para la selección y validación de certificados digitales
    /// Proporciona métodos para obtener certificados disponibles y validarlos
    /// </summary>
    public class CertificateSelector
    {
        /// <summary>
        /// Obtiene los certificados disponibles en el almacén personal del usuario actual
        /// </summary>
        /// <returns>Lista de certificados disponibles con clave privada</returns>
        public static List<X509Certificate2> GetAvailableCertificates()
        {
            List<X509Certificate2> certificates = new List<X509Certificate2>();

            try
            {
                // Abrir el almacén de certificados personal del usuario actual
                X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadOnly);

                // Obtener los certificados válidos en la fecha actual
                X509Certificate2Collection certs = store.Certificates.Find(
                    X509FindType.FindByTimeValid,
                    DateTime.Now,
                    false);

                foreach (X509Certificate2 cert in certs)
                {
                    // Filtrar solo certificados con clave privada (aptos para firmar)
                    if (cert.HasPrivateKey)
                    {
                        certificates.Add(cert);
                    }
                }

                store.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al acceder al almacén de certificados: {ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return certificates;
        }

        /// <summary>
        /// Obtiene la descripción legible de un certificado
        /// </summary>
        /// <param name="certificate">Certificado a describir</param>
        /// <returns>Descripción legible del certificado</returns>
        public static string GetCertificateDescription(X509Certificate2 certificate)
        {
            string subject = certificate.SubjectName.Name;
            string expiration = certificate.NotAfter.ToString("dd/MM/yyyy");
            return $"{subject} (Expira: {expiration})";
        }

        /// <summary>
        /// Valida si el certificado es válido para firmar
        /// </summary>
        /// <param name="certificate">Certificado a validar</param>
        /// <returns>true si el certificado es válido, false en caso contrario</returns>
        public static bool IsCertificateValid(X509Certificate2 certificate)
        {
            if (certificate == null)
                return false;

            if (!certificate.HasPrivateKey)
                return false;

            // Validar que no esté expirado
            if (DateTime.Now > certificate.NotAfter || DateTime.Now < certificate.NotBefore)
                return false;

            return true;
        }
    }
}
