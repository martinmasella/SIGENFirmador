
namespace SIGENFirmador
{
    partial class Main
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dlgArchivoPaquete = new System.Windows.Forms.SaveFileDialog();
            this.dlgCarpetaSign = new System.Windows.Forms.FolderBrowserDialog();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.dlgArchivoFus = new System.Windows.Forms.SaveFileDialog();
            this.dlgOCROriginal = new System.Windows.Forms.OpenFileDialog();
            this.dlgTrozarOriginal = new System.Windows.Forms.OpenFileDialog();
            this.dlgTrozarDestino = new System.Windows.Forms.SaveFileDialog();
            this.dlgOCRDestino = new System.Windows.Forms.SaveFileDialog();
            this.btnTest = new System.Windows.Forms.Button();
            this.lnkSourceCode = new System.Windows.Forms.LinkLabel();
            this.panelFusionador = new SIGENFirmador.PanelFirm();
            this.label14 = new System.Windows.Forms.Label();
            this.chkSelFus = new System.Windows.Forms.CheckBox();
            this.pgsFus = new System.Windows.Forms.ProgressBar();
            this.label12 = new System.Windows.Forms.Label();
            this.chkAbrirFus = new System.Windows.Forms.CheckBox();
            this.cbDrivesFus = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.chkFirmarFus = new System.Windows.Forms.CheckBox();
            this.btnFusion = new SIGENFirmador.tessdata.RoundBtn();
            this.lvwArchivosFus = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tvwCarpetasFus = new System.Windows.Forms.TreeView();
            this.panelDivisor = new SIGENFirmador.PanelFirm();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtTrozarDestino = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.btnSplit2 = new SIGENFirmador.tessdata.RoundBtn();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTrozarOriginal = new System.Windows.Forms.TextBox();
            this.txtPaginasSplit = new System.Windows.Forms.TextBox();
            this.panelOcr = new SIGENFirmador.PanelFirm();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOCROriginal = new System.Windows.Forms.Button();
            this.txtDestinoOCR = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnOCR = new SIGENFirmador.tessdata.RoundBtn();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOriginalOCR = new System.Windows.Forms.TextBox();
            this.panelFirmador = new SIGENFirmador.PanelFirm();
            this.label10 = new System.Windows.Forms.Label();
            this.chkSelSign = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSign = new SIGENFirmador.tessdata.RoundBtn();
            this.label8 = new System.Windows.Forms.Label();
            this.pgsSign = new System.Windows.Forms.ProgressBar();
            this.cboDrivesSign = new System.Windows.Forms.ComboBox();
            this.lvwArchivosSign = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tvwCarpetasSign = new System.Windows.Forms.TreeView();
            this.slpFusionar = new SIGENFirmador.SolapaFirm();
            this.slpDivisor = new SIGENFirmador.SolapaFirm();
            this.slpOcr = new SIGENFirmador.SolapaFirm();
            this.slpFirmar = new SIGENFirmador.SolapaFirm();
            this.slpEmpaquetar = new SIGENFirmador.SolapaFirm();
            this.panelEmpaquetador = new SIGENFirmador.PanelFirm();
            this.txtComentarioPack = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPackBytes = new System.Windows.Forms.Label();
            this.chkSelPack = new System.Windows.Forms.CheckBox();
            this.lvwArchivosPack = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tvwCarpetasPack = new System.Windows.Forms.TreeView();
            this.btnPack = new SIGENFirmador.tessdata.RoundBtn();
            this.pgsPack = new System.Windows.Forms.ProgressBar();
            this.chkAbrirPaquete = new System.Windows.Forms.CheckBox();
            this.cboDrivesPack = new System.Windows.Forms.ComboBox();
            this.chkFirmarPaquete = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panelFusionador.SuspendLayout();
            this.panelDivisor.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelOcr.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelFirmador.SuspendLayout();
            this.panelEmpaquetador.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(885, 268);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(309, 399);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // dlgArchivoPaquete
            // 
            this.dlgArchivoPaquete.DefaultExt = "PDF";
            this.dlgArchivoPaquete.FileName = "Paquete.pdf";
            this.dlgArchivoPaquete.Filter = "Archivos PDF|*.pdf";
            this.dlgArchivoPaquete.OverwritePrompt = false;
            this.dlgArchivoPaquete.RestoreDirectory = true;
            // 
            // dlgCarpetaSign
            // 
            this.dlgCarpetaSign.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(23)))), ((int)(((byte)(175)))));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1194, 80);
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(23)))), ((int)(((byte)(175)))));
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(32, 12);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(422, 55);
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(23)))), ((int)(((byte)(175)))));
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(1053, 14);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(100, 45);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 9;
            this.pictureBox4.TabStop = false;
            // 
            // dlgArchivoFus
            // 
            this.dlgArchivoFus.DefaultExt = "PDF";
            this.dlgArchivoFus.FileName = "Paquete.pdf";
            this.dlgArchivoFus.Filter = "Archivos PDF|*.pdf";
            this.dlgArchivoFus.InitialDirectory = "c:\\temp";
            this.dlgArchivoFus.OverwritePrompt = false;
            this.dlgArchivoFus.RestoreDirectory = true;
            // 
            // dlgOCROriginal
            // 
            this.dlgOCROriginal.DefaultExt = "jpg";
            this.dlgOCROriginal.Filter = "Imagenes JPG|*.jpg";
            this.dlgOCROriginal.Multiselect = true;
            this.dlgOCROriginal.RestoreDirectory = true;
            // 
            // dlgTrozarOriginal
            // 
            this.dlgTrozarOriginal.DefaultExt = "PDF";
            this.dlgTrozarOriginal.Filter = "Archivos PDF|*.PDF";
            this.dlgTrozarOriginal.RestoreDirectory = true;
            this.dlgTrozarOriginal.Title = "Seleccione el archivo original";
            // 
            // dlgTrozarDestino
            // 
            this.dlgTrozarDestino.DefaultExt = "PDF";
            this.dlgTrozarDestino.Filter = "Archivos PDF|*.PDF";
            this.dlgTrozarDestino.RestoreDirectory = true;
            this.dlgTrozarDestino.Title = "Indique el archivo destino";
            // 
            // dlgOCRDestino
            // 
            this.dlgOCRDestino.DefaultExt = "PDF";
            this.dlgOCRDestino.Filter = "Archivos PDF|*.PDF";
            this.dlgOCRDestino.RestoreDirectory = true;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(1214, 22);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(39, 28);
            this.btnTest.TabIndex = 30;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // lnkSourceCode
            // 
            this.lnkSourceCode.AutoSize = true;
            this.lnkSourceCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(23)))), ((int)(((byte)(175)))));
            this.lnkSourceCode.LinkColor = System.Drawing.SystemColors.ButtonFace;
            this.lnkSourceCode.Location = new System.Drawing.Point(1058, 63);
            this.lnkSourceCode.Name = "lnkSourceCode";
            this.lnkSourceCode.Size = new System.Drawing.Size(91, 13);
            this.lnkSourceCode.TabIndex = 31;
            this.lnkSourceCode.TabStop = true;
            this.lnkSourceCode.Text = "Ver código fuente";
            this.lnkSourceCode.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSourceCode_LinkClicked);
            // 
            // panelFusionador
            // 
            this.panelFusionador.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelFusionador.BorderRadius = 30;
            this.panelFusionador.Controls.Add(this.label14);
            this.panelFusionador.Controls.Add(this.chkSelFus);
            this.panelFusionador.Controls.Add(this.pgsFus);
            this.panelFusionador.Controls.Add(this.label12);
            this.panelFusionador.Controls.Add(this.chkAbrirFus);
            this.panelFusionador.Controls.Add(this.cbDrivesFus);
            this.panelFusionador.Controls.Add(this.label11);
            this.panelFusionador.Controls.Add(this.chkFirmarFus);
            this.panelFusionador.Controls.Add(this.btnFusion);
            this.panelFusionador.Controls.Add(this.lvwArchivosFus);
            this.panelFusionador.Controls.Add(this.tvwCarpetasFus);
            this.panelFusionador.ForeColor = System.Drawing.Color.Gray;
            this.panelFusionador.Location = new System.Drawing.Point(1825, 173);
            this.panelFusionador.Name = "panelFusionador";
            this.panelFusionador.Size = new System.Drawing.Size(814, 443);
            this.panelFusionador.TabIndex = 29;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(283, 54);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(131, 13);
            this.label14.TabIndex = 26;
            this.label14.Text = "3-Seleccione los archivos:";
            // 
            // chkSelFus
            // 
            this.chkSelFus.AutoSize = true;
            this.chkSelFus.Location = new System.Drawing.Point(290, 77);
            this.chkSelFus.Name = "chkSelFus";
            this.chkSelFus.Size = new System.Drawing.Size(15, 14);
            this.chkSelFus.TabIndex = 31;
            this.chkSelFus.UseVisualStyleBackColor = true;
            this.chkSelFus.CheckedChanged += new System.EventHandler(this.chkSelFus_CheckedChanged);
            // 
            // pgsFus
            // 
            this.pgsFus.Location = new System.Drawing.Point(22, 381);
            this.pgsFus.Name = "pgsFus";
            this.pgsFus.Size = new System.Drawing.Size(249, 23);
            this.pgsFus.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pgsFus.TabIndex = 29;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(21, 54);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(122, 13);
            this.label12.TabIndex = 25;
            this.label12.Text = "2-Seleccione la carpeta:";
            // 
            // chkAbrirFus
            // 
            this.chkAbrirFus.AutoSize = true;
            this.chkAbrirFus.Checked = true;
            this.chkAbrirFus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAbrirFus.Location = new System.Drawing.Point(430, 384);
            this.chkAbrirFus.Name = "chkAbrirFus";
            this.chkAbrirFus.Size = new System.Drawing.Size(96, 17);
            this.chkAbrirFus.TabIndex = 26;
            this.chkAbrirFus.Text = "Abrir al finalizar";
            this.chkAbrirFus.UseVisualStyleBackColor = true;
            // 
            // cbDrivesFus
            // 
            this.cbDrivesFus.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbDrivesFus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDrivesFus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbDrivesFus.FormattingEnabled = true;
            this.cbDrivesFus.Location = new System.Drawing.Point(24, 28);
            this.cbDrivesFus.Name = "cbDrivesFus";
            this.cbDrivesFus.Size = new System.Drawing.Size(249, 21);
            this.cbDrivesFus.TabIndex = 25;
            this.cbDrivesFus.SelectedIndexChanged += new System.EventHandler(this.cbDrivesFus_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(21, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(118, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "1-Seleccione la unidad:";
            // 
            // chkFirmarFus
            // 
            this.chkFirmarFus.AutoSize = true;
            this.chkFirmarFus.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkFirmarFus.Checked = true;
            this.chkFirmarFus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFirmarFus.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkFirmarFus.Location = new System.Drawing.Point(286, 384);
            this.chkFirmarFus.Name = "chkFirmarFus";
            this.chkFirmarFus.Size = new System.Drawing.Size(96, 17);
            this.chkFirmarFus.TabIndex = 24;
            this.chkFirmarFus.Text = "Firmar paquete";
            this.chkFirmarFus.UseVisualStyleBackColor = true;
            this.chkFirmarFus.Visible = false;
            // 
            // btnFusion
            // 
            this.btnFusion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(23)))), ((int)(((byte)(175)))));
            this.btnFusion.FlatAppearance.BorderSize = 0;
            this.btnFusion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFusion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFusion.ForeColor = System.Drawing.Color.White;
            this.btnFusion.Location = new System.Drawing.Point(656, 360);
            this.btnFusion.Name = "btnFusion";
            this.btnFusion.Size = new System.Drawing.Size(136, 40);
            this.btnFusion.TabIndex = 30;
            this.btnFusion.Text = "Unificar";
            this.btnFusion.UseVisualStyleBackColor = false;
            this.btnFusion.Click += new System.EventHandler(this.btnFusion_Click);
            // 
            // lvwArchivosFus
            // 
            this.lvwArchivosFus.BackColor = System.Drawing.Color.White;
            this.lvwArchivosFus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvwArchivosFus.CheckBoxes = true;
            this.lvwArchivosFus.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader9,
            this.columnHeader11});
            this.lvwArchivosFus.HideSelection = false;
            this.lvwArchivosFus.Location = new System.Drawing.Point(286, 70);
            this.lvwArchivosFus.Name = "lvwArchivosFus";
            this.lvwArchivosFus.Size = new System.Drawing.Size(506, 261);
            this.lvwArchivosFus.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvwArchivosFus.TabIndex = 23;
            this.lvwArchivosFus.UseCompatibleStateImageBehavior = false;
            this.lvwArchivosFus.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "           Nombre";
            this.columnHeader7.Width = 300;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Fecha";
            this.columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader9.Width = 100;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Tamaño (en bytes)";
            this.columnHeader11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader11.Width = 90;
            // 
            // tvwCarpetasFus
            // 
            this.tvwCarpetasFus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvwCarpetasFus.Location = new System.Drawing.Point(22, 70);
            this.tvwCarpetasFus.Name = "tvwCarpetasFus";
            this.tvwCarpetasFus.Size = new System.Drawing.Size(249, 262);
            this.tvwCarpetasFus.TabIndex = 22;
            // 
            // panelDivisor
            // 
            this.panelDivisor.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelDivisor.BorderRadius = 30;
            this.panelDivisor.Controls.Add(this.panel2);
            this.panelDivisor.ForeColor = System.Drawing.Color.Gray;
            this.panelDivisor.Location = new System.Drawing.Point(1822, 511);
            this.panelDivisor.Name = "panelDivisor";
            this.panelDivisor.Size = new System.Drawing.Size(814, 343);
            this.panelDivisor.TabIndex = 28;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.txtTrozarDestino);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.btnSplit2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtTrozarOriginal);
            this.panel2.Controls.Add(this.txtPaginasSplit);
            this.panel2.Location = new System.Drawing.Point(214, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(387, 251);
            this.panel2.TabIndex = 14;
            // 
            // txtTrozarDestino
            // 
            this.txtTrozarDestino.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtTrozarDestino.Location = new System.Drawing.Point(25, 136);
            this.txtTrozarDestino.Name = "txtTrozarDestino";
            this.txtTrozarDestino.ReadOnly = true;
            this.txtTrozarDestino.Size = new System.Drawing.Size(340, 20);
            this.txtTrozarDestino.TabIndex = 7;
            this.txtTrozarDestino.Text = "C:\\Temp\\Extraccion.pdf";
            this.txtTrozarDestino.Click += new System.EventHandler(this.txtTrozarDestino_Click);
            this.txtTrozarDestino.TextChanged += new System.EventHandler(this.txtTrozarDestino_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(22, 120);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(152, 13);
            this.label15.TabIndex = 6;
            this.label15.Text = "3-Indique el archivo resultante:";
            // 
            // btnSplit2
            // 
            this.btnSplit2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(23)))), ((int)(((byte)(175)))));
            this.btnSplit2.FlatAppearance.BorderSize = 0;
            this.btnSplit2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSplit2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSplit2.ForeColor = System.Drawing.Color.White;
            this.btnSplit2.Location = new System.Drawing.Point(131, 176);
            this.btnSplit2.Name = "btnSplit2";
            this.btnSplit2.Size = new System.Drawing.Size(136, 40);
            this.btnSplit2.TabIndex = 5;
            this.btnSplit2.Text = "Extraer";
            this.btnSplit2.UseVisualStyleBackColor = false;
            this.btnSplit2.Click += new System.EventHandler(this.btnSplit2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "1-Seleccione el archivo original:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(283, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "2-Indique las páginas a extraer (por ejemplo 1,2,3 o 10-20):";
            // 
            // txtTrozarOriginal
            // 
            this.txtTrozarOriginal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtTrozarOriginal.Location = new System.Drawing.Point(22, 37);
            this.txtTrozarOriginal.Name = "txtTrozarOriginal";
            this.txtTrozarOriginal.ReadOnly = true;
            this.txtTrozarOriginal.Size = new System.Drawing.Size(343, 20);
            this.txtTrozarOriginal.TabIndex = 3;
            this.txtTrozarOriginal.Click += new System.EventHandler(this.txtTrozarOriginal_Click);
            this.txtTrozarOriginal.TextChanged += new System.EventHandler(this.txtTrozarOriginal_TextChanged);
            // 
            // txtPaginasSplit
            // 
            this.txtPaginasSplit.Location = new System.Drawing.Point(25, 85);
            this.txtPaginasSplit.Name = "txtPaginasSplit";
            this.txtPaginasSplit.Size = new System.Drawing.Size(340, 20);
            this.txtPaginasSplit.TabIndex = 0;
            // 
            // panelOcr
            // 
            this.panelOcr.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelOcr.BorderRadius = 30;
            this.panelOcr.Controls.Add(this.panel1);
            this.panelOcr.ForeColor = System.Drawing.Color.Gray;
            this.panelOcr.Location = new System.Drawing.Point(960, 471);
            this.panelOcr.Name = "panelOcr";
            this.panelOcr.Size = new System.Drawing.Size(814, 443);
            this.panelOcr.TabIndex = 20;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnOCROriginal);
            this.panel1.Controls.Add(this.txtDestinoOCR);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.btnOCR);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtOriginalOCR);
            this.panel1.Location = new System.Drawing.Point(214, 118);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(387, 251);
            this.panel1.TabIndex = 13;
            // 
            // btnOCROriginal
            // 
            this.btnOCROriginal.Location = new System.Drawing.Point(340, 44);
            this.btnOCROriginal.Name = "btnOCROriginal";
            this.btnOCROriginal.Size = new System.Drawing.Size(25, 24);
            this.btnOCROriginal.TabIndex = 14;
            this.btnOCROriginal.Text = "...";
            this.btnOCROriginal.UseVisualStyleBackColor = true;
            this.btnOCROriginal.Click += new System.EventHandler(this.btnOCROriginal_Click);
            // 
            // txtDestinoOCR
            // 
            this.txtDestinoOCR.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtDestinoOCR.Location = new System.Drawing.Point(32, 87);
            this.txtDestinoOCR.Name = "txtDestinoOCR";
            this.txtDestinoOCR.ReadOnly = true;
            this.txtDestinoOCR.Size = new System.Drawing.Size(320, 20);
            this.txtDestinoOCR.TabIndex = 13;
            this.txtDestinoOCR.Text = "C:\\Temp\\OCR.pdf";
            this.txtDestinoOCR.Click += new System.EventHandler(this.txtDestinoOCR_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(29, 71);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(140, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "2-Indique el archivo destino:";
            // 
            // btnOCR
            // 
            this.btnOCR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(23)))), ((int)(((byte)(175)))));
            this.btnOCR.FlatAppearance.BorderSize = 0;
            this.btnOCR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOCR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOCR.ForeColor = System.Drawing.Color.White;
            this.btnOCR.Location = new System.Drawing.Point(126, 120);
            this.btnOCR.Name = "btnOCR";
            this.btnOCR.Size = new System.Drawing.Size(136, 40);
            this.btnOCR.TabIndex = 11;
            this.btnOCR.Text = "Procesar OCR";
            this.btnOCR.UseVisualStyleBackColor = false;
            this.btnOCR.Click += new System.EventHandler(this.btnOCR_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(29, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "1-Seleccione el archivo original:";
            // 
            // txtOriginalOCR
            // 
            this.txtOriginalOCR.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtOriginalOCR.Location = new System.Drawing.Point(32, 48);
            this.txtOriginalOCR.Name = "txtOriginalOCR";
            this.txtOriginalOCR.ReadOnly = true;
            this.txtOriginalOCR.Size = new System.Drawing.Size(302, 20);
            this.txtOriginalOCR.TabIndex = 9;
            this.txtOriginalOCR.Click += new System.EventHandler(this.txtOriginalOCR_Click);
            this.txtOriginalOCR.TextChanged += new System.EventHandler(this.txtOriginalOCR_TextChanged);
            // 
            // panelFirmador
            // 
            this.panelFirmador.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelFirmador.BorderRadius = 30;
            this.panelFirmador.Controls.Add(this.label10);
            this.panelFirmador.Controls.Add(this.chkSelSign);
            this.panelFirmador.Controls.Add(this.label9);
            this.panelFirmador.Controls.Add(this.btnSign);
            this.panelFirmador.Controls.Add(this.label8);
            this.panelFirmador.Controls.Add(this.pgsSign);
            this.panelFirmador.Controls.Add(this.cboDrivesSign);
            this.panelFirmador.Controls.Add(this.lvwArchivosSign);
            this.panelFirmador.Controls.Add(this.tvwCarpetasSign);
            this.panelFirmador.ForeColor = System.Drawing.Color.Gray;
            this.panelFirmador.Location = new System.Drawing.Point(982, 173);
            this.panelFirmador.Name = "panelFirmador";
            this.panelFirmador.Size = new System.Drawing.Size(814, 443);
            this.panelFirmador.TabIndex = 26;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(287, 54);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(131, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "3-Seleccione los archivos:";
            // 
            // chkSelSign
            // 
            this.chkSelSign.AutoSize = true;
            this.chkSelSign.Location = new System.Drawing.Point(290, 77);
            this.chkSelSign.Name = "chkSelSign";
            this.chkSelSign.Size = new System.Drawing.Size(15, 14);
            this.chkSelSign.TabIndex = 26;
            this.chkSelSign.UseVisualStyleBackColor = true;
            this.chkSelSign.CheckedChanged += new System.EventHandler(this.chkSelSign_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "2-Seleccione la carpeta:";
            // 
            // btnSign
            // 
            this.btnSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(23)))), ((int)(((byte)(175)))));
            this.btnSign.FlatAppearance.BorderSize = 0;
            this.btnSign.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSign.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSign.ForeColor = System.Drawing.Color.White;
            this.btnSign.Location = new System.Drawing.Point(656, 373);
            this.btnSign.Name = "btnSign";
            this.btnSign.Size = new System.Drawing.Size(136, 40);
            this.btnSign.TabIndex = 23;
            this.btnSign.Text = "Firmar";
            this.btnSign.UseVisualStyleBackColor = false;
            this.btnSign.Click += new System.EventHandler(this.btnSign_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "1-Seleccione la unidad:";
            // 
            // pgsSign
            // 
            this.pgsSign.Location = new System.Drawing.Point(22, 381);
            this.pgsSign.Name = "pgsSign";
            this.pgsSign.Size = new System.Drawing.Size(249, 23);
            this.pgsSign.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pgsSign.TabIndex = 22;
            // 
            // cboDrivesSign
            // 
            this.cboDrivesSign.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboDrivesSign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDrivesSign.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboDrivesSign.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cboDrivesSign.FormattingEnabled = true;
            this.cboDrivesSign.Location = new System.Drawing.Point(22, 28);
            this.cboDrivesSign.Name = "cboDrivesSign";
            this.cboDrivesSign.Size = new System.Drawing.Size(249, 21);
            this.cboDrivesSign.TabIndex = 21;
            this.cboDrivesSign.SelectedIndexChanged += new System.EventHandler(this.cboDrivesSign_SelectedIndexChanged);
            // 
            // lvwArchivosSign
            // 
            this.lvwArchivosSign.BackColor = System.Drawing.Color.White;
            this.lvwArchivosSign.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvwArchivosSign.CheckBoxes = true;
            this.lvwArchivosSign.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader8});
            this.lvwArchivosSign.HideSelection = false;
            this.lvwArchivosSign.Location = new System.Drawing.Point(286, 70);
            this.lvwArchivosSign.Name = "lvwArchivosSign";
            this.lvwArchivosSign.Size = new System.Drawing.Size(506, 261);
            this.lvwArchivosSign.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvwArchivosSign.TabIndex = 20;
            this.lvwArchivosSign.UseCompatibleStateImageBehavior = false;
            this.lvwArchivosSign.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "              Nombre";
            this.columnHeader5.Width = 300;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Fecha";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 200;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Tamaño (en bytes)";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader8.Width = 100;
            // 
            // tvwCarpetasSign
            // 
            this.tvwCarpetasSign.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvwCarpetasSign.Location = new System.Drawing.Point(22, 70);
            this.tvwCarpetasSign.Name = "tvwCarpetasSign";
            this.tvwCarpetasSign.Size = new System.Drawing.Size(249, 262);
            this.tvwCarpetasSign.TabIndex = 19;
            // 
            // slpFusionar
            // 
            this.slpFusionar.BackColor = System.Drawing.Color.Gray;
            this.slpFusionar.FlatAppearance.BorderSize = 0;
            this.slpFusionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.slpFusionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slpFusionar.ForeColor = System.Drawing.Color.White;
            this.slpFusionar.Location = new System.Drawing.Point(653, 134);
            this.slpFusionar.Name = "slpFusionar";
            this.slpFusionar.Size = new System.Drawing.Size(152, 40);
            this.slpFusionar.TabIndex = 25;
            this.slpFusionar.Text = "Unificar PDFs";
            this.slpFusionar.UseVisualStyleBackColor = false;
            this.slpFusionar.Click += new System.EventHandler(this.slpFusionar_Click);
            // 
            // slpDivisor
            // 
            this.slpDivisor.BackColor = System.Drawing.Color.Gray;
            this.slpDivisor.FlatAppearance.BorderSize = 0;
            this.slpDivisor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.slpDivisor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slpDivisor.ForeColor = System.Drawing.Color.White;
            this.slpDivisor.Location = new System.Drawing.Point(489, 134);
            this.slpDivisor.Name = "slpDivisor";
            this.slpDivisor.Size = new System.Drawing.Size(163, 40);
            this.slpDivisor.TabIndex = 24;
            this.slpDivisor.Text = "Extraer páginas";
            this.slpDivisor.UseVisualStyleBackColor = false;
            this.slpDivisor.Click += new System.EventHandler(this.slpDivisor_Click);
            // 
            // slpOcr
            // 
            this.slpOcr.BackColor = System.Drawing.Color.Gray;
            this.slpOcr.FlatAppearance.BorderSize = 0;
            this.slpOcr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.slpOcr.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slpOcr.ForeColor = System.Drawing.Color.White;
            this.slpOcr.Location = new System.Drawing.Point(336, 134);
            this.slpOcr.Name = "slpOcr";
            this.slpOcr.Size = new System.Drawing.Size(152, 40);
            this.slpOcr.TabIndex = 23;
            this.slpOcr.Text = "Pasar OCR";
            this.slpOcr.UseVisualStyleBackColor = false;
            this.slpOcr.Click += new System.EventHandler(this.slpOcr_Click);
            // 
            // slpFirmar
            // 
            this.slpFirmar.BackColor = System.Drawing.Color.Gray;
            this.slpFirmar.FlatAppearance.BorderSize = 0;
            this.slpFirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.slpFirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slpFirmar.ForeColor = System.Drawing.Color.White;
            this.slpFirmar.Location = new System.Drawing.Point(183, 134);
            this.slpFirmar.Name = "slpFirmar";
            this.slpFirmar.Size = new System.Drawing.Size(152, 40);
            this.slpFirmar.TabIndex = 22;
            this.slpFirmar.Text = "Firmar digitalmente";
            this.slpFirmar.UseVisualStyleBackColor = false;
            this.slpFirmar.Click += new System.EventHandler(this.slpFirmar_Click);
            // 
            // slpEmpaquetar
            // 
            this.slpEmpaquetar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(23)))), ((int)(((byte)(175)))));
            this.slpEmpaquetar.FlatAppearance.BorderSize = 0;
            this.slpEmpaquetar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.slpEmpaquetar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slpEmpaquetar.ForeColor = System.Drawing.Color.White;
            this.slpEmpaquetar.Location = new System.Drawing.Point(30, 134);
            this.slpEmpaquetar.Name = "slpEmpaquetar";
            this.slpEmpaquetar.Size = new System.Drawing.Size(152, 40);
            this.slpEmpaquetar.TabIndex = 21;
            this.slpEmpaquetar.Text = "Empaquetar en PDF";
            this.slpEmpaquetar.UseVisualStyleBackColor = false;
            this.slpEmpaquetar.Click += new System.EventHandler(this.slpEmpaquetar_Click);
            // 
            // panelEmpaquetador
            // 
            this.panelEmpaquetador.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelEmpaquetador.BorderRadius = 30;
            this.panelEmpaquetador.Controls.Add(this.txtComentarioPack);
            this.panelEmpaquetador.Controls.Add(this.label1);
            this.panelEmpaquetador.Controls.Add(this.label7);
            this.panelEmpaquetador.Controls.Add(this.label6);
            this.panelEmpaquetador.Controls.Add(this.label5);
            this.panelEmpaquetador.Controls.Add(this.lblPackBytes);
            this.panelEmpaquetador.Controls.Add(this.chkSelPack);
            this.panelEmpaquetador.Controls.Add(this.lvwArchivosPack);
            this.panelEmpaquetador.Controls.Add(this.tvwCarpetasPack);
            this.panelEmpaquetador.Controls.Add(this.btnPack);
            this.panelEmpaquetador.Controls.Add(this.pgsPack);
            this.panelEmpaquetador.Controls.Add(this.chkAbrirPaquete);
            this.panelEmpaquetador.Controls.Add(this.cboDrivesPack);
            this.panelEmpaquetador.Controls.Add(this.chkFirmarPaquete);
            this.panelEmpaquetador.ForeColor = System.Drawing.Color.Gray;
            this.panelEmpaquetador.Location = new System.Drawing.Point(32, 173);
            this.panelEmpaquetador.Name = "panelEmpaquetador";
            this.panelEmpaquetador.Size = new System.Drawing.Size(814, 443);
            this.panelEmpaquetador.TabIndex = 20;
            this.panelEmpaquetador.Paint += new System.Windows.Forms.PaintEventHandler(this.panelEmpaquetador_Paint);
            // 
            // txtComentarioPack
            // 
            this.txtComentarioPack.Location = new System.Drawing.Point(90, 412);
            this.txtComentarioPack.Name = "txtComentarioPack";
            this.txtComentarioPack.Size = new System.Drawing.Size(559, 20);
            this.txtComentarioPack.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 416);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Comentario:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(283, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(131, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "3-Seleccione los archivos:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "2-Seleccione la carpeta:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "1-Seleccione la unidad:";
            // 
            // lblPackBytes
            // 
            this.lblPackBytes.Location = new System.Drawing.Point(283, 342);
            this.lblPackBytes.Name = "lblPackBytes";
            this.lblPackBytes.Size = new System.Drawing.Size(509, 22);
            this.lblPackBytes.TabIndex = 23;
            // 
            // chkSelPack
            // 
            this.chkSelPack.AutoSize = true;
            this.chkSelPack.Location = new System.Drawing.Point(290, 77);
            this.chkSelPack.Name = "chkSelPack";
            this.chkSelPack.Size = new System.Drawing.Size(15, 14);
            this.chkSelPack.TabIndex = 22;
            this.chkSelPack.UseVisualStyleBackColor = true;
            this.chkSelPack.CheckedChanged += new System.EventHandler(this.chkSelPack_CheckedChanged);
            // 
            // lvwArchivosPack
            // 
            this.lvwArchivosPack.AutoArrange = false;
            this.lvwArchivosPack.BackColor = System.Drawing.Color.White;
            this.lvwArchivosPack.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvwArchivosPack.CheckBoxes = true;
            this.lvwArchivosPack.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvwArchivosPack.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lvwArchivosPack.HideSelection = false;
            this.lvwArchivosPack.Location = new System.Drawing.Point(286, 70);
            this.lvwArchivosPack.Name = "lvwArchivosPack";
            this.lvwArchivosPack.Size = new System.Drawing.Size(506, 261);
            this.lvwArchivosPack.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvwArchivosPack.TabIndex = 21;
            this.lvwArchivosPack.UseCompatibleStateImageBehavior = false;
            this.lvwArchivosPack.View = System.Windows.Forms.View.Details;
            this.lvwArchivosPack.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvwArchivosPack_ItemChecked);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "           Nombre";
            this.columnHeader1.Width = 180;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Fecha";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Tipo";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 150;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Tamaño (en bytes)";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader4.Width = 82;
            // 
            // tvwCarpetasPack
            // 
            this.tvwCarpetasPack.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvwCarpetasPack.Location = new System.Drawing.Point(22, 70);
            this.tvwCarpetasPack.Name = "tvwCarpetasPack";
            this.tvwCarpetasPack.Size = new System.Drawing.Size(249, 262);
            this.tvwCarpetasPack.TabIndex = 20;
            this.tvwCarpetasPack.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwCarpetasPack_AfterSelect);
            // 
            // btnPack
            // 
            this.btnPack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(23)))), ((int)(((byte)(175)))));
            this.btnPack.FlatAppearance.BorderSize = 0;
            this.btnPack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPack.ForeColor = System.Drawing.Color.White;
            this.btnPack.Location = new System.Drawing.Point(656, 373);
            this.btnPack.Name = "btnPack";
            this.btnPack.Size = new System.Drawing.Size(136, 40);
            this.btnPack.TabIndex = 19;
            this.btnPack.Text = "Empaquetar";
            this.btnPack.UseVisualStyleBackColor = false;
            this.btnPack.Click += new System.EventHandler(this.btnPack_Click);
            // 
            // pgsPack
            // 
            this.pgsPack.Location = new System.Drawing.Point(22, 381);
            this.pgsPack.Name = "pgsPack";
            this.pgsPack.Size = new System.Drawing.Size(249, 23);
            this.pgsPack.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pgsPack.TabIndex = 17;
            // 
            // chkAbrirPaquete
            // 
            this.chkAbrirPaquete.AutoSize = true;
            this.chkAbrirPaquete.Checked = true;
            this.chkAbrirPaquete.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAbrirPaquete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAbrirPaquete.Location = new System.Drawing.Point(539, 384);
            this.chkAbrirPaquete.Name = "chkAbrirPaquete";
            this.chkAbrirPaquete.Size = new System.Drawing.Size(110, 19);
            this.chkAbrirPaquete.TabIndex = 16;
            this.chkAbrirPaquete.Text = "Abrir al finalizar";
            this.chkAbrirPaquete.UseVisualStyleBackColor = true;
            // 
            // cboDrivesPack
            // 
            this.cboDrivesPack.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboDrivesPack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDrivesPack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboDrivesPack.FormattingEnabled = true;
            this.cboDrivesPack.Location = new System.Drawing.Point(24, 28);
            this.cboDrivesPack.Name = "cboDrivesPack";
            this.cboDrivesPack.Size = new System.Drawing.Size(249, 21);
            this.cboDrivesPack.TabIndex = 15;
            this.cboDrivesPack.SelectedIndexChanged += new System.EventHandler(this.cboDrivesPack_SelectedIndexChanged_1);
            // 
            // chkFirmarPaquete
            // 
            this.chkFirmarPaquete.AutoSize = true;
            this.chkFirmarPaquete.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkFirmarPaquete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFirmarPaquete.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkFirmarPaquete.Location = new System.Drawing.Point(294, 384);
            this.chkFirmarPaquete.Name = "chkFirmarPaquete";
            this.chkFirmarPaquete.Size = new System.Drawing.Size(110, 19);
            this.chkFirmarPaquete.TabIndex = 14;
            this.chkFirmarPaquete.Text = "Firmar paquete";
            this.chkFirmarPaquete.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.lnkSourceCode);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.panelFusionador);
            this.Controls.Add(this.panelDivisor);
            this.Controls.Add(this.panelOcr);
            this.Controls.Add(this.panelFirmador);
            this.Controls.Add(this.slpFusionar);
            this.Controls.Add(this.slpDivisor);
            this.Controls.Add(this.slpOcr);
            this.Controls.Add(this.slpFirmar);
            this.Controls.Add(this.slpEmpaquetar);
            this.Controls.Add(this.panelEmpaquetador);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "Firmador";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panelFusionador.ResumeLayout(false);
            this.panelFusionador.PerformLayout();
            this.panelDivisor.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelOcr.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelFirmador.ResumeLayout(false);
            this.panelFirmador.PerformLayout();
            this.panelEmpaquetador.ResumeLayout(false);
            this.panelEmpaquetador.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.SaveFileDialog dlgArchivoPaquete;
        private System.Windows.Forms.FolderBrowserDialog dlgCarpetaSign;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.SaveFileDialog dlgArchivoFus;
        private PanelFirm panelEmpaquetador;
        private tessdata.RoundBtn btnPack;
        private System.Windows.Forms.ProgressBar pgsPack;
        private System.Windows.Forms.CheckBox chkAbrirPaquete;
        private System.Windows.Forms.ComboBox cboDrivesPack;
        private System.Windows.Forms.CheckBox chkFirmarPaquete;
        private System.Windows.Forms.TreeView tvwCarpetasPack;
        private SolapaFirm slpFusionar;
        private SolapaFirm slpDivisor;
        private SolapaFirm slpOcr;
        private SolapaFirm slpFirmar;
        private SolapaFirm slpEmpaquetar;
        private PanelFirm panelFirmador;
        private tessdata.RoundBtn btnSign;
        private System.Windows.Forms.ProgressBar pgsSign;
        private System.Windows.Forms.ComboBox cboDrivesSign;
        private System.Windows.Forms.ListView lvwArchivosSign;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.TreeView tvwCarpetasSign;
        private System.Windows.Forms.CheckBox chkSelPack;
        private System.Windows.Forms.ListView lvwArchivosPack;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.CheckBox chkSelSign;
        private PanelFirm panelOcr;
        private System.Windows.Forms.Panel panel1;
        private tessdata.RoundBtn btnOCR;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOriginalOCR;
        private PanelFirm panelDivisor;
        private System.Windows.Forms.Panel panel2;
        private tessdata.RoundBtn btnSplit2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTrozarOriginal;
        private System.Windows.Forms.TextBox txtPaginasSplit;
        private PanelFirm panelFusionador;
        private System.Windows.Forms.CheckBox chkSelFus;
        private System.Windows.Forms.ProgressBar pgsFus;
        private System.Windows.Forms.CheckBox chkAbrirFus;
        private System.Windows.Forms.ComboBox cbDrivesFus;
        private System.Windows.Forms.CheckBox chkFirmarFus;
        private tessdata.RoundBtn btnFusion;
        private System.Windows.Forms.ListView lvwArchivosFus;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.TreeView tvwCarpetasFus;
        private System.Windows.Forms.Label lblPackBytes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.OpenFileDialog dlgOCROriginal;
        private System.Windows.Forms.TextBox txtTrozarDestino;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.OpenFileDialog dlgTrozarOriginal;
        private System.Windows.Forms.SaveFileDialog dlgTrozarDestino;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtDestinoOCR;
        private System.Windows.Forms.SaveFileDialog dlgOCRDestino;
        private System.Windows.Forms.Button btnOCROriginal;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.TextBox txtComentarioPack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lnkSourceCode;
    }
}

