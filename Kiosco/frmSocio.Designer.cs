namespace Nori.Kiosco
{
    partial class frmSocio
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSocio));
            this.txtCodigo = new DevExpress.XtraEditors.TextEdit();
            this.txtNombre = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.txtRFC = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lblInfo = new DevExpress.XtraEditors.LabelControl();
            this.btnCerrar = new DevExpress.XtraEditors.SimpleButton();
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.btnAlta = new DevExpress.XtraEditors.SimpleButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblError = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRFC.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(158, 72);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 20F);
            this.txtCodigo.Properties.Appearance.Options.UseFont = true;
            this.txtCodigo.Size = new System.Drawing.Size(175, 40);
            this.txtCodigo.TabIndex = 0;
            this.txtCodigo.TextChanged += new System.EventHandler(this.textEdit1_TextChanged);
            this.txtCodigo.Enter += new System.EventHandler(this.txtNombre_Enter);
            this.txtCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNombre_KeyDown);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(158, 128);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 20F);
            this.txtNombre.Properties.Appearance.Options.UseFont = true;
            this.txtNombre.Size = new System.Drawing.Size(427, 40);
            this.txtNombre.TabIndex = 1;
            this.txtNombre.EditValueChanged += new System.EventHandler(this.textEdit2_EditValueChanged);
            this.txtNombre.Enter += new System.EventHandler(this.txtNombre_Enter);
            this.txtNombre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNombre_KeyDown);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 20F);
            this.labelControl1.Location = new System.Drawing.Point(12, 75);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(123, 33);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Código SN";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 20F);
            this.labelControl2.Location = new System.Drawing.Point(40, 131);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(95, 33);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Nombre";
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinMaskColor = System.Drawing.Color.Azure;
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2016 Colorful";
            // 
            // txtRFC
            // 
            this.txtRFC.Location = new System.Drawing.Point(158, 180);
            this.txtRFC.Name = "txtRFC";
            this.txtRFC.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 20F);
            this.txtRFC.Properties.Appearance.Options.UseFont = true;
            this.txtRFC.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRFC.Size = new System.Drawing.Size(254, 40);
            this.txtRFC.TabIndex = 7;
            this.txtRFC.Enter += new System.EventHandler(this.txtNombre_Enter);
            this.txtRFC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNombre_KeyDown);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 20F);
            this.labelControl3.Location = new System.Drawing.Point(64, 187);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(71, 33);
            this.labelControl3.TabIndex = 8;
            this.labelControl3.Text = "R.F.C.";
            // 
            // lblInfo
            // 
            this.lblInfo.Appearance.Font = new System.Drawing.Font("Tahoma", 20F);
            this.lblInfo.Location = new System.Drawing.Point(12, 12);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(571, 33);
            this.lblInfo.TabIndex = 10;
            this.lblInfo.Text = "Busqueda del socio por código, nombre o R.F.C.";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Appearance.Font = new System.Drawing.Font("Tahoma", 20F);
            this.btnCerrar.Appearance.Options.UseFont = true;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnCerrar.Location = new System.Drawing.Point(12, 236);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(60, 46);
            this.btnCerrar.TabIndex = 37;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Appearance.Font = new System.Drawing.Font("Tahoma", 20F);
            this.btnAceptar.Appearance.Options.UseFont = true;
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btnAceptar.Location = new System.Drawing.Point(158, 233);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(427, 46);
            this.btnAceptar.TabIndex = 38;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Appearance.Font = new System.Drawing.Font("Tahoma", 20F);
            this.btnBuscar.Appearance.Options.UseFont = true;
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btnBuscar.Location = new System.Drawing.Point(602, 67);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(146, 46);
            this.btnBuscar.TabIndex = 39;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnAlta
            // 
            this.btnAlta.Appearance.Font = new System.Drawing.Font("Tahoma", 20F);
            this.btnAlta.Appearance.Options.UseFont = true;
            this.btnAlta.Image = ((System.Drawing.Image)(resources.GetObject("btnAlta.Image")));
            this.btnAlta.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btnAlta.Location = new System.Drawing.Point(602, 233);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.Size = new System.Drawing.Size(146, 46);
            this.btnAlta.TabIndex = 40;
            this.btnAlta.Text = "Nuevo";
            this.btnAlta.Click += new System.EventHandler(this.btnAlta_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Tahoma", 20F);
            this.lblError.ForeColor = System.Drawing.Color.Firebrick;
            this.lblError.Location = new System.Drawing.Point(6, 285);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(75, 33);
            this.lblError.TabIndex = 11;
            this.lblError.Text = "Error";
            this.lblError.Visible = false;
            // 
            // frmSocio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 319);
            this.ControlBox = false;
            this.Controls.Add(this.btnAlta);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtRFC);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtCodigo);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSocio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Socio";
            this.Load += new System.EventHandler(this.frmSocio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRFC.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtCodigo;
        private DevExpress.XtraEditors.TextEdit txtNombre;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraEditors.TextEdit txtRFC;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl lblInfo;
        private DevExpress.XtraEditors.SimpleButton btnCerrar;
        private DevExpress.XtraEditors.SimpleButton btnAceptar;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
        private DevExpress.XtraEditors.SimpleButton btnAlta;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblError;
    }
}