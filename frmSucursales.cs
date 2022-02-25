using NoriSDK;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Nori
{
    public partial class frmSucursales : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        Sucursal sucursal = new Sucursal();

        public frmSucursales(int id = 0)
        {
            InitializeComponent();
            this.MetodoDinamico();

            if (id != 0)
            {
                sucursal = Sucursal.Obtener(id);
                Cargar();
            }
            else
            {
                Cargar(false, true);
            }

            Permisos();
        }

        private void Permisos()
        {
            switch (Program.Nori.UsuarioAutenticado.rol)
            {
                case 'C':
                    mainRibbonPageGroup.Visible = false;
                    break;
                case 'V':
                    mainRibbonPageGroup.Visible = false;
                    break;
                case 'S':
                    mainRibbonPageGroup.Visible = false;
                    break;
            }
        }

        private void Cargar(bool nuevo = false, bool busqueda = false)
        {
            lblID.Text = sucursal.id.ToString();

            txtCodigo.Text = sucursal.codigo;
            txtNombre.Text = sucursal.nombre;
            txtServidor.Text = sucursal.servidor;
            txtBD.Text = sucursal.bd;
            txtUsuario.Text = sucursal.usuario;
            txtContraseña.Text = sucursal.contraseña;
            udHorario.Value = sucursal.horario;

            cbSoloSubida.Checked = sucursal.solo_subida;
            cbDocumentosBajada.Checked = sucursal.documentos_bajada;
            cbActivo.Checked = sucursal.activo;

            lblFechaActualizacion.Text = sucursal.fecha_actualizacion.ToShortDateString();

            if (nuevo)
            {
                bbiNuevo.Enabled = false;
                bbiGuardar.Enabled = true;
                bbiGuardarCerrar.Enabled = true;
                bbiGuardarNuevo.Enabled = true;
                txtCodigo.Focus();
            }
            else
            {
                if (busqueda)
                {
                    bbiNuevo.Enabled = true;
                    bbiGuardar.Enabled = false;
                    bbiGuardarCerrar.Enabled = false;
                    bbiGuardarNuevo.Enabled = false;
                    txtCodigo.Focus();
                }
                else
                {
                    bbiNuevo.Enabled = true;
                    bbiGuardar.Enabled = true;
                    bbiGuardarCerrar.Enabled = true;
                    bbiGuardarNuevo.Enabled = true;
                }
            }
        }

        private void Llenar()
        {
            try
            {
			    sucursal.codigo = txtCodigo.Text;
			    sucursal.nombre = txtNombre.Text;
			    sucursal.servidor = txtServidor.Text;
			    sucursal.bd = txtBD.Text;
			    sucursal.usuario = txtUsuario.Text;
			    sucursal.contraseña = txtContraseña.Text;
                sucursal.horario = (int)udHorario.Value;
			    sucursal.solo_subida = cbSoloSubida.Checked;
			    sucursal.documentos_bajada = cbDocumentosBajada.Checked;
			    sucursal.activo = cbActivo.Checked;
            } catch { }
		}

		private bool Guardar()
		{
			try
			{
				if (MessageBox.Show("¿Desea guardar los cambios?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					Llenar();
					if (sucursal.id != 0)
						return sucursal.Actualizar();
					else
						return sucursal.Agregar();
				}
				else
					return false;
			}
			catch
			{
				MessageBox.Show(NoriSDK.Nori.ObtenerUltimoError().Message, Text);
				return false;
			}
		}

		private void bbiGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (Guardar()) { Cargar(); } else { MessageBox.Show( "Error al guardar: " + NoriSDK.Nori.ObtenerUltimoError().Message, Text); };
		}

		private void bbiGuardarCerrar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (Guardar())
				Close();
		}

		private void bbiGuardarNuevo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (Guardar())
			{
				sucursal = new Sucursal();
				Cargar();
			}
		}

		private void bbiPrimero_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				sucursal = Sucursal.Sucursales().OrderBy(x => x.id).First();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				Cargar();
			}
		}

		private void bbiAnterior_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				sucursal = Sucursal.Sucursales().Where(x => x.id < sucursal.id).OrderByDescending(x => x.id).First();
				Cargar();
			}
			catch
			{
				bbiUltimo.PerformClick();
			}
		}

		private void bbiSiguiente_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				sucursal = Sucursal.Sucursales().Where(x => x.id > sucursal.id).First();
				Cargar();
			}
			catch
			{
				bbiPrimero.PerformClick();
			}
		}

		private void bbiUltimo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				sucursal = Sucursal.Sucursales().OrderByDescending(x => x.id).First();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				Cargar();
			}
		}

		private void bbiBuscar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			Buscar();
		}

		private void Buscar()
		{
			try
			{
				if (sucursal.id != 0)
				{
					sucursal = new Sucursal();
					Cargar(false, true);
				}
				else
				{
					object p = new { fields = "id, codigo, nombre, activo", like = true };
					object o = new { codigo = txtCodigo.Text, nombre = txtNombre.Text };
					DataTable sucursales = Utilidades.Busqueda("sucursales", o, p);
					if (sucursales.Rows.Count > 0)
					{
						if (sucursales.Rows.Count == 1)
						{
							sucursal = Sucursal.Obtener((int)sucursales.Rows[0]["id"]);
							Cargar();
						}
						else
						{
							frmResultadosBusqueda f = new frmResultadosBusqueda(sucursales);
							var result = f.ShowDialog();
							if (result == DialogResult.OK)
							{
								sucursal = Sucursal.Obtener(f.id);
								Cargar();
							}
						}
					}
					else
					{
						MessageBox.Show("No se encontraron resultados", Text);
					}
				}
			}
			catch { }
		}

		private void bbiNuevo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			sucursal = new Sucursal();
			Cargar(true);
		}

		private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && sucursal.id == 0)
				Buscar();
		}

		private void btnConectar_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("¿Desea realizar una conexión con esta sucursal? (La conexión actual sera finalizada)", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
				Conectar();
		}

		private void Conectar()
		{
			SqlConnectionStringBuilder conexion_original = Program.Nori.Conexion;

			Program.Nori.Conexion.DataSource = @sucursal.servidor;
			Program.Nori.Conexion.InitialCatalog = sucursal.bd;
			if (sucursal.contraseña.IsNullOrEmpty())
				Program.Nori.Conexion.IntegratedSecurity = false;
			Program.Nori.Conexion.UserID = sucursal.usuario;
			Program.Nori.Conexion.Password = sucursal.contraseña;
			Program.Nori.Conexion.ConnectTimeout = 30;

			if (Program.Nori.Conectar())
			{
				MessageBox.Show("Conexión realizada correctamente");
			}
			else
			{
				Program.Nori.Conexion = conexion_original;
				Program.Nori.Conectar();
				MessageBox.Show(string.Format("No fue posible establecer una conexión con la sucursal {0}", sucursal.nombre));
			}
		}
	}
}