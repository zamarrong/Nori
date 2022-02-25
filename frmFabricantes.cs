using NoriSDK;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Nori
{
	public partial class frmFabricantes : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		Fabricante fabricante = new Fabricante();

		public frmFabricantes(int id = 0)
		{
			InitializeComponent();
			this.MetodoDinamico();
			if (id != 0)
			{
				fabricante = Fabricante.Obtener(id);
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
			lblID.Text = fabricante.id.ToString();

			txtCodigo.Text = fabricante.codigo.ToString();
			txtNombre.Text = fabricante.nombre;
			cbActivo.Checked = fabricante.activo;

			lblFechaActualizacion.Text = fabricante.fecha_actualizacion.ToShortDateString();

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
			fabricante.codigo = short.Parse(txtCodigo.Text);
			fabricante.nombre = txtNombre.Text;
			fabricante.activo = cbActivo.Checked;
		}

		private bool Guardar()
		{
			try
			{
				if (MessageBox.Show("¿Desea guardar los cambios?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					Llenar();
					if (fabricante.id != 0)
					{
						return fabricante.Actualizar();
					}
					else
					{
						return fabricante.Agregar();
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
				fabricante = new Fabricante();
				Cargar();
			}
		}

		private void bbiPrimero_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				fabricante = Fabricante.Fabricantes().OrderBy(x => x.id).First();
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
				fabricante = Fabricante.Fabricantes().Where(x => x.id < fabricante.id).OrderByDescending(x => x.id).First();
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
				fabricante = Fabricante.Fabricantes().Where(x => x.id > fabricante.id).First();
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
				fabricante = Fabricante.Fabricantes().OrderByDescending(x => x.id).First();
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
				if (fabricante.id != 0)
				{
					fabricante = new Fabricante();
					Cargar(false, true);
				}
				else
				{
					object p = new { fields = "id, codigo, nombre, activo", like = true };
					object o = new { codigo = txtCodigo.Text, nombre = txtNombre.Text };
					DataTable fabricantes = Utilidades.Busqueda("fabricantes", o, p);
					if (fabricantes.Rows.Count > 0)
					{
						if (fabricantes.Rows.Count == 1)
						{
							fabricante = Fabricante.Obtener((int)fabricantes.Rows[0]["id"]);
							Cargar();
						}
						else
						{
							frmResultadosBusqueda f = new frmResultadosBusqueda(fabricantes);
							var result = f.ShowDialog();
							if (result == DialogResult.OK)
							{
								fabricante = Fabricante.Obtener(f.id);
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
			fabricante = new Fabricante();
			Cargar(true);
		}

		private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && fabricante.id == 0)
				Buscar();
		}
	}
}