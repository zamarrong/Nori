namespace Nori
{
    partial class frmMediosPago
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMediosPago));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCondicionPago = new DevExpress.XtraEditors.LabelControl();
            this.cbCondicionesPago = new DevExpress.XtraEditors.LookUpEdit();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblClaseDocumento = new System.Windows.Forms.Label();
            this.cbUsoPrincipal = new DevExpress.XtraEditors.LookUpEdit();
            this.lblUsoPrincipal = new DevExpress.XtraEditors.LabelControl();
            this.lblDiferencia = new System.Windows.Forms.Label();
            this.lblDiferencia_ = new System.Windows.Forms.Label();
            this.separatorControl1 = new DevExpress.XtraEditors.SeparatorControl();
            this.lblTotalAplicado = new System.Windows.Forms.Label();
            this.lblTotalAplicado_ = new System.Windows.Forms.Label();
            this.gcPagos = new DevExpress.XtraGrid.GridControl();
            this.gvPagos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnMetodoPago = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cbMetodosPago = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumnTC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnReferencia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnImporte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblImpuesto = new System.Windows.Forms.Label();
            this.lblImpuesto_ = new System.Windows.Forms.Label();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.lblSubTotal_ = new System.Windows.Forms.Label();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTotal_ = new System.Windows.Forms.Label();
            this.lblDescuento_ = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ssGeneral = new System.Windows.Forms.StatusStrip();
            this.lblLimiteCredito = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCreditoDisponible = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbCondicionesPago.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbUsoPrincipal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPagos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPagos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMetodosPago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.ssGeneral.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 1;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.OfficeUniversal;
            this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.Size = new System.Drawing.Size(598, 49);
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.panel1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 49);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(598, 390);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblCondicionPago);
            this.panel1.Controls.Add(this.cbCondicionesPago);
            this.panel1.Controls.Add(this.lblNombre);
            this.panel1.Controls.Add(this.lblClaseDocumento);
            this.panel1.Controls.Add(this.cbUsoPrincipal);
            this.panel1.Controls.Add(this.lblUsoPrincipal);
            this.panel1.Controls.Add(this.lblDiferencia);
            this.panel1.Controls.Add(this.lblDiferencia_);
            this.panel1.Controls.Add(this.separatorControl1);
            this.panel1.Controls.Add(this.lblTotalAplicado);
            this.panel1.Controls.Add(this.lblTotalAplicado_);
            this.panel1.Controls.Add(this.gcPagos);
            this.panel1.Controls.Add(this.lblImpuesto);
            this.panel1.Controls.Add(this.lblImpuesto_);
            this.panel1.Controls.Add(this.lblSubTotal);
            this.panel1.Controls.Add(this.lblSubTotal_);
            this.panel1.Controls.Add(this.lblDescuento);
            this.panel1.Controls.Add(this.lblTotal);
            this.panel1.Controls.Add(this.lblTotal_);
            this.panel1.Controls.Add(this.lblDescuento_);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnAceptar);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(574, 366);
            this.panel1.TabIndex = 0;
            // 
            // lblCondicionPago
            // 
            this.lblCondicionPago.Location = new System.Drawing.Point(11, 307);
            this.lblCondicionPago.Name = "lblCondicionPago";
            this.lblCondicionPago.Size = new System.Drawing.Size(88, 13);
            this.lblCondicionPago.TabIndex = 104;
            this.lblCondicionPago.Text = "Condición de pago";
            // 
            // cbCondicionesPago
            // 
            this.cbCondicionesPago.Location = new System.Drawing.Point(11, 326);
            this.cbCondicionesPago.Name = "cbCondicionesPago";
            this.cbCondicionesPago.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbCondicionesPago.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nombre", 50, "Nombre"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("dias_extra", "Días extra"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("plazos", "Plazos"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("porcentaje_interes", "% Interes")});
            this.cbCondicionesPago.Size = new System.Drawing.Size(192, 20);
            this.cbCondicionesPago.TabIndex = 103;
            this.cbCondicionesPago.TabStop = false;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoEllipsis = true;
            this.lblNombre.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.Silver;
            this.lblNombre.Location = new System.Drawing.Point(303, 267);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblNombre.Size = new System.Drawing.Size(260, 42);
            this.lblNombre.TabIndex = 102;
            this.lblNombre.Text = "Nombre SN";
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblClaseDocumento
            // 
            this.lblClaseDocumento.AutoEllipsis = true;
            this.lblClaseDocumento.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.lblClaseDocumento.ForeColor = System.Drawing.Color.Silver;
            this.lblClaseDocumento.Location = new System.Drawing.Point(303, 235);
            this.lblClaseDocumento.Name = "lblClaseDocumento";
            this.lblClaseDocumento.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblClaseDocumento.Size = new System.Drawing.Size(260, 27);
            this.lblClaseDocumento.TabIndex = 101;
            this.lblClaseDocumento.Text = "Entrega";
            this.lblClaseDocumento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbUsoPrincipal
            // 
            this.cbUsoPrincipal.Location = new System.Drawing.Point(11, 281);
            this.cbUsoPrincipal.Name = "cbUsoPrincipal";
            this.cbUsoPrincipal.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbUsoPrincipal.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("uso", "Uso", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nombre", "Nombre")});
            this.cbUsoPrincipal.Size = new System.Drawing.Size(192, 20);
            this.cbUsoPrincipal.TabIndex = 0;
            this.cbUsoPrincipal.TabStop = false;
            // 
            // lblUsoPrincipal
            // 
            this.lblUsoPrincipal.Location = new System.Drawing.Point(11, 262);
            this.lblUsoPrincipal.Name = "lblUsoPrincipal";
            this.lblUsoPrincipal.Size = new System.Drawing.Size(60, 13);
            this.lblUsoPrincipal.TabIndex = 98;
            this.lblUsoPrincipal.Text = "Uso principal";
            // 
            // lblDiferencia
            // 
            this.lblDiferencia.AutoEllipsis = true;
            this.lblDiferencia.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.lblDiferencia.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblDiferencia.Location = new System.Drawing.Point(370, 210);
            this.lblDiferencia.Name = "lblDiferencia";
            this.lblDiferencia.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDiferencia.Size = new System.Drawing.Size(197, 25);
            this.lblDiferencia.TabIndex = 22;
            this.lblDiferencia.Text = "0.00";
            // 
            // lblDiferencia_
            // 
            this.lblDiferencia_.AutoSize = true;
            this.lblDiferencia_.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblDiferencia_.Location = new System.Drawing.Point(300, 210);
            this.lblDiferencia_.Name = "lblDiferencia_";
            this.lblDiferencia_.Size = new System.Drawing.Size(64, 13);
            this.lblDiferencia_.TabIndex = 21;
            this.lblDiferencia_.Text = "Diferencia";
            // 
            // separatorControl1
            // 
            this.separatorControl1.Location = new System.Drawing.Point(303, 184);
            this.separatorControl1.Name = "separatorControl1";
            this.separatorControl1.Size = new System.Drawing.Size(266, 23);
            this.separatorControl1.TabIndex = 20;
            // 
            // lblTotalAplicado
            // 
            this.lblTotalAplicado.AutoEllipsis = true;
            this.lblTotalAplicado.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalAplicado.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblTotalAplicado.Location = new System.Drawing.Point(370, 156);
            this.lblTotalAplicado.Name = "lblTotalAplicado";
            this.lblTotalAplicado.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTotalAplicado.Size = new System.Drawing.Size(197, 25);
            this.lblTotalAplicado.TabIndex = 19;
            this.lblTotalAplicado.Text = "0.00";
            // 
            // lblTotalAplicado_
            // 
            this.lblTotalAplicado_.AutoSize = true;
            this.lblTotalAplicado_.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblTotalAplicado_.Location = new System.Drawing.Point(300, 156);
            this.lblTotalAplicado_.Name = "lblTotalAplicado_";
            this.lblTotalAplicado_.Size = new System.Drawing.Size(55, 13);
            this.lblTotalAplicado_.TabIndex = 18;
            this.lblTotalAplicado_.Text = "Aplicado";
            // 
            // gcPagos
            // 
            this.gcPagos.Location = new System.Drawing.Point(0, 0);
            this.gcPagos.MainView = this.gvPagos;
            this.gcPagos.MenuManager = this.ribbonControl1;
            this.gcPagos.Name = "gcPagos";
            this.gcPagos.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cbMetodosPago});
            this.gcPagos.Size = new System.Drawing.Size(574, 153);
            this.gcPagos.TabIndex = 1;
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
            this.gridColumnImporte,
            this.gridColumnTotal});
            this.gvPagos.GridControl = this.gcPagos;
            this.gvPagos.Name = "gvPagos";
            this.gvPagos.OptionsCustomization.AllowColumnMoving = false;
            this.gvPagos.OptionsCustomization.AllowFilter = false;
            this.gvPagos.OptionsCustomization.AllowSort = false;
            this.gvPagos.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gvPagos.OptionsView.ShowGroupPanel = false;
            this.gvPagos.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gvPagos_ShowingEditor);
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
            this.gridColumnTC.OptionsColumn.AllowEdit = false;
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
            // gridColumnImporte
            // 
            this.gridColumnImporte.Caption = "Importe";
            this.gridColumnImporte.DisplayFormat.FormatString = "C";
            this.gridColumnImporte.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnImporte.FieldName = "importe";
            this.gridColumnImporte.Name = "gridColumnImporte";
            this.gridColumnImporte.Visible = true;
            this.gridColumnImporte.VisibleIndex = 3;
            this.gridColumnImporte.Width = 100;
            // 
            // gridColumnTotal
            // 
            this.gridColumnTotal.Caption = "Total";
            this.gridColumnTotal.DisplayFormat.FormatString = "C";
            this.gridColumnTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnTotal.FieldName = "gridColumnTotal";
            this.gridColumnTotal.Name = "gridColumnTotal";
            this.gridColumnTotal.OptionsColumn.AllowEdit = false;
            this.gridColumnTotal.UnboundExpression = "tipo_cambio * importe";
            this.gridColumnTotal.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.gridColumnTotal.Visible = true;
            this.gridColumnTotal.VisibleIndex = 4;
            this.gridColumnTotal.Width = 111;
            // 
            // lblImpuesto
            // 
            this.lblImpuesto.AutoEllipsis = true;
            this.lblImpuesto.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblImpuesto.ForeColor = System.Drawing.Color.Gray;
            this.lblImpuesto.Location = new System.Drawing.Point(66, 205);
            this.lblImpuesto.Name = "lblImpuesto";
            this.lblImpuesto.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblImpuesto.Size = new System.Drawing.Size(141, 22);
            this.lblImpuesto.TabIndex = 16;
            this.lblImpuesto.Text = "0.00";
            // 
            // lblImpuesto_
            // 
            this.lblImpuesto_.AutoSize = true;
            this.lblImpuesto_.ForeColor = System.Drawing.Color.Gray;
            this.lblImpuesto_.Location = new System.Drawing.Point(8, 205);
            this.lblImpuesto_.Name = "lblImpuesto_";
            this.lblImpuesto_.Size = new System.Drawing.Size(52, 13);
            this.lblImpuesto_.TabIndex = 15;
            this.lblImpuesto_.Text = "Impuesto";
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.AutoEllipsis = true;
            this.lblSubTotal.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblSubTotal.ForeColor = System.Drawing.Color.Gray;
            this.lblSubTotal.Location = new System.Drawing.Point(54, 156);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblSubTotal.Size = new System.Drawing.Size(153, 22);
            this.lblSubTotal.TabIndex = 14;
            this.lblSubTotal.Text = "0.00";
            // 
            // lblSubTotal_
            // 
            this.lblSubTotal_.AutoSize = true;
            this.lblSubTotal_.ForeColor = System.Drawing.Color.Gray;
            this.lblSubTotal_.Location = new System.Drawing.Point(8, 156);
            this.lblSubTotal_.Name = "lblSubTotal_";
            this.lblSubTotal_.Size = new System.Drawing.Size(49, 13);
            this.lblSubTotal_.TabIndex = 13;
            this.lblSubTotal_.Text = "SubTotal";
            // 
            // lblDescuento
            // 
            this.lblDescuento.AutoEllipsis = true;
            this.lblDescuento.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblDescuento.ForeColor = System.Drawing.Color.Gray;
            this.lblDescuento.Location = new System.Drawing.Point(72, 180);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDescuento.Size = new System.Drawing.Size(135, 22);
            this.lblDescuento.TabIndex = 10;
            this.lblDescuento.Text = "0.00";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoEllipsis = true;
            this.lblTotal.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(54, 231);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTotal.Size = new System.Drawing.Size(153, 25);
            this.lblTotal.TabIndex = 9;
            this.lblTotal.Text = "0.00";
            // 
            // lblTotal_
            // 
            this.lblTotal_.AutoSize = true;
            this.lblTotal_.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblTotal_.Location = new System.Drawing.Point(8, 231);
            this.lblTotal_.Name = "lblTotal_";
            this.lblTotal_.Size = new System.Drawing.Size(36, 13);
            this.lblTotal_.TabIndex = 8;
            this.lblTotal_.Text = "Total";
            // 
            // lblDescuento_
            // 
            this.lblDescuento_.AutoSize = true;
            this.lblDescuento_.ForeColor = System.Drawing.Color.Gray;
            this.lblDescuento_.Location = new System.Drawing.Point(8, 180);
            this.lblDescuento_.Name = "lblDescuento_";
            this.lblDescuento_.Size = new System.Drawing.Size(58, 13);
            this.lblDescuento_.TabIndex = 7;
            this.lblDescuento_.Text = "Descuento";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancelar.Location = new System.Drawing.Point(303, 319);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(108, 27);
            this.btnCancelar.TabIndex = 0;
            this.btnCancelar.TabStop = false;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(152)))), ((int)(((byte)(33)))));
            this.btnAceptar.Enabled = false;
            this.btnAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(135)))), ((int)(((byte)(0)))));
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.Location = new System.Drawing.Point(451, 319);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(108, 27);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.TabStop = false;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(598, 390);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.panel1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(578, 370);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // ssGeneral
            // 
            this.ssGeneral.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblLimiteCredito,
            this.toolStripStatusLabel1,
            this.lblCreditoDisponible});
            this.ssGeneral.Location = new System.Drawing.Point(0, 417);
            this.ssGeneral.Name = "ssGeneral";
            this.ssGeneral.Size = new System.Drawing.Size(598, 22);
            this.ssGeneral.SizingGrip = false;
            this.ssGeneral.TabIndex = 0;
            this.ssGeneral.Text = "Nori";
            // 
            // lblLimiteCredito
            // 
            this.lblLimiteCredito.BackColor = System.Drawing.Color.Transparent;
            this.lblLimiteCredito.Name = "lblLimiteCredito";
            this.lblLimiteCredito.Size = new System.Drawing.Size(114, 17);
            this.lblLimiteCredito.Text = "Limite de crédito: $0";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(4, 17);
            // 
            // lblCreditoDisponible
            // 
            this.lblCreditoDisponible.BackColor = System.Drawing.Color.Transparent;
            this.lblCreditoDisponible.Name = "lblCreditoDisponible";
            this.lblCreditoDisponible.Size = new System.Drawing.Size(122, 17);
            this.lblCreditoDisponible.Text = "Crédito disponible: $0";
            // 
            // frmMediosPago
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(598, 439);
            this.Controls.Add(this.ssGeneral);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.ribbonControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmMediosPago";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Medios de pago";
            this.Activated += new System.EventHandler(this.frmPagos_Activated);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPago_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmPago_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbCondicionesPago.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbUsoPrincipal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPagos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPagos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMetodosPago)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ssGeneral.ResumeLayout(false);
            this.ssGeneral.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label lblDescuento;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblTotal_;
        private System.Windows.Forms.Label lblDescuento_;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.Label lblImpuesto;
        private System.Windows.Forms.Label lblImpuesto_;
        private DevExpress.XtraGrid.GridControl gcPagos;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPagos;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnMetodoPago;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cbMetodosPago;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTC;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnReferencia;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnImporte;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTotal;
        private DevExpress.XtraEditors.SeparatorControl separatorControl1;
        private System.Windows.Forms.Label lblTotalAplicado;
        private System.Windows.Forms.Label lblTotalAplicado_;
        private System.Windows.Forms.Label lblDiferencia;
        private System.Windows.Forms.Label lblDiferencia_;
        private System.Windows.Forms.Label lblSubTotal_;
        private System.Windows.Forms.StatusStrip ssGeneral;
        private System.Windows.Forms.ToolStripStatusLabel lblLimiteCredito;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblCreditoDisponible;
        private DevExpress.XtraEditors.LookUpEdit cbUsoPrincipal;
        private DevExpress.XtraEditors.LabelControl lblUsoPrincipal;
        private System.Windows.Forms.Label lblClaseDocumento;
        private System.Windows.Forms.Label lblNombre;
        private DevExpress.XtraEditors.LabelControl lblCondicionPago;
        private DevExpress.XtraEditors.LookUpEdit cbCondicionesPago;
    }
}