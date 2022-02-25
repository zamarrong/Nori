using NoriSDK;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Nori
{
	public partial class frmAcceder : DevExpress.XtraBars.Ribbon.RibbonForm
	{

		ConnectionStringSettingsCollection conexiones;
		public frmAcceder()
		{
			InitializeComponent();
			this.MetodoDinamico();

			lblVersion.Text = "V 18.12.91.16";

			Cargar();
		}

		private void CargarConexiones()
		{
			ConfigurationManager.RefreshSection("connectionStrings");
			conexiones = ConfigurationManager.ConnectionStrings;
		}

		private void Cargar()
		{
			try
			{
				CargarConexiones();
				if (conexiones.Count != 0)
				{
					cbConexiones.Properties.DataSource = conexiones;
					cbConexiones.Properties.ValueMember = "Name";
					cbConexiones.Properties.DisplayMember = "Name";

					cbConexiones.EditValue = conexiones[0].Name;
				}
			} catch { }
		}

		private void btnAcceder_Click(object sender, EventArgs e)
		{
			if (!Program.Nori.Conectar())
			{
				MessageBox.Show(NoriSDK.Nori.ObtenerUltimoError().Message, Application.ProductName);
			}
			else
			{
				Usuario usuario = new Usuario();
				usuario.usuario = txtUsuario.Text;
				usuario.contraseña = txtContraseña.Text;

				if (usuario.usuario.Length > 0 && usuario.contraseña.Length > 0)
					acceder(Program.Nori.Autenticar(usuario));
				else if (txtUsuario.Text.Length > 0 && Program.Nori.Estacion.lector_huella)
					acceder(Funciones.AccederConHuella(usuario));
				else
					MessageBox.Show("Ingrese un nombre de usuario y contraseña.", Text);
			}
		}

		private void acceder(bool r)
		{
			if (r)
			{
				try
				{
					if (Program.Nori.Configuracion.tema.Length > 0)
						defaultLookAndFeel1.LookAndFeel.SkinMaskColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Program.Nori.Configuracion.tema));
				}
				catch { }

				if (Program.Nori.UsuarioAutenticado.rol == 'X')
				{
					frmSincronizacion f = new frmSincronizacion();
					f.Show();
				}
				else
				{
					if (Program.Nori.Configuracion.seleccionar_sucursal)
					{
						frmSeleccionarSucural fs = new frmSeleccionarSucural();
						fs.ShowDialog();
					}

					frmPrincipal f = new frmPrincipal();
					f.Show();

					txtUsuario.Text = string.Empty;
					txtContraseña.Text = string.Empty;
				}

				Hide();
			}
			else
			{
				txtContraseña.Text = string.Empty;
				txtContraseña.Focus();
				MessageBox.Show(NoriSDK.Nori.ObtenerUltimoError().Message, Text);
			}
		}

		private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
		{

			try
			{
				if (e.Control && e.KeyCode == Keys.S && txtUsuario.Text.Length > 0)
				{
					Usuario usuario = Usuario.Usuarios().Where(x => x.usuario == txtUsuario.Text).First();
					if (usuario.rol == 'A')
					{
						frmAutenticar f = new frmAutenticar();
						f.usuario = usuario;
						f.ShowDialog();
						if (f.DialogResult == DialogResult.OK)
						{
							Program.Nori.EstablecerUsuario(f.usuario);

							acceder(true);
						}
					}
				}
			} catch { }
		}

		private void frmAcceder_FormClosed(object sender, FormClosedEventArgs e)
		{
			Funciones.MatarProcesos();
		}

		private void lblConexion_Click(object sender, EventArgs e)
		{
			frmConexiones f = new frmConexiones();
			f.ShowDialog();
			CargarConexiones();
		}

		private void cbConexiones_EditValueChanged(object sender, EventArgs e)
		{
			Program.Nori.Conexion = new SqlConnectionStringBuilder(conexiones[cbConexiones.EditValue.ToString()].ConnectionString);
		}

		private void frmAcceder_Load(object sender, EventArgs e)
		{
			this.Activate();
		}
	}
}