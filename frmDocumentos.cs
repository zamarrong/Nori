using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using NoriSDK;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nori
{
	public partial class frmDocumentos : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		public Documento documento { get; set; } = new Documento();
		public Socio socio { get; set; } = new Socio();

		List<Documento.Estado> estados_documento = Documento.Estado.Estados();
		List<Documento.Clase> clases = Documento.Clase.Clases();
		List<UnidadMedida> unidades_medida = new List<UnidadMedida>();
		//UnidadMedida.UnidadesMedida().Where(x => x.activo == true).Select(x => new { x.id, x.nombre});

		List<string> copiar_de = new List<string>();
		List<string> copiar_a = new List<string>();
		public frmDocumentos(string clase, int id = 0)
		{
			InitializeComponent();

			//if (!Program.Nori.Empresa.rfc.Equals("XAXX010101000"))
			//	Application.Exit();

			this.MetodoDinamico();
			EventoControl.SuscribirEventos(this);

			documento.clase = clase;
			documento.tipo = Documento.Clase.Clases().Where(x => x.clase == clase).First().tipo;

			xtraTabPageDocumentoElectronico.PageVisible = documento.EsDocumentoElectronico();

			if (!documento.clase.Equals("FA") && !documento.clase.Equals("NC") && !documento.clase.Equals("EN") && !documento.clase.Equals("PE") && !documento.clase.Equals("DV"))
				bbiCancelar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

			if (documento.tipo.Equals('I') || documento.clase.Equals("EN") || documento.clase.Equals("CC") || documento.clase.Equals("EM"))
				lblFechaVencimiento.Text = "Fecha entrega";

			Permisos();
			CargarListas();

			if (id != 0)
			{
				documento = Documento.Obtener(id);
				Cargar();
			}
			else
			{
				Cargar(Program.Nori.Configuracion.documentos_modo_nuevo, !Program.Nori.Configuracion.documentos_modo_nuevo);
			}

			CargarInformes(clase);

			if (documento.clase.Equals("AE") || documento.clase.Equals("AS") || documento.clase.Equals("IF"))
			{
				lblCodigoSN.Visible = txtCodigoSN.Visible = lblSocio.Visible = lblFechaCreacion.Visible = txtFechaCreacion.Visible = lblMonedas.Visible = cbMonedas.Visible = lblVendedores.Visible = cbVendedores.Visible = lblMonederos.Visible = cbMonederos.Visible = false;
			}

			if (documento.clase.Equals("IF"))
			{
				gvPartidas.Columns.Where(x => x.Name == "gridColumnDiferencia").First().Visible = true;
				gvPartidas.Columns.Where(x => x.Name == "gridColumnDiferencia").First().VisibleIndex = 3;
			}

			if (Program.Nori.Configuracion.pedimentos)
				gvPartidas.Columns.Where(x => x.Name == "gridColumnNumeroPedimento").First().Visible = true;

			if (Program.Nori.Configuracion.documentos_modo_nuevo)
				txtArticulo.Focus();
		}

		private void CargarInformes(string clase)
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
					boton.ItemClick += (object sender, DevExpress.XtraBars.ItemClickEventArgs e) => { Funciones.ImprimirInforme(informe.id, documento.id, true); };
					botonPDF.ItemClick += (object sender, DevExpress.XtraBars.ItemClickEventArgs e) => { Process.Start(@Funciones.PDFInforme(informe.id, documento.id)); };

					bbiImprimir.AddItem(boton);
					bbiPDF.AddItem(botonPDF);
				}
			}
			catch (Exception ex)
			{ MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error); }
		}

		private void CargarCopiar()
		{
			try
			{
				if (documento.id == 0)
					bbiCopiar.Caption = "Copiar de";
				else
					bbiCopiar.Caption = "Copiar a";

				bbiCopiar.ItemLinks.Clear();

				List<string> cds = new List<string>();

				cds = (documento.id == 0) ? copiar_de : copiar_a;

				foreach (string cd in cds)
				{
					Documento.Clase clase = clases.Where(x => x.clase == cd).First();

					DevExpress.XtraBars.BarButtonItem boton = new DevExpress.XtraBars.BarButtonItem();

					boton.Caption = clase.nombre;
					boton.ItemClick += (object sender, DevExpress.XtraBars.ItemClickEventArgs e) => { CopiarDocumento(clase); };

					if (documento.estado.Equals('C') && documento.clase.Equals("FA") && clase.clase.Equals("EN"))
						continue;

					bbiCopiar.AddItem(boton);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void CopiarDocumento(Documento.Clase clase, bool ts = false)
		{
			if (documento.id != 0)
			{
				if (clase.clase.Equals("EN") && documento.clase.Equals("FA") && !documento.reserva)
				{
					MessageBox.Show("No es posible copiar una factura a entrega si la factura no es de reserva.");
					return;
				}

				frmDocumentos f = new frmDocumentos(clase.clase);

				f.documento.CopiarDe(documento, clase.clase, true);

				if (f.documento.clase.Equals("EM") && documento.clase.Equals("OC"))
					if (MessageBox.Show("¿Desea realizar una recepción de mercancías diferencial?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
						f.documento.partidas.ForEach(x => { x.cantidad = 0; });

				if (f.documento.clase.Equals("EN") && documento.clase.Equals("PE"))
				{
					if (MessageBox.Show("¿Desea realizar una entrega de mercancías diferencial?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
					{
						f.documento.partidas.ForEach(x => { x.cantidad = 0; });
						if (Program.Nori.UsuarioAutenticado.almacen_id != 0)
						{
							if (MessageBox.Show("¿Cargar solo partidas del almacén predeterminado para este usuario?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
								f.documento.partidas.RemoveAll(x => x.almacen_id != Program.Nori.UsuarioAutenticado.almacen_id);
						}
					}
				}

				f.documento.descuento = f.documento.porcentaje_descuento = 0;

				if (documento.estado.Equals('C') && documento.clase.Equals("FA"))
				{
					f.documento.partidas.ForEach(x => { x.documento_id = 0; });
					Documento.Referencia referencia = new Documento.Referencia();
					referencia.documento_referencia_id = documento.id;
					f.documento.referencias.Add(referencia);
				}

				try
				{
					if (ts)
					{
						f.documento.partidas.ForEach(x => { x.almacen_id = x.almacen_destino_id; x.almacen_destino_id = Program.Nori.UsuarioAutenticado.almacen_id; x.CalcularTotal(); x.ObtenerStock(); });
					}
					else
					{
						f.documento.partidas.ForEach(x => { x.CalcularTotal(); x.ObtenerStock(); });
					}

				}
				catch { }

				f.Cargar(true);
				f.Show();
				Close();
			}
			else
			{
				try
				{
					var docs = (Documento.Documentos().Where(x => x.socio_id == documento.socio_id && x.clase == clase.clase && x.tipo == clase.tipo && x.estado == 'A' && x.cancelado == false).OrderByDescending(x => x.fecha_creacion)).Select(x => new { ID = x.id, No = x.numero_documento, Total = x.total, Aplicado = x.importe_aplicado, Estado = x.estado, Fecha = x.fecha_documento });
					DataTable documentos = docs.ToList().ToDataTable();
					if (documentos.Rows.Count > 0)
					{
						frmResultadosBusqueda f = new frmResultadosBusqueda(documentos, true);

						var result = f.ShowDialog();

						if (result == DialogResult.OK)
						{
							if (f.ids.Count > 1)
							{
								MessageBox.Show("Este documento fue creado a partir de múltiples documentos por lo que se omitira el encabezado y pie del documento y solo se copiaran las lineas de los documentos seleccionados");

								List<Documento.Partida> partidas = Documento.Partida.Partidas().Where(x => f.ids.Contains(x.documento_id) && x.cantidad_pendiente > 0).ToList();
								decimal importe_aplicado = Documento.Documentos().Where(x => f.ids.Contains(x.id)).Sum(x => x.importe_aplicado);
								var descuentos = Documento.Documentos().Where(x => f.ids.Contains(x.id) && x.porcentaje_descuento > 0).Select(x => new { x.id, x.porcentaje_descuento }).ToList();
								var flujo = Flujo.Flujos().Where(x => f.ids.Contains(x.documento_id)).ToList();
								documento.AgregarFlujos(flujo);

								foreach (var descuento in descuentos)
								{
									partidas.Where(x => x.documento_id == descuento.id).ToList().ForEach(x => { x.porcentaje_descuento = (x.porcentaje_descuento + descuento.porcentaje_descuento); x.CalcularTotal(); });
								}

								partidas.All(x => { x.cantidad = x.cantidad_pendiente; x.cantidad_pendiente = x.cantidad; return true; });

								documento.partidas.Clear();
								documento.partidas = partidas;

								documento.importe_aplicado = importe_aplicado;
								documento.descuento = documento.porcentaje_descuento = 0;

								documento.partidas.ForEach(x => { x.CalcularTotal(); x.ObtenerStock(); });
								Cargar(true);
							}
							else
							{
								documento.CopiarDe(Documento.Obtener(f.ids[0]), documento.clase, true);
								documento.descuento = documento.porcentaje_descuento = 0;
								documento.partidas.ForEach(x => { x.CalcularTotal(); x.ObtenerStock(); });
								Cargar(true);
							}
						}
					}
					else
					{
						MessageBox.Show("No se encontraron resultados", Text);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		#region bbi
		private void bbiGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (Guardar())
				RecargarDocumento();
			else
				MessageBox.Show("Error al guardar: " + NoriSDK.Nori.ObtenerUltimoError().Message, Text);
		}

		private void bbiGuardarCerrar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (Guardar())
				Close();
		}

		private void bbiGuardarNuevo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (Guardar())
				Nuevo();
			else
				MessageBox.Show("Error al guardar: " + NoriSDK.Nori.ObtenerUltimoError().Message, Text);
		}

		private void bbiPrimero_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				documento = Documento.Obtener(Documento.Documentos().Where(x => x.clase == documento.clase && x.serie_id == ObtenerSerieID()).OrderBy(x => x.numero_documento).Select(x => new { x.id }).First().id);
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
				documento = Documento.Obtener(Documento.Documentos().Where(x => x.clase == documento.clase && x.numero_documento < documento.numero_documento && x.serie_id == ObtenerSerieID()).OrderByDescending(x => x.numero_documento).Select(x => new { x.id }).First().id);
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
				documento = Documento.Obtener(Documento.Documentos().Where(x => x.clase == documento.clase && x.numero_documento > documento.numero_documento && x.serie_id == ObtenerSerieID()).OrderBy(x => x.numero_documento).Select(x => new { x.id }).First().id);
			}
			catch
			{
				bbiPrimero.PerformClick();
			}
			finally
			{
				Cargar();
			}
		}

		private void bbiUltimo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				documento = Documento.Obtener(Documento.Documentos().Where(x => x.clase == documento.clase && x.serie_id == ObtenerSerieID()).OrderByDescending(x => x.numero_documento).Select(x => new { x.id }).First().id);
				Cargar();
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

		private int ObtenerSerieID()
		{
			try
			{
				int serie_id = ((cbSeries.EditValue.IsNullOrEmpty() || (int)cbSeries.EditValue == 0) ? Serie.Series().Where(x => x.clase == documento.clase && x.predeterminado == true).Select(x => new { x.id }).First().id : (int)cbSeries.EditValue);
				return serie_id;
			}
			catch
			{
				return 0;
			}
		}

		private void bbiBuscar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			Buscar();
		}

		private void bbiNuevo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			Nuevo();
		}
		#endregion

		private void Permisos()
		{
			switch (Program.Nori.UsuarioAutenticado.rol)
			{
				case 'C':
					searchRibbonPageGroup.Visible = false;
					break;
			}
		}
		private void Buscar()
		{
			try
			{
				if (documento.id != 0)
				{
					string clase = documento.clase;
					documento = new Documento();
					documento.clase = clase;
					socio = new Socio();
					Cargar(false, true);
				}
				else
				{
					var docs = (Documento.Documentos().Where(x => (x.referencia == txtReferencia.Text && x.referencia != "") || (x.id == int.Parse(txtNumeroDocumento.Text) && x.clase == documento.clase) || (x.socio_id == ((documento.socio_id == 0) ? -1 : documento.socio_id) && x.clase == documento.clase) || (x.numero_documento == int.Parse(txtNumeroDocumento.Text) && x.clase == documento.clase) || (x.numero_documento_externo == ((Program.Nori.Configuracion.sap && int.Parse(txtNumeroDocumentoExterno.Text) != 0) ? int.Parse(txtNumeroDocumentoExterno.Text) : 1) && x.clase == documento.clase)).OrderByDescending(x => x.fecha_creacion)).Select(x => new { ID = x.id, Clase = documento.clase, No = x.numero_documento, NoSAP = x.numero_documento_externo, Total = x.total, Aplicado = x.importe_aplicado, Estado = x.estado, Fecha = x.fecha_documento });
					DataTable documentos = docs.ToList().ToDataTable();
					if (documentos.Rows.Count > 0)
					{
						if (documentos.Rows.Count == 1)
						{
							if (documentos.Rows[0]["clase"].ToString() == documento.clase)
							{
								documento = Documento.Obtener((int)documentos.Rows[0]["id"]);
								Cargar();
							}
						}
						else
						{
							frmResultadosBusqueda f = new frmResultadosBusqueda(documentos);
							var result = f.ShowDialog();
							if (result == DialogResult.OK)
							{
								documento = Documento.Obtener(f.id);
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
		private void Nuevo()
		{
			string clase = documento.clase;
			documento = new Documento(clase);

			Cargar(true);
		}
		internal void Cargar(bool nuevo = false, bool busqueda = false)
		{
			try
			{
				cbSeries.EditValue = documento.serie_id;
				txtNumeroDocumento.Text = documento.numero_documento.ToString();
				txtNumeroDocumentoExterno.Visible = (documento.identificador_externo != 0) ? true : false;
				txtNumeroDocumentoExterno.Text = documento.numero_documento_externo.ToString();
				lbReferencias.Visible = false;

				if (documento.socio_id != 0)
					socio = Socio.Obtener(documento.socio_id);

				if (documento.estado.Equals('C'))
					cbMonedas.Enabled = txtCodigoSN.Enabled = txtTipoCambio.Enabled = txtArticulo.Enabled = bbiCopiar.Enabled = bbiGuardar.Enabled = bbiGuardarNuevo.Enabled = bbiGuardarCerrar.Enabled = bbiPagar.Enabled = gvPartidas.OptionsBehavior.Editable = false;
				else
					cbMonedas.Enabled = txtCodigoSN.Enabled = txtTipoCambio.Enabled = txtArticulo.Enabled = bbiCopiar.Enabled = bbiGuardar.Enabled = bbiGuardarNuevo.Enabled = bbiGuardarCerrar.Enabled = bbiPagar.Enabled = gvPartidas.OptionsBehavior.Editable = true;

				if (bbiCopiar.Enabled)
					CargarCopiar();

				if (nuevo)
				{
					bbiNuevo.Enabled = bbiPDF.Enabled = bbiImprimir.Enabled = false;
					cbAnticipo.Enabled = cbReserva.Enabled = txtArticulo.Enabled = bbiGuardar.Enabled = bbiGuardarCerrar.Enabled = bbiGuardarNuevo.Enabled = bbiPagar.Enabled = true;

					if (documento.socio_id == 0 && !documento.tipo.Equals('C'))
					{
						socio = Socio.Obtener(Program.Nori.UsuarioAutenticado.socio_id);
						EstablecerSocio();
					}
					else if (documento.id == 0 && documento.socio_id != 0)
					{
						EstablecerSocio();
					}

					Serie serie = Serie.ObtenerPredeterminado(documento.clase);
					documento.serie_id = serie.id;

					cbSeries.EditValue = documento.serie_id;
					txtNumeroDocumento.Text = serie.siguiente.ToString();
				}
				else
				{
					cbAnticipo.Enabled = cbReserva.Enabled = false;

					if (busqueda)
					{
						txtArticulo.Enabled = bbiGuardar.Enabled = bbiGuardarCerrar.Enabled = bbiGuardarNuevo.Enabled = bbiPagar.Enabled = bbiCopiar.Enabled = bbiPDF.Enabled = bbiImprimir.Enabled = false;
						txtCodigoSN.Enabled = txtNumeroDocumentoExterno.Visible = bbiNuevo.Enabled = true;
					}
					else
					{
						bbiNuevo.Enabled = bbiGuardar.Enabled = bbiGuardarCerrar.Enabled = bbiGuardarNuevo.Enabled = bbiPagar.Enabled = bbiPDF.Enabled = bbiImprimir.Enabled = true;
						txtCodigoSN.Enabled = false;
					}
				}

				Text = clases.Where(x => x.clase == documento.clase).First().nombre;
				lblClase.Text = Text;
				if (documento.numero_documento != 0)
					Text += string.Format(" ({0}) ", documento.numero_documento);
				Text += string.Format(" - {0}", estados_documento.Where(x => x.estado == documento.estado).First().nombre);

				//General
				deFechaVencimiento.Enabled = deFechaContabilizacion.Enabled = (documento.id == 0) ? true : false;
				lblIdentificadorExterno.Visible = (documento.identificador_externo != 0) ? true : false;

				if (documento.clase.Equals("PE"))
					cbCOD.Visible = true;
				else
					cbCOD.Visible = false;

				if (documento.clase.Equals("FA"))
					cbAnticipo.Visible = cbReserva.Visible = true;
				else
					cbAnticipo.Visible = cbReserva.Visible = false;

				bcID.Text = lblID.Text = documento.id.ToString();
				lblIdentificadorExterno.Text = documento.identificador_externo.ToString();
				lblCancelado.Visible = documento.cancelado;
				lblImpreso.Visible = documento.impreso;
				cbCOD.Checked = documento.cod;
				cbReserva.Checked = documento.reserva;
				cbAnticipo.Checked = documento.anticipo;

				txtCodigoSN.Text = socio.codigo;
				lblSocio.Text = socio.nombre;
				lblRFC.Text = socio.rfc;
				txtFechaCreacion.Text = documento.fecha_creacion.ToShortDateString();
				cbMonedas.EditValue = documento.moneda_id;
				deFechaContabilizacion.DateTime = documento.fecha_contabilizacion;
				deFechaVencimiento.DateTime = documento.fecha_vencimiento;
				txtFechaDocumento.Text = documento.fecha_documento.ToShortDateString();
				cbVendedores.EditValue = documento.vendedor_id;
				txtReferencia.Text = documento.referencia;
				txtComentario.Text = documento.comentario;
				//Logística
				if (documento.socio_id != 0 || documento.id != 0)
				{
					CargarDirecciones();
					CargarPersonasContacto();
				}
				txtDistancia.Text = documento.distancia.ToString();
				cbClasesExpedicion.EditValue = documento.clase_expedicion_id;
				cbChoferes.EditValue = documento.chofer_id;
				cbVehiculos.EditValue = documento.vehiculo_id;
				cbRemolques.EditValue = documento.remolque_id;
				cbRutas.EditValue = documento.ruta_id;
				cbForaneo.Checked = documento.foraneo;
				cbSupervisores.EditValue = documento.supervisor_id;
				cbCausalidades.EditValue = documento.causalidad_id;
				cbSeguimiento.Checked = documento.seguimiento;
				cbEstadoSeguimiento.SelectedIndex = documento.estado_seguimiento;
				//Finanzas
				cbCondicionesPago.EditValue = documento.condicion_pago_id;
				cbMetodosPago.EditValue = documento.metodo_pago_id;
				cbProyectos.EditValue = documento.proyecto_id;
				cbCanales.EditValue = documento.canal_id;
				txtCuentaPago.Text = documento.cuenta_pago;
				txtOrdenCompra.Text = documento.orden_compra;
				txtTipoCambio.Text = documento.tipo_cambio.ToString();
				//Documento electrónico
				cbGenerarDocumentoElectronico.Checked = (nuevo) ? documento.GenerarDocumentoElectronico() : documento.generar_documento_electronico;
				if (documento.clase.Equals("EN") && Program.Nori.Empresa.rfc.Equals("JAIJ640806EF5"))
					cbGenerarDocumentoElectronico.Enabled = false;
				cbGlobal.Checked = documento.global;
				cbUsoPrincipal.EditValue = documento.uso_principal;
				CargarDocumentoElectronico();
				//Extras
				cbAlmacenOrigen.EditValue = documento.almacen_id;
				cbAlmacenDestino.EditValue = documento.almacen_destino_id;

				cbMonederos.EditValue = documento.monedero_id;
				if (documento.usuario_creacion_id != 0)
				{
					lblCreacion.Text = string.Format("Creación: {0} ({1})", documento.fecha_creacion.ToString(), Usuario.Usuarios().Where(x => x.id == documento.usuario_creacion_id).Select(x => x.usuario).First());
					lblActualizacion.Text = string.Format("Actualización: {0} ({1})", documento.fecha_actualizacion.ToString(), Usuario.Usuarios().Where(x => x.id == documento.usuario_actualizacion_id).Select(x => x.usuario).First());
				}

				if (documento.id == 0 || documento.clase.Equals("CO") || documento.clase.Equals("PE") || documento.clase.Equals("CC") || documento.clase.Equals("OC") || documento.clase.Equals("ST"))
					gvPartidas.OptionsBehavior.Editable = true;
				else
					gvPartidas.OptionsBehavior.Editable = false;

				Calcular();
			}
			catch { }
			finally
			{
				if (nuevo)
					txtArticulo.Focus();
				else if (busqueda)
					txtCodigoSN.Focus();
			}
		}
		public async void CargarDocumentoElectronico()
		{
			try
			{
				lblAlmacenOrigen.Visible = lblAlmacenDestino.Visible = cbAlmacenOrigen.Visible = cbAlmacenDestino.Visible = gvPartidas.Columns.Where(x => x.Name == "gridColumnAlmacenDestino").First().Visible = (documento.tipo.Equals('I'));
				gvPartidas.Columns.Where(x => x.Name == "gridColumnUbicacion").First().Visible = Almacen.Almacenes().Any(x => x.ubicaciones == true);
				if (gvPartidas.Columns.Where(x => x.Name == "gridColumnUbicacion").First().Visible == true && documento.clase.Equals("TS"))
					gvPartidas.Columns.Where(x => x.Name == "gridColumnUbicacionDestino").First().Visible = true;
				else
					gvPartidas.Columns.Where(x => x.Name == "gridColumnUbicacionDestino").First().Visible = false;


				if (documento.id != 0)
				{
					gvPartidas.Columns.Where(x => x.Name == "gridColumnStock").First().Visible = gvPartidas.Columns.Where(x => x.Name == "gridColumnPrecioPieza").First().Visible = gvPartidas.Columns.Where(x => x.Name == "gridColumnListaPrecio").First().Visible = false;

					Sincronizacion sincronizacion = Sincronizacion.Obtener("documentos", documento.id);
					lblSincronizacion.Text = (sincronizacion.id == 0) ? string.Empty : sincronizacion.error;

					if (documento.EsDocumentoElectronico())
					{
						DocumentoElectronico documento_electronico = await Task.Run(() => documento.DocumentoElectronico());

						btnGenerar.Enabled = btnGenerarRFCGenerico.Enabled = (documento_electronico.estado.Equals('A')) ? false : true;

						if ((documento.clase.Equals("EN") || documento.clase.Equals("TS")) && Program.Nori.Empresa.rfc.Equals("JAIJ640806EF5"))
							cbGenerarDocumentoElectronico.Enabled = btnGenerar.Enabled = btnGenerarRFCGenerico.Enabled = false;

						txtFolioFiscal.Text = documento_electronico.folio_fiscal;
						txtFolioFiscal.ToolTip = documento_electronico.mensaje;
						txtCadenaOriginal.Text = documento_electronico.cadena_original;
						txtSelloCFD.Text = documento_electronico.sello_CFD;

						if (documento_electronico.estado.Equals('E'))
							MessageBox.Show(documento_electronico.mensaje, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

						CargarReferencias();
						CargarAnexos();

						return;
					}
				}
				else
				{
					gvPartidas.Columns.Where(x => x.Name == "gridColumnStock").First().Visible = gvPartidas.Columns.Where(x => x.Name == "gridColumnPrecioPieza").First().Visible = gvPartidas.Columns.Where(x => x.Name == "gridColumnListaPrecio").First().Visible = true;
				}

				btnGenerar.Enabled = btnGenerarRFCGenerico.Enabled = false;

				txtFolioFiscal.Text = string.Empty;
				txtCadenaOriginal.Text = string.Empty;
				txtSelloCFD.Text = string.Empty;
			}
			catch { }
		}

		private async void CargarDirecciones()
		{
			try
			{
				if (documento.socio_id != 0)
				{
					cbDireccionesFacturacion.Properties.DataSource = await Task.Run(() => Socio.Direccion.Direcciones().Where(x => x.socio_id == documento.socio_id && x.tipo == 'F').Select(x => new { x.id, x.nombre }).ToList());
					cbDireccionesFacturacion.Properties.ValueMember = "id";
					cbDireccionesFacturacion.Properties.DisplayMember = "nombre";

					cbDireccionesOrigen.Properties.DataSource = await Task.Run(() => Socio.Direccion.Direcciones().Where(x => x.socio_id == Program.Nori.UsuarioAutenticado.socio_id && x.tipo == 'E').Select(x => new { x.id, x.nombre }).ToList());
					cbDireccionesOrigen.Properties.ValueMember = "id";
					cbDireccionesOrigen.Properties.DisplayMember = "nombre";

					var direcciones_envio = await Task.Run(() => Socio.Direccion.Direcciones().Where(x => x.socio_id == documento.socio_id && x.tipo == 'E').Select(x => new { x.id, x.nombre }).ToList());
					if (documento.direccion_envio_id != 0 && !direcciones_envio.Any(x => x.id == documento.direccion_envio_id))
					{
						direcciones_envio.Add(new { id = documento.direccion_envio_id, nombre = "Dirección del documento" });
					}

					cbDireccionesEnvio.Properties.DataSource = direcciones_envio;
					cbDireccionesEnvio.Properties.ValueMember = "id";
					cbDireccionesEnvio.Properties.DisplayMember = "nombre";

					cbDireccionesFacturacion.EditValue = documento.direccion_facturacion_id;
					cbDireccionesEnvio.EditValue = documento.direccion_envio_id;
					cbDireccionesOrigen.EditValue = documento.direccion_origen_id;

					BloqueDirecciones();
				}
			}
			catch { }
		}

		private async void CargarPersonasContacto()
		{
			try
			{
				if (documento.socio_id != 0)
				{
					cbPersonasContacto.Properties.DataSource = await Task.Run(() => Socio.PersonaContacto.PersonasContacto().Where(x => x.socio_id == socio.id).Select(x => new { x.id, x.nombre }).ToList());
					cbPersonasContacto.Properties.ValueMember = "id";
					cbPersonasContacto.Properties.DisplayMember = "nombre";

					cbPersonasContacto.EditValue = documento.persona_contacto_id;
				}
			}
			catch { }

		}

		private void CargarMonedero()
		{
			try
			{
				if (documento.monedero_id != 0)
					if (MessageBox.Show("El documento ya tiene asignado un monedero, ¿desea remplazarlo?", Text, MessageBoxButtons.YesNo) != DialogResult.Yes)
						return;

				string folio_monedero = Microsoft.VisualBasic.Interaction.InputBox("Ingresa el folio del monedero electrónico", "Monedero electrónico", "");
				documento.monedero_id = Monedero.Monederos().Where(x => x.folio == folio_monedero).Select(x => new { x.id }).First().id;
				cbMonederos.EditValue = documento.monedero_id;
			}
			catch
			{
				MessageBox.Show("No se encontraron resultados", "Monedero electrónico");
			}
		}

		private async void BloqueDirecciones()
		{
			try
			{
				txtDireccionFacturacion.Text = await Task.Run(() => Socio.Direccion.Obtener((int)cbDireccionesFacturacion.EditValue).Bloque());
				txtDireccionEnvio.Text = await Task.Run(() => Socio.Direccion.Obtener((int)cbDireccionesEnvio.EditValue).Bloque());
				txtDireccionOrigen.Text = await Task.Run(() => Socio.Direccion.Obtener((int)cbDireccionesOrigen.EditValue).Bloque());
			}
			catch { }
		}

		private void CargarListas()
		{
			try
			{
				string clase = documento.clase;

				cbSeries.Properties.DataSource = Serie.Series().Where(x => x.clase == clase && x.activo == true).Select(x => new { x.id, x.nombre }).ToList();
				cbSeries.Properties.ValueMember = "id";
				cbSeries.Properties.DisplayMember = "nombre";

				cbVendedores.Properties.DataSource = Vendedor.Vendedores().Where(x => x.activo == true).Select(x => new { x.id, x.nombre }).ToList();
				cbVendedores.Properties.ValueMember = "id";
				cbVendedores.Properties.DisplayMember = "nombre";

				cbMonedas.Properties.DataSource = Moneda.Monedas().Where(x => x.activo == true).Select(x => new { x.id, x.codigo, x.nombre }).ToList();
				cbMonedas.Properties.ValueMember = "id";
				cbMonedas.Properties.DisplayMember = "nombre";

				List<int> usuarios_almacenes = Usuario.Almacen.Almacenes().Where(x => x.usuario_id == Program.Nori.UsuarioAutenticado.id).Select(x => x.almacen_id).ToList();
				var almacenes = Almacen.Almacenes().Where(x => x.activo == true).Select(x => new { x.id, x.codigo, x.nombre }).ToList();
				cbAlmacenOrigen.Properties.DataSource = cbAlmacenes.DataSource = (usuarios_almacenes.Count > 0) ? almacenes.Where(x => usuarios_almacenes.Contains(x.id)).Select(x => new { x.id, x.codigo, x.nombre }).ToList() : almacenes;
				cbAlmacenesDestino.DataSource = cbAlmacenDestino.Properties.DataSource = almacenes;
				cbAlmacenOrigen.Properties.ValueMember = cbAlmacenDestino.Properties.ValueMember = cbAlmacenes.ValueMember = "id";
				cbAlmacenOrigen.Properties.DisplayMember = cbAlmacenDestino.Properties.DisplayMember = cbAlmacenes.DisplayMember = "codigo";

				unidades_medida = UnidadMedida.UnidadesMedida().Where(x => x.activo == true).ToList();
				cbUnidadesMedida.DataSource = unidades_medida;
				cbUnidadesMedida.ValueMember = "id";
				cbUnidadesMedida.DisplayMember = "nombre";

				cbUbicaciones.DataSource = Almacen.Ubicacion.Ubicaciones().Where(x => x.activo == true).Select(x => new { x.id, x.codigo, x.ubicacion });
				cbUbicaciones.ValueMember = "id";
				cbUbicaciones.DisplayMember = "ubicacion";

				List<int> usuarios_listas_precios = Usuario.ListaPrecio.ListasPrecios().Where(x => x.usuario_id == Program.Nori.UsuarioAutenticado.id).Select(x => x.lista_precio_id).ToList();
				cbListasPrecios.DataSource = (usuarios_listas_precios.Count > 0) ? ListaPrecio.ListasPrecios().Where(x => usuarios_listas_precios.Contains(x.id)).Select(x => new { x.id, x.nombre }) : ListaPrecio.ListasPrecios().Where(x => x.activo == true).Select(x => new { x.id, x.nombre });
				cbListasPrecios.ValueMember = "id";
				cbListasPrecios.DisplayMember = "nombre";

				cbTiposEmpaques.DataSource = TipoEmpaque.TiposEmpaques().Where(x => x.activo == true).Select(x => new { x.id, x.nombre }).ToList();
				cbTiposEmpaques.ValueMember = "id";
				cbTiposEmpaques.DisplayMember = "nombre";

				cbCondicionesPago.Properties.DataSource = CondicionesPago.CondicionesPagos().Where(x => x.activo == true).Select(x => new { x.id, x.nombre }).ToList();
				cbCondicionesPago.Properties.ValueMember = "id";
				cbCondicionesPago.Properties.DisplayMember = "nombre";

				cbMetodosPago.Properties.DataSource = MetodoPago.MetodosPago().Where(x => x.activo == true && x.tipo == (documento.tipo.Equals('V') ? 'E' : 'S')).Select(x => new { x.id, x.nombre }).ToList();
				cbMetodosPago.Properties.ValueMember = "id";
				cbMetodosPago.Properties.DisplayMember = "nombre";

				cbProyectos.Properties.DataSource = Proyecto.Proyectos().Where(x => x.activo == true).Select(x => new { x.id, x.nombre }).ToList();
				cbProyectos.Properties.ValueMember = "id";
				cbProyectos.Properties.DisplayMember = "nombre";

				cbClasesExpedicion.Properties.DataSource = ClaseExpedicion.ClasesExpedicion().Where(x => x.activo == true).Select(x => new { x.id, x.codigo, x.nombre }).ToList();
				cbClasesExpedicion.Properties.ValueMember = "id";
				cbClasesExpedicion.Properties.DisplayMember = "nombre";

				cbChoferes.Properties.DataSource = Chofer.Choferes().Where(x => x.activo == true).Select(x => new { x.id, x.codigo, x.nombre }).ToList();
				cbChoferes.Properties.ValueMember = "id";
				cbChoferes.Properties.DisplayMember = "nombre";

				cbVehiculos.Properties.DataSource = Vehiculo.Vehiculos().Where(x => x.activo == true).Select(x => new { x.id, x.codigo, x.nombre }).ToList();
				cbVehiculos.Properties.ValueMember = "id";
				cbVehiculos.Properties.DisplayMember = "nombre";

				cbRemolques.Properties.DataSource = Remolque.Remolques().Where(x => x.activo == true).Select(x => new { x.id, x.codigo, x.nombre }).ToList();
				cbRemolques.Properties.ValueMember = "id";
				cbRemolques.Properties.DisplayMember = "nombre";

				cbSupervisores.Properties.DataSource = Supervisor.Supervisores().Where(x => x.activo == true).Select(x => new { x.id, x.codigo, x.nombre }).ToList();
				cbSupervisores.Properties.ValueMember = "id";
				cbSupervisores.Properties.DisplayMember = "nombre";

				cbCausalidades.Properties.DataSource = Causalidad.Causalidades().Where(x => x.activo == true).Select(x => new { x.id, x.codigo, x.nombre }).ToList();
				cbCausalidades.Properties.ValueMember = "id";
				cbCausalidades.Properties.DisplayMember = "nombre";

				cbCanales.Properties.DataSource = Canal.Canales().Where(x => x.activo == true).Select(x => new { x.id, x.codigo, x.nombre }).ToList();
				cbCanales.Properties.ValueMember = "id";
				cbCanales.Properties.DisplayMember = "nombre";

				cbRutas.Properties.DataSource = Ruta.Rutas().Where(x => x.activo == true).Select(x => new { x.id, x.codigo, x.nombre }).ToList();
				cbRutas.Properties.ValueMember = "id";
				cbRutas.Properties.DisplayMember = "nombre";

				cbMonederos.Properties.DataSource = Utilidades.EjecutarQuery("select monederos.id, socios.codigo, monederos.folio from monederos join socios on monederos.socio_id = socios.id where monederos.activo = 1");
				cbMonederos.Properties.ValueMember = "id";
				cbMonederos.Properties.DisplayMember = "folio";

				cbUsoPrincipal.Properties.DataSource = Documento.UsoCFDI.UsosCFDI();
				cbUsoPrincipal.Properties.ValueMember = "uso";
				cbUsoPrincipal.Properties.DisplayMember = "nombre";

				copiar_de = clases.Where(x => x.clase == documento.clase).First().CopiarDe();
				copiar_a = clases.Where(x => x.clase == documento.clase).First().CopiarA();
			}
			catch { }
		}

		private void Calcular()
		{
			try
			{
				gcPartidas.DataSource = documento.partidas;
				gcPartidas.RefreshDataSource();

				documento.CalcularTotal();

				txtTipoCambio.Text = documento.tipo_cambio.ToString("n4");

				txtSubTotal.Text = documento.subtotal.ToString("c2");
				txtPorcentajeDescuento.Text = documento.porcentaje_descuento.ToString("n2");
				txtDescuento.Text = documento.descuento.ToString("c2");
				txtImpuesto.Text = documento.impuesto.ToString("c2");
				txtTotal.Text = documento.total.ToString("c2");
				txtImporteAplicado.Text = documento.importe_aplicado.ToString("c2");

				try
				{
					lblPartidas.Text = string.Format("Partidas {0}", documento.numero_partidas);
					lblArticulos.Text = string.Format("Artículos {0}", documento.cantidad_partidas);

					lblUtilidad.Text = string.Format("Utilidad {0}", ((documento.partidas.Sum(x => x.precio) - documento.partidas.Sum(x => x.costo)) / documento.partidas.Sum(x => x.precio)).ToString("p2"));
				}
				catch { }
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void BuscarSocios(string q)
		{
			try
			{
				string query = string.Format("SELECT id, codigo Codigo, nombre Nombre, rfc RFC, (SELECT direccion FROM BloqueDireccion(direccion_facturacion_id)) AS 'Dirección de facturación' FROM socios WHERE (codigo like '%{0}%' OR nombre LIKE '%{0}%' OR rfc LIKE '%{0}%') AND tipo = '{1}' AND activo = 1", q.Replace(" ", "%"), (documento.tipo.Equals('C')) ? "P" : "C");
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
			catch { }
		}

		public void EstablecerSocio()
		{
			try
			{
				Cursor = Cursors.WaitCursor;
				if (documento.EstablecerSocio(socio))
				{
					txtCodigoSN.Text = socio.codigo;
					lblSocio.Text = socio.nombre;
					lblRFC.Text = socio.rfc;

					cbVendedores.EditValue = documento.vendedor_id;
					cbMetodosPago.EditValue = documento.metodo_pago_id;
					txtCuentaPago.Text = documento.cuenta_pago;
					cbCondicionesPago.EditValue = documento.condicion_pago_id;
					cbMonederos.EditValue = documento.monedero_id;
					cbUsoPrincipal.EditValue = documento.uso_principal;

					CargarDirecciones();
					CargarPersonasContacto();
					Calcular();

					if (socio.id != Program.Nori.UsuarioAutenticado.socio_id)
					{
						if (documento.clase.Equals("FA") || documento.clase.Equals("EN"))
						{
							if (socio.balance > socio.limite_credito)
							{
								if (MessageBox.Show(string.Format("{0} - {1} Límite de crédito excedido en {2:c2}. ¿Desea Continuar?", socio.codigo, socio.nombre, (socio.limite_credito - socio.balance) * -1), Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
								{
									Close();
								}
							}
						}
					}

					if (Program.Nori.Empresa.rfc.Equals("SFE191219K23") || Program.Nori.Empresa.rfc.Equals("QFS970203EJ6"))
					{
						var condicion_pago = CondicionesPago.Obtener(socio.condicion_pago_id);
						if ((documento.clase.Equals("EN") || documento.clase.Equals("PE") || documento.clase.Equals("FA")) && condicion_pago.dias_extra == 0)
						{
							cbCondicionesPago.Enabled = false;
							cbMetodosPago.Enabled = true;
						}
						else
						{
							cbCondicionesPago.Enabled = true;

							cbCondicionesPago.Properties.DataSource = CondicionesPago.CondicionesPagos().Where(x => x.activo == true && (x.dias_extra == 0 || x.id == socio.condicion_pago_id)).Select(x => new { x.id, x.nombre }).ToList();
							cbCondicionesPago.Properties.ValueMember = "id";
							cbCondicionesPago.Properties.DisplayMember = "nombre";
						}
					}

					if (socio.orden_compra && (documento.clase.Equals("FA") || documento.clase.Equals("EN") || documento.clase.Equals("PE")))
						OrdenCompra();

					txtArticulo.Text = string.Empty;
					txtArticulo.Focus();
				}
				else
				{
					MessageBox.Show(NoriSDK.Nori.ObtenerUltimoError().Message);
				}
				Cursor = Cursors.Default;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public void OrdenCompra()
		{
			try
			{
				string orden_compra = Microsoft.VisualBasic.Interaction.InputBox("Ingresa el número de orden de compra.", "Orden de compra", documento.orden_compra);
				if (orden_compra.Length <= 0 & socio.orden_compra)
				{
					MessageBox.Show("La número de la orden de compra es obligatoria.");
					OrdenCompra();
				}
				if (orden_compra.Length <= 15)
					documento.orden_compra = orden_compra;
				else
					MessageBox.Show("El número de la orden de compra no puede exceder los 15 caracteres.");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				txtOrdenCompra.Text = documento.orden_compra;
				txtArticulo.Focus();
			}
		}

		private bool Llenar()
		{
			try
			{
				documento.cod = cbCOD.Checked;
				documento.reserva = cbReserva.Checked;
				documento.anticipo = cbAnticipo.Checked;

				documento.fecha_documento = documento.fecha_contabilizacion = deFechaContabilizacion.DateTime;
				documento.fecha_vencimiento = deFechaVencimiento.DateTime;
				documento.serie_id = (int)cbSeries.EditValue;
				documento.condicion_pago_id = (int)cbCondicionesPago.EditValue;
				documento.moneda_id = (int)cbMonedas.EditValue;
				documento.tipo_cambio = decimal.Parse(txtTipoCambio.EditValue.ToString());
				documento.metodo_pago_id = (int)cbMetodosPago.EditValue;
				documento.proyecto_id = (cbProyectos.EditValue.IsNullOrEmpty()) ? 0 : (int)cbProyectos.EditValue;
				documento.cuenta_pago = txtCuentaPago.Text;
				documento.vendedor_id = (int)cbVendedores.EditValue;
				documento.monedero_id = (cbMonederos.EditValue.IsNullOrEmpty()) ? 0 : (int)cbMonederos.EditValue;
				documento.direccion_facturacion_id = (int)cbDireccionesFacturacion.EditValue;
				documento.direccion_envio_id = (int)cbDireccionesEnvio.EditValue;
				documento.direccion_origen_id = (cbDireccionesOrigen.EditValue.IsNullOrEmpty()) ? 0 : (int)cbDireccionesOrigen.EditValue;
				documento.distancia = int.Parse(txtDistancia.Text);
				documento.persona_contacto_id = (cbPersonasContacto.EditValue.IsNullOrEmpty()) ? 0 : (int)cbPersonasContacto.EditValue;
				documento.clase_expedicion_id = (cbClasesExpedicion.EditValue.IsNullOrEmpty()) ? 0 : (int)cbClasesExpedicion.EditValue;
				documento.chofer_id = (cbChoferes.EditValue.IsNullOrEmpty()) ? 0 : (int)cbChoferes.EditValue;
				documento.vehiculo_id = (cbVehiculos.EditValue.IsNullOrEmpty()) ? 0 : (int)cbVehiculos.EditValue;
				documento.remolque_id = (cbRemolques.EditValue.IsNullOrEmpty()) ? 0 : (int)cbRemolques.EditValue;
				documento.ruta_id = (cbRutas.EditValue.IsNullOrEmpty()) ? 0 : (int)cbRutas.EditValue;
				documento.foraneo = cbForaneo.Checked;
				documento.supervisor_id = (cbSupervisores.EditValue.IsNullOrEmpty()) ? 0 : (int)cbSupervisores.EditValue;
				documento.causalidad_id = (cbCausalidades.EditValue.IsNullOrEmpty()) ? 0 : (int)cbCausalidades.EditValue;
				documento.seguimiento = cbSeguimiento.Checked;
				documento.estado_seguimiento = cbEstadoSeguimiento.SelectedIndex;
				documento.canal_id = (cbCanales.EditValue.IsNullOrEmpty()) ? 0 : (int)cbCanales.EditValue;
				documento.orden_compra = txtOrdenCompra.Text;
				documento.referencia = txtReferencia.Text;
				documento.comentario = txtComentario.Text;
				documento.generar_documento_electronico = cbGenerarDocumentoElectronico.Checked;
				documento.global = cbGlobal.Checked;
				documento.uso_principal = (cbUsoPrincipal.EditValue.IsNullOrEmpty()) ? Documento.UsoCFDI.ObtenerPredeterminado() : cbUsoPrincipal.EditValue.ToString();

				documento.almacen_id = (cbAlmacenOrigen.EditValue.IsNullOrEmpty()) ? 0 : (int)cbAlmacenOrigen.EditValue;
				documento.almacen_destino_id = (cbAlmacenDestino.EditValue.IsNullOrEmpty()) ? 0 : (int)cbAlmacenDestino.EditValue;

				if (Usuario.Almacen.Almacenes().Any(x => x.usuario_id == Program.Nori.UsuarioAutenticado.id))
				{
					List<int> almacenes = Usuario.Almacen.Almacenes().Where(x => x.usuario_id == Program.Nori.UsuarioAutenticado.id).Select(x => x.almacen_id).ToList();
					if (documento.partidas.Any(x => !almacenes.Contains(x.almacen_id)))
					{
						MessageBox.Show("No puedes utilizar uno o más almacenes de los establecidos en las partidas.", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return false;
					}
				}

				try
				{
					int almacen_id = Serie.Series().Where(x => x.id == documento.serie_id).Select(x => x.almacen_id).First();
					if (almacen_id != 0)
					{
						if (documento.partidas.Any(x => x.almacen_id != almacen_id))
						{
							MessageBox.Show(string.Format("Solo es posible utilizar el almacén {0} con esta serie.", Almacen.Almacenes().Where(x => x.id == almacen_id).Select(x => x.codigo).First()), Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
							return false;
						}
					}
				}
				catch { }

				try
				{
					if (Usuario.Serie.Series().Any(x => x.usuario_id == Program.Nori.UsuarioAutenticado.id))
					{
						List<int> series = Usuario.Serie.Series().Where(x => x.usuario_id == Program.Nori.UsuarioAutenticado.id).Select(x => x.serie_id).ToList();
						if (!series.Contains(documento.serie_id))
						{
							MessageBox.Show("No tienes autorización para utilizar esta serie.", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
							return false;
						}
					}
				}
				catch { }

				return VerificarExistencias();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}

		private bool VerificarExistencias()
		{
			try
			{
				if (documento.clase.Equals("EN") || documento.clase.Equals("FA") || documento.clase.Equals("TS") || (documento.clase.Equals("PE") && (Program.Nori.Empresa.rfc.Equals("CVR981030480") || Program.Nori.Empresa.rfc.Equals("JAIJ640806EF5"))))
				{
					if (!Program.Nori.Configuracion.venta_articulo_stock_cero)
					{
						Funciones.Cargando("Verificando existencias", "Por favor espere...");
						List<Documento.Partida> partidas_verificar = (documento.id == 0) ? documento.partidas : documento.partidas.Where(x => x.id == 0).ToList();
						bool stock_negativo = false;

						if (Program.Nori.Configuracion.inventario_sap)
						{
							foreach (Documento.Partida partida in partidas_verificar)
							{
								if (partida.documento_id != 0 && documento.clase == "FA")
								{
									string clase_documento_base = Documento.Documentos().Where(x => x.id == partida.documento_id).Select(x => x.clase).First();
									if (clase_documento_base == "EN")
										stock_negativo = false;
								}
								else
								{
									stock_negativo = FuncionesSAP.StockNegativo(partida.cantidad, partida.sku, unidades_medida.Where(x => x.id == partida.unidad_medida_id).Select(x => x.codigo).First(), Almacen.Almacenes().Where(x => x.id == partida.almacen_id).Select(x => x.codigo).First());
								}

								if (stock_negativo && !documento.reserva)
								{
									Funciones.DescartarCargando();
									MessageBox.Show(string.Format("La cantidad recae en un inventario negativo ({0}).", partida.sku));
									return false;
								}
							}
						}
						else
						{

							partidas_verificar.ForEach(x => x.ObtenerStock());

							switch (documento.clase)
							{
								case "PE":
									stock_negativo = documento.partidas.Any(x => x.stock < x.cantidad);
									break;
								case "EN":
									stock_negativo = documento.partidas.Any(x => x.stock < x.cantidad);
									break;
								case "FA":
									stock_negativo = documento.partidas.Any(x => x.stock < x.cantidad && x.documento_id == 0);
									break;
								case "TS":
									stock_negativo = documento.partidas.Any(x => x.stock < x.cantidad);
									break;
							}
						}

						if (stock_negativo && !documento.reserva)
						{
							Funciones.DescartarCargando();
							MessageBox.Show(string.Format("La cantidad recae en un inventario negativo ({0}).", documento.partidas.Where(x => x.stock < x.cantidad).Select(x => x.sku).First()));
							return false;
						}
					}

					if (!Program.Nori.Configuracion.venta_precio_menor_costo && documento.tipo.Equals('V'))
					{
						Funciones.Cargando("Verificando precios", "Por favor espere...");

						if (documento.partidas.Any(x => x.precio < x.costo))
						{
							Funciones.DescartarCargando();
							MessageBox.Show(string.Format("No es posible vender un artículo a menos del costo ({0}).", documento.partidas.Where(x => x.precio < x.costo).Select(x => x.sku).First()));
							return false;
						}
					}
				}

				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			finally
			{
				Funciones.DescartarCargando();
			}
		}

		private bool Guardar()
		{
			try
			{
				gvPartidas.CloseEditor();
				txtArticulo.Focus();

				if (MessageBox.Show("¿Desea guardar los cambios?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					if (Llenar())
					{
						if (CondicionesPago.CondicionesPagos().Any(x => x.id == documento.condicion_pago_id && x.pago_requerido == true) && documento.id == 0 && documento.clase.Equals("FA"))
						{
							GuardarPOS();
							return true;
						}
						else
						{
							if (documento.identificador_externo == 0 && documento.estado != 'C' && Program.Nori.Configuracion.documento_borrador)
							{
								if (MessageBox.Show("¿Desea guardar como borrador?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
									documento.estado = 'B';
								else
									documento.estado = 'A';
							}

							if (documento.id != 0)
							{
								return documento.Actualizar(true);
							}
							else
							{
								if (Autorizacion() && Permiso())
								{
									#region SepararDocumento
									//if (documento.flujo.Count == 0 && documento.importe_aplicado == 0 && documento.clase.Equals("FA"))
									//{
									//	if (MessageBox.Show("¿Deseas separar este documento según la moneda base de las partidas?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
									//	{
									//		List<Documento> documentos = Documento.SepararDocumento(documento);

									//		if (documentos.Count == 1)
									//		{
									//			documento = documentos[0];
									//			return true;
									//		}
									//		else
									//		{
									//			foreach (Documento documento in documentos)
									//			{
									//				try
									//				{
									//					if (documento.generar_documento_electronico)
									//						Funciones.TimbrarDocumento(documento);
									//				}
									//				catch { }

									//				frmDocumentos f = new frmDocumentos(documento.clase, documento.id);
									//				f.Show();
									//			}
									//			Close();
									//			return true;
									//		}
									//	}
									//	else
									//	{
									//		if (documento.Agregar())
									//			return true;
									//		else
									//			return false;
									//	}
									//}
									//else
									//{
									//	if (documento.Agregar())
									//		return true;
									//	else
									//		return false;
									//}
									#endregion
									if (documento.Agregar())
									{
										if (documento.generar_documento_electronico)
											Funciones.TimbrarDocumento(documento);

										if (documento.tipo.Equals('I'))
											Funciones.EnviarLogisticaAsync(documento.id);

										if (documento.clase.Equals("IF"))
										{
											if (MessageBox.Show("¿Desea realizar los ajustes de inventario correspondientes automáticamente?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
											{
												Documento ajuste_positivo = new Documento("AE");
												ajuste_positivo.CopiarDe(documento, "AE");
												ajuste_positivo.partidas = documento.partidas.Where(x => x.diferencia > 0).ToList();
												ajuste_positivo.partidas.ForEach(x => x.cantidad = x.diferencia);
												ajuste_positivo.Agregar();

												Documento ajuste_negativo = new Documento("AS");
												ajuste_negativo.CopiarDe(documento, "AS");
												ajuste_negativo.partidas = documento.partidas.Where(x => x.diferencia < 0).ToList();
												ajuste_negativo.partidas.ForEach(x => x.cantidad = x.diferencia * -1);
												ajuste_negativo.Agregar();

												MessageBox.Show("Operación realizada correctamente.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
											}
										}

										return true;
									}
								}
								else
								{
									MessageBox.Show("No fue posible autorizar este movimiento.");
								}
							}
						}
					}
					return false;
				}
				else
					return false;
			}
			catch (Exception ex)
			{
				MessageBox.Show(NoriSDK.Nori.ObtenerUltimoError().Message + " | Error: " + ex.Message, Text);
				return false;
			}
		}

		private bool Autorizacion()
		{
			try
			{
				if (documento.clase.Equals("FA") || documento.clase.Equals("EN"))
				{
					decimal importe_aplicado = (documento.partidas.Where(x => x.documento_id != 0).Count() == 0) ? 0M : Documento.Documentos().Where(x => documento.partidas.Where(y => y.documento_id != 0).Select(y => y.documento_id).ToList().Contains(x.id)).Sum(x => x.importe_aplicado);

					if (documento.total > importe_aplicado || documento.anticipo)
					{
						decimal disponible = socio.limite_credito - socio.balance;
						bool documentos_vencidos = socio.DocumentosVencidos();
						int dias_extra = CondicionesPago.CondicionesPagos().Where(x => x.id == documento.condicion_pago_id).Select(x => x.dias_extra).First();

						if ((documento.total > disponible || documentos_vencidos) && dias_extra > 0 && documento.socio_id != Program.Nori.UsuarioAutenticado.socio_id)
						{
							Autorizacion autorizacion = new Autorizacion();
							string txt_documentos_vencidos = (documentos_vencidos) ? "(Documentos vencidos)" : "";
							if (documento.anticipo)
								txt_documentos_vencidos += " - Anticipo -";

							string clase_documento = Documento.Clase.Clases().Where(x => x.clase == documento.clase).Select(x => x.nombre).First();

							if (documento.reserva)
								clase_documento += " (Reserva)";
							if (documento.anticipo)
								clase_documento += " (Anticipo)";

							autorizacion.codigo = "VEACR";
							autorizacion.referencia = string.Format("{0} a crédito por {1:c2} al socio {2} ({3}), Límite de crédito excedido en {4:c2} {5}", clase_documento, documento.total, socio.nombre, socio.codigo, ((socio.limite_credito - socio.balance) * -1), txt_documentos_vencidos);
							autorizacion.comentario = Microsoft.VisualBasic.Interaction.InputBox("Comentario venta a crédito (Opcional)", "");

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
				}

				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool Permiso(bool cancelacion = false)
		{
			try
			{
				Permiso permiso = NoriSDK.Permiso.Obtener(Program.Nori.UsuarioAutenticado.id, documento.clase, true);

				if (permiso.id != 0)
				{
					if (permiso.cancelar && cancelacion)
						return true;

					if ((!permiso.agregar && documento.id == 0) || (!permiso.actualizar && documento.id != 0) || (!permiso.cancelar && cancelacion))
					{
						Autorizacion autorizacion = new Autorizacion();

						string accion;
						if (cancelacion)
							accion = "Cancelación";
						else if (documento.id == 0)
							accion = "Creación";
						else
							accion = "Actualización";

						autorizacion.codigo = "CRUDO";
						autorizacion.usuario_autorizacion_id = permiso.usuario_autorizacion_id;
						autorizacion.referencia = string.Format("{0} del documento {1} al cliente {2} por {3}", accion, documento.clase, socio.nombre, documento.total.ToString("c2"));
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

		private void GuardarPOS()
		{
			try
			{
				gvPartidas.CloseEditor();
				txtArticulo.Focus();

				if (documento.estado.Equals('A') && (documento.clase.Equals("FA") || documento.clase.Equals("EN")))
				{
					if (NoriSDK.PuntoVenta.EstadoCaja().Equals('C'))
					{
						if (MessageBox.Show("¿Deseas realizar una apertura de caja?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
						{
							PuntoVenta.frmIngresos f = new PuntoVenta.frmIngresos("INACA");
							f.ShowDialog();
							return;
						}
						else
						{
							MessageBox.Show("Para poder realizar este movimiento es necesario realizar una apertura de caja.");
						}
					}
					else
					{
						frmMediosPago f = new frmMediosPago(documento, socio);

						if (f.ShowDialog() == DialogResult.OK)
						{
							if (documento.id == 0)
							{
								if (MessageBox.Show("¿Estas seguro(a) de guardar el documento?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
								{
									cbMetodosPago.EditValue = documento.metodo_pago_id;
									cbUsoPrincipal.EditValue = documento.uso_principal;

									if (Llenar())
									{
										if (documento.flujo.Count > 0)
										{
											if (documento.Agregar())
											{
												if (documento.generar_documento_electronico)
													Funciones.TimbrarDocumento(documento);
												Imprimir(documento);
												RecargarDocumento();
											}
											else
												MessageBox.Show(NoriSDK.Nori.ObtenerUltimoError().Message);
										}
										else
										{
											frmAutorizacionCredito fs = new frmAutorizacionCredito();
											fs.socio = socio;
											fs.ShowDialog();

											if (fs.DialogResult == DialogResult.OK)
											{
												if (documento.Agregar())
												{
													if (documento.generar_documento_electronico)
														Funciones.TimbrarDocumento(documento);
													Imprimir(documento, 2);
													RecargarDocumento();
												}
												else
													MessageBox.Show(NoriSDK.Nori.ObtenerUltimoError().Message);
											}
										}
									}
								}
							}
							else if (documento.flujo.Count > 0)
							{
								if (documento.AgregarPagoFactura())
									RecargarDocumento();
								else
									MessageBox.Show("No fue posible agregar el pago.");
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Este documento ya ha sido cerrado o no puede ser pagado.");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private static void Imprimir(Documento documento, short copias = 1)
		{
			try
			{
				if (documento.id != 0)
				{
					Funciones.ImprimirInformePredeterminado(documento.clase, documento.id, copias);

					documento.Impreso();

					try
					{
						if (Program.Nori.Configuracion.tipo_metodo_pago_monedero_id != 0)
						{
							foreach (Flujo flujo_monedero in documento.flujo.Where(x => x.tipo_metodo_pago_id == Program.Nori.Configuracion.tipo_metodo_pago_monedero_id).ToList())
							{
								if (flujo_monedero.id != 0)
									Funciones.ImprimirInformePredeterminado("IE", flujo_monedero.id);
							}
						}
					}
					catch { }
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Documentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void bbiNuevoSocio_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			frmAltaRapidaSocio f = new frmAltaRapidaSocio();
			if (f.ShowDialog() == DialogResult.OK)
			{
				socio = Socio.Obtener(Socio.Socios().OrderByDescending(x => x.id).Select(x => x.id).First());
				EstablecerSocio();
			}

		}

		private void txtCodigoSN_KeyDown(object sender, KeyEventArgs e)
		{
			try
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

				if (e.Control && e.KeyCode == Keys.M)
					CargarMonedero();
			}
			catch { }
		}

		private void barButtonItemMapaRelaciones_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			frmMapaRelaciones f = new frmMapaRelaciones(documento);
			f.Show();
		}

		private void gvPartidas_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
		{
			try
			{
				if (e.Column.FieldName == "total")
				{
					Autorizacion autorizacion = new Autorizacion();

					autorizacion.codigo = "MOTPP";
					autorizacion.referencia = string.Format("Modificación del total del artículo {0} de {1:c2} a {2:c2} al socio {3}", documento.partidas[e.RowHandle].sku, gvPartidas.ActiveEditor.OldEditValue, gvPartidas.ActiveEditor.EditValue, socio.codigo);
					autorizacion.comentario = Microsoft.VisualBasic.Interaction.InputBox("Comentario modifiación de total (Opcional)", "");

					autorizacion.Agregar();

					if (!autorizacion.autorizado)
					{
						frmSolicitarAutorizacion fa = new frmSolicitarAutorizacion(autorizacion);
						fa.ShowDialog();
						autorizacion.autorizado = (fa.DialogResult == DialogResult.OK) ? true : false;
					}

					if (!autorizacion.autorizado)
						documento.partidas[e.RowHandle].total = (decimal)gvPartidas.ActiveEditor.OldEditValue;

					documento.partidas[e.RowHandle].ModificarTotal();
				}
				else if (e.Column.FieldName == "porcentaje_descuento")
				{
					Autorizacion autorizacion = new Autorizacion();

					autorizacion.codigo = "DSCPP";
					autorizacion.referencia = string.Format("Descuento al artículo {0} de {1:p2} al socio {2}", documento.partidas[e.RowHandle].sku, gvPartidas.ActiveEditor.EditValue, socio.codigo);
					autorizacion.comentario = Microsoft.VisualBasic.Interaction.InputBox("Comentario descuento artículo (Opcional)", "");

					autorizacion.Agregar();

					if (!autorizacion.autorizado)
					{
						frmSolicitarAutorizacion fa = new frmSolicitarAutorizacion(autorizacion);
						fa.ShowDialog();
						autorizacion.autorizado = (fa.DialogResult == DialogResult.OK) ? true : false;
					}

					if (!autorizacion.autorizado)
						documento.partidas[e.RowHandle].porcentaje_descuento = (decimal)gvPartidas.ActiveEditor.OldEditValue;

					documento.partidas[e.RowHandle].CalcularTotal();
				}
				else if (e.Column.FieldName == "cantidad")
				{
					if (documento.id != 0 || documento.partidas.Any(x => x.documento_id != 0))
						documento.partidas[e.RowHandle].CalcularCantidadPendiente(documento.id);

					if (documento.partidas[e.RowHandle].id == 0)
						documento.partidas[e.RowHandle].ObtenerDescuento(documento.socio_id);

					documento.partidas[e.RowHandle].CalcularTotal();
				}
				else if (e.Column.FieldName == "tipo_empaque_id" || e.Column.FieldName == "cantidad_empaque")
				{
					try
					{
						if (Articulo.Articulos().Any(x => x.id == documento.partidas[e.RowHandle].articulo_id && x.pesable == true))
						{
							var tipo_empaque = TipoEmpaque.TiposEmpaques().Where(x => x.id == documento.partidas[e.RowHandle].tipo_empaque_id && x.activo == true).Select(x => new { x.id, x.peso }).First();

							documento.partidas[e.RowHandle].tipo_empaque_id = tipo_empaque.id;
							documento.partidas[e.RowHandle].cantidad -= (documento.partidas[e.RowHandle].cantidad_empaque * tipo_empaque.peso);

							documento.partidas[e.RowHandle].CalcularTotal();
						}
					}
					catch { }
				}
				else if (e.Column.Name == "gridColumnPrecio")
				{

					Autorizacion autorizacion = new Autorizacion();

					autorizacion.codigo = "MOTPP";
					autorizacion.referencia = string.Format("Modificación de precio al artículo {0} de {1:c2} a {2:c2} al socio {3}", documento.partidas[e.RowHandle].sku, gvPartidas.ActiveEditor.OldEditValue, gvPartidas.ActiveEditor.EditValue, socio.codigo);
					autorizacion.comentario = Microsoft.VisualBasic.Interaction.InputBox("Comentario modificación de precio (Opcional)", "");

					autorizacion.Agregar();

					if (!autorizacion.autorizado)
					{
						frmSolicitarAutorizacion fa = new frmSolicitarAutorizacion(autorizacion);
						fa.ShowDialog();
						autorizacion.autorizado = (fa.DialogResult == DialogResult.OK) ? true : false;
					}

					if (!autorizacion.autorizado)
						documento.partidas[e.RowHandle].precio = decimal.Parse(gvPartidas.ActiveEditor.OldEditValue.ToString()) * documento.tipo_cambio;
					else
						documento.partidas[e.RowHandle].precio = decimal.Parse(gvPartidas.ActiveEditor.EditValue.ToString()) * documento.tipo_cambio;

					documento.partidas[e.RowHandle].CalcularTotal();
				}
				else if (e.Column.Name == "gridColumnUnidadMedida")
				{
					documento.partidas[e.RowHandle].ModificarUnidadMedida();
				}
				else if (e.Column.Name == "gridColumnAlmacen")
				{
					if (documento.id == 0)
						documento.partidas[e.RowHandle].ObtenerStock();

					if (documento.id == 0)
						if (MessageBox.Show("¿Establecer esta almacén para todas las partidas?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
							documento.partidas.All(x => { x.almacen_id = documento.partidas[e.RowHandle].almacen_id; x.ObtenerStock(); return true; });
				}
				else if (e.Column.Name == "gridColumnAlmacenDestino")
				{
					if (documento.id == 0)
						documento.partidas[e.RowHandle].ObtenerStock();

					if (documento.id == 0)
						if (MessageBox.Show("¿Establecer esta almacén de destino para todas las partidas?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
							documento.partidas.All(x => { x.almacen_destino_id = documento.partidas[e.RowHandle].almacen_destino_id; return true; });
				}
				else if (e.Column.Name == "gridColumnUbicacion")
				{
					if (documento.id == 0)
						if (MessageBox.Show("¿Establecer esta ubicación para todas las partidas?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
							documento.partidas.All(x => { x.ubicacion_id = documento.partidas[e.RowHandle].ubicacion_id; x.ObtenerStock(); return true; });
				}
				else if (e.Column.Name == "gridColumnUbicacionDestino")
				{
					if (documento.id == 0)
						if (MessageBox.Show("¿Establecer esta ubicación de destino para todas las partidas?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
							documento.partidas.All(x => { x.ubicacion_destino_id = documento.partidas[e.RowHandle].ubicacion_destino_id; return true; });
				}
				else if (e.Column.Name == "gridColumnListaPrecio")
				{
					if (documento.id == 0)
					{
						if (MessageBox.Show("¿Establecer esta lista de precios para todas las partidas?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
						{
							documento.lista_precio_id = documento.partidas[e.RowHandle].lista_precio_id;
							documento.RecalcularTotalPartidas();
						}
						else
						{
							documento.partidas[e.RowHandle].ObtenerPrecio(documento.socio_id);
						}
					}
				}
				else
				{
					documento.partidas[e.RowHandle].CalcularTotal();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				Calcular();
			}
		}

		private void gvPartidas_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Delete)
				{
					if (documento.partidas.Count > 0)
						documento.partidas.Remove(documento.partidas[gvPartidas.GetSelectedRows()[0]]);

					Calcular();
				}

				if (e.Alt && e.KeyCode == Keys.E)
				{
					DataTable existencias = (Program.Nori.Configuracion.inventario_sap) ? FuncionesSAP.ObtenerExistencias(documento.partidas[gvPartidas.GetSelectedRows()[0]].sku) : Utilidades.EjecutarQuery(string.Format("SELECT codigo AS Almacén, nombre AS [Nombre del almacén], stock AS Stock, comprometido AS Compormetido, pedido AS Pedido, disponible AS Disponible FROM DatosInventario WHERE articulo_id = {0} AND activo = 1", documento.partidas[gvPartidas.GetSelectedRows()[0]].articulo_id));

					frmResultadosBusqueda f = new frmResultadosBusqueda(existencias);
					f.Text = "Existencias " + documento.partidas[gvPartidas.GetSelectedRows()[0]].sku;
					f.ShowDialog();
				}

				if (e.Alt && e.KeyCode == Keys.U)
				{
					MessageBox.Show(((documento.partidas[gvPartidas.GetSelectedRows()[0]].precio - documento.partidas[gvPartidas.GetSelectedRows()[0]].costo) / documento.partidas[gvPartidas.GetSelectedRows()[0]].precio).ToString("p2"), string.Format("Utilidad bruta del artículo ", documento.partidas[gvPartidas.GetSelectedRows()[0]].sku), MessageBoxButtons.OK, MessageBoxIcon.Information);
				}

				if (e.Alt && e.KeyCode == Keys.P)
				{
					DataTable ultimos_precios = Utilidades.EjecutarQuery(string.Format("select top 30 sku SKU, nombre Artículo, precio Precio, precio + partidas.impuesto 'Precio neto', fecha_documento Fecha from partidas join documentos on partidas.documento_id = documentos.id where documentos.socio_id = {0} and partidas.articulo_id = {1} order by partidas.id desc", documento.socio_id, documento.partidas[gvPartidas.GetSelectedRows()[0]].articulo_id));
					frmResultadosBusqueda f = new frmResultadosBusqueda(ultimos_precios);
					f.Text = "Últimos precios " + documento.partidas[gvPartidas.GetSelectedRows()[0]].sku;
					f.ShowDialog();
				}

				if (e.Control && e.KeyCode == Keys.A)
				{
					frmArticulos f = new frmArticulos(documento.partidas[gvPartidas.GetSelectedRows()[0]].articulo_id);
					f.Show();
				}


				if (e.Shift && e.KeyCode == Keys.C)
				{
					MessageBox.Show(Articulo.Articulos().Where(x => x.id == documento.partidas[gvPartidas.GetSelectedRows()[0]].articulo_id).Select(x => x.comentario).First(), "Comentario del artículo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}

				if (e.Shift && e.KeyCode == Keys.A)
				{
					frmAltaRapidaArticulo f = new frmAltaRapidaArticulo();
					f.Show();
				}

				if (e.Alt && e.KeyCode == Keys.D)
					gvPartidas.FocusedColumn = gvPartidas.Columns["porcentaje_descuento"];

				if (e.Alt && e.KeyCode == Keys.T)
					gvPartidas.FocusedColumn = gvPartidas.Columns["total"];

				if (e.KeyCode == Keys.Enter)
				{
					if (gvPartidas.FocusedColumn.Caption.Equals("Cantidad"))
					{
						gvPartidas.FocusedColumn = gvPartidas.Columns["comentario"];
						gvPartidas.ShowEditor();
					}
					else if (gvPartidas.FocusedColumn.Caption.Equals("Comentario"))
					{
						gvPartidas.FocusedColumn = null;
						txtArticulo.Focus();
					}
				}
			}
			catch { }
		}

		private void gvPartidas_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
		{
			try
			{
				if (e.RowHandle >= 0)
				{
					if (Convert.ToDouble(gvPartidas.GetRowCellValue(e.RowHandle, gvPartidas.Columns["cantidad_pendiente"])) == 0 && documento.id != 0)
						e.Appearance.BackColor = Color.WhiteSmoke;
					else if (Convert.ToDouble(gvPartidas.GetRowCellValue(e.RowHandle, gvPartidas.Columns["porcentaje_descuento"])) > 0)
						e.Appearance.BackColor = Color.GreenYellow;
					e.Appearance.BackColor2 = Color.White;


				}
			}
			catch { }
		}

		private async void AgregarPartida(string q)
		{
			try
			{
			Buscar:
				if (await Task.Run(() => documento.AgregarPartida(q)))
				{
					txtArticulo.Text = string.Empty;
					try
					{
						gvPartidas.MoveFirst();
						Documento.Partida partida = documento.partidas.OrderByDescending(x => x.fecha_lectura).First();
						if (Program.Nori.Configuracion.agrupar_partidas)
							gvPartidas.MoveBy(gvPartidas.LocateByValue("articulo_id", partida.articulo_id));
						else
							gvPartidas.MoveLast();

						if (documento.clase.Equals("EN") || documento.clase.Equals("FA"))
							if (!partida.VerificarExistencia())
								if (MessageBox.Show(NoriSDK.Nori.ObtenerUltimoError().Message + " ¿Desea continuar agregando este artículo?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
									documento.partidas.Remove(partida);
					}
					catch { }

					Calcular();
				}
				else
				{
					if (MessageBox.Show(NoriSDK.Nori.ObtenerUltimoError().Message, Text, MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
						goto Buscar;
				}

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				txtArticulo.Text = string.Empty;

				if (documento.partidas.Count > 0)
				{
					gvPartidas.FocusedColumn = gvPartidas.Columns["cantidad"];
					gvPartidas.ShowEditor();
				}

				txtArticulo.Enabled = true;
			}
		}

		private void txtArticulo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Tab && txtArticulo.Text.Length > 0)
				{
					string q = txtArticulo.Text;
					decimal cantidad = 1;

					if (q.Contains("*"))
					{
						cantidad = decimal.Parse(q.Split('*')[0]);
						q = q.Split('*')[1];
					}

					ConsultaPersonalizada consulta = ConsultaPersonalizada.Obtener("txtArticulo");

					if (consulta.query.IsNullOrEmpty())
						consulta.query = "SELECT articulos.id, sku as sku_articulo, articulos.nombre, (SELECT SUM(stock) FROM inventario WHERE articulo_id = articulos.id) stock, precios.precio, monedas.codigo as moneda FROM articulos JOIN precios ON precios.articulo_id = articulos.id JOIN monedas ON monedas.id = precios.moneda_id AND precios.lista_precio_id = {lista_precio_id} WHERE (sku = '{q}' OR articulos.nombre LIKE '%{q}%' OR codigo_barras LIKE '%{q}%') AND venta = 1 AND articulos.activo = 1";

					consulta.query = consulta.query.Replace("{q}", q.Replace(" ", "%"));
					consulta.query = consulta.query.Replace("{socio_id}", documento.socio_id.ToString());
					consulta.query = consulta.query.Replace("{lista_precio_id}", documento.lista_precio_id.ToString());
					consulta.query = consulta.query.Replace("{condicion_pago_id}", documento.condicion_pago_id.ToString());
					consulta.query = consulta.query.Replace("{metodo_pago_id}", documento.metodo_pago_id.ToString());
					consulta.query = consulta.query.Replace("{moneda_id}", documento.moneda_id.ToString());

					DataTable articulos = consulta.Ejecutar();

					if (articulos.Rows.Count > 0)
					{
						if (articulos.Rows.Count == 1)
						{
							AgregarPartida(string.Format("{0}*{1}", cantidad, articulos.Rows[0][1].ToString()));
						}
						else
						{
							frmResultadosBusquedaArticulos f = new frmResultadosBusquedaArticulos(articulos, true);
							var result = f.ShowDialog();

							if (result == DialogResult.OK)
							{
								Cursor = Cursors.WaitCursor;
								f.filas.ForEach(x => AgregarPartida(string.Format("{0}*{1}", cantidad, articulos.Rows[x][1].ToString())));
								Calcular();
								Cursor = Cursors.Default;
							}
						}
					}
					else
						MessageBox.Show(string.Format("No se encontraron resultados para {0}", q), Text);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void txtArticulo_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Enter && txtArticulo.Text.Length > 0)
				{
					txtArticulo.Enabled = false;
					AgregarPartida(txtArticulo.Text);
				}
			}
			catch { }
		}

		private void lblDescuento_Click(object sender, EventArgs e)
		{
			if (documento.total > 0 && documento.estado == 'A')
			{
				frmDescuento f = new frmDescuento();

				f.total = documento.total;

				var result = f.ShowDialog();

				if (result == DialogResult.OK)
					if (documento.descuento > 0)
					{
						if (MessageBox.Show(string.Format("El documento actualmente tiene un descuento de {0} ¿desea acumularlo?", documento.descuento.ToString("c2")), Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
						{
							documento.descuento = documento.descuento + f.descuento;
							documento.porcentaje_descuento = (documento.descuento / documento.total) * 100;
						}
						else
						{
							documento.descuento = f.descuento;
							documento.porcentaje_descuento = (documento.descuento / documento.total) * 100;
						}
					}
					else
					{
						documento.descuento = f.descuento;
						documento.porcentaje_descuento = (documento.descuento / documento.total) * 100;
					}
				Calcular();
			}
		}

		private void cbDireccionesFacturacion_EditValueChanged(object sender, EventArgs e)
		{
			BloqueDirecciones();
		}

		private void txtTipoCambio_EditValueChanged(object sender, EventArgs e)
		{
			documento.tipo_cambio = decimal.Parse(txtTipoCambio.EditValue.ToString());
			Calcular();
		}

		private void txtCodigoSN_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Tab && txtCodigoSN.Text.Length > 0)
					BuscarSocios(txtCodigoSN.Text);
			}
			catch { }
		}

		private void btnDireccionFacturacion_Click(object sender, EventArgs e)
		{
			if (documento.socio_id != 0)
			{
				Socio.Direccion direccion = new Socio.Direccion();
				direccion.socio_id = documento.socio_id;
				direccion.tipo = 'F';
				frmDireccion f = new frmDireccion();
				f.direccion = direccion;
				f.ShowDialog();
				if (f.direccion.id != 0)
				{
					documento.direccion_facturacion_id = f.direccion.id;
				}
				CargarDirecciones();
			}
		}

		private void btnAgregarDireccionEnvio_Click(object sender, EventArgs e)
		{
			if (documento.socio_id != 0)
			{
				Socio.Direccion direccion = new Socio.Direccion();
				direccion.tipo = 'E';
				frmDireccion f = new frmDireccion();
				f.direccion = direccion;
				f.ShowDialog();
				if (f.direccion.id != 0)
				{
					documento.direccion_envio_id = f.direccion.id;
				}
				CargarDirecciones();
			}
		}

		private void btnCFDI_Click(object sender, EventArgs e)
		{
			try
			{
				if (documento.EsDocumentoElectronico() && documento.generar_documento_electronico)
				{
					Funciones.TimbrarDocumento(documento);
					CargarDocumentoElectronico();
				}
				else
				{
					MessageBox.Show("El documento no es electrónico o no se ha establecido la generación electrónica.");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnActualizar_Click(object sender, EventArgs e)
		{
			CargarDocumentoElectronico();
		}

		private void bbiRecargar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			RecargarDocumento();
		}

		private void RecargarDocumento()
		{
			if (documento.id != 0)
			{
				documento = Documento.Obtener(documento.id);
				Cargar();
			}
			else
			{
				bbiNuevo.PerformClick();
			}
		}

		private void bbiCerrar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (MessageBox.Show("¿Estas seguro de cerrar este documento?", "Cerrar documento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				if (documento.estado.Equals('A'))
				{
					if (documento.Cerrar())
						RecargarDocumento();
					else
						MessageBox.Show(NoriSDK.Nori.ObtenerUltimoError().Message);
				}
				else
					MessageBox.Show("Este documento ya ha sido cerrado.");
			}
		}

		private void bbiCancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (MessageBox.Show("¿Estas seguro de cancelar este documento?", "Cancelar documento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				if (!documento.cancelado)
				{
					if (Permiso(true))
					{
						documento.comentario = Microsoft.VisualBasic.Interaction.InputBox("Ingresa un comentario sobre la cancelación", "Cancelación documento", documento.comentario);
						if (documento.Cancelar(true))
						{
							RecargarDocumento();
							CancelarDocumentoElectronico();
						}
						else
						{
							MessageBox.Show(NoriSDK.Nori.ObtenerUltimoError().Message);
						}
					}
				}
				else
					MessageBox.Show("Este documento ya ha sido cancelado.");
			}
		}

		private void CancelarDocumentoElectronico()
		{
			if (documento.EsDocumentoElectronico())
			{
				DocumentoElectronico documento_electronico = documento.DocumentoElectronico();
				if (documento_electronico.estado.Equals('A') && documento_electronico.folio_fiscal.Length > 0 && Program.Nori.UsuarioAutenticado.NivelAcceso() >= 50)
				{
					if (MessageBox.Show("¿Deseas cancelar el CFDI?", "Cancelar CFDI", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						Funciones.CancelarTimbreDocumentoElectronico(documento_electronico);
						CargarDocumentoElectronico();
					}
				}
			}
		}

		private void EliminarDocumentoElectronico()
		{
			if (documento.EsDocumentoElectronico())
			{
				DocumentoElectronico documento_electronico = documento.DocumentoElectronico();
				if (MessageBox.Show("¿Deseas eliminar el CFDI?: Esta opción NO cancela el CFDI ante el SAT, solo quita el registro de la base de datos.", "Eliminar CFDI", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					documento_electronico.Eliminar();
					CargarDocumentoElectronico();
				}
			}
		}

		private void lblCodigoSN_Click(object sender, EventArgs e)
		{
			frmSocios form = new frmSocios(socio.id);
			form.ShowDialog();
		}

		private void txtNumeroDocumento_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && (txtNumeroDocumento.Text.Length > 0 || txtReferencia.Text.Length > 0) && documento.id == 0)
				Buscar();
		}

		private void bbiPagar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			GuardarPOS();
		}

		private void gvPartidas_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (!documento.partidas[gvPartidas.GetSelectedRows()[0]].Modificable())
				e.Cancel = true;
		}

		private void lblMonedas_Click(object sender, EventArgs e)
		{
			frmMonedas form = new frmMonedas((int)cbMonedas.EditValue);
			form.ShowDialog();
		}

		private void cbMonedas_EditValueChanged(object sender, EventArgs e)
		{
			try
			{
				if (documento.id == 0 || documento.clase.Equals("CO") || documento.clase.Equals("PE"))
				{
					documento.moneda_id = (int)cbMonedas.EditValue;
					txtTipoCambio.EditValue = TipoCambio.Venta(documento.moneda_id);
					txtTipoCambio.Visible = (Program.Nori.Configuracion.moneda_id != documento.moneda_id) ? true : false;
				}
			}
			catch { }
		}

		private void bbiXLSX_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				string archivo = string.Format(@"{0}\{1}.xlsx", Program.Nori.Configuracion.directorio_documentos, documento.id);
				gcPartidas.ExportToXlsx(archivo);
				Funciones.AbrirArchivo(archivo);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void bbiEnviar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				if (documento.id != 0)
				{
					int informe_id = Informe.Informes().Where(x => x.tipo == documento.clase && x.activo == true && x.predeterminado_correo_electronico == true).Select(x => x.id).First();

					frmCorreoElectronico f = new frmCorreoElectronico();
					f.socio = socio;
					f.anexos.Add(Funciones.PDFInforme(informe_id, documento.id));

					try
					{
						if (documento.EsDocumentoElectronico())
						{
							DocumentoElectronico documento_electronico = documento.DocumentoElectronico();
							if (documento_electronico.id != 0)
							{
								if (documento_electronico.estado.Equals('A'))
								{
									f.anexos.Add(string.Format(@"{0}\{1}.xml", Program.Nori.Configuracion.directorio_xml, documento_electronico.folio_fiscal));
								}
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

		private void btnGenerarPuntos_Click(object sender, EventArgs e)
		{
			if (documento.GenerarPuntos())
				MessageBox.Show("Se generarón los puntos correctamente");
			else
				MessageBox.Show(NoriSDK.Nori.ObtenerUltimoError().Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void btnReferencias_Click(object sender, EventArgs e)
		{
			try
			{
				var docs = (Documento.Documentos().Where(x => x.socio_id == documento.socio_id && (x.clase == "AN" || x.clase == "FA" || x.clase == "NC" || x.clase == "ND")).OrderByDescending(x => x.fecha_creacion)).Select(x => new { ID = x.id, Clase = x.clase, No = x.numero_documento, NoSAP = x.numero_documento_externo, Fecha = x.fecha_documento, Total = x.total, Aplicado = x.importe_aplicado, Estado = x.estado, Reserva = x.reserva, Anticipo = x.anticipo, Cancelado = x.cancelado });
				DataTable documentos = docs.ToList().ToDataTable();
				if (documentos.Rows.Count > 0)
				{
					frmResultadosBusqueda f = new frmResultadosBusqueda(documentos, true);

					var result = f.ShowDialog();

					if (result == DialogResult.OK)
					{
						foreach (int documento_id in f.ids)
						{
							Documento.Referencia referencia = new Documento.Referencia();
							referencia.documento_id = documento.id;
							referencia.documento_referencia_id = documento_id;
							if (!documento.referencias.Any(x => x.documento_referencia_id == documento_id))
							{
								documento.referencias.Add(referencia);
								CargarReferencias();
							}
						}
					}
				}
				else
				{
					MessageBox.Show("No se encontraron resultados", Text);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void CargarReferencias()
		{
			try
			{
				lbReferencias.Visible = true;
				lbReferencias.Items.Clear();
				foreach (Documento.Referencia referencia in documento.referencias)
				{
					var documento_referencia = Documento.Documentos().Where(x => x.id == referencia.documento_referencia_id).Select(x => new { x.id, x.numero_documento, x.clase, x.estado, x.total }).First();
					lbReferencias.Items.Add(string.Format("{0} {1} Total: {2} {3}", Documento.Clase.Clases().Where(x => x.clase == documento_referencia.clase).First().nombre, documento_referencia.numero_documento, documento_referencia.total.ToString("c2"), Documento.Estado.Estados().Where(x => x.estado == documento_referencia.estado).First().nombre));
				}
			}
			catch
			{
				//
			}
		}

		private void CargarAnexos()
		{
			try
			{
				lbAnexos.Items.Clear();
				foreach (Documento.Anexo anexo in documento.anexos)
				{
					lbAnexos.Items.Add(string.Format("{0} - {1}", anexo.anexo, anexo.fecha_creacion.ToShortDateString()));
				}
			}
			catch
			{
				//
			}
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			CancelarDocumentoElectronico();
		}

		private void gvPartidas_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
		{
			if (e.Column.Name == "gridColumnNo")
				if (e.IsGetData)
					e.Value = e.ListSourceRowIndex + 1;
		}

		private void bbiAjustarColumnas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			gvPartidas.BestFitColumns();
		}

		private void txtNumeroDocumentoExterno_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && txtNumeroDocumento.Text.Length > 0 && documento.id == 0)
				Buscar();
		}

		private void lblImportarFolioFiscal_Click(object sender, EventArgs e)
		{
			ImportarFolioFiscal();
		}

		private void ImportarFolioFiscal()
		{
			try
			{
				if (documento.EsDocumentoElectronico() && documento.id != 0)
				{
					if (Program.Nori.UsuarioAutenticado.rol.Equals('A'))
					{
						DocumentoElectronico documento_electronico = documento.DocumentoElectronico();
						if (documento_electronico.estado != 'A' && documento_electronico.folio_fiscal.Length == 0)
						{
							string folio_fiscal = Microsoft.VisualBasic.Interaction.InputBox("Ingresa el folio fiscal (UUID)", "Importar folio fiscal", "");
							documento_electronico.documento_id = documento.id;
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

		private void btnSolicitarEtiquetas_Click(object sender, EventArgs e)
		{
			try
			{
				Etiqueta etiqueta = new Etiqueta();
				etiqueta.almacen_id = Program.Nori.UsuarioAutenticado.almacen_id;

				foreach (Documento.Partida partida_documento in documento.partidas)
				{
					Etiqueta.Partida partida_etiqueta = new Etiqueta.Partida();
					partida_etiqueta.cantidad = Convert.ToInt32(partida_documento.cantidad);
					partida_etiqueta.articulo_id = partida_documento.articulo_id;

					etiqueta.partidas.Add(partida_etiqueta);
				}

				if (etiqueta.Agregar())
				{
					MessageBox.Show("Solicitud creada correctamente.");
					frmEtiquetas f = new frmEtiquetas(etiqueta.id);
					f.Show();
				}
				else
				{
					MessageBox.Show(NoriSDK.Nori.ObtenerUltimoError().Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void bbiDuplicar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				List<Documento.Partida> partidas = documento.partidas;
				partidas.All(x => { x.documento_id = 0; x.id = 0; return true; });
				string clase = documento.clase;

				documento = new Documento();
				documento.clase = clase;
				documento.partidas = partidas;

				Cargar(true);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void lblChofer_Click(object sender, EventArgs e)
		{
			frmChoferes f = new frmChoferes(documento.chofer_id);
			f.ShowDialog();
			CargarListas();
		}

		private void lblVehiculo_Click(object sender, EventArgs e)
		{
			frmVehiculos f = new frmVehiculos(documento.vehiculo_id);
			f.ShowDialog();
			CargarListas();
		}

		private void btnEstadoCFDI_Click(object sender, EventArgs e)
		{
			try
			{
				MessageBox.Show(Funciones.ObtenerEstado(documento.DocumentoElectronico()), "Estado CFDI", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch { }
		}

		private void bbiCancelacionManualCFDI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				string uuid = Microsoft.VisualBasic.Interaction.InputBox("UUID", "");
				string rfc_receptor = Microsoft.VisualBasic.Interaction.InputBox("RFC Receptor", "");
				double total = double.Parse(Microsoft.VisualBasic.Interaction.InputBox("Total", ""));

				MessageBox.Show(Funciones.CancelarCFDi(uuid, rfc_receptor, total));
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			foreach (string linea in txtUUIDPorCancelar.Lines)
			{
				try
				{
					string[] cfdi = linea.Split(',');
					string uuid = cfdi[0];
					string rfc_receptor = cfdi[1];
					double total = double.Parse(cfdi[2]);

					string resultado = Funciones.CancelarCFDi(uuid, rfc_receptor, total);
					if (resultado.Contains("Error"))
					{
						txtUUIDErrorCancelacion.AppendText("\r\n" + linea);
					}
				}
				catch
				{
					txtUUIDErrorCancelacion.AppendText("\r\n" + linea);
					continue;
				}
			}
		}

		private void lblCanal_Click(object sender, EventArgs e)
		{
			frmCanales f = new frmCanales((int)cbCanales.EditValue);
			f.ShowDialog();
		}

		private void lblSupervisores_Click(object sender, EventArgs e)
		{
			frmSupervisores f = new frmSupervisores((int)cbSupervisores.EditValue);
			f.ShowDialog();
		}

		private void cbSeries_EditValueChanged(object sender, EventArgs e)
		{
			try
			{
				if (documento.id == 0)
				{
					int almacen_id = Serie.Series().Where(x => x.id == (int)cbSeries.EditValue).Select(x => x.almacen_id).First();
					if (almacen_id != 0)
						documento.partidas.All(x => { x.almacen_id = almacen_id; x.ObtenerStock(); return true; });
				}
			}
			catch { }
		}

		private void frmDocumentos_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.Control && e.KeyCode == Keys.N)
					Nuevo();

				if (e.Control && e.KeyCode == Keys.B)
					Buscar();

				if (e.Alt && e.KeyCode == Keys.B)
				{
					frmBascula f = new frmBascula();
					f.ShowDialog();
				}

				if (e.Alt && e.KeyCode == Keys.O)
					OrdenCompra();

				if (e.Shift && e.KeyCode == Keys.V)
					cbVendedores.Focus();

				if (e.Alt && e.KeyCode == Keys.V)
					VerificarExistencias();

				if (e.Control && e.KeyCode == Keys.M)
					CargarMonedero();

				if (e.Control && e.KeyCode == Keys.P)
					Imprimir(documento);

				if (e.Alt && e.KeyCode == Keys.C)
					txtComentario.Focus();

				if (e.Control && e.KeyCode == Keys.D)
				{
					if (documento.total > 0 && documento.estado == 'A')
					{
						frmDescuento f = new frmDescuento();

						f.total = documento.total;

						var result = f.ShowDialog();

						if (result == DialogResult.OK)
							if (documento.descuento > 0)
							{
								if (MessageBox.Show(string.Format("El documento actualmente tiene un descuento de {0} ¿desea acumularlo?", documento.descuento.ToString("c2")), Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
								{
									documento.descuento = documento.descuento + f.descuento;
									documento.porcentaje_descuento = (documento.descuento / documento.total) * 100;
								}
								else
								{
									documento.descuento = f.descuento;
									documento.porcentaje_descuento = (documento.descuento / documento.total) * 100;
								}
							}
							else
							{
								documento.descuento = f.descuento;
								documento.porcentaje_descuento = (documento.descuento / documento.total) * 100;
							}
						Calcular();
					}
				}

				if (e.Control && e.KeyCode == Keys.S)
					Guardar();

				if (e.KeyCode == Keys.F1)
					new frmDocumentos("CO").Show();

				if (e.KeyCode == Keys.F2)
					new frmDocumentos("PE").Show();

				if (e.KeyCode == Keys.F3)
					new frmDocumentos("EN").Show();

				if (e.KeyCode == Keys.F4)
					new frmDocumentos("DV").Show();

				if (e.KeyCode == Keys.F5)
					new frmDocumentos("FA").Show();

				if (e.KeyCode == Keys.F6)
					new frmDocumentos("NC").Show();

				if (e.KeyCode == Keys.F7)
					new frmDocumentos("TS").Show();

				if (e.KeyCode == Keys.F8)
					new frmDocumentos("AE").Show();
			}
			catch { }
		}

		private void lblCausalidades_Click(object sender, EventArgs e)
		{
			frmCausalidades f = new frmCausalidades((int)cbCausalidades.EditValue);
			f.ShowDialog();
		}

		private void btnAnexos_Click(object sender, EventArgs e)
		{
			OpenFileDialog open = new OpenFileDialog();
			if (open.ShowDialog() == DialogResult.OK)
			{
				string archivo = (Program.Nori.Configuracion.directorio_anexos + @"\" + open.SafeFileName);
				Documento.Anexo anexo = new Documento.Anexo();
				anexo.anexo = open.SafeFileName;
				File.Copy(open.FileName, archivo, true);
				documento.anexos.Add(anexo);
				CargarAnexos();
			}
		}

		private void btnVisualizarAnexo_Click(object sender, EventArgs e)
		{
			try
			{
				string archivo = (Program.Nori.Configuracion.directorio_anexos + @"\" + lbAnexos.SelectedValue.ToString());
				Funciones.AbrirArchivo(archivo);
			}
			catch { }
		}

		private void lblCancelacionMasiva_Click(object sender, EventArgs e)
		{
			lblUUIDPorCancelar.Visible = txtUUIDPorCancelar.Visible = lblUUIDErrorCancelacion.Visible = txtUUIDErrorCancelacion.Visible = btnCancelacionMasiva.Visible = true;
		}

		private void gvPartidas_ShownEditor(object sender, EventArgs e)
		{
			try
			{
				ColumnView view = (ColumnView)sender;
				if (view.FocusedColumn.FieldName == "unidad_medida_id")
				{
					LookUpEdit editor = (LookUpEdit)view.ActiveEditor;
					int articulo_id = Convert.ToInt32(view.GetFocusedRowCellValue("articulo_id"));
					editor.Properties.DataSource = Articulo.UnidadesMedida(articulo_id);
				}
			}
			catch { }
		}

		private void cbEstadoSeguimiento_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (documento.seguimiento)
				{
					string id = documento.id.ToString();
					string numero_documento = documento.numero_documento.ToString();
					string total = documento.total.ToString("c2");
					string estado_seguimiento = cbEstadoSeguimiento.SelectedText;
					string nombre = socio.nombre;
					string rfc = socio.rfc;
					string direccion_envio = txtDireccionEnvio.Text;
					string correo = socio.correo;

					Funciones.EnviarSeguimientoAsync(id, numero_documento, total, estado_seguimiento, nombre, rfc, direccion_envio, correo);

					MessageBox.Show("Se actualizó y notificó el seguimiento correctamente.");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void lblRuta_Click(object sender, EventArgs e)
		{
			frmRutas f = new frmRutas((int)cbRutas.EditValue);
			f.ShowDialog();
		}

		private void btnGenerarRFCGenerico_Click(object sender, EventArgs e)
		{
			try
			{
				if (documento.EsDocumentoElectronico() && documento.generar_documento_electronico)
				{
					Funciones.TimbrarDocumento(documento, "XAXX010101000");
					CargarDocumentoElectronico();
				}
				else
				{
					MessageBox.Show("El documento no es electrónico o no se ha establecido la generación electrónica.");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnAnticipos_Click(object sender, EventArgs e)
		{
			try
			{
				var docs = (Documento.Documentos().Where(x => x.socio_id == documento.socio_id && x.anticipo == true && x.cancelado == false && x.importe_aplicado_anticipo < x.total && (x.clase == "AN" || x.clase == "FA"))).OrderByDescending(x => x.fecha_creacion).Select(x => new { ID = x.id, Clase = x.clase, No = x.numero_documento, NoSAP = x.numero_documento_externo, Fecha = x.fecha_documento, Total = x.total, Aplicado = x.importe_aplicado, Saldo = x.total - x.importe_aplicado });
				DataTable documentos = docs.ToList().ToDataTable();
				if (documentos.Rows.Count > 0)
				{
					frmResultadosBusqueda f = new frmResultadosBusqueda(documentos, true);

					var result = f.ShowDialog();

					if (result == DialogResult.OK)
					{
						foreach (int documento_id in f.ids)
						{
							Documento.Referencia referencia = new Documento.Referencia();
							referencia.documento_id = documento.id;
							referencia.documento_referencia_id = documento_id;
							if (!documento.referencias.Any(x => x.documento_referencia_id == documento_id))
							{
								documento.referencias.Add(referencia);
								CargarReferencias();
							}
						}
					}
				}
				else
				{
					MessageBox.Show("No se encontraron resultados", Text);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnEliminarDE_Click(object sender, EventArgs e)
		{
			EliminarDocumentoElectronico();
		}

		private void btnGenerarSustitucion_Click(object sender, EventArgs e)
		{
			try
			{
				if (documento.EsDocumentoElectronico() && documento.generar_documento_electronico)
				{
					if (MessageBox.Show("¿Deseas sustituir el CFDI?: Esta opción crea un nuevo CFDI y agrega como relación de sustitución el CFDI actual.", "Sustituir CFDI", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						DocumentoElectronico documento_electronico = documento.DocumentoElectronico();
						if (!documento_electronico.folio_fiscal.IsNullOrEmpty())
						{
							documento_electronico.estado = 'S';
							documento_electronico.Actualizar();
							Funciones.TimbrarDocumento(documento, null, documento_electronico.id);
							CargarDocumentoElectronico();
						}
					}
				}
				else
				{
					MessageBox.Show("El documento no es electrónico o no se ha establecido la generación electrónica.");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnGenerarTransferenciaStock_Click(object sender, EventArgs e)
		{
			Documento.Clase clase = new Documento.Clase();

			clase.tipo = 'I';
			clase.clase = "TS";
			clase.nombre = "Transferencia de stock";

			CopiarDocumento(clase, true);
		}

		private void lbReferencias_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Delete && documento.id == 0)
				{
					if (MessageBox.Show("¿Desea eliminar esta referencia?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
					{
						documento.referencias.RemoveAt(lbReferencias.SelectedIndex);
						CargarReferencias();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void cbCondicionesPago_EditValueChanged(object sender, EventArgs e)
		{
			try
			{
				if (socio.condicion_pago_id == int.Parse(cbCondicionesPago.EditValue.ToString()))
				{
					cbMetodosPago.EditValue = socio.metodo_pago_id;
				}
			}
			catch (Exception ex)
			{

			}
		}

        private void lblRemolque_Click(object sender, EventArgs e)
        {
			frmRemolques f = new frmRemolques(documento.remolque_id);
			f.ShowDialog();
			CargarListas();
		}

        private void btnEditarDireccionEnvio_Click(object sender, EventArgs e)
        {
			if (documento.socio_id != 0)
			{
				Socio.Direccion direccion = Socio.Direccion.Obtener(documento.direccion_envio_id);
				direccion.tipo = 'E';
				frmDireccion f = new frmDireccion();
				f.direccion = direccion;
				f.ShowDialog();
				CargarDirecciones();
			}
		}

        private void btnEditarDireccionFacturacion_Click(object sender, EventArgs e)
        {
			if (documento.socio_id != 0)
			{
				Socio.Direccion direccion = Socio.Direccion.Obtener(documento.direccion_facturacion_id);
				direccion.tipo = 'F';
				frmDireccion f = new frmDireccion();
				f.direccion = direccion;
				f.ShowDialog();
				CargarDirecciones();
			}
		}

        private void btnAgregarDireccionOrigen_Click(object sender, EventArgs e)
        {
			if (documento.socio_id != 0)
			{
				Socio.Direccion direccion = new Socio.Direccion();
				direccion.tipo = 'E';
				direccion.socio_id = Program.Nori.UsuarioAutenticado.socio_id;
				frmDireccion f = new frmDireccion();
				f.direccion = direccion;
				f.ShowDialog();
				if (f.direccion.id != 0)
				{
					documento.direccion_origen_id = f.direccion.id;
				}
				CargarDirecciones();
			}
		}

        private void btnEditarDireccionOrigen_Click(object sender, EventArgs e)
        {
			if (documento.socio_id != 0)
			{
				Socio.Direccion direccion = Socio.Direccion.Obtener(documento.direccion_origen_id);
				frmDireccion f = new frmDireccion();
				f.direccion = direccion;
				f.ShowDialog();
				CargarDirecciones();
			}
		}
    }
}