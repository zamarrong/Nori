using NoriSDK;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Nori
{
	public partial class frmCondicionesPago : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		CondicionesPago condicion_pago = new CondicionesPago();

		public frmCondicionesPago(int id = 0)
		{
			InitializeComponent();
			this.MetodoDinamico();
			if (id != 0)
			{
				condicion_pago = CondicionesPago.Obtener(id);
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
			lblID.Text = condicion_pago.id.ToString();
			cbListaPrecios.EditValue = condicion_pago.lista_precio_id;

			txtCodigo.Text = condicion_pago.codigo.ToString();
			txtNombre.Text = condicion_pago.nombre;
			txtPorcentajeDescuentoTotal.Text = condicion_pago.porcentaje_descuento_total.ToString();
			txtPorcentajeInteres.Text = condicion_pago.porcentaje_interes.ToString();
            txtPorcentajeInteresMoratorio.Text = condicion_pago.porcentaje_interes_moratorio.ToString();
			txtDiasExtra.Text = condicion_pago.dias_extra.ToString();
			txtPlazos.Text = condicion_pago.plazos.ToString();
			txtDiasTolerancia.Text = condicion_pago.dias_tolerancia.ToString();
			txtLimiteMaximo.Text = condicion_pago.limite_maximo.ToString();

			cbFinanciado.Checked = condicion_pago.financiado;
            cbPagoRequerido.Checked = condicion_pago.pago_requerido;
			cbActivo.Checked = condicion_pago.activo;

			lblFechaActualizacion.Text = condicion_pago.fecha_actualizacion.ToShortDateString();

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

		private void CargarListas()
		{
			object p = new { fields = "id, nombre" };
			object o = new { activo = 1 };
			cbListaPrecios.Properties.DataSource = Utilidades.Busqueda("listas_precios", o, p);
			cbListaPrecios.Properties.ValueMember = "id";
			cbListaPrecios.Properties.DisplayMember = "nombre";
			cbListaPrecios.EditValue = Program.Nori.Configuracion.lista_precio_id;
		}

		private void Llenar()
		{
			condicion_pago.lista_precio_id = (cbListaPrecios.EditValue.IsNullOrEmpty()) ? 0 : (int)cbListaPrecios.EditValue;
			condicion_pago.codigo = short.Parse(txtCodigo.Text);
			condicion_pago.nombre = txtNombre.Text;
			condicion_pago.porcentaje_descuento_total = decimal.Parse(txtPorcentajeDescuentoTotal.Text);
			condicion_pago.porcentaje_interes = decimal.Parse(txtPorcentajeInteres.Text);
            condicion_pago.porcentaje_interes_moratorio = decimal.Parse(txtPorcentajeInteresMoratorio.Text);
            condicion_pago.dias_extra = short.Parse(txtDiasExtra.Text);
			condicion_pago.plazos = int.Parse(txtPlazos.Text);
			condicion_pago.dias_tolerancia = short.Parse(txtDiasTolerancia.Text);
			condicion_pago.limite_maximo = decimal.Parse(txtLimiteMaximo.Text);
			condicion_pago.limite_comprometido = condicion_pago.limite_maximo;
            condicion_pago.financiado = cbFinanciado.Checked;
            condicion_pago.pago_requerido = cbPagoRequerido.Checked;
            condicion_pago.activo = cbActivo.Checked;
		}

		private bool Guardar()
		{
			try
			{
				if (MessageBox.Show("¿Desea guardar los cambios?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					Llenar();
					if (condicion_pago.id != 0)
					{
						return condicion_pago.Actualizar();
					}
					else
					{
						return condicion_pago.Agregar();
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
				condicion_pago = new CondicionesPago();
				Cargar();
			}
		}

		private void bbiPrimero_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				condicion_pago = CondicionesPago.CondicionesPagos().OrderBy(x => x.id).First();
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
				condicion_pago = CondicionesPago.CondicionesPagos().Where(x => x.id < condicion_pago.id).OrderByDescending(x => x.id).First();
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
				condicion_pago = CondicionesPago.CondicionesPagos().Where(x => x.id > condicion_pago.id).First();
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
				condicion_pago = CondicionesPago.CondicionesPagos().OrderByDescending(x => x.id).First();
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
				if (condicion_pago.id != 0)
				{
					condicion_pago = new CondicionesPago();
					Cargar(false, true);
				}
				else
				{
					object p = new { fields = "id, codigo, nombre, activo", like = true };
					object o = new { codigo = txtCodigo.Text, nombre = txtNombre.Text };
					DataTable condiciones_pago = Utilidades.Busqueda("condiciones_pago", o, p);
					if (condiciones_pago.Rows.Count > 0)
					{
						if (condiciones_pago.Rows.Count == 1)
						{
							condicion_pago = CondicionesPago.Obtener((int)condiciones_pago.Rows[0]["id"]);
							Cargar();
						}
						else
						{
							frmResultadosBusqueda f = new frmResultadosBusqueda(condiciones_pago);
							var result = f.ShowDialog();
							if (result == DialogResult.OK)
							{
								condicion_pago = CondicionesPago.Obtener(f.id);
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
			condicion_pago = new CondicionesPago();
			Cargar(true);
		}

		private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && condicion_pago.id == 0)
				Buscar();
		}

		private void lblListaPrecios_Click(object sender, EventArgs e)
		{
			frmListasPrecios form = new frmListasPrecios((cbListaPrecios.EditValue.IsNullOrEmpty()) ? 0 : (int)cbListaPrecios.EditValue);
			form.ShowDialog();
			CargarListas();
		}
	}
}