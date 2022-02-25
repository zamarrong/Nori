using NoriSDK;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nori
{
	public partial class frmPagos : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		Pago pago = new Pago();
		Socio socio = new Socio();
		internal List<MetodoPago.Tipo> tipos_metodos_pago;
		internal decimal importe_aplicado = 0;
		internal decimal saldo_pendiente = 0;
		const string clase = "PR";
		internal bool solo_ppd = true;
		internal bool solo_pue = true;
		public frmPagos(int id = 0)
		{
			InitializeComponent();
			this.MetodoDinamico();

			CargarListas();

			if (id != 0)
			{
				pago = Pago.Obtener(id);
				Cargar();
			}
			else
			{
				Cargar(false, true);
			}

			CargarInformes();
		}

		private void CargarInformes()
		{
			try
			{
				List<Informe> informes = Informe.Informes().Where(x => x.activo == true && x.tipo == clase).OrderBy(x => x.nombre).ToList();
				foreach (Informe informe in informes)
				{
					DevExpress.XtraBars.BarButtonItem boton = new DevExpress.XtraBars.BarButtonItem();
					DevExpress.XtraBars.BarButtonItem botonPDF = new DevExpress.XtraBars.BarButtonItem();

					boton.Name = informe.id.ToString();
					botonPDF.Name = boton.Name + "PDF";
					boton.Caption = informe.nombre;
					botonPDF.Caption = boton.Caption;
					boton.ItemClick += (object sender, DevExpress.XtraBars.ItemClickEventArgs e) => { Funciones.ImprimirInforme(informe.id, pago.id, true); };
					botonPDF.ItemClick += (object sender, DevExpress.XtraBars.ItemClickEventArgs e) => { Process.Start(@Funciones.PDFInforme(informe.id, pago.id)); };

					bbiImprimir.AddItem(boton);
					bbiPDF.AddItem(botonPDF);
				}
			}
			catch (Exception ex)
			{ MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error); }
		}
		private void CargarListas()
		{
			cbSeries.Properties.DataSource = Serie.Series().Where(x => x.clase == clase && x.activo == true).Select(x => new { x.id, x.nombre }).ToList();
			cbSeries.Properties.ValueMember = "id";
			cbSeries.Properties.DisplayMember = "nombre";

			List<int> usuario_tipos_metodos_pago = Usuario.TipoMetodoPago.TiposMetodosPago().Where(x => x.usuario_id == Program.Nori.UsuarioAutenticado.id).Select(x => x.tipo_metodo_pago_id).ToList();
			tipos_metodos_pago = (usuario_tipos_metodos_pago.Count > 0) ? MetodoPago.Tipo.Tipos().Where(x => usuario_tipos_metodos_pago.Contains(x.id)).ToList() : MetodoPago.Tipo.Tipos().Where(x => x.activo == true).ToList();

			cbMetodosPago.DataSource = tipos_metodos_pago;
			cbMetodosPago.ValueMember = "id";
			cbMetodosPago.DisplayMember = "nombre";

			cbMetodoPago.Properties.DataSource = MetodoPago.MetodosPago().Where(x => x.activo == true && x.tipo == 'E').Select(x => new { x.id, x.codigo, x.nombre }).ToList();
			cbMetodoPago.Properties.ValueMember = "id";
			cbMetodoPago.Properties.DisplayMember = "nombre";

			cbMonedas.Properties.DataSource = Moneda.Monedas().Where(x => x.activo == true).Select(x => new { x.id, x.codigo, x.nombre }).ToList();
			cbMonedas.Properties.ValueMember = "id";
			cbMonedas.Properties.DisplayMember = "nombre";
		}

		private void Cargar(bool nuevo = false, bool busqueda = false)
		{
			lblCancelado.Visible = pago.cancelado;
			cbSeries.EditValue = pago.serie_id;
			txtNumeroDocumento.Text = pago.numero_documento.ToString();
			txtNumeroDocumentoExterno.Visible = (pago.identificador_externo != 0) ? true : false;
			txtNumeroDocumentoExterno.Text = pago.numero_documento_externo.ToString();
			cbMonedas.EditValue = pago.moneda_id;


			if (pago.socio_id != 0)
				socio = Socio.Obtener(pago.socio_id);
			else
				socio = Socio.Obtener(Program.Nori.UsuarioAutenticado.socio_id);

			if (nuevo)
			{
				bbiNuevo.Enabled = bbiImprimir.Enabled = false;
				bbiGuardar.Enabled = bbiGuardarCerrar.Enabled = bbiGuardarNuevo.Enabled = true;
				lblCodigoSN.Focus();

				pago.socio_id = socio.id;

				Serie serie = Serie.ObtenerPredeterminado(clase);
				pago.serie_id = serie.id;

				cbSeries.EditValue = pago.serie_id;
				txtNumeroDocumento.Text = serie.siguiente.ToString();
			}
			else
			{
				if (busqueda)
				{
					bbiNuevo.Enabled = true;
					bbiGuardar.Enabled = bbiGuardarCerrar.Enabled = bbiGuardarNuevo.Enabled = false;
					lblCodigoSN.Focus();
				}
				else
				{
					bbiNuevo.Enabled = bbiGuardar.Enabled = bbiGuardarCerrar.Enabled = bbiGuardarNuevo.Enabled = bbiImprimir.Enabled = true;
				}
			}

			lblID.Text = pago.id.ToString();
			lblIdentificadorExterno.Text = pago.identificador_externo.ToString();

			txtCodigoSN.Text = socio.codigo;
			lblSocio.Text = socio.nombre;

			deFechaContabilizacion.DateTime = pago.fecha_contabilizacion;
			txtFechaVencimiento.Text = pago.fecha_vencimiento.ToShortDateString();
			txtFechaDocumento.Text = pago.fecha_documento.ToShortDateString();
			txtReferencia.Text = pago.referencia;
			txtComentario.Text = pago.comentario;
			cbPagoACuenta.Checked = pago.cuenta;
			cbMetodoPago.EditValue = pago.metodo_pago_id;

			txtTotal.Text = pago.total.ToString("c2");

			CargarPartidas();
			CargarDocumentoElectronico();
		}

		private void Llenar()
		{
			try
			{
				pago.metodo_pago_id = (int)cbMetodoPago.EditValue;
				if (pago.id == 0)
				{
					pago.partidas.RemoveAll(x => x.id == 0);

					pago.fecha_vencimiento = pago.fecha_contabilizacion = deFechaContabilizacion.DateTime;
					pago.referencia = txtReferencia.Text;
					pago.comentario = txtComentario.Text;
					pago.tipo_cambio = decimal.Parse(txtTipoCambio.EditValue.ToString());

					DataRow row;
					int[] listRowList = gvPartidas.GetSelectedRows();
					for (int i = 0; i < listRowList.Length; i++)
					{
						row = gvPartidas.GetDataRow(listRowList[i]);
						Pago.Partida partida = new Pago.Partida();

						partida.id = (int)row["id"];

						if (partida.id != 0)
							partida = pago.partidas.Where(x => x.id == partida.id).First();

						partida.documento_id = (int)row["documento_id"];
						partida.saldo = (decimal)row["saldo"];
						partida.fecha_vencimiento = (DateTime)row["fecha_vencimiento"];
						partida.tipo_cambio = (decimal)row["tipo_cambio"];
						partida.importe = (decimal)row["importe"];                        

						if (partida.id == 0)
							pago.partidas.Add(partida);
					}
				}
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
				gvPartidas.CloseEditor();
				gvPagos.CloseEditor();

				if (Permiso())
				{
					//if ((solo_pue && !solo_ppd) || (solo_ppd && !solo_pue))
					//{
						if (Math.Round(saldo_pendiente, 2) != 0)
							if (MessageBox.Show(string.Format("{0} del importe que se tiene que pagar no coincide con las operaciones existentes, ¿Desea contabilizar este importe como pago a cuenta?", saldo_pendiente.ToString("c2")), Text, MessageBoxButtons.YesNo) == DialogResult.No)
								pago.cuenta = true;

						if (MessageBox.Show("¿Desea guardar los cambios?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
						{
							Llenar();

							if (pago.id != 0)
								return pago.Actualizar();
							else
								return pago.Agregar();
						}
					//}
					//else
					//{
						//MessageBox.Show("No es posible guardar un pago con diferentes métodos de pago en sus documentos relacionados");
					//}
				}
				else
				{
					 MessageBox.Show("No fue posible autorizar este movimiento.");
				}

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
			if (Guardar()) { pago = Pago.Obtener(pago.id); Cargar(); } else { MessageBox.Show( "Error al guardar: " + NoriSDK.Nori.ObtenerUltimoError().Message, Text); };
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
				pago = new Pago();
				Cargar(true);
			}
		}

		private void bbiPrimero_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				pago = Pago.Obtener(Pago.Pagos().Where(x => x.financiado == false).OrderBy(x => x.id).Select(x => new { x.id }).First().id);
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
				pago = Pago.Obtener(Pago.Pagos().Where(x => x.id < pago.id && x.financiado == false).OrderByDescending(x => x.id).Select(x => new { x.id }).First().id);
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
				pago = Pago.Obtener(Pago.Pagos().Where(x => x.id > pago.id && x.financiado == false).Select(x => new { x.id }).First().id);
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
				pago = Pago.Obtener(Pago.Pagos().Where(x => x.financiado == false).OrderByDescending(x => x.id).Select(x => new { x.id }).First().id);
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
				if (pago.id != 0)
				{
					pago = new Pago();
					socio = new Socio();
					Cargar(false, true);
				}
				else
				{
					var docs = (Pago.Pagos().Where(x => (x.id == int.Parse(txtNumeroDocumento.Text) || (x.socio_id == pago.socio_id) || (x.numero_documento == int.Parse(txtNumeroDocumento.Text))) && x.financiado == false || (x.numero_documento_externo == ((Program.Nori.Configuracion.sap && int.Parse(txtNumeroDocumentoExterno.Text) != 0) ? int.Parse(txtNumeroDocumentoExterno.Text) : 1))).OrderByDescending(x => x.fecha_creacion)).Select(x => new { x.id, No = x.numero_documento, Total = x.total, Cancelado = x.cancelado, Fecha = x.fecha_documento, Referencia = x.referencia });
					DataTable pagos = docs.ToList().ToDataTable();
					if (pagos.Rows.Count > 0)
					{
						if (pagos.Rows.Count == 1)
						{
							pago = Pago.Obtener((int)pagos.Rows[0]["id"]);
							frmPagos f = new frmPagos();
							Cargar();
						}
						else
						{
							frmResultadosBusqueda f = new frmResultadosBusqueda(pagos);
							var result = f.ShowDialog();
							if (result == DialogResult.OK)
							{
								pago = Pago.Obtener(f.id);
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
			pago = new Pago();
			Cargar(true);
		}

		private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && pago.id == 0)
				Buscar();
		}

		private void CargarPartidas()
		{
			try
			{
				string query = string.Format("SELECT T0.pago_id, T1.id documento_id, T1.numero_documento, T1.clase, T1.fecha_documento, T0.fecha_vencimiento, T0.saldo, T0.tipo_cambio, T1.total, T1.moneda_id, T2.nombre moneda, T1.importe_aplicado, (CASE WHEN (select codigo from metodos_pago where id = T1.metodo_pago_id) = '99' THEN 'PPD' ELSE 'PUE' END) metodo_pago, T0.importe AS importe FROM partidas_pagos T0 JOIN documentos T1 ON T0.documento_id = T1.id JOIN monedas T2 ON T1.moneda_id = T2.id WHERE T0.pago_id = {0}", pago.id);
 
				if (pago.id == 0)
					query = string.Format("SELECT 0 id, 0 pago_id, documentos.id documento_id, numero_documento, clase, fecha_documento, fecha_vencimiento, (total - importe_aplicado) saldo, (select top 1 venta from tipos_cambio where moneda_id = documentos.moneda_id and fecha <= '{0}' order by id desc) tipo_cambio, total, moneda_id, monedas.nombre moneda, (CASE WHEN (select codigo from metodos_pago where id = documentos.metodo_pago_id) = '99' THEN 'PPD' ELSE 'PUE' END) metodo_pago, importe_aplicado, (CASE WHEN clase = 'NC' THEN ((total - importe_aplicado) * -1) ELSE (total - importe_aplicado) END) importe FROM documentos JOIN monedas ON documentos.moneda_id = monedas.id join metodos_pago ON documentos.metodo_pago_id = metodos_pago.id WHERE cancelado = 0 AND importe_aplicado < total - 0.01 AND clase IN ('FA', 'NC') AND socio_id = {1} AND (estado = 'A' OR reserva = 1)", deFechaContabilizacion.DateTime.ToString("yyyyMMdd"), pago.socio_id);

				DataTable partidas = Utilidades.EjecutarQuery(query);

				gcPartidas.DataSource = partidas;

				gcPartidas.RefreshDataSource();

				if (pago.id != 0)
					gvPartidas.SelectAll();

				Calcular();

				List<string> clases = new List<string>(new string[] { "FA", "NC" });

				deFechaContabilizacion.Properties.MaxValue = DateTime.Today;
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

					if (socio.activo)
						EstablecerSocio();
					else
						MessageBox.Show("El socio esta inactivo.");
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
			string query = string.Format("SELECT id, codigo, nombre, rfc, (SELECT direccion FROM BloqueDireccion(direccion_facturacion_id)) AS direccion FROM socios WHERE codigo like '%{0}%' OR nombre LIKE '%{0}%' AND activo = 1", q.Replace(" ", "%"));
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

		private void txtNumeroDocumento_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && txtNumeroDocumento.Text.Length > 0 && pago.id == 0)
				Buscar();
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
		}

		private void Calcular()
		{
			try
			{
				gcPagos.DataSource = pago.flujo;
				gcPagos.RefreshDataSource();

				DataRow row;

				int[] listRowList = gvPartidas.GetSelectedRows();

				btnGenerar.Enabled = solo_ppd = true;
				solo_pue = true;
				saldo_pendiente = 0;
				DateTime fecha_minima = DateTime.Today;
				for (int i = 0; i < listRowList.Length; i++)
				{
					row = gvPartidas.GetDataRow(listRowList[i]);
					fecha_minima = DateTime.Parse(row["fecha_documento"].ToString());
					saldo_pendiente += (decimal)row["importe"] * (decimal)row["tipo_cambio"];
					if (row["metodo_pago"].ToString().Equals("PUE"))
						btnGenerar.Enabled = solo_ppd = false;
					else
						solo_pue = false;
				}

				pago.Calcular();

				importe_aplicado = pago.total;
				saldo_pendiente = importe_aplicado - saldo_pendiente;

				txtSaldoPendiente.Text = saldo_pendiente.ToString("c2");
				txtImporteAplicado.Text = importe_aplicado.ToString("c2");
				txtTotal.Text = pago.total.ToString("c2");

				deFechaContabilizacion.Properties.MinValue = fecha_minima;
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
						pago.flujo[e.RowHandle].importe = TipoCambio.Convertir(pago.moneda_id, tipo_metodo_pago.moneda_id, 'C', (pago.total));

					gvPagos.FocusedColumn = gvPagos.Columns["importe"];
				}
				else if (e.Column.FieldName == "tipo_cambio")
				{
					Autorizacion autorizacion = new Autorizacion();

					autorizacion.codigo = "MOTCP";
					autorizacion.referencia = string.Format("Modificar tipo de cambio ({0}) de {1} a {2} al socio {3}", cbMonedas.Text, gvPartidas.ActiveEditor.OldEditValue, gvPartidas.ActiveEditor.EditValue, socio.codigo);
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

		private void btnGenerar_Click(object sender, EventArgs e)
		{
			try
			{
				if (solo_ppd)
				{
					Funciones.TimbrarDocumento(pago);
					CargarDocumentoElectronico();
				}
				else
				{
					MessageBox.Show("Solo es posible timbrar pagos cuyos documentos relacionados tengan el método de pago PPD.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		public async void CargarDocumentoElectronico()
		{
			try
			{
 
				if (pago.id != 0)
				{
					DocumentoElectronico documento_electronico = await Task.Run(() => pago.DocumentoElectronico());

					btnGenerar.Enabled = (documento_electronico.estado.Equals('A')) ? false : true;

					txtFolioFiscal.Text = documento_electronico.folio_fiscal;
					txtFolioFiscal.ToolTip = documento_electronico.mensaje;
					txtCadenaOriginal.Text = documento_electronico.cadena_original;

					if (documento_electronico.estado.Equals('E'))
						MessageBox.Show(documento_electronico.mensaje, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

					return;
				}

				btnGenerar.Enabled = false;

				txtFolioFiscal.Text = string.Empty;
				txtCadenaOriginal.Text = string.Empty;
			}
			catch { }
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

		private void cbMonedas_EditValueChanged(object sender, EventArgs e)
		{
			try
			{
				pago.moneda_id = (int)cbMonedas.EditValue;
				txtTipoCambio.EditValue = TipoCambio.Venta(pago.moneda_id);
				txtTipoCambio.Visible = (Program.Nori.Configuracion.moneda_id != pago.moneda_id) ? true : false;
			} catch { }
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			CancelarDocumentoElectronico();
		}

		private void CancelarDocumentoElectronico()
		{
			DocumentoElectronico documento_electronico = pago.DocumentoElectronico();
			if (documento_electronico.estado.Equals('A') && documento_electronico.folio_fiscal.Length > 0 && Program.Nori.UsuarioAutenticado.NivelAcceso() >= 50)
			{
				if (MessageBox.Show("¿Deseas cancelar el CFDI?", "Cancelar CFDI", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					Funciones.CancelarTimbreDocumentoElectronico(documento_electronico);
					CargarDocumentoElectronico();
				}
			}
		}

		private void deFechaContabilizacion_EditValueChanged(object sender, EventArgs e)
		{
			try
			{
				if (pago.id == 0)
				{
					int rows = gvPartidas.DataRowCount;
					for(int i = 0; i < rows; i++)
					{
						DataRow row = gvPartidas.GetDataRow(i);
						string query = string.Format("select top 1 venta from tipos_cambio where moneda_id = {0} and fecha <= '{1}' order by id desc", row["moneda_id"],  deFechaContabilizacion.DateTime.ToString("yyyyMMdd"));
						decimal tipo_cambio = Utilidades.EjecutarDecimal(query);
						row["tipo_cambio"] = tipo_cambio;
					}
					gcPagos.RefreshDataSource();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void lblImportarFolioFiscal_Click(object sender, EventArgs e)
		{
			ImportarFolioFiscal();
		}

		private void ImportarFolioFiscal()
		{
			try
			{
				if (pago.id != 0)
				{
					if (Program.Nori.UsuarioAutenticado.rol.Equals('A'))
					{
						DocumentoElectronico documento_electronico = pago.DocumentoElectronico();
						if (documento_electronico.estado != 'A' && documento_electronico.folio_fiscal.Length == 0)
						{
							string folio_fiscal = Microsoft.VisualBasic.Interaction.InputBox("Ingresa el folio fiscal (UUID)", "Importar folio fiscal", "");
							documento_electronico.pago_id = pago.id;
							documento_electronico.estado = 'A';
							documento_electronico.folio_fiscal = folio_fiscal;
							if ((documento_electronico.id == 0) ? documento_electronico.Agregar() : documento_electronico.Actualizar())
								MessageBox.Show("Se importó el folio fiscal correctamente");
							else
								MessageBox.Show(string.Format("Error al importar folio fiscal: {0}", NoriSDK.Nori.ObtenerUltimoError().Message), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				CargarDocumentoElectronico();
			}
		}

		private void bbiCancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (MessageBox.Show("¿Estas seguro de cancelar este pago?", "Cancelar pago", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				if (!pago.cancelado)
				{
					if (Permiso())
					{
						pago.comentario = Microsoft.VisualBasic.Interaction.InputBox("Ingresa un comentario sobre la cancelación", "Cancelación pago", pago.comentario);
						if (pago.Cancelar(true))
						{
							RecargarPago();
							CancelarDocumentoElectronico();
						}
						else
						{
							MessageBox.Show(NoriSDK.Nori.ObtenerUltimoError().Message);
						}
					}
				}
				else
					MessageBox.Show("Este pago ya ha sido cancelado.");
			}
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


		private void RecargarPago()
		{
			if (pago.id != 0)
			{
				pago = Pago.Obtener(pago.id);
				Cargar();
			}
			else
			{
				bbiNuevo.PerformClick();
			}
		}

		private void bbiPagosFinanciados_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			frmPagosFinanciados f = new frmPagosFinanciados();
			f.Show();
		}

		private void lblCodigoSN_Click(object sender, EventArgs e)
		{
			frmSocios form = new frmSocios(socio.id);
			form.ShowDialog();
		}

		private void lblMonedas_Click(object sender, EventArgs e)
		{
			frmMonedas form = new frmMonedas(pago.moneda_id);
			form.ShowDialog();
		}

		private void bbiMapaRelaciones_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			frmMapaRelacionesPagos f = new frmMapaRelacionesPagos(pago);
			f.Show();
		}

		private void txtNumeroDocumentoExterno_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && txtNumeroDocumento.Text.Length > 0 && pago.id == 0)
				Buscar();
		}

		private void bbiEnviar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				if (pago.id != 0)
				{
					int informe_id = Informe.Informes().Where(x => x.tipo == "PR" && x.activo == true && x.predeterminado_correo_electronico == true).Select(x => x.id).First();

					frmCorreoElectronico f = new frmCorreoElectronico();
					f.socio = socio;
					f.anexos.Add(Funciones.PDFInforme(informe_id, pago.id));

					try
					{
						DocumentoElectronico documento_electronico = pago.DocumentoElectronico();
						if (documento_electronico.id != 0)
						{
							if (documento_electronico.estado.Equals('A'))
							{
								f.anexos.Add(string.Format(@"{0}\{1}.xml", Program.Nori.Configuracion.directorio_xml, documento_electronico.folio_fiscal));
							}
						}
					}
					catch { }

					f.ShowDialog();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

        private void bbiNuevoMetodoPago_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Nuevo();
        }
    }
}