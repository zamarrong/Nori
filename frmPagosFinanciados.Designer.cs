namespace Nori
{
    partial class frmPagosFinanciados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPagosFinanciados));
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
            this.mainRibbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mainRibbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblEstadoCredito = new System.Windows.Forms.Label();
            this.lblImporteAplicado = new DevExpress.XtraEditors.LabelControl();
            this.txtImporteAplicado = new DevExpress.XtraEditors.TextEdit();
            this.lblSaldoPendiente = new DevExpress.XtraEditors.LabelControl();
            this.txtSaldoPendiente = new DevExpress.XtraEditors.TextEdit();
            this.lblSocio = new DevExpress.XtraEditors.LabelControl();
            this.lblTotal = new DevExpress.XtraEditors.LabelControl();
            this.txtTotal = new DevExpress.XtraEditors.TextEdit();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPageContenido = new DevExpress.XtraTab.XtraTabPage();
            this.gcPartidas = new DevExpress.XtraGrid.GridControl();
            this.gvPartidas = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnPartidaID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPagoID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDocumentoID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnNumeroDocumento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnTipoDocumento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnReserva = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnFechaVencimiento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnMoneda = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnMonedaID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnTipoCambio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnImporteAplicado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnIntereses = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSaldo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnImporte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnComentario = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.lblCodigoSN = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.txtCodigoSN = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.popupMenuPagos = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtImporteAplicado.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaldoPendiente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.Properties)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigoSN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuPagos)).BeginInit();
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
            this.bbiPDF});
            this.mainRibbonControl.Location = new System.Drawing.Point(0, 0);
            this.mainRibbonControl.MaxItemId = 7;
            this.mainRibbonControl.Name = "mainRibbonControl";
            this.mainRibbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.mainRibbonPage});
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
            // 
            // bbiGuardarNuevo
            // 
            this.bbiGuardarNuevo.Caption = "Guardar y nuevo";
            this.bbiGuardarNuevo.Id = 4;
            this.bbiGuardarNuevo.ImageUri.Uri = "SaveAndNew";
            this.bbiGuardarNuevo.Name = "bbiGuardarNuevo";
            // 
            // bbiCancelar
            // 
            this.bbiCancelar.Caption = "Cancelar";
            this.bbiCancelar.Id = 6;
            this.bbiCancelar.ImageUri.Uri = "Cancel";
            this.bbiCancelar.Name = "bbiCancelar";
            // 
            // bbiBuscar
            // 
            this.bbiBuscar.Caption = "Buscar";
            this.bbiBuscar.Id = 4;
            this.bbiBuscar.ImageUri.Uri = "Find";
            this.bbiBuscar.Name = "bbiBuscar";
            this.bbiBuscar.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText;
            // 
            // bbiPrimero
            // 
            this.bbiPrimero.Caption = "Primero";
            this.bbiPrimero.Id = 5;
            this.bbiPrimero.ImageUri.Uri = "First";
            this.bbiPrimero.Name = "bbiPrimero";
            this.bbiPrimero.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText;
            // 
            // bbiAnterior
            // 
            this.bbiAnterior.Caption = "Anterior";
            this.bbiAnterior.Id = 6;
            this.bbiAnterior.ImageUri.Uri = "Prev";
            this.bbiAnterior.Name = "bbiAnterior";
            this.bbiAnterior.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText;
            // 
            // bbiUltimo
            // 
            this.bbiUltimo.Caption = "Último";
            this.bbiUltimo.Id = 7;
            this.bbiUltimo.ImageUri.Uri = "Last";
            this.bbiUltimo.Name = "bbiUltimo";
            this.bbiUltimo.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText;
            // 
            // bbiSiguiente
            // 
            this.bbiSiguiente.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.bbiSiguiente.Caption = "Siguiente";
            this.bbiSiguiente.Id = 8;
            this.bbiSiguiente.ImageUri.Uri = "Next";
            this.bbiSiguiente.Name = "bbiSiguiente";
            this.bbiSiguiente.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText;
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
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiGuardar);
            this.mainRibbonPageGroup.Name = "mainRibbonPageGroup";
            this.mainRibbonPageGroup.ShowCaptionButton = false;
            this.mainRibbonPageGroup.Text = "Opciones";
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
            this.panel1.Controls.Add(this.lblDireccion);
            this.panel1.Controls.Add(this.lblEstadoCredito);
            this.panel1.Controls.Add(this.lblImporteAplicado);
            this.panel1.Controls.Add(this.txtImporteAplicado);
            this.panel1.Controls.Add(this.lblSaldoPendiente);
            this.panel1.Controls.Add(this.txtSaldoPendiente);
            this.panel1.Controls.Add(this.lblSocio);
            this.panel1.Controls.Add(this.lblTotal);
            this.panel1.Controls.Add(this.txtTotal);
            this.panel1.Controls.Add(this.xtraTabControl1);
            this.panel1.Controls.Add(this.lblCodigoSN);
            this.panel1.Controls.Add(this.txtCodigoSN);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(766, 492);
            this.panel1.TabIndex = 4;
            // 
            // lblDireccion
            // 
            this.lblDireccion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDireccion.ForeColor = System.Drawing.Color.DimGray;
            this.lblDireccion.Location = new System.Drawing.Point(475, 14);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDireccion.Size = new System.Drawing.Size(286, 33);
            this.lblDireccion.TabIndex = 149;
            this.lblDireccion.Text = "Dirección de facturación";
            // 
            // lblEstadoCredito
            // 
            this.lblEstadoCredito.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEstadoCredito.ForeColor = System.Drawing.Color.DimGray;
            this.lblEstadoCredito.Location = new System.Drawing.Point(380, 56);
            this.lblEstadoCredito.Name = "lblEstadoCredito";
            this.lblEstadoCredito.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblEstadoCredito.Size = new System.Drawing.Size(380, 17);
            this.lblEstadoCredito.TabIndex = 150;
            this.lblEstadoCredito.Text = "Estado de crédito";
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
            // xtraTabControl1
            // 
            this.xtraTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xtraTabControl1.Location = new System.Drawing.Point(3, 59);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPageContenido;
            this.xtraTabControl1.Size = new System.Drawing.Size(760, 343);
            this.xtraTabControl1.TabIndex = 121;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageContenido,
            this.xtraTabPageMediosPago});
            // 
            // xtraTabPageContenido
            // 
            this.xtraTabPageContenido.Controls.Add(this.gcPartidas);
            this.xtraTabPageContenido.Name = "xtraTabPageContenido";
            this.xtraTabPageContenido.Size = new System.Drawing.Size(754, 315);
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
            this.gcPartidas.Size = new System.Drawing.Size(754, 315);
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
            this.gridColumnReserva,
            this.gridColumnFecha,
            this.gridColumnFechaVencimiento,
            this.gridColumnMoneda,
            this.gridColumnMonedaID,
            this.gridColumnTipoCambio,
            this.gridColumnTotal,
            this.gridColumnImporteAplicado,
            this.gridColumnIntereses,
            this.gridColumnSaldo,
            this.gridColumnImporte,
            this.gridColumnComentario});
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
            // 
            // gridColumnNumeroDocumento
            // 
            this.gridColumnNumeroDocumento.Caption = "N° documento";
            this.gridColumnNumeroDocumento.FieldName = "numero_documento";
            this.gridColumnNumeroDocumento.Name = "gridColumnNumeroDocumento";
            this.gridColumnNumeroDocumento.OptionsColumn.AllowEdit = false;
            this.gridColumnNumeroDocumento.Visible = true;
            this.gridColumnNumeroDocumento.VisibleIndex = 2;
            // 
            // gridColumnTipoDocumento
            // 
            this.gridColumnTipoDocumento.Caption = "Tipo";
            this.gridColumnTipoDocumento.FieldName = "clase";
            this.gridColumnTipoDocumento.Name = "gridColumnTipoDocumento";
            this.gridColumnTipoDocumento.OptionsColumn.AllowEdit = false;
            this.gridColumnTipoDocumento.Visible = true;
            this.gridColumnTipoDocumento.VisibleIndex = 3;
            // 
            // gridColumnReserva
            // 
            this.gridColumnReserva.Caption = "Reserva";
            this.gridColumnReserva.FieldName = "reserva";
            this.gridColumnReserva.Name = "gridColumnReserva";
            this.gridColumnReserva.OptionsColumn.AllowEdit = false;
            this.gridColumnReserva.Visible = true;
            this.gridColumnReserva.VisibleIndex = 4;
            // 
            // gridColumnFecha
            // 
            this.gridColumnFecha.Caption = "Fecha";
            this.gridColumnFecha.FieldName = "fecha_documento";
            this.gridColumnFecha.Name = "gridColumnFecha";
            this.gridColumnFecha.OptionsColumn.AllowEdit = false;
            this.gridColumnFecha.Visible = true;
            this.gridColumnFecha.VisibleIndex = 5;
            // 
            // gridColumnFechaVencimiento
            // 
            this.gridColumnFechaVencimiento.Caption = "Vencimiento";
            this.gridColumnFechaVencimiento.FieldName = "fecha_vencimiento";
            this.gridColumnFechaVencimiento.Name = "gridColumnFechaVencimiento";
            this.gridColumnFechaVencimiento.OptionsColumn.AllowEdit = false;
            this.gridColumnFechaVencimiento.Visible = true;
            this.gridColumnFechaVencimiento.VisibleIndex = 6;
            // 
            // gridColumnMoneda
            // 
            this.gridColumnMoneda.Caption = "Moneda";
            this.gridColumnMoneda.FieldName = "moneda";
            this.gridColumnMoneda.Name = "gridColumnMoneda";
            this.gridColumnMoneda.OptionsColumn.AllowEdit = false;
            this.gridColumnMoneda.Visible = true;
            this.gridColumnMoneda.VisibleIndex = 7;
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
            // 
            // gridColumnIntereses
            // 
            this.gridColumnIntereses.Caption = "Intereses";
            this.gridColumnIntereses.DisplayFormat.FormatString = "c2";
            this.gridColumnIntereses.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnIntereses.FieldName = "intereses";
            this.gridColumnIntereses.Name = "gridColumnIntereses";
            this.gridColumnIntereses.OptionsColumn.AllowEdit = false;
            this.gridColumnIntereses.Visible = true;
            this.gridColumnIntereses.VisibleIndex = 11;
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
            this.gridColumnSaldo.VisibleIndex = 12;
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
            this.gridColumnImporte.VisibleIndex = 13;
            this.gridColumnImporte.Width = 80;
            // 
            // gridColumnComentario
            // 
            this.gridColumnComentario.Caption = "Comentario";
            this.gridColumnComentario.FieldName = "comentario";
            this.gridColumnComentario.Name = "gridColumnComentario";
            this.gridColumnComentario.OptionsColumn.AllowEdit = false;
            this.gridColumnComentario.Visible = true;
            this.gridColumnComentario.VisibleIndex = 14;
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
            this.xtraTabPageMediosPago.Size = new System.Drawing.Size(754, 315);
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
            this.gcPagos.Size = new System.Drawing.Size(754, 315);
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
            // popupMenuPagos
            // 
            this.popupMenuPagos.ItemLinks.Add(this.bbiNuevo);
            this.popupMenuPagos.ItemLinks.Add(this.bbiGuardar);
            this.popupMenuPagos.Name = "popupMenuPagos";
            this.popupMenuPagos.Ribbon = this.mainRibbonControl;
            // 
            // frmPagosFinanciados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 595);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.mainRibbonControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPagosFinanciados";
            this.mainRibbonControl.SetPopupContextMenu(this, this.popupMenuPagos);
            this.Ribbon = this.mainRibbonControl;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pagos financiados";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtImporteAplicado.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaldoPendiente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.Properties)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigoSN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuPagos)).EndInit();
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
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.HyperlinkLabelControl lblCodigoSN;
        private DevExpress.XtraEditors.TextEdit txtCodigoSN;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageContenido;
        private DevExpress.XtraGrid.GridControl gcPartidas;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPartidas;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPagoID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnImporte;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cbGenero;
        private DevExpress.XtraEditors.LabelControl lblTotal;
        private DevExpress.XtraEditors.TextEdit txtTotal;
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
        private DevExpress.XtraBars.BarSubItem bbiImprimir;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnFecha;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnFechaVencimiento;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnMoneda;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTipoCambio;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSaldo;
        private DevExpress.XtraBars.BarSubItem bbiPDF;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnMonedaID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPartidaID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnIntereses;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblEstadoCredito;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnReserva;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnComentario;
        private DevExpress.XtraBars.PopupMenu popupMenuPagos;
    }
}