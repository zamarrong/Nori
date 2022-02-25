using NoriSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Nori
{
	public partial class frmMediosPago : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		internal Documento documento;
		internal Socio socio;
		internal List<MetodoPago.Tipo> tipos_metodos_pago;
		internal List<CondicionesPago> condiciones_pago;
		public frmMediosPago(Documento documento, Socio socio)
		{
			InitializeComponent();
			this.MetodoDinamico();

			this.documento = documento;
			this.socio = socio;

			if (socio.eventual)
				socio.limite_credito = 1;

			lblNombre.Text = socio.nombre;
			lblClaseDocumento.Text = Documento.Clase.Clases().Where(x => x.clase == documento.clase).First().nombre;

			CargarListas();

			lblLimiteCredito.Text = "Límite de crédito: " + socio.limite_credito.ToString("c2");
			lblCreditoDisponible.Text = "Crédito disponible: " + (socio.limite_credito - socio.balance).ToString("c2");
			cbCondicionesPago.Enabled = (socio.limite_credito > 0) ? true : false;

			if (documento.flujo.Count == 0)
				Nuevo();
		}

		private void CargarListas()
		{
			List<int> usuario_tipos_metodos_pago = Usuario.TipoMetodoPago.TiposMetodosPago().Where(x => x.usuario_id == Program.Nori.UsuarioAutenticado.id).Select(x => x.tipo_metodo_pago_id).ToList();
			tipos_metodos_pago = (usuario_tipos_metodos_pago.Count > 0) ? MetodoPago.Tipo.Tipos().Where(x => usuario_tipos_metodos_pago.Contains(x.id)).ToList() : MetodoPago.Tipo.Tipos().Where(x => x.activo == true).ToList();

			cbMetodosPago.DataSource = tipos_metodos_pago;
			cbMetodosPago.ValueMember = "id";
			cbMetodosPago.DisplayMember = "nombre";

			cbUsoPrincipal.Properties.DataSource = Documento.UsoCFDI.UsosCFDI();
			cbUsoPrincipal.Properties.ValueMember = "uso";
			cbUsoPrincipal.Properties.DisplayMember = "nombre";
			cbUsoPrincipal.EditValue = documento.uso_principal;

			condiciones_pago = CondicionesPago.CondicionesPagos().Where(x => x.activo == true && x.financiado == true && (x.limite_maximo == 0 || documento.total >= x.limite_maximo)).ToList();

			cbCondicionesPago.Properties.DataSource = condiciones_pago;
			cbCondicionesPago.Properties.ValueMember = "id";
			cbCondicionesPago.Properties.DisplayMember = "nombre";
			cbCondicionesPago.EditValue = documento.condicion_pago_id;

			Calcular();
		}

		private void btnAceptar_Click(object sender, EventArgs e)
		{
			try
			{
				documento.uso_principal = cbUsoPrincipal.EditValue.ToString();

				bool financiado = false;

				try
				{
					if (cbCondicionesPago.Enabled)
					{
						documento.condicion_pago_id = (cbCondicionesPago.EditValue.IsNullOrEmpty()) ? documento.condicion_pago_id : (int)cbCondicionesPago.EditValue;

						if (condiciones_pago.Where(x => x.id == documento.condicion_pago_id).First().financiado)
						{
							financiado = true;
							documento.clase = "FA";
						}
					}
				} catch { }

				if (Math.Round(documento.importe_aplicado, 2) >= Math.Round(documento.total, 2) || (documento.importe_aplicado > 0 && documento.reserva))
				{
					try
					{
						var flujo_metodo_pago = documento.flujo.OrderByDescending(x => (x.importe * x.tipo_cambio)).First();
						documento.metodo_pago_id = tipos_metodos_pago.Where(x => x.id == flujo_metodo_pago.tipo_metodo_pago_id).Select(x => x.metodo_pago_id).First();
					} catch { }

					if (documento.importe_aplicado >= documento.total)
						documento.importe_aplicado = documento.total;

					DialogResult = DialogResult.OK;
				}
				else if (socio.limite_credito > 0 && documento.flujo.Count == 0 && documento.socio_id != Program.Nori.UsuarioAutenticado.socio_id)
				{
					try
					{
						documento.metodo_pago_id = MetodoPago.MetodosPago().Where(x => x.codigo == "99").Select(x => x.id).First();
					} catch { }


					if (MessageBox.Show("Este documento será guardado a crédito, ¿desea continuar?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						//Quita descuentos
						if (!financiado)
						{
							if (MessageBox.Show("¿Desea quitar los descuentos aplicados?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
							{
								documento.partidas.ForEach(x => x.porcentaje_descuento = 0);
								documento.RecalcularTotalPartidas(false);
							}
						}

						decimal disponible = socio.limite_credito - socio.balance;
						bool documentos_vencidos = socio.DocumentosVencidos();
						int dias_extra = CondicionesPago.CondicionesPagos().Where(x => x.id == documento.condicion_pago_id).Select(x => x.dias_extra).First();

						if ((documento.total > disponible || documentos_vencidos) && dias_extra > 0)
						{
							Autorizacion autorizacion = new Autorizacion();
							string txt_documentos_vencidos = (documentos_vencidos) ? "(Documentos vencidos)" : "";

							string clase_documento = Documento.Clase.Clases().Where(x => x.clase == documento.clase).Select(x => x.nombre).First();

							if (documento.reserva)
								clase_documento += " (Reserva)";
							if (documento.anticipo)
								clase_documento += " (Anticipo)";

							autorizacion.codigo = "VEACR";
							autorizacion.referencia = string.Format("{0} a crédito por {1:c2} al socio {2} ({3}), Límite de crédito excedido en {4:c2} {5}",clase_documento, documento.total, socio.nombre, socio.codigo, ((socio.limite_credito - socio.balance) * -1), txt_documentos_vencidos);
							autorizacion.comentario = Microsoft.VisualBasic.Interaction.InputBox("Comentario venta a crédito (Opcional)", "");

							autorizacion.Agregar();

							if (!autorizacion.autorizado)
							{
								frmSolicitarAutorizacion fa = new frmSolicitarAutorizacion(autorizacion);
								fa.ShowDialog();
								autorizacion.autorizado = (fa.DialogResult == DialogResult.OK) ? true : false;
							}

							if (autorizacion.autorizado)
								DialogResult = DialogResult.OK;
							else
								MessageBox.Show("No se autorizó este movimiento.");
						}
						else
						{
							DialogResult = DialogResult.OK;
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}
		private void gvPagos_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete)
			{
				if (documento.flujo.Count > 0)
					documento.flujo.Remove(documento.flujo[gvPagos.GetSelectedRows()[0]]);
				Calcular();
			}

			if (e.Alt && e.KeyCode == Keys.M)
				gvPagos.FocusedColumn = gvPagos.Columns["tipo_metodo_pago_id"];

			if (e.Alt && e.KeyCode == Keys.I)
				gvPagos.FocusedColumn = gvPagos.Columns["importe"];

			if (e.Control && e.KeyCode == Keys.B)
			{
				documento.flujo[gvPagos.GetSelectedRows()[0]].importe = documento.total;
				gvPagos.CloseEditor();
			}
		}

		private void gvPagos_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
		{
			try
			{
				if (e.Column.FieldName == "tipo_metodo_pago_id")
				{
					MetodoPago.Tipo tipo_metodo_pago = tipos_metodos_pago.Where(x => x.id == documento.flujo[e.RowHandle].tipo_metodo_pago_id).First();

					if (tipo_metodo_pago.referencia)
						documento.flujo[e.RowHandle].referencia = Microsoft.VisualBasic.Interaction.InputBox("Ingresar referencia", Text, "");
					else
						documento.flujo[e.RowHandle].referencia = string.Empty;

					if (tipo_metodo_pago.documento)
						SolicitarDocumento();

					documento.flujo[e.RowHandle].EstablecerTipoCambio();

					if (documento.moneda_id != tipo_metodo_pago.moneda_id || (!tipo_metodo_pago.cambio && !tipo_metodo_pago.documento))
						documento.flujo[e.RowHandle].importe = TipoCambio.Convertir(documento.moneda_id, tipo_metodo_pago.moneda_id, 'C', (documento.total - documento.importe_aplicado));

					if (Program.Nori.Configuracion.tipo_metodo_pago_monedero_id == documento.flujo[e.RowHandle].tipo_metodo_pago_id)
					{
						PagoMonedero();
						documento.flujo.Remove(documento.flujo[e.RowHandle]);
					}

					gvPagos.FocusedColumn = gvPagos.Columns["importe"];
				}
				else if (e.Column.FieldName == "importe")
				{

					decimal diferencia = Math.Round(documento.total, 2) - Math.Round(documento.importe_aplicado, 2);
					var pagos_agregados = (documento.flujo.Select(x => x.tipo_metodo_pago_id)).ToList();
					decimal pago = documento.flujo[e.RowHandle].tipo_cambio * documento.flujo[e.RowHandle].importe;
					bool cambio = tipos_metodos_pago.Any(x => pagos_agregados.Contains(x.id) && x.cambio == true);

					if (!cambio && !tipos_metodos_pago.Where(x => x.id == documento.flujo[e.RowHandle].tipo_metodo_pago_id).First().cambio)
					{
						if (pago > diferencia)
						{
							documento.flujo[e.RowHandle].importe = 0;
							MessageBox.Show("No se puede ingresar un importe mayor que la diferencia restante");
						}
					}
					else if (!tipos_metodos_pago.Where(x => x.id == documento.flujo[e.RowHandle].tipo_metodo_pago_id).First().cambio && (pago > diferencia) && !cambio)
					{
						documento.flujo[e.RowHandle].importe = 0;
						MessageBox.Show("No se puede ingresar un importe mayor que la diferencia restante");
					}

				}
				Calcular();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void SolicitarDocumento()
		{
			try
			{
				DateTime fecha = new DateTime(1753, 01, 01);

				if (socio.id == Program.Nori.UsuarioAutenticado.socio_id)
					fecha = DateTime.Today;

				var documentos = Documento.Documentos().Where(x => x.estado == 'A' && x.clase == "NC" && x.socio_id == socio.id && x.fecha_documento >= fecha).Select(x => new { x.id, x.numero_documento, x.total, disponible = x.total - x.importe_aplicado, fecha = x.fecha_documento }).ToList();

				if (documentos.Count > 0)
				{
					frmResultadosBusqueda f = new frmResultadosBusqueda(documentos.ToDataTable());
					var result = f.ShowDialog();
					if (result == DialogResult.OK)
					{
						var documento_pago = documentos.Where(x => x.id == f.id).First();

						decimal diferencia = Math.Round(documento.total, 2) - Math.Round(documento.importe_aplicado, 2);

						if (documento_pago.disponible >= diferencia)
							documento.flujo[gvPagos.GetSelectedRows()[0]].importe = diferencia;
						else
							documento.flujo[gvPagos.GetSelectedRows()[0]].importe = documento_pago.disponible;

						documento.flujo[gvPagos.GetSelectedRows()[0]].referencia = documento_pago.id.ToString();
					}
				}
				else
				{
					MessageBox.Show("Este socio no tiene notas de crédito disponibles.");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void Calcular()
		{
			gcPagos.DataSource = documento.flujo;
			gcPagos.RefreshDataSource();

			documento.CalcularTotal();

			//CAMBIAR QUITAR YOYOSO
			lblSubTotal.Text = documento.subtotal.ToString("C");
			lblDescuento.Text = documento.descuento.ToString("C");
			lblImpuesto.Text = documento.impuesto.ToString("C");
			lblTotal.Text = documento.total.ToString("C");
			lblTotalAplicado.Text = documento.importe_aplicado.ToString("C");

			decimal diferencia = Math.Round(documento.total, 2) - Math.Round(documento.importe_aplicado, 2);

			if ((double)diferencia <= 0 || documento.reserva)
			{
				lblDiferencia_.Text = "Cambio";
				decimal cambio = diferencia * -1;
				lblDiferencia.Text = cambio.ToString("C");
				btnAceptar.Enabled = true;
			}
			else
			{
				lblDiferencia_.Text = "Restante";
				lblDiferencia.Text = diferencia.ToString("C");
				btnAceptar.Enabled = false;
			}

			if (socio.limite_credito > 0)
				btnAceptar.Enabled = true;

			if (condiciones_pago.Count > 0)
			{
				if (documento.flujo.Count == 0 || documento.reserva)
					cbCondicionesPago.Enabled = true;
				else
					cbCondicionesPago.Enabled = false;
			}
			else
			{
				cbCondicionesPago.Enabled = false;
			}
		}

		private void Nuevo()
		{
			try
			{
				decimal diferencia = Math.Round(documento.total, 2) - Math.Round(documento.importe_aplicado, 2);
				if (diferencia > 0)
				{
					documento.AgregarPago();
					Calcular();
				}
				else
				{
					MessageBox.Show("No es posible agregar otro pago debido a que ya se ha liquidado el total del documento.");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				gvPagos.Focus();
				gvPagos.MoveLast();
				gvPagos.FocusedColumn = (documento.flujo[gvPagos.GetSelectedRows()[0]].tipo_metodo_pago_id == 0) ? gvPagos.Columns["tipo_metodo_pago_id"] : gvPagos.Columns["importe"];
			}
		}

		private void PagoMonedero()
		{
			try
			{
				if (Program.Nori.Configuracion.tipo_metodo_pago_monedero_id != 0)
				{
					string folio_monedero = Microsoft.VisualBasic.Interaction.InputBox("Ingresa el folio del monedero electrónico", "Monedero electrónico", "");
					Monedero monedero = Monedero.Obtener(folio_monedero);

					if (monedero.socio_id == documento.socio_id)
					{
						if (monedero.saldo > 0)
						{
							decimal importe = decimal.Parse(Microsoft.VisualBasic.Interaction.InputBox(string.Format("Folio {0}\r\nSaldo disponible: {1}", folio_monedero, monedero.saldo.ToString("c2")), "Importe", Math.Round(documento.total, 2).ToString()));

							if (importe <= Math.Round(monedero.saldo, 2))
							{
								if (importe <= Math.Round(documento.total, 2))
								{
									documento.AgregarPago(Program.Nori.Configuracion.tipo_metodo_pago_monedero_id, importe, folio_monedero.ToString());
									Calcular();
								}
								else
									MessageBox.Show("El importe no puede ser mayor al total del documento.");
							}
							else
								MessageBox.Show("El importe no puede ser mayor que el saldo del monedero.");
						}
						else
							MessageBox.Show("No cuenta con saldo suficiente para realizar esta operación.");
					}
					else
						MessageBox.Show("El socio del monedero y el socio del documento son distintos.");
				}
				else
					MessageBox.Show("Aún no esta configurado el tipo de método de pago para monedero electrónico.");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void frmPago_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Alt && e.KeyCode == Keys.P)
				gvPagos.Focus();
		}

		private void frmPago_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.Control && e.KeyCode == Keys.N)
				Nuevo();

			if (e.Control && e.KeyCode == Keys.M)
				PagoMonedero();

			if (e.Shift && e.KeyCode == Keys.C)
			{
				PuntoVenta.frmCanjes f = new PuntoVenta.frmCanjes();
				f.ShowDialog();
			}
		}

		private void gvPagos_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try
			{
				if (tipos_metodos_pago.Any(x => x.id == documento.flujo[gvPagos.GetSelectedRows()[0]].tipo_metodo_pago_id && x.documento) || (documento.flujo[gvPagos.GetSelectedRows()[0]].tipo_metodo_pago_id == Program.Nori.Configuracion.tipo_metodo_pago_monedero_id && Program.Nori.Configuracion.tipo_metodo_pago_monedero_id != 0))
					e.Cancel = true;
			}
			catch { }
		}

		private void frmPagos_Activated(object sender, EventArgs e)
		{
			gvPagos.Focus();
		}
	}
}