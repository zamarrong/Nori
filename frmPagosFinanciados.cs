using NoriSDK;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Nori
{
	public partial class frmPagosFinanciados : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		Pago pago = new Pago();
		Socio socio = new Socio();
		internal List<MetodoPago.Tipo> tipos_metodos_pago;
		internal decimal importe_aplicado = 0;
		internal decimal saldo_pendiente = 0;
		internal bool solo_vencidos = true;
		internal bool solo_no_vencidos = true;
		const string clase = "PR";
		public frmPagosFinanciados(int id = 0)
		{
			InitializeComponent();
			this.MetodoDinamico();

			//Renovaciòn sin intereses, renovacion de documetnos sin vencer

			CargarListas();

			if (id != 0)
			{
				pago = Pago.Obtener(id);
				Cargar();
			}
			else
			{
				Cargar(true, false);
			}
		}

		private void CargarListas()
		{
			List<int> usuario_tipos_metodos_pago = Usuario.TipoMetodoPago.TiposMetodosPago().Where(x => x.usuario_id == Program.Nori.UsuarioAutenticado.id).Select(x => x.tipo_metodo_pago_id).ToList();
			tipos_metodos_pago = (usuario_tipos_metodos_pago.Count > 0) ? MetodoPago.Tipo.Tipos().Where(x => usuario_tipos_metodos_pago.Contains(x.id)).ToList() : MetodoPago.Tipo.Tipos().Where(x => x.activo == true).ToList();

			cbMetodosPago.DataSource = tipos_metodos_pago;
			cbMetodosPago.ValueMember = "id";
			cbMetodosPago.DisplayMember = "nombre";
		}

		private void Cargar(bool nuevo = false, bool busqueda = false)
		{
			if (pago.socio_id != 0)
				socio = Socio.Obtener(pago.socio_id);
			else
				socio = Socio.Obtener(Program.Nori.UsuarioAutenticado.socio_id);

			if (nuevo)
			{
				lblCodigoSN.Focus();

				pago.socio_id = socio.id;

				Serie serie = Serie.ObtenerPredeterminado(clase);
				pago.serie_id = serie.id;
			}
			else
			{
				lblCodigoSN.Focus();
			}

			txtCodigoSN.Text = socio.codigo;
			lblSocio.Text = socio.nombre;
			lblEstadoCredito.Text = string.Format("Límite de crédito: {0} | Disponible: {1}", socio.limite_credito.ToString("c2"), (socio.limite_credito - socio.balance).ToString("c2"));
			if (socio.DocumentosVencidos())
				lblEstadoCredito.ForeColor = Color.Firebrick;
			else
				lblEstadoCredito.ForeColor = Color.DimGray;

			txtTotal.Text = pago.total.ToString("c2");

			CargarPartidas();
		}

		private void Guardar()
		{
			try
			{
				if (NoriSDK.PuntoVenta.EstadoCaja().Equals('C'))
				{
					if (MessageBox.Show("¿Deseas realizar una apertura de caja?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
					{
						PuntoVenta.frmIngresos f = new PuntoVenta.frmIngresos("INACA");
						f.ShowDialog();
					}
					else
					{
						MessageBox.Show("Para poder realizar este movimiento es necesario realizar una apertura de caja.");
					}
				}
				else
				{
					if (Permiso())
					{
						if (Math.Round(saldo_pendiente, 2) >= 0)
						{
							if (MessageBox.Show("¿Desea guardar los cambios?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
							{
								DataRow row;
								string referencia = Funciones.DigitosAleatorios(10);
								int[] listRowList = gvPartidas.GetSelectedRows();

								foreach (Flujo flujo_pagare in pago.flujo.Where(x => x.tipo_metodo_pago_id >= 9).ToList())
								{
									if (!solo_vencidos && !solo_no_vencidos)
									{
										MessageBox.Show("Para realizar una renovación seleccione únicamente documentos vencidos o no vencidos.");
										return;
									}

									Documento documento = new Documento();

									documento.clase = "FA";
									documento.EstablecerSocio(socio);
									documento.AgregarPartida(MetodoPago.Tipo.Tipos().Where(x => x.id == flujo_pagare.tipo_metodo_pago_id).Select(x => x.codigo).First(), flujo_pagare.importe);

									switch (flujo_pagare.tipo_metodo_pago_id)
									{
										case 9:
											documento.condicion_pago_id = 11;
											break;
										case 10:
											documento.condicion_pago_id = 12;
											break;
										case 11:
											documento.condicion_pago_id = 13;
											break;
									}

									documento.referencia = referencia;
									documento.CalcularTotal();

									if (!documento.Agregar())
									{
										MessageBox.Show("No es posible agregar el pagaré de renovación: " + NoriSDK.Nori.ObtenerUltimoError().Message);
										return;
									}
									else
									{
										Funciones.ImprimirInformePredeterminado(documento.clase, documento.id, 1);
									}
								}

								for (int i = 0; i < listRowList.Length; i++)
								{
									row = gvPartidas.GetDataRow(listRowList[i]);
									Pago.Partida partida = Pago.Partida.Obtener((int)row["id"]);

									partida.documento_id = (int)row["documento_id"];
									partida.saldo = (decimal)row["saldo"];
									partida.fecha_vencimiento = (DateTime)row["fecha_vencimiento"];
									partida.tipo_cambio = (decimal)row["tipo_cambio"];
									partida.intereses = (decimal)row["intereses"];
									partida.importe = (decimal)row["importe"];

									Flujo flujo = new Flujo();

									flujo.documento_id = partida.documento_id;
									flujo.pago_id = (int)row["pago_id"];
									flujo.codigo = (solo_vencidos || solo_no_vencidos) ? "INREN" : "INPAG";
									flujo.referencia = referencia;
									flujo.tipo_metodo_pago_id = 1;
									flujo.importe = partida.importe;

									if (partida.Actualizar())
									{
										if (flujo.Agregar())
										{
											Pago pago = Pago.Obtener(flujo.pago_id);
											pago.Actualizar(false, false);
										}
									}
									else
									{
										MessageBox.Show("No es posible agregar el abono, revise la información y trate nuevamente.");
										return;
									}
								}

								Dictionary<string, object> parametros = new Dictionary<string, object>();

								parametros.Add("referencia", referencia);

								Funciones.ImprimirInforme(23, parametros);

								MessageBox.Show("Se guardó la información correctamente.");
								Close();
							}
						}
						else
						{
							MessageBox.Show("Para continuar es necesario liquidar el total del importe a pagar.");
						}
					}
					else
					{
						MessageBox.Show("No fue posible autorizar este movimiento.");
					}
				}
			}
			catch
			{
				MessageBox.Show(NoriSDK.Nori.ObtenerUltimoError().Message, Text);
			}
		}
		private void bbiGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			Guardar();
		}
		private void CargarPartidas()
		{
			try
			{
				string query = string.Format("SELECT *, (T1.saldo_tmp + T1.intereses) AS saldo, T1.importe_tmp + T1.intereses importe FROM (SELECT *, (CASE WHEN (T0.dias_atraso - T0.dias_tolerancia) > 0 THEN ( T0.saldo_tmp * (((T0.porcentaje_interes_retraso) * (T0.dias_atraso) + (T0.porcentaje_interes_moratorio))) / 100) ELSE T0.intereses_tmp END) intereses FROM (SELECT T0.id id, T0.pago_id, T1.id documento_id, T1.numero_documento, T1.clase, T1.reserva, T1.comentario, T1.fecha_documento, T0.fecha_vencimiento, DATEDIFF(DAY, T0.fecha_vencimiento, GETDATE()) dias_atraso, T3.dias_tolerancia, T4.porcentaje_interes_retraso, T3.porcentaje_interes_moratorio, (CASE WHEN (select financiado from pagos where id = T0.pago_id) = 1 THEN (T0.saldo + T0.intereses) - T0.importe ELSE T0.saldo END) saldo_tmp, T0.tipo_cambio, T1.total, t1.moneda_id, T2.nombre moneda, T1.importe_aplicado, T0.intereses as intereses_tmp, (CASE WHEN (select financiado from pagos where id = T0.pago_id) = 1 THEN (T0.saldo + T0.intereses) - T0.importe ELSE T0.importe END) AS importe_tmp FROM partidas_pagos T0 JOIN documentos T1 ON T0.documento_id = T1.id JOIN monedas T2 ON T1.moneda_id = T2.id JOIN condiciones_pago T3 ON T1.condicion_pago_id = T3.id JOIN socios T4 ON T1.socio_id = T4.id JOIN pagos T5 ON T0.pago_id = T5.id WHERE T5.socio_id = {0} AND T5.financiado = 1) T0) T1 WHERE T1.importe_tmp > 0", socio.id);

				DataTable partidas = Utilidades.EjecutarQuery(query);

				gcPartidas.DataSource = partidas;

				gcPartidas.RefreshDataSource();

				if (pago.id != 0)
					gvPartidas.SelectAll();

				Calcular();

				List<string> clases = new List<string>(new string[] { "FA", "NC" });
			}
			catch { }
		}

		private void txtCodigoSN_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && txtCodigoSN.Text.Length > 0)
			{
				try
				{
					socio = Socio.Socios().Where(x => x.codigo == txtCodigoSN.Text).First();
					EstablecerSocio();
				}
				catch
				{
					MessageBox.Show("No se encontraron resultados.");
				}
			}

			if (e.Control && e.KeyCode == Keys.S)
			{
				frmAltaRapidaSocio f = new frmAltaRapidaSocio();
				f.Show();
			}
		}

		public void EstablecerSocio()
		{
			try
			{
				pago.socio_id = socio.id;

				txtCodigoSN.Text = socio.codigo;
				lblSocio.Text = socio.nombre;
				lblEstadoCredito.Text = string.Format("Límite de crédito: {0} | Disponible: {1}", socio.limite_credito.ToString("c2"), (socio.limite_credito - socio.balance).ToString("c2"));
				if (socio.DocumentosVencidos())
					lblEstadoCredito.ForeColor = Color.Firebrick;
				else
					lblEstadoCredito.ForeColor = Color.DimGray;

				try
				{
					lblDireccion.Text = Socio.Direccion.Obtener(socio.direccion_facturacion_id).Bloque();
				}
				catch
				{
					lblDireccion.Text = string.Empty;
					MessageBox.Show("El socio no tiene establecida la dirección de facturación.");
					return;
				}

				CargarPartidas();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void txtCodigoSN_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			if (e.KeyCode == Keys.Tab && txtCodigoSN.Text.Length > 0)
				BuscarSocios(txtCodigoSN.Text);
		}

		private void BuscarSocios(string q)
		{
			string query = string.Format("SELECT id, codigo, nombre, rfc, (SELECT direccion FROM BloqueDireccion(direccion_facturacion_id)) AS direccion FROM socios WHERE codigo like '%{0}%' OR nombre LIKE '%{0}%'", q.Replace(" ", "%"));
			DataTable socios = Utilidades.EjecutarQuery(query);

			if (socios.Rows.Count > 0)
			{
				if (socios.Rows.Count == 1)
				{
					socio = Socio.Obtener((int)socios.Rows[0]["id"]);
				}
				else
				{
					frmResultadosBusqueda f = new frmResultadosBusqueda(socios);
					var result = f.ShowDialog();
					if (result == DialogResult.OK)
						socio = Socio.Obtener(f.id);
				}

				if (socio.activo)
					EstablecerSocio();
				else
					MessageBox.Show("El socio esta inactivo.");
			}
			else
				MessageBox.Show(string.Format("No se encontraron resultados para {0}", q), Text);
		}
		private void gvPagos_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete)
			{
				if (pago.flujo.Count > 0)
					pago.flujo.Remove(pago.flujo[gvPagos.GetSelectedRows()[0]]);
				Calcular();
			}

			if (e.Control && e.KeyCode == Keys.N)
				Nuevo();

			if (e.Alt && e.KeyCode == Keys.M)
				gvPagos.FocusedColumn = gvPagos.Columns["tipo_metodo_pago_id"];

			if (e.Alt && e.KeyCode == Keys.I)
				gvPagos.FocusedColumn = gvPagos.Columns["importe"];

            if (e.Control && e.KeyCode == Keys.B)
            {
                pago.flujo[gvPagos.GetSelectedRows()[0]].importe = saldo_pendiente;
                gvPagos.CloseEditor();
            }
		}
		private void Calcular()
		{
			try
			{
				gcPagos.DataSource = pago.flujo;
				gcPagos.RefreshDataSource();

				DataRow row;

				int[] listRowList = gvPartidas.GetSelectedRows();

				saldo_pendiente = 0;
				DateTime fecha_minima = DateTime.Today;
				solo_vencidos = solo_no_vencidos = true;
				for (int i = 0; i < listRowList.Length; i++)
				{
					row = gvPartidas.GetDataRow(listRowList[i]);
					fecha_minima = DateTime.Parse(row["fecha_documento"].ToString());
					saldo_pendiente += (decimal)row["importe"] * (decimal)row["tipo_cambio"];
					DateTime fecha_vencimiento = DateTime.Parse(row["fecha_vencimiento"].ToString());
					if (fecha_vencimiento > DateTime.Today)
						solo_vencidos = false;
					else
						solo_no_vencidos = false;
				}

				pago.Calcular();

				importe_aplicado = pago.total;
				saldo_pendiente = importe_aplicado - saldo_pendiente;

				txtSaldoPendiente.Text = saldo_pendiente.ToString("c2");
				txtImporteAplicado.Text = importe_aplicado.ToString("c2");
				txtTotal.Text = pago.total.ToString("c2");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		private void gvPagos_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
		{
			try
			{
				if (e.Column.FieldName == "tipo_metodo_pago_id")
				{
					MetodoPago.Tipo tipo_metodo_pago = tipos_metodos_pago.Where(x => x.id == pago.flujo[e.RowHandle].tipo_metodo_pago_id).First();

					if (tipo_metodo_pago.referencia)
						pago.flujo[e.RowHandle].referencia = Microsoft.VisualBasic.Interaction.InputBox("Ingresar referencia", Text, "");
					else
						pago.flujo[e.RowHandle].referencia = string.Empty;

					pago.flujo[e.RowHandle].EstablecerTipoCambio();

					if (pago.moneda_id != tipo_metodo_pago.moneda_id || (!tipo_metodo_pago.cambio && !tipo_metodo_pago.documento))
						pago.flujo[e.RowHandle].importe = TipoCambio.Convertir(pago.moneda_id, tipo_metodo_pago.moneda_id, 'C', (saldo_pendiente * -1));

					gvPagos.FocusedColumn = gvPagos.Columns["importe"];
				}
				else if (e.Column.FieldName == "tipo_cambio")
				{
					Autorizacion autorizacion = new Autorizacion();

					autorizacion.codigo = "MOTCP";
					autorizacion.referencia = string.Format("Modificar tipo de cambio de {0} a {1} al socio {2}", gvPartidas.ActiveEditor.OldEditValue, gvPartidas.ActiveEditor.EditValue, socio.codigo);
					autorizacion.comentario = Microsoft.VisualBasic.Interaction.InputBox("Comentario modificar tipo de cambio (Opcional)", "");

					autorizacion.Agregar();

					if (!autorizacion.autorizado)
					{
						frmSolicitarAutorizacion fa = new frmSolicitarAutorizacion(autorizacion);
						fa.ShowDialog();
						autorizacion.autorizado = (fa.DialogResult == DialogResult.OK) ? true : false;
					}

					if (!autorizacion.autorizado)
						pago.partidas[e.RowHandle].tipo_cambio = (decimal)gvPartidas.ActiveEditor.OldEditValue;
				}
				Calcular();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		private void Nuevo()
		{
			try
			{
				pago.AgregarPago();
				Calcular();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				gvPagos.Focus();
				gvPagos.MoveLast();
				gvPagos.FocusedColumn = (pago.flujo[gvPagos.GetSelectedRows()[0]].tipo_metodo_pago_id == 0) ? gvPagos.Columns["tipo_metodo_pago_id"] : gvPagos.Columns["importe"];
			}
		}
		private void gvPartidas_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
		{
			Calcular();
		}
		private void gvPartidas_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
		{
			try
			{
				if (e.Column.FieldName == "importe")
				{
					if ((decimal)gvPartidas.GetRowCellValue(e.RowHandle, "importe") > (decimal)gvPartidas.GetRowCellValue(e.RowHandle, "saldo"))
					{
						gvPartidas.SetRowCellValue(e.RowHandle, "importe", (decimal)gvPartidas.GetRowCellValue(e.RowHandle, "saldo"));
						MessageBox.Show("No es posible ingresar un importe mayor que el saldo del documento.");
					}

					Calcular();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void gvPartidas_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
		{
			try
			{
				if (e.RowHandle >= 0)
				{
					if (DateTime.Today > Convert.ToDateTime(gvPartidas.GetRowCellValue(e.RowHandle, gvPartidas.Columns["fecha_vencimiento"])))
					{
						e.Appearance.BackColor = Color.Salmon;
						e.Appearance.BackColor2 = Color.White;
					}
				}
			}
			catch { }
		}

		public bool Permiso(bool cancelacion = false)
		{
			try
			{
				Permiso permiso = NoriSDK.Permiso.Obtener(Program.Nori.UsuarioAutenticado.id, "PR", true);

				if (permiso.id != 0)
				{
					if ((!permiso.agregar && pago.id == 0) || (!permiso.actualizar && pago.id != 0))
					{
						Autorizacion autorizacion = new Autorizacion();

						string accion;
						if (cancelacion)
							accion = "Cancelación";
						else if (pago.id == 0)
							accion = "Creación";
						else
							accion = "Actualización";

						autorizacion.codigo = "CRUDO";
						autorizacion.usuario_autorizacion_id = permiso.usuario_autorizacion_id;
						autorizacion.referencia = string.Format("{0} del pago {1} al cliente {2} por {3}", accion, "PR", socio.nombre, pago.total.ToString("c2"));
						autorizacion.comentario = Microsoft.VisualBasic.Interaction.InputBox("CRUD (Opcional)", "");

						autorizacion.Agregar();

						if (!autorizacion.autorizado)
						{
							frmSolicitarAutorizacion fa = new frmSolicitarAutorizacion(autorizacion);
							fa.ShowDialog();
							autorizacion.autorizado = (fa.DialogResult == DialogResult.OK) ? true : false;
						}

						return autorizacion.autorizado;
					}
				}

				return true;
			}
			catch
			{
				return false;
			}
		}

		private void lblCodigoSN_Click(object sender, EventArgs e)
		{
			frmSocios form = new frmSocios(socio.id);
			form.ShowDialog();
		}

		private void bbiNuevo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			Nuevo();
		}
	}
}