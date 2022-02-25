using NoriSDK;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Nori
{
    public partial class frmActivosFijos : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		ActivoFijo activo_fijo = new ActivoFijo();

		public frmActivosFijos(int id = 0)
		{
			InitializeComponent();
			this.MetodoDinamico();

			if (id != 0)
			{
				activo_fijo = ActivoFijo.Obtener(id);
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
				case 'L':
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
                cbGruposArticulos.Properties.DataSource = GrupoArticulo.GruposArticulos().Where(x => x.activo == true).Select(x => new { x.id, x.codigo, x.nombre }).ToList();
                cbGruposArticulos.Properties.ValueMember = "id";
                cbGruposArticulos.Properties.DisplayMember = "nombre";

                cbFabricantes.Properties.DataSource = Fabricante.Fabricantes().Where(x => x.activo == true).Select(x => new { x.id, x.codigo, x.nombre }).ToList();
                cbFabricantes.Properties.ValueMember = "id";
                cbFabricantes.Properties.DisplayMember = "nombre";

                cbPropietarios.Properties.DataSource = Propietario.Propietarios().Where(x => x.activo == true).Select(x => new { x.id, x.codigo, x.nombre }).ToList();
                cbPropietarios.Properties.ValueMember = "id";
                cbPropietarios.Properties.DisplayMember = "nombre";

                cbSocios.Properties.DataSource = Socio.Socios().Where(x => x.activo == true).Select(x => new { x.id, x.codigo, x.nombre }).ToList();
                cbSocios.Properties.ValueMember = "id";
                cbSocios.Properties.DisplayMember = "nombre";

            }
            catch { }
        }

		private void Cargar(bool nuevo = false, bool busqueda = false)
		{
			lblID.Text = activo_fijo.id.ToString();

			txtCodigo.Text = activo_fijo.codigo;
			txtNombre.Text = activo_fijo.nombre;

            cbGruposArticulos.EditValue = activo_fijo.grupo_articulo_id;
            cbFabricantes.EditValue = activo_fijo.fabricante_id;
            cbPropietarios.EditValue = activo_fijo.propietario_id;
            cbSocios.EditValue = activo_fijo.socio_id;

            txtSerie.Text = activo_fijo.serie;
            txtDescripcion.Text = activo_fijo.descripcion;
            txtMarca.Text = activo_fijo.marca;
            txtModelo.Text = activo_fijo.modelo;
            txtComentario.Text = activo_fijo.comentario;
            deFechaAdquisicion.DateTime = activo_fijo.fecha_adquisicion;

			cbActivo.Checked = activo_fijo.activo;

			lblFechaActualizacion.Text = activo_fijo.fecha_actualizacion.ToShortDateString();

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
                activo_fijo.codigo = txtCodigo.Text;
                activo_fijo.nombre = txtNombre.Text;

                activo_fijo.grupo_articulo_id = (int)cbGruposArticulos.EditValue;
                activo_fijo.fabricante_id = (int)cbFabricantes.EditValue;
                activo_fijo.propietario_id = (int)cbPropietarios.EditValue;
                activo_fijo.socio_id = (int)cbSocios.EditValue;

                activo_fijo.serie = txtSerie.Text;
                activo_fijo.descripcion = txtDescripcion.Text;
                activo_fijo.marca = txtMarca.Text;
                activo_fijo.modelo = txtModelo.Text;
                activo_fijo.comentario = txtComentario.Text;
                activo_fijo.fecha_adquisicion = deFechaAdquisicion.DateTime;

                activo_fijo.activo = cbActivo.Checked;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
		}

		private bool Guardar()
		{
			try
			{
				if (MessageBox.Show("¿Desea guardar los cambios?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					Llenar();
					if (activo_fijo.id != 0)
						return activo_fijo.Actualizar();
					else
						return activo_fijo.Agregar();
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
				activo_fijo = new ActivoFijo();
				Cargar();
			}
		}

		private void bbiPrimero_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				activo_fijo = ActivoFijo.ActivosFijos().OrderBy(x => x.id).First();
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
				activo_fijo = ActivoFijo.ActivosFijos().Where(x => x.id < activo_fijo.id).OrderByDescending(x => x.id).First();
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
				activo_fijo = ActivoFijo.ActivosFijos().Where(x => x.id > activo_fijo.id).First();
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
				activo_fijo = ActivoFijo.ActivosFijos().OrderByDescending(x => x.id).First();
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
				if (activo_fijo.id != 0)
				{
					activo_fijo = new ActivoFijo();
					Cargar(false, true);
				}
				else
				{
					object p = new { fields = "id, codigo, nombre, activo", like = true };
					object o = new { codigo = txtCodigo.Text, nombre = txtNombre.Text };
					DataTable activos_fijos = Utilidades.Busqueda("activos_fijos", o, p);
					if (activos_fijos.Rows.Count > 0)
					{
						if (activos_fijos.Rows.Count == 1)
						{
							activo_fijo = ActivoFijo.Obtener((int)activos_fijos.Rows[0]["id"]);
							Cargar();
						}
						else
						{
							frmResultadosBusqueda f = new frmResultadosBusqueda(activos_fijos);
							var result = f.ShowDialog();
							if (result == DialogResult.OK)
							{
								activo_fijo = ActivoFijo.Obtener(f.id);
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
			activo_fijo = new ActivoFijo();
			Cargar(true);
		}

		private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && activo_fijo.id == 0)
				Buscar();
		}
    }
}