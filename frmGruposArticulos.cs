using NoriSDK;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Nori
{
	public partial class frmGruposArticulos : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		GrupoArticulo grupo_articulo = new GrupoArticulo();

		public frmGruposArticulos(int id = 0)
		{
			InitializeComponent();
			this.MetodoDinamico();
			CargarListas();
			Permisos();

			if (id != 0)
			{
				grupo_articulo = GrupoArticulo.Obtener(id);
				Cargar();
			}
			else
			{
				Cargar(false, true);
			}
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
				object p = new { fields = "id, codigo, nombre" };
				object o = new { activo = 1 };

				cbGruposArticulos.Properties.DataSource = Utilidades.Busqueda("grupos_articulos", o, p);
				cbGruposArticulos.Properties.ValueMember = "id";
				cbGruposArticulos.Properties.DisplayMember = "nombre";
			}
			catch { }
        }


		private void Cargar(bool nuevo = false, bool busqueda = false)
		{
			try
			{
				lblID.Text = grupo_articulo.id.ToString();

				txtCodigo.Text = grupo_articulo.codigo.ToString();
				txtNombre.Text = grupo_articulo.nombre;
				txtNumeroCuentaAjusteInventario.Text = grupo_articulo.numero_cuenta_ajuste_inventario;
				cbGruposArticulos.EditValue = grupo_articulo.grupo_superior_id;
				udOrden.Value = grupo_articulo.orden;

				if (!grupo_articulo.color.IsNullOrEmpty())
					cpColor.Color = Color.FromArgb(grupo_articulo.color.GetValueOrDefault());

				cbActivo.Checked = grupo_articulo.activo;

				lblFechaActualizacion.Text = grupo_articulo.fecha_actualizacion.ToShortDateString();

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
			catch (Exception ex)
            {
				MessageBox.Show(ex.Message);
            }
		}

		private void Llenar()
		{
			try
			{
				grupo_articulo.codigo = short.Parse(txtCodigo.Text);
				grupo_articulo.nombre = txtNombre.Text;
				grupo_articulo.numero_cuenta_ajuste_inventario = txtNumeroCuentaAjusteInventario.Text;
				grupo_articulo.grupo_superior_id = (cbGruposArticulos.EditValue.IsNullOrEmpty()) ? 0 : (int)cbGruposArticulos.EditValue;
				if (!cpColor.Color.IsEmpty)
					grupo_articulo.color = cpColor.Color.ToArgb();
				grupo_articulo.orden = (int)udOrden.Value;

				grupo_articulo.activo = cbActivo.Checked;
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
					if (grupo_articulo.id != 0)
					{
						return grupo_articulo.Actualizar();
					}
					else
					{
						return grupo_articulo.Agregar();
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
				grupo_articulo = new GrupoArticulo();
				Cargar();
			}
		}

		private void bbiPrimero_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				grupo_articulo = GrupoArticulo.GruposArticulos().OrderBy(x => x.id).First();
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
				grupo_articulo = GrupoArticulo.GruposArticulos().Where(x => x.id < grupo_articulo.id).OrderByDescending(x => x.id).First();
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
				grupo_articulo = GrupoArticulo.GruposArticulos().Where(x => x.id > grupo_articulo.id).First();
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
				grupo_articulo = GrupoArticulo.GruposArticulos().OrderByDescending(x => x.id).First();
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

		private void bbiNuevo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			grupo_articulo = new GrupoArticulo();
			Cargar(true);
		}

		private void Buscar()
		{
			try
			{
				if (grupo_articulo.id != 0)
				{
					grupo_articulo = new GrupoArticulo();
					Cargar(false, true);
				}
				else
				{
					object p = new { fields = "id, codigo, nombre, activo", like = true };
					object o = new { codigo = txtCodigo.Text, nombre = txtNombre.Text };
					DataTable grupos_articulos = Utilidades.Busqueda("grupos_articulos", o, p);
					if (grupos_articulos.Rows.Count > 0)
					{
						if (grupos_articulos.Rows.Count == 1)
						{
							grupo_articulo = GrupoArticulo.Obtener((int)grupos_articulos.Rows[0]["id"]);
							Cargar();
						}
						else
						{
							frmResultadosBusqueda f = new frmResultadosBusqueda(grupos_articulos);
							var result = f.ShowDialog();
							if (result == DialogResult.OK)
							{
								grupo_articulo = GrupoArticulo.Obtener(f.id);
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

		private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && grupo_articulo.id == 0)
				Buscar();
		}
	}
}