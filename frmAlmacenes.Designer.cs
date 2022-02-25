namespace Nori
{
    partial class frmAlmacenes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAlmacenes));
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
            this.bbiUsuarios = new DevExpress.XtraBars.BarButtonItem();
            this.mainRibbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mainRibbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.searchRibbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageHerramientas = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.herramientasRibbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.lblID = new DevExpress.XtraEditors.LabelControl();
            this.lblNombre = new DevExpress.XtraEditors.LabelControl();
            this.txtNombre = new DevExpress.XtraEditors.TextEdit();
            this.lblCodigo = new DevExpress.XtraEditors.LabelControl();
            this.txtCodigo = new DevExpress.XtraEditors.TextEdit();
            this.cbActivo = new DevExpress.XtraEditors.CheckEdit();
            this.lblFechaActualizacion = new DevExpress.XtraEditors.LabelControl();
            this.lblUltimaActualizacion = new DevExpress.XtraEditors.LabelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblUbicacion = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.cbUbicacion = new DevExpress.XtraEditors.LookUpEdit();
            this.cbUbicaciones = new DevExpress.XtraEditors.CheckEdit();
            this.lblCuentaAjusteInventario = new DevExpress.XtraEditors.LabelControl();
            this.txtNumeroCuentaAjusteInventario = new DevExpress.XtraEditors.TextEdit();
            this.cbImpresoras = new DevExpress.XtraEditors.LookUpEdit();
            this.lblImpresora = new DevExpress.XtraEditors.LabelControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.cbTransito = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbActivo.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbUbicacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbUbicaciones.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroCuentaAjusteInventario.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbImpresoras.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTransito.Properties)).BeginInit();
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
            this.bbiUsuarios,
            this.mainRibbonControl.SearchEditItem});
            this.mainRibbonControl.Location = new System.Drawing.Point(0, 0);
            this.mainRibbonControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mainRibbonControl.MaxItemId = 3;
            this.mainRibbonControl.Name = "mainRibbonControl";
            this.mainRibbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.mainRibbonPage,
            this.ribbonPageHerramientas});
            this.mainRibbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.OfficeUniversal;
            this.mainRibbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.mainRibbonControl.Size = new System.Drawing.Size(856, 131);
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
            // bbiUsuarios
            // 
            this.bbiUsuarios.Caption = "Usuarios";
            this.bbiUsuarios.Id = 2;
            this.bbiUsuarios.ImageOptions.ImageUri.Uri = "ListBullets";
            this.bbiUsuarios.Name = "bbiUsuarios";
            this.bbiUsuarios.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiUsuarios_ItemClick);
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
            // ribbonPageHerramientas
            // 
            this.ribbonPageHerramientas.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.herramientasRibbonPageGroup});
            this.ribbonPageHerramientas.Name = "ribbonPageHerramientas";
            this.ribbonPageHerramientas.Text = "HERRAMIENTAS";
            // 
            // herramientasRibbonPageGroup
            // 
            this.herramientasRibbonPageGroup.ItemLinks.Add(this.bbiUsuarios);
            this.herramientasRibbonPageGroup.Name = "herramientasRibbonPageGroup";
            this.herramientasRibbonPageGroup.Text = "Herramientas";
            // 
            // lblID
            // 
            this.lblID.Location = new System.Drawing.Point(513, 23);
            this.lblID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(9, 19);
            this.lblID.TabIndex = 47;
            this.lblID.Text = "0";
            // 
            // lblNombre
            // 
            this.lblNombre.Location = new System.Drawing.Point(18, 61);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(57, 19);
            this.lblNombre.TabIndex = 46;
            this.lblNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(171, 57);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNombre.MenuManager = this.mainRibbonControl;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Properties.MaxLength = 100;
            this.txtNombre.Size = new System.Drawing.Size(632, 28);
            this.txtNombre.TabIndex = 1;
            this.txtNombre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigo_KeyDown);
            // 
            // lblCodigo
            // 
            this.lblCodigo.Location = new System.Drawing.Point(18, 23);
            this.lblCodigo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(50, 19);
            this.lblCodigo.TabIndex = 44;
            this.lblCodigo.Text = "Código";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(171, 19);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCodigo.MenuManager = this.mainRibbonControl;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Properties.MaxLength = 8;
            this.txtCodigo.Size = new System.Drawing.Size(328, 28);
            this.txtCodigo.TabIndex = 0;
            this.txtCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigo_KeyDown);
            // 
            // cbActivo
            // 
            this.cbActivo.Location = new System.Drawing.Point(18, 248);
            this.cbActivo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbActivo.MenuManager = this.mainRibbonControl;
            this.cbActivo.Name = "cbActivo";
            this.cbActivo.Properties.Caption = "Activo";
            this.cbActivo.Size = new System.Drawing.Size(180, 29);
            this.cbActivo.TabIndex = 6;
            // 
            // lblFechaActualizacion
            // 
            this.lblFechaActualizacion.Location = new System.Drawing.Point(718, 253);
            this.lblFechaActualizacion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblFechaActualizacion.Name = "lblFechaActualizacion";
            this.lblFechaActualizacion.Size = new System.Drawing.Size(84, 19);
            this.lblFechaActualizacion.TabIndex = 51;
            this.lblFechaActualizacion.Text = "01/01/0001";
            // 
            // lblUltimaActualizacion
            // 
            this.lblUltimaActualizacion.Location = new System.Drawing.Point(513, 253);
            this.lblUltimaActualizacion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblUltimaActualizacion.Name = "lblUltimaActualizacion";
            this.lblUltimaActualizacion.Size = new System.Drawing.Size(143, 19);
            this.lblUltimaActualizacion.TabIndex = 50;
            this.lblUltimaActualizacion.Text = "Última Actualización";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbTransito);
            this.panel1.Controls.Add(this.lblUbicacion);
            this.panel1.Controls.Add(this.cbUbicacion);
            this.panel1.Controls.Add(this.cbUbicaciones);
            this.panel1.Controls.Add(this.lblCuentaAjusteInventario);
            this.panel1.Controls.Add(this.txtNumeroCuentaAjusteInventario);
            this.panel1.Controls.Add(this.cbImpresoras);
            this.panel1.Controls.Add(this.lblImpresora);
            this.panel1.Controls.Add(this.lblFechaActualizacion);
            this.panel1.Controls.Add(this.txtNombre);
            this.panel1.Controls.Add(this.lblUltimaActualizacion);
            this.panel1.Controls.Add(this.txtCodigo);
            this.panel1.Controls.Add(this.lblCodigo);
            this.panel1.Controls.Add(this.cbActivo);
            this.panel1.Controls.Add(this.lblNombre);
            this.panel1.Controls.Add(this.lblID);
            this.panel1.Location = new System.Drawing.Point(10, 12);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(836, 286);
            this.panel1.TabIndex = 53;
            // 
            // lblUbicacion
            // 
            this.lblUbicacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblUbicacion.Location = new System.Drawing.Point(14, 212);
            this.lblUbicacion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblUbicacion.Name = "lblUbicacion";
            this.lblUbicacion.Size = new System.Drawing.Size(153, 19);
            this.lblUbicacion.TabIndex = 64;
            this.lblUbicacion.Text = "Ubicación por defecto";
            this.lblUbicacion.Click += new System.EventHandler(this.lblUbicacion_Click);
            // 
            // cbUbicacion
            // 
            this.cbUbicacion.Location = new System.Drawing.Point(171, 208);
            this.cbUbicacion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbUbicacion.MenuManager = this.mainRibbonControl;
            this.cbUbicacion.Name = "cbUbicacion";
            this.cbUbicacion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbUbicacion.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("codigo", "Código"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ubicacion", "Ubicación")});
            this.cbUbicacion.Size = new System.Drawing.Size(328, 28);
            this.cbUbicacion.TabIndex = 5;
            // 
            // cbUbicaciones
            // 
            this.cbUbicaciones.Location = new System.Drawing.Point(171, 171);
            this.cbUbicaciones.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbUbicaciones.MenuManager = this.mainRibbonControl;
            this.cbUbicaciones.Name = "cbUbicaciones";
            this.cbUbicaciones.Properties.Caption = "Usar ubicaciones";
            this.cbUbicaciones.Size = new System.Drawing.Size(180, 29);
            this.cbUbicaciones.TabIndex = 4;
            // 
            // lblCuentaAjusteInventario
            // 
            this.lblCuentaAjusteInventario.Location = new System.Drawing.Point(18, 137);
            this.lblCuentaAjusteInventario.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblCuentaAjusteInventario.Name = "lblCuentaAjusteInventario";
            this.lblCuentaAjusteInventario.Size = new System.Drawing.Size(103, 19);
            this.lblCuentaAjusteInventario.TabIndex = 58;
            this.lblCuentaAjusteInventario.Text = "Cuenta ajustes";
            // 
            // txtNumeroCuentaAjusteInventario
            // 
            this.txtNumeroCuentaAjusteInventario.Location = new System.Drawing.Point(171, 133);
            this.txtNumeroCuentaAjusteInventario.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNumeroCuentaAjusteInventario.MenuManager = this.mainRibbonControl;
            this.txtNumeroCuentaAjusteInventario.Name = "txtNumeroCuentaAjusteInventario";
            this.txtNumeroCuentaAjusteInventario.Properties.MaxLength = 15;
            this.txtNumeroCuentaAjusteInventario.Properties.NullValuePrompt = "Cuenta ajustes de inventario";
            this.txtNumeroCuentaAjusteInventario.Size = new System.Drawing.Size(328, 28);
            this.txtNumeroCuentaAjusteInventario.TabIndex = 3;
            // 
            // cbImpresoras
            // 
            this.cbImpresoras.Location = new System.Drawing.Point(171, 95);
            this.cbImpresoras.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbImpresoras.MenuManager = this.mainRibbonControl;
            this.cbImpresoras.Name = "cbImpresoras";
            this.cbImpresoras.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbImpresoras.Size = new System.Drawing.Size(328, 28);
            this.cbImpresoras.TabIndex = 2;
            // 
            // lblImpresora
            // 
            this.lblImpresora.Location = new System.Drawing.Point(18, 99);
            this.lblImpresora.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblImpresora.Name = "lblImpresora";
            this.lblImpresora.Size = new System.Drawing.Size(73, 19);
            this.lblImpresora.TabIndex = 56;
            this.lblImpresora.Text = "Impresora";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.panel1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 131);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(92, 301, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(856, 293);
            this.layoutControl1.TabIndex = 57;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(856, 293);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // cbTransito
            // 
            this.cbTransito.Location = new System.Drawing.Point(369, 171);
            this.cbTransito.Margin = new System.Windows.Forms.Padding(4);
            this.cbTransito.MenuManager = this.mainRibbonControl;
            this.cbTransito.Name = "cbTransito";
            this.cbTransito.Properties.Caption = "Tránsito";
            this.cbTransito.Size = new System.Drawing.Size(180, 29);
            this.cbTransito.TabIndex = 65;
            // 
            // frmAlmacenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 424);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.mainRibbonControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frmAlmacenes.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "frmAlmacenes";
            this.Ribbon = this.mainRibbonControl;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Almacenes";
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbActivo.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbUbicacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbUbicaciones.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroCuentaAjusteInventario.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbImpresoras.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTransito.Properties)).EndInit();
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
        private DevExpress.XtraEditors.LabelControl lblFechaActualizacion;
        private DevExpress.XtraEditors.LabelControl lblUltimaActualizacion;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.LookUpEdit cbImpresoras;
        private DevExpress.XtraEditors.LabelControl lblImpresora;
        private DevExpress.XtraEditors.TextEdit txtNumeroCuentaAjusteInventario;
        private DevExpress.XtraEditors.LabelControl lblCuentaAjusteInventario;
        private DevExpress.XtraEditors.CheckEdit cbUbicaciones;
        private DevExpress.XtraEditors.LookUpEdit cbUbicacion;
        private DevExpress.XtraEditors.HyperlinkLabelControl lblUbicacion;
        private DevExpress.XtraBars.BarButtonItem bbiUsuarios;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageHerramientas;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup herramientasRibbonPageGroup;
        private DevExpress.XtraEditors.CheckEdit cbTransito;
    }
}