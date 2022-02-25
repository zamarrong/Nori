namespace Nori
{
    partial class frmSincronizacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSincronizacion));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiRestablecerErrores = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEliminar = new DevExpress.XtraBars.BarButtonItem();
            this.bbiAgregarBajada = new DevExpress.XtraBars.BarButtonItem();
            this.barHeaderItem1 = new DevExpress.XtraBars.BarHeaderItem();
            this.bbiAregarSubida = new DevExpress.XtraBars.BarButtonItem();
            this.popupMenuSincronizacion = new DevExpress.XtraBars.PopupMenu(this.components);
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.lbLogs = new System.Windows.Forms.ListBox();
            this.gcSincronizacion = new DevExpress.XtraGrid.GridControl();
            this.gvSincronizacion = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.bw = new System.ComponentModel.BackgroundWorker();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuSincronizacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcSincronizacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSincronizacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.bbiRestablecerErrores,
            this.bbiEliminar,
            this.bbiAgregarBajada,
            this.barHeaderItem1,
            this.bbiAregarSubida});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 7;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.OfficeUniversal;
            this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.Size = new System.Drawing.Size(698, 49);
            // 
            // bbiRestablecerErrores
            // 
            this.bbiRestablecerErrores.Caption = "Restablecer mensajes de error";
            this.bbiRestablecerErrores.Id = 1;
            this.bbiRestablecerErrores.ImageUri.Uri = "Reset";
            this.bbiRestablecerErrores.Name = "bbiRestablecerErrores";
            this.bbiRestablecerErrores.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiRestablecerErrores_ItemClick);
            // 
            // bbiEliminar
            // 
            this.bbiEliminar.Caption = "Eliminar registro";
            this.bbiEliminar.Id = 2;
            this.bbiEliminar.ImageUri.Uri = "Delete";
            this.bbiEliminar.Name = "bbiEliminar";
            this.bbiEliminar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiEliminar_ItemClick);
            // 
            // bbiAgregarBajada
            // 
            this.bbiAgregarBajada.Caption = "Agregar a bajada";
            this.bbiAgregarBajada.Id = 4;
            this.bbiAgregarBajada.ImageUri.Uri = "AlignVerticalLeft";
            this.bbiAgregarBajada.Name = "bbiAgregarBajada";
            this.bbiAgregarBajada.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiAgregarBajada_ItemClick);
            // 
            // barHeaderItem1
            // 
            this.barHeaderItem1.Caption = "Acciones";
            this.barHeaderItem1.Id = 5;
            this.barHeaderItem1.Name = "barHeaderItem1";
            // 
            // bbiAregarSubida
            // 
            this.bbiAregarSubida.Caption = "Agregar a subida";
            this.bbiAregarSubida.Id = 6;
            this.bbiAregarSubida.ImageUri.Uri = "AlignVerticalRight";
            this.bbiAregarSubida.Name = "bbiAregarSubida";
            this.bbiAregarSubida.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiAregarSubida_ItemClick);
            // 
            // popupMenuSincronizacion
            // 
            this.popupMenuSincronizacion.ItemLinks.Add(this.barHeaderItem1);
            this.popupMenuSincronizacion.ItemLinks.Add(this.bbiAgregarBajada);
            this.popupMenuSincronizacion.ItemLinks.Add(this.bbiAregarSubida);
            this.popupMenuSincronizacion.ItemLinks.Add(this.bbiRestablecerErrores);
            this.popupMenuSincronizacion.ItemLinks.Add(this.bbiEliminar);
            this.popupMenuSincronizacion.Name = "popupMenuSincronizacion";
            this.popupMenuSincronizacion.Ribbon = this.ribbonControl1;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.panelControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 49);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(698, 373);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.splitContainerControl1);
            this.panelControl1.Location = new System.Drawing.Point(12, 12);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(674, 349);
            this.panelControl1.TabIndex = 4;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(2, 2);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.lbLogs);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gcSincronizacion);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(670, 345);
            this.splitContainerControl1.SplitterPosition = 319;
            this.splitContainerControl1.TabIndex = 2;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // lbLogs
            // 
            this.lbLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLogs.FormattingEnabled = true;
            this.lbLogs.Location = new System.Drawing.Point(0, 0);
            this.lbLogs.Name = "lbLogs";
            this.lbLogs.Size = new System.Drawing.Size(319, 345);
            this.lbLogs.TabIndex = 2;
            // 
            // gcSincronizacion
            // 
            this.gcSincronizacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcSincronizacion.Location = new System.Drawing.Point(0, 0);
            this.gcSincronizacion.MainView = this.gvSincronizacion;
            this.gcSincronizacion.MenuManager = this.ribbonControl1;
            this.gcSincronizacion.Name = "gcSincronizacion";
            this.gcSincronizacion.Size = new System.Drawing.Size(346, 345);
            this.gcSincronizacion.TabIndex = 1;
            this.gcSincronizacion.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSincronizacion});
            // 
            // gvSincronizacion
            // 
            this.gvSincronizacion.GridControl = this.gcSincronizacion;
            this.gvSincronizacion.Name = "gvSincronizacion";
            this.gvSincronizacion.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(698, 373);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.panelControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(678, 353);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // bw
            // 
            this.bw.WorkerReportsProgress = true;
            this.bw.WorkerSupportsCancellation = true;
            this.bw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_DoWork);
            this.bw.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bw_ProgressChanged);
            this.bw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_RunWorkerCompleted);
            // 
            // timer
            // 
            this.timer.Interval = 10000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // frmSincronizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 422);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.ribbonControl1);
            this.DoubleBuffered = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSincronizacion";
            this.ribbonControl1.SetPopupContextMenu(this, this.popupMenuSincronizacion);
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sincronización SAP Business One";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSincronizacion_FormClosing);
            this.Load += new System.EventHandler(this.frmSincronizacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuSincronizacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcSincronizacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSincronizacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private System.ComponentModel.BackgroundWorker bw;
        private System.Windows.Forms.Timer timer;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private System.Windows.Forms.ListBox lbLogs;
        private DevExpress.XtraGrid.GridControl gcSincronizacion;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSincronizacion;
        private DevExpress.XtraBars.BarButtonItem bbiRestablecerErrores;
        private DevExpress.XtraBars.PopupMenu popupMenuSincronizacion;
        private DevExpress.XtraBars.BarButtonItem bbiEliminar;
        private DevExpress.XtraBars.BarButtonItem bbiAgregarBajada;
        private DevExpress.XtraBars.BarHeaderItem barHeaderItem1;
        private DevExpress.XtraBars.BarButtonItem bbiAregarSubida;
    }
}