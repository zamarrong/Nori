namespace Nori
{
    partial class frmCorreoElectronico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCorreoElectronico));
            this.panel1 = new DevExpress.XtraEditors.PanelControl();
            this.cbCorreoElectronico = new DevExpress.XtraEditors.LookUpEdit();
            this.lblCorreoElectronico = new DevExpress.XtraEditors.LabelControl();
            this.btnAnexo = new System.Windows.Forms.Button();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.lblAnexos = new DevExpress.XtraEditors.LabelControl();
            this.lbAnexos = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.txtDestinatario = new DevExpress.XtraEditors.TextEdit();
            this.lblDestinatario = new DevExpress.XtraEditors.LabelControl();
            this.lblDestinatarios = new DevExpress.XtraEditors.LabelControl();
            this.lbDestinatarios = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.lblMensaje = new DevExpress.XtraEditors.LabelControl();
            this.txtMensaje = new DevExpress.XtraEditors.MemoEdit();
            this.txtAsunto = new DevExpress.XtraEditors.TextEdit();
            this.lblAsunto = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbCorreoElectronico.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbAnexos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDestinatario.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbDestinatarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMensaje.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAsunto.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbCorreoElectronico);
            this.panel1.Controls.Add(this.lblCorreoElectronico);
            this.panel1.Controls.Add(this.btnAnexo);
            this.panel1.Controls.Add(this.btnEnviar);
            this.panel1.Controls.Add(this.lblAnexos);
            this.panel1.Controls.Add(this.lbAnexos);
            this.panel1.Controls.Add(this.txtDestinatario);
            this.panel1.Controls.Add(this.lblDestinatario);
            this.panel1.Controls.Add(this.lblDestinatarios);
            this.panel1.Controls.Add(this.lbDestinatarios);
            this.panel1.Controls.Add(this.lblMensaje);
            this.panel1.Controls.Add(this.txtMensaje);
            this.panel1.Controls.Add(this.txtAsunto);
            this.panel1.Controls.Add(this.lblAsunto);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(384, 413);
            this.panel1.TabIndex = 0;
            // 
            // cbCorreoElectronico
            // 
            this.cbCorreoElectronico.Location = new System.Drawing.Point(10, 29);
            this.cbCorreoElectronico.Name = "cbCorreoElectronico";
            this.cbCorreoElectronico.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbCorreoElectronico.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("usuario", "Correo electrónico")});
            this.cbCorreoElectronico.Size = new System.Drawing.Size(365, 20);
            this.cbCorreoElectronico.TabIndex = 57;
            this.cbCorreoElectronico.EditValueChanged += new System.EventHandler(this.cbCorreoElectronico_EditValueChanged);
            // 
            // lblCorreoElectronico
            // 
            this.lblCorreoElectronico.Location = new System.Drawing.Point(10, 10);
            this.lblCorreoElectronico.Name = "lblCorreoElectronico";
            this.lblCorreoElectronico.Size = new System.Drawing.Size(88, 13);
            this.lblCorreoElectronico.TabIndex = 56;
            this.lblCorreoElectronico.Text = "Correo electrónico";
            // 
            // btnAnexo
            // 
            this.btnAnexo.BackColor = System.Drawing.Color.LightSlateGray;
            this.btnAnexo.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray;
            this.btnAnexo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnexo.ForeColor = System.Drawing.Color.White;
            this.btnAnexo.Location = new System.Drawing.Point(10, 379);
            this.btnAnexo.Name = "btnAnexo";
            this.btnAnexo.Size = new System.Drawing.Size(94, 27);
            this.btnAnexo.TabIndex = 0;
            this.btnAnexo.Text = "Agregar anexo";
            this.btnAnexo.UseVisualStyleBackColor = false;
            this.btnAnexo.Click += new System.EventHandler(this.btnAnexo_Click);
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(152)))), ((int)(((byte)(33)))));
            this.btnEnviar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(135)))), ((int)(((byte)(0)))));
            this.btnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviar.ForeColor = System.Drawing.Color.White;
            this.btnEnviar.Location = new System.Drawing.Point(267, 379);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(108, 27);
            this.btnEnviar.TabIndex = 5;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = false;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // lblAnexos
            // 
            this.lblAnexos.Location = new System.Drawing.Point(10, 305);
            this.lblAnexos.Name = "lblAnexos";
            this.lblAnexos.Size = new System.Drawing.Size(36, 13);
            this.lblAnexos.TabIndex = 54;
            this.lblAnexos.Text = "Anexos";
            // 
            // lbAnexos
            // 
            this.lbAnexos.Location = new System.Drawing.Point(10, 324);
            this.lbAnexos.Name = "lbAnexos";
            this.lbAnexos.Size = new System.Drawing.Size(365, 50);
            this.lbAnexos.TabIndex = 4;
            // 
            // txtDestinatario
            // 
            this.txtDestinatario.Location = new System.Drawing.Point(10, 74);
            this.txtDestinatario.Name = "txtDestinatario";
            this.txtDestinatario.Properties.MaxLength = 254;
            this.txtDestinatario.Size = new System.Drawing.Size(365, 20);
            this.txtDestinatario.TabIndex = 0;
            // 
            // lblDestinatario
            // 
            this.lblDestinatario.Location = new System.Drawing.Point(10, 55);
            this.lblDestinatario.Name = "lblDestinatario";
            this.lblDestinatario.Size = new System.Drawing.Size(58, 13);
            this.lblDestinatario.TabIndex = 52;
            this.lblDestinatario.Text = "Destinatario";
            // 
            // lblDestinatarios
            // 
            this.lblDestinatarios.Location = new System.Drawing.Point(10, 230);
            this.lblDestinatarios.Name = "lblDestinatarios";
            this.lblDestinatarios.Size = new System.Drawing.Size(63, 13);
            this.lblDestinatarios.TabIndex = 50;
            this.lblDestinatarios.Text = "Destinatarios";
            // 
            // lbDestinatarios
            // 
            this.lbDestinatarios.Location = new System.Drawing.Point(10, 249);
            this.lbDestinatarios.Name = "lbDestinatarios";
            this.lbDestinatarios.Size = new System.Drawing.Size(365, 50);
            this.lbDestinatarios.TabIndex = 3;
            // 
            // lblMensaje
            // 
            this.lblMensaje.Location = new System.Drawing.Point(10, 145);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(40, 13);
            this.lblMensaje.TabIndex = 48;
            this.lblMensaje.Text = "Mensaje";
            // 
            // txtMensaje
            // 
            this.txtMensaje.Location = new System.Drawing.Point(10, 164);
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.Size = new System.Drawing.Size(365, 60);
            this.txtMensaje.TabIndex = 2;
            // 
            // txtAsunto
            // 
            this.txtAsunto.Location = new System.Drawing.Point(10, 119);
            this.txtAsunto.Name = "txtAsunto";
            this.txtAsunto.Properties.MaxLength = 254;
            this.txtAsunto.Size = new System.Drawing.Size(365, 20);
            this.txtAsunto.TabIndex = 1;
            // 
            // lblAsunto
            // 
            this.lblAsunto.Location = new System.Drawing.Point(10, 100);
            this.lblAsunto.Name = "lblAsunto";
            this.lblAsunto.Size = new System.Drawing.Size(34, 13);
            this.lblAsunto.TabIndex = 46;
            this.lblAsunto.Text = "Asunto";
            // 
            // frmCorreoElectronico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 413);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmCorreoElectronico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Correo electrónico";
            this.Load += new System.EventHandler(this.frmCorreoElectronico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbCorreoElectronico.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbAnexos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDestinatario.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbDestinatarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMensaje.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAsunto.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panel1;
        private DevExpress.XtraEditors.TextEdit txtAsunto;
        private DevExpress.XtraEditors.LabelControl lblAsunto;
        private DevExpress.XtraEditors.LabelControl lblMensaje;
        private DevExpress.XtraEditors.MemoEdit txtMensaje;
        private DevExpress.XtraEditors.CheckedListBoxControl lbDestinatarios;
        private DevExpress.XtraEditors.LabelControl lblDestinatarios;
        private DevExpress.XtraEditors.TextEdit txtDestinatario;
        private DevExpress.XtraEditors.LabelControl lblDestinatario;
        private DevExpress.XtraEditors.LabelControl lblAnexos;
        private DevExpress.XtraEditors.CheckedListBoxControl lbAnexos;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Button btnAnexo;
        private DevExpress.XtraEditors.LabelControl lblCorreoElectronico;
        private DevExpress.XtraEditors.LookUpEdit cbCorreoElectronico;
    }
}