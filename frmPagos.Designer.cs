namespace Nori
{
    partial class frmPagos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPagos));
            this.mainRibbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiGuardar = new DevExpress.XtraBars.BarButtonItem();
            this.bbiGuardarCerrar = new DevExpress.XtraBars.BarButtonItem();
            this.bbiGuardarNuevo = new DevExpress.XtraBars.BarButtonItem();
            this.bbiCancelar = new DevExpress.XtraBars.BarButtonItem();
            this.bbiBuscar = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPrimero = new DevExpress.XtraBars.BarButtonItem();
            this.bbiAnterior = new DevExpress.XtraBars.BarButtonItem();
            this.bbiUltimo = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSiguiente = new DevExpress.XtraBars.BarButtonItem();
            this.bbiNuevo = new DevExpress.XtraBars.BarButtonItem();
            this.bbiImprimir = new DevExpress.XtraBars.BarSubItem();
            this.bbiPDF = new DevExpress.XtraBars.BarSubItem();
            this.bbiPagosFinanciados = new DevExpress.XtraBars.BarButtonItem();
            this.bbiMapaRelaciones = new DevExpress.XtraBars.BarButtonItem();
            this.barHeaderItem1 = new DevExpress.XtraBars.BarHeaderItem();
            this.barHeaderItem2 = new DevExpress.XtraBars.BarHeaderItem();
            this.bbiEnviar = new DevExpress.XtraBars.BarButtonItem();
            this.mainRibbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mainRibbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.searchRibbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageHerramientas = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupHerramientas = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.popupMenuPagos = new DevExpress.XtraBars.PopupMenu(this.components);
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtNumeroDocumentoExterno = new DevExpress.XtraEditors.TextEdit();
            this.lblCancelado = new System.Windows.Forms.Label();
            this.txtTipoCambio = new DevExpress.XtraEditors.TextEdit();
            this.cbMonedas = new DevExpress.XtraEditors.LookUpEdit();
            this.lblMonedas = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.deFechaContabilizacion = new DevExpress.XtraEditors.DateEdit();
            this.lblImporteAplicado = new DevExpress.XtraEditors.LabelControl();
            this.txtImporteAplicado = new DevExpress.XtraEditors.TextEdit();
            this.lblSaldoPendiente = new DevExpress.XtraEditors.LabelControl();
            this.txtSaldoPendiente = new DevExpress.XtraEditors.TextEdit();
            this.lblSocio = new DevExpress.XtraEditors.LabelControl();
            this.lblIdentificadorExterno = new DevExpress.XtraEditors.LabelControl();
            this.lblReferencia = new DevExpress.XtraEditors.LabelControl();
            this.txtReferencia = new DevExpress.XtraEditors.TextEdit();
            this.lblTotal = new DevExpress.XtraEditors.LabelControl();
            this.txtTotal = new DevExpress.XtraEditors.TextEdit();
            this.txtComentario = new DevExpress.XtraEditors.MemoEdit();
            this.lblComentario = new DevExpress.XtraEditors.LabelControl();
            this.cbPagoACuenta = new DevExpress.XtraEditors.CheckEdit();
            this.cbSeries = new DevExpress.XtraEditors.LookUpEdit();
            this.lblNumeroDocumento = new DevExpress.XtraEditors.LabelControl();
            this.txtNumeroDocumento = new DevExpress.XtraEditors.TextEdit();
            this.txtFechaDocumento = new DevExpress.XtraEditors.TextEdit();
            this.txtFechaVencimiento = new DevExpress.XtraEditors.TextEdit();
            this.lblFechaDocumento = new DevExpress.XtraEditors.LabelControl();
            this.lblFechaVencimiento = new DevExpress.XtraEditors.LabelControl();
            this.lblFechaContabilizacion = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPageContenido = new DevExpress.XtraTab.XtraTabPage();
            this.gcPartidas = new DevExpress.XtraGrid.GridControl();
            this.gvPartidas = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnPartidaID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPagoID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDocumentoID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnNumeroDocumento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnTipoDocumento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnMetodoPagoSAT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnFechaVencimiento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnMoneda = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnMonedaID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnTipoCambio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnImporteAplicado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSaldo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnImporte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cbGenero = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.xtraTabPageMediosPago = new DevExpress.XtraTab.XtraTabPage();
            this.gcPagos = new DevExpress.XtraGrid.GridControl();
            this.gvPagos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnMetodoPago = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cbMetodosPago = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumnTC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnReferencia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtraTabPageDocumentoElectronico = new DevExpress.XtraTab.XtraTabPage();
            this.btnEstadoCFDI = new DevExpress.XtraEditors.SimpleButton();
            this.lblImportarFolioFiscal = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.cbMetodoPago = new DevExpress.XtraEditors.LookUpEdit();
            this.lblMetodosPago = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.btnActualizar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGenerar = new DevExpress.XtraEditors.SimpleButton();
            this.txtCadenaOriginal = new DevExpress.XtraEditors.MemoEdit();
            this.lblCadenaOriginal = new DevExpress.XtraEditors.LabelControl();
            this.lblFolioFiscal = new DevExpress.XtraEditors.LabelControl();
            this.txtFolioFiscal = new DevExpress.XtraEditors.TextEdit();
            this.lblCodigoSN = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.txtCodigoSN = new DevExpress.XtraEditors.TextEdit();
            this.lblID = new DevExpress.XtraEditors.LabelControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.bbiNuevoMetodoPago = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuPagos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroDocumentoExterno.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoCambio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMonedas.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaContabilizacion.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaContabilizacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImporteAplicado.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaldoPendiente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferencia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtComentario.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPagoACuenta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSeries.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroDocumento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaDocumento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaVencimiento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPageContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcPartidas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPartidas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbGenero)).BeginInit();
            this.xtraTabPageMediosPago.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcPagos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPagos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMetodosPago)).BeginInit();
            this.xtraTabPageDocumentoElectronico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbMetodoPago.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCadenaOriginal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFolioFiscal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigoSN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
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
            this.bbiCancelar,
            this.bbiBuscar,
            this.bbiPrimero,
            this.bbiAnterior,
            this.bbiUltimo,
            this.bbiSiguiente,
            this.bbiNuevo,
            this.bbiImprimir,
            this.bbiPDF,
            this.bbiPagosFinanciados,
            this.bbiMapaRelaciones,
            this.barHeaderItem1,
            this.barHeaderItem2,
            this.bbiEnviar,
            this.bbiNuevoMetodoPago});
            this.mainRibbonControl.Location = new System.Drawing.Point(0, 0);
            this.mainRibbonControl.MaxItemId = 2;
            this.mainRibbonControl.Name = "mainRibbonControl";
            this.mainRibbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.mainRibbonPage,
            this.ribbonPageHerramientas});
            this.mainRibbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.OfficeUniversal;
            this.mainRibbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.mainRibbonControl.Size = new System.Drawing.Size(790, 79);
            this.mainRibbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // bbiGuardar
            // 
            this.bbiGuardar.Caption = "Guardar";
            this.bbiGuardar.Id = 2;
            this.bbiGuardar.ImageUri.Uri = "Save";
            this.bbiGuardar.Name = "bbiGuardar";
            this.bbiGuardar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiGuardar_ItemClick);
            // 
            // bbiGuardarCerrar
            // 
            this.bbiGuardarCerrar.Caption = "Guardar y cerrar";
            this.bbiGuardarCerrar.Id = 3;
            this.bbiGuardarCerrar.ImageUri.Uri = "SaveAndClose";
            this.bbiGuardarCerrar.Name = "bbiGuardarCerrar";
            this.bbiGuardarCerrar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiGuardarCerrar_ItemClick);
            // 
            // bbiGuardarNuevo
            // 
            this.bbiGuardarNuevo.Caption = "Guardar y nuevo";
            this.bbiGuardarNuevo.Id = 4;
            this.bbiGuardarNuevo.ImageUri.Uri = "SaveAndNew";
            this.bbiGuardarNuevo.Name = "bbiGuardarNuevo";
            this.bbiGuardarNuevo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiGuardarNuevo_ItemClick);
            // 
            // bbiCancelar
            // 
            this.bbiCancelar.Caption = "Cancelar";
            this.bbiCancelar.Id = 6;
            this.bbiCancelar.ImageUri.Uri = "Cancel";
            this.bbiCancelar.Name = "bbiCancelar";
            this.bbiCancelar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiCancelar_ItemClick);
            // 
            // bbiBuscar
            // 
            this.bbiBuscar.Caption = "Buscar";
            this.bbiBuscar.Id = 4;
            this.bbiBuscar.ImageUri.Uri = "Find";
            this.bbiBuscar.Name = "bbiBuscar";
            this.bbiBuscar.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText;
            this.bbiBuscar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiBuscar_ItemClick);
            // 
            // bbiPrimero
            // 
            this.bbiPrimero.Caption = "Primero";
            this.bbiPrimero.Id = 5;
            this.bbiPrimero.ImageUri.Uri = "First";
            this.bbiPrimero.Name = "bbiPrimero";
            this.bbiPrimero.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText;
            this.bbiPrimero.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiPrimero_ItemClick);
            // 
            // bbiAnterior
            // 
            this.bbiAnterior.Caption = "Anterior";
            this.bbiAnterior.Id = 6;
            this.bbiAnterior.ImageUri.Uri = "Prev";
            this.bbiAnterior.Name = "bbiAnterior";
            this.bbiAnterior.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText;
            this.bbiAnterior.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiAnterior_ItemClick);
            // 
            // bbiUltimo
            // 
            this.bbiUltimo.Caption = "Último";
            this.bbiUltimo.Id = 7;
            this.bbiUltimo.ImageUri.Uri = "Last";
            this.bbiUltimo.Name = "bbiUltimo";
            this.bbiUltimo.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText;
            this.bbiUltimo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiUltimo_ItemClick);
            // 
            // bbiSiguiente
            // 
            this.bbiSiguiente.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.bbiSiguiente.Caption = "Siguiente";
            this.bbiSiguiente.Id = 8;
            this.bbiSiguiente.ImageUri.Uri = "Next";
            this.bbiSiguiente.Name = "bbiSiguiente";
            this.bbiSiguiente.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText;
            this.bbiSiguiente.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSiguiente_ItemClick);
            // 
            // bbiNuevo
            // 
            this.bbiNuevo.Caption = "Nuevo";
            this.bbiNuevo.Id = 1;
            this.bbiNuevo.ImageUri.Uri = "Add";
            this.bbiNuevo.Name = "bbiNuevo";
            this.bbiNuevo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiNuevo_ItemClick);
            // 
            // bbiImprimir
            // 
            this.bbiImprimir.Caption = "Imprimir";
            this.bbiImprimir.Id = 3;
            this.bbiImprimir.ImageUri.Uri = "Print";
            this.bbiImprimir.Name = "bbiImprimir";
            // 
            // bbiPDF
            // 
            this.bbiPDF.Caption = "PDF";
            this.bbiPDF.Id = 6;
            this.bbiPDF.ImageUri.Uri = "ExportToPDF";
            this.bbiPDF.Name = "bbiPDF";
            // 
            // bbiPagosFinanciados
            // 
            this.bbiPagosFinanciados.Caption = "Pagos financiados";
            this.bbiPagosFinanciados.Id = 7;
            this.bbiPagosFinanciados.ImageUri.Uri = "Currency";
            this.bbiPagosFinanciados.Name = "bbiPagosFinanciados";
            this.bbiPagosFinanciados.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiPagosFinanciados_ItemClick);
            // 
            // bbiMapaRelaciones
            // 
            this.bbiMapaRelaciones.Caption = "Mapa de relaciones";
            this.bbiMapaRelaciones.Id = 8;
            this.bbiMapaRelaciones.ImageUri.Uri = "BringToFront";
            this.bbiMapaRelaciones.Name = "bbiMapaRelaciones";
            this.bbiMapaRelaciones.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiMapaRelaciones_ItemClick);
            // 
            // barHeaderItem1
            // 
            this.barHeaderItem1.Caption = "Más";
            this.barHeaderItem1.Id = 9;
            this.barHeaderItem1.Name = "barHeaderItem1";
            // 
            // barHeaderItem2
            // 
            this.barHeaderItem2.Caption = "Acciones";
            this.barHeaderItem2.Id = 10;
            this.barHeaderItem2.Name = "barHeaderItem2";
            // 
            // bbiEnviar
            // 
            this.bbiEnviar.Caption = "Enviar";
            this.bbiEnviar.Id = 11;
            this.bbiEnviar.ImageUri.Uri = "Mail";
            this.bbiEnviar.Name = "bbiEnviar";
            this.bbiEnviar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiEnviar_ItemClick);
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
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiNuevo);
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiGuardar);
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiGuardarCerrar);
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiGuardarNuevo);
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiPDF);
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiImprimir);
            this.mainRibbonPageGroup.Name = "mainRibbonPageGroup";
            this.mainRibbonPageGroup.ShowCaptionButton = false;
            this.mainRibbonPageGroup.Text = "Opciones";
            // 
            // searchRibbonPageGroup
            // 
            this.searchRibbonPageGroup.AllowTextClipping = false;
            this.searchRibbonPageGroup.ItemLinks.Add(this.bbiBuscar);
            this.searchRibbonPageGroup.ItemLinks.Add(this.bbiPrimero);
            this.searchRibbonPageGroup.ItemLinks.Add(this.bbiAnterior);
            this.searchRibbonPageGroup.ItemLinks.Add(this.bbiSiguiente);
            this.searchRibbonPageGroup.ItemLinks.Add(this.bbiUltimo);
            this.searchRibbonPageGroup.Name = "searchRibbonPageGroup";
            this.searchRibbonPageGroup.ShowCaptionButton = false;
            this.searchRibbonPageGroup.Text = "Navegación";
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
            this.ribbonPageGroupHerramientas.ItemLinks.Add(this.bbiMapaRelaciones);
            this.ribbonPageGroupHerramientas.ItemLinks.Add(this.bbiPagosFinanciados);
            this.ribbonPageGroupHerramientas.Name = "ribbonPageGroupHerramientas";
            this.ribbonPageGroupHerramientas.Text = "Herramientas";
            // 
            // popupMenuPagos
            // 
            this.popupMenuPagos.ItemLinks.Add(this.barHeaderItem2);
            this.popupMenuPagos.ItemLinks.Add(this.bbiNuevoMetodoPago);
            this.popupMenuPagos.ItemLinks.Add(this.bbiEnviar);
            this.popupMenuPagos.ItemLinks.Add(this.barHeaderItem1);
            this.popupMenuPagos.ItemLinks.Add(this.bbiCancelar);
            this.popupMenuPagos.Name = "popupMenuPagos";
            this.popupMenuPagos.Ribbon = this.mainRibbonControl;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.panel1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 79);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(92, 301, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(790, 516);
            this.layoutControl1.TabIndex = 57;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtNumeroDocumentoExterno);
            this.panel1.Controls.Add(this.lblCancelado);
            this.panel1.Controls.Add(this.txtTipoCambio);
            this.panel1.Controls.Add(this.cbMonedas);
            this.panel1.Controls.Add(this.lblMonedas);
            this.panel1.Controls.Add(this.deFechaContabilizacion);
            this.panel1.Controls.Add(this.lblImporteAplicado);
            this.panel1.Controls.Add(this.txtImporteAplicado);
            this.panel1.Controls.Add(this.lblSaldoPendiente);
            this.panel1.Controls.Add(this.txtSaldoPendiente);
            this.panel1.Controls.Add(this.lblSocio);
            this.panel1.Controls.Add(this.lblIdentificadorExterno);
            this.panel1.Controls.Add(this.lblReferencia);
            this.panel1.Controls.Add(this.txtReferencia);
            this.panel1.Controls.Add(this.lblTotal);
            this.panel1.Controls.Add(this.txtTotal);
            this.panel1.Controls.Add(this.txtComentario);
            this.panel1.Controls.Add(this.lblComentario);
            this.panel1.Controls.Add(this.cbPagoACuenta);
            this.panel1.Controls.Add(this.cbSeries);
            this.panel1.Controls.Add(this.lblNumeroDocumento);
            this.panel1.Controls.Add(this.txtNumeroDocumento);
            this.panel1.Controls.Add(this.txtFechaDocumento);
            this.panel1.Controls.Add(this.txtFechaVencimiento);
            this.panel1.Controls.Add(this.lblFechaDocumento);
            this.panel1.Controls.Add(this.lblFechaVencimiento);
            this.panel1.Controls.Add(this.lblFechaContabilizacion);
            this.panel1.Controls.Add(this.xtraTabControl1);
            this.panel1.Controls.Add(this.lblCodigoSN);
            this.panel1.Controls.Add(this.txtCodigoSN);
            this.panel1.Controls.Add(this.lblID);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(766, 492);
            this.panel1.TabIndex = 4;
            // 
            // txtNumeroDocumentoExterno
            // 
            this.txtNumeroDocumentoExterno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNumeroDocumentoExterno.Location = new System.Drawing.Point(11, 441);
            this.txtNumeroDocumentoExterno.Name = "txtNumeroDocumentoExterno";
            this.txtNumeroDocumentoExterno.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtNumeroDocumentoExterno.Properties.Appearance.Options.UseBackColor = true;
            this.txtNumeroDocumentoExterno.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNumeroDocumentoExterno.Size = new System.Drawing.Size(80, 20);
            this.txtNumeroDocumentoExterno.TabIndex = 155;
            this.txtNumeroDocumentoExterno.TabStop = false;
            this.txtNumeroDocumentoExterno.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNumeroDocumentoExterno_KeyDown);
            // 
            // lblCancelado
            // 
            this.lblCancelado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCancelado.AutoSize = true;
            this.lblCancelado.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblCancelado.ForeColor = System.Drawing.Color.Firebrick;
            this.lblCancelado.Location = new System.Drawing.Point(463, 14);
            this.lblCancelado.Name = "lblCancelado";
            this.lblCancelado.Size = new System.Drawing.Size(65, 13);
            this.lblCancelado.TabIndex = 154;
            this.lblCancelado.Text = "Cancelado";
            this.lblCancelado.Visible = false;
            // 
            // txtTipoCambio
            // 
            this.txtTipoCambio.Location = new System.Drawing.Point(317, 85);
            this.txtTipoCambio.Name = "txtTipoCambio";
            this.txtTipoCambio.Size = new System.Drawing.Size(96, 20);
            this.txtTipoCambio.TabIndex = 150;
            this.txtTipoCambio.TabStop = false;
            // 
            // cbMonedas
            // 
            this.cbMonedas.Location = new System.Drawing.Point(113, 85);
            this.cbMonedas.MenuManager = this.mainRibbonControl;
            this.cbMonedas.Name = "cbMonedas";
            this.cbMonedas.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbMonedas.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("codigo", "Código"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nombre", "Nombre")});
            this.cbMonedas.Size = new System.Drawing.Size(198, 20);
            this.cbMonedas.TabIndex = 151;
            this.cbMonedas.TabStop = false;
            this.cbMonedas.EditValueChanged += new System.EventHandler(this.cbMonedas_EditValueChanged);
            // 
            // lblMonedas
            // 
            this.lblMonedas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMonedas.Location = new System.Drawing.Point(12, 86);
            this.lblMonedas.Name = "lblMonedas";
            this.lblMonedas.Size = new System.Drawing.Size(38, 13);
            this.lblMonedas.TabIndex = 152;
            this.lblMonedas.Text = "Moneda";
            this.lblMonedas.Click += new System.EventHandler(this.lblMonedas_Click);
            // 
            // deFechaContabilizacion
            // 
            this.deFechaContabilizacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deFechaContabilizacion.EditValue = null;
            this.deFechaContabilizacion.Location = new System.Drawing.Point(652, 37);
            this.deFechaContabilizacion.MenuManager = this.mainRibbonControl;
            this.deFechaContabilizacion.Name = "deFechaContabilizacion";
            this.deFechaContabilizacion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaContabilizacion.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaContabilizacion.Size = new System.Drawing.Size(106, 20);
            this.deFechaContabilizacion.TabIndex = 149;
            this.deFechaContabilizacion.EditValueChanged += new System.EventHandler(this.deFechaContabilizacion_EditValueChanged);
            // 
            // lblImporteAplicado
            // 
            this.lblImporteAplicado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblImporteAplicado.Location = new System.Drawing.Point(520, 411);
            this.lblImporteAplicado.Name = "lblImporteAplicado";
            this.lblImporteAplicado.Size = new System.Drawing.Size(80, 13);
            this.lblImporteAplicado.TabIndex = 148;
            this.lblImporteAplicado.Text = "Importe aplicado";
            // 
            // txtImporteAplicado
            // 
            this.txtImporteAplicado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImporteAplicado.Location = new System.Drawing.Point(623, 408);
            this.txtImporteAplicado.MenuManager = this.mainRibbonControl;
            this.txtImporteAplicado.Name = "txtImporteAplicado";
            this.txtImporteAplicado.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtImporteAplicado.Properties.DisplayFormat.FormatString = "c2";
            this.txtImporteAplicado.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtImporteAplicado.Properties.EditFormat.FormatString = "c2";
            this.txtImporteAplicado.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtImporteAplicado.Properties.ReadOnly = true;
            this.txtImporteAplicado.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtImporteAplicado.Size = new System.Drawing.Size(135, 20);
            this.txtImporteAplicado.TabIndex = 147;
            this.txtImporteAplicado.TabStop = false;
            // 
            // lblSaldoPendiente
            // 
            this.lblSaldoPendiente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSaldoPendiente.Location = new System.Drawing.Point(520, 437);
            this.lblSaldoPendiente.Name = "lblSaldoPendiente";
            this.lblSaldoPendiente.Size = new System.Drawing.Size(77, 13);
            this.lblSaldoPendiente.TabIndex = 146;
            this.lblSaldoPendiente.Text = "Saldo pendiente";
            // 
            // txtSaldoPendiente
            // 
            this.txtSaldoPendiente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSaldoPendiente.Location = new System.Drawing.Point(623, 434);
            this.txtSaldoPendiente.MenuManager = this.mainRibbonControl;
            this.txtSaldoPendiente.Name = "txtSaldoPendiente";
            this.txtSaldoPendiente.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtSaldoPendiente.Properties.DisplayFormat.FormatString = "c2";
            this.txtSaldoPendiente.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtSaldoPendiente.Properties.EditFormat.FormatString = "c2";
            this.txtSaldoPendiente.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtSaldoPendiente.Properties.ReadOnly = true;
            this.txtSaldoPendiente.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSaldoPendiente.Size = new System.Drawing.Size(135, 20);
            this.txtSaldoPendiente.TabIndex = 145;
            this.txtSaldoPendiente.TabStop = false;
            // 
            // lblSocio
            // 
            this.lblSocio.Location = new System.Drawing.Point(12, 40);
            this.lblSocio.Name = "lblSocio";
            this.lblSocio.Size = new System.Drawing.Size(25, 13);
            this.lblSocio.TabIndex = 141;
            this.lblSocio.Text = "Socio";
            // 
            // lblIdentificadorExterno
            // 
            this.lblIdentificadorExterno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblIdentificadorExterno.Location = new System.Drawing.Point(12, 467);
            this.lblIdentificadorExterno.Name = "lblIdentificadorExterno";
            this.lblIdentificadorExterno.Size = new System.Drawing.Size(6, 13);
            this.lblIdentificadorExterno.TabIndex = 140;
            this.lblIdentificadorExterno.Text = "0";
            // 
            // lblReferencia
            // 
            this.lblReferencia.Location = new System.Drawing.Point(12, 62);
            this.lblReferencia.Name = "lblReferencia";
            this.lblReferencia.Size = new System.Drawing.Size(52, 13);
            this.lblReferencia.TabIndex = 139;
            this.lblReferencia.Text = "Referencia";
            // 
            // txtReferencia
            // 
            this.txtReferencia.Location = new System.Drawing.Point(112, 59);
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Properties.MaxLength = 18;
            this.txtReferencia.Size = new System.Drawing.Size(199, 20);
            this.txtReferencia.TabIndex = 138;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.Location = new System.Drawing.Point(520, 463);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(24, 13);
            this.lblTotal.TabIndex = 136;
            this.lblTotal.Text = "Total";
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotal.Location = new System.Drawing.Point(623, 460);
            this.txtTotal.MenuManager = this.mainRibbonControl;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtTotal.Properties.DisplayFormat.FormatString = "c2";
            this.txtTotal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotal.Properties.EditFormat.FormatString = "c2";
            this.txtTotal.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotal.Properties.ReadOnly = true;
            this.txtTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotal.Size = new System.Drawing.Size(135, 20);
            this.txtTotal.TabIndex = 135;
            this.txtTotal.TabStop = false;
            // 
            // txtComentario
            // 
            this.txtComentario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtComentario.Location = new System.Drawing.Point(112, 384);
            this.txtComentario.MenuManager = this.mainRibbonControl;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(198, 96);
            this.txtComentario.TabIndex = 132;
            this.txtComentario.TabStop = false;
            // 
            // lblComentario
            // 
            this.lblComentario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblComentario.Location = new System.Drawing.Point(11, 386);
            this.lblComentario.Name = "lblComentario";
            this.lblComentario.Size = new System.Drawing.Size(55, 13);
            this.lblComentario.TabIndex = 133;
            this.lblComentario.Text = "Comentario";
            // 
            // cbPagoACuenta
            // 
            this.cbPagoACuenta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPagoACuenta.Enabled = false;
            this.cbPagoACuenta.Location = new System.Drawing.Point(623, 383);
            this.cbPagoACuenta.MenuManager = this.mainRibbonControl;
            this.cbPagoACuenta.Name = "cbPagoACuenta";
            this.cbPagoACuenta.Properties.Caption = "Pago a cuenta";
            this.cbPagoACuenta.Size = new System.Drawing.Size(103, 19);
            this.cbPagoACuenta.TabIndex = 131;
            // 
            // cbSeries
            // 
            this.cbSeries.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSeries.Location = new System.Drawing.Point(568, 11);
            this.cbSeries.MenuManager = this.mainRibbonControl;
            this.cbSeries.Name = "cbSeries";
            this.cbSeries.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbSeries.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nombre", "Nombre")});
            this.cbSeries.Size = new System.Drawing.Size(78, 20);
            this.cbSeries.TabIndex = 122;
            this.cbSeries.TabStop = false;
            // 
            // lblNumeroDocumento
            // 
            this.lblNumeroDocumento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNumeroDocumento.Location = new System.Drawing.Point(545, 14);
            this.lblNumeroDocumento.Name = "lblNumeroDocumento";
            this.lblNumeroDocumento.Size = new System.Drawing.Size(12, 13);
            this.lblNumeroDocumento.TabIndex = 130;
            this.lblNumeroDocumento.Text = "N°";
            // 
            // txtNumeroDocumento
            // 
            this.txtNumeroDocumento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumeroDocumento.Location = new System.Drawing.Point(652, 11);
            this.txtNumeroDocumento.Name = "txtNumeroDocumento";
            this.txtNumeroDocumento.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNumeroDocumento.Size = new System.Drawing.Size(106, 20);
            this.txtNumeroDocumento.TabIndex = 123;
            this.txtNumeroDocumento.TabStop = false;
            this.txtNumeroDocumento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNumeroDocumento_KeyDown);
            // 
            // txtFechaDocumento
            // 
            this.txtFechaDocumento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFechaDocumento.Location = new System.Drawing.Point(652, 89);
            this.txtFechaDocumento.Name = "txtFechaDocumento";
            this.txtFechaDocumento.Properties.DisplayFormat.FormatString = "d";
            this.txtFechaDocumento.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.txtFechaDocumento.Properties.EditFormat.FormatString = "d";
            this.txtFechaDocumento.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.txtFechaDocumento.Properties.ReadOnly = true;
            this.txtFechaDocumento.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFechaDocumento.Size = new System.Drawing.Size(106, 20);
            this.txtFechaDocumento.TabIndex = 129;
            this.txtFechaDocumento.TabStop = false;
            // 
            // txtFechaVencimiento
            // 
            this.txtFechaVencimiento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFechaVencimiento.Location = new System.Drawing.Point(652, 63);
            this.txtFechaVencimiento.Name = "txtFechaVencimiento";
            this.txtFechaVencimiento.Properties.DisplayFormat.FormatString = "d";
            this.txtFechaVencimiento.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.txtFechaVencimiento.Properties.EditFormat.FormatString = "d";
            this.txtFechaVencimiento.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.txtFechaVencimiento.Properties.ReadOnly = true;
            this.txtFechaVencimiento.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFechaVencimiento.Size = new System.Drawing.Size(106, 20);
            this.txtFechaVencimiento.TabIndex = 128;
            this.txtFechaVencimiento.TabStop = false;
            // 
            // lblFechaDocumento
            // 
            this.lblFechaDocumento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFechaDocumento.Location = new System.Drawing.Point(561, 92);
            this.lblFechaDocumento.Name = "lblFechaDocumento";
            this.lblFechaDocumento.Size = new System.Drawing.Size(85, 13);
            this.lblFechaDocumento.TabIndex = 126;
            this.lblFechaDocumento.Text = "Fecha documento";
            // 
            // lblFechaVencimiento
            // 
            this.lblFechaVencimiento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFechaVencimiento.Location = new System.Drawing.Point(557, 66);
            this.lblFechaVencimiento.Name = "lblFechaVencimiento";
            this.lblFechaVencimiento.Size = new System.Drawing.Size(89, 13);
            this.lblFechaVencimiento.TabIndex = 125;
            this.lblFechaVencimiento.Text = "Fecha vencimiento";
            // 
            // lblFechaContabilizacion
            // 
            this.lblFechaContabilizacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFechaContabilizacion.Location = new System.Drawing.Point(545, 40);
            this.lblFechaContabilizacion.Name = "lblFechaContabilizacion";
            this.lblFechaContabilizacion.Size = new System.Drawing.Size(101, 13);
            this.lblFechaContabilizacion.TabIndex = 124;
            this.lblFechaContabilizacion.Text = "Fecha contabilización";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xtraTabControl1.Location = new System.Drawing.Point(3, 111);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPageContenido;
            this.xtraTabControl1.Size = new System.Drawing.Size(760, 264);
            this.xtraTabControl1.TabIndex = 121;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageContenido,
            this.xtraTabPageMediosPago,
            this.xtraTabPageDocumentoElectronico});
            // 
            // xtraTabPageContenido
            // 
            this.xtraTabPageContenido.Controls.Add(this.gcPartidas);
            this.xtraTabPageContenido.Name = "xtraTabPageContenido";
            this.xtraTabPageContenido.Size = new System.Drawing.Size(754, 236);
            this.xtraTabPageContenido.Text = "Contenido";
            // 
            // gcPartidas
            // 
            this.gcPartidas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcPartidas.Location = new System.Drawing.Point(0, 0);
            this.gcPartidas.MainView = this.gvPartidas;
            this.gcPartidas.Name = "gcPartidas";
            this.gcPartidas.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cbGenero});
            this.gcPartidas.Size = new System.Drawing.Size(754, 236);
            this.gcPartidas.TabIndex = 70;
            this.gcPartidas.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPartidas});
            // 
            // gvPartidas
            // 
            this.gvPartidas.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gvPartidas.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnPartidaID,
            this.gridColumnPagoID,
            this.gridColumnDocumentoID,
            this.gridColumnNumeroDocumento,
            this.gridColumnTipoDocumento,
            this.gridColumnMetodoPagoSAT,
            this.gridColumnFecha,
            this.gridColumnFechaVencimiento,
            this.gridColumnMoneda,
            this.gridColumnMonedaID,
            this.gridColumnTipoCambio,
            this.gridColumnTotal,
            this.gridColumnImporteAplicado,
            this.gridColumnSaldo,
            this.gridColumnImporte});
            this.gvPartidas.GridControl = this.gcPartidas;
            this.gvPartidas.Name = "gvPartidas";
            this.gvPartidas.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gvPartidas.OptionsNavigation.AutoFocusNewRow = true;
            this.gvPartidas.OptionsSelection.MultiSelect = true;
            this.gvPartidas.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gvPartidas.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gvPartidas_RowStyle);
            this.gvPartidas.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gvPartidas_SelectionChanged);
            this.gvPartidas.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvPartidas_CellValueChanged);
            // 
            // gridColumnPartidaID
            // 
            this.gridColumnPartidaID.Caption = "Partida ID";
            this.gridColumnPartidaID.FieldName = "id";
            this.gridColumnPartidaID.Name = "gridColumnPartidaID";
            // 
            // gridColumnPagoID
            // 
            this.gridColumnPagoID.Caption = "PagoID";
            this.gridColumnPagoID.FieldName = "pago_id";
            this.gridColumnPagoID.Name = "gridColumnPagoID";
            // 
            // gridColumnDocumentoID
            // 
            this.gridColumnDocumentoID.Caption = "ID";
            this.gridColumnDocumentoID.FieldName = "documento_id";
            this.gridColumnDocumentoID.Name = "gridColumnDocumentoID";
            this.gridColumnDocumentoID.OptionsColumn.AllowEdit = false;
            this.gridColumnDocumentoID.Visible = true;
            this.gridColumnDocumentoID.VisibleIndex = 1;
            this.gridColumnDocumentoID.Width = 54;
            // 
            // gridColumnNumeroDocumento
            // 
            this.gridColumnNumeroDocumento.Caption = "N° documento";
            this.gridColumnNumeroDocumento.FieldName = "numero_documento";
            this.gridColumnNumeroDocumento.Name = "gridColumnNumeroDocumento";
            this.gridColumnNumeroDocumento.OptionsColumn.AllowEdit = false;
            this.gridColumnNumeroDocumento.Visible = true;
            this.gridColumnNumeroDocumento.VisibleIndex = 2;
            this.gridColumnNumeroDocumento.Width = 54;
            // 
            // gridColumnTipoDocumento
            // 
            this.gridColumnTipoDocumento.Caption = "Tipo";
            this.gridColumnTipoDocumento.FieldName = "clase";
            this.gridColumnTipoDocumento.MaxWidth = 40;
            this.gridColumnTipoDocumento.Name = "gridColumnTipoDocumento";
            this.gridColumnTipoDocumento.OptionsColumn.AllowEdit = false;
            this.gridColumnTipoDocumento.Visible = true;
            this.gridColumnTipoDocumento.VisibleIndex = 3;
            this.gridColumnTipoDocumento.Width = 40;
            // 
            // gridColumnMetodoPagoSAT
            // 
            this.gridColumnMetodoPagoSAT.Caption = "Método pago";
            this.gridColumnMetodoPagoSAT.FieldName = "metodo_pago";
            this.gridColumnMetodoPagoSAT.MaxWidth = 40;
            this.gridColumnMetodoPagoSAT.Name = "gridColumnMetodoPagoSAT";
            this.gridColumnMetodoPagoSAT.OptionsColumn.AllowEdit = false;
            this.gridColumnMetodoPagoSAT.Visible = true;
            this.gridColumnMetodoPagoSAT.VisibleIndex = 4;
            this.gridColumnMetodoPagoSAT.Width = 40;
            // 
            // gridColumnFecha
            // 
            this.gridColumnFecha.Caption = "Fecha";
            this.gridColumnFecha.FieldName = "fecha_documento";
            this.gridColumnFecha.Name = "gridColumnFecha";
            this.gridColumnFecha.OptionsColumn.AllowEdit = false;
            this.gridColumnFecha.Visible = true;
            this.gridColumnFecha.VisibleIndex = 5;
            this.gridColumnFecha.Width = 55;
            // 
            // gridColumnFechaVencimiento
            // 
            this.gridColumnFechaVencimiento.Caption = "Vencimiento";
            this.gridColumnFechaVencimiento.FieldName = "fecha_vencimiento";
            this.gridColumnFechaVencimiento.Name = "gridColumnFechaVencimiento";
            this.gridColumnFechaVencimiento.OptionsColumn.AllowEdit = false;
            this.gridColumnFechaVencimiento.Visible = true;
            this.gridColumnFechaVencimiento.VisibleIndex = 6;
            this.gridColumnFechaVencimiento.Width = 55;
            // 
            // gridColumnMoneda
            // 
            this.gridColumnMoneda.Caption = "Moneda";
            this.gridColumnMoneda.FieldName = "moneda";
            this.gridColumnMoneda.Name = "gridColumnMoneda";
            this.gridColumnMoneda.OptionsColumn.AllowEdit = false;
            this.gridColumnMoneda.Visible = true;
            this.gridColumnMoneda.VisibleIndex = 7;
            this.gridColumnMoneda.Width = 55;
            // 
            // gridColumnMonedaID
            // 
            this.gridColumnMonedaID.Caption = "Moneda ID";
            this.gridColumnMonedaID.FieldName = "moneda_id";
            this.gridColumnMonedaID.Name = "gridColumnMonedaID";
            // 
            // gridColumnTipoCambio
            // 
            this.gridColumnTipoCambio.Caption = "TC";
            this.gridColumnTipoCambio.FieldName = "tipo_cambio";
            this.gridColumnTipoCambio.Name = "gridColumnTipoCambio";
            this.gridColumnTipoCambio.Visible = true;
            this.gridColumnTipoCambio.VisibleIndex = 8;
            this.gridColumnTipoCambio.Width = 55;
            // 
            // gridColumnTotal
            // 
            this.gridColumnTotal.Caption = "Total";
            this.gridColumnTotal.DisplayFormat.FormatString = "c2";
            this.gridColumnTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnTotal.FieldName = "total";
            this.gridColumnTotal.Name = "gridColumnTotal";
            this.gridColumnTotal.OptionsColumn.AllowEdit = false;
            this.gridColumnTotal.Visible = true;
            this.gridColumnTotal.VisibleIndex = 9;
            this.gridColumnTotal.Width = 55;
            // 
            // gridColumnImporteAplicado
            // 
            this.gridColumnImporteAplicado.Caption = "Importe aplicado";
            this.gridColumnImporteAplicado.DisplayFormat.FormatString = "c2";
            this.gridColumnImporteAplicado.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnImporteAplicado.FieldName = "importe_aplicado";
            this.gridColumnImporteAplicado.Name = "gridColumnImporteAplicado";
            this.gridColumnImporteAplicado.OptionsColumn.AllowEdit = false;
            this.gridColumnImporteAplicado.Visible = true;
            this.gridColumnImporteAplicado.VisibleIndex = 10;
            this.gridColumnImporteAplicado.Width = 55;
            // 
            // gridColumnSaldo
            // 
            this.gridColumnSaldo.Caption = "Saldo";
            this.gridColumnSaldo.DisplayFormat.FormatString = "c2";
            this.gridColumnSaldo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnSaldo.FieldName = "saldo";
            this.gridColumnSaldo.Name = "gridColumnSaldo";
            this.gridColumnSaldo.OptionsColumn.AllowEdit = false;
            this.gridColumnSaldo.Visible = true;
            this.gridColumnSaldo.VisibleIndex = 11;
            this.gridColumnSaldo.Width = 51;
            // 
            // gridColumnImporte
            // 
            this.gridColumnImporte.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.gridColumnImporte.AppearanceCell.BackColor2 = System.Drawing.Color.Moccasin;
            this.gridColumnImporte.AppearanceCell.Options.UseBackColor = true;
            this.gridColumnImporte.Caption = "Importe a pagar";
            this.gridColumnImporte.DisplayFormat.FormatString = "c2";
            this.gridColumnImporte.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnImporte.FieldName = "importe";
            this.gridColumnImporte.MaxWidth = 80;
            this.gridColumnImporte.MinWidth = 80;
            this.gridColumnImporte.Name = "gridColumnImporte";
            this.gridColumnImporte.Visible = true;
            this.gridColumnImporte.VisibleIndex = 12;
            this.gridColumnImporte.Width = 80;
            // 
            // cbGenero
            // 
            this.cbGenero.AutoHeight = false;
            this.cbGenero.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbGenero.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("genero", "Genero"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nombre", "Nombre")});
            this.cbGenero.Name = "cbGenero";
            // 
            // xtraTabPageMediosPago
            // 
            this.xtraTabPageMediosPago.Controls.Add(this.gcPagos);
            this.xtraTabPageMediosPago.Name = "xtraTabPageMediosPago";
            this.xtraTabPageMediosPago.Size = new System.Drawing.Size(754, 236);
            this.xtraTabPageMediosPago.Text = "Medios de pago";
            // 
            // gcPagos
            // 
            this.gcPagos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcPagos.Location = new System.Drawing.Point(0, 0);
            this.gcPagos.MainView = this.gvPagos;
            this.gcPagos.Name = "gcPagos";
            this.gcPagos.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cbMetodosPago});
            this.gcPagos.Size = new System.Drawing.Size(754, 236);
            this.gcPagos.TabIndex = 2;
            this.gcPagos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPagos});
            // 
            // gvPagos
            // 
            this.gvPagos.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnID,
            this.gridColumnMetodoPago,
            this.gridColumnTC,
            this.gridColumnReferencia,
            this.gridColumn1,
            this.gridColumn2});
            this.gvPagos.GridControl = this.gcPagos;
            this.gvPagos.Name = "gvPagos";
            this.gvPagos.OptionsCustomization.AllowColumnMoving = false;
            this.gvPagos.OptionsCustomization.AllowFilter = false;
            this.gvPagos.OptionsCustomization.AllowSort = false;
            this.gvPagos.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gvPagos.OptionsView.ShowGroupPanel = false;
            this.gvPagos.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvPagos_CellValueChanged);
            this.gvPagos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvPagos_KeyDown);
            // 
            // gridColumnID
            // 
            this.gridColumnID.Caption = "ID";
            this.gridColumnID.FieldName = "id";
            this.gridColumnID.Name = "gridColumnID";
            // 
            // gridColumnMetodoPago
            // 
            this.gridColumnMetodoPago.Caption = "Método de pago";
            this.gridColumnMetodoPago.ColumnEdit = this.cbMetodosPago;
            this.gridColumnMetodoPago.FieldName = "tipo_metodo_pago_id";
            this.gridColumnMetodoPago.MaxWidth = 120;
            this.gridColumnMetodoPago.Name = "gridColumnMetodoPago";
            this.gridColumnMetodoPago.Visible = true;
            this.gridColumnMetodoPago.VisibleIndex = 0;
            this.gridColumnMetodoPago.Width = 120;
            // 
            // cbMetodosPago
            // 
            this.cbMetodosPago.AutoHeight = false;
            this.cbMetodosPago.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbMetodosPago.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nombre", 60, "Nombre")});
            this.cbMetodosPago.Name = "cbMetodosPago";
            // 
            // gridColumnTC
            // 
            this.gridColumnTC.Caption = "TC";
            this.gridColumnTC.FieldName = "tipo_cambio";
            this.gridColumnTC.MaxWidth = 50;
            this.gridColumnTC.Name = "gridColumnTC";
            this.gridColumnTC.Visible = true;
            this.gridColumnTC.VisibleIndex = 1;
            this.gridColumnTC.Width = 47;
            // 
            // gridColumnReferencia
            // 
            this.gridColumnReferencia.Caption = "Referencia";
            this.gridColumnReferencia.FieldName = "referencia";
            this.gridColumnReferencia.Name = "gridColumnReferencia";
            this.gridColumnReferencia.Visible = true;
            this.gridColumnReferencia.VisibleIndex = 2;
            this.gridColumnReferencia.Width = 100;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Importe";
            this.gridColumn1.DisplayFormat.FormatString = "C";
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn1.FieldName = "importe";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 3;
            this.gridColumn1.Width = 100;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Total";
            this.gridColumn2.DisplayFormat.FormatString = "C";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn2.FieldName = "gridColumnTotal";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.UnboundExpression = "tipo_cambio * importe";
            this.gridColumn2.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 4;
            this.gridColumn2.Width = 111;
            // 
            // xtraTabPageDocumentoElectronico
            // 
            this.xtraTabPageDocumentoElectronico.Controls.Add(this.btnEstadoCFDI);
            this.xtraTabPageDocumentoElectronico.Controls.Add(this.lblImportarFolioFiscal);
            this.xtraTabPageDocumentoElectronico.Controls.Add(this.btnCancelar);
            this.xtraTabPageDocumentoElectronico.Controls.Add(this.cbMetodoPago);
            this.xtraTabPageDocumentoElectronico.Controls.Add(this.lblMetodosPago);
            this.xtraTabPageDocumentoElectronico.Controls.Add(this.btnActualizar);
            this.xtraTabPageDocumentoElectronico.Controls.Add(this.btnGenerar);
            this.xtraTabPageDocumentoElectronico.Controls.Add(this.txtCadenaOriginal);
            this.xtraTabPageDocumentoElectronico.Controls.Add(this.lblCadenaOriginal);
            this.xtraTabPageDocumentoElectronico.Controls.Add(this.lblFolioFiscal);
            this.xtraTabPageDocumentoElectronico.Controls.Add(this.txtFolioFiscal);
            this.xtraTabPageDocumentoElectronico.Name = "xtraTabPageDocumentoElectronico";
            this.xtraTabPageDocumentoElectronico.Size = new System.Drawing.Size(754, 236);
            this.xtraTabPageDocumentoElectronico.Text = "Documento electrónico";
            // 
            // btnEstadoCFDI
            // 
            this.btnEstadoCFDI.Image = ((System.Drawing.Image)(resources.GetObject("btnEstadoCFDI.Image")));
            this.btnEstadoCFDI.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnEstadoCFDI.Location = new System.Drawing.Point(165, 201);
            this.btnEstadoCFDI.Name = "btnEstadoCFDI";
            this.btnEstadoCFDI.Size = new System.Drawing.Size(37, 23);
            this.btnEstadoCFDI.TabIndex = 110;
            this.btnEstadoCFDI.TabStop = false;
            // 
            // lblImportarFolioFiscal
            // 
            this.lblImportarFolioFiscal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblImportarFolioFiscal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblImportarFolioFiscal.Location = new System.Drawing.Point(657, 211);
            this.lblImportarFolioFiscal.Name = "lblImportarFolioFiscal";
            this.lblImportarFolioFiscal.Size = new System.Drawing.Size(92, 13);
            this.lblImportarFolioFiscal.TabIndex = 109;
            this.lblImportarFolioFiscal.Text = "Importar folio fiscal";
            this.lblImportarFolioFiscal.Click += new System.EventHandler(this.lblImportarFolioFiscal_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btnCancelar.Location = new System.Drawing.Point(353, 201);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(108, 23);
            this.btnCancelar.TabIndex = 108;
            this.btnCancelar.TabStop = false;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cbMetodoPago
            // 
            this.cbMetodoPago.Location = new System.Drawing.Point(108, 8);
            this.cbMetodoPago.MenuManager = this.mainRibbonControl;
            this.cbMetodoPago.Name = "cbMetodoPago";
            this.cbMetodoPago.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbMetodoPago.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("codigo", "Código"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nombre", "Nombre")});
            this.cbMetodoPago.Size = new System.Drawing.Size(353, 20);
            this.cbMetodoPago.TabIndex = 105;
            // 
            // lblMetodosPago
            // 
            this.lblMetodosPago.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMetodosPago.Location = new System.Drawing.Point(6, 11);
            this.lblMetodosPago.Name = "lblMetodosPago";
            this.lblMetodosPago.Size = new System.Drawing.Size(78, 13);
            this.lblMetodosPago.TabIndex = 106;
            this.lblMetodosPago.Text = "Método de pago";
            // 
            // btnActualizar
            // 
            this.btnActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.Image")));
            this.btnActualizar.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btnActualizar.Location = new System.Drawing.Point(122, 201);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(37, 23);
            this.btnActualizar.TabIndex = 103;
            this.btnActualizar.TabStop = false;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Image = ((System.Drawing.Image)(resources.GetObject("btnGenerar.Image")));
            this.btnGenerar.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btnGenerar.Location = new System.Drawing.Point(8, 201);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(108, 23);
            this.btnGenerar.TabIndex = 104;
            this.btnGenerar.TabStop = false;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // txtCadenaOriginal
            // 
            this.txtCadenaOriginal.Enabled = false;
            this.txtCadenaOriginal.Location = new System.Drawing.Point(8, 82);
            this.txtCadenaOriginal.MenuManager = this.mainRibbonControl;
            this.txtCadenaOriginal.Name = "txtCadenaOriginal";
            this.txtCadenaOriginal.Size = new System.Drawing.Size(453, 113);
            this.txtCadenaOriginal.TabIndex = 99;
            // 
            // lblCadenaOriginal
            // 
            this.lblCadenaOriginal.Location = new System.Drawing.Point(8, 63);
            this.lblCadenaOriginal.Name = "lblCadenaOriginal";
            this.lblCadenaOriginal.Size = new System.Drawing.Size(74, 13);
            this.lblCadenaOriginal.TabIndex = 101;
            this.lblCadenaOriginal.Text = "Cadena original";
            // 
            // lblFolioFiscal
            // 
            this.lblFolioFiscal.Location = new System.Drawing.Point(8, 37);
            this.lblFolioFiscal.Name = "lblFolioFiscal";
            this.lblFolioFiscal.Size = new System.Drawing.Size(49, 13);
            this.lblFolioFiscal.TabIndex = 100;
            this.lblFolioFiscal.Text = "Folio fiscal";
            // 
            // txtFolioFiscal
            // 
            this.txtFolioFiscal.Location = new System.Drawing.Point(108, 34);
            this.txtFolioFiscal.Name = "txtFolioFiscal";
            this.txtFolioFiscal.Properties.ReadOnly = true;
            this.txtFolioFiscal.Size = new System.Drawing.Size(353, 20);
            this.txtFolioFiscal.TabIndex = 98;
            // 
            // lblCodigoSN
            // 
            this.lblCodigoSN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCodigoSN.Location = new System.Drawing.Point(12, 14);
            this.lblCodigoSN.Name = "lblCodigoSN";
            this.lblCodigoSN.Size = new System.Drawing.Size(49, 13);
            this.lblCodigoSN.TabIndex = 120;
            this.lblCodigoSN.Text = "Código SN";
            this.lblCodigoSN.Click += new System.EventHandler(this.lblCodigoSN_Click);
            // 
            // txtCodigoSN
            // 
            this.txtCodigoSN.Location = new System.Drawing.Point(112, 11);
            this.txtCodigoSN.Name = "txtCodigoSN";
            this.txtCodigoSN.Size = new System.Drawing.Size(84, 20);
            this.txtCodigoSN.TabIndex = 119;
            this.txtCodigoSN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoSN_KeyDown);
            this.txtCodigoSN.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtCodigoSN_PreviewKeyDown);
            // 
            // lblID
            // 
            this.lblID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblID.Location = new System.Drawing.Point(202, 14);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(6, 13);
            this.lblID.TabIndex = 48;
            this.lblID.Text = "0";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(790, 516);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.panel1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(770, 496);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // bbiNuevoMetodoPago
            // 
            this.bbiNuevoMetodoPago.Caption = "Nuevo método de pago";
            this.bbiNuevoMetodoPago.Id = 1;
            this.bbiNuevoMetodoPago.ImageUri.Uri = "AddNewDataSource";
            this.bbiNuevoMetodoPago.Name = "bbiNuevoMetodoPago";
            this.bbiNuevoMetodoPago.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiNuevoMetodoPago_ItemClick);
            // 
            // frmPagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 595);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.mainRibbonControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPagos";
            this.mainRibbonControl.SetPopupContextMenu(this, this.popupMenuPagos);
            this.Ribbon = this.mainRibbonControl;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pagos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuPagos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroDocumentoExterno.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoCambio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMonedas.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaContabilizacion.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaContabilizacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImporteAplicado.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaldoPendiente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferencia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtComentario.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPagoACuenta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSeries.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroDocumento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaDocumento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaVencimiento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPageContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcPartidas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPartidas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbGenero)).EndInit();
            this.xtraTabPageMediosPago.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcPagos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPagos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMetodosPago)).EndInit();
            this.xtraTabPageDocumentoElectronico.ResumeLayout(false);
            this.xtraTabPageDocumentoElectronico.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbMetodoPago.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCadenaOriginal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFolioFiscal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigoSN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonControl mainRibbonControl;
        private DevExpress.XtraBars.BarButtonItem bbiGuardar;
        private DevExpress.XtraBars.BarButtonItem bbiGuardarCerrar;
        private DevExpress.XtraBars.BarButtonItem bbiGuardarNuevo;
        private DevExpress.XtraBars.BarButtonItem bbiCancelar;
        private DevExpress.XtraBars.BarButtonItem bbiBuscar;
        private DevExpress.XtraBars.BarButtonItem bbiPrimero;
        private DevExpress.XtraBars.BarButtonItem bbiAnterior;
        private DevExpress.XtraBars.BarButtonItem bbiUltimo;
        private DevExpress.XtraBars.BarButtonItem bbiSiguiente;
        private DevExpress.XtraBars.BarButtonItem bbiNuevo;
        private DevExpress.XtraBars.Ribbon.RibbonPage mainRibbonPage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mainRibbonPageGroup;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup searchRibbonPageGroup;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.LabelControl lblID;
        private DevExpress.XtraEditors.HyperlinkLabelControl lblCodigoSN;
        private DevExpress.XtraEditors.TextEdit txtCodigoSN;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageContenido;
        private DevExpress.XtraGrid.GridControl gcPartidas;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPartidas;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPagoID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnImporte;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cbGenero;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageDocumentoElectronico;
        private DevExpress.XtraEditors.LookUpEdit cbSeries;
        private DevExpress.XtraEditors.LabelControl lblNumeroDocumento;
        private DevExpress.XtraEditors.TextEdit txtNumeroDocumento;
        private DevExpress.XtraEditors.TextEdit txtFechaDocumento;
        private DevExpress.XtraEditors.TextEdit txtFechaVencimiento;
        private DevExpress.XtraEditors.LabelControl lblFechaDocumento;
        private DevExpress.XtraEditors.LabelControl lblFechaVencimiento;
        private DevExpress.XtraEditors.LabelControl lblFechaContabilizacion;
        private DevExpress.XtraEditors.CheckEdit cbPagoACuenta;
        private DevExpress.XtraEditors.MemoEdit txtComentario;
        private DevExpress.XtraEditors.LabelControl lblComentario;
        private DevExpress.XtraEditors.LabelControl lblTotal;
        private DevExpress.XtraEditors.TextEdit txtTotal;
        private DevExpress.XtraEditors.LabelControl lblReferencia;
        private DevExpress.XtraEditors.TextEdit txtReferencia;
        private DevExpress.XtraEditors.LabelControl lblIdentificadorExterno;
        private DevExpress.XtraEditors.LabelControl lblSocio;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDocumentoID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnNumeroDocumento;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTipoDocumento;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTotal;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnImporteAplicado;
        private DevExpress.XtraEditors.LabelControl lblSaldoPendiente;
        private DevExpress.XtraEditors.TextEdit txtSaldoPendiente;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageMediosPago;
        private DevExpress.XtraEditors.LabelControl lblImporteAplicado;
        private DevExpress.XtraEditors.TextEdit txtImporteAplicado;
        private DevExpress.XtraGrid.GridControl gcPagos;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPagos;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnMetodoPago;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cbMetodosPago;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTC;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnReferencia;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.MemoEdit txtCadenaOriginal;
        private DevExpress.XtraEditors.LabelControl lblCadenaOriginal;
        private DevExpress.XtraEditors.LabelControl lblFolioFiscal;
        private DevExpress.XtraEditors.TextEdit txtFolioFiscal;
        private DevExpress.XtraEditors.SimpleButton btnActualizar;
        private DevExpress.XtraEditors.SimpleButton btnGenerar;
        private DevExpress.XtraEditors.LookUpEdit cbMetodoPago;
        private DevExpress.XtraEditors.HyperlinkLabelControl lblMetodosPago;
        private DevExpress.XtraEditors.DateEdit deFechaContabilizacion;
        private DevExpress.XtraBars.BarSubItem bbiImprimir;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnFecha;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnFechaVencimiento;
        private DevExpress.XtraEditors.TextEdit txtTipoCambio;
        private DevExpress.XtraEditors.LookUpEdit cbMonedas;
        private DevExpress.XtraEditors.HyperlinkLabelControl lblMonedas;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnMoneda;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTipoCambio;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSaldo;
        private DevExpress.XtraBars.BarSubItem bbiPDF;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnMonedaID;
        private DevExpress.XtraEditors.HyperlinkLabelControl lblImportarFolioFiscal;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPartidaID;
        private System.Windows.Forms.Label lblCancelado;
        private DevExpress.XtraBars.PopupMenu popupMenuPagos;
        private DevExpress.XtraBars.BarButtonItem bbiPagosFinanciados;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageHerramientas;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupHerramientas;
        private DevExpress.XtraBars.BarButtonItem bbiMapaRelaciones;
        private DevExpress.XtraEditors.TextEdit txtNumeroDocumentoExterno;
        private DevExpress.XtraEditors.SimpleButton btnEstadoCFDI;
        private DevExpress.XtraBars.BarHeaderItem barHeaderItem1;
        private DevExpress.XtraBars.BarHeaderItem barHeaderItem2;
        private DevExpress.XtraBars.BarButtonItem bbiEnviar;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnMetodoPagoSAT;
        private DevExpress.XtraBars.BarButtonItem bbiNuevoMetodoPago;
    }
}