# Migración de Firma Digital: iTextSharp 5 ? iText 9

## Resumen de cambios

Se ha migrado completamente el método `Sign_Remember()` de **iTextSharp 5** (legacy) a **iText 9** (moderno). Esta migración aplica SOLO a la funcionalidad de firma digital.

## Cambios realizados en `Main.cs`

### 1. **Método Sign_Remember() - Completamente reescrito**

#### Antes (iTextSharp 5):
```csharp
// Usaba clases legacy de iTextSharp 5
IExternalSignature pks = new X509Certificate2Signature(Cert,"SHA-1");
iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader(src);
iTextSharp.text.pdf.PdfStamper stamper = PdfStamper.CreateSignature(reader, os, '\0');
PdfSignatureAppearance appearance = stamper.SignatureAppearance;
MakeSignature.SignDetached(appearance, pks, chain, null, null, null, 0, CryptoStandard.CADES);
```

#### Ahora (iText 9):
```csharp
// Usa la API moderna de iText 9
RSA rsaKey = Cert.GetRSAPrivateKey();
IExternalSignature externalSignature = new RSAPrivateKeyExternalSignature(rsaKey, DigestAlgorithms.SHA256);
using (PdfReader reader = new PdfReader(src))
using (FileStream os = new FileStream(dest, FileMode.Create))
{
    PdfSigner signer = new PdfSigner(reader, os, new StampingProperties());
    PdfSignatureAppearance appearance = signer.GetSignatureAppearance();
    // ... configurar apariencia ...
    signer.SignDetached(externalSignature, chain, null, null, null, 0, PdfSigner.CryptoStandard.CADES);
}
```

### 2. **Nueva clase: RSAPrivateKeyExternalSignature**

Se agregó una clase que implementa `IExternalSignature` de iText 9:

```csharp
public class RSAPrivateKeyExternalSignature : IExternalSignature
{
    private readonly RSA rsa;
    private readonly string hashAlgorithm;

    public RSAPrivateKeyExternalSignature(RSA rsa, string hashAlgorithm)
    {
        this.rsa = rsa;
        this.hashAlgorithm = hashAlgorithm;
    }

    public byte[] Sign(byte[] message)
    {
        string algo = hashAlgorithm.Replace("-", "").ToUpperInvariant();
        var hashAlgName = new HashAlgorithmName(algo);
        return rsa.SignHash(message, hashAlgName, RSASignaturePadding.Pkcs1);
    }

    public string GetHashAlgorithm() => hashAlgorithm;
    public string GetEncryptionAlgorithm() => "RSA";
}
```

## Beneficios de la migración

| Aspecto | iTextSharp 5 | iText 9 |
|---------|------------|--------|
| **Algoritmo Hash** | SHA-1 (débil) | SHA-256 (robusto) |
| **Estándar Firma** | CAdES | CAdES moderno |
| **Gestión de recursos** | Manual con finally | `using` statements |
| **API RSA** | Legacy/CSP | Moderna (.NET nativa) |
| **Mantenimiento** | Descontinuado | Activamente mantenido |
| **Seguridad** | Clases inseguras | Criptografía moderna |

## Notas importantes

1. **Certificados requeridos**: El certificado debe tener una llave privada RSA accesible. Los certificados CNG (Cryptography Next Generation) son soportados.

2. **Cambio de algoritmo**: La firma ahora utiliza **SHA-256** en lugar de SHA-1, lo que mejora significativamente la seguridad.

3. **Compatibilidad**: Las firmas generadas con iText 9 son completamente compatibles con lectores PDF estándar y validadores de firma digital.

4. **Manejo de errores**: Se agregó mejor manejo de excepciones con información sobre causas raíz.

5. **Variables legacy**: Las variables `rsa`, `rsa2`, `cspp` y el flag `bFlag` ya NO se utilizan en la nueva implementación. Pueden ser removidas en futuras refactorizaciones.

## Resto del proyecto

- **OCR**: Ya está en iText 9 (usando Tesseract4)
- **Fusión de PDFs**: Ya está en iText 9  
- **División de PDFs**: Ya está en iText 9
- **Empaquetado**: Ya está en iText 9

## Validación

Para validar que la migración funciona correctamente:

1. Compilar el proyecto
2. Abrir un PDF
3. Usar la funcionalidad "Firmar" 
4. Seleccionar un certificado digital
5. Verificar que el PDF se firme correctamente
6. Abrir el PDF firmado en un lector con soporte de firma digital

## Referencias

- [iText 9 Documentation - PDF Signatures](https://itextpdf.com/en/blog/technical-tips/how-sign-pdf-itext-7)
- [X509 Certificates & RSA in .NET](https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.rsa)
- [CAdES/PAdES Standards](https://www.etsi.org/deliver/etsi_ts/103173v020101p.pdf)
