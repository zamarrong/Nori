using NoriSDK;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Nori.PuntoVenta
{
	public partial class frmArqueo : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		List<MetodoPago.Tipo> tipos = new List<MetodoPago.Tipo>();
		List<Arqueo> arqueos = new List<Arqueo>();
		List<Acumulado> acumulados = new List<Acumulado>();
		public frmArqueo()
		{
			InitializeComponent();
			this.MetodoDinamico();

			CargarListas();
		}

		private class Acumulado
		{
			public int tipo_metodo_pago_id { get; set; }
			public string concepto { get; set; }
			public decimal total { get; set; }
		}

		private void CargarListas()
		{
			object p = new { fields = "id, nombre", order_by = "nombre" };
			object o = new { activo = 1 };

			tipos = MetodoPago.Tipo.Tipos().ToList();

			cbConceptos.Properties.DataSource = tipos;
			cbConceptos.Properties.ValueMember = "id";
			cbConceptos.Properties.DisplayMember = "nombre";
			cbConceptos.ItemIndex = 0;

			foreach(MetodoPago.Tipo tipo in tipos)
			{
				Acumulado acumulado = new Acumulado();
				acumulado.tipo_metodo_pago_id = tipo.id;
				acumulado.concepto = tipo.nombre;
				acumulado.total = 0;
				acumulados.Add(acumulado);
			}

			gcAcumulados.DataSource = acumulados;
			gcPartidas.DataSource = arqueos;
		}

		private void Calcular()
		{
			try
			{
				gcPartidas.DataSource = (tipos.Where(x => x.id == (int)cbConceptos.EditValue).First().cambio) ? arqueos.Where(x => x.tipo_metodo_pago_id == (int)cbConceptos.EditValue).OrderByDescending(x => x.factor) : arqueos.Where(x => x.tipo_metodo_pago_id == (int)cbConceptos.EditValue);
				gcPartidas.RefreshDataSource();

				foreach (MetodoPago.Tipo tipo in tipos)
				{
					acumulados.Where(x => x.tipo_metodo_pago_id == tipo.id).First().total = arqueos.Where(x => x.tipo_metodo_pago_id == tipo.id).Sum(x => x.producto) * tipo.ObtenerTipoCambio();
				}

				gcAcumulados.DataSource = acumulados;
				gcAcumulados.RefreshDataSource();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void AgregarArqueo(Arqueo arqueo)
		{
			arqueo.tipo_metodo_pago_id = (int)cbConceptos.EditValue;

			if (arqueos.Any(x => x.tipo_metodo_pago_id == arqueo.tipo_metodo_pago_id && x.factor == arqueo.factor))
			{
				Arqueo arqueo_tmp = arqueos.Where(x => x.tipo_metodo_pago_id == arqueo.tipo_metodo_pago_id && x.factor == arqueo.factor).First();
				arqueo_tmp.cantidad = arqueo_tmp.cantidad + arqueo.cantidad;
				arqueo_tmp.Calcular();
			}
			else
			{
				arqueos.Add(arqueo);
			}

			txtCantidad.Text = string.Empty;
			txtCantidad.Focus();
			Calcular();
		}

		private void btnCancelar_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private void txtImporte_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Enter && txtCantidad.Text.Length > 0 && (int)cbConceptos.EditValue != 0)
				{
					Arqueo arqueo = new Arqueo();
					if (arqueo.Validar(txtCantidad.Text))
						AgregarArqueo(arqueo);
					else
						MessageBox.Show("El formato de entrada no es válido.");
				}
			}
			catch
			{
				MessageBox.Show("Debe seleccionar un concepto primero.");
			}
		}

		private void cbConceptos_EditValueChanged(object sender, EventArgs e)
		{
			Calcular();
		}

		private void gvPartidas_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
		{
			try
			{
				arqueos[e.RowHandle].Calcular();
				Calcular();
			} catch { }
		}

		private void gvPartidas_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Delete)
				{
					if (arqueos.Count > 0)
					{
						Arqueo arqueo = (Arqueo)gvPartidas.GetRow(gvPartidas.GetSelectedRows()[0]);
						gvPartidas.CloseEditor();
						arqueos.Remove(arqueo);
					}
					Calcular();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnRERET_Click(object sender, EventArgs e)
		{
			const string codigo = "RERET";
            gvPartidas.CloseEditor();
            decimal importe = acumulados.Sum(x => x.total);

			if (importe > 0)
			{
				if (MessageBox.Show(string.Format("¿Estas seguro(a) de realizar un retiro por la cantidad de {0:c2}?", importe), "Retiro", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					Autorizacion autorizacion = new Autorizacion();
					autorizacion.codigo = codigo;
					autorizacion.referencia = string.Format("Retiro por la cantidad de {0} al usuario {1} en la estación {2}", importe, Program.Nori.UsuarioAutenticado.usuario, Program.Nori.Estacion.nombre);
					autorizacion.comentario = Microsoft.VisualBasic.Interaction.InputBox("Comentario retiro (Opcional)", "");

					autorizacion.Agregar();

					if (!autorizacion.autorizado)
					{
						frmSolicitarAutorizacion fa = new frmSolicitarAutorizacion(autorizacion);
						fa.ShowDialog();
						autorizacion.autorizado = (fa.DialogResult == DialogResult.OK) ? true : false;
					}

					if (autorizacion.autorizado)
					{
                        Flujo flujo = new Flujo();

						flujo.codigo = codigo;
						flujo.comentario = Microsoft.VisualBasic.Interaction.InputBox("Ingrese un comentario acerca del retiro (Opcional)", "");
						flujo.autorizacion_id = autorizacion.id;
						flujo.importe = importe;

                        try
                        {
                            if (MessageBox.Show(string.Format("¿El retiro corresponde a una devolución de venta?", importe), "Retiro", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                flujo.documento_id = int.Parse(Microsoft.VisualBasic.Interaction.InputBox("Ingrese el ID del documento", ""));

                                var documento = Documento.Documentos().Where(x => x.id == flujo.documento_id).Select(x => new { x.clase, x.importe_aplicado, x.total }).First();

                                if (!documento.clase.Equals("FA") && !documento.clase.Equals("EN"))
                                {
                                    MessageBox.Show("Solo es posible realizar devoluciones de entregas y facturas.");
                                    return;
                                }

                                if (importe > documento.total)
                                {
                                    MessageBox.Show("No es posible devolver un importe mayor que el importe total del documento referenciado.");
                                    return;
                                }

                                if (importe > documento.importe_aplicado)
                                {
                                    MessageBox.Show("No es posible devolver un importe mayor que el importe aplicado del documento referenciado.");
                                    return;
                                }
                            }


                            if (flujo.Agregar())
                            {
                                arqueos.All(x => { x.flujo_id = flujo.id; return true; });
                                arqueos.ForEach(x => x.Agregar());
                                Funciones.ImprimirInformePredeterminado("IE", flujo.id);

                                if (MessageBox.Show("¿Deseas imprimir el arqueo de este retiro?", "Retiro", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                    Funciones.ImprimirInformePredeterminado("AR", flujo.id);

                                Close();
                            }
                            else
                                MessageBox.Show(NoriSDK.Nori.ObtenerUltimoError().Message);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
					}
				}
			}
		}
		private void btnRetiroFondoInicial_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (NoriSDK.PuntoVenta.EstadoCaja().Equals('A'))
				{
                    gvPartidas.CloseEditor();
                    Flujo fondo_inicial = NoriSDK.PuntoVenta.FondoInicial();

					if (!NoriSDK.PuntoVenta.FondoInicialRetirado(fondo_inicial.id))
					{

						Autorizacion autorizacion = new Autorizacion();
						autorizacion.codigo = "RERET";
						autorizacion.referencia = string.Format("Retiro del fondo inicial del usuario {0} en la estación {1}", Program.Nori.UsuarioAutenticado.usuario, Program.Nori.Estacion.nombre);
						autorizacion.comentario = Microsoft.VisualBasic.Interaction.InputBox("Comentario retiro fondo inicial (Opcional)", "");

						autorizacion.Agregar();

						if (!autorizacion.autorizado)
						{
							frmSolicitarAutorizacion fa = new frmSolicitarAutorizacion(autorizacion);
							fa.ShowDialog();
							autorizacion.autorizado = (fa.DialogResult == DialogResult.OK) ? true : false;
						}

						if (autorizacion.autorizado)
						{
							Flujo flujo = new Flujo();
							flujo.codigo = "REACA";
							flujo.comentario = Microsoft.VisualBasic.Interaction.InputBox("Ingrese un comentario acerca del retiro (Opcional)", "");
							flujo.autorizacion_id = autorizacion.id;
							flujo.tipo_cambio = fondo_inicial.tipo_cambio;
							flujo.importe = fondo_inicial.importe;
							if (flujo.Agregar())
							{
								Funciones.ImprimirInformePredeterminado("IE", flujo.id);
							}
							else
								MessageBox.Show(NoriSDK.Nori.ObtenerUltimoError().Message);
						}
					}
					else
						MessageBox.Show("El fondo inicial ya ha sido retirado anteriormente");
				}
				else
					MessageBox.Show("La caja ya ha sido cerrada");
			}
			catch (Exception ex) { MessageBox.Show("Error al retirar el fondo inicial: " + ex.Message); }
		}

		private void btnRECCA_Click(object sender, System.EventArgs e)
		{
			try
			{
				const string codigo = "RECCA";
                gvPartidas.CloseEditor();
				decimal importe = acumulados.Sum(x => x.total);

				if (NoriSDK.PuntoVenta.EstadoCaja().Equals('A'))
				{
					if (MessageBox.Show("¿Estas seguro(a) de realizar el cierre de caja?", "Cierre de caja", MessageBoxButtons.YesNo) == DialogResult.Yes)
					{
						Autorizacion autorizacion = new Autorizacion();

						autorizacion.codigo = codigo;
						autorizacion.referencia = string.Format("Cierre de caja del usuario {0} en la estación {1}", Program.Nori.UsuarioAutenticado.usuario, Program.Nori.Estacion.nombre);
						autorizacion.comentario = Microsoft.VisualBasic.Interaction.InputBox("Comentario cierre de caja (Opcional)", "");

						autorizacion.Agregar();

						if (!autorizacion.autorizado)
						{
							frmSolicitarAutorizacion fa = new frmSolicitarAutorizacion(autorizacion);
							fa.ShowDialog();
							autorizacion.autorizado = (fa.DialogResult == DialogResult.OK) ? true : false;
						}

						if (autorizacion.autorizado)
						{
							Flujo flujo = new Flujo();
							flujo.codigo = codigo;
							flujo.comentario = Microsoft.VisualBasic.Interaction.InputBox("Ingrese un comentario acerca del cierre de caja (Opcional)", "");
							flujo.autorizacion_id = autorizacion.id;
							flujo.importe = importe;
							if (flujo.Agregar())
							{
								arqueos.All(x => { x.flujo_id = flujo.id; return true; });
								arqueos.ForEach(x => x.Agregar());

								if (MessageBox.Show("¿Desea imprimir el Egreso?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
									Funciones.ImprimirInformePredeterminado("IE", flujo.id);
								if (MessageBox.Show("¿Desea imprimir el Arqueo?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
									Funciones.ImprimirInformePredeterminado("AR", flujo.id);
								if (MessageBox.Show("¿Desea imprimir el corte Corte X?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
									Funciones.ImprimirInformePredeterminado("CX", flujo.id);
								if (MessageBox.Show("¿Desea imprimir el corte Corte Z?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
									Funciones.ImprimirInformePredeterminado("CZ", flujo.id);

								Close();
							}
							else
								MessageBox.Show(NoriSDK.Nori.ObtenerUltimoError().Message);
						}
					}
				}
				else
					MessageBox.Show("La caja ya ha sido cerrada");
			}
			catch { MessageBox.Show("Error al realizar el Corte Z"); }
		}
	}
}