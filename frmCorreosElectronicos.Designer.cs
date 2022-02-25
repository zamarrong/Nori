namespace Nori
{
    partial class frmCorreosElectronicos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCorreosElectronicos));
            this.panel1 = new DevExpress.XtraEditors.PanelControl();
            this.gcCorreosElectronicos = new DevExpress.XtraGrid.GridControl();
            this.gvCorreosElectronicos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnUsuarioID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cbUsuarios = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumnServidor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPuerto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSSL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnUsuario = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnContraseña = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnActivo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnRemitente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnAsunto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnMensaje = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcCorreosElectronicos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCorreosElectronicos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gcCorreosElectronicos);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(584, 361);
            this.panel1.TabIndex = 0;
            // 
            // gcCorreosElectronicos
            // 
            this.gcCorreosElectronicos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcCorreosElectronicos.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.gcCorreosElectronicos_EmbeddedNavigator_ButtonClick);
            this.gcCorreosElectronicos.Location = new System.Drawing.Point(2, 2);
            this.gcCorreosElectronicos.MainView = this.gvCorreosElectronicos;
            this.gcCorreosElectronicos.Name = "gcCorreosElectronicos";
            this.gcCorreosElectronicos.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cbUsuarios});
            this.gcCorreosElectronicos.Size = new System.Drawing.Size(580, 357);
            this.gcCorreosElectronicos.TabIndex = 0;
            this.gcCorreosElectronicos.UseEmbeddedNavigator = true;
            this.gcCorreosElectronicos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCorreosElectronicos});
            // 
            // gvCorreosElectronicos
            // 
            this.gvCorreosElectronicos.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnID,
            this.gridColumnUsuarioID,
            this.gridColumnServidor,
            this.gridColumnPuerto,
            this.gridColumnSSL,
            this.gridColumnUsuario,
            this.gridColumnContraseña,
            this.gridColumnRemitente,
            this.gridColumnAsunto,
            this.gridColumnMensaje,
            this.gridColumnActivo});
            this.gvCorreosElectronicos.GridControl = this.gcCorreosElectronicos;
            this.gvCorreosElectronicos.Name = "gvCorreosElectronicos";
            this.gvCorreosElectronicos.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gvCorreosElectronicos.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gvCorreosElectronicos.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gvCorreosElectronicos.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
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
            // gridColumnServidor
            // 
            this.gridColumnServidor.Caption = "Servidor";
            this.gridColumnServidor.FieldName = "servidor";
            this.gridColumnServidor.Name = "gridColumnServidor";
            this.gridColumnServidor.Visible = true;
            this.gridColumnServidor.VisibleIndex = 1;
            // 
            // gridColumnPuerto
            // 
            this.gridColumnPuerto.Caption = "Puerto";
            this.gridColumnPuerto.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnPuerto.FieldName = "puerto";
            this.gridColumnPuerto.Name = "gridColumnPuerto";
            this.gridColumnPuerto.Visible = true;
            this.gridColumnPuerto.VisibleIndex = 2;
            // 
            // gridColumnSSL
            // 
            this.gridColumnSSL.Caption = "SSL";
            this.gridColumnSSL.FieldName = "ssl";
            this.gridColumnSSL.Name = "gridColumnSSL";
            this.gridColumnSSL.Visible = true;
            this.gridColumnSSL.VisibleIndex = 3;
            // 
            // gridColumnUsuario
            // 
            this.gridColumnUsuario.Caption = "Correo electrónico";
            this.gridColumnUsuario.FieldName = "usuario";
            this.gridColumnUsuario.Name = "gridColumnUsuario";
            this.gridColumnUsuario.Visible = true;
            this.gridColumnUsuario.VisibleIndex = 4;
            // 
            // gridColumnContraseña
            // 
            this.gridColumnContraseña.Caption = "Contraseña";
            this.gridColumnContraseña.FieldName = "contraseña";
            this.gridColumnContraseña.Name = "gridColumnContraseña";
            this.gridColumnContraseña.Visible = true;
            this.gridColumnContraseña.VisibleIndex = 5;
            // 
            // gridColumnActivo
            // 
            this.gridColumnActivo.Caption = "Activo";
            this.gridColumnActivo.FieldName = "activo";
            this.gridColumnActivo.Name = "gridColumnActivo";
            this.gridColumnActivo.Visible = true;
            this.gridColumnActivo.VisibleIndex = 9;
            // 
            // gridColumnRemitente
            // 
            this.gridColumnRemitente.Caption = "Remitente";
            this.gridColumnRemitente.FieldName = "remitente";
            this.gridColumnRemitente.Name = "gridColumnRemitente";
            this.gridColumnRemitente.Visible = true;
            this.gridColumnRemitente.VisibleIndex = 6;
            // 
            // gridColumnAsunto
            // 
            this.gridColumnAsunto.Caption = "Asunto";
            this.gridColumnAsunto.FieldName = "asunto";
            this.gridColumnAsunto.Name = "gridColumnAsunto";
            this.gridColumnAsunto.Visible = true;
            this.gridColumnAsunto.VisibleIndex = 7;
            // 
            // gridColumnMensaje
            // 
            this.gridColumnMensaje.Caption = "Mensaje";
            this.gridColumnMensaje.FieldName = "mensaje";
            this.gridColumnMensaje.Name = "gridColumnMensaje";
            this.gridColumnMensaje.Visible = true;
            this.gridColumnMensaje.VisibleIndex = 8;
            // 
            // frmCorreosElectronicos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCorreosElectronicos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Correos electrónicos";
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcCorreosElectronicos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCorreosElectronicos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbUsuarios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panel1;
        private DevExpress.XtraGrid.GridControl gcCorreosElectronicos;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCorreosElectronicos;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnUsuarioID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cbUsuarios;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnServidor;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPuerto;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSSL;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnUsuario;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnContraseña;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnActivo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnRemitente;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnAsunto;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnMensaje;
    }
}