using NoriSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Nori.PuntoVenta
{
	public partial class frmCanjes : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		Autorizacion autorizacion = new Autorizacion();
		List<MetodoPago.Tipo> tipos_metodos_pago = MetodoPago.Tipo.Tipos().Where(x => x.canjeable == true).ToList();
		decimal importe = 0;
		public frmCanjes()
		{
			InitializeComponent();
			this.MetodoDinamico();

			autorizacion.codigo = "CANJE";

			if (tipos_metodos_pago.Count == 0)
			{
				MessageBox.Show("Aún no hay tipos de métodos de pago canjeables");
				Close();
			}

			CargarListas();
		}

		public void CargarListas()
		{

			cbIngreso.Properties.DataSource = tipos_metodos_pago;
			cbIngreso.Properties.ValueMember = "id";
			cbIngreso.Properties.DisplayMember = "nombre";

			cbEgreso.Properties.DataSource = tipos_metodos_pago;
			cbEgreso.Properties.ValueMember = "id";
			cbEgreso.Properties.DisplayMember = "nombre";
			cbEgreso.EditValue = MetodoPago.MetodosPago().Where(x => x.id == Program.Nori.Configuracion.metodo_pago_id).First().tipo_metodo_pago_id;
		}

		public void Calcular()
		{
			try
			{
				if (txtCantidad.Text.Length > 0)
				{
					importe = TipoCambio.Convertir(tipos_metodos_pago.Where(x => x.id == (int)cbIngreso.EditValue).First().moneda_id, tipos_metodos_pago.Where(x => x.id == (int)cbEgreso.EditValue).First().moneda_id, 'C', decimal.Parse(txtCantidad.EditValue.ToString()));
					lblImporte.Text = importe.ToString("c2");
				}
			}
			catch { }
		}

		private void btnAceptar_Click(object sender, EventArgs e)
		{
			try
			{
				if ((int)cbIngreso.EditValue != (int)cbEgreso.EditValue)
				{
					if (MessageBox.Show(string.Format("¿Estas seguro(a) de realizar este canje?"), Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
					{
						autorizacion.referencia = string.Format("Canje del usuario {0} en la estación {1}", Program.Nori.UsuarioAutenticado.usuario, Program.Nori.Estacion.nombre);
						autorizacion.comentario = Microsoft.VisualBasic.Interaction.InputBox("Comentario canje (Opcional)", "");
						autorizacion.Agregar();

						if (!autorizacion.autorizado)
						{
							frmSolicitarAutorizacion fa = new frmSolicitarAutorizacion(autorizacion);
							fa.ShowDialog();
							autorizacion.autorizado = (fa.DialogResult == DialogResult.OK) ? true : false;
						}

						if (autorizacion.autorizado)
						{
							//Flujo ingreo
							Flujo flujo = new Flujo();
							flujo.codigo = "INCAN";
							flujo.autorizacion_id = autorizacion.id;
							flujo.tipo_metodo_pago_id = (int)cbIngreso.EditValue;
							flujo.importe = decimal.Parse(txtCantidad.EditValue.ToString());
							flujo.tipo_cambio = importe / flujo.importe;
							flujo.comentario = txtComentario.Text;
							if (flujo.Agregar())
								Funciones.ImprimirInformePredeterminado("IE", flujo.id);
							//Flujo egreso
							flujo = new Flujo();
							flujo.codigo = "RECAN";
							flujo.autorizacion_id = autorizacion.id;
							flujo.tipo_metodo_pago_id = (int)cbEgreso.EditValue;
							flujo.importe = importe;
							flujo.comentario = txtComentario.Text;
							if (flujo.Agregar())
								Funciones.ImprimirInformePredeterminado("IE", flujo.id);

							DialogResult = DialogResult.OK;
						}
						else
						{
							MessageBox.Show("No se autorizó la operación");
						}
					}
				}
				else
					MessageBox.Show("No es posible realizar un canje de dos conceptos iguales");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private void cbIngreso_EditValueChanged(object sender, EventArgs e)
		{
			Calcular();
		}

		private void txtCantidad_TextChanged(object sender, EventArgs e)
		{
			Calcular();
		}
	}
}