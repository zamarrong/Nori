namespace Nori
{
    partial class frmAltaRapidaSocioEventual
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAltaRapidaSocioEventual));
            this.mainRibbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.backstageViewControl1 = new DevExpress.XtraBars.Ribbon.BackstageViewControl();
            this.bbiGuardarCerrar = new DevExpress.XtraBars.BarButtonItem();
            this.mainRibbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mainRibbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.cbUsoPrincipal = new DevExpress.XtraEditors.LookUpEdit();
            this.lblUsoPrincipal = new DevExpress.XtraEditors.LabelControl();
            this.lblCP = new DevExpress.XtraEditors.LabelControl();
            this.txtCP = new DevExpress.XtraEditors.TextEdit();
            this.lblCorreo = new DevExpress.XtraEditors.LabelControl();
            this.txtCorreo = new DevExpress.XtraEditors.TextEdit();
            this.lblRFC = new DevExpress.XtraEditors.LabelControl();
            this.txtRFC = new DevExpress.XtraEditors.TextEdit();
            this.lblNombre = new DevExpress.XtraEditors.LabelControl();
            this.txtNombre = new DevExpress.XtraEditors.TextEdit();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backstageViewControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbUsoPrincipal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCorreo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRFC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre.Properties)).BeginInit();
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
            this.mainRibbonControl.Size = new System.Drawing.Size(525, 79);
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
            this.layoutControlGroup1.Size = new System.Drawing.Size(525, 146);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.panelControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(505, 126);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.cbUsoPrincipal);
            this.panelControl1.Controls.Add(this.lblUsoPrincipal);
            this.panelControl1.Controls.Add(this.lblCP);
            this.panelControl1.Controls.Add(this.txtCP);
            this.panelControl1.Controls.Add(this.lblCorreo);
            this.panelControl1.Controls.Add(this.txtCorreo);
            this.panelControl1.Controls.Add(this.lblRFC);
            this.panelControl1.Controls.Add(this.txtRFC);
            this.panelControl1.Controls.Add(this.lblNombre);
            this.panelControl1.Controls.Add(this.txtNombre);
            this.panelControl1.Location = new System.Drawing.Point(12, 12);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(501, 122);
            this.panelControl1.TabIndex = 4;
            // 
            // cbUsoPrincipal
            // 
            this.cbUsoPrincipal.Location = new System.Drawing.Point(305, 59);
            this.cbUsoPrincipal.MenuManager = this.mainRibbonControl;
            this.cbUsoPrincipal.Name = "cbUsoPrincipal";
            this.cbUsoPrincipal.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbUsoPrincipal.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("uso", "Uso"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nombre", "Nombre")});
            this.cbUsoPrincipal.Size = new System.Drawing.Size(180, 20);
            this.cbUsoPrincipal.TabIndex = 104;
            this.cbUsoPrincipal.TabStop = false;
            // 
            // lblUsoPrincipal
            // 
            this.lblUsoPrincipal.Location = new System.Drawing.Point(240, 62);
            this.lblUsoPrincipal.Name = "lblUsoPrincipal";
            this.lblUsoPrincipal.Size = new System.Drawing.Size(60, 13);
            this.lblUsoPrincipal.TabIndex = 103;
            this.lblUsoPrincipal.Text = "Uso principal";
            // 
            // lblCP
            // 
            this.lblCP.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblCP.Location = new System.Drawing.Point(11, 62);
            this.lblCP.Name = "lblCP";
            this.lblCP.Size = new System.Drawing.Size(20, 13);
            this.lblCP.TabIndex = 101;
            this.lblCP.Text = "C.P.";
            // 
            // txtCP
            // 
            this.txtCP.Location = new System.Drawing.Point(113, 59);
            this.txtCP.MenuManager = this.mainRibbonControl;
            this.txtCP.Name = "txtCP";
            this.txtCP.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtCP.Properties.Mask.EditMask = "00000";
            this.txtCP.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.txtCP.Properties.MaxLength = 5;
            this.txtCP.Size = new System.Drawing.Size(110, 20);
            this.txtCP.TabIndex = 9;
            // 
            // lblCorreo
            // 
            this.lblCorreo.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblCorreo.Location = new System.Drawing.Point(11, 88);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(38, 13);
            this.lblCorreo.TabIndex = 80;
            this.lblCorreo.Text = "Correo";
            // 
            // txtCorreo
            // 
            this.txtCorreo.Location = new System.Drawing.Point(113, 85);
            this.txtCorreo.MenuManager = this.mainRibbonControl;
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtCorreo.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtCorreo.Properties.MaxLength = 100;
            this.txtCorreo.Properties.NullValuePrompt = "Dirección de correo electrónico";
            this.txtCorreo.Size = new System.Drawing.Size(219, 20);
            this.txtCorreo.TabIndex = 17;
            // 
            // lblRFC
            // 
            this.lblRFC.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblRFC.Location = new System.Drawing.Point(11, 10);
            this.lblRFC.Name = "lblRFC";
            this.lblRFC.Size = new System.Drawing.Size(21, 13);
            this.lblRFC.TabIndex = 77;
            this.lblRFC.Text = "RFC";
            // 
            // txtRFC
            // 
            this.txtRFC.Location = new System.Drawing.Point(113, 7);
            this.txtRFC.MenuManager = this.mainRibbonControl;
            this.txtRFC.Name = "txtRFC";
            this.txtRFC.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtRFC.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRFC.Properties.MaxLength = 30;
            this.txtRFC.Properties.NullValuePrompt = "RFC";
            this.txtRFC.Size = new System.Drawing.Size(219, 20);
            this.txtRFC.TabIndex = 1;
            // 
            // lblNombre
            // 
            this.lblNombre.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblNombre.Location = new System.Drawing.Point(11, 36);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(44, 13);
            this.lblNombre.TabIndex = 68;
            this.lblNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(113, 33);
            this.txtNombre.MenuManager = this.mainRibbonControl;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtNombre.Properties.MaxLength = 100;
            this.txtNombre.Properties.NullValuePrompt = "Nombre del socio";
            this.txtNombre.Size = new System.Drawing.Size(372, 20);
            this.txtNombre.TabIndex = 3;
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
            this.dataLayoutControl1.Size = new System.Drawing.Size(525, 146);
            this.dataLayoutControl1.TabIndex = 0;
            // 
            // frmAltaRapidaSocioEventual
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.True;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(525, 225);
            this.Controls.Add(this.dataLayoutControl1);
            this.Controls.Add(this.backstageViewControl1);
            this.Controls.Add(this.mainRibbonControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAltaRapidaSocioEventual";
            this.Ribbon = this.mainRibbonControl;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alta rápida de socio eventual";
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backstageViewControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbUsoPrincipal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCorreo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRFC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre.Properties)).EndInit();
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
        private DevExpress.XtraEditors.LabelControl lblCorreo;
        private DevExpress.XtraEditors.TextEdit txtCorreo;
        private DevExpress.XtraEditors.LabelControl lblRFC;
        private DevExpress.XtraEditors.TextEdit txtRFC;
        private DevExpress.XtraEditors.LabelControl lblNombre;
        private DevExpress.XtraEditors.TextEdit txtNombre;
        private DevExpress.XtraEditors.LabelControl lblCP;
        private DevExpress.XtraEditors.TextEdit txtCP;
        private DevExpress.XtraEditors.LookUpEdit cbUsoPrincipal;
        private DevExpress.XtraEditors.LabelControl lblUsoPrincipal;
    }
}