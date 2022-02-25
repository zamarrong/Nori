using NoriSDK;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Nori
{
	public partial class frmAltaRapidaArticulo : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		Articulo articulo = new Articulo();
		public frmAltaRapidaArticulo()
		{
			InitializeComponent();
			this.MetodoDinamico();
		
			EventoControl.SuscribirEventos(this);

			CargarListas();
		}

		private void bbiGuardarCerrar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (Validar())
			{
				if (Guardar())
					Close();
				else
					MessageBox.Show(NoriSDK.Nori.ObtenerUltimoError().Message, Text);
			}
			else
				MessageBox.Show("La información del artículo no esta completa.");
		}

		private void CargarListas()
		{
			cbGruposArticulos.Properties.DataSource = GrupoArticulo.GruposArticulos().Select(x => new { x.id, x.nombre });
			cbGruposArticulos.Properties.ValueMember = "id";
			cbGruposArticulos.Properties.DisplayMember = "nombre";
		}

		private bool Validar()
		{
			try {
				if (txtSKU.Text.Length == 0 || txtNombre.Text.Length == 0 || txtNombre.Text.Length == 0 || txtPrecio.Text.Length == 0  || (int)cbGruposArticulos.EditValue == 0)
					return false;
				else
					return true;
			} catch { return false; }
		}

		private void Llenar()
		{
			//Articulo
			articulo.sku = txtSKU.Text;
			articulo.nombre = txtNombre.Text;
			articulo.descripcion = txtDescripcion.Text;
			articulo.codigo_barras = articulo.sku;
			articulo.grupo_articulo_id = (int)cbGruposArticulos.EditValue;
			articulo.venta = articulo.compra = articulo.almacenable = true;
		}

		private bool Guardar()
		{
			try
			{
				if (MessageBox.Show("¿Desea guardar los cambios?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					Llenar();
					if (articulo.Agregar())
					{
						Articulo.Precio precio = new Articulo.Precio();

						precio.articulo_id = articulo.id;
						precio.precio = decimal.Parse(txtPrecio.EditValue.ToString());
						precio.Agregar();

						Articulo.Inventario inventario = Articulo.Inventario.Obtener(articulo.id, Program.Nori.UsuarioAutenticado.almacen_id);
						if (inventario.id == 0)
						{
							inventario.articulo_id = articulo.id;
							inventario.almacen_id = Program.Nori.UsuarioAutenticado.almacen_id;

							if (inventario.Agregar())
								MessageBox.Show("Se agregó la información correctamente.");
							else
								MessageBox.Show(NoriSDK.Nori.ObtenerUltimoError().Message);
						}
						else
						{
							MessageBox.Show("El inventario de este artículo ya incluye este almacén.");
						}

						return true;
					}
					else
						return false;
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

		private void btnGenerarSKU_Click(object sender, System.EventArgs e)
		{
			try
			{
				GrupoArticulo grupo_articulo = GrupoArticulo.Obtener((int)cbGruposArticulos.EditValue);

				string sku = string.Format("{0}{1}{2}{3}", grupo_articulo.codigo.ToString("D2"), DateTime.Today.Month.ToString("D2"), DateTime.Today.ToString("yy"), Funciones.DigitosAleatorios(6));

				txtSKU.Text = sku;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}