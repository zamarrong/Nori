namespace Nori
{
    partial class frmDireccion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDireccion));
            this.mainRibbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.backstageViewControl1 = new DevExpress.XtraBars.Ribbon.BackstageViewControl();
            this.bbiGuardarCerrar = new DevExpress.XtraBars.BarButtonItem();
            this.mainRibbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mainRibbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lblCP = new DevExpress.XtraEditors.LabelControl();
            this.txtCP = new DevExpress.XtraEditors.TextEdit();
            this.lblCiudad = new DevExpress.XtraEditors.LabelControl();
            this.txtCiudad = new DevExpress.XtraEditors.TextEdit();
            this.lblEstado = new DevExpress.XtraEditors.LabelControl();
            this.cbEstados = new DevExpress.XtraEditors.LookUpEdit();
            this.lblPais = new DevExpress.XtraEditors.LabelControl();
            this.cbPaises = new DevExpress.XtraEditors.LookUpEdit();
            this.lblMunicipio = new DevExpress.XtraEditors.LabelControl();
            this.txtMunicipio = new DevExpress.XtraEditors.TextEdit();
            this.lblColonia = new DevExpress.XtraEditors.LabelControl();
            this.txtColonia = new DevExpress.XtraEditors.TextEdit();
            this.lblNumeroInterior = new DevExpress.XtraEditors.LabelControl();
            this.txtNumeroInterior = new DevExpress.XtraEditors.TextEdit();
            this.lblNumeroExterior = new DevExpress.XtraEditors.LabelControl();
            this.txtNumeroExterior = new DevExpress.XtraEditors.TextEdit();
            this.lblCalle = new DevExpress.XtraEditors.LabelControl();
            this.txtCalle = new DevExpress.XtraEditors.TextEdit();
            this.lblNombre = new DevExpress.XtraEditors.LabelControl();
            this.txtNombre = new DevExpress.XtraEditors.TextEdit();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.lblEntreCalles = new DevExpress.XtraEditors.LabelControl();
            this.txtEntreCalles = new DevExpress.XtraEditors.TextEdit();
            this.lblReferencias = new DevExpress.XtraEditors.LabelControl();
            this.txtReferencias = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backstageViewControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCiudad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbEstados.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPaises.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMunicipio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtColonia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroInterior.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroExterior.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCalle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEntreCalles.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferencias.Properties)).BeginInit();
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
            this.mainRibbonControl.Size = new System.Drawing.Size(628, 79);
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
            this.layoutControlGroup1.Size = new System.Drawing.Size(628, 298);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.panelControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(608, 278);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lblReferencias);
            this.panelControl1.Controls.Add(this.txtReferencias);
            this.panelControl1.Controls.Add(this.lblEntreCalles);
            this.panelControl1.Controls.Add(this.txtEntreCalles);
            this.panelControl1.Controls.Add(this.lblCP);
            this.panelControl1.Controls.Add(this.txtCP);
            this.panelControl1.Controls.Add(this.lblCiudad);
            this.panelControl1.Controls.Add(this.txtCiudad);
            this.panelControl1.Controls.Add(this.lblEstado);
            this.panelControl1.Controls.Add(this.cbEstados);
            this.panelControl1.Controls.Add(this.lblPais);
            this.panelControl1.Controls.Add(this.cbPaises);
            this.panelControl1.Controls.Add(this.lblMunicipio);
            this.panelControl1.Controls.Add(this.txtMunicipio);
            this.panelControl1.Controls.Add(this.lblColonia);
            this.panelControl1.Controls.Add(this.txtColonia);
            this.panelControl1.Controls.Add(this.lblNumeroInterior);
            this.panelControl1.Controls.Add(this.txtNumeroInterior);
            this.panelControl1.Controls.Add(this.lblNumeroExterior);
            this.panelControl1.Controls.Add(this.txtNumeroExterior);
            this.panelControl1.Controls.Add(this.lblCalle);
            this.panelControl1.Controls.Add(this.txtCalle);
            this.panelControl1.Controls.Add(this.lblNombre);
            this.panelControl1.Controls.Add(this.txtNombre);
            this.panelControl1.Location = new System.Drawing.Point(12, 12);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(604, 274);
            this.panelControl1.TabIndex = 4;
            // 
            // lblCP
            // 
            this.lblCP.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblCP.Location = new System.Drawing.Point(15, 140);
            this.lblCP.Name = "lblCP";
            this.lblCP.Size = new System.Drawing.Size(20, 13);
            this.lblCP.TabIndex = 101;
            this.lblCP.Text = "C.P.";
            // 
            // txtCP
            // 
            this.txtCP.Location = new System.Drawing.Point(117, 137);
            this.txtCP.MenuManager = this.mainRibbonControl;
            this.txtCP.Name = "txtCP";
            this.txtCP.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtCP.Properties.Mask.EditMask = "00000";
            this.txtCP.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.txtCP.Properties.MaxLength = 5;
            this.txtCP.Size = new System.Drawing.Size(110, 20);
            this.txtCP.TabIndex = 7;
            // 
            // lblCiudad
            // 
            this.lblCiudad.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblCiudad.Location = new System.Drawing.Point(15, 114);
            this.lblCiudad.Name = "lblCiudad";
            this.lblCiudad.Size = new System.Drawing.Size(38, 13);
            this.lblCiudad.TabIndex = 99;
            this.lblCiudad.Text = "Ciudad";
            // 
            // txtCiudad
            // 
            this.txtCiudad.Location = new System.Drawing.Point(117, 111);
            this.txtCiudad.MenuManager = this.mainRibbonControl;
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtCiudad.Properties.MaxLength = 100;
            this.txtCiudad.Size = new System.Drawing.Size(473, 20);
            this.txtCiudad.TabIndex = 6;
            // 
            // lblEstado
            // 
            this.lblEstado.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblEstado.Location = new System.Drawing.Point(15, 244);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(38, 13);
            this.lblEstado.TabIndex = 97;
            this.lblEstado.Text = "Estado";
            // 
            // cbEstados
            // 
            this.cbEstados.Location = new System.Drawing.Point(117, 241);
            this.cbEstados.MenuManager = this.mainRibbonControl;
            this.cbEstados.Name = "cbEstados";
            this.cbEstados.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbEstados.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nombre", "Nombre")});
            this.cbEstados.Size = new System.Drawing.Size(219, 20);
            this.cbEstados.TabIndex = 11;
            // 
            // lblPais
            // 
            this.lblPais.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblPais.Location = new System.Drawing.Point(15, 218);
            this.lblPais.Name = "lblPais";
            this.lblPais.Size = new System.Drawing.Size(23, 13);
            this.lblPais.TabIndex = 95;
            this.lblPais.Text = "País";
            // 
            // cbPaises
            // 
            this.cbPaises.Location = new System.Drawing.Point(117, 215);
            this.cbPaises.MenuManager = this.mainRibbonControl;
            this.cbPaises.Name = "cbPaises";
            this.cbPaises.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbPaises.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nombre", "Nombre")});
            this.cbPaises.Size = new System.Drawing.Size(219, 20);
            this.cbPaises.TabIndex = 10;
            this.cbPaises.EditValueChanged += new System.EventHandler(this.cbPaises_EditValueChanged);
            // 
            // lblMunicipio
            // 
            this.lblMunicipio.Location = new System.Drawing.Point(15, 192);
            this.lblMunicipio.Name = "lblMunicipio";
            this.lblMunicipio.Size = new System.Drawing.Size(43, 13);
            this.lblMunicipio.TabIndex = 92;
            this.lblMunicipio.Text = "Municipio";
            // 
            // txtMunicipio
            // 
            this.txtMunicipio.Location = new System.Drawing.Point(117, 189);
            this.txtMunicipio.MenuManager = this.mainRibbonControl;
            this.txtMunicipio.Name = "txtMunicipio";
            this.txtMunicipio.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtMunicipio.Properties.MaxLength = 100;
            this.txtMunicipio.Size = new System.Drawing.Size(473, 20);
            this.txtMunicipio.TabIndex = 9;
            // 
            // lblColonia
            // 
            this.lblColonia.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblColonia.Location = new System.Drawing.Point(15, 166);
            this.lblColonia.Name = "lblColonia";
            this.lblColonia.Size = new System.Drawing.Size(41, 13);
            this.lblColonia.TabIndex = 90;
            this.lblColonia.Text = "Colonia";
            // 
            // txtColonia
            // 
            this.txtColonia.Location = new System.Drawing.Point(117, 163);
            this.txtColonia.MenuManager = this.mainRibbonControl;
            this.txtColonia.Name = "txtColonia";
            this.txtColonia.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtColonia.Properties.MaxLength = 100;
            this.txtColonia.Size = new System.Drawing.Size(473, 20);
            this.txtColonia.TabIndex = 8;
            // 
            // lblNumeroInterior
            // 
            this.lblNumeroInterior.Location = new System.Drawing.Point(15, 88);
            this.lblNumeroInterior.Name = "lblNumeroInterior";
            this.lblNumeroInterior.Size = new System.Drawing.Size(56, 13);
            this.lblNumeroInterior.TabIndex = 88;
            this.lblNumeroInterior.Text = "No. Interior";
            // 
            // txtNumeroInterior
            // 
            this.txtNumeroInterior.Location = new System.Drawing.Point(117, 85);
            this.txtNumeroInterior.MenuManager = this.mainRibbonControl;
            this.txtNumeroInterior.Name = "txtNumeroInterior";
            this.txtNumeroInterior.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtNumeroInterior.Properties.MaxLength = 100;
            this.txtNumeroInterior.Size = new System.Drawing.Size(110, 20);
            this.txtNumeroInterior.TabIndex = 4;
            // 
            // lblNumeroExterior
            // 
            this.lblNumeroExterior.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblNumeroExterior.Location = new System.Drawing.Point(15, 62);
            this.lblNumeroExterior.Name = "lblNumeroExterior";
            this.lblNumeroExterior.Size = new System.Drawing.Size(65, 13);
            this.lblNumeroExterior.TabIndex = 86;
            this.lblNumeroExterior.Text = "No. Exterior";
            // 
            // txtNumeroExterior
            // 
            this.txtNumeroExterior.Location = new System.Drawing.Point(117, 59);
            this.txtNumeroExterior.MenuManager = this.mainRibbonControl;
            this.txtNumeroExterior.Name = "txtNumeroExterior";
            this.txtNumeroExterior.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtNumeroExterior.Properties.MaxLength = 100;
            this.txtNumeroExterior.Size = new System.Drawing.Size(110, 20);
            this.txtNumeroExterior.TabIndex = 2;
            // 
            // lblCalle
            // 
            this.lblCalle.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblCalle.Location = new System.Drawing.Point(15, 36);
            this.lblCalle.Name = "lblCalle";
            this.lblCalle.Size = new System.Drawing.Size(27, 13);
            this.lblCalle.TabIndex = 84;
            this.lblCalle.Text = "Calle";
            // 
            // txtCalle
            // 
            this.txtCalle.Location = new System.Drawing.Point(117, 33);
            this.txtCalle.MenuManager = this.mainRibbonControl;
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtCalle.Properties.MaxLength = 100;
            this.txtCalle.Size = new System.Drawing.Size(473, 20);
            this.txtCalle.TabIndex = 1;
            // 
            // lblNombre
            // 
            this.lblNombre.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblNombre.Location = new System.Drawing.Point(15, 10);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(44, 13);
            this.lblNombre.TabIndex = 68;
            this.lblNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(117, 7);
            this.txtNombre.MenuManager = this.mainRibbonControl;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtNombre.Properties.MaxLength = 100;
            this.txtNombre.Properties.NullValuePrompt = "Nombre de la dirección Ej. Trabajo";
            this.txtNombre.Size = new System.Drawing.Size(473, 20);
            this.txtNombre.TabIndex = 0;
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
            this.dataLayoutControl1.Size = new System.Drawing.Size(628, 298);
            this.dataLayoutControl1.TabIndex = 0;
            // 
            // lblEntreCalles
            // 
            this.lblEntreCalles.Location = new System.Drawing.Point(233, 62);
            this.lblEntreCalles.Name = "lblEntreCalles";
            this.lblEntreCalles.Size = new System.Drawing.Size(55, 13);
            this.lblEntreCalles.TabIndex = 103;
            this.lblEntreCalles.Text = "Entre calles";
            // 
            // txtEntreCalles
            // 
            this.txtEntreCalles.Location = new System.Drawing.Point(335, 59);
            this.txtEntreCalles.MenuManager = this.mainRibbonControl;
            this.txtEntreCalles.Name = "txtEntreCalles";
            this.txtEntreCalles.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtEntreCalles.Properties.MaxLength = 100;
            this.txtEntreCalles.Size = new System.Drawing.Size(255, 20);
            this.txtEntreCalles.TabIndex = 3;
            // 
            // lblReferencias
            // 
            this.lblReferencias.Location = new System.Drawing.Point(233, 88);
            this.lblReferencias.Name = "lblReferencias";
            this.lblReferencias.Size = new System.Drawing.Size(57, 13);
            this.lblReferencias.TabIndex = 105;
            this.lblReferencias.Text = "Referencias";
            // 
            // txtReferencias
            // 
            this.txtReferencias.Location = new System.Drawing.Point(335, 85);
            this.txtReferencias.MenuManager = this.mainRibbonControl;
            this.txtReferencias.Name = "txtReferencias";
            this.txtReferencias.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtReferencias.Properties.MaxLength = 100;
            this.txtReferencias.Size = new System.Drawing.Size(255, 20);
            this.txtReferencias.TabIndex = 5;
            // 
            // frmDireccion
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.True;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(628, 377);
            this.Controls.Add(this.dataLayoutControl1);
            this.Controls.Add(this.backstageViewControl1);
            this.Controls.Add(this.mainRibbonControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDireccion";
            this.Ribbon = this.mainRibbonControl;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dirección";
            this.Load += new System.EventHandler(this.frmDireccion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backstageViewControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCiudad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbEstados.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPaises.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMunicipio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtColonia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroInterior.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroExterior.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCalle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtEntreCalles.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferencias.Properties)).EndInit();
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
        private DevExpress.XtraEditors.LabelControl lblNombre;
        private DevExpress.XtraEditors.TextEdit txtNombre;
        private DevExpress.XtraEditors.LabelControl lblCalle;
        private DevExpress.XtraEditors.TextEdit txtCalle;
        private DevExpress.XtraEditors.LabelControl lblNumeroInterior;
        private DevExpress.XtraEditors.TextEdit txtNumeroInterior;
        private DevExpress.XtraEditors.LabelControl lblNumeroExterior;
        private DevExpress.XtraEditors.TextEdit txtNumeroExterior;
        private DevExpress.XtraEditors.LabelControl lblColonia;
        private DevExpress.XtraEditors.TextEdit txtColonia;
        private DevExpress.XtraEditors.LabelControl lblMunicipio;
        private DevExpress.XtraEditors.TextEdit txtMunicipio;
        private DevExpress.XtraEditors.LabelControl lblPais;
        private DevExpress.XtraEditors.LookUpEdit cbPaises;
        private DevExpress.XtraEditors.LabelControl lblEstado;
        private DevExpress.XtraEditors.LookUpEdit cbEstados;
        private DevExpress.XtraEditors.LabelControl lblCiudad;
        private DevExpress.XtraEditors.TextEdit txtCiudad;
        private DevExpress.XtraEditors.TextEdit txtCP;
        private DevExpress.XtraEditors.LabelControl lblCP;
        private DevExpress.XtraEditors.LabelControl lblReferencias;
        private DevExpress.XtraEditors.TextEdit txtReferencias;
        private DevExpress.XtraEditors.LabelControl lblEntreCalles;
        private DevExpress.XtraEditors.TextEdit txtEntreCalles;
    }
}