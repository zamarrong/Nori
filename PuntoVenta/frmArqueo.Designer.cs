namespace Nori.PuntoVenta
{
    partial class frmArqueo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmArqueo));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnREACA = new System.Windows.Forms.Button();
            this.btnRERET = new System.Windows.Forms.Button();
            this.gcAcumulados = new DevExpress.XtraGrid.GridControl();
            this.gvAcumulados = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPartidas = new DevExpress.XtraGrid.GridControl();
            this.gvPartidas = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cbConceptos = new DevExpress.XtraEditors.LookUpEdit();
            this.lblConceptos = new DevExpress.XtraEditors.LabelControl();
            this.txtCantidad = new DevExpress.XtraEditors.TextEdit();
            this.lblCantidad = new DevExpress.XtraEditors.LabelControl();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnRECCA = new System.Windows.Forms.Button();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcAcumulados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAcumulados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPartidas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPartidas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbConceptos.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
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
            this.ribbonControl1.Size = new System.Drawing.Size(785, 49);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.panel1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 49);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(785, 427);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnREACA);
            this.panel1.Controls.Add(this.btnRERET);
            this.panel1.Controls.Add(this.gcAcumulados);
            this.panel1.Controls.Add(this.gcPartidas);
            this.panel1.Controls.Add(this.cbConceptos);
            this.panel1.Controls.Add(this.lblConceptos);
            this.panel1.Controls.Add(this.txtCantidad);
            this.panel1.Controls.Add(this.lblCantidad);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnRECCA);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(761, 403);
            this.panel1.TabIndex = 0;
            // 
            // btnREACA
            // 
            this.btnREACA.BackColor = System.Drawing.Color.LightSlateGray;
            this.btnREACA.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray;
            this.btnREACA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnREACA.ForeColor = System.Drawing.Color.White;
            this.btnREACA.Location = new System.Drawing.Point(516, 361);
            this.btnREACA.Name = "btnREACA";
            this.btnREACA.Size = new System.Drawing.Size(117, 27);
            this.btnREACA.TabIndex = 67;
            this.btnREACA.Text = "Retiro fondo inicial";
            this.btnREACA.UseVisualStyleBackColor = false;
            this.btnREACA.Click += new System.EventHandler(this.btnRetiroFondoInicial_Click);
            // 
            // btnRERET
            // 
            this.btnRERET.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(152)))), ((int)(((byte)(33)))));
            this.btnRERET.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(135)))), ((int)(((byte)(0)))));
            this.btnRERET.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRERET.ForeColor = System.Drawing.Color.White;
            this.btnRERET.Location = new System.Drawing.Point(402, 361);
            this.btnRERET.Name = "btnRERET";
            this.btnRERET.Size = new System.Drawing.Size(108, 27);
            this.btnRERET.TabIndex = 65;
            this.btnRERET.Text = "Retiro";
            this.btnRERET.UseVisualStyleBackColor = false;
            this.btnRERET.Click += new System.EventHandler(this.btnRERET_Click);
            // 
            // gcAcumulados
            // 
            this.gcAcumulados.Location = new System.Drawing.Point(402, 13);
            this.gcAcumulados.MainView = this.gvAcumulados;
            this.gcAcumulados.MenuManager = this.ribbonControl1;
            this.gcAcumulados.Name = "gcAcumulados";
            this.gcAcumulados.Size = new System.Drawing.Size(345, 322);
            this.gcAcumulados.TabIndex = 64;
            this.gcAcumulados.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvAcumulados});
            // 
            // gvAcumulados
            // 
            this.gvAcumulados.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn5,
            this.gridColumn6});
            this.gvAcumulados.GridControl = this.gcAcumulados;
            this.gvAcumulados.Name = "gvAcumulados";
            this.gvAcumulados.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gvAcumulados.OptionsView.ShowFooter = true;
            this.gvAcumulados.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Concepto";
            this.gridColumn5.FieldName = "concepto";
            this.gridColumn5.MaxWidth = 200;
            this.gridColumn5.MinWidth = 200;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            this.gridColumn5.Width = 200;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Total";
            this.gridColumn6.DisplayFormat.FormatString = "c2";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn6.FieldName = "total";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", "TOTAL={0:c2}")});
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 1;
            this.gridColumn6.Width = 127;
            // 
            // gcPartidas
            // 
            this.gcPartidas.Location = new System.Drawing.Point(14, 65);
            this.gcPartidas.MainView = this.gvPartidas;
            this.gcPartidas.MenuManager = this.ribbonControl1;
            this.gcPartidas.Name = "gcPartidas";
            this.gcPartidas.Size = new System.Drawing.Size(375, 270);
            this.gcPartidas.TabIndex = 63;
            this.gcPartidas.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPartidas});
            // 
            // gvPartidas
            // 
            this.gvPartidas.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gvPartidas.GridControl = this.gcPartidas;
            this.gvPartidas.Name = "gvPartidas";
            this.gvPartidas.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gvPartidas.OptionsView.ShowFooter = true;
            this.gvPartidas.OptionsView.ShowGroupPanel = false;
            this.gvPartidas.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvPartidas_CellValueChanged);
            this.gvPartidas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvPartidas_KeyDown);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Cant";
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn1.FieldName = "cantidad";
            this.gridColumn1.MaxWidth = 50;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 50;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Factor";
            this.gridColumn2.DisplayFormat.FormatString = "c2";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn2.FieldName = "factor";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Producto";
            this.gridColumn3.DisplayFormat.FormatString = "c2";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn3.FieldName = "producto";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "producto", "TOTAL={0:c2}")});
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // cbConceptos
            // 
            this.cbConceptos.Location = new System.Drawing.Point(116, 13);
            this.cbConceptos.Name = "cbConceptos";
            this.cbConceptos.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbConceptos.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nombre", 60, "Concepto")});
            this.cbConceptos.Size = new System.Drawing.Size(273, 20);
            this.cbConceptos.TabIndex = 0;
            this.cbConceptos.EditValueChanged += new System.EventHandler(this.cbConceptos_EditValueChanged);
            // 
            // lblConceptos
            // 
            this.lblConceptos.Location = new System.Drawing.Point(14, 16);
            this.lblConceptos.Name = "lblConceptos";
            this.lblConceptos.Size = new System.Drawing.Size(46, 13);
            this.lblConceptos.TabIndex = 61;
            this.lblConceptos.Text = "Concepto";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(116, 39);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Properties.MaxLength = 20;
            this.txtCantidad.Size = new System.Drawing.Size(273, 20);
            this.txtCantidad.TabIndex = 1;
            this.txtCantidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtImporte_KeyDown);
            // 
            // lblCantidad
            // 
            this.lblCantidad.Location = new System.Drawing.Point(14, 42);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(43, 13);
            this.lblCantidad.TabIndex = 60;
            this.lblCantidad.Text = "Cantidad";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancelar.Location = new System.Drawing.Point(14, 361);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(108, 27);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnRECCA
            // 
            this.btnRECCA.BackColor = System.Drawing.Color.Firebrick;
            this.btnRECCA.FlatAppearance.BorderColor = System.Drawing.Color.Brown;
            this.btnRECCA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRECCA.ForeColor = System.Drawing.Color.White;
            this.btnRECCA.Location = new System.Drawing.Point(639, 361);
            this.btnRECCA.Name = "btnRECCA";
            this.btnRECCA.Size = new System.Drawing.Size(108, 27);
            this.btnRECCA.TabIndex = 2;
            this.btnRECCA.Text = "CORTE Z";
            this.btnRECCA.UseVisualStyleBackColor = false;
            this.btnRECCA.Click += new System.EventHandler(this.btnRECCA_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(785, 427);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.panel1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(765, 407);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // frmArqueo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(785, 476);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.ribbonControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmArqueo";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Arqueo";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcAcumulados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAcumulados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPartidas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPartidas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbConceptos.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
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
        private System.Windows.Forms.Button btnRECCA;
        private DevExpress.XtraEditors.LookUpEdit cbConceptos;
        private DevExpress.XtraEditors.LabelControl lblConceptos;
        private DevExpress.XtraEditors.TextEdit txtCantidad;
        private DevExpress.XtraEditors.LabelControl lblCantidad;
        private DevExpress.XtraGrid.GridControl gcPartidas;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPartidas;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.GridControl gcAcumulados;
        private DevExpress.XtraGrid.Views.Grid.GridView gvAcumulados;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private System.Windows.Forms.Button btnRERET;
        private System.Windows.Forms.Button btnREACA;
    }
}