using NoriSDK;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Nori
{
	public partial class frmArticulos : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		Articulo articulo = new Articulo();
		Articulo.Precio precio = new Articulo.Precio();
		public frmArticulos(int id = 0)
		{
			InitializeComponent();
			this.MetodoDinamico();

			if (id != 0)
			{
				articulo = Articulo.Obtener(id);
				Cargar();
			}
			else
			{
				Cargar(false, true);
			}

			CargarListas();

			Permisos();

			EventoControl.SuscribirEventos(this);
		}

		private void Permisos()
		{
			switch (Program.Nori.UsuarioAutenticado.rol)
			{
				case 'C':
					lblGrupoArticulos.Enabled = false;
					lblListaPrecios.Enabled = false;
					lblMonedas.Enabled = false;
					lblFabricantes.Enabled = false;
					mainRibbonPageGroup.Visible = false;
					break;
				case 'V':
					lblGrupoArticulos.Enabled = false;
					lblListaPrecios.Enabled = false;
					lblMonedas.Enabled = false;
					lblFabricantes.Enabled = false;
					mainRibbonPageGroup.Visible = false;
					break;
				case 'S':
					lblListaPrecios.Enabled = false;
					lblMonedas.Enabled = false;
					lblFabricantes.Enabled = false;
					mainRibbonPageGroup.Visible = false;
					break;
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
				articulo = new Articulo();
				Cargar();
			}
		}

		private void Cargar(bool nuevo = false, bool busqueda = false)
		{
			if (articulo.id != 0)
			{
				gcInventario.DataSource = Utilidades.EjecutarQuery(string.Format("SELECT * FROM DatosInventario WHERE articulo_id = {0}", articulo.id));
				gcUbicaciones.DataSource = Utilidades.EjecutarQuery(string.Format("SELECT * FROM ubicaciones_articulos WHERE articulo_id = {0}", articulo.id));
			}

			lblID.Text = articulo.id.ToString();

			cbGruposArticulos.EditValue = articulo.grupo_articulo_id;
			cbFabricantes.EditValue = articulo.fabricante_id;
			cbAlmacen.EditValue = articulo.almacen_id;
			cbTiposEmpaques.EditValue = articulo.tipo_empaque_id;

			cbAlmacenable.Checked = articulo.almacenable;
			cbVenta.Checked = articulo.venta;
			cbCompra.Checked = articulo.compra;
			cbCanjeable.Checked = articulo.canjeable;

			switch (articulo.seguimiento)
			{
				case 'N':
					rbNormal.Checked = true;
					break;
				case 'S':
					rbSeries.Checked = true;
					break;
				case 'L':
					rbLotes.Checked = true;
					break;
			}

			txtDiasGarantia.Text = articulo.dias_garantia.ToString();

			txtSKU.Text = articulo.sku;
			cbProveedores.EditValue = articulo.socio_id;
			txtSKUFabricante.Text = articulo.sku_fabricante;
			txtIDAdicional.Text = articulo.id_adicional;
			txtNombre.Text = articulo.nombre;
			txtDescripcion.Text = articulo.descripcion;
			txtNombreAPI.Text = articulo.nombre_api;

			pbImagen.LoadImage(articulo.imagen);

			txtCodigoBarras.Text = articulo.codigo_barras;
			txtClaveUnidad.Text = articulo.clave_unidad;
			cbUnidadesMedidaInventario.EditValue = articulo.unidad_medida_id;
			cbUnidadesMedidaCompra.EditValue = articulo.unidad_medida_compra_id;
			cbUnidadesMedidaVenta.EditValue = articulo.unidad_medida_venta_id;
			txtCodigoClasificacion.Text = articulo.codigo_clasificacion;
			txtStock.Text = articulo.Stock().ToString();
			txtPeso.Text = articulo.peso.ToString();
			txtCantidadCompra.Text = articulo.cantidad_compra.ToString();
			txtCantidadVenta.Text = articulo.cantidad_venta.ToString();
			txtCantidadPaquete.Text = articulo.cantidad_paquete.ToString();
			cbPesable.Checked = articulo.pesable;
			txtAjusteMaximo.Text = articulo.ajuste_maximo.ToString();
			txtAjusteMinimo.Text = articulo.ajuste_minimo.ToString();
			txtPedidoMinimo.Text = articulo.pedido_minimo.ToString();

			cbSujetoRetencion.Checked = articulo.sujeto_retencion;
			cbSujetoImpuesto.Checked = articulo.sujeto_impuesto;
			cbIEPS.Checked = articulo.ieps;

			cbImpuestosCompras.EditValue = articulo.impuesto_compra_id;
			cbImpuestosVentas.EditValue = articulo.impuesto_venta_id;

			txtComentario.Text = articulo.comentario;

			cbAPI.Checked = articulo.api;
			cbActivo.Checked = articulo.activo;

			lblFechaActualizacion.Text = articulo.fecha_actualizacion.ToShortDateString();

			if (nuevo)
			{
				bbiNuevo.Enabled = false;
				bbiGuardar.Enabled = true;
				bbiGuardarCerrar.Enabled = true;
				bbiGuardarNuevo.Enabled = true;
				txtSKU.Focus();
			}
			else
			{
				if (busqueda)
				{
					bbiNuevo.Enabled = true;
					bbiGuardar.Enabled = false;
					bbiGuardarCerrar.Enabled = false;
					bbiGuardarNuevo.Enabled = false;
					cbGruposArticulos.EditValue = null;
					cbFabricantes.EditValue = null;
					txtSKU.Focus();
				}
				else
				{
					bbiNuevo.Enabled = true;
					bbiGuardar.Enabled = true;
					bbiGuardarCerrar.Enabled = true;
					bbiGuardarNuevo.Enabled = true;
				}
			}

			xtraTabPageDatosInventario.PageVisible = xtraTabPageUbicaciones.PageVisible = (articulo.id == 0 || cbAlmacenable.Checked == false) ? false : true;

			CargarPrecio();
			CargarPropiedades();
			CargarRutas();
			CargarGrupos();
		}

		private void CargarPrecio()
		{
			if (cbListasPrecios.EditValue != null && cbMonedas.EditValue != null)
			{
				precio = Articulo.Precio.Obtener(articulo.id, (int)cbListasPrecios.EditValue, articulo.unidad_medida_id);
				cbMonedas.EditValue = precio.moneda_id;
				txtPrecio.Text = precio.precio.ToString();
				txtMultiplicador.Text = precio.multiplicador_puntos.ToString();
			}
		}

		private void CargarListas()
		{
			try
			{
				object p = new { fields = "id, codigo, nombre" };
				object o = new { activo = 1 };

				cbGruposArticulos.Properties.DataSource = Utilidades.Busqueda("grupos_articulos", o, p);
				cbGruposArticulos.Properties.ValueMember = "id";
				cbGruposArticulos.Properties.DisplayMember = "nombre";

				cbUnidadesMedidaInventario.Properties.DataSource = cbUnidadesMedidaCompra.Properties.DataSource = cbUnidadesMedidaVenta.Properties.DataSource = Utilidades.Busqueda("unidades_medida", o, p);
				cbUnidadesMedidaInventario.Properties.ValueMember = cbUnidadesMedidaCompra.Properties.ValueMember = cbUnidadesMedidaVenta.Properties.ValueMember = "id";
				cbUnidadesMedidaInventario.Properties.DisplayMember = cbUnidadesMedidaCompra.Properties.DisplayMember = cbUnidadesMedidaVenta.Properties.DisplayMember = "nombre";

				cbProveedores.Properties.DataSource = Socio.Socios().Where(x => x.tipo == 'P' && x.activo == true).Select(x => new { x.id, x.codigo, x.nombre }).ToList();
				cbProveedores.Properties.ValueMember = "id";
				cbProveedores.Properties.DisplayMember = "nombre";

				cbFabricantes.Properties.DataSource = Utilidades.Busqueda("fabricantes", o, p);
				cbFabricantes.Properties.ValueMember = "id";
				cbFabricantes.Properties.DisplayMember = "nombre";

				cbMonedas.Properties.DataSource = Utilidades.Busqueda("monedas", o, p);
				cbMonedas.Properties.ValueMember = "id";
				cbMonedas.Properties.DisplayMember = "nombre";
				cbMonedas.EditValue = Program.Nori.Configuracion.moneda_id;

				cbAlmacen.Properties.DataSource = cbAlmacenes.DataSource = Utilidades.Busqueda("almacenes", o, p);
				cbAlmacen.Properties.ValueMember = cbAlmacenes.ValueMember = "id";
				cbAlmacen.Properties.DisplayMember = cbAlmacenes.DisplayMember = "nombre";

				cbImpuestosCompras.Properties.DataSource = Utilidades.Busqueda("impuestos", new { compra = 1 }, p);
				cbImpuestosVentas.Properties.DataSource = Utilidades.Busqueda("impuestos", new { venta = 1 }, p);
				cbImpuestosCompras.Properties.ValueMember = cbImpuestosVentas.Properties.ValueMember = "id";
				cbImpuestosCompras.Properties.DisplayMember = cbImpuestosVentas.Properties.DisplayMember = "nombre";

				p = new { fields = "id, nombre" };

				cbListasPrecios.Properties.DataSource = Utilidades.Busqueda("listas_precios", o, p);
				cbListasPrecios.Properties.ValueMember = "id";
				cbListasPrecios.Properties.DisplayMember = "nombre";
				cbListasPrecios.EditValue = Program.Nori.Configuracion.lista_precio_id;

				cbTiposEmpaques.Properties.DataSource = Utilidades.Busqueda("tipos_empaques", o, p);
				cbTiposEmpaques.Properties.ValueMember = "id";
				cbTiposEmpaques.Properties.DisplayMember = "nombre";

				cbRutas.Properties.DataSource = Utilidades.Busqueda("rutas", o, p);
				cbRutas.Properties.ValueMember = "id";
				cbRutas.Properties.DisplayMember = "nombre";

				cbGrupos.Properties.DataSource = cbGruposArticulos.Properties.DataSource;
				cbGrupos.Properties.ValueMember = "id";
				cbGrupos.Properties.DisplayMember = "nombre";

				for (int i = 0; i < 32; i++)
				{
					cbPropiedades.Items.Add(string.Format("Propiedad {0}", i + 1));
				}
			} catch { }
		}

		private void CargarPropiedades()
		{
			try
			{
				cbPropiedades.Items[0].CheckState = (articulo.propiedad_1) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[1].CheckState = (articulo.propiedad_2) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[2].CheckState = (articulo.propiedad_3) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[3].CheckState = (articulo.propiedad_4) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[4].CheckState = (articulo.propiedad_5) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[5].CheckState = (articulo.propiedad_6) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[6].CheckState = (articulo.propiedad_7) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[7].CheckState = (articulo.propiedad_8) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[8].CheckState = (articulo.propiedad_9) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[9].CheckState = (articulo.propiedad_10) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[10].CheckState = (articulo.propiedad_11) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[11].CheckState = (articulo.propiedad_12) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[12].CheckState = (articulo.propiedad_13) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[13].CheckState = (articulo.propiedad_14) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[14].CheckState = (articulo.propiedad_15) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[15].CheckState = (articulo.propiedad_16) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[16].CheckState = (articulo.propiedad_17) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[17].CheckState = (articulo.propiedad_18) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[18].CheckState = (articulo.propiedad_19) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[19].CheckState = (articulo.propiedad_20) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[20].CheckState = (articulo.propiedad_21) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[21].CheckState = (articulo.propiedad_22) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[22].CheckState = (articulo.propiedad_23) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[23].CheckState = (articulo.propiedad_24) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[24].CheckState = (articulo.propiedad_25) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[25].CheckState = (articulo.propiedad_26) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[26].CheckState = (articulo.propiedad_27) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[27].CheckState = (articulo.propiedad_28) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[28].CheckState = (articulo.propiedad_29) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[29].CheckState = (articulo.propiedad_30) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[30].CheckState = (articulo.propiedad_31) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[31].CheckState = (articulo.propiedad_32) ? CheckState.Checked : CheckState.Unchecked;
			}
			catch { }
		}

		private void CargarRutas()
		{
			try
			{
				List<Articulo.Ruta> rutas = articulo.Rutas();
				cbRutas.SetEditValue(string.Join<int>(",", rutas.Select(x => x.ruta_id).ToList()));
			}
			catch (Exception ex)
			{
				Console.Write(ex.Message);
			}
		}

		private void CargarGrupos()
		{
			try
			{
				List<Articulo.Grupo> grupos = articulo.Grupos();
				cbGrupos.SetEditValue(string.Join<int>(",", grupos.Select(x => x.grupo_articulo_id).ToList()));
			}
			catch (Exception ex)
			{
				Console.Write(ex.Message);
			}
		}

		private void Llenar()
		{
			articulo.grupo_articulo_id = (cbGruposArticulos.EditValue.IsNullOrEmpty()) ? 0 : (int)cbGruposArticulos.EditValue;
			articulo.socio_id = (cbProveedores.EditValue.IsNullOrEmpty()) ? 0 : (int)cbProveedores.EditValue;
			articulo.fabricante_id = (cbFabricantes.EditValue.IsNullOrEmpty()) ? 0 : (int)cbFabricantes.EditValue;
			articulo.almacen_id = (cbAlmacen.EditValue.IsNullOrEmpty()) ? 0 : (int)cbAlmacen.EditValue;
			articulo.tipo_empaque_id = (cbTiposEmpaques.EditValue.IsNullOrEmpty()) ? 0 : (int)cbTiposEmpaques.EditValue;
			articulo.unidad_medida_id = (cbUnidadesMedidaInventario.EditValue.IsNullOrEmpty()) ? 0 : (int)cbUnidadesMedidaInventario.EditValue;
			articulo.unidad_medida_compra_id = (cbUnidadesMedidaCompra.EditValue.IsNullOrEmpty()) ? 0 : (int)cbUnidadesMedidaCompra.EditValue;
			articulo.unidad_medida_venta_id = (cbUnidadesMedidaVenta.EditValue.IsNullOrEmpty()) ? 0 : (int)cbUnidadesMedidaVenta.EditValue;

			articulo.almacenable = cbAlmacenable.Checked;
			articulo.venta = cbVenta.Checked;
			articulo.compra = cbCompra.Checked;
			articulo.canjeable = cbCanjeable.Checked;

			if (rbNormal.Checked)
				articulo.seguimiento = 'N';
			else if (rbSeries.Checked)
				articulo.seguimiento = 'S';
			else if (rbLotes.Checked)
				articulo.seguimiento = 'L';

			articulo.dias_garantia = short.Parse(txtDiasGarantia.Text);

			articulo.sku = txtSKU.Text;
			articulo.sku_fabricante = txtSKUFabricante.Text;
			articulo.id_adicional = txtIDAdicional.Text;
			articulo.nombre = txtNombre.Text;
			articulo.descripcion = txtDescripcion.Text;
			articulo.nombre_api = txtNombreAPI.Text;
			articulo.codigo_barras = txtCodigoBarras.Text;

			articulo.clave_unidad = txtClaveUnidad.Text;
			articulo.codigo_clasificacion = txtCodigoClasificacion.Text;
			articulo.peso = decimal.Parse(txtPeso.EditValue.ToString());
			articulo.cantidad_compra = decimal.Parse(txtCantidadCompra.EditValue.ToString());
			articulo.cantidad_venta = decimal.Parse(txtCantidadVenta.EditValue.ToString());
			articulo.cantidad_paquete = decimal.Parse(txtCantidadPaquete.EditValue.ToString());
			articulo.pesable = cbPesable.Checked;
			articulo.ajuste_maximo = decimal.Parse(txtAjusteMaximo.EditValue.ToString());
			articulo.ajuste_minimo = decimal.Parse(txtAjusteMinimo.EditValue.ToString());
			articulo.pedido_minimo = decimal.Parse(txtPedidoMinimo.EditValue.ToString());

			articulo.sujeto_retencion = cbSujetoRetencion.Checked;
			articulo.sujeto_impuesto = cbSujetoImpuesto.Checked;
			articulo.ieps = cbIEPS.Checked;

			articulo.impuesto_compra_id = (cbImpuestosCompras.EditValue.IsNullOrEmpty()) ? 0 : (int)cbImpuestosCompras.EditValue;
			articulo.impuesto_venta_id = (cbImpuestosVentas.EditValue.IsNullOrEmpty()) ? 0 : (int)cbImpuestosVentas.EditValue;

			articulo.comentario = txtComentario.Text;

			articulo.api = cbAPI.Checked;
			articulo.activo = cbActivo.Checked;

			try
			{
				//Propiedades
				articulo.propiedad_1 = (cbPropiedades.Items[0].CheckState == CheckState.Checked) ? true : false;
				articulo.propiedad_2 = (cbPropiedades.Items[1].CheckState == CheckState.Checked) ? true : false;
				articulo.propiedad_3 = (cbPropiedades.Items[2].CheckState == CheckState.Checked) ? true : false;
				articulo.propiedad_4 = (cbPropiedades.Items[3].CheckState == CheckState.Checked) ? true : false;
				articulo.propiedad_5 = (cbPropiedades.Items[4].CheckState == CheckState.Checked) ? true : false;
				articulo.propiedad_6 = (cbPropiedades.Items[5].CheckState == CheckState.Checked) ? true : false;
				articulo.propiedad_7 = (cbPropiedades.Items[6].CheckState == CheckState.Checked) ? true : false;
				articulo.propiedad_8 = (cbPropiedades.Items[7].CheckState == CheckState.Checked) ? true : false;
				articulo.propiedad_9 = (cbPropiedades.Items[8].CheckState == CheckState.Checked) ? true : false;
				articulo.propiedad_10 = (cbPropiedades.Items[9].CheckState == CheckState.Checked) ? true : false;
				articulo.propiedad_11 = (cbPropiedades.Items[10].CheckState == CheckState.Checked) ? true : false;
				articulo.propiedad_12 = (cbPropiedades.Items[11].CheckState == CheckState.Checked) ? true : false;
				articulo.propiedad_13 = (cbPropiedades.Items[12].CheckState == CheckState.Checked) ? true : false;
				articulo.propiedad_14 = (cbPropiedades.Items[13].CheckState == CheckState.Checked) ? true : false;
				articulo.propiedad_15 = (cbPropiedades.Items[14].CheckState == CheckState.Checked) ? true : false;
				articulo.propiedad_16 = (cbPropiedades.Items[15].CheckState == CheckState.Checked) ? true : false;
				articulo.propiedad_17 = (cbPropiedades.Items[16].CheckState == CheckState.Checked) ? true : false;
				articulo.propiedad_18 = (cbPropiedades.Items[17].CheckState == CheckState.Checked) ? true : false;
				articulo.propiedad_19 = (cbPropiedades.Items[18].CheckState == CheckState.Checked) ? true : false;
				articulo.propiedad_20 = (cbPropiedades.Items[19].CheckState == CheckState.Checked) ? true : false;
				articulo.propiedad_21 = (cbPropiedades.Items[20].CheckState == CheckState.Checked) ? true : false;
				articulo.propiedad_22 = (cbPropiedades.Items[21].CheckState == CheckState.Checked) ? true : false;
				articulo.propiedad_23 = (cbPropiedades.Items[22].CheckState == CheckState.Checked) ? true : false;
				articulo.propiedad_24 = (cbPropiedades.Items[23].CheckState == CheckState.Checked) ? true : false;
				articulo.propiedad_25 = (cbPropiedades.Items[24].CheckState == CheckState.Checked) ? true : false;
				articulo.propiedad_26 = (cbPropiedades.Items[25].CheckState == CheckState.Checked) ? true : false;
				articulo.propiedad_27 = (cbPropiedades.Items[26].CheckState == CheckState.Checked) ? true : false;
				articulo.propiedad_28 = (cbPropiedades.Items[27].CheckState == CheckState.Checked) ? true : false;
				articulo.propiedad_29 = (cbPropiedades.Items[28].CheckState == CheckState.Checked) ? true : false;
				articulo.propiedad_30 = (cbPropiedades.Items[29].CheckState == CheckState.Checked) ? true : false;
				articulo.propiedad_31 = (cbPropiedades.Items[30].CheckState == CheckState.Checked) ? true : false;
				articulo.propiedad_32 = (cbPropiedades.Items[31].CheckState == CheckState.Checked) ? true : false;
			}
			catch { }
		}

		private void LlenarPrecio()
		{
			try
			{
				precio.articulo_id = articulo.id;
				precio.lista_precio_id = (int)cbListasPrecios.EditValue;
				precio.moneda_id = (int)cbMonedas.EditValue;
				precio.precio = decimal.Parse(txtPrecio.EditValue.ToString());
				precio.multiplicador_puntos = decimal.Parse(txtMultiplicador.EditValue.ToString());
			} catch { }
		}

		private void LlenarRutas()
		{
			try
			{
				if (articulo.id != 0)
				{
					List<object> rutas = cbRutas.Properties.Items.GetCheckedValues();
					List<int> rutas_seleccionadas = new List<int>();
					foreach(object ruta_id in rutas)
					{
						Articulo.Ruta ruta = new Articulo.Ruta();

						ruta.articulo_id = articulo.id;
						ruta.ruta_id = (int)ruta_id;
						rutas_seleccionadas.Add(ruta.ruta_id);

						ruta.Agregar();
					}
					Utilidades.EjecutarQuery(string.Format("delete from articulos_rutas where articulo_id = {0} and ruta_id not in ({1})", articulo.id, string.Join<int>(",", rutas_seleccionadas)));
				}
			} catch { }
		}

		private void LlenarGrupos()
		{
			try
			{
				if (articulo.id != 0)
				{
					List<object> grupos = cbGrupos.Properties.Items.GetCheckedValues();
					List<int> grupos_seleccionados = new List<int>();
					foreach (object grupo_id in grupos)
					{
						Articulo.Grupo grupo = new Articulo.Grupo();

						grupo.articulo_id = articulo.id;
						grupo.grupo_articulo_id = (int)grupo_id;
						grupos_seleccionados.Add(grupo.grupo_articulo_id);

						grupo.Agregar();
					}
					Utilidades.EjecutarQuery(string.Format("delete from articulos_grupos where articulo_id = {0} and grupo_articulo_id not in ({1})", articulo.id, string.Join<int>(",", grupos_seleccionados)));
				}
			}
			catch { }
		}

		private bool Guardar()
		{
			try
			{
				if (MessageBox.Show("¿Desea guardar los cambios?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					Llenar();

					if (articulo.id != 0)
						articulo.Actualizar();
					else
						articulo.Agregar();

					LlenarPrecio();

					if (precio.id != 0)
						precio.Actualizar();
					else
						precio.Agregar();

					LlenarRutas();
					LlenarGrupos();

					return true;
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

		private void bbiPrimero_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				articulo = Articulo.Articulos().OrderBy(x => x.id).First();
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
				articulo = Articulo.Articulos().Where(x => x.id < articulo.id).OrderByDescending(x => x.id).First();
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
				articulo = Articulo.Articulos().Where(x => x.id > articulo.id).First();
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
				articulo = Articulo.Articulos().OrderByDescending(x => x.id).First();
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

		private void bbiNuevo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			articulo = new Articulo();
			Cargar(true);
		}

		private void btnImagen_Click(object sender, EventArgs e)
		{
			OpenFileDialog open = new OpenFileDialog();
			open.Filter = "Archivos de imagen(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
			if (open.ShowDialog() == DialogResult.OK)
			{
				string archivo = (Program.Nori.Configuracion.directorio_imagenes + @"\" + open.SafeFileName);
				File.Copy(open.FileName, archivo, true);
				pbImagen.Image = new Bitmap(archivo);
				articulo.imagen = open.SafeFileName;
			}
		}

		private void lblGrupoArticulos_Click(object sender, EventArgs e)
		{
			frmGruposArticulos form = new frmGruposArticulos((cbGruposArticulos.EditValue.IsNullOrEmpty()) ? 0 : (int)cbGruposArticulos.EditValue);
			form.ShowDialog();
			CargarListas();
		}

		private void Buscar()
		{
			try
			{
				if (articulo.id != 0)
				{
					articulo = new Articulo();
					Cargar(false, true);
				}
				else
				{
					object p = new { fields = "id AS ID, sku AS SKU, nombre AS Nombre, codigo_barras AS 'Codigo Barras', activo AS Activo", like = true };
					object o = new { sku = txtSKU.Text, nombre = txtNombre.Text, descripcion = txtDescripcion.Text, codigo_barras = txtCodigoBarras.Text, sku_fabricante = txtSKUFabricante.Text, grupo_articulo_id = (cbGruposArticulos.EditValue.IsNullOrEmpty()) ? null : cbGruposArticulos.EditValue };
					DataTable articulos = Utilidades.Busqueda("articulos", o, p);
					if (articulos.Rows.Count > 0)
					{
						if (articulos.Rows.Count == 1)
						{
							articulo = Articulo.Obtener((int)articulos.Rows[0]["id"]);
							Cargar();
						}
						else
						{
							frmResultadosBusqueda f = new frmResultadosBusqueda(articulos);
							var result = f.ShowDialog();
							if (result == DialogResult.OK)
							{
								articulo = Articulo.Obtener(f.id);
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

		private void txtSKU_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && articulo.id == 0)
				Buscar();
		}

		private void cbListasPrecios_EditValueChanged(object sender, EventArgs e)
		{
			CargarPrecio();
		}

		private void cbMonedas_EditValueChanged(object sender, EventArgs e)
		{
			txtPrecio.Text = TipoCambio.Convertir(precio.moneda_id, (int)cbMonedas.EditValue, 'V', precio.precio).ToString();
		}

		private void lblMonedas_Click(object sender, EventArgs e)
		{
			frmMonedas form = new frmMonedas((cbMonedas.EditValue.IsNullOrEmpty()) ? 0 : (int)cbMonedas.EditValue);
			form.ShowDialog();
			CargarListas();
		}

		private void lblListaPrecios_Click(object sender, EventArgs e)
		{
			frmListasPrecios form = new frmListasPrecios((cbListasPrecios.EditValue.IsNullOrEmpty()) ? 0 : (int)cbListasPrecios.EditValue);
			form.ShowDialog();
			CargarListas();
		}

		private void lblFabricantes_Click(object sender, EventArgs e)
		{
			frmFabricantes form = new frmFabricantes((cbFabricantes.EditValue.IsNullOrEmpty()) ? 0 : (int)cbFabricantes.EditValue);
			form.ShowDialog();
			CargarListas();
		}

		private void cbAlmacenable_CheckedChanged(object sender, EventArgs e)
		{
			xtraTabPageDatosInventario.PageVisible = xtraTabPageUbicaciones.PageVisible = (articulo.id == 0 || cbAlmacenable.Checked == false) ? false : true;
		}

		private void gcUbicaciones_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
		{
			try
			{
				DataRow row = gvUbicaciones.GetDataRow(gvUbicaciones.GetSelectedRows()[0]);
				gvUbicaciones.CloseEditor();

				int id = 0;
				int.TryParse(row["id"].ToString(), out id);

				Articulo.Ubicacion ubicacion = new Articulo.Ubicacion();

				if (id != 0)
					ubicacion = Articulo.Ubicacion.Obtener(id);

				if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.EndEdit)
				{
					int almacen_id = (int)row["almacen_id"];
					string ubic = (string)row["ubicacion"];
					bool activo = (row["activo"].IsNullOrEmpty() ? true : (bool)row["activo"]);

					ubicacion.articulo_id = articulo.id;
					ubicacion.almacen_id = almacen_id;
					ubicacion.ubicacion = ubic;
					ubicacion.activo = activo;

					if (ubicacion.id != 0)
					{
						if (!ubicacion.Actualizar())
							MessageBox.Show(NoriSDK.Nori.ObtenerUltimoError().Message);
					}
					else
					{
						if (!ubicacion.Agregar())
							MessageBox.Show(NoriSDK.Nori.ObtenerUltimoError().Message);
					}
				}
				else if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove && ubicacion.id != 0)
				{
					ubicacion.Eliminar();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void gcInventario_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
		{
			try
			{
				DataRow row = gvInventario.GetDataRow(gvInventario.GetSelectedRows()[0]);
				gvInventario.CloseEditor();
				if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.EndEdit)
				{
					int articulo_id = (int)row["articulo_id"];
					int almacen_id = (int)row["almacen_id"];
					Articulo.Inventario inventario = Articulo.Inventario.Obtener(articulo_id, almacen_id);

					if (inventario.id != 0)
					{
						inventario.activo = (bool)row["activo"];
						inventario.stock_minimo = decimal.Parse(row["stock_minimo"].ToString());
						inventario.stock_maximo = decimal.Parse(row["stock_maximo"].ToString());
						inventario.punto_reorden = decimal.Parse(row["punto_reorden"].ToString());
						inventario.costo = decimal.Parse(row["costo"].ToString());

						if (!inventario.Actualizar())
							MessageBox.Show(NoriSDK.Nori.ObtenerUltimoError().Message);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void lblCodigoBarras_Click(object sender, EventArgs e)
		{
			try
			{
				DataTable codigos = Utilidades.EjecutarQuery(string.Format("select codigos_barras.id, codigos_barras.codigo, codigos_barras.nombre comentario, unidades_medida.nombre udm from codigos_barras left join unidades_medida on codigos_barras.unidad_medida_id = unidades_medida.id where articulo_id = {0}", articulo.id));
				if (codigos.Rows.Count > 0)
				{
					frmResultadosBusqueda f = new frmResultadosBusqueda(codigos);
					f.Text = string.Format("Códigos de barras del artículo {0}", articulo.sku);
					var result = f.ShowDialog();
				}
			}
			catch { }
		}

		private void lblTiposEmpaques_Click(object sender, EventArgs e)
		{
			frmTiposEmpaques f = new frmTiposEmpaques();
			f.ShowDialog();
		}

		private void lblProveedor_Click(object sender, EventArgs e)
		{
			frmSocios form = new frmSocios((cbProveedores.EditValue.IsNullOrEmpty()) ? 0 : (int)cbProveedores.EditValue);
			form.ShowDialog();
		}

		private void btnAgregarAlInventario_Click(object sender, EventArgs e)
		{
			try
			{
				int almacen_id = (cbAlmacen.EditValue.IsNullOrEmpty()) ? 0 : (int)cbAlmacen.EditValue;
				if (almacen_id != 0 && articulo.id != 0)
				{
					Articulo.Inventario inventario = Articulo.Inventario.Obtener(articulo.id, almacen_id);
					if (inventario.id == 0)
					{
						inventario.articulo_id = articulo.id;
						inventario.almacen_id = almacen_id;

						if (inventario.Agregar())
							MessageBox.Show("Se agregó la información correctamente.");
						else
							MessageBox.Show(NoriSDK.Nori.ObtenerUltimoError().Message);
					}
					else
					{
						MessageBox.Show("El inventario de este artículo ya incluye este almacén.");
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void lblTipoRuta_Click(object sender, EventArgs e)
		{
			frmRutas f = new frmRutas();
			f.ShowDialog();
			CargarListas();
		}

		private void lblUnidadMedidaCompra_Click(object sender, EventArgs e)
		{
			frmUnidadesMedida form = new frmUnidadesMedida((cbUnidadesMedidaCompra.EditValue.IsNullOrEmpty()) ? 0 : (int)cbUnidadesMedidaCompra.EditValue);
			form.ShowDialog();
		}

		private void lblUnidadMedidaVenta_Click(object sender, EventArgs e)
		{
			frmUnidadesMedida form = new frmUnidadesMedida((cbUnidadesMedidaVenta.EditValue.IsNullOrEmpty()) ? 0 : (int)cbUnidadesMedidaVenta.EditValue);
			form.ShowDialog();
		}
	}
}