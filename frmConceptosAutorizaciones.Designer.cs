namespace Nori
{
    partial class frmConceptosAutorizaciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConceptosAutorizaciones));
            this.panel1 = new DevExpress.XtraEditors.PanelControl();
            this.gcConceptos = new DevExpress.XtraGrid.GridControl();
            this.gvConceptos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnOperador = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnNivelAcceso = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnNombre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cbUsuarios = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumnUsuarioAutorizacion = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcConceptos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvConceptos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gcConceptos);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(584, 361);
            this.panel1.TabIndex = 0;
            // 
            // gcConceptos
            // 
            this.gcConceptos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcConceptos.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.gcCorreosElectronicos_EmbeddedNavigator_ButtonClick);
            this.gcConceptos.Location = new System.Drawing.Point(2, 2);
            this.gcConceptos.MainView = this.gvConceptos;
            this.gcConceptos.Name = "gcConceptos";
            this.gcConceptos.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cbUsuarios});
            this.gcConceptos.Size = new System.Drawing.Size(580, 357);
            this.gcConceptos.TabIndex = 0;
            this.gcConceptos.UseEmbeddedNavigator = true;
            this.gcConceptos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvConceptos});
            // 
            // gvConceptos
            // 
            this.gvConceptos.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnCodigo,
            this.gridColumnOperador,
            this.gridColumnNivelAcceso,
            this.gridColumnNombre,
            this.gridColumnUsuarioAutorizacion});
            this.gvConceptos.GridControl = this.gcConceptos;
            this.gvConceptos.Name = "gvConceptos";
            this.gvConceptos.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvConceptos.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvConceptos.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            // 
            // gridColumnCodigo
            // 
            this.gridColumnCodigo.Caption = "Código";
            this.gridColumnCodigo.FieldName = "codigo";
            this.gridColumnCodigo.Name = "gridColumnCodigo";
            this.gridColumnCodigo.OptionsColumn.AllowEdit = false;
            this.gridColumnCodigo.Visible = true;
            this.gridColumnCodigo.VisibleIndex = 0;
            // 
            // gridColumnOperador
            // 
            this.gridColumnOperador.Caption = "Operador";
            this.gridColumnOperador.FieldName = "operador";
            this.gridColumnOperador.Name = "gridColumnOperador";
            this.gridColumnOperador.Visible = true;
            this.gridColumnOperador.VisibleIndex = 1;
            // 
            // gridColumnNivelAcceso
            // 
            this.gridColumnNivelAcceso.Caption = "Nivel de acceso";
            this.gridColumnNivelAcceso.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnNivelAcceso.FieldName = "nivel_acceso";
            this.gridColumnNivelAcceso.Name = "gridColumnNivelAcceso";
            this.gridColumnNivelAcceso.Visible = true;
            this.gridColumnNivelAcceso.VisibleIndex = 2;
            // 
            // gridColumnNombre
            // 
            this.gridColumnNombre.Caption = "Nombre";
            this.gridColumnNombre.FieldName = "nombre";
            this.gridColumnNombre.Name = "gridColumnNombre";
            this.gridColumnNombre.OptionsColumn.AllowEdit = false;
            this.gridColumnNombre.Visible = true;
            this.gridColumnNombre.VisibleIndex = 3;
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
            // gridColumnUsuarioAutorizacion
            // 
            this.gridColumnUsuarioAutorizacion.Caption = "Usuario autorización";
            this.gridColumnUsuarioAutorizacion.ColumnEdit = this.cbUsuarios;
            this.gridColumnUsuarioAutorizacion.FieldName = "usuario_autorizacion_id";
            this.gridColumnUsuarioAutorizacion.Name = "gridColumnUsuarioAutorizacion";
            this.gridColumnUsuarioAutorizacion.Visible = true;
            this.gridColumnUsuarioAutorizacion.VisibleIndex = 4;
            // 
            // frmConceptosAutorizaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmConceptosAutorizaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conceptos autorizaciónes";
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcConceptos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvConceptos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbUsuarios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panel1;
        private DevExpress.XtraGrid.GridControl gcConceptos;
        private DevExpress.XtraGrid.Views.Grid.GridView gvConceptos;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCodigo;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cbUsuarios;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnOperador;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnNivelAcceso;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnNombre;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnUsuarioAutorizacion;
    }
}