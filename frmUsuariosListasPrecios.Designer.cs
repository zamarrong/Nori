namespace Nori
{
    partial class frmUsuariosListasPrecios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsuariosListasPrecios));
            this.panel1 = new DevExpress.XtraEditors.PanelControl();
            this.gc = new DevExpress.XtraGrid.GridControl();
            this.gv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnUsuarioID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cbUsuarios = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumnListaPrecioID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cbListasPrecios = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumnFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbUsuarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbListasPrecios)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gc);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(584, 361);
            this.panel1.TabIndex = 0;
            // 
            // gc
            // 
            this.gc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.gc_EmbeddedNavigator_ButtonClick);
            this.gc.Location = new System.Drawing.Point(2, 2);
            this.gc.MainView = this.gv;
            this.gc.Name = "gc";
            this.gc.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cbUsuarios,
            this.cbListasPrecios});
            this.gc.Size = new System.Drawing.Size(580, 357);
            this.gc.TabIndex = 0;
            this.gc.UseEmbeddedNavigator = true;
            this.gc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv});
            // 
            // gv
            // 
            this.gv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnID,
            this.gridColumnUsuarioID,
            this.gridColumnListaPrecioID,
            this.gridColumnFecha});
            this.gv.GridControl = this.gc;
            this.gv.Name = "gv";
            this.gv.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gv.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gv.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gv.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            // 
            // gridColumnID
            // 
            this.gridColumnID.Caption = "ID";
            this.gridColumnID.FieldName = "id";
            this.gridColumnID.Name = "gridColumnID";
            // 
            // gridColumnUsuarioID
            // 
            this.gridColumnUsuarioID.Caption = "Usuario";
            this.gridColumnUsuarioID.ColumnEdit = this.cbUsuarios;
            this.gridColumnUsuarioID.FieldName = "usuario_id";
            this.gridColumnUsuarioID.Name = "gridColumnUsuarioID";
            this.gridColumnUsuarioID.Visible = true;
            this.gridColumnUsuarioID.VisibleIndex = 0;
            // 
            // cbUsuarios
            // 
            this.cbUsuarios.AutoHeight = false;
            this.cbUsuarios.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbUsuarios.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("usuario", "Usuario")});
            this.cbUsuarios.Name = "cbUsuarios";
            // 
            // gridColumnListaPrecioID
            // 
            this.gridColumnListaPrecioID.Caption = "Lista precio";
            this.gridColumnListaPrecioID.ColumnEdit = this.cbListasPrecios;
            this.gridColumnListaPrecioID.FieldName = "lista_precio_id";
            this.gridColumnListaPrecioID.Name = "gridColumnListaPrecioID";
            this.gridColumnListaPrecioID.Visible = true;
            this.gridColumnListaPrecioID.VisibleIndex = 1;
            // 
            // cbListasPrecios
            // 
            this.cbListasPrecios.AutoHeight = false;
            this.cbListasPrecios.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbListasPrecios.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("codigo", "Codigo"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nombre", 60, "Nombre")});
            this.cbListasPrecios.Name = "cbListasPrecios";
            // 
            // gridColumnFecha
            // 
            this.gridColumnFecha.Caption = "Fecha";
            this.gridColumnFecha.FieldName = "fecha_actualizacion";
            this.gridColumnFecha.Name = "gridColumnFecha";
            this.gridColumnFecha.Visible = true;
            this.gridColumnFecha.VisibleIndex = 2;
            // 
            // frmUsuariosListasPrecios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmUsuariosListasPrecios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Usuarios - Listas precios";
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbUsuarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbListasPrecios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panel1;
        private DevExpress.XtraGrid.GridControl gc;
        private DevExpress.XtraGrid.Views.Grid.GridView gv;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnUsuarioID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cbUsuarios;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cbListasPrecios;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnFecha;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnListaPrecioID;
    }
}