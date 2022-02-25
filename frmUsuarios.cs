using NoriSDK;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Nori
{
	public partial class frmUsuarios : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		Usuario usuario = new Usuario();

		public frmUsuarios(int id = 0)
		{
			InitializeComponent();
			this.MetodoDinamico();
			if (id != 0)
			{
				usuario = Usuario.Obtener(id);
				Cargar();
			}
			else
			{
				Cargar(false, true);
			}

			cbRoles.Properties.DataSource = Usuario.Rol.Roles();
			cbRoles.Properties.ValueMember = "rol";
			cbRoles.Properties.DisplayMember = "nombre";
			cbRoles.EditValue = Usuario.Rol.ObtenerPredeterminado();

			cbAlmacenes.Properties.DataSource = Almacen.Almacenes().Where(x => x.activo == true).Select(x => new { x.id, x.codigo, x.nombre }).ToList();
			cbAlmacenes.Properties.ValueMember = "id";
			cbAlmacenes.Properties.DisplayMember = "nombre";

			cbVendedores.Properties.DataSource = Vendedor.Vendedores().Where(x => x.activo == true).Select(x => new { x.id, x.nombre }).ToList();
			cbVendedores.Properties.ValueMember = "id";
			cbVendedores.Properties.DisplayMember = "nombre";

			cbSocios.Properties.DataSource = Socio.Socios().Where(x => x.activo == true).Select(x => new { x.id, x.codigo, x.nombre }).ToList();
			cbSocios.Properties.ValueMember = "id";
			cbSocios.Properties.DisplayMember = "nombre";

			cbEstados.Properties.DataSource = Estado.Estados().Select(x => new { x.id, x.codigo, x.nombre }).ToList();
			cbEstados.Properties.ValueMember = "id";
			cbEstados.Properties.DisplayMember = "nombre";

			cbClasesExpedicion.Properties.DataSource = ClaseExpedicion.ClasesExpedicion().Select(x => new { x.id, x.codigo, x.nombre }).ToList();
			cbClasesExpedicion.Properties.ValueMember = "id";
			cbClasesExpedicion.Properties.DisplayMember = "nombre";

			cbSucursales.Properties.DataSource = Sucursal.Sucursales().Select(x => new { x.id, x.nombre }).ToList();
			cbSucursales.Properties.ValueMember = "id";
			cbSucursales.Properties.DisplayMember = "nombre";
		}

		private void Cargar(bool nuevo = false, bool busqueda = false)
		{
			lblID.Text = usuario.id.ToString();

			txtUsuario.Text = usuario.usuario;
			txtCodigo.Text = usuario.codigo.ToString();
			cbRoles.EditValue = usuario.rol;
			cbAlmacenes.EditValue = usuario.almacen_id;

			cbUbicaciones.Properties.DataSource = Almacen.Ubicacion.Ubicaciones().Where(x => x.almacen_id == usuario.almacen_id && x.activo == true).Select(x => new { x.id, x.codigo, x.ubicacion }).ToList();
			cbUbicaciones.Properties.ValueMember = "id";
			cbUbicaciones.Properties.DisplayMember = "ubicacion";

			cbUbicaciones.EditValue = usuario.ubicacion_id;
			cbSocios.EditValue = usuario.socio_id;
			cbEstados.EditValue = usuario.estado_id;
			cbVendedores.EditValue = usuario.vendedor_id;
			cbClasesExpedicion.EditValue = usuario.clase_expedicion_id;
			cbSucursales.EditValue = usuario.sucursal_id;
			txtNombre.Text = usuario.nombre;
			txtCorreo.Text = usuario.correo;
			txtContraseña.Text = usuario.ObtenerContraseña();
			txtEscritorio.Text = usuario.escritorio;
			txtDispositivo.Text = usuario.dispositivo;

			txtNormaReparto.Text = usuario.norma_reparto;

			cbSuscribirAutorizaciones.Checked = usuario.suscribir_autorizaciones;
			cbActivo.Checked = usuario.activo;

			lblFechaActualizacion.Text = usuario.fecha_actualizacion.ToShortDateString();

			if (nuevo)
			{
				bbiNuevo.Enabled = false;
				bbiGuardar.Enabled = true;
				bbiGuardarCerrar.Enabled = true;
				bbiGuardarNuevo.Enabled = true;
				txtUsuario.Enabled = true;
				txtUsuario.Focus();
			}
			else
			{
				if (busqueda)
				{
					bbiNuevo.Enabled = true;
					bbiGuardar.Enabled = false;
					bbiGuardarCerrar.Enabled = false;
					bbiGuardarNuevo.Enabled = false;
					txtUsuario.Enabled = true;
					txtUsuario.Focus();
				}
				else
				{
					bbiNuevo.Enabled = true;
					bbiGuardar.Enabled = true;
					bbiGuardarCerrar.Enabled = true;
					bbiGuardarNuevo.Enabled = true;
					txtUsuario.Enabled = false;
				}
			}
		}

		private void Llenar()
		{
			usuario.usuario = txtUsuario.Text;
			usuario.codigo = int.Parse(txtCodigo.Text);
			usuario.rol = (char)cbRoles.EditValue;
			usuario.almacen_id = (cbAlmacenes.EditValue.IsNullOrEmpty()) ? 0 : (int)cbAlmacenes.EditValue;
			usuario.ubicacion_id = (cbUbicaciones.EditValue.IsNullOrEmpty()) ? 0 : (int)cbUbicaciones.EditValue;
			usuario.vendedor_id = (cbVendedores.EditValue.IsNullOrEmpty()) ? 0 : (int)cbVendedores.EditValue;
			usuario.socio_id = (cbSocios.EditValue.IsNullOrEmpty()) ? 0 : (int)cbSocios.EditValue;
			usuario.estado_id = (cbEstados.EditValue.IsNullOrEmpty()) ? 0 : (int)cbEstados.EditValue;
			usuario.clase_expedicion_id = (cbClasesExpedicion.EditValue.IsNullOrEmpty()) ? 0 : (int)cbClasesExpedicion.EditValue;
			usuario.sucursal_id = (cbSucursales.EditValue.IsNullOrEmpty()) ? 0 : (int)cbSucursales.EditValue;
			usuario.nombre = txtNombre.Text;
			usuario.correo = txtCorreo.Text;
			usuario.contraseña = txtContraseña.Text;
			usuario.escritorio = txtEscritorio.Text;
			usuario.dispositivo = txtDispositivo.Text;

			usuario.norma_reparto = txtNormaReparto.Text;

			usuario.suscribir_autorizaciones = cbSuscribirAutorizaciones.Checked;
			usuario.activo = cbActivo.Checked;
		}

		private bool Guardar()
		{
			try
			{
				if (MessageBox.Show("¿Desea guardar los cambios?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes && txtContraseña.Text.Length > 0 && txtUsuario.Text.Length > 0)
				{
					Llenar();
					if (usuario.id != 0)
					{
						return usuario.Actualizar();
					}
					else
					{
						return usuario.Agregar();
					}
				}
				else
				{
					return false;
				}
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
			{
				Close();
			}
		}

		private void bbiGuardarNuevo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (Guardar())
			{
				usuario = new Usuario();
				Cargar();
			}
		}

		private void bbiPrimero_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				usuario = Usuario.Usuarios().OrderBy(x => x.id).First();
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
				usuario = Usuario.Usuarios().Where(x => x.id < usuario.id).OrderByDescending(x => x.id).First();
			}
			catch
			{
				bbiUltimo.PerformClick();
			}
			finally
			{
				Cargar();
			}
		}

		private void bbiSiguiente_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				usuario = Usuario.Usuarios().Where(x => x.id > usuario.id).First();
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
				usuario = Usuario.Usuarios().OrderByDescending(x => x.id).First();
				Cargar();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
				if (usuario.id != 0)
				{
					usuario = new Usuario();
					Cargar(false, true);
				}
				else
				{
					object p = new { fields = "id, usuario, nombre, rol, activo", like = true };
					object o = new { usuario = txtUsuario.Text, nombre = txtNombre.Text };
					DataTable usuarios = Utilidades.Busqueda("usuarios", o, p);
					if (usuarios.Rows.Count > 0)
					{
						if (usuarios.Rows.Count == 1)
						{
							usuario = Usuario.Obtener((int)usuarios.Rows[0]["id"]);
							Cargar();
						}
						else
						{
							frmResultadosBusqueda f = new frmResultadosBusqueda(usuarios);
							var result = f.ShowDialog();
							if (result == DialogResult.OK)
							{
								usuario = Usuario.Obtener(f.id);
								Cargar();
							}
						}
					}
					else
					{
						MessageBox.Show("No se encontraron resultados.", Text);
					}
				}
			}
			catch { }
		}

		private void bbiNuevo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			usuario = new Usuario();
			Cargar(true);
		}

		private void cbMostrarContraseña_CheckedChanged(object sender, EventArgs e)
		{
			txtContraseña.Properties.PasswordChar = cbMostrarContraseña.Checked ? '\0' : '*';
		}

		private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && usuario.id == 0)
				Buscar();
		}

		private void btnHuellaDigital_Click(object sender, EventArgs e)
		{
			if (Program.Nori.Estacion.lector_huella)
			{
				HuellaDigital.frmHuellaDigitalAgregar f = new HuellaDigital.frmHuellaDigitalAgregar();
				var result = f.ShowDialog();
				if (result == DialogResult.OK)
				{
					usuario.huella_digital = f.huella_digital;
				}
			}
			else
			{
				MessageBox.Show("El lector de huella no esta habilitado para esta estación.");
			}
		}

		private void btnLiberarSesion_Click(object sender, EventArgs e)
		{
			if (usuario.id != 0)
			{
				if (usuario.LiberarSesion())
				{
					MessageBox.Show("Sesión liberada correctamente.");
				}
			}
		}

		private void bbiCorreosElectronicos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			frmCorreosElectronicos f = new frmCorreosElectronicos();
			f.Show();
		}

		private void txtEscritorio_DoubleClick(object sender, EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter = "XML (*.xml) | *.xml";
			dialog.Title = "Por favor seleccione un archivo.";
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				if (dialog.FileName.Length > 260)
					MessageBox.Show("La ruta es mayor de 260 caracteres, por favor seleccione una ruta más corta");
				else
					txtEscritorio.Text = dialog.FileName;
			}
		}

		private void bbiPermisos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			frmPermisos f = new frmPermisos();
			f.Show();
		}

		private void lblUbicaciones_Click(object sender, EventArgs e)
		{
			frmUbicaciones f = new frmUbicaciones((cbUbicaciones.EditValue.IsNullOrEmpty()) ? 0 : (int)cbUbicaciones.EditValue);
			f.ShowDialog();
		}

        private void bbiConceptosAutorizaciones_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmConceptosAutorizaciones f = new frmConceptosAutorizaciones();
            f.Show();
        }
	}
}