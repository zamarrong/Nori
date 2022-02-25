using NoriSDK;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Nori
{
    public partial class frmUbicaciones : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		Almacen.Ubicacion ubicacion = new Almacen.Ubicacion();

		public frmUbicaciones(int id = 0)
		{
			InitializeComponent();
			this.MetodoDinamico();

			if (id != 0)
			{
				ubicacion = Almacen.Ubicacion.Obtener(id);
				Cargar();
			}
			else
			{
				Cargar(false, true);
			}

            CargarListas();

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

		private void CargarListas()
		{
			try
			{
                cbAlmacenes.Properties.DataSource = Almacen.Almacenes().Where(x => x.activo == true).Select(x => new { x.id, x.codigo, x.nombre }).ToList();
                cbAlmacenes.Properties.ValueMember = "id";
                cbAlmacenes.Properties.DisplayMember = "nombre";
            }
			catch
			{

			}
		}


		private void Cargar(bool nuevo = false, bool busqueda = false)
		{
			lblID.Text = ubicacion.id.ToString();

			txtCodigo.Text = ubicacion.codigo.ToString();
            txtUbicacion.Text = ubicacion.ubicacion;
            cbAlmacenes.EditValue = ubicacion.almacen_id;

			cbActivo.Checked = ubicacion.activo;

			lblFechaActualizacion.Text = ubicacion.fecha_actualizacion.ToShortDateString();

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
			ubicacion.codigo = int.Parse(txtCodigo.Text);
			ubicacion.ubicacion = txtUbicacion.Text;
			ubicacion.almacen_id = (cbAlmacenes.EditValue.IsNullOrEmpty()) ? 0 : (int)cbAlmacenes.EditValue;
			ubicacion.activo = cbActivo.Checked;
		}

		private bool Guardar()
		{
			try
			{
				if (MessageBox.Show("¿Desea guardar los cambios?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					Llenar();
					if (ubicacion.id != 0)
						return ubicacion.Actualizar();
					else
						return ubicacion.Agregar();
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
				ubicacion = new Almacen.Ubicacion();
				Cargar();
			}
		}

		private void bbiPrimero_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				ubicacion = Almacen.Ubicacion.Ubicaciones().OrderBy(x => x.id).First();
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
				ubicacion = Almacen.Ubicacion.Ubicaciones().Where(x => x.id < ubicacion.id).OrderByDescending(x => x.id).First();
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
				ubicacion = Almacen.Ubicacion.Ubicaciones().Where(x => x.id > ubicacion.id).First();
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
				ubicacion = Almacen.Ubicacion.Ubicaciones().OrderByDescending(x => x.id).First();
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
				if (ubicacion.id != 0)
				{
					ubicacion = new Almacen.Ubicacion();
					Cargar(false, true);
				}
				else
				{
					object p = new { fields = "id, codigo, nombre, activo", like = true };
					object o = new { codigo = txtCodigo.Text, nombre = txtUbicacion.Text };
					DataTable ubicaciones = Utilidades.Busqueda("ubicaciones", o, p);
					if (ubicaciones.Rows.Count > 0)
					{
						if (ubicaciones.Rows.Count == 1)
						{
							ubicacion = Almacen.Ubicacion.Obtener((int)ubicaciones.Rows[0]["id"]);
							Cargar();
						}
						else
						{
							frmResultadosBusqueda f = new frmResultadosBusqueda(ubicaciones);
							var result = f.ShowDialog();
							if (result == DialogResult.OK)
							{
								ubicacion = Almacen.Ubicacion.Obtener(f.id);
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
			ubicacion = new Almacen.Ubicacion();
			Cargar(true);
		}

		private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && ubicacion.id == 0)
				Buscar();
		}
	}
}