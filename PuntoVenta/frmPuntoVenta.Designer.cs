namespace Nori.PuntoVenta
{
    partial class frmPuntoVenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPuntoVenta));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.lblEstacion = new DevExpress.XtraBars.BarStaticItem();
            this.lblUsuario = new DevExpress.XtraBars.BarStaticItem();
            this.lblPartidas = new DevExpress.XtraBars.BarStaticItem();
            this.lblVendedor = new DevExpress.XtraBars.BarEditItem();
            this.cbVendedores = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.bbiNuevo = new DevExpress.XtraBars.BarButtonItem();
            this.bbiImprimir = new DevExpress.XtraBars.BarButtonItem();
            this.bbiGuardar = new DevExpress.XtraBars.BarButtonItem();
            this.lblArticulos = new DevExpress.XtraBars.BarButtonItem();
            this.lblMoneda = new DevExpress.XtraBars.BarStaticItem();
            this.lblCantidadEmpaque = new DevExpress.XtraBars.BarStaticItem();
            this.bbiCortesCaja = new DevExpress.XtraBars.BarButtonItem();
            this.bbiArqueo = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPagos = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageArchivo = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupArchivo = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageHerramientas = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupHerramientas = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.repositoryItemLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.scPV = new DevExpress.XtraEditors.SplitContainerControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.cbPersonasContacto = new DevExpress.XtraEditors.LookUpEdit();
            this.lblPersonasContacto = new DevExpress.XtraEditors.LabelControl();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.cbReserva = new System.Windows.Forms.CheckBox();
            this.cbFactura = new System.Windows.Forms.CheckBox();
            this.lblCondicionPago = new DevExpress.XtraEditors.LabelControl();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtArticulo = new DevExpress.XtraEditors.TextEdit();
            this.separatorControl1 = new DevExpress.XtraEditors.SeparatorControl();
            this.lblCodigoSN = new DevExpress.XtraEditors.LabelControl();
            this.txtCodigoSN = new DevExpress.XtraEditors.TextEdit();
            this.lblSocio = new DevExpress.XtraEditors.LabelControl();
            this.lblEstadoCredito = new System.Windows.Forms.Label();
            this.splitContainerControl3 = new DevExpress.XtraEditors.SplitContainerControl();
            this.tlp = new System.Windows.Forms.TableLayoutPanel();
            this.gcPartidas = new DevExpress.XtraGrid.GridControl();
            this.gvPartidas = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnCantidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnUnidadMedida = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cbUnidadesMedida = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumnCantidadEmpaque = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnTipoEmpaque = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cbTiposEmpaques = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumnSKU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnArticulo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCodigoBarras = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnAlmacen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cbAlmacenes = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumnPrecio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPrecioNeto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPorcentajeDescuento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDescuento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSubTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cbMonedas = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.lblArticuloComentarios = new DevExpress.XtraEditors.LabelControl();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.pbImagen = new System.Windows.Forms.PictureBox();
            this.btnAtras = new DevExpress.XtraEditors.SimpleButton();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTotal_ = new System.Windows.Forms.Label();
            this.lblDescuento_ = new System.Windows.Forms.Label();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbVendedores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scPV)).BeginInit();
            this.scPV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbPersonasContacto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArticulo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigoSN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl3)).BeginInit();
            this.splitContainerControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcPartidas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPartidas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbUnidadesMedida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTiposEmpaques)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAlmacenes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMonedas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.AllowKeyTips = false;
            this.ribbonControl1.ApplicationButtonText = "SALIR";
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.lblEstacion,
            this.lblUsuario,
            this.lblPartidas,
            this.lblVendedor,
            this.bbiNuevo,
            this.bbiImprimir,
            this.bbiGuardar,
            this.lblArticulos,
            this.lblMoneda,
            this.lblCantidadEmpaque,
            this.bbiCortesCaja,
            this.bbiArqueo,
            this.bbiPagos});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ribbonControl1.MaxItemId = 20;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPageArchivo,
            this.ribbonPageHerramientas});
            this.ribbonControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cbVendedores,
            this.repositoryItemLookUpEdit2});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.OfficeUniversal;
            this.ribbonControl1.Size = new System.Drawing.Size(1383, 131);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            this.ribbonControl1.ApplicationButtonClick += new System.EventHandler(this.ribbonControl1_ApplicationButtonClick);
            // 
            // lblEstacion
            // 
            this.lblEstacion.Caption = "Estación";
            this.lblEstacion.Id = 1;
            this.lblEstacion.Name = "lblEstacion";
            // 
            // lblUsuario
            // 
            this.lblUsuario.Caption = "Usuario";
            this.lblUsuario.Id = 2;
            this.lblUsuario.Name = "lblUsuario";
            // 
            // lblPartidas
            // 
            this.lblPartidas.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.lblPartidas.Caption = "Partidas 0";
            this.lblPartidas.Id = 3;
            this.lblPartidas.Name = "lblPartidas";
            // 
            // lblVendedor
            // 
            this.lblVendedor.Caption = "Vendedor ";
            this.lblVendedor.Edit = this.cbVendedores;
            this.lblVendedor.EditWidth = 200;
            this.lblVendedor.Id = 7;
            this.lblVendedor.Name = "lblVendedor";
            this.lblVendedor.EditValueChanged += new System.EventHandler(this.lblVendedor_EditValueChanged);
            // 
            // cbVendedores
            // 
            this.cbVendedores.AutoHeight = false;
            this.cbVendedores.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbVendedores.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nombre", "Nombre", 60, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.cbVendedores.Name = "cbVendedores";
            // 
            // bbiNuevo
            // 
            this.bbiNuevo.Caption = "Nuevo";
            this.bbiNuevo.Id = 8;
            this.bbiNuevo.ImageOptions.ImageUri.Uri = "AddItem";
            this.bbiNuevo.Name = "bbiNuevo";
            this.bbiNuevo.ShowItemShortcut = DevExpress.Utils.DefaultBoolean.False;
            this.bbiNuevo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiNuevo_ItemClick);
            // 
            // bbiImprimir
            // 
            this.bbiImprimir.Caption = "Imprimir";
            this.bbiImprimir.Id = 10;
            this.bbiImprimir.ImageOptions.ImageUri.Uri = "Print";
            this.bbiImprimir.Name = "bbiImprimir";
            this.bbiImprimir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiImprimir_ItemClick);
            // 
            // bbiGuardar
            // 
            this.bbiGuardar.Caption = "Guardar";
            this.bbiGuardar.Id = 11;
            this.bbiGuardar.ImageOptions.ImageUri.Uri = "Save";
            this.bbiGuardar.Name = "bbiGuardar";
            this.bbiGuardar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiGuardar_ItemClick);
            // 
            // lblArticulos
            // 
            this.lblArticulos.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.lblArticulos.Caption = "Artículos 0";
            this.lblArticulos.Id = 12;
            this.lblArticulos.Name = "lblArticulos";
            // 
            // lblMoneda
            // 
            this.lblMoneda.Caption = "Moneda";
            this.lblMoneda.Id = 13;
            this.lblMoneda.Name = "lblMoneda";
            // 
            // lblCantidadEmpaque
            // 
            this.lblCantidadEmpaque.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.lblCantidadEmpaque.Caption = "Cantidad empaque 0";
            this.lblCantidadEmpaque.Id = 16;
            this.lblCantidadEmpaque.Name = "lblCantidadEmpaque";
            // 
            // bbiCortesCaja
            // 
            this.bbiCortesCaja.Caption = "Cortes y flujo de caja";
            this.bbiCortesCaja.Id = 17;
            this.bbiCortesCaja.ImageOptions.ImageUri.Uri = "Cut";
            this.bbiCortesCaja.Name = "bbiCortesCaja";
            this.bbiCortesCaja.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiCortesCaja_ItemClick);
            // 
            // bbiArqueo
            // 
            this.bbiArqueo.Caption = "Arqueo";
            this.bbiArqueo.Id = 18;
            this.bbiArqueo.ImageOptions.ImageUri.Uri = "Summary";
            this.bbiArqueo.Name = "bbiArqueo";
            this.bbiArqueo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiArqueo_ItemClick);
            // 
            // bbiPagos
            // 
            this.bbiPagos.Caption = "Pagos";
            this.bbiPagos.Id = 19;
            this.bbiPagos.ImageOptions.ImageUri.Uri = "Currency";
            this.bbiPagos.Name = "bbiPagos";
            this.bbiPagos.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiPagos_ItemClick);
            // 
            // ribbonPageArchivo
            // 
            this.ribbonPageArchivo.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupArchivo});
            this.ribbonPageArchivo.Name = "ribbonPageArchivo";
            this.ribbonPageArchivo.Text = "ARCHIVO";
            // 
            // ribbonPageGroupArchivo
            // 
            this.ribbonPageGroupArchivo.AllowTextClipping = false;
            this.ribbonPageGroupArchivo.ItemLinks.Add(this.bbiNuevo);
            this.ribbonPageGroupArchivo.ItemLinks.Add(this.bbiGuardar);
            this.ribbonPageGroupArchivo.ItemLinks.Add(this.bbiImprimir);
            this.ribbonPageGroupArchivo.Name = "ribbonPageGroupArchivo";
            this.ribbonPageGroupArchivo.Text = "Archivo";
            // 
            // ribbonPageHerramientas
            // 
            this.ribbonPageHerramientas.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupHerramientas});
            this.ribbonPageHerramientas.Name = "ribbonPageHerramientas";
            this.ribbonPageHerramientas.Text = "HERRAMIENTAS";
            // 
            // ribbonPageGroupHerramientas
            // 
            this.ribbonPageGroupHerramientas.ItemLinks.Add(this.bbiArqueo);
            this.ribbonPageGroupHerramientas.ItemLinks.Add(this.bbiPagos);
            this.ribbonPageGroupHerramientas.ItemLinks.Add(this.bbiCortesCaja);
            this.ribbonPageGroupHerramientas.Name = "ribbonPageGroupHerramientas";
            this.ribbonPageGroupHerramientas.Text = "Herramientas";
            // 
            // repositoryItemLookUpEdit2
            // 
            this.repositoryItemLookUpEdit2.AutoHeight = false;
            this.repositoryItemLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit2.Name = "repositoryItemLookUpEdit2";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.ItemLinks.Add(this.lblEstacion);
            this.ribbonStatusBar1.ItemLinks.Add(this.lblUsuario, true);
            this.ribbonStatusBar1.ItemLinks.Add(this.lblMoneda, true);
            this.ribbonStatusBar1.ItemLinks.Add(this.lblVendedor, true);
            this.ribbonStatusBar1.ItemLinks.Add(this.lblPartidas);
            this.ribbonStatusBar1.ItemLinks.Add(this.lblArticulos, true);
            this.ribbonStatusBar1.ItemLinks.Add(this.lblCantidadEmpaque, true);
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 839);
            this.ribbonStatusBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1383, 36);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.scPV);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 131);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1383, 708);
            this.layoutControl1.TabIndex = 2;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // scPV
            // 
            this.scPV.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.scPV.Location = new System.Drawing.Point(18, 18);
            this.scPV.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.scPV.Name = "scPV";
            this.scPV.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.scPV.Panel1.Controls.Add(this.splitContainerControl1);
            this.scPV.Panel1.MinSize = 660;
            this.scPV.Panel1.Text = "Panel1";
            this.scPV.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.scPV.Panel2.Controls.Add(this.splitContainerControl2);
            this.scPV.Panel2.MinSize = 210;
            this.scPV.Panel2.Text = "Panel2";
            this.scPV.Size = new System.Drawing.Size(1347, 672);
            this.scPV.SplitterPosition = 1010;
            this.scPV.TabIndex = 4;
            this.scPV.Text = "splitContainerControl1";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.cbPersonasContacto);
            this.splitContainerControl1.Panel1.Controls.Add(this.lblPersonasContacto);
            this.splitContainerControl1.Panel1.Controls.Add(this.splitter1);
            this.splitContainerControl1.Panel1.Controls.Add(this.cbReserva);
            this.splitContainerControl1.Panel1.Controls.Add(this.cbFactura);
            this.splitContainerControl1.Panel1.Controls.Add(this.lblCondicionPago);
            this.splitContainerControl1.Panel1.Controls.Add(this.lblDireccion);
            this.splitContainerControl1.Panel1.Controls.Add(this.pictureBox1);
            this.splitContainerControl1.Panel1.Controls.Add(this.txtArticulo);
            this.splitContainerControl1.Panel1.Controls.Add(this.separatorControl1);
            this.splitContainerControl1.Panel1.Controls.Add(this.lblCodigoSN);
            this.splitContainerControl1.Panel1.Controls.Add(this.txtCodigoSN);
            this.splitContainerControl1.Panel1.Controls.Add(this.lblSocio);
            this.splitContainerControl1.Panel1.Controls.Add(this.lblEstadoCredito);
            this.splitContainerControl1.Panel1.MinSize = 115;
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.splitContainerControl3);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1006, 668);
            this.splitContainerControl1.SplitterPosition = 159;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // cbPersonasContacto
            // 
            this.cbPersonasContacto.Location = new System.Drawing.Point(176, 75);
            this.cbPersonasContacto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbPersonasContacto.Name = "cbPersonasContacto";
            this.cbPersonasContacto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbPersonasContacto.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nombre", "Nombre"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nombre_persona", "Persona contacto")});
            this.cbPersonasContacto.Size = new System.Drawing.Size(230, 28);
            this.cbPersonasContacto.TabIndex = 77;
            this.cbPersonasContacto.TabStop = false;
            // 
            // lblPersonasContacto
            // 
            this.lblPersonasContacto.Location = new System.Drawing.Point(22, 79);
            this.lblPersonasContacto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblPersonasContacto.Name = "lblPersonasContacto";
            this.lblPersonasContacto.Size = new System.Drawing.Size(142, 19);
            this.lblPersonasContacto.TabIndex = 78;
            this.lblPersonasContacto.Text = "Persona de contacto";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(4, 168);
            this.splitter1.TabIndex = 21;
            this.splitter1.TabStop = false;
            // 
            // cbReserva
            // 
            this.cbReserva.AutoSize = true;
            this.cbReserva.Location = new System.Drawing.Point(414, 16);
            this.cbReserva.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbReserva.Name = "cbReserva";
            this.cbReserva.Size = new System.Drawing.Size(90, 23);
            this.cbReserva.TabIndex = 20;
            this.cbReserva.TabStop = false;
            this.cbReserva.Text = "Reserva";
            this.cbReserva.UseVisualStyleBackColor = true;
            this.cbReserva.Visible = false;
            this.cbReserva.CheckedChanged += new System.EventHandler(this.cbReserva_CheckedChanged);
            // 
            // cbFactura
            // 
            this.cbFactura.AutoSize = true;
            this.cbFactura.Location = new System.Drawing.Point(310, 16);
            this.cbFactura.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbFactura.Name = "cbFactura";
            this.cbFactura.Size = new System.Drawing.Size(86, 23);
            this.cbFactura.TabIndex = 0;
            this.cbFactura.TabStop = false;
            this.cbFactura.Text = "Factura";
            this.cbFactura.UseVisualStyleBackColor = true;
            this.cbFactura.CheckedChanged += new System.EventHandler(this.cbFactura_CheckedChanged);
            // 
            // lblCondicionPago
            // 
            this.lblCondicionPago.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.lblCondicionPago.Appearance.Options.UseForeColor = true;
            this.lblCondicionPago.Location = new System.Drawing.Point(414, 79);
            this.lblCondicionPago.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblCondicionPago.Name = "lblCondicionPago";
            this.lblCondicionPago.Size = new System.Drawing.Size(132, 19);
            this.lblCondicionPago.TabIndex = 19;
            this.lblCondicionPago.Text = "Condición de pago";
            // 
            // lblDireccion
            // 
            this.lblDireccion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDireccion.ForeColor = System.Drawing.Color.DimGray;
            this.lblDireccion.Location = new System.Drawing.Point(556, 18);
            this.lblDireccion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDireccion.Size = new System.Drawing.Size(429, 48);
            this.lblDireccion.TabIndex = 0;
            this.lblDireccion.Text = "Dirección de facturación";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Nori.Properties.Resources.barcode;
            this.pictureBox1.Location = new System.Drawing.Point(24, 126);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // txtArticulo
            // 
            this.txtArticulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtArticulo.Location = new System.Drawing.Point(69, 129);
            this.txtArticulo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtArticulo.MenuManager = this.ribbonControl1;
            this.txtArticulo.Name = "txtArticulo";
            this.txtArticulo.Size = new System.Drawing.Size(911, 28);
            this.txtArticulo.TabIndex = 1;
            this.txtArticulo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtArticulo_KeyDown);
            this.txtArticulo.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtArticulo_PreviewKeyDown);
            // 
            // separatorControl1
            // 
            this.separatorControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.separatorControl1.Location = new System.Drawing.Point(-3, 99);
            this.separatorControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.separatorControl1.Name = "separatorControl1";
            this.separatorControl1.Padding = new System.Windows.Forms.Padding(14, 13, 14, 13);
            this.separatorControl1.Size = new System.Drawing.Size(1004, 26);
            this.separatorControl1.TabIndex = 0;
            this.separatorControl1.TabStop = false;
            // 
            // lblCodigoSN
            // 
            this.lblCodigoSN.Location = new System.Drawing.Point(24, 18);
            this.lblCodigoSN.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblCodigoSN.Name = "lblCodigoSN";
            this.lblCodigoSN.Size = new System.Drawing.Size(75, 19);
            this.lblCodigoSN.TabIndex = 17;
            this.lblCodigoSN.Text = "Código SN";
            // 
            // txtCodigoSN
            // 
            this.txtCodigoSN.Location = new System.Drawing.Point(176, 13);
            this.txtCodigoSN.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCodigoSN.MenuManager = this.ribbonControl1;
            this.txtCodigoSN.Name = "txtCodigoSN";
            this.txtCodigoSN.Size = new System.Drawing.Size(126, 28);
            this.txtCodigoSN.TabIndex = 0;
            this.txtCodigoSN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoSN_KeyDown);
            this.txtCodigoSN.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtCodigoSN_PreviewKeyDown);
            // 
            // lblSocio
            // 
            this.lblSocio.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblSocio.Appearance.Options.UseFont = true;
            this.lblSocio.Location = new System.Drawing.Point(24, 47);
            this.lblSocio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblSocio.Name = "lblSocio";
            this.lblSocio.Size = new System.Drawing.Size(332, 21);
            this.lblSocio.TabIndex = 15;
            this.lblSocio.Text = "Por favor ingrese un socio de negocios";
            // 
            // lblEstadoCredito
            // 
            this.lblEstadoCredito.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEstadoCredito.ForeColor = System.Drawing.Color.DimGray;
            this.lblEstadoCredito.Location = new System.Drawing.Point(413, 79);
            this.lblEstadoCredito.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEstadoCredito.Name = "lblEstadoCredito";
            this.lblEstadoCredito.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblEstadoCredito.Size = new System.Drawing.Size(570, 25);
            this.lblEstadoCredito.TabIndex = 79;
            this.lblEstadoCredito.Text = "Estado de crédito";
            // 
            // splitContainerControl3
            // 
            this.splitContainerControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl3.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainerControl3.Name = "splitContainerControl3";
            this.splitContainerControl3.Panel1.Controls.Add(this.tlp);
            this.splitContainerControl3.Panel1.Text = "Panel1";
            this.splitContainerControl3.Panel2.Controls.Add(this.gcPartidas);
            this.splitContainerControl3.Panel2.Text = "Panel2";
            this.splitContainerControl3.Size = new System.Drawing.Size(1006, 485);
            this.splitContainerControl3.SplitterPosition = 300;
            this.splitContainerControl3.TabIndex = 1;
            // 
            // tlp
            // 
            this.tlp.AutoScroll = true;
            this.tlp.ColumnCount = 3;
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp.Location = new System.Drawing.Point(0, 0);
            this.tlp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tlp.Name = "tlp";
            this.tlp.RowCount = 1;
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp.Size = new System.Drawing.Size(300, 485);
            this.tlp.TabIndex = 2;
            // 
            // gcPartidas
            // 
            this.gcPartidas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcPartidas.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gcPartidas.Location = new System.Drawing.Point(0, 0);
            this.gcPartidas.MainView = this.gvPartidas;
            this.gcPartidas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gcPartidas.MenuManager = this.ribbonControl1;
            this.gcPartidas.Name = "gcPartidas";
            this.gcPartidas.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cbMonedas,
            this.cbTiposEmpaques,
            this.cbAlmacenes,
            this.cbUnidadesMedida});
            this.gcPartidas.Size = new System.Drawing.Size(691, 485);
            this.gcPartidas.TabIndex = 1;
            this.gcPartidas.TabStop = false;
            this.gcPartidas.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPartidas});
            // 
            // gvPartidas
            // 
            this.gvPartidas.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gvPartidas.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnCantidad,
            this.gridColumnUnidadMedida,
            this.gridColumnCantidadEmpaque,
            this.gridColumnTipoEmpaque,
            this.gridColumnSKU,
            this.gridColumnArticulo,
            this.gridColumnCodigoBarras,
            this.gridColumnAlmacen,
            this.gridColumnPrecio,
            this.gridColumnPrecioNeto,
            this.gridColumnPorcentajeDescuento,
            this.gridColumnDescuento,
            this.gridColumnSubTotal,
            this.gridColumnTotal});
            this.gvPartidas.DetailHeight = 512;
            this.gvPartidas.FixedLineWidth = 3;
            this.gvPartidas.GridControl = this.gcPartidas;
            this.gvPartidas.Name = "gvPartidas";
            this.gvPartidas.OptionsCustomization.AllowSort = false;
            this.gvPartidas.OptionsView.ShowGroupPanel = false;
            this.gvPartidas.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gvPartidas_RowStyle);
            this.gvPartidas.ShownEditor += new System.EventHandler(this.gvPartidas_ShownEditor);
            this.gvPartidas.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvPartidas_FocusedRowChanged);
            this.gvPartidas.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvPartidas_CellValueChanged);
            this.gvPartidas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvPartidas_KeyDown);
            // 
            // gridColumnCantidad
            // 
            this.gridColumnCantidad.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumnCantidad.AppearanceCell.Options.UseFont = true;
            this.gridColumnCantidad.Caption = "Cant";
            this.gridColumnCantidad.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnCantidad.FieldName = "cantidad";
            this.gridColumnCantidad.MaxWidth = 60;
            this.gridColumnCantidad.MinWidth = 60;
            this.gridColumnCantidad.Name = "gridColumnCantidad";
            this.gridColumnCantidad.OptionsColumn.FixedWidth = true;
            this.gridColumnCantidad.Visible = true;
            this.gridColumnCantidad.VisibleIndex = 0;
            this.gridColumnCantidad.Width = 60;
            // 
            // gridColumnUnidadMedida
            // 
            this.gridColumnUnidadMedida.Caption = "UdM";
            this.gridColumnUnidadMedida.ColumnEdit = this.cbUnidadesMedida;
            this.gridColumnUnidadMedida.FieldName = "unidad_medida_id";
            this.gridColumnUnidadMedida.MinWidth = 30;
            this.gridColumnUnidadMedida.Name = "gridColumnUnidadMedida";
            this.gridColumnUnidadMedida.Visible = true;
            this.gridColumnUnidadMedida.VisibleIndex = 1;
            this.gridColumnUnidadMedida.Width = 112;
            // 
            // cbUnidadesMedida
            // 
            this.cbUnidadesMedida.AutoHeight = false;
            this.cbUnidadesMedida.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbUnidadesMedida.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nombre", "Nombre")});
            this.cbUnidadesMedida.Name = "cbUnidadesMedida";
            // 
            // gridColumnCantidadEmpaque
            // 
            this.gridColumnCantidadEmpaque.Caption = "C/E";
            this.gridColumnCantidadEmpaque.DisplayFormat.FormatString = "n2";
            this.gridColumnCantidadEmpaque.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnCantidadEmpaque.FieldName = "cantidad_empaque";
            this.gridColumnCantidadEmpaque.MinWidth = 45;
            this.gridColumnCantidadEmpaque.Name = "gridColumnCantidadEmpaque";
            this.gridColumnCantidadEmpaque.Width = 45;
            // 
            // gridColumnTipoEmpaque
            // 
            this.gridColumnTipoEmpaque.Caption = "Tipo empaque";
            this.gridColumnTipoEmpaque.ColumnEdit = this.cbTiposEmpaques;
            this.gridColumnTipoEmpaque.FieldName = "tipo_empaque_id";
            this.gridColumnTipoEmpaque.MinWidth = 112;
            this.gridColumnTipoEmpaque.Name = "gridColumnTipoEmpaque";
            this.gridColumnTipoEmpaque.Width = 112;
            // 
            // cbTiposEmpaques
            // 
            this.cbTiposEmpaques.AutoHeight = false;
            this.cbTiposEmpaques.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbTiposEmpaques.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nombre", "Nombre")});
            this.cbTiposEmpaques.Name = "cbTiposEmpaques";
            // 
            // gridColumnSKU
            // 
            this.gridColumnSKU.Caption = "SKU";
            this.gridColumnSKU.FieldName = "sku";
            this.gridColumnSKU.MaxWidth = 225;
            this.gridColumnSKU.MinWidth = 90;
            this.gridColumnSKU.Name = "gridColumnSKU";
            this.gridColumnSKU.OptionsColumn.AllowEdit = false;
            this.gridColumnSKU.Visible = true;
            this.gridColumnSKU.VisibleIndex = 2;
            this.gridColumnSKU.Width = 90;
            // 
            // gridColumnArticulo
            // 
            this.gridColumnArticulo.Caption = "Artículo";
            this.gridColumnArticulo.FieldName = "nombre";
            this.gridColumnArticulo.MinWidth = 150;
            this.gridColumnArticulo.Name = "gridColumnArticulo";
            this.gridColumnArticulo.OptionsColumn.AllowEdit = false;
            this.gridColumnArticulo.Visible = true;
            this.gridColumnArticulo.VisibleIndex = 3;
            this.gridColumnArticulo.Width = 150;
            // 
            // gridColumnCodigoBarras
            // 
            this.gridColumnCodigoBarras.Caption = "Código de barras";
            this.gridColumnCodigoBarras.FieldName = "codigo_barras";
            this.gridColumnCodigoBarras.MaxWidth = 180;
            this.gridColumnCodigoBarras.MinWidth = 120;
            this.gridColumnCodigoBarras.Name = "gridColumnCodigoBarras";
            this.gridColumnCodigoBarras.OptionsColumn.AllowEdit = false;
            this.gridColumnCodigoBarras.Visible = true;
            this.gridColumnCodigoBarras.VisibleIndex = 4;
            this.gridColumnCodigoBarras.Width = 120;
            // 
            // gridColumnAlmacen
            // 
            this.gridColumnAlmacen.Caption = "Almacén";
            this.gridColumnAlmacen.ColumnEdit = this.cbAlmacenes;
            this.gridColumnAlmacen.FieldName = "almacen_id";
            this.gridColumnAlmacen.MinWidth = 30;
            this.gridColumnAlmacen.Name = "gridColumnAlmacen";
            this.gridColumnAlmacen.Visible = true;
            this.gridColumnAlmacen.VisibleIndex = 5;
            this.gridColumnAlmacen.Width = 112;
            // 
            // cbAlmacenes
            // 
            this.cbAlmacenes.AutoHeight = false;
            this.cbAlmacenes.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbAlmacenes.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("codigo", "Código"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nombre", "Nombre", 40, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.cbAlmacenes.Name = "cbAlmacenes";
            // 
            // gridColumnPrecio
            // 
            this.gridColumnPrecio.Caption = "Precio";
            this.gridColumnPrecio.DisplayFormat.FormatString = "c2";
            this.gridColumnPrecio.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnPrecio.FieldName = "gridColumnPrecio";
            this.gridColumnPrecio.MinWidth = 90;
            this.gridColumnPrecio.Name = "gridColumnPrecio";
            this.gridColumnPrecio.UnboundExpression = "precio * tipo_cambio";
            this.gridColumnPrecio.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.gridColumnPrecio.Visible = true;
            this.gridColumnPrecio.VisibleIndex = 6;
            this.gridColumnPrecio.Width = 90;
            // 
            // gridColumnPrecioNeto
            // 
            this.gridColumnPrecioNeto.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumnPrecioNeto.AppearanceCell.Options.UseFont = true;
            this.gridColumnPrecioNeto.Caption = "P. Neto";
            this.gridColumnPrecioNeto.DisplayFormat.FormatString = "c2";
            this.gridColumnPrecioNeto.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnPrecioNeto.FieldName = "gridColumnPrecioNeto";
            this.gridColumnPrecioNeto.MinWidth = 90;
            this.gridColumnPrecioNeto.Name = "gridColumnPrecioNeto";
            this.gridColumnPrecioNeto.UnboundExpression = "(precio * tipo_cambio) + impuesto";
            this.gridColumnPrecioNeto.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.gridColumnPrecioNeto.Visible = true;
            this.gridColumnPrecioNeto.VisibleIndex = 7;
            this.gridColumnPrecioNeto.Width = 90;
            // 
            // gridColumnPorcentajeDescuento
            // 
            this.gridColumnPorcentajeDescuento.Caption = "% Dscto";
            this.gridColumnPorcentajeDescuento.DisplayFormat.FormatString = "p2";
            this.gridColumnPorcentajeDescuento.FieldName = "porcentaje_descuento";
            this.gridColumnPorcentajeDescuento.MaxWidth = 75;
            this.gridColumnPorcentajeDescuento.MinWidth = 30;
            this.gridColumnPorcentajeDescuento.Name = "gridColumnPorcentajeDescuento";
            this.gridColumnPorcentajeDescuento.OptionsColumn.FixedWidth = true;
            this.gridColumnPorcentajeDescuento.Visible = true;
            this.gridColumnPorcentajeDescuento.VisibleIndex = 8;
            // 
            // gridColumnDescuento
            // 
            this.gridColumnDescuento.Caption = "Descuento";
            this.gridColumnDescuento.DisplayFormat.FormatString = "c2";
            this.gridColumnDescuento.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnDescuento.FieldName = "descuento";
            this.gridColumnDescuento.MaxWidth = 180;
            this.gridColumnDescuento.MinWidth = 90;
            this.gridColumnDescuento.Name = "gridColumnDescuento";
            this.gridColumnDescuento.OptionsColumn.AllowEdit = false;
            this.gridColumnDescuento.Visible = true;
            this.gridColumnDescuento.VisibleIndex = 9;
            this.gridColumnDescuento.Width = 90;
            // 
            // gridColumnSubTotal
            // 
            this.gridColumnSubTotal.Caption = "SubTotal";
            this.gridColumnSubTotal.DisplayFormat.FormatString = "c2";
            this.gridColumnSubTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnSubTotal.FieldName = "subtotal";
            this.gridColumnSubTotal.MinWidth = 90;
            this.gridColumnSubTotal.Name = "gridColumnSubTotal";
            this.gridColumnSubTotal.OptionsColumn.AllowEdit = false;
            this.gridColumnSubTotal.Visible = true;
            this.gridColumnSubTotal.VisibleIndex = 10;
            this.gridColumnSubTotal.Width = 90;
            // 
            // gridColumnTotal
            // 
            this.gridColumnTotal.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumnTotal.AppearanceCell.Options.UseFont = true;
            this.gridColumnTotal.Caption = "Total";
            this.gridColumnTotal.DisplayFormat.FormatString = "c2";
            this.gridColumnTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnTotal.FieldName = "total";
            this.gridColumnTotal.MinWidth = 90;
            this.gridColumnTotal.Name = "gridColumnTotal";
            this.gridColumnTotal.Visible = true;
            this.gridColumnTotal.VisibleIndex = 11;
            this.gridColumnTotal.Width = 90;
            // 
            // cbMonedas
            // 
            this.cbMonedas.AutoHeight = false;
            this.cbMonedas.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbMonedas.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("codigo", "Código")});
            this.cbMonedas.Name = "cbMonedas";
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.splitContainerControl2.Horizontal = false;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Controls.Add(this.lblArticuloComentarios);
            this.splitContainerControl2.Panel1.Controls.Add(this.pbLogo);
            this.splitContainerControl2.Panel1.Controls.Add(this.pbImagen);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.Controls.Add(this.btnAtras);
            this.splitContainerControl2.Panel2.Controls.Add(this.lblDescuento);
            this.splitContainerControl2.Panel2.Controls.Add(this.lblTotal);
            this.splitContainerControl2.Panel2.Controls.Add(this.lblTotal_);
            this.splitContainerControl2.Panel2.Controls.Add(this.lblDescuento_);
            this.splitContainerControl2.Panel2.MinSize = 100;
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(318, 668);
            this.splitContainerControl2.SplitterPosition = 501;
            this.splitContainerControl2.TabIndex = 0;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // lblArticuloComentarios
            // 
            this.lblArticuloComentarios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblArticuloComentarios.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblArticuloComentarios.Appearance.Options.UseFont = true;
            this.lblArticuloComentarios.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblArticuloComentarios.Location = new System.Drawing.Point(2, 476);
            this.lblArticuloComentarios.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblArticuloComentarios.Name = "lblArticuloComentarios";
            this.lblArticuloComentarios.Size = new System.Drawing.Size(312, 21);
            this.lblArticuloComentarios.TabIndex = 43;
            this.lblArticuloComentarios.Text = "Comentarios";
            // 
            // pbLogo
            // 
            this.pbLogo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbLogo.Location = new System.Drawing.Point(2, 1);
            this.pbLogo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(312, 158);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 41;
            this.pbLogo.TabStop = false;
            // 
            // pbImagen
            // 
            this.pbImagen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbImagen.Location = new System.Drawing.Point(2, 168);
            this.pbImagen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbImagen.Name = "pbImagen";
            this.pbImagen.Size = new System.Drawing.Size(312, 300);
            this.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImagen.TabIndex = 40;
            this.pbImagen.TabStop = false;
            // 
            // btnAtras
            // 
            this.btnAtras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAtras.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAtras.ImageOptions.Image")));
            this.btnAtras.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnAtras.Location = new System.Drawing.Point(4, 78);
            this.btnAtras.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(86, 73);
            this.btnAtras.TabIndex = 7;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // lblDescuento
            // 
            this.lblDescuento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescuento.AutoEllipsis = true;
            this.lblDescuento.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblDescuento.ForeColor = System.Drawing.Color.Gray;
            this.lblDescuento.Location = new System.Drawing.Point(178, 29);
            this.lblDescuento.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDescuento.Size = new System.Drawing.Size(133, 32);
            this.lblDescuento.TabIndex = 4;
            this.lblDescuento.Text = "0.00";
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.AutoEllipsis = true;
            this.lblTotal.Font = new System.Drawing.Font("Tahoma", 22F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(99, 97);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTotal.Size = new System.Drawing.Size(215, 53);
            this.lblTotal.TabIndex = 3;
            this.lblTotal.Text = "0.00";
            // 
            // lblTotal_
            // 
            this.lblTotal_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal_.AutoSize = true;
            this.lblTotal_.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblTotal_.Location = new System.Drawing.Point(94, 72);
            this.lblTotal_.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotal_.Name = "lblTotal_";
            this.lblTotal_.Size = new System.Drawing.Size(53, 21);
            this.lblTotal_.TabIndex = 1;
            this.lblTotal_.Text = "Total";
            // 
            // lblDescuento_
            // 
            this.lblDescuento_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescuento_.AutoSize = true;
            this.lblDescuento_.ForeColor = System.Drawing.Color.Gray;
            this.lblDescuento_.Location = new System.Drawing.Point(94, 29);
            this.lblDescuento_.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescuento_.Name = "lblDescuento_";
            this.lblDescuento_.Size = new System.Drawing.Size(82, 19);
            this.lblDescuento_.TabIndex = 0;
            this.lblDescuento_.Text = "Descuento";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1383, 708);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.scPV;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1353, 678);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // frmPuntoVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1383, 875);
            this.ControlBox = false;
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frmPuntoVenta.IconOptions.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmPuntoVenta";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "Punto de venta";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPuntoVenta_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPuntoVenta_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmPuntoVenta_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbVendedores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scPV)).EndInit();
            this.scPV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbPersonasContacto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArticulo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigoSN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl3)).EndInit();
            this.splitContainerControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcPartidas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPartidas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbUnidadesMedida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTiposEmpaques)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAlmacenes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMonedas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageArchivo;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupArchivo;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SplitContainerControl scPV;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.LabelControl lblCodigoSN;
        private DevExpress.XtraEditors.TextEdit txtCodigoSN;
        private DevExpress.XtraEditors.LabelControl lblSocio;
        private DevExpress.XtraBars.BarStaticItem lblEstacion;
        private DevExpress.XtraBars.BarStaticItem lblUsuario;
        private DevExpress.XtraEditors.SeparatorControl separatorControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private System.Windows.Forms.PictureBox pbImagen;
        private System.Windows.Forms.Label lblTotal_;
        private System.Windows.Forms.Label lblDescuento_;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblDescuento;
        private DevExpress.XtraBars.BarStaticItem lblPartidas;
        private DevExpress.XtraBars.BarEditItem lblVendedor;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cbVendedores;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit2;
        private DevExpress.XtraBars.BarButtonItem bbiNuevo;
        private DevExpress.XtraBars.BarButtonItem bbiImprimir;
        private DevExpress.XtraBars.BarButtonItem bbiGuardar;
        private DevExpress.XtraBars.BarButtonItem lblArticulos;
        private DevExpress.XtraEditors.TextEdit txtArticulo;
        private DevExpress.XtraBars.BarStaticItem lblMoneda;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblDireccion;
        private DevExpress.XtraEditors.LabelControl lblCondicionPago;
        private System.Windows.Forms.CheckBox cbFactura;
        private System.Windows.Forms.CheckBox cbReserva;
        private System.Windows.Forms.Splitter splitter1;
        private DevExpress.XtraBars.BarStaticItem lblCantidadEmpaque;
        private DevExpress.XtraEditors.LookUpEdit cbPersonasContacto;
        private DevExpress.XtraEditors.LabelControl lblPersonasContacto;
        private DevExpress.XtraBars.BarButtonItem bbiCortesCaja;
        private DevExpress.XtraBars.BarButtonItem bbiArqueo;
        private DevExpress.XtraBars.BarButtonItem bbiPagos;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageHerramientas;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupHerramientas;
        private System.Windows.Forms.Label lblEstadoCredito;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl3;
        private DevExpress.XtraGrid.GridControl gcPartidas;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPartidas;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCantidad;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnUnidadMedida;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cbUnidadesMedida;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCantidadEmpaque;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTipoEmpaque;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cbTiposEmpaques;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSKU;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnArticulo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCodigoBarras;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnAlmacen;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cbAlmacenes;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPrecio;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPrecioNeto;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPorcentajeDescuento;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDescuento;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSubTotal;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTotal;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cbMonedas;
        private System.Windows.Forms.TableLayoutPanel tlp;
        private DevExpress.XtraEditors.SimpleButton btnAtras;
        private DevExpress.XtraEditors.LabelControl lblArticuloComentarios;
    }
}