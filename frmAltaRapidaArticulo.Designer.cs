namespace Nori
{
    partial class frmAltaRapidaArticulo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAltaRapidaArticulo));
            this.mainRibbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.backstageViewControl1 = new DevExpress.XtraBars.Ribbon.BackstageViewControl();
            this.bbiGuardarCerrar = new DevExpress.XtraBars.BarButtonItem();
            this.mainRibbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mainRibbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnGenerarSKU = new DevExpress.XtraEditors.SimpleButton();
            this.lblPrecio = new DevExpress.XtraEditors.LabelControl();
            this.txtPrecio = new DevExpress.XtraEditors.TextEdit();
            this.lblGruposArticulo = new DevExpress.XtraEditors.LabelControl();
            this.cbGruposArticulos = new DevExpress.XtraEditors.LookUpEdit();
            this.lblDescripcion = new DevExpress.XtraEditors.LabelControl();
            this.txtDescripcion = new DevExpress.XtraEditors.TextEdit();
            this.lblNombre = new DevExpress.XtraEditors.LabelControl();
            this.txtNombre = new DevExpress.XtraEditors.TextEdit();
            this.lblSKU = new DevExpress.XtraEditors.LabelControl();
            this.txtSKU = new DevExpress.XtraEditors.TextEdit();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backstageViewControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbGruposArticulos.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSKU.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainRibbonControl
            // 
            this.mainRibbonControl.ApplicationButtonDropDownControl = this.backstageViewControl1;
            this.mainRibbonControl.ExpandCollapseItem.Id = 0;
            this.mainRibbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.mainRibbonControl.ExpandCollapseItem,
            this.bbiGuardarCerrar});
            this.mainRibbonControl.Location = new System.Drawing.Point(0, 0);
            this.mainRibbonControl.MaxItemId = 3;
            this.mainRibbonControl.Name = "mainRibbonControl";
            this.mainRibbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.mainRibbonPage});
            this.mainRibbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.OfficeUniversal;
            this.mainRibbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.mainRibbonControl.Size = new System.Drawing.Size(553, 79);
            this.mainRibbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // backstageViewControl1
            // 
            this.backstageViewControl1.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Yellow;
            this.backstageViewControl1.Location = new System.Drawing.Point(41, 124);
            this.backstageViewControl1.Name = "backstageViewControl1";
            this.backstageViewControl1.OwnerControl = this.mainRibbonControl;
            this.backstageViewControl1.Size = new System.Drawing.Size(480, 150);
            this.backstageViewControl1.TabIndex = 2;
            // 
            // bbiGuardarCerrar
            // 
            this.bbiGuardarCerrar.Caption = "Guardar y cerrar";
            this.bbiGuardarCerrar.Id = 3;
            this.bbiGuardarCerrar.ImageUri.Uri = "SaveAndClose";
            this.bbiGuardarCerrar.Name = "bbiGuardarCerrar";
            this.bbiGuardarCerrar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiGuardarCerrar_ItemClick);
            // 
            // mainRibbonPage
            // 
            this.mainRibbonPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.mainRibbonPageGroup});
            this.mainRibbonPage.MergeOrder = 0;
            this.mainRibbonPage.Name = "mainRibbonPage";
            this.mainRibbonPage.Text = "ARCHIVO";
            // 
            // mainRibbonPageGroup
            // 
            this.mainRibbonPageGroup.AllowTextClipping = false;
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiGuardarCerrar);
            this.mainRibbonPageGroup.Name = "mainRibbonPageGroup";
            this.mainRibbonPageGroup.ShowCaptionButton = false;
            this.mainRibbonPageGroup.Text = "Opciones";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(553, 171);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.panelControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(533, 151);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnGenerarSKU);
            this.panelControl1.Controls.Add(this.lblPrecio);
            this.panelControl1.Controls.Add(this.txtPrecio);
            this.panelControl1.Controls.Add(this.lblGruposArticulo);
            this.panelControl1.Controls.Add(this.cbGruposArticulos);
            this.panelControl1.Controls.Add(this.lblDescripcion);
            this.panelControl1.Controls.Add(this.txtDescripcion);
            this.panelControl1.Controls.Add(this.lblNombre);
            this.panelControl1.Controls.Add(this.txtNombre);
            this.panelControl1.Controls.Add(this.lblSKU);
            this.panelControl1.Controls.Add(this.txtSKU);
            this.panelControl1.Location = new System.Drawing.Point(12, 12);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(529, 147);
            this.panelControl1.TabIndex = 4;
            // 
            // btnGenerarSKU
            // 
            this.btnGenerarSKU.Location = new System.Drawing.Point(351, 9);
            this.btnGenerarSKU.Name = "btnGenerarSKU";
            this.btnGenerarSKU.Size = new System.Drawing.Size(75, 23);
            this.btnGenerarSKU.TabIndex = 0;
            this.btnGenerarSKU.TabStop = false;
            this.btnGenerarSKU.Text = "Generar SKU";
            this.btnGenerarSKU.Click += new System.EventHandler(this.btnGenerarSKU_Click);
            // 
            // lblPrecio
            // 
            this.lblPrecio.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblPrecio.Location = new System.Drawing.Point(15, 118);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(35, 13);
            this.lblPrecio.TabIndex = 97;
            this.lblPrecio.Text = "Precio";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(126, 115);
            this.txtPrecio.MenuManager = this.mainRibbonControl;
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPrecio.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPrecio.Properties.Mask.EditMask = "c2";
            this.txtPrecio.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPrecio.Size = new System.Drawing.Size(180, 20);
            this.txtPrecio.TabIndex = 4;
            // 
            // lblGruposArticulo
            // 
            this.lblGruposArticulo.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblGruposArticulo.Location = new System.Drawing.Point(15, 92);
            this.lblGruposArticulo.Name = "lblGruposArticulo";
            this.lblGruposArticulo.Size = new System.Drawing.Size(103, 13);
            this.lblGruposArticulo.TabIndex = 95;
            this.lblGruposArticulo.Text = "Grupo de artículos";
            // 
            // cbGruposArticulos
            // 
            this.cbGruposArticulos.Location = new System.Drawing.Point(126, 89);
            this.cbGruposArticulos.MenuManager = this.mainRibbonControl;
            this.cbGruposArticulos.Name = "cbGruposArticulos";
            this.cbGruposArticulos.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbGruposArticulos.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nombre", "Nombre")});
            this.cbGruposArticulos.Size = new System.Drawing.Size(219, 20);
            this.cbGruposArticulos.TabIndex = 3;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Location = new System.Drawing.Point(15, 66);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(54, 13);
            this.lblDescripcion.TabIndex = 70;
            this.lblDescripcion.Text = "Descripción";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(126, 63);
            this.txtDescripcion.MenuManager = this.mainRibbonControl;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtDescripcion.Properties.MaxLength = 100;
            this.txtDescripcion.Properties.NullValuePrompt = "Descripción del artículo";
            this.txtDescripcion.Size = new System.Drawing.Size(392, 20);
            this.txtDescripcion.TabIndex = 2;
            // 
            // lblNombre
            // 
            this.lblNombre.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblNombre.Location = new System.Drawing.Point(15, 40);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(44, 13);
            this.lblNombre.TabIndex = 68;
            this.lblNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(126, 37);
            this.txtNombre.MenuManager = this.mainRibbonControl;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtNombre.Properties.MaxLength = 100;
            this.txtNombre.Properties.NullValuePrompt = "Nombre del artículo";
            this.txtNombre.Size = new System.Drawing.Size(392, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // lblSKU
            // 
            this.lblSKU.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblSKU.Location = new System.Drawing.Point(15, 14);
            this.lblSKU.Name = "lblSKU";
            this.lblSKU.Size = new System.Drawing.Size(22, 13);
            this.lblSKU.TabIndex = 66;
            this.lblSKU.Text = "SKU";
            // 
            // txtSKU
            // 
            this.txtSKU.Location = new System.Drawing.Point(126, 11);
            this.txtSKU.MenuManager = this.mainRibbonControl;
            this.txtSKU.Name = "txtSKU";
            this.txtSKU.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtSKU.Properties.MaxLength = 15;
            this.txtSKU.Properties.NullValuePrompt = "SKU";
            this.txtSKU.Size = new System.Drawing.Size(219, 20);
            this.txtSKU.TabIndex = 0;
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.AllowCustomization = false;
            this.dataLayoutControl1.Controls.Add(this.panelControl1);
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 79);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(482, 356, 250, 350);
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(553, 171);
            this.dataLayoutControl1.TabIndex = 0;
            // 
            // frmAltaRapidaArticulo
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.True;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(553, 250);
            this.Controls.Add(this.dataLayoutControl1);
            this.Controls.Add(this.backstageViewControl1);
            this.Controls.Add(this.mainRibbonControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAltaRapidaArticulo";
            this.Ribbon = this.mainRibbonControl;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alta rápida de artículo";
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backstageViewControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbGruposArticulos.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSKU.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonControl mainRibbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage mainRibbonPage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mainRibbonPageGroup;
        private DevExpress.XtraBars.BarButtonItem bbiGuardarCerrar;
        private DevExpress.XtraBars.Ribbon.BackstageViewControl backstageViewControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl lblDescripcion;
        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private DevExpress.XtraEditors.LabelControl lblNombre;
        private DevExpress.XtraEditors.TextEdit txtNombre;
        private DevExpress.XtraEditors.LabelControl lblSKU;
        private DevExpress.XtraEditors.TextEdit txtSKU;
        private DevExpress.XtraEditors.LabelControl lblGruposArticulo;
        private DevExpress.XtraEditors.LookUpEdit cbGruposArticulos;
        private DevExpress.XtraEditors.LabelControl lblPrecio;
        private DevExpress.XtraEditors.TextEdit txtPrecio;
        private DevExpress.XtraEditors.SimpleButton btnGenerarSKU;
    }
}