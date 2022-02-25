namespace Nori.Kiosco
{
    partial class frmKiosco
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKiosco));
            this.txtNumeroDocumento = new DevExpress.XtraEditors.TextEdit();
            this.btnFacturar = new DevExpress.XtraEditors.SimpleButton();
            this.btnLimpiar = new DevExpress.XtraEditors.SimpleButton();
            this.txtPIN = new DevExpress.XtraEditors.TextEdit();
            this.lblPIN = new DevExpress.XtraEditors.LabelControl();
            this.lblDocumento = new DevExpress.XtraEditors.LabelControl();
            this.lblTitulo = new DevExpress.XtraEditors.LabelControl();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroDocumento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPIN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNumeroDocumento
            // 
            this.txtNumeroDocumento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumeroDocumento.Location = new System.Drawing.Point(31, 455);
            this.txtNumeroDocumento.Name = "txtNumeroDocumento";
            this.txtNumeroDocumento.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 30F);
            this.txtNumeroDocumento.Properties.Appearance.Options.UseFont = true;
            this.txtNumeroDocumento.Properties.Appearance.Options.UseTextOptions = true;
            this.txtNumeroDocumento.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtNumeroDocumento.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtNumeroDocumento.Size = new System.Drawing.Size(477, 54);
            this.txtNumeroDocumento.TabIndex = 0;
            this.txtNumeroDocumento.Enter += new System.EventHandler(this.txtNumeroDocumento_Enter);
            this.txtNumeroDocumento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNumeroDocumento_KeyDown);
            // 
            // btnFacturar
            // 
            this.btnFacturar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFacturar.Appearance.Font = new System.Drawing.Font("Tahoma", 20F);
            this.btnFacturar.Appearance.Options.UseFont = true;
            this.btnFacturar.Image = ((System.Drawing.Image)(resources.GetObject("btnFacturar.Image")));
            this.btnFacturar.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btnFacturar.Location = new System.Drawing.Point(529, 530);
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Size = new System.Drawing.Size(235, 54);
            this.btnFacturar.TabIndex = 0;
            this.btnFacturar.TabStop = false;
            this.btnFacturar.Text = "Facturar";
            this.btnFacturar.Click += new System.EventHandler(this.btnFacturar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLimpiar.Appearance.Font = new System.Drawing.Font("Tahoma", 20F);
            this.btnLimpiar.Appearance.Options.UseFont = true;
            this.btnLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.Image")));
            this.btnLimpiar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnLimpiar.Location = new System.Drawing.Point(31, 530);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(65, 54);
            this.btnLimpiar.TabIndex = 0;
            this.btnLimpiar.TabStop = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // txtPIN
            // 
            this.txtPIN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPIN.Location = new System.Drawing.Point(529, 455);
            this.txtPIN.Name = "txtPIN";
            this.txtPIN.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 30F);
            this.txtPIN.Properties.Appearance.Options.UseFont = true;
            this.txtPIN.Properties.Appearance.Options.UseTextOptions = true;
            this.txtPIN.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtPIN.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtPIN.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPIN.Properties.MaxLength = 6;
            this.txtPIN.Size = new System.Drawing.Size(235, 54);
            this.txtPIN.TabIndex = 1;
            this.txtPIN.Enter += new System.EventHandler(this.txtNumeroDocumento_Enter);
            this.txtPIN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPIN_KeyDown);
            // 
            // lblPIN
            // 
            this.lblPIN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPIN.Appearance.Font = new System.Drawing.Font("Tahoma", 20F);
            this.lblPIN.Location = new System.Drawing.Point(625, 416);
            this.lblPIN.Name = "lblPIN";
            this.lblPIN.Size = new System.Drawing.Size(43, 33);
            this.lblPIN.TabIndex = 5;
            this.lblPIN.Text = "PIN";
            // 
            // lblDocumento
            // 
            this.lblDocumento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDocumento.Appearance.Font = new System.Drawing.Font("Tahoma", 20F);
            this.lblDocumento.Location = new System.Drawing.Point(31, 416);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new System.Drawing.Size(136, 33);
            this.lblDocumento.TabIndex = 6;
            this.lblDocumento.Text = "Documento";
            // 
            // lblTitulo
            // 
            this.lblTitulo.Appearance.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblTitulo.AutoEllipsis = true;
            this.lblTitulo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(800, 77);
            this.lblTitulo.TabIndex = 7;
            this.lblTitulo.Text = "-";
            // 
            // pbLogo
            // 
            this.pbLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbLogo.Location = new System.Drawing.Point(31, 83);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(733, 327);
            this.pbLogo.TabIndex = 8;
            this.pbLogo.TabStop = false;
            // 
            // frmKiosco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblDocumento);
            this.Controls.Add(this.lblPIN);
            this.Controls.Add(this.txtPIN);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnFacturar);
            this.Controls.Add(this.txtNumeroDocumento);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmKiosco";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kiosco de facturación";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroDocumento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPIN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.TextEdit txtNumeroDocumento;
        private DevExpress.XtraEditors.SimpleButton btnFacturar;
        private DevExpress.XtraEditors.SimpleButton btnLimpiar;
        private DevExpress.XtraEditors.TextEdit txtPIN;
        private DevExpress.XtraEditors.LabelControl lblPIN;
        private DevExpress.XtraEditors.LabelControl lblDocumento;
        private DevExpress.XtraEditors.LabelControl lblTitulo;
        private System.Windows.Forms.PictureBox pbLogo;
    }
}