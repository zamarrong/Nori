namespace Nori
{
    partial class frmEstaciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEstaciones));
            this.mainRibbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiGuardar = new DevExpress.XtraBars.BarButtonItem();
            this.bbiGuardarCerrar = new DevExpress.XtraBars.BarButtonItem();
            this.bbiGuardarNuevo = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEliminar = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRestablecer = new DevExpress.XtraBars.BarButtonItem();
            this.bbiBuscar = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPrimero = new DevExpress.XtraBars.BarButtonItem();
            this.bbiAnterior = new DevExpress.XtraBars.BarButtonItem();
            this.bbiUltimo = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSiguiente = new DevExpress.XtraBars.BarButtonItem();
            this.bbiNuevo = new DevExpress.XtraBars.BarButtonItem();
            this.mainRibbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mainRibbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.searchRibbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.lblID = new DevExpress.XtraEditors.LabelControl();
            this.lblNombre = new DevExpress.XtraEditors.LabelControl();
            this.txtNombre = new DevExpress.XtraEditors.TextEdit();
            this.lblCodigo = new DevExpress.XtraEditors.LabelControl();
            this.txtCodigo = new DevExpress.XtraEditors.TextEdit();
            this.cbActivo = new DevExpress.XtraEditors.CheckEdit();
            this.cbLectorHuella = new DevExpress.XtraEditors.CheckEdit();
            this.lblFechaActualizacion = new DevExpress.XtraEditors.LabelControl();
            this.lblUltimaActualizacion = new DevExpress.XtraEditors.LabelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblBasculas = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.cbBasculas = new DevExpress.XtraEditors.LookUpEdit();
            this.cbBascula = new DevExpress.XtraEditors.CheckEdit();
            this.cbImpresoraDocumentos = new DevExpress.XtraEditors.LookUpEdit();
            this.cbImpresoraTickets = new DevExpress.XtraEditors.LookUpEdit();
            this.lblImpresoraDocumentos = new DevExpress.XtraEditors.LabelControl();
            this.lblImpresoraTickets = new DevExpress.XtraEditors.LabelControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.cbImpresion = new DevExpress.XtraEditors.CheckEdit();
            this.cbEnvioCorreoAutomatico = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbActivo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbLectorHuella.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbBasculas.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBascula.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbImpresoraDocumentos.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbImpresoraTickets.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbImpresion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbEnvioCorreoAutomatico.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // mainRibbonControl
            // 
            this.mainRibbonControl.ExpandCollapseItem.Id = 0;
            this.mainRibbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.mainRibbonControl.ExpandCollapseItem,
            this.bbiGuardar,
            this.bbiGuardarCerrar,
            this.bbiGuardarNuevo,
            this.bbiEliminar,
            this.bbiRestablecer,
            this.bbiBuscar,
            this.bbiPrimero,
            this.bbiAnterior,
            this.bbiUltimo,
            this.bbiSiguiente,
            this.bbiNuevo,
            this.mainRibbonControl.SearchEditItem});
            this.mainRibbonControl.Location = new System.Drawing.Point(0, 0);
            this.mainRibbonControl.MaxItemId = 2;
            this.mainRibbonControl.Name = "mainRibbonControl";
            this.mainRibbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.mainRibbonPage});
            this.mainRibbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.OfficeUniversal;
            this.mainRibbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.mainRibbonControl.Size = new System.Drawing.Size(573, 92);
            this.mainRibbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // bbiGuardar
            // 
            this.bbiGuardar.Caption = "Guardar";
            this.bbiGuardar.Id = 2;
            this.bbiGuardar.ImageOptions.ImageUri.Uri = "Save";
            this.bbiGuardar.Name = "bbiGuardar";
            this.bbiGuardar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiGuardar_ItemClick);
            // 
            // bbiGuardarCerrar
            // 
            this.bbiGuardarCerrar.Caption = "Guardar y cerrar";
            this.bbiGuardarCerrar.Id = 3;
            this.bbiGuardarCerrar.ImageOptions.ImageUri.Uri = "SaveAndClose";
            this.bbiGuardarCerrar.Name = "bbiGuardarCerrar";
            this.bbiGuardarCerrar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiGuardarCerrar_ItemClick);
            // 
            // bbiGuardarNuevo
            // 
            this.bbiGuardarNuevo.Caption = "Guardar y nuevo";
            this.bbiGuardarNuevo.Id = 4;
            this.bbiGuardarNuevo.ImageOptions.ImageUri.Uri = "SaveAndNew";
            this.bbiGuardarNuevo.Name = "bbiGuardarNuevo";
            this.bbiGuardarNuevo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiGuardarNuevo_ItemClick);
            // 
            // bbiEliminar
            // 
            this.bbiEliminar.Caption = "Eliminar";
            this.bbiEliminar.Id = 6;
            this.bbiEliminar.ImageOptions.ImageUri.Uri = "Delete";
            this.bbiEliminar.Name = "bbiEliminar";
            // 
            // bbiRestablecer
            // 
            this.bbiRestablecer.Id = 1;
            this.bbiRestablecer.Name = "bbiRestablecer";
            // 
            // bbiBuscar
            // 
            this.bbiBuscar.Caption = "Buscar";
            this.bbiBuscar.Id = 4;
            this.bbiBuscar.ImageOptions.ImageUri.Uri = "Find";
            this.bbiBuscar.Name = "bbiBuscar";
            this.bbiBuscar.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText;
            this.bbiBuscar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiBuscar_ItemClick);
            // 
            // bbiPrimero
            // 
            this.bbiPrimero.Caption = "Primero";
            this.bbiPrimero.Id = 5;
            this.bbiPrimero.ImageOptions.ImageUri.Uri = "First";
            this.bbiPrimero.Name = "bbiPrimero";
            this.bbiPrimero.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText;
            this.bbiPrimero.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiPrimero_ItemClick);
            // 
            // bbiAnterior
            // 
            this.bbiAnterior.Caption = "Anterior";
            this.bbiAnterior.Id = 6;
            this.bbiAnterior.ImageOptions.ImageUri.Uri = "Prev";
            this.bbiAnterior.Name = "bbiAnterior";
            this.bbiAnterior.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText;
            this.bbiAnterior.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiAnterior_ItemClick);
            // 
            // bbiUltimo
            // 
            this.bbiUltimo.Caption = "Último";
            this.bbiUltimo.Id = 7;
            this.bbiUltimo.ImageOptions.ImageUri.Uri = "Last";
            this.bbiUltimo.Name = "bbiUltimo";
            this.bbiUltimo.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText;
            this.bbiUltimo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiUltimo_ItemClick);
            // 
            // bbiSiguiente
            // 
            this.bbiSiguiente.Caption = "Siguiente";
            this.bbiSiguiente.Id = 8;
            this.bbiSiguiente.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.bbiSiguiente.ImageOptions.ImageUri.Uri = "Next";
            this.bbiSiguiente.Name = "bbiSiguiente";
            this.bbiSiguiente.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText;
            this.bbiSiguiente.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSiguiente_ItemClick);
            // 
            // bbiNuevo
            // 
            this.bbiNuevo.Caption = "Nuevo";
            this.bbiNuevo.Id = 1;
            this.bbiNuevo.ImageOptions.ImageUri.Uri = "Add";
            this.bbiNuevo.Name = "bbiNuevo";
            this.bbiNuevo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiNuevo_ItemClick);
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
            this.mainRibbonPageGroup.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiNuevo);
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiGuardar);
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiGuardarCerrar);
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiGuardarNuevo);
            this.mainRibbonPageGroup.Name = "mainRibbonPageGroup";
            this.mainRibbonPageGroup.Text = "Opciones";
            // 
            // searchRibbonPageGroup
            // 
            this.searchRibbonPageGroup.AllowTextClipping = false;
            this.searchRibbonPageGroup.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.searchRibbonPageGroup.ItemLinks.Add(this.bbiBuscar);
            this.searchRibbonPageGroup.ItemLinks.Add(this.bbiPrimero);
            this.searchRibbonPageGroup.ItemLinks.Add(this.bbiAnterior);
            this.searchRibbonPageGroup.ItemLinks.Add(this.bbiSiguiente);
            this.searchRibbonPageGroup.ItemLinks.Add(this.bbiUltimo);
            this.searchRibbonPageGroup.Name = "searchRibbonPageGroup";
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
            this.txtNombre.Properties.MaxLength = 254;
            this.txtNombre.Size = new System.Drawing.Size(421, 20);
            this.txtNombre.TabIndex = 1;
            this.txtNombre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigo_KeyDown);
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
            this.txtCodigo.Properties.MaxLength = 100;
            this.txtCodigo.Size = new System.Drawing.Size(219, 20);
            this.txtCodigo.TabIndex = 0;
            this.txtCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigo_KeyDown);
            // 
            // cbActivo
            // 
            this.cbActivo.Location = new System.Drawing.Point(12, 148);
            this.cbActivo.MenuManager = this.mainRibbonControl;
            this.cbActivo.Name = "cbActivo";
            this.cbActivo.Properties.Caption = "Activo";
            this.cbActivo.Size = new System.Drawing.Size(120, 18);
            this.cbActivo.TabIndex = 5;
            // 
            // cbLectorHuella
            // 
            this.cbLectorHuella.Location = new System.Drawing.Point(114, 117);
            this.cbLectorHuella.MenuManager = this.mainRibbonControl;
            this.cbLectorHuella.Name = "cbLectorHuella";
            this.cbLectorHuella.Properties.Caption = "Usar lector de huella";
            this.cbLectorHuella.Size = new System.Drawing.Size(131, 18);
            this.cbLectorHuella.TabIndex = 4;
            // 
            // lblFechaActualizacion
            // 
            this.lblFechaActualizacion.Location = new System.Drawing.Point(479, 151);
            this.lblFechaActualizacion.Name = "lblFechaActualizacion";
            this.lblFechaActualizacion.Size = new System.Drawing.Size(56, 13);
            this.lblFechaActualizacion.TabIndex = 51;
            this.lblFechaActualizacion.Text = "01/01/0001";
            // 
            // lblUltimaActualizacion
            // 
            this.lblUltimaActualizacion.Location = new System.Drawing.Point(342, 151);
            this.lblUltimaActualizacion.Name = "lblUltimaActualizacion";
            this.lblUltimaActualizacion.Size = new System.Drawing.Size(94, 13);
            this.lblUltimaActualizacion.TabIndex = 50;
            this.lblUltimaActualizacion.Text = "Última Actualización";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbEnvioCorreoAutomatico);
            this.panel1.Controls.Add(this.cbImpresion);
            this.panel1.Controls.Add(this.lblBasculas);
            this.panel1.Controls.Add(this.cbBasculas);
            this.panel1.Controls.Add(this.cbBascula);
            this.panel1.Controls.Add(this.cbImpresoraDocumentos);
            this.panel1.Controls.Add(this.cbImpresoraTickets);
            this.panel1.Controls.Add(this.lblImpresoraDocumentos);
            this.panel1.Controls.Add(this.lblImpresoraTickets);
            this.panel1.Controls.Add(this.lblFechaActualizacion);
            this.panel1.Controls.Add(this.txtNombre);
            this.panel1.Controls.Add(this.lblUltimaActualizacion);
            this.panel1.Controls.Add(this.txtCodigo);
            this.panel1.Controls.Add(this.cbLectorHuella);
            this.panel1.Controls.Add(this.lblCodigo);
            this.panel1.Controls.Add(this.cbActivo);
            this.panel1.Controls.Add(this.lblNombre);
            this.panel1.Controls.Add(this.lblID);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(7, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(557, 174);
            this.panel1.TabIndex = 53;
            // 
            // lblBasculas
            // 
            this.lblBasculas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblBasculas.Location = new System.Drawing.Point(494, 67);
            this.lblBasculas.Name = "lblBasculas";
            this.lblBasculas.Size = new System.Drawing.Size(41, 13);
            this.lblBasculas.TabIndex = 58;
            this.lblBasculas.Text = "Básculas";
            this.lblBasculas.Click += new System.EventHandler(this.lblBasculas_Click);
            // 
            // cbBasculas
            // 
            this.cbBasculas.Location = new System.Drawing.Point(342, 91);
            this.cbBasculas.MenuManager = this.mainRibbonControl;
            this.cbBasculas.Name = "cbBasculas";
            this.cbBasculas.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbBasculas.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("puerto", "Puerto"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nombre", "Nombre")});
            this.cbBasculas.Size = new System.Drawing.Size(193, 20);
            this.cbBasculas.TabIndex = 57;
            // 
            // cbBascula
            // 
            this.cbBascula.Location = new System.Drawing.Point(342, 66);
            this.cbBascula.MenuManager = this.mainRibbonControl;
            this.cbBascula.Name = "cbBascula";
            this.cbBascula.Properties.Caption = "Usar báscula";
            this.cbBascula.Size = new System.Drawing.Size(131, 18);
            this.cbBascula.TabIndex = 56;
            // 
            // cbImpresoraDocumentos
            // 
            this.cbImpresoraDocumentos.Location = new System.Drawing.Point(114, 91);
            this.cbImpresoraDocumentos.MenuManager = this.mainRibbonControl;
            this.cbImpresoraDocumentos.Name = "cbImpresoraDocumentos";
            this.cbImpresoraDocumentos.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbImpresoraDocumentos.Size = new System.Drawing.Size(219, 20);
            this.cbImpresoraDocumentos.TabIndex = 3;
            // 
            // cbImpresoraTickets
            // 
            this.cbImpresoraTickets.Location = new System.Drawing.Point(114, 65);
            this.cbImpresoraTickets.MenuManager = this.mainRibbonControl;
            this.cbImpresoraTickets.Name = "cbImpresoraTickets";
            this.cbImpresoraTickets.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbImpresoraTickets.Size = new System.Drawing.Size(219, 20);
            this.cbImpresoraTickets.TabIndex = 2;
            // 
            // lblImpresoraDocumentos
            // 
            this.lblImpresoraDocumentos.Location = new System.Drawing.Point(12, 94);
            this.lblImpresoraDocumentos.Name = "lblImpresoraDocumentos";
            this.lblImpresoraDocumentos.Size = new System.Drawing.Size(99, 13);
            this.lblImpresoraDocumentos.TabIndex = 55;
            this.lblImpresoraDocumentos.Text = "Impresora de doctos";
            // 
            // lblImpresoraTickets
            // 
            this.lblImpresoraTickets.Location = new System.Drawing.Point(12, 68);
            this.lblImpresoraTickets.Name = "lblImpresoraTickets";
            this.lblImpresoraTickets.Size = new System.Drawing.Size(98, 13);
            this.lblImpresoraTickets.TabIndex = 54;
            this.lblImpresoraTickets.Text = "Impresora de tickets";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.panel1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 92);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(92, 301, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(573, 181);
            this.layoutControl1.TabIndex = 57;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(573, 181);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // cbImpresion
            // 
            this.cbImpresion.Location = new System.Drawing.Point(251, 117);
            this.cbImpresion.MenuManager = this.mainRibbonControl;
            this.cbImpresion.Name = "cbImpresion";
            this.cbImpresion.Properties.Caption = "Usar impresión";
            this.cbImpresion.Size = new System.Drawing.Size(106, 18);
            this.cbImpresion.TabIndex = 59;
            // 
            // cbEnvioCorreoAutomatico
            // 
            this.cbEnvioCorreoAutomatico.Location = new System.Drawing.Point(363, 117);
            this.cbEnvioCorreoAutomatico.MenuManager = this.mainRibbonControl;
            this.cbEnvioCorreoAutomatico.Name = "cbEnvioCorreoAutomatico";
            this.cbEnvioCorreoAutomatico.Properties.Caption = "Envío automático correo";
            this.cbEnvioCorreoAutomatico.Size = new System.Drawing.Size(172, 18);
            this.cbEnvioCorreoAutomatico.TabIndex = 60;
            // 
            // frmEstaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 273);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.mainRibbonControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frmEstaciones.IconOptions.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmEstaciones";
            this.Ribbon = this.mainRibbonControl;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Estaciones de trabajo";
            this.Load += new System.EventHandler(this.frmEstaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbActivo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbLectorHuella.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbBasculas.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBascula.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbImpresoraDocumentos.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbImpresoraTickets.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbImpresion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbEnvioCorreoAutomatico.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonControl mainRibbonControl;
        private DevExpress.XtraBars.BarButtonItem bbiGuardar;
        private DevExpress.XtraBars.BarButtonItem bbiGuardarCerrar;
        private DevExpress.XtraBars.BarButtonItem bbiGuardarNuevo;
        private DevExpress.XtraBars.BarButtonItem bbiEliminar;
        private DevExpress.XtraBars.BarButtonItem bbiRestablecer;
        private DevExpress.XtraBars.BarButtonItem bbiBuscar;
        private DevExpress.XtraBars.BarButtonItem bbiPrimero;
        private DevExpress.XtraBars.BarButtonItem bbiAnterior;
        private DevExpress.XtraBars.BarButtonItem bbiUltimo;
        private DevExpress.XtraBars.BarButtonItem bbiSiguiente;
        private DevExpress.XtraBars.BarButtonItem bbiNuevo;
        private DevExpress.XtraBars.Ribbon.RibbonPage mainRibbonPage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mainRibbonPageGroup;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup searchRibbonPageGroup;
        private DevExpress.XtraEditors.LabelControl lblID;
        private DevExpress.XtraEditors.LabelControl lblNombre;
        private DevExpress.XtraEditors.TextEdit txtNombre;
        private DevExpress.XtraEditors.LabelControl lblCodigo;
        private DevExpress.XtraEditors.TextEdit txtCodigo;
        private DevExpress.XtraEditors.CheckEdit cbActivo;
        private DevExpress.XtraEditors.CheckEdit cbLectorHuella;
        private DevExpress.XtraEditors.LabelControl lblFechaActualizacion;
        private DevExpress.XtraEditors.LabelControl lblUltimaActualizacion;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.LabelControl lblImpresoraDocumentos;
        private DevExpress.XtraEditors.LabelControl lblImpresoraTickets;
        private DevExpress.XtraEditors.LookUpEdit cbImpresoraDocumentos;
        private DevExpress.XtraEditors.LookUpEdit cbImpresoraTickets;
        private DevExpress.XtraEditors.LookUpEdit cbBasculas;
        private DevExpress.XtraEditors.CheckEdit cbBascula;
        private DevExpress.XtraEditors.HyperlinkLabelControl lblBasculas;
        private DevExpress.XtraEditors.CheckEdit cbImpresion;
        private DevExpress.XtraEditors.CheckEdit cbEnvioCorreoAutomatico;
    }
}