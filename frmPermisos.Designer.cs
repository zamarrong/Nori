namespace Nori
{
    partial class frmPermisos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPermisos));
            this.panel1 = new DevExpress.XtraEditors.PanelControl();
            this.gcPermisos = new DevExpress.XtraGrid.GridControl();
            this.gvPermisos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnUsuarioID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cbUsuarios = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumnObjeto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cbObjetos = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumnAgregar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnActualizar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCancelar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnEliminar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnAutorizacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnUsuarioAutorizacionID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnActivo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcPermisos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPermisos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbUsuarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbObjetos)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gcPermisos);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(584, 361);
            this.panel1.TabIndex = 0;
            // 
            // gcPermisos
            // 
            this.gcPermisos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcPermisos.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.gcPermisos_EmbeddedNavigator_ButtonClick);
            this.gcPermisos.Location = new System.Drawing.Point(2, 2);
            this.gcPermisos.MainView = this.gvPermisos;
            this.gcPermisos.Name = "gcPermisos";
            this.gcPermisos.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cbUsuarios,
            this.cbObjetos});
            this.gcPermisos.Size = new System.Drawing.Size(580, 357);
            this.gcPermisos.TabIndex = 0;
            this.gcPermisos.UseEmbeddedNavigator = true;
            this.gcPermisos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPermisos});
            // 
            // gvPermisos
            // 
            this.gvPermisos.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnID,
            this.gridColumnUsuarioID,
            this.gridColumnObjeto,
            this.gridColumnAgregar,
            this.gridColumnActualizar,
            this.gridColumnCancelar,
            this.gridColumnEliminar,
            this.gridColumnAutorizacion,
            this.gridColumnUsuarioAutorizacionID,
            this.gridColumnActivo,
            this.gridColumnFecha});
            this.gvPermisos.GridControl = this.gcPermisos;
            this.gvPermisos.Name = "gvPermisos";
            this.gvPermisos.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gvPermisos.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gvPermisos.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gvPermisos.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gvPermisos.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gvPermisos_InitNewRow);
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
            // gridColumnObjeto
            // 
            this.gridColumnObjeto.Caption = "Objeto";
            this.gridColumnObjeto.ColumnEdit = this.cbObjetos;
            this.gridColumnObjeto.FieldName = "objeto";
            this.gridColumnObjeto.Name = "gridColumnObjeto";
            this.gridColumnObjeto.Visible = true;
            this.gridColumnObjeto.VisibleIndex = 1;
            // 
            // cbObjetos
            // 
            this.cbObjetos.AutoHeight = false;
            this.cbObjetos.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbObjetos.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Key", "Objeto"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", 60, "Nombre")});
            this.cbObjetos.Name = "cbObjetos";
            // 
            // gridColumnAgregar
            // 
            this.gridColumnAgregar.Caption = "Agregar";
            this.gridColumnAgregar.FieldName = "agregar";
            this.gridColumnAgregar.Name = "gridColumnAgregar";
            this.gridColumnAgregar.Visible = true;
            this.gridColumnAgregar.VisibleIndex = 2;
            // 
            // gridColumnActualizar
            // 
            this.gridColumnActualizar.Caption = "Actualizar";
            this.gridColumnActualizar.FieldName = "actualizar";
            this.gridColumnActualizar.Name = "gridColumnActualizar";
            this.gridColumnActualizar.Visible = true;
            this.gridColumnActualizar.VisibleIndex = 3;
            // 
            // gridColumnCancelar
            // 
            this.gridColumnCancelar.Caption = "Cancelar";
            this.gridColumnCancelar.FieldName = "cancelar";
            this.gridColumnCancelar.Name = "gridColumnCancelar";
            this.gridColumnCancelar.Visible = true;
            this.gridColumnCancelar.VisibleIndex = 4;
            // 
            // gridColumnEliminar
            // 
            this.gridColumnEliminar.Caption = "Eliminar";
            this.gridColumnEliminar.FieldName = "eliminar";
            this.gridColumnEliminar.Name = "gridColumnEliminar";
            this.gridColumnEliminar.Visible = true;
            this.gridColumnEliminar.VisibleIndex = 5;
            // 
            // gridColumnAutorizacion
            // 
            this.gridColumnAutorizacion.Caption = "Autorización";
            this.gridColumnAutorizacion.FieldName = "autorizacion";
            this.gridColumnAutorizacion.Name = "gridColumnAutorizacion";
            this.gridColumnAutorizacion.Visible = true;
            this.gridColumnAutorizacion.VisibleIndex = 6;
            // 
            // gridColumnUsuarioAutorizacionID
            // 
            this.gridColumnUsuarioAutorizacionID.Caption = "Usuario autorización";
            this.gridColumnUsuarioAutorizacionID.ColumnEdit = this.cbUsuarios;
            this.gridColumnUsuarioAutorizacionID.FieldName = "usuario_autorizacion_id";
            this.gridColumnUsuarioAutorizacionID.Name = "gridColumnUsuarioAutorizacionID";
            this.gridColumnUsuarioAutorizacionID.Visible = true;
            this.gridColumnUsuarioAutorizacionID.VisibleIndex = 7;
            // 
            // gridColumnActivo
            // 
            this.gridColumnActivo.Caption = "Activo";
            this.gridColumnActivo.FieldName = "activo";
            this.gridColumnActivo.Name = "gridColumnActivo";
            this.gridColumnActivo.Visible = true;
            this.gridColumnActivo.VisibleIndex = 8;
            // 
            // gridColumnFecha
            // 
            this.gridColumnFecha.Caption = "Fecha";
            this.gridColumnFecha.FieldName = "fecha_actualizacion";
            this.gridColumnFecha.Name = "gridColumnFecha";
            this.gridColumnFecha.Visible = true;
            this.gridColumnFecha.VisibleIndex = 9;
            // 
            // frmPermisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPermisos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Permisos";
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcPermisos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPermisos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbUsuarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbObjetos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panel1;
        private DevExpress.XtraGrid.GridControl gcPermisos;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPermisos;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnUsuarioID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cbUsuarios;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnActivo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnObjeto;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cbObjetos;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnAgregar;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnActualizar;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnEliminar;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnFecha;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnAutorizacion;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnUsuarioAutorizacionID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCancelar;
    }
}