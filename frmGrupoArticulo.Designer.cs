namespace Nori
{
    partial class frmGrupoArticulo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGrupoArticulo));
            this.mainRibbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiSave = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSaveAndClose = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSaveAndNew = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            this.bbiReset = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSearch = new DevExpress.XtraBars.BarButtonItem();
            this.bbiFirst = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPrev = new DevExpress.XtraBars.BarButtonItem();
            this.bbiLast = new DevExpress.XtraBars.BarButtonItem();
            this.bbiNext = new DevExpress.XtraBars.BarButtonItem();
            this.bbiNew = new DevExpress.XtraBars.BarButtonItem();
            this.mainRibbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mainRibbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.searchRibbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.lblID = new DevExpress.XtraEditors.LabelControl();
            this.lblNombre = new DevExpress.XtraEditors.LabelControl();
            this.txtNombre = new DevExpress.XtraEditors.TextEdit();
            this.lblCodigo = new DevExpress.XtraEditors.LabelControl();
            this.txtCodigo = new DevExpress.XtraEditors.TextEdit();
            this.cbActivo = new DevExpress.XtraEditors.CheckEdit();
            this.cbPredeterminado = new DevExpress.XtraEditors.CheckEdit();
            this.lblFechaActualizacion = new DevExpress.XtraEditors.LabelControl();
            this.lblUltimaActualizacion = new DevExpress.XtraEditors.LabelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbActivo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPredeterminado.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainRibbonControl
            // 
            this.mainRibbonControl.ExpandCollapseItem.Id = 0;
            this.mainRibbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.mainRibbonControl.ExpandCollapseItem,
            this.bbiSave,
            this.bbiSaveAndClose,
            this.bbiSaveAndNew,
            this.bbiDelete,
            this.bbiReset,
            this.bbiSearch,
            this.bbiFirst,
            this.bbiPrev,
            this.bbiLast,
            this.bbiNext,
            this.bbiNew});
            this.mainRibbonControl.Location = new System.Drawing.Point(0, 0);
            this.mainRibbonControl.MaxItemId = 2;
            this.mainRibbonControl.Name = "mainRibbonControl";
            this.mainRibbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.mainRibbonPage});
            this.mainRibbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.OfficeUniversal;
            this.mainRibbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.mainRibbonControl.Size = new System.Drawing.Size(556, 83);
            this.mainRibbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // bbiSave
            // 
            this.bbiSave.Caption = "Guardar";
            this.bbiSave.Id = 2;
            this.bbiSave.ImageUri.Uri = "Save";
            this.bbiSave.Name = "bbiSave";
            this.bbiSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSave_ItemClick);
            // 
            // bbiSaveAndClose
            // 
            this.bbiSaveAndClose.Caption = "Guardar y cerrar";
            this.bbiSaveAndClose.Id = 3;
            this.bbiSaveAndClose.ImageUri.Uri = "SaveAndClose";
            this.bbiSaveAndClose.Name = "bbiSaveAndClose";
            this.bbiSaveAndClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSaveAndClose_ItemClick);
            // 
            // bbiSaveAndNew
            // 
            this.bbiSaveAndNew.Caption = "Guardar y nuevo";
            this.bbiSaveAndNew.Id = 4;
            this.bbiSaveAndNew.ImageUri.Uri = "SaveAndNew";
            this.bbiSaveAndNew.Name = "bbiSaveAndNew";
            this.bbiSaveAndNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSaveAndNew_ItemClick);
            // 
            // bbiDelete
            // 
            this.bbiDelete.Caption = "Eliminar";
            this.bbiDelete.Id = 6;
            this.bbiDelete.ImageUri.Uri = "Delete";
            this.bbiDelete.Name = "bbiDelete";
            // 
            // bbiReset
            // 
            this.bbiReset.Id = 1;
            this.bbiReset.Name = "bbiReset";
            // 
            // bbiSearch
            // 
            this.bbiSearch.Caption = "Buscar";
            this.bbiSearch.Id = 4;
            this.bbiSearch.ImageUri.Uri = "Find";
            this.bbiSearch.Name = "bbiSearch";
            this.bbiSearch.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText;
            this.bbiSearch.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSearch_ItemClick);
            // 
            // bbiFirst
            // 
            this.bbiFirst.Caption = "Primero";
            this.bbiFirst.Id = 5;
            this.bbiFirst.ImageUri.Uri = "First";
            this.bbiFirst.Name = "bbiFirst";
            this.bbiFirst.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText;
            this.bbiFirst.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiFirst_ItemClick);
            // 
            // bbiPrev
            // 
            this.bbiPrev.Caption = "Anterior";
            this.bbiPrev.Id = 6;
            this.bbiPrev.ImageUri.Uri = "Prev";
            this.bbiPrev.Name = "bbiPrev";
            this.bbiPrev.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText;
            this.bbiPrev.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiPrev_ItemClick);
            // 
            // bbiLast
            // 
            this.bbiLast.Caption = "Último";
            this.bbiLast.Id = 7;
            this.bbiLast.ImageUri.Uri = "Last";
            this.bbiLast.Name = "bbiLast";
            this.bbiLast.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText;
            this.bbiLast.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiLast_ItemClick);
            // 
            // bbiNext
            // 
            this.bbiNext.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.bbiNext.Caption = "Siguiente";
            this.bbiNext.Id = 8;
            this.bbiNext.ImageUri.Uri = "Next";
            this.bbiNext.Name = "bbiNext";
            this.bbiNext.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText;
            this.bbiNext.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiNext_ItemClick);
            // 
            // bbiNew
            // 
            this.bbiNew.Caption = "Nuevo";
            this.bbiNew.Id = 1;
            this.bbiNew.ImageUri.Uri = "Add";
            this.bbiNew.Name = "bbiNew";
            this.bbiNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiNew_ItemClick);
            // 
            // mainRibbonPage
            // 
            this.mainRibbonPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.mainRibbonPageGroup,
            this.searchRibbonPageGroup});
            this.mainRibbonPage.MergeOrder = 0;
            this.mainRibbonPage.Name = "mainRibbonPage";
            this.mainRibbonPage.Text = "ARCHIVO";
            // 
            // mainRibbonPageGroup
            // 
            this.mainRibbonPageGroup.AllowTextClipping = false;
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiNew);
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiSave);
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiSaveAndClose);
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiSaveAndNew);
            this.mainRibbonPageGroup.Name = "mainRibbonPageGroup";
            this.mainRibbonPageGroup.ShowCaptionButton = false;
            this.mainRibbonPageGroup.Text = "Opciones";
            // 
            // searchRibbonPageGroup
            // 
            this.searchRibbonPageGroup.AllowTextClipping = false;
            this.searchRibbonPageGroup.ItemLinks.Add(this.bbiSearch);
            this.searchRibbonPageGroup.ItemLinks.Add(this.bbiFirst);
            this.searchRibbonPageGroup.ItemLinks.Add(this.bbiPrev);
            this.searchRibbonPageGroup.ItemLinks.Add(this.bbiNext);
            this.searchRibbonPageGroup.ItemLinks.Add(this.bbiLast);
            this.searchRibbonPageGroup.Name = "searchRibbonPageGroup";
            this.searchRibbonPageGroup.ShowCaptionButton = false;
            this.searchRibbonPageGroup.Text = "Navegación";
            // 
            // lblID
            // 
            this.lblID.Location = new System.Drawing.Point(342, 16);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(6, 13);
            this.lblID.TabIndex = 47;
            this.lblID.Text = "0";
            // 
            // lblNombre
            // 
            this.lblNombre.Location = new System.Drawing.Point(12, 42);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(37, 13);
            this.lblNombre.TabIndex = 46;
            this.lblNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(114, 39);
            this.txtNombre.MenuManager = this.mainRibbonControl;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(421, 20);
            this.txtNombre.TabIndex = 2;
            // 
            // lblCodigo
            // 
            this.lblCodigo.Location = new System.Drawing.Point(12, 16);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(33, 13);
            this.lblCodigo.TabIndex = 44;
            this.lblCodigo.Text = "Código";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(114, 13);
            this.txtCodigo.MenuManager = this.mainRibbonControl;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(219, 20);
            this.txtCodigo.TabIndex = 1;
            // 
            // cbActivo
            // 
            this.cbActivo.Location = new System.Drawing.Point(12, 107);
            this.cbActivo.MenuManager = this.mainRibbonControl;
            this.cbActivo.Name = "cbActivo";
            this.cbActivo.Properties.Caption = "Activo";
            this.cbActivo.Size = new System.Drawing.Size(120, 19);
            this.cbActivo.TabIndex = 4;
            // 
            // cbPredeterminado
            // 
            this.cbPredeterminado.Location = new System.Drawing.Point(114, 65);
            this.cbPredeterminado.MenuManager = this.mainRibbonControl;
            this.cbPredeterminado.Name = "cbPredeterminado";
            this.cbPredeterminado.Properties.Caption = "Predeterminado";
            this.cbPredeterminado.Size = new System.Drawing.Size(103, 19);
            this.cbPredeterminado.TabIndex = 3;
            // 
            // lblFechaActualizacion
            // 
            this.lblFechaActualizacion.Location = new System.Drawing.Point(479, 110);
            this.lblFechaActualizacion.Name = "lblFechaActualizacion";
            this.lblFechaActualizacion.Size = new System.Drawing.Size(56, 13);
            this.lblFechaActualizacion.TabIndex = 51;
            this.lblFechaActualizacion.Text = "01/01/0001";
            // 
            // lblUltimaActualizacion
            // 
            this.lblUltimaActualizacion.Location = new System.Drawing.Point(342, 110);
            this.lblUltimaActualizacion.Name = "lblUltimaActualizacion";
            this.lblUltimaActualizacion.Size = new System.Drawing.Size(94, 13);
            this.lblUltimaActualizacion.TabIndex = 50;
            this.lblUltimaActualizacion.Text = "Última Actualización";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblFechaActualizacion);
            this.panel1.Controls.Add(this.txtNombre);
            this.panel1.Controls.Add(this.lblUltimaActualizacion);
            this.panel1.Controls.Add(this.txtCodigo);
            this.panel1.Controls.Add(this.cbPredeterminado);
            this.panel1.Controls.Add(this.lblCodigo);
            this.panel1.Controls.Add(this.cbActivo);
            this.panel1.Controls.Add(this.lblNombre);
            this.panel1.Controls.Add(this.lblID);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 83);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(556, 142);
            this.panel1.TabIndex = 53;
            // 
            // frmGrupoArticulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 225);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mainRibbonControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmGrupoArticulo";
            this.Ribbon = this.mainRibbonControl;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grupo de artículos";
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbActivo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPredeterminado.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonControl mainRibbonControl;
        private DevExpress.XtraBars.BarButtonItem bbiSave;
        private DevExpress.XtraBars.BarButtonItem bbiSaveAndClose;
        private DevExpress.XtraBars.BarButtonItem bbiSaveAndNew;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraBars.BarButtonItem bbiReset;
        private DevExpress.XtraBars.BarButtonItem bbiSearch;
        private DevExpress.XtraBars.BarButtonItem bbiFirst;
        private DevExpress.XtraBars.BarButtonItem bbiPrev;
        private DevExpress.XtraBars.BarButtonItem bbiLast;
        private DevExpress.XtraBars.BarButtonItem bbiNext;
        private DevExpress.XtraBars.BarButtonItem bbiNew;
        private DevExpress.XtraBars.Ribbon.RibbonPage mainRibbonPage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mainRibbonPageGroup;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup searchRibbonPageGroup;
        private DevExpress.XtraEditors.LabelControl lblID;
        private DevExpress.XtraEditors.LabelControl lblNombre;
        private DevExpress.XtraEditors.TextEdit txtNombre;
        private DevExpress.XtraEditors.LabelControl lblCodigo;
        private DevExpress.XtraEditors.TextEdit txtCodigo;
        private DevExpress.XtraEditors.CheckEdit cbActivo;
        private DevExpress.XtraEditors.CheckEdit cbPredeterminado;
        private DevExpress.XtraEditors.LabelControl lblFechaActualizacion;
        private DevExpress.XtraEditors.LabelControl lblUltimaActualizacion;
        private System.Windows.Forms.Panel panel1;
    }
}