using iTextSharp.text.pdf.security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using iText;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Filespec;
using System.Diagnostics;
using iTextSharp.text.pdf;
using System.Security.Cryptography;
using iText.Pdfocr;
using iText.Pdfocr.Tesseract4;
using PdfWriter = iText.Kernel.Pdf.PdfWriter;
using iText.Kernel.Utils;
using iText.Pdfa;
using iText.Forms;
using iText.Layout.Element;
using iText.Layout;
using PdfReader = iText.Kernel.Pdf.PdfReader;
using iText.Kernel.Pdf.Canvas.Draw;

namespace SIGENFirmador
{
    public partial class Main : Form
    {
        public X509Certificate2 Cert;
        private string strArchivoPaqueteResultado = @"c:\temp\paquete.pdf";
        private string strCarpetaSign = @"c:\temp";
        private const string cteArchivoTemporal = @"c:\temp\temporal";
        private bool bFlag=false;
        public RSACryptoServiceProvider rsa;
        public CspParameters cspp;
        public RSACryptoServiceProvider rsa2;
        private string[] archivosOCR;

        public Main()
        {
            InitializeComponent();
            InicializarForm();
            pgsPack.Visible = false;
            this.Width = 1208;
            this.Height = 700;
        }

        private void InicializarForm()
        {
            this.Text = "SIGEN - Gestor de documentos digitales - Versión " + System.Windows.Forms.Application.ProductVersion;
            FillCboDrives(ref cboDrivesPack);
            FillCboDrives(ref cboDrivesSign);
            FillCboDrives(ref cbDrivesFus);

            string carpeta = cboDrivesPack.Text;
            PopulateTreeView(ref tvwCarpetasPack, carpeta);
            PopulateTreeView(ref tvwCarpetasSign, carpeta);
            PopulateTreeView(ref tvwCarpetasFus, carpeta);

            this.tvwCarpetasPack.NodeMouseClick += new TreeNodeMouseClickEventHandler(this.tvwCarpetasPack_NodeMouseClick);
            this.tvwCarpetasSign.NodeMouseClick += new TreeNodeMouseClickEventHandler(this.tvwCarpetasSign_NodeMouseClick);
            this.tvwCarpetasFus.NodeMouseClick += new TreeNodeMouseClickEventHandler(this.tvwCarpetasFus_NodeMouseClick);
        }

        private void FillCboDrives(ref ComboBox combo)
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            combo.Items.Clear();
            foreach (DriveInfo d in allDrives)
            {
                combo.Items.Add(d.Name);
            }
            combo.SelectedIndex = 0;
        }

        private void AbrirPDF(string archivo)
        {
            Process P = new Process();
            P.StartInfo.FileName = archivo;
            P.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            P.StartInfo.UseShellExecute = true;
            P.Start();
            P.Close();
        }

        public void Sign_Remember(String src, String dest, ICollection<Org.BouncyCastle.X509.X509Certificate> chain)
        {
            try
            {

                IExternalSignature pks = new X509Certificate2Signature(Cert,"SHA-1");

                int llx = 40, lly = 120, urx = 200, ury = 40; //Coordenadas para fijar la firma...
                iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader(src);
                FileStream os = new FileStream(dest, FileMode.Create);
                iTextSharp.text.pdf.PdfStamper stamper = PdfStamper.CreateSignature(reader, os, '\0');

                PdfSignatureAppearance appearance = stamper.SignatureAppearance;
                //PdfSigLockDictionary pdfSigLockDictionary = new PdfSigLockDictionary(new PdfSigLockDictionary.LockPermissions)
                appearance.FieldLockDict = null;

                Random rand = new Random();
                int rnd = rand.Next(0, 1000);
                /*
                appearance.Layer2Text = "Firmado digitalmente por " + Cert.GetNameInfo(X509NameType.SimpleName,false) + " de " +
                    new Org.BouncyCastle.Asn1.X509.X509Name(Cert.Subject).GetValueList(Org.BouncyCastle.Asn1.X509.X509Name.O).OfType<string>().FirstOrDefault() +
                    " el " + DateTime.Now.ToLongDateString() + " a las " + DateTime.Now.ToLongTimeString();
                */
                appearance.Layer2Text = "Firmado digitalmente por " + Cert.GetNameInfo(X509NameType.SimpleName, false) + " de " +
                    new Org.BouncyCastle.Asn1.X509.X509Name(Cert.Subject).GetValueList(Org.BouncyCastle.Asn1.X509.X509Name.O).OfType<string>().FirstOrDefault() +
                    " el " + DateTime.Now.ToLongDateString() + " a las " + DateTime.Now.ToLongTimeString();
                appearance.SetVisibleSignature(new iTextSharp.text.Rectangle(llx, lly, urx, ury), 1, "Firma_" + rnd.ToString());
                
                //Esta línea bloquea completamente al documento.
                //Debería agregar un check para que el usuario indique si quiere que esto suceda.
                appearance.CertificationLevel = PdfSignatureAppearance.CERTIFIED_NO_CHANGES_ALLOWED;

                if (bFlag == false)
                {
                    rsa = (RSACryptoServiceProvider)Cert.PrivateKey;
                    cspp = new CspParameters();
                    cspp.KeyContainerName = rsa.CspKeyContainerInfo.KeyContainerName;
                    cspp.ProviderName = rsa.CspKeyContainerInfo.ProviderName;
                    cspp.ProviderType = rsa.CspKeyContainerInfo.ProviderType;
                    cspp.Flags = CspProviderFlags.UseExistingKey;

                    rsa2 = new RSACryptoServiceProvider(cspp);
                    rsa.PersistKeyInCsp = true;
                    bFlag = true;
                }

                MakeSignature.SignDetached(appearance, pks, chain, null, null, null, 0, CryptoStandard.CADES);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
                // MessageBox.Show("Se produjo un error al firmar el archivo " + src , "Firmador SIGEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //ToLog("Error firmando archivo: " + src + " - e: " + e.Message + " - " + e.StackTrace);
            }
        }

        private void PopulateTreeView(ref TreeView tree, string carpeta)
        {
            TreeNode rootNode;
            tree.Nodes.Clear();
            DirectoryInfo info = new DirectoryInfo(carpeta);
            if (info.Exists)
            {
                rootNode = new TreeNode(info.Name);
                rootNode.Tag = info;
                GetDirectories(info.GetDirectories(), rootNode);
                tree.Nodes.Add(rootNode);
            }
        }
        private void GetDirectories(DirectoryInfo[] subDirs, TreeNode nodeToAddTo)
        {
            TreeNode aNode;
            foreach (DirectoryInfo subDir in subDirs)
            {
                aNode = new TreeNode(subDir.Name, 0, 0);
                aNode.Tag = subDir;
                //aNode.ImageKey = "folder";
                nodeToAddTo.Nodes.Add(aNode);
            }
        }

        void tvwCarpetasPack_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                DirectoryInfo d = new DirectoryInfo(@e.Node.FullPath);
                if (e.Node.Nodes.Count > 0) 
                { /*Do Nothing.*/ } 
                else 
                { 
                    GetDirectories(d.GetDirectories(), e.Node); 
                    e.Node.Expand(); 
                }

                TreeNode newSelected = e.Node;
                lvwArchivosPack.Items.Clear();
                DirectoryInfo nodeDirInfo = (DirectoryInfo)newSelected.Tag;
                ListViewItem.ListViewSubItem[] subItems;

                ListViewItem item = null;

                foreach (FileInfo file in nodeDirInfo.GetFiles())
                {
                    item = new ListViewItem(file.Name, 1);
                    subItems = new ListViewItem.ListViewSubItem[]
                     {
                        new ListViewItem.ListViewSubItem(item,file.LastWriteTime.ToShortDateString()),
                         new ListViewItem.ListViewSubItem(item, file.Extension),
                        new ListViewItem.ListViewSubItem(item, file.Length.ToString())
                     };
                    item.SubItems.AddRange(subItems);
                    lvwArchivosPack.Items.Add(item);
                }

                lvwArchivosPack.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            catch (Exception ex)
            {
                if (ex is NullReferenceException || ex is UnauthorizedAccessException)
                { }

            }
        }

        void tvwCarpetasSign_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                DirectoryInfo d = new DirectoryInfo(@e.Node.FullPath);
                if (e.Node.Nodes.Count > 0) { /*Do Nothing.*/ } else { GetDirectories(d.GetDirectories(), e.Node); e.Node.Expand(); }

                TreeNode newSelected = e.Node;
                lvwArchivosSign.Items.Clear();
                DirectoryInfo nodeDirInfo = (DirectoryInfo)newSelected.Tag;
                ListViewItem.ListViewSubItem[] subItems;

                ListViewItem item = null;

                foreach (FileInfo file in nodeDirInfo.GetFiles("*.pdf"))
                {
                    item = new ListViewItem(file.Name, 1);
                    subItems = new ListViewItem.ListViewSubItem[]
                     {
                        new ListViewItem.ListViewSubItem(item,file.LastWriteTime.ToShortDateString()),
                        new ListViewItem.ListViewSubItem(item, file.Length.ToString())
                     };
                    item.SubItems.AddRange(subItems);
                    lvwArchivosSign.Items.Add(item);
                }

                lvwArchivosSign.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            catch (Exception ex)
            {
                if (ex is NullReferenceException || ex is UnauthorizedAccessException)
                { }

            }
        }

        void tvwCarpetasFus_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                DirectoryInfo d = new DirectoryInfo(@e.Node.FullPath);
                if (e.Node.Nodes.Count > 0)
                { /*Do Nothing.*/ }
                else
                { 
                    GetDirectories(d.GetDirectories(), e.Node);
                    e.Node.Expand();
                }

                TreeNode newSelected = e.Node;
                lvwArchivosFus.Items.Clear();
                DirectoryInfo nodeDirInfo = (DirectoryInfo)newSelected.Tag;
                ListViewItem.ListViewSubItem[] subItems;

                ListViewItem item = null;

                foreach (FileInfo file in nodeDirInfo.GetFiles("*.pdf"))
                {
                    item = new ListViewItem(file.Name, 1);
                    subItems = new ListViewItem.ListViewSubItem[]
                     {
                        new ListViewItem.ListViewSubItem(item,file.LastWriteTime.ToShortDateString()),
                        new ListViewItem.ListViewSubItem(item, file.Length.ToString())
                     };
                    item.SubItems.AddRange(subItems);
                    lvwArchivosFus.Items.Add(item);
                }

                lvwArchivosFus.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            catch (Exception ex)
            {
                if (ex is NullReferenceException || ex is UnauthorizedAccessException)
                { }

            }
        }
       
        private void Main_Load(object sender, EventArgs e)
        {
            EsconderPaneles();
            panelEmpaquetador.Visible = true;

            string misdocumentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //misdocumentos = misdocumentos.Insert(2, "\\"); //
            TreeNode nodoPack= new TreeNode(misdocumentos);
            nodoPack.Tag = new DirectoryInfo(misdocumentos);

            TreeNode nodoSign= new TreeNode(misdocumentos);
            nodoSign.Tag = new DirectoryInfo(misdocumentos);

            TreeNode nodoFus= new TreeNode(misdocumentos);
            nodoFus.Tag = new DirectoryInfo(misdocumentos);

            tvwCarpetasPack.Nodes.Add(nodoPack);
            tvwCarpetasSign.Nodes.Add(nodoSign);
            tvwCarpetasFus.Nodes.Add(nodoFus);
        }

        public byte[] Combine(IEnumerable<byte[]> pdfs)
        {
            using (var writerMemoryStream = new MemoryStream())
            {
                using (var writer = new PdfWriter(writerMemoryStream))
                {
                    using (var mergedDocument = new iText.Kernel.Pdf.PdfDocument(writer))
                    {
                        var merger = new PdfMerger(mergedDocument);

                        foreach (var pdfBytes in pdfs)
                        {
                            using (var copyFromMemoryStream = new MemoryStream(pdfBytes))
                            {
                                using (var reader = new iText.Kernel.Pdf.PdfReader(copyFromMemoryStream))
                                {
                                    using (var copyFromDocument = new iText.Kernel.Pdf.PdfDocument(reader))
                                    {
                                        merger.Merge(copyFromDocument, 1, copyFromDocument.GetNumberOfPages());
                                    }
                                }
                            }
                        }
                    }
                }
                return writerMemoryStream.ToArray();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvwArchivosFus.Items)
            {
                item.Checked = true;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void EsconderPaneles()
        {
            panelEmpaquetador.Visible = false;
            panelOcr.Visible = false;
            panelFirmador.Visible = false;
            panelDivisor.Visible = false;
            panelFusionador.Visible = false;
        }

        private void DeseleccionarSolapas()
        {
            slpEmpaquetar.BackColor = Color.Gray;
            slpDivisor.BackColor = Color.Gray;
            slpOcr.BackColor = Color.Gray;
            slpFusionar.BackColor = Color.Gray;
            slpFirmar.BackColor = Color.Gray;
        }
       
        private void slpFirmar_Click(object sender, EventArgs e)
        {
            DeseleccionarSolapas();
            slpFirmar.BackColor= Color.FromArgb(93, 23, 175);
            EsconderPaneles();
            panelFirmador.Visible = true;
            panelFirmador.Location = new Point(32, 173);
        }

        private void slpEmpaquetar_Click(object sender, EventArgs e)
        {
            DeseleccionarSolapas();
            slpEmpaquetar.BackColor = Color.FromArgb(93, 23, 175);
            EsconderPaneles();
            panelEmpaquetador.Visible = true;
            panelEmpaquetador.Location = new Point(32, 173);
        }

        private void slpOcr_Click(object sender, EventArgs e)
        {
            DeseleccionarSolapas();
            slpOcr.BackColor = Color.FromArgb(93, 23, 175);
            EsconderPaneles();
            panelOcr.Visible = true;
            panelOcr.Location = new Point(32, 173);
        }

        private void slpDivisor_Click(object sender, EventArgs e)
        {
            DeseleccionarSolapas();
            slpDivisor.BackColor = Color.FromArgb(93, 23, 175);
            EsconderPaneles();
            panelDivisor.Visible = true;
            panelDivisor.Location = new Point(32, 173);
        }

        private void slpFusionar_Click(object sender, EventArgs e)
        {
            DeseleccionarSolapas();
            slpFusionar.BackColor = Color.FromArgb(93, 23, 175);
            EsconderPaneles();
            panelFusionador.Visible = true;
            panelFusionador.Location = new Point(32, 173);
        }

        private void btnPack_Click(object sender, EventArgs e)
        {
            dlgArchivoPaquete.InitialDirectory = @"C:\temp";

            if (dlgArchivoPaquete.ShowDialog() == DialogResult.OK)
            {
                strArchivoPaqueteResultado = dlgArchivoPaquete.FileName;
            }
            else
            {
                return;
            }

            if (File.Exists(strArchivoPaqueteResultado))
            {
                DialogResult result = MessageBox.Show("El archivo indicado para contener el resultado del empaquetado ya existe. \n ¿Desea sobreescribirlo?", "Confirma", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    File.Delete(cteArchivoTemporal);
                    File.Delete(strArchivoPaqueteResultado);
                }
                else
                {
                    return;
                }
            }

            iText.Kernel.Pdf.PdfDocument PDFDoc = new iText.Kernel.Pdf.PdfDocument(new iText.Kernel.Pdf.PdfWriter(cteArchivoTemporal));
            iText.Layout.Document doc = new iText.Layout.Document(PDFDoc);

            PDFDoc.SetDefaultPageSize(iText.Kernel.Geom.PageSize.A4);
            PDFDoc.SetTagged();
            PDFDoc.GetDocumentInfo().SetAuthor("SIGEN");

            iText.Layout.Element.Paragraph Titulo;
            iText.Layout.Element.Paragraph Parrafo;

            Titulo = new iText.Layout.Element.Paragraph("Papeles de trabajo digitales").SetFontSize(14);
            //Titulo = new iText.Layout.Element.Paragraph("Papeles de Trabajo").SetFontSize(12);
            doc.Add(Titulo);
            
            /*
            Titulo = new iText.Layout.Element.Paragraph("Utilidad para tratamiento de documentos digitales").SetFontSize(12);
            doc.Add(Titulo);
            */

            Titulo = new iText.Layout.Element.Paragraph("Lista de Archivos").SetFontSize(11);
            doc.Add(Titulo);

            string s;
            StreamReader sr;
            byte[] fileBytes;
            PdfFileSpec spec;

            iText.Layout.Element.Table table = new iText.Layout.Element.Table(3, false);
            table.AddHeaderCell("Nombre");
            table.AddHeaderCell("Tamaño (en bytes)");
            table.AddHeaderCell("Fecha");

            int tamaño = 0;

            string archivo;

            pgsPack.Minimum = 0;
            pgsPack.Value = 0;
            pgsPack.Maximum = lvwArchivosPack.CheckedItems.Count;
            pgsPack.Visible = true;
            foreach (ListViewItem item in lvwArchivosPack.CheckedItems)
            {
                archivo = @tvwCarpetasPack.SelectedNode.FullPath + @"\" + item.Text;
                //sr = new StreamReader(@"c:\temp\" + item.Text,Encoding.Default,false,1);  //El Encoding.Default no me funcionó.
                sr = new StreamReader(archivo, Encoding.GetEncoding(0));    //En cambio el Encoding (0) sí.
                s = sr.ReadToEnd();
                fileBytes = Encoding.GetEncoding(0).GetBytes(s);

                spec = PdfFileSpec.CreateEmbeddedFileSpec(PDFDoc, fileBytes, item.Text, iText.Kernel.Pdf.PdfName.AFRelationship);
                PDFDoc.AddFileAttachment(item.Text, spec);
                spec = null;

                table.AddCell(item.Text);
                table.AddCell(fileBytes.Length.ToString());
                table.AddCell(item.SubItems[1].Text);
                tamaño += int.Parse(fileBytes.Length.ToString());
                pgsPack.Value++;
                Application.DoEvents();
            }
            table.AddFooterCell(new iText.Layout.Element.Cell(1, 3).Add(new iText.Layout.Element.Paragraph("Total " + tamaño.ToString() + " bytes")));
            doc.Add(table);

            Parrafo = new iText.Layout.Element.Paragraph("Comentario: " + txtComentarioPack.Text).SetFontSize(10);
            doc.Add(Parrafo);

            doc.Close();
            PDFDoc.Close();

            if (chkFirmarPaquete.Checked)
            {
                X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadOnly);
                X509Certificate2Collection fcollection = store.Certificates.Find(X509FindType.FindByKeyUsage, X509KeyUsageFlags.DigitalSignature, true);
                //X509Certificate2Collection fcollection = collection.Find(X509FindType.FindByTimeValid, DateTime.Now, true).Find(X509FindType.FindByKeyUsage,X509KeyUsageFlags.DigitalSignature,true);

                try
                {
                    Cert = X509Certificate2UI.SelectFromCollection(fcollection, "Elegir", "Seleccione el certificado que desea utilizar", X509SelectionFlag.SingleSelection)[0];
                    //textBox1.Text = Cert.RawData.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                store.Close();

                Org.BouncyCastle.X509.X509CertificateParser cp = new Org.BouncyCastle.X509.X509CertificateParser();
                Org.BouncyCastle.X509.X509Certificate[] chain = new Org.BouncyCastle.X509.X509Certificate[] { cp.ReadCertificate(Cert.RawData) };

                Sign_Remember(cteArchivoTemporal, strArchivoPaqueteResultado, chain);

                MessageBox.Show("Empaquetado y firmado completo.", "SIGEN", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                File.Move(cteArchivoTemporal, strArchivoPaqueteResultado);
                MessageBox.Show("Empaquetado completo.", "SIGEN", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            if (chkAbrirPaquete.Checked)
            {
                AbrirPDF(strArchivoPaqueteResultado);
            }
            pgsPack.Visible = false;

        
    }

        private void btnSign_Click(object sender, EventArgs e)
        {
            {
                X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadOnly);
                X509Certificate2Collection fcollection = store.Certificates.Find(X509FindType.FindByKeyUsage, X509KeyUsageFlags.DigitalSignature, true);
                //X509Certificate2Collection fcollection = collection.Find(X509FindType.FindByTimeValid, DateTime.Now, true).Find(X509FindType.FindByKeyUsage,X509KeyUsageFlags.DigitalSignature,true);

                try
                {
                    Cert = X509Certificate2UI.SelectFromCollection(fcollection, "Elegir", "Seleccione el certificado que desea utilizar", X509SelectionFlag.SingleSelection)[0];
                    //textBox1.Text = Cert.RawData.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                store.Close();

                if (dlgCarpetaSign.ShowDialog() == DialogResult.OK)
                {
                    strCarpetaSign = dlgCarpetaSign.SelectedPath;
                }
                else
                {
                    return;
                }

                Org.BouncyCastle.X509.X509CertificateParser cp = new Org.BouncyCastle.X509.X509CertificateParser();
                Org.BouncyCastle.X509.X509Certificate[] chain = new Org.BouncyCastle.X509.X509Certificate[] { cp.ReadCertificate(Cert.RawData) };

                string archivo;

                pgsSign.Minimum = 0;
                pgsSign.Value = 0;
                pgsSign.Maximum = lvwArchivosSign.CheckedItems.Count;

                foreach (ListViewItem item in lvwArchivosSign.CheckedItems)
                {
                    archivo = @tvwCarpetasSign.SelectedNode.FullPath + @"\" + item.Text;

                    Sign_Remember(archivo, strCarpetaSign + @"\Firmado_" + item.Text, chain);
                    pgsSign.Value++;
                    Application.DoEvents();
                }
                MessageBox.Show("Firmado completo", "Ok", MessageBoxButtons.OK);
            }

        }

        private void btnOCR_Click(object sender, EventArgs e)
        {
            {
                string OUTPUT_PDF = txtDestinoOCR.Text;
                Tesseract4OcrEngineProperties tesseract4OcrEngineProperties = new Tesseract4OcrEngineProperties();

                IList<FileInfo> LIST_IMAGES_OCR = new List<FileInfo>();
                LIST_IMAGES_OCR.Add(new FileInfo(txtOriginalOCR.Text));
                Tesseract4LibOcrEngine tesseractReader = new Tesseract4LibOcrEngine(tesseract4OcrEngineProperties);
                tesseract4OcrEngineProperties.SetPathToTessData(new FileInfo(Application.StartupPath + "\\tessdata"));

                var ocrPdfCreator = new OcrPdfCreator(tesseractReader);
                using (var writer = new PdfWriter(OUTPUT_PDF))
                {
                    ocrPdfCreator.CreatePdf(LIST_IMAGES_OCR, writer).Close();
                }
                MessageBox.Show("OCR completo.", "Ok", MessageBoxButtons.OK);
                AbrirPDF(OUTPUT_PDF);
            }
        }

        private void btnSplit2_Click(object sender, EventArgs e)
        {
            string origenSplit = txtTrozarOriginal.Text;
            string destinoSplit = txtTrozarDestino.Text;
            string rangeSplit = txtPaginasSplit.Text;

            if (origenSplit=="")
            {
                MessageBox.Show("No ha seleccionado el archivo origen.", "SIGEN", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (rangeSplit=="")
            {
                MessageBox.Show("No ha indicado las páginas a extraer.", "SIGEN", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            var pdfDocumentInvoiceNumber = new iText.Kernel.Pdf.PdfDocument(new iText.Kernel.Pdf.PdfReader(origenSplit));
            var split = new MySplitter(pdfDocumentInvoiceNumber);
            var result = split.ExtractPageRange(new PageRange(rangeSplit));
            result.Close();
            System.IO.File.Delete(destinoSplit);
            System.IO.File.Move(@"c:\temp\dividido.pdf", destinoSplit);
            MessageBox.Show("Extracción completa.", "Ok", MessageBoxButtons.OK);
            AbrirPDF(destinoSplit);

        }

        private void btnFusion_Click(object sender, EventArgs e)
        {
            string strArchivoFus;

            if (dlgArchivoFus.ShowDialog() == DialogResult.OK)
            {
                strArchivoFus = dlgArchivoFus.FileName;
            }
            else
            {
                return;
            }

            if (File.Exists(strArchivoFus))
            {
                DialogResult result = MessageBox.Show("El archivo indicado para contener el resultado de la unificación ya existe. \n ¿Desea sobreescribirlo?", "Confirma", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    File.Delete(cteArchivoTemporal);
                    File.Delete(strArchivoFus);
                }
                else
                {
                    return;
                }
            }


            pgsFus.Minimum = 0;
            pgsFus.Value = 0;
            pgsFus.Maximum = lvwArchivosFus.CheckedItems.Count;
            pgsFus.Visible = true;

            /*
            var pdfList = new List<byte[]> { };
            foreach (ListViewItem item in lvwArchivosFus.CheckedItems)
            {
                pdfList.Add(File.ReadAllBytes(tvwCarpetasFus.SelectedNode.FullPath + @"\" + item.Text));
                pgsFus.Value++;
                Application.DoEvents();
            }
            File.WriteAllBytes(strArchivoFus, Combine(pdfList));  Con este método se pierden los comments.
            */

            IDictionary<string, iText.Kernel.Pdf.PdfDocument> ListaPDFs=new SortedDictionary<string, iText.Kernel.Pdf.PdfDocument>();
            foreach (ListViewItem item in lvwArchivosFus.CheckedItems)
            {
                ListaPDFs.Add(item.Text, new iText.Kernel.Pdf.PdfDocument(new iText.Kernel.Pdf.PdfReader(tvwCarpetasFus.SelectedNode.FullPath + @"\" + item.Text)));
                pgsFus.Value++;
                Application.DoEvents();
            }
            
            iText.Kernel.Pdf.PdfDocument pdfMerged = new iText.Kernel.Pdf.PdfDocument(new PdfWriter(strArchivoFus));
            Document doc = new Document(pdfMerged);
            pdfMerged.InitializeOutlines();
            PdfPageFormCopier formCopier = new PdfPageFormCopier();

            IDictionary<int, string> toc = new SortedDictionary<int, string>();
            int page = 1;
            foreach (KeyValuePair<string, iText.Kernel.Pdf.PdfDocument> entry in ListaPDFs)
            {
                iText.Kernel.Pdf.PdfDocument srcDoc = entry.Value;
                int totPages = srcDoc.GetNumberOfPages();

                //var strDoc = entry.Key;
                toc.Add(page, entry.Key);

                for (int i = 1; i<= totPages; i++, page++)
                {
                    //iText.Layout.Element.Text text = new iText.Layout.Element.Text(String.Format("Pag. {0}", page));
                    iText.Layout.Element.Text text = new iText.Layout.Element.Text(String.Empty);
                    srcDoc.CopyPagesTo(i,i,pdfMerged,formCopier);
                    if (i == 1)
                    {
                        text.SetDestination("p" + page);
                    }

                    doc.Add(new Paragraph(text)
                        .SetFixedPosition(page, 549,810,40)
                        .SetMargin(0)
                        .SetMultipliedLeading(1));
                }
            }

            iText.Kernel.Pdf.PdfDocument tocDoc = new iText.Kernel.Pdf.PdfDocument(new iText.Kernel.Pdf.PdfWriter(cteArchivoTemporal));
            Document altDoc = new Document(tocDoc);
            tocDoc.SetDefaultPageSize(iText.Kernel.Geom.PageSize.A4);
            tocDoc.SetTagged();
            tocDoc.GetDocumentInfo().SetAuthor("SIGEN");

            iText.Layout.Element.Paragraph Titulo;

            Titulo = new iText.Layout.Element.Paragraph("Tabla de documentos incluidos").SetFontSize(14);
            altDoc.Add(Titulo);
            altDoc.Close();
            tocDoc.Close();
            tocDoc = new iText.Kernel.Pdf.PdfDocument(new PdfReader(cteArchivoTemporal));

            tocDoc.CopyPagesTo(1,1,pdfMerged,formCopier);

            float tocYCoordinate = 750;
            float tocXCoordinate = doc.GetLeftMargin();
            float tocWidth = pdfMerged.GetDefaultPageSize().GetWidth() - doc.GetLeftMargin() - doc.GetRightMargin();
            
            foreach (KeyValuePair<int, String> entry in toc)
            {
                Paragraph p = new Paragraph();
                p.AddTabStops(new TabStop(500, iText.Layout.Properties.TabAlignment.LEFT, new DashedLine()));
                p.Add(entry.Value);
                p.Add(new Tab());
                p.Add(entry.Key.ToString());
                p.SetAction(iText.Kernel.Pdf.Action.PdfAction.CreateGoTo("p" + entry.Key));
                doc.Add(p
                        .SetFixedPosition(pdfMerged.GetNumberOfPages(), tocXCoordinate, tocYCoordinate, tocWidth)
                        .SetMargin(0)
                        .SetMultipliedLeading(1));
                tocYCoordinate -= 20;
            }


            foreach (iText.Kernel.Pdf.PdfDocument srcDoc in ListaPDFs.Values)
            {
                srcDoc.Close();
            }
            tocDoc.Close();
            doc.Close();

            if (chkAbrirFus.Checked)
            {
                AbrirPDF(strArchivoFus);
            }
        }

        private void chkSelPack_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelPack.Checked)
            {
                foreach (ListViewItem item in lvwArchivosPack.Items)
                {
                    item.Checked = true;
                }
            }
            else
            {
                foreach (ListViewItem item in lvwArchivosPack.Items)
                {
                    item.Checked = false;
                }
            }
        }

        private void chkSelFus_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelFus.Checked)
            {
                foreach (ListViewItem item in lvwArchivosFus.Items)
                {
                    item.Checked = true;
                }
            }
            else
            {
                foreach (ListViewItem item in lvwArchivosFus.Items)
                {
                    item.Checked = false;
                }
            }


        }


        private void chkSelSign_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelSign.Checked)
            {
                foreach (ListViewItem item in lvwArchivosSign.Items)
                {
                    item.Checked = true;
                }
            }
            else
            {
                foreach (ListViewItem item in lvwArchivosSign.Items)
                {
                    item.Checked = false;
                }
            }

        }


        private void cboDrivesPack_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            PopulateTreeView(ref tvwCarpetasPack, cboDrivesPack.Text);
            lvwArchivosPack.Items.Clear();
        }

        private void panelEmpaquetador_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lvwArchivosPack_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            int archivos=0;
            long bytes=0;
            foreach (ListViewItem item in lvwArchivosPack.Items)
            {
                if (item.Checked)
                {
                    archivos++;
                    bytes += long.Parse(item.SubItems[3].Text);
                }
            }

            lblPackBytes.Text = archivos.ToString() + " archivos seleccionados, " + bytes.ToString() + " bytes";
        }


        private void tvwCarpetasPack_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void cboDrivesSign_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateTreeView(ref tvwCarpetasSign, cboDrivesSign.Text);
            lvwArchivosSign.Items.Clear();
        }

        private void cbDrivesFus_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateTreeView(ref tvwCarpetasFus, cbDrivesFus.Text);
            lvwArchivosFus.Items.Clear();
        }

        private void txtTrozarOriginal_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTrozarOriginal_Click(object sender, EventArgs e)
        {

            if (dlgTrozarOriginal.ShowDialog() == DialogResult.OK)
            {
                txtTrozarOriginal.Text = dlgTrozarOriginal.FileName;
            }
            else
            {
                return;
            }

        }

        private void txtTrozarDestino_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTrozarDestino_Click(object sender, EventArgs e)
        {
            if (dlgTrozarDestino.ShowDialog() == DialogResult.OK)
            {
                txtTrozarDestino.Text = dlgTrozarDestino.FileName;
            }
            else
            {
                return;
            }
        }

        private void txtOriginalOCR_Click(object sender, EventArgs e)
        {
            if (dlgOCROriginal.ShowDialog() == DialogResult.OK)
            {
                txtOriginalOCR.Text = dlgOCROriginal.FileName;
            }
            else
            {
                return;
            }
        }

        private void txtOriginalOCR_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDestinoOCR_Click(object sender, EventArgs e)
        {
            if (dlgOCRDestino.ShowDialog() == DialogResult.OK)
            {
                txtDestinoOCR.Text = dlgOCRDestino.FileName;
            }
            else
            {
                return;
            }
        }

        private void btnOCROriginal_Click(object sender, EventArgs e)
        {
            if (dlgOCROriginal.ShowDialog() == DialogResult.OK)
            {
                txtOriginalOCR.Text = dlgOCROriginal.FileName;
            }
            else
            {
                return;
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            String DEST = @"c:\temp\FazzitoRotado.pdf";
            String SRC = @"c:\temp\Fazzito.pdf";



            iText.Kernel.Pdf.PdfDocument pdfDoc = new iText.Kernel.Pdf.PdfDocument(new iText.Kernel.Pdf.PdfReader(SRC), new iText.Kernel.Pdf.PdfWriter(DEST));
            for (int p = 1; p <= pdfDoc.GetNumberOfPages(); p++)
            {
                iText.Kernel.Pdf.PdfPage page = pdfDoc.GetPage(p);
                int rotate = page.GetRotation();
                if (rotate == 0)
                {
                    page.SetRotation(90);
                }
                else
                {
                    page.SetRotation((rotate + 90) % 360);
                }
            }

            pdfDoc.Close();
        }

        private void lnkSourceCode_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/martinmasella/SIGENFirmador");
        }
    }
    class MySplitter : PdfSplitter
    {
        public MySplitter(iText.Kernel.Pdf.PdfDocument pdfDocument) : base(pdfDocument)
        {
        }

        protected override PdfWriter GetNextPdfWriter(PageRange documentPageRange)
        {
            String toFile = @"c:\Temp\Dividido.pdf";
            return new PdfWriter(toFile);
        }
    }
}
