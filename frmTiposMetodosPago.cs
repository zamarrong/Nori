using NoriSDK;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Nori
{
	public partial class frmTiposMetodosPago : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		MetodoPago.Tipo tipo_metodo_pago = new MetodoPago.Tipo();

		public frmTiposMetodosPago(int id = 0)
		{
			InitializeComponent();
			this.MetodoDinamico();
			if (id != 0)
			{
				tipo_metodo_pago = MetodoPago.Tipo.Obtener(id);
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

		private void Cargar(bool nuevo = false, bool busqueda = false)
		{
			lblID.Text = tipo_metodo_pago.id.ToString();

			cbMetodosPago.EditValue = tipo_metodo_pago.metodo_pago_id;
			cbMonedas.EditValue = tipo_metodo_pago.moneda_id;
			txtNombre.Text = tipo_metodo_pago.nombre;
			txtCuentaContable.Text = tipo_metodo_pago.cuenta_contable;
			txtCodigo.Text = tipo_metodo_pago.codigo;
			cbTiposCambio.EditValue = tipo_metodo_pago.tipo_cambio;
			cbClases.EditValue = tipo_metodo_pago.clase;
			cbReferencia.Checked = tipo_metodo_pago.referencia;
			cbCambio.Checked = tipo_metodo_pago.cambio;
			cbCanjeable.Checked = tipo_metodo_pago.canjeable;
			cbDocumento.Checked = tipo_metodo_pago.documento;
			cbActivo.Checked = tipo_metodo_pago.activo;

			lblFechaActualizacion.Text = tipo_metodo_pago.fecha_actualizacion.ToShortDateString();

			if (nuevo)
			{
				bbiNuevo.Enabled = false;
				bbiGuardar.Enabled = true;
				bbiGuardarCerrar.Enabled = true;
				bbiGuardarNuevo.Enabled = true;
				cbMetodosPago.Focus();
			}
			else
			{
				if (busqueda)
				{
					bbiNuevo.Enabled = true;
					bbiGuardar.Enabled = false;
					bbiGuardarCerrar.Enabled = false;
					bbiGuardarNuevo.Enabled = false;
					cbMetodosPago.Focus();
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

		private void CargarListas()
		{
			object p = new { fields = "id, codigo, nombre" };
			object o = new { activo = 1 };

			cbMetodosPago.Properties.DataSource = Utilidades.Busqueda("metodos_pago", o, p);
			cbMetodosPago.Properties.ValueMember = "id";
			cbMetodosPago.Properties.DisplayMember = "nombre";

			cbMonedas.Properties.DataSource = Utilidades.Busqueda("monedas", o, p);
			cbMonedas.Properties.ValueMember = "id";
			cbMonedas.Properties.DisplayMember = "nombre";

			cbTiposCambio.Properties.DataSource = MetodoPago.Tipo.TipoCambio.Tipos();
			cbTiposCambio.Properties.ValueMember = "tipo";
			cbTiposCambio.Properties.DisplayMember = "nombre";
			cbTiposCambio.EditValue = MetodoPago.Tipo.TipoCambio.ObtenerPredeterminado();

			cbClases.Properties.DataSource = MetodoPago.Tipo.Clase.Clases();
			cbClases.Properties.ValueMember = "clase";
			cbClases.Properties.DisplayMember = "nombre";
			cbClases.EditValue = MetodoPago.Tipo.Clase.ObtenerPredeterminado();
		}

		private void Llenar()
		{
			tipo_metodo_pago.metodo_pago_id = (int)cbMetodosPago.EditValue;
			tipo_metodo_pago.moneda_id = (int)cbMonedas.EditValue;
			tipo_metodo_pago.nombre = txtNombre.Text;
			tipo_metodo_pago.cuenta_contable = txtCuentaContable.Text;
			tipo_metodo_pago.codigo = txtCodigo.Text;
			tipo_metodo_pago.tipo_cambio = (char)cbTiposCambio.EditValue;
			tipo_metodo_pago.clase = (string)cbClases.EditValue;
			tipo_metodo_pago.referencia = cbReferencia.Checked;
			tipo_metodo_pago.cambio = cbCambio.Checked;
			tipo_metodo_pago.canjeable = cbCanjeable.Checked;
			tipo_metodo_pago.documento = cbDocumento.Checked;
			tipo_metodo_pago.activo = cbActivo.Checked;
		}

		private bool Guardar()
		{
			try
			{
				if (MessageBox.Show("¿Desea guardar los cambios?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					Llenar();
					if (tipo_metodo_pago.id != 0)
					{
						return tipo_metodo_pago.Actualizar();
					}
					else
					{
						return tipo_metodo_pago.Agregar();
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
				tipo_metodo_pago = new MetodoPago.Tipo();
				Cargar();
			}
		}

		private void bbiPrimero_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				tipo_metodo_pago = MetodoPago.Tipo.Tipos().OrderBy(x => x.id).First();
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
				tipo_metodo_pago = MetodoPago.Tipo.Tipos().Where(x => x.id < tipo_metodo_pago.id).OrderByDescending(x => x.id).First();
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
				tipo_metodo_pago = MetodoPago.Tipo.Tipos().Where(x => x.id > tipo_metodo_pago.id).First();
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
				tipo_metodo_pago = MetodoPago.Tipo.Tipos().OrderByDescending(x => x.id).First();
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
				if (tipo_metodo_pago.id != 0)
				{
					tipo_metodo_pago = new MetodoPago.Tipo();
					Cargar(false, true);
				}
				else
				{
					object p = new { fields = "id, nombre, activo", like = true };
					object o = new { metodo_pago_id = (cbMetodosPago.EditValue.IsNullOrEmpty()) ? null : cbMetodosPago.EditValue, nombre = txtNombre.Text };
					DataTable tipos_metodos_pago = Utilidades.Busqueda("tipos_metodos_pago", o, p);
					if (tipos_metodos_pago.Rows.Count > 0)
					{
						if (tipos_metodos_pago.Rows.Count == 1)
						{
							tipo_metodo_pago = MetodoPago.Tipo.Obtener((int)tipos_metodos_pago.Rows[0]["id"]);
							Cargar();
						}
						else
						{
							frmResultadosBusqueda f = new frmResultadosBusqueda(tipos_metodos_pago);
							var result = f.ShowDialog();
							if (result == DialogResult.OK)
							{
								tipo_metodo_pago = MetodoPago.Tipo.Obtener(f.id);
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
			tipo_metodo_pago = new MetodoPago.Tipo();
			Cargar(true);
		}

		private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && tipo_metodo_pago.id == 0)
				Buscar();
		}

		private void bbiUsuarios_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			frmUsuariosTiposMetodosPago f = new frmUsuariosTiposMetodosPago();
			f.Show();
		}
	}
}