namespace Nori.Restaurante
{
    partial class frmComanda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmComanda));
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
            this.bbiImprimir = new DevExpress.XtraBars.BarButtonItem();
            this.mainRibbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mainRibbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.splitContainerControlComanda = new DevExpress.XtraEditors.SplitContainerControl();
            this.splitContainerControlArticulos = new DevExpress.XtraEditors.SplitContainerControl();
            this.lblVendedores = new DevExpress.XtraEditors.LabelControl();
            this.cbVendedores = new DevExpress.XtraEditors.LookUpEdit();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtArticulo = new DevExpress.XtraEditors.TextEdit();
            this.tlp = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainerControlPartidas = new DevExpress.XtraEditors.SplitContainerControl();
            this.gcPartidas = new DevExpress.XtraGrid.GridControl();
            this.gvPartidas = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnCantidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSKU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnArticulo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCodigoBarras = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPrecio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPrecioNeto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPorcentajeDescuento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDescuento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSubTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cbMonedas = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTotal_ = new System.Windows.Forms.Label();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnAtras = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlComanda)).BeginInit();
            this.splitContainerControlComanda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlArticulos)).BeginInit();
            this.splitContainerControlArticulos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbVendedores.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArticulo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlPartidas)).BeginInit();
            this.splitContainerControlPartidas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcPartidas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPartidas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMonedas)).BeginInit();
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
            this.bbiEliminar,
            this.bbiRestablecer,
            this.bbiBuscar,
            this.bbiPrimero,
            this.bbiAnterior,
            this.bbiUltimo,
            this.bbiSiguiente,
            this.bbiNuevo,
            this.bbiImprimir});
            this.mainRibbonControl.Location = new System.Drawing.Point(0, 0);
            this.mainRibbonControl.MaxItemId = 3;
            this.mainRibbonControl.Name = "mainRibbonControl";
            this.mainRibbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.mainRibbonPage});
            this.mainRibbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.OfficeUniversal;
            this.mainRibbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.mainRibbonControl.Size = new System.Drawing.Size(798, 83);
            this.mainRibbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // bbiGuardar
            // 
            this.bbiGuardar.Caption = "Guardar";
            this.bbiGuardar.Id = 2;
            this.bbiGuardar.ImageUri.Uri = "Save";
            this.bbiGuardar.Name = "bbiGuardar";
            // 
            // bbiGuardarCerrar
            // 
            this.bbiGuardarCerrar.Caption = "Guardar y cerrar";
            this.bbiGuardarCerrar.Id = 3;
            this.bbiGuardarCerrar.ImageUri.Uri = "SaveAndClose";
            this.bbiGuardarCerrar.Name = "bbiGuardarCerrar";
            this.bbiGuardarCerrar.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            // 
            // bbiGuardarNuevo
            // 
            this.bbiGuardarNuevo.Caption = "Guardar y nuevo";
            this.bbiGuardarNuevo.Id = 4;
            this.bbiGuardarNuevo.ImageUri.Uri = "SaveAndNew";
            this.bbiGuardarNuevo.Name = "bbiGuardarNuevo";
            // 
            // bbiEliminar
            // 
            this.bbiEliminar.Caption = "Eliminar";
            this.bbiEliminar.Id = 6;
            this.bbiEliminar.ImageUri.Uri = "Delete";
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
            this.bbiNuevo.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // bbiImprimir
            // 
            this.bbiImprimir.Caption = "Imprimir";
            this.bbiImprimir.Id = 2;
            this.bbiImprimir.ImageUri.Uri = "Print";
            this.bbiImprimir.Name = "bbiImprimir";
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
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiGuardarCerrar);
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiImprimir);
            this.mainRibbonPageGroup.Name = "mainRibbonPageGroup";
            this.mainRibbonPageGroup.ShowCaptionButton = false;
            this.mainRibbonPageGroup.Text = "Opciones";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.splitContainerControlComanda);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 83);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(92, 301, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(798, 516);
            this.layoutControl1.TabIndex = 57;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // splitContainerControlComanda
            // 
            this.splitContainerControlComanda.Location = new System.Drawing.Point(12, 12);
            this.splitContainerControlComanda.Name = "splitContainerControlComanda";
            this.splitContainerControlComanda.Panel1.Controls.Add(this.splitContainerControlArticulos);
            this.splitContainerControlComanda.Panel1.Text = "Panel1";
            this.splitContainerControlComanda.Panel2.Controls.Add(this.splitContainerControlPartidas);
            this.splitContainerControlComanda.Panel2.Text = "Panel2";
            this.splitContainerControlComanda.Size = new System.Drawing.Size(774, 492);
            this.splitContainerControlComanda.SplitterPosition = 373;
            this.splitContainerControlComanda.TabIndex = 4;
            this.splitContainerControlComanda.Text = "splitContainerControl1";
            // 
            // splitContainerControlArticulos
            // 
            this.splitContainerControlArticulos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlArticulos.Horizontal = false;
            this.splitContainerControlArticulos.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControlArticulos.Name = "splitContainerControlArticulos";
            this.splitContainerControlArticulos.Panel1.Controls.Add(this.lblVendedores);
            this.splitContainerControlArticulos.Panel1.Controls.Add(this.cbVendedores);
            this.splitContainerControlArticulos.Panel1.Controls.Add(this.pictureBox1);
            this.splitContainerControlArticulos.Panel1.Controls.Add(this.txtArticulo);
            this.splitContainerControlArticulos.Panel1.Text = "Panel1";
            this.splitContainerControlArticulos.Panel2.AutoScroll = true;
            this.splitContainerControlArticulos.Panel2.Controls.Add(this.tlp);
            this.splitContainerControlArticulos.Panel2.Text = "Panel2";
            this.splitContainerControlArticulos.Size = new System.Drawing.Size(373, 492);
            this.splitContainerControlArticulos.SplitterPosition = 56;
            this.splitContainerControlArticulos.TabIndex = 0;
            this.splitContainerControlArticulos.Text = "splitContainerControl2";
            // 
            // lblVendedores
            // 
            this.lblVendedores.Location = new System.Drawing.Point(4, 35);
            this.lblVendedores.Name = "lblVendedores";
            this.lblVendedores.Size = new System.Drawing.Size(35, 13);
            this.lblVendedores.TabIndex = 85;
            this.lblVendedores.Text = "Mesero";
            // 
            // cbVendedores
            // 
            this.cbVendedores.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbVendedores.Location = new System.Drawing.Point(106, 32);
            this.cbVendedores.MenuManager = this.mainRibbonControl;
            this.cbVendedores.Name = "cbVendedores";
            this.cbVendedores.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbVendedores.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nombre", "Nombre")});
            this.cbVendedores.Size = new System.Drawing.Size(262, 20);
            this.cbVendedores.TabIndex = 83;
            this.cbVendedores.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Nori.Properties.Resources.barcode;
            this.pictureBox1.Location = new System.Drawing.Point(4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // txtArticulo
            // 
            this.txtArticulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtArticulo.Location = new System.Drawing.Point(34, 6);
            this.txtArticulo.Name = "txtArticulo";
            this.txtArticulo.Size = new System.Drawing.Size(334, 20);
            this.txtArticulo.TabIndex = 19;
            this.txtArticulo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtArticulo_KeyDown);
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
            this.tlp.Name = "tlp";
            this.tlp.RowCount = 1;
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp.Size = new System.Drawing.Size(373, 424);
            this.tlp.TabIndex = 1;
            // 
            // splitContainerControlPartidas
            // 
            this.splitContainerControlPartidas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlPartidas.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControlPartidas.Horizontal = false;
            this.splitContainerControlPartidas.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControlPartidas.Name = "splitContainerControlPartidas";
            this.splitContainerControlPartidas.Panel1.Controls.Add(this.gcPartidas);
            this.splitContainerControlPartidas.Panel1.Text = "Panel1";
            this.splitContainerControlPartidas.Panel2.Controls.Add(this.btnAtras);
            this.splitContainerControlPartidas.Panel2.Controls.Add(this.lblTotal);
            this.splitContainerControlPartidas.Panel2.Controls.Add(this.lblTotal_);
            this.splitContainerControlPartidas.Panel2.MinSize = 55;
            this.splitContainerControlPartidas.Panel2.Text = "Panel2";
            this.splitContainerControlPartidas.Size = new System.Drawing.Size(389, 492);
            this.splitContainerControlPartidas.SplitterPosition = 55;
            this.splitContainerControlPartidas.TabIndex = 0;
            this.splitContainerControlPartidas.Text = "splitContainerControl1";
            // 
            // gcPartidas
            // 
            this.gcPartidas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcPartidas.Location = new System.Drawing.Point(0, 0);
            this.gcPartidas.MainView = this.gvPartidas;
            this.gcPartidas.Name = "gcPartidas";
            this.gcPartidas.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cbMonedas});
            this.gcPartidas.Size = new System.Drawing.Size(389, 425);
            this.gcPartidas.TabIndex = 3;
            this.gcPartidas.TabStop = false;
            this.gcPartidas.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPartidas});
            // 
            // gvPartidas
            // 
            this.gvPartidas.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gvPartidas.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnCantidad,
            this.gridColumnSKU,
            this.gridColumnArticulo,
            this.gridColumnCodigoBarras,
            this.gridColumnPrecio,
            this.gridColumnPrecioNeto,
            this.gridColumnPorcentajeDescuento,
            this.gridColumnDescuento,
            this.gridColumnSubTotal,
            this.gridColumnTotal});
            this.gvPartidas.GridControl = this.gcPartidas;
            this.gvPartidas.Name = "gvPartidas";
            this.gvPartidas.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gvPartidas.OptionsView.ShowFooter = true;
            this.gvPartidas.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumnCantidad
            // 
            this.gridColumnCantidad.Caption = "Cant";
            this.gridColumnCantidad.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnCantidad.FieldName = "cantidad";
            this.gridColumnCantidad.MaxWidth = 40;
            this.gridColumnCantidad.MinWidth = 40;
            this.gridColumnCantidad.Name = "gridColumnCantidad";
            this.gridColumnCantidad.OptionsColumn.FixedWidth = true;
            this.gridColumnCantidad.Visible = true;
            this.gridColumnCantidad.VisibleIndex = 0;
            this.gridColumnCantidad.Width = 40;
            // 
            // gridColumnSKU
            // 
            this.gridColumnSKU.Caption = "SKU";
            this.gridColumnSKU.FieldName = "sku";
            this.gridColumnSKU.MaxWidth = 150;
            this.gridColumnSKU.MinWidth = 60;
            this.gridColumnSKU.Name = "gridColumnSKU";
            this.gridColumnSKU.OptionsColumn.AllowEdit = false;
            this.gridColumnSKU.Width = 63;
            // 
            // gridColumnArticulo
            // 
            this.gridColumnArticulo.Caption = "Artículo";
            this.gridColumnArticulo.FieldName = "nombre";
            this.gridColumnArticulo.MinWidth = 100;
            this.gridColumnArticulo.Name = "gridColumnArticulo";
            this.gridColumnArticulo.OptionsColumn.AllowEdit = false;
            this.gridColumnArticulo.Visible = true;
            this.gridColumnArticulo.VisibleIndex = 1;
            this.gridColumnArticulo.Width = 120;
            // 
            // gridColumnCodigoBarras
            // 
            this.gridColumnCodigoBarras.Caption = "Código de barras";
            this.gridColumnCodigoBarras.FieldName = "codigo_barras";
            this.gridColumnCodigoBarras.MaxWidth = 120;
            this.gridColumnCodigoBarras.MinWidth = 80;
            this.gridColumnCodigoBarras.Name = "gridColumnCodigoBarras";
            this.gridColumnCodigoBarras.OptionsColumn.AllowEdit = false;
            this.gridColumnCodigoBarras.Width = 97;
            // 
            // gridColumnPrecio
            // 
            this.gridColumnPrecio.Caption = "Precio";
            this.gridColumnPrecio.DisplayFormat.FormatString = "c2";
            this.gridColumnPrecio.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnPrecio.FieldName = "gridColumnPrecio";
            this.gridColumnPrecio.MinWidth = 60;
            this.gridColumnPrecio.Name = "gridColumnPrecio";
            this.gridColumnPrecio.OptionsColumn.AllowEdit = false;
            this.gridColumnPrecio.UnboundExpression = "precio * tipo_cambio";
            this.gridColumnPrecio.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.gridColumnPrecio.Width = 60;
            // 
            // gridColumnPrecioNeto
            // 
            this.gridColumnPrecioNeto.Caption = "PU. Neto";
            this.gridColumnPrecioNeto.DisplayFormat.FormatString = "c2";
            this.gridColumnPrecioNeto.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnPrecioNeto.FieldName = "gridColumnPrecioNeto";
            this.gridColumnPrecioNeto.MinWidth = 60;
            this.gridColumnPrecioNeto.Name = "gridColumnPrecioNeto";
            this.gridColumnPrecioNeto.UnboundExpression = "(precio * tipo_cambio) + impuesto";
            this.gridColumnPrecioNeto.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.gridColumnPrecioNeto.Visible = true;
            this.gridColumnPrecioNeto.VisibleIndex = 2;
            this.gridColumnPrecioNeto.Width = 60;
            // 
            // gridColumnPorcentajeDescuento
            // 
            this.gridColumnPorcentajeDescuento.Caption = "% Dscto";
            this.gridColumnPorcentajeDescuento.DisplayFormat.FormatString = "p2";
            this.gridColumnPorcentajeDescuento.FieldName = "porcentaje_descuento";
            this.gridColumnPorcentajeDescuento.MaxWidth = 50;
            this.gridColumnPorcentajeDescuento.Name = "gridColumnPorcentajeDescuento";
            this.gridColumnPorcentajeDescuento.OptionsColumn.FixedWidth = true;
            this.gridColumnPorcentajeDescuento.Width = 50;
            // 
            // gridColumnDescuento
            // 
            this.gridColumnDescuento.Caption = "Descuento";
            this.gridColumnDescuento.DisplayFormat.FormatString = "c2";
            this.gridColumnDescuento.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnDescuento.FieldName = "descuento";
            this.gridColumnDescuento.MaxWidth = 120;
            this.gridColumnDescuento.MinWidth = 60;
            this.gridColumnDescuento.Name = "gridColumnDescuento";
            this.gridColumnDescuento.OptionsColumn.AllowEdit = false;
            this.gridColumnDescuento.Width = 60;
            // 
            // gridColumnSubTotal
            // 
            this.gridColumnSubTotal.Caption = "SubTotal";
            this.gridColumnSubTotal.DisplayFormat.FormatString = "c2";
            this.gridColumnSubTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnSubTotal.FieldName = "subtotal";
            this.gridColumnSubTotal.MinWidth = 60;
            this.gridColumnSubTotal.Name = "gridColumnSubTotal";
            this.gridColumnSubTotal.OptionsColumn.AllowEdit = false;
            this.gridColumnSubTotal.Width = 60;
            // 
            // gridColumnTotal
            // 
            this.gridColumnTotal.Caption = "Total";
            this.gridColumnTotal.DisplayFormat.FormatString = "c2";
            this.gridColumnTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnTotal.FieldName = "total";
            this.gridColumnTotal.MinWidth = 60;
            this.gridColumnTotal.Name = "gridColumnTotal";
            this.gridColumnTotal.Visible = true;
            this.gridColumnTotal.VisibleIndex = 3;
            this.gridColumnTotal.Width = 60;
            // 
            // cbMonedas
            // 
            this.cbMonedas.AutoHeight = false;
            this.cbMonedas.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbMonedas.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("codigo", "Código")});
            this.cbMonedas.Name = "cbMonedas";
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.AutoEllipsis = true;
            this.lblTotal.Font = new System.Drawing.Font("Tahoma", 22F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(231, 12);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTotal.Size = new System.Drawing.Size(153, 36);
            this.lblTotal.TabIndex = 5;
            this.lblTotal.Text = "0.00";
            // 
            // lblTotal_
            // 
            this.lblTotal_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal_.AutoSize = true;
            this.lblTotal_.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblTotal_.Location = new System.Drawing.Point(185, 12);
            this.lblTotal_.Name = "lblTotal_";
            this.lblTotal_.Size = new System.Drawing.Size(36, 13);
            this.lblTotal_.TabIndex = 4;
            this.lblTotal_.Text = "Total";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(798, 516);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.splitContainerControlComanda;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(778, 496);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // btnAtras
            // 
            this.btnAtras.Image = ((System.Drawing.Image)(resources.GetObject("btnAtras.Image")));
            this.btnAtras.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnAtras.Location = new System.Drawing.Point(2, 3);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(80, 50);
            this.btnAtras.TabIndex = 6;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // frmComanda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 599);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.mainRibbonControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmComanda";
            this.Ribbon = this.mainRibbonControl;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comanda";
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlComanda)).EndInit();
            this.splitContainerControlComanda.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlArticulos)).EndInit();
            this.splitContainerControlArticulos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbVendedores.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArticulo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlPartidas)).EndInit();
            this.splitContainerControlPartidas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcPartidas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPartidas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMonedas)).EndInit();
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
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraBars.BarButtonItem bbiImprimir;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlComanda;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlArticulos;
        private System.Windows.Forms.TableLayoutPanel tlp;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraEditors.TextEdit txtArticulo;
        private DevExpress.XtraEditors.LookUpEdit cbVendedores;
        private DevExpress.XtraEditors.LabelControl lblVendedores;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlPartidas;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblTotal_;
        private DevExpress.XtraGrid.GridControl gcPartidas;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPartidas;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCantidad;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSKU;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnArticulo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCodigoBarras;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPrecio;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPrecioNeto;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPorcentajeDescuento;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDescuento;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSubTotal;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTotal;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cbMonedas;
        private DevExpress.XtraEditors.SimpleButton btnAtras;
    }
}