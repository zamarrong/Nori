namespace Nori.PuntoVenta
{
    partial class frmCanjes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCanjes));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblImporte = new System.Windows.Forms.Label();
            this.lblImporte_ = new System.Windows.Forms.Label();
            this.lblConceptoEgreso = new DevExpress.XtraEditors.LabelControl();
            this.lblConceptoIngreso = new DevExpress.XtraEditors.LabelControl();
            this.cbEgreso = new DevExpress.XtraEditors.LookUpEdit();
            this.cbIngreso = new DevExpress.XtraEditors.LookUpEdit();
            this.txtComentario = new DevExpress.XtraEditors.MemoEdit();
            this.lblComentario = new DevExpress.XtraEditors.LabelControl();
            this.txtCantidad = new DevExpress.XtraEditors.TextEdit();
            this.lblCantidad = new DevExpress.XtraEditors.LabelControl();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbEgreso.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbIngreso.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtComentario.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 1;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.OfficeUniversal;
            this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.Size = new System.Drawing.Size(402, 54);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.panel1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 54);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(402, 252);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblImporte);
            this.panel1.Controls.Add(this.lblImporte_);
            this.panel1.Controls.Add(this.lblConceptoEgreso);
            this.panel1.Controls.Add(this.lblConceptoIngreso);
            this.panel1.Controls.Add(this.cbEgreso);
            this.panel1.Controls.Add(this.cbIngreso);
            this.panel1.Controls.Add(this.txtComentario);
            this.panel1.Controls.Add(this.lblComentario);
            this.panel1.Controls.Add(this.txtCantidad);
            this.panel1.Controls.Add(this.lblCantidad);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnAceptar);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(378, 228);
            this.panel1.TabIndex = 0;
            // 
            // lblImporte
            // 
            this.lblImporte.AutoEllipsis = true;
            this.lblImporte.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.lblImporte.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblImporte.Location = new System.Drawing.Point(215, 158);
            this.lblImporte.Name = "lblImporte";
            this.lblImporte.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblImporte.Size = new System.Drawing.Size(153, 25);
            this.lblImporte.TabIndex = 69;
            this.lblImporte.Text = "0.00";
            // 
            // lblImporte_
            // 
            this.lblImporte_.AutoSize = true;
            this.lblImporte_.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblImporte_.Location = new System.Drawing.Point(154, 158);
            this.lblImporte_.Name = "lblImporte_";
            this.lblImporte_.Size = new System.Drawing.Size(54, 13);
            this.lblImporte_.TabIndex = 68;
            this.lblImporte_.Text = "Importe";
            // 
            // lblConceptoEgreso
            // 
            this.lblConceptoEgreso.Location = new System.Drawing.Point(12, 68);
            this.lblConceptoEgreso.Name = "lblConceptoEgreso";
            this.lblConceptoEgreso.Size = new System.Drawing.Size(82, 13);
            this.lblConceptoEgreso.TabIndex = 64;
            this.lblConceptoEgreso.Text = "Concepto egreso";
            // 
            // lblConceptoIngreso
            // 
            this.lblConceptoIngreso.Location = new System.Drawing.Point(12, 16);
            this.lblConceptoIngreso.Name = "lblConceptoIngreso";
            this.lblConceptoIngreso.Size = new System.Drawing.Size(84, 13);
            this.lblConceptoIngreso.TabIndex = 63;
            this.lblConceptoIngreso.Text = "Concepto ingreso";
            // 
            // cbEgreso
            // 
            this.cbEgreso.Location = new System.Drawing.Point(114, 65);
            this.cbEgreso.MenuManager = this.ribbonControl1;
            this.cbEgreso.Name = "cbEgreso";
            this.cbEgreso.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbEgreso.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nombre", "Nombre")});
            this.cbEgreso.Size = new System.Drawing.Size(250, 20);
            this.cbEgreso.TabIndex = 2;
            this.cbEgreso.EditValueChanged += new System.EventHandler(this.cbIngreso_EditValueChanged);
            // 
            // cbIngreso
            // 
            this.cbIngreso.Location = new System.Drawing.Point(114, 13);
            this.cbIngreso.MenuManager = this.ribbonControl1;
            this.cbIngreso.Name = "cbIngreso";
            this.cbIngreso.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbIngreso.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nombre", "Nombre")});
            this.cbIngreso.Size = new System.Drawing.Size(250, 20);
            this.cbIngreso.TabIndex = 0;
            this.cbIngreso.EditValueChanged += new System.EventHandler(this.cbIngreso_EditValueChanged);
            // 
            // txtComentario
            // 
            this.txtComentario.Location = new System.Drawing.Point(114, 91);
            this.txtComentario.MenuManager = this.ribbonControl1;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(250, 54);
            this.txtComentario.TabIndex = 3;
            // 
            // lblComentario
            // 
            this.lblComentario.Location = new System.Drawing.Point(12, 94);
            this.lblComentario.Name = "lblComentario";
            this.lblComentario.Size = new System.Drawing.Size(55, 13);
            this.lblComentario.TabIndex = 2;
            this.lblComentario.Text = "Comentario";
            // 
            // txtCantidad
            // 
            this.txtCantidad.EditValue = "1";
            this.txtCantidad.Location = new System.Drawing.Point(114, 39);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtCantidad.Properties.Appearance.Options.UseFont = true;
            this.txtCantidad.Properties.DisplayFormat.FormatString = "c2";
            this.txtCantidad.Properties.Mask.EditMask = "c2";
            this.txtCantidad.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtCantidad.Properties.MaxLength = 100;
            this.txtCantidad.Size = new System.Drawing.Size(250, 20);
            this.txtCantidad.TabIndex = 1;
            this.txtCantidad.TextChanged += new System.EventHandler(this.txtCantidad_TextChanged);
            // 
            // lblCantidad
            // 
            this.lblCantidad.Location = new System.Drawing.Point(12, 42);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(43, 13);
            this.lblCantidad.TabIndex = 60;
            this.lblCantidad.Text = "Cantidad";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancelar.Location = new System.Drawing.Point(12, 189);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(108, 27);
            this.btnCancelar.TabIndex = 0;
            this.btnCancelar.TabStop = false;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(152)))), ((int)(((byte)(33)))));
            this.btnAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(135)))), ((int)(((byte)(0)))));
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.Location = new System.Drawing.Point(256, 189);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(108, 27);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.TabStop = false;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(402, 252);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.panel1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(382, 232);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // frmCanjes
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(402, 306);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.ribbonControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmCanjes";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Canje";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbEgreso.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbIngreso.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtComentario.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private DevExpress.XtraEditors.TextEdit txtCantidad;
        private DevExpress.XtraEditors.LabelControl lblCantidad;
        private DevExpress.XtraEditors.MemoEdit txtComentario;
        private DevExpress.XtraEditors.LabelControl lblComentario;
        private DevExpress.XtraEditors.LookUpEdit cbEgreso;
        private DevExpress.XtraEditors.LookUpEdit cbIngreso;
        private DevExpress.XtraEditors.LabelControl lblConceptoIngreso;
        private DevExpress.XtraEditors.LabelControl lblConceptoEgreso;
        private System.Windows.Forms.Label lblImporte;
        private System.Windows.Forms.Label lblImporte_;
    }
}