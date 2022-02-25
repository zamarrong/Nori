using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Nori
{
    public partial class frmConexiones : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        ConnectionStringSettingsCollection conexiones;
        public frmConexiones()
        {
            InitializeComponent();
			this.MetodoDinamico();
            Cargar();
        }

        private void bbiNuevo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Inicializar();
        }

        private void CargarConexiones()
        {
            conexiones = ConfigurationManager.ConnectionStrings;
        }

        private void Cargar()
        {
            CargarConexiones();
            if (conexiones.Count != 0)
            {
                cbConexiones.Properties.DataSource = conexiones;
                cbConexiones.Properties.ValueMember = "Name";
                cbConexiones.Properties.DisplayMember = "Name";
            }
        }

        private void Inicializar()
        {
            cbConexiones.Properties.DataSource = null;
            txtNombre.Text = string.Empty;
            txtServidor.Text = string.Empty;
            txtBD.Text = string.Empty;
            txtUsuario.Text = string.Empty;
            txtContraseña.Text = string.Empty;
            cbSeguridadIntegrada.Checked = false;
        }

        private void cbConexiones_EditValueChanged(object sender, System.EventArgs e)
        {
            try
            {
                SqlConnectionStringBuilder conexion = new SqlConnectionStringBuilder(conexiones[cbConexiones.EditValue.ToString()].ConnectionString);

                txtNombre.Text = cbConexiones.EditValue.ToString();
                txtServidor.Text = conexion.DataSource;
                txtBD.Text = conexion.InitialCatalog;
                txtUsuario.Text = conexion.UserID;
                txtContraseña.Text = conexion.Password;
                cbSeguridadIntegrada.Checked = conexion.IntegratedSecurity;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Guardar()
        {
            try
            {
                SqlConnectionStringBuilder conexion = new SqlConnectionStringBuilder();
                ConnectionStringSettings css = new ConnectionStringSettings();
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                ConnectionStringsSection conSettings = (ConnectionStringsSection)config.GetSection("connectionStrings");

                conexion.DataSource = txtServidor.Text;
                conexion.InitialCatalog = txtBD.Text;
                conexion.UserID = txtUsuario.Text;
                conexion.Password = txtContraseña.Text;
                conexion.IntegratedSecurity = cbSeguridadIntegrada.Checked;

                css.ConnectionString = conexion.ConnectionString;
                css.Name = txtNombre.Text;
                css.ProviderName = "System.Data.SqlClient";

                if (conSettings.ConnectionStrings[txtNombre.Text] != null)
                {
                    conSettings.ConnectionStrings[txtNombre.Text].ConnectionString = conexion.ConnectionString;
                }
                else
                {
                    conSettings.ConnectionStrings.Add(css);
                }

                config.Save(ConfigurationSaveMode.Full);
                ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);

                Cargar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bbiGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Guardar();
        }

        private void bbiGuardarCerrar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Guardar();
            Close();
        }

        private void bbiGuardarNuevo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Guardar();
            Inicializar();
        }
    }
}