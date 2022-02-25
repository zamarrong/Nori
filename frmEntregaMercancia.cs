using NoriSDK;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nori
{
	public partial class frmEntregaMercancia : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		Documento documento = new Documento();
		Documento pedido = new Documento();
		Socio socio = new Socio();
		List<TipoEmpaque> tipos_empaques;
		List<Documento.Partida> partidas_pedido = new List<Documento.Partida>();
		List<UnidadMedida> unidades_medida = new List<UnidadMedida>();
		public frmEntregaMercancia(int id = 0)
		{
			InitializeComponent();
			this.MetodoDinamico();
			CargarListas();

			if (id != 0)
			{
				txtNumeroDocumento.Text = id.ToString();
				Buscar();
			}
		}
		#region bbi
		private void bbiGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (Guardar())
				Inicializar();
			else
				MessageBox.Show("Error al guardar: " + NoriSDK.Nori.ObtenerUltimoError().Message, Text);
		}
		private void Inicializar()
		{
			documento = new Documento();
			Cargar();
		}
		private void bbiGuardarCerrar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (Guardar())
			{
				pedido.Cerrar();
				Close();
			}
			else
			{
				MessageBox.Show("Error al guardar: " + NoriSDK.Nori.ObtenerUltimoError().Message, Text);
			}
		}
		private void Buscar()
		{
			try
			{
				pedido = Documento.ObtenerPorID("PE", int.Parse(txtNumeroDocumento.Text));

				if (pedido.id != 0 && pedido.estado.Equals('A'))
				{
					documento.CopiarDe(pedido, "EN", true);

					documento.partidas.ForEach(x => { x.cantidad = 0; });
					if (Program.Nori.UsuarioAutenticado.almacen_id != 0)
						if (MessageBox.Show("¿Cargar solo partidas del almacén predeterminado para este usuario?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
							documento.partidas.RemoveAll(x => x.almacen_id != Program.Nori.UsuarioAutenticado.almacen_id);
					Cargar();
				}
				else
				{
					Inicializar();
					MessageBox.Show("El pedido solicitado no ha sido encontrado o ya ha sido cerrado.");
				}
			}
			catch { }
		}
		#endregion
		private void Cargar()
		{
			if (documento.socio_id != 0)
				socio = Socio.Obtener(documento.socio_id);
			//General
			lblIdentificadorExterno.Visible = (documento.identificador_externo != 0) ? true : false;
			lblIdentificadorExterno.Text = documento.identificador_externo.ToString();

			lblNoDocumento.Text = documento.numero_documento.ToString();
			lblSocio.Text = socio.nombre;
			cbVendedores.EditValue = documento.vendedor_id;
			txtReferencia.Text = documento.referencia;
			txtComentario.Text = documento.comentario;
			partidas_pedido = documento.partidas;

			if (documento.partidas.Sum(x => x.documento_id) != 0)
				txtArticulo.Focus();
			else
				txtNumeroDocumento.Focus();

			Calcular();
		}
		private void CargarListas()
		{
			string clase = documento.clase;
			tipos_empaques = TipoEmpaque.TiposEmpaques().Where(x => x.activo == true).ToList();

			TipoEmpaque tipo_empaque = new TipoEmpaque()
			{
				id = 0,
				nombre = "-- Seleccionar --",
				peso = 0,
			};

			cbVendedores.Properties.DataSource = Vendedor.Vendedores().Select(x => new { x.id, x.nombre }).ToList();
			cbVendedores.Properties.ValueMember = "id";
			cbVendedores.Properties.DisplayMember = "nombre";

			cbAlmacenes.DataSource = Almacen.Almacenes().Select(x => new { x.id, x.codigo, x.nombre });
			cbAlmacenes.ValueMember = "id";
			cbAlmacenes.DisplayMember = "nombre";

			unidades_medida = UnidadMedida.UnidadesMedida().Where(x => x.activo == true).ToList();
			cbUnidadesMedida.DataSource = unidades_medida;
			cbUnidadesMedida.ValueMember = "id";
			cbUnidadesMedida.DisplayMember = "nombre";

			cbTiposEmpaques.DataSource = tipos_empaques;
			cbTiposEmpaques.ValueMember = "id";
			cbTiposEmpaques.DisplayMember = "nombre";


		}
		private void Calcular()
		{
			gcPartidas.DataSource = documento.partidas;
			gcPartidas.RefreshDataSource();

			documento.CalcularTotal();
		}
		private bool Llenar()
		{
			try
			{
				documento.vendedor_id = (int)cbVendedores.EditValue;
				documento.referencia = txtReferencia.Text;
				documento.comentario = txtComentario.Text;

				if (!documento.partidas.Any(x => x.cantidad > 0))
					return false;

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
					if (documento.id == 0 && !Program.Nori.Configuracion.venta_articulo_stock_cero)
					{
						Funciones.Cargando("Verificando existencias", "Por favor espere...");

						bool stock_negativo = false;

						if (Program.Nori.Configuracion.inventario_sap)
						{
							foreach (Documento.Partida partida in documento.partidas)
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
							documento.partidas.ForEach(x => x.ObtenerStock());

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

		private bool Guardar(bool imprimir = false)
		{
			try
			{
				if (MessageBox.Show("¿Desea guardar los cambios?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					if (Llenar())
					{
						if (documento.id != 0)
							return documento.Actualizar(true);
						else
							return documento.Agregar();
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
		private void gvPartidas_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
		{
			try
			{
				if (e.Column.FieldName == "tipo_empaque_id" || e.Column.FieldName == "cantidad_empaque")
				{
					try
					{
						if (Articulo.Articulos().Any(x => x.id == documento.partidas[e.RowHandle].articulo_id && x.pesable == true))
						{
							var tipo_empaque = tipos_empaques.Where(x => x.id == documento.partidas[e.RowHandle].tipo_empaque_id && x.activo == true).Select(x => new { x.id, x.peso }).First();

							documento.partidas[e.RowHandle].tipo_empaque_id = tipo_empaque.id;
							documento.partidas[e.RowHandle].cantidad -= (documento.partidas[e.RowHandle].cantidad_empaque * tipo_empaque.peso);

							documento.partidas[e.RowHandle].CalcularTotal();
						}
					}
					catch { }
				}
				if (e.Column.FieldName == "tipo_tara_id")
				{
					try
					{
						if (Articulo.Articulos().Any(x => x.id == documento.partidas[e.RowHandle].articulo_id && x.pesable == true))
						{
							var tipo_empaque = tipos_empaques.Where(x => x.id == documento.partidas[e.RowHandle].tipo_tara_id && x.activo == true).Select(x => new { x.id, x.peso }).First();

							documento.partidas[e.RowHandle].tipo_tara_id = tipo_empaque.id;
							documento.partidas[e.RowHandle].cantidad -= tipo_empaque.peso;

							documento.partidas[e.RowHandle].CalcularTotal();
						}
					}
					catch { }
				}
				else if (e.Column.FieldName == "cantidad")
				{
					Autorizacion autorizacion = new Autorizacion();

					autorizacion.codigo = "MOCPP";
					autorizacion.referencia = string.Format("Modificar cantidad al artículo {0} de {1} a {2}", documento.partidas[e.RowHandle].sku, gvPartidas.ActiveEditor.OldEditValue, gvPartidas.ActiveEditor.EditValue);
					autorizacion.comentario = Microsoft.VisualBasic.Interaction.InputBox("Comentario modificar cantidad (Opcional)", "");

					autorizacion.Agregar();

					if (!autorizacion.autorizado)
					{
						frmSolicitarAutorizacion fa = new frmSolicitarAutorizacion(autorizacion);
						fa.ShowDialog();
						autorizacion.autorizado = (fa.DialogResult == DialogResult.OK) ? true : false;
					}

					if (!autorizacion.autorizado)
						documento.partidas[e.RowHandle].cantidad = (decimal)gvPartidas.ActiveEditor.OldEditValue;

					if (documento.partidas[e.RowHandle].cantidad > documento.partidas[e.RowHandle].cantidad_pendiente)
					{
						if (Articulo.Articulos().Any(x => x.id == documento.partidas[e.RowHandle].articulo_id && x.pesable == false))
						{
							MessageBox.Show("No es posible entregar más de la cantidad solicitada si el artículo no es pesable.");
							documento.partidas[e.RowHandle].cantidad = (decimal)gvPartidas.ActiveEditor.OldEditValue;
						}
					}

					documento.partidas[e.RowHandle].CalcularTotal();
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
				txtArticulo.Focus();
			}
		}
		private void gvPartidas_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete)
			{
				if (documento.partidas.Count > 0)
				{
					Autorizacion autorizacion = new Autorizacion();

					autorizacion.codigo = "EPART";
					autorizacion.referencia = string.Format("Eliminar partida del artículo {0}", documento.partidas[gvPartidas.GetSelectedRows()[0]].sku);
					autorizacion.comentario = Microsoft.VisualBasic.Interaction.InputBox("Comentario eliminar partida (Opcional)", "");

					autorizacion.Agregar();

					if (!autorizacion.autorizado)
					{
						frmSolicitarAutorizacion fa = new frmSolicitarAutorizacion(autorizacion);
						fa.ShowDialog();

						autorizacion.autorizado = (fa.DialogResult == DialogResult.OK) ? true : false;
					}

					if (autorizacion.autorizado)
					{
						documento.partidas.Remove(documento.partidas[gvPartidas.GetSelectedRows()[0]]);
					}
				}

				Calcular();
			}

			if (e.Alt && e.KeyCode == Keys.E)
			{
				DataTable existencias = Utilidades.EjecutarQuery(string.Format("SELECT codigo AS Almacén, nombre AS [Nombre del almacén], stock AS Stock, comprometido AS Compormetido, pedido AS Pedido, disponible AS Disponible FROM DatosInventario WHERE articulo_id = {0} AND activo = 1", documento.partidas[gvPartidas.GetSelectedRows()[0]].articulo_id));
				frmResultadosBusqueda f = new frmResultadosBusqueda(existencias);
				f.Text = "Existencias " + documento.partidas[gvPartidas.GetSelectedRows()[0]].sku;
				f.ShowDialog();
			}
		}
		private void gvPartidas_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
		{
			if (e.RowHandle >= 0)
			{
				if (Convert.ToDouble(gvPartidas.GetRowCellValue(e.RowHandle, gvPartidas.Columns["cantidad"])) == 0)
					e.Appearance.BackColor = Color.Salmon;
				else if (Convert.ToDouble(gvPartidas.GetRowCellValue(e.RowHandle, gvPartidas.Columns["cantidad_pendiente"])) - Convert.ToDouble(gvPartidas.GetRowCellValue(e.RowHandle, gvPartidas.Columns["cantidad"])) <= 0)
					e.Appearance.BackColor = Color.GreenYellow;
				else
					e.Appearance.BackColor = Color.Yellow;
				e.Appearance.BackColor2 = Color.White;
			}
		}
		private async void AgregarPartida(string q)
		{
			try
			{
				Buscar:
				if (await Task.Run(() => documento.AgregarPartida(q)))
				{
					gvPartidas.MoveFirst();
					Documento.Partida partida = documento.partidas.OrderByDescending(x => x.fecha_lectura).First();

					if (partida.documento_id == 0)
					{
						MessageBox.Show("El artículo no pertenece al documento original.");
						documento.partidas.Remove(partida);
					}
					else
					{

						gvPartidas.MoveBy(gvPartidas.LocateByValue("articulo_id", partida.articulo_id));

						if (Articulo.Articulos().Any(x => x.id == partida.articulo_id && x.pesable == true))
						{
							gvPartidas.FocusedColumn = gvPartidas.Columns["cantidad_empaque"];
							gvPartidas.ShowEditor();
						}
						else
						{
							txtArticulo.Focus();
						}

						Calcular();
					}
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
			}
		}
		private void txtArticulo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Tab && txtArticulo.Text.Length > 0)
				{
					string q = txtArticulo.Text;

					string query = "SELECT articulos.id, sku as sku_articulo, articulos.nombre, (SELECT TOP 1 inventario.stock FROM inventario WHERE inventario.articulo_id = articulo_id AND inventario.almacen_id = " + Program.Nori.UsuarioAutenticado.almacen_id + ") AS stock, (SELECT dbo.[PrecioNetoArticulo](articulo_id, " + documento.socio_id + ", " + documento.lista_precio_id + ")) AS precio, monedas.codigo as moneda FROM articulos JOIN precios ON precios.articulo_id = articulos.id JOIN monedas ON monedas.id = precios.moneda_id AND precios.lista_precio_id = " + Program.Nori.Configuracion.lista_precio_id + " WHERE (sku = '" + q + "' OR articulos.nombre LIKE '%" + q.Replace(" ", "%") + "%' OR codigo_barras LIKE '%" + q + "%') AND venta = 1 AND articulos.activo = 1";

					DataTable articulos = Utilidades.EjecutarQuery(query);

					if (articulos.Rows.Count > 0)
					{
						if (articulos.Rows.Count == 1)
						{
							AgregarPartida(articulos.Rows[0][1].ToString());
						}
						else
						{
							frmResultadosBusquedaArticulos f = new frmResultadosBusquedaArticulos(articulos, true);
							var result = f.ShowDialog();

							txtArticulo.Text = string.Empty;
							txtArticulo.Focus();

							if (result == DialogResult.OK)
							{
								Cursor = Cursors.WaitCursor;
								f.filas.ForEach(x => AgregarPartida(articulos.Rows[x][1].ToString()));
								Calcular();
								Cursor = Cursors.Default;

								txtArticulo.Text = string.Empty;
								txtArticulo.Focus();
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
			if (e.KeyCode == Keys.Enter && txtArticulo.Text.Length > 0)
				AgregarPartida(txtArticulo.Text);
		}
		private void txtNumeroDocumento_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && txtNumeroDocumento.Text.Length > 0)
				Buscar();
		}
		private void gvPartidas_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (!documento.partidas[gvPartidas.GetSelectedRows()[0]].Modificable())
				e.Cancel = true;
		}

		private void bbiGuardarImprimir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (Guardar())
			{
				Funciones.ImprimirInformePredeterminado("EN", documento.id);
				Close();
			}
			else
			{
				MessageBox.Show("Error al guardar: " + NoriSDK.Nori.ObtenerUltimoError().Message, Text);
			}
		}
	}
}