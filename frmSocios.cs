using NoriSDK;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Nori
{
	public partial class frmSocios : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		Socio socio = new Socio();
		Socio.Direccion direccion = new Socio.Direccion();
		public frmSocios(int id = 0)
		{
			InitializeComponent();
			this.MetodoDinamico();

			CargarListas();

			if (id != 0)
			{
				socio = Socio.Obtener(id);

				Cargar();
			}
			else
			{
				Cargar(false, true);
			}
		
			Permisos();
			CargarInformes("SN");

			EventoControl.SuscribirEventos(this);
		}

		private void Permisos()
		{
			switch (Program.Nori.UsuarioAutenticado.rol)
			{
				case 'C':
					lblGrupoSocios.Enabled = false;
					lblCondicionesPago.Enabled = false;
					lblMonedas.Enabled = false;
					mainRibbonPageGroup.Visible = false;
					break;
				case 'V':
					txtLimiteCredito.Enabled = false;
					cbCondicionesPago.Enabled = false;
					break;
				case 'S':
					txtLimiteCredito.Enabled = false;
					cbCondicionesPago.Enabled = false;
					break;
			}
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
					boton.ItemClick += (object sender, DevExpress.XtraBars.ItemClickEventArgs e) => { Funciones.ImprimirInforme(informe.id, socio.id, true); };
					botonPDF.ItemClick += (object sender, DevExpress.XtraBars.ItemClickEventArgs e) => { Process.Start(@Funciones.PDFInforme(informe.id, socio.id)); };

					bbiImprimir.AddItem(boton);
					bbiPDF.AddItem(botonPDF);
				}
			}
			catch (Exception ex)
			{ MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error); }
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
				socio = new Socio();
				Cargar();
			}
		}

		private void Cargar(bool nuevo = false, bool busqueda = false)
		{
			try
			{
				lblID.Text = socio.id.ToString();
				cbListaPrecios.EditValue = socio.lista_precio_id;
				cbMonedas.EditValue = socio.moneda_id;
				cbCondicionesPago.EditValue = socio.condicion_pago_id;
				cbMetodosPago.EditValue = socio.metodo_pago_id;
				cbGruposSocios.EditValue = socio.grupo_socio_id;
				txtCodigo.Text = socio.codigo;
				cbTipo.EditValue = socio.tipo;
				txtNombre.Text = socio.nombre;
				txtNombreComercial.Text = socio.nombre_comercial;
				txtRFC.Text = socio.rfc;
				txtCURP.Text = socio.curp;
				txtTelefono.Text = socio.telefono;
				txtTelefono2.Text = socio.telefono2;
				txtTelefonoCelular.Text = socio.celular;
				txtCorreo.Text = socio.correo;
				txtSitioWeb.Text = socio.sitio_web;
				cbVendedores.EditValue = socio.vendedor_id;
				cbPropietarios.EditValue = socio.propietario_id;

				pbImagen.LoadImage(socio.imagen);

				txtBalance.Text = socio.balance.ToString();
				txtPorcentajeInteresRetraso.Text = socio.porcentaje_interes_retraso.ToString();
				txtPorcentajeDescuento.Text = socio.porcentaje_descuento.ToString();
				txtLimiteCredito.Text = socio.limite_credito.ToString();
				txtCuenta.Text = socio.cuenta;
				txtCuentaPago.Text = socio.cuenta_pago;
				cbOrdenCompra.Checked = socio.orden_compra;
				txtMultiplicador.Text = socio.multiplicador_puntos.ToString();
				cbUsoPrincipal.EditValue = socio.uso_principal;
				cbEventual.Checked = socio.eventual;
				cbSocios.EditValue = socio.socio_eventual_id;
				cbMonedero.EditValue = socio.monedero_id;

				txtLatitud.EditValue = socio.latitud;
				txtLongitud.EditValue = socio.longitud;
				cbFrecuencia.EditValue = socio.frecuencia;
				cbRutas.EditValue = socio.ruta_id;
				txtOrdenRuta.EditValue = socio.orden_ruta;

				cbAPI.Checked = socio.api;
				cbActivo.Checked = socio.activo;

				lblFechaActualizacion.Text = socio.fecha_actualizacion.ToShortDateString();

				cbListaPrecios.Enabled = (socio.lista_precio_id >= 0) ? true : false;
				CargarDirecciones();
				CargarPersonasContacto();
				CargarPropiedades();

				if (nuevo)
				{
					bbiNuevo.Enabled = false;
					bbiPDF.Enabled = bbiImprimir.Enabled = bbiGuardar.Enabled = bbiGuardarCerrar.Enabled = bbiGuardarNuevo.Enabled = txtCodigo.Enabled = true;
					txtCodigo.Focus();
				}
				else
				{
					if (busqueda)
					{
						bbiNuevo.Enabled = txtCodigo.Enabled = true;
						bbiPDF.Enabled = bbiImprimir.Enabled = bbiGuardar.Enabled = bbiGuardarCerrar.Enabled = bbiGuardarNuevo.Enabled = false;
						cbGruposSocios.EditValue = null;
						txtCodigo.Focus();
					}
					else
					{
						bbiPDF.Enabled = bbiImprimir.Enabled = bbiNuevo.Enabled = bbiGuardar.Enabled = bbiGuardarCerrar.Enabled = bbiGuardarNuevo.Enabled = true;
						txtCodigo.Enabled = false;
					}
				}

				txtCodigo.ReadOnly = !txtCodigo.Enabled;

				xtraTabPagePersonasContacto.PageVisible = xtraTabPageDirecciones.PageVisible = (socio.id == 0) ? false : true;
			} catch { } 
		}

		private void CargarListas()
		{
			object p = new { fields = "id, codigo, nombre" };
			object o = new { activo = 1 };

			cbGruposSocios.Properties.DataSource = Utilidades.Busqueda("grupos_socios", o, p);
			cbGruposSocios.Properties.ValueMember = "id";
			cbGruposSocios.Properties.DisplayMember = "nombre";

			cbCondicionesPago.Properties.DataSource = Utilidades.Busqueda("condiciones_pago", o, p);
			cbCondicionesPago.Properties.ValueMember = "id";
			cbCondicionesPago.Properties.DisplayMember = "nombre";

			cbMetodosPago.Properties.DataSource = Utilidades.Busqueda("metodos_pago", o, p);
			cbMetodosPago.Properties.ValueMember = "id";
			cbMetodosPago.Properties.DisplayMember = "nombre";

			cbMonedas.Properties.DataSource = Utilidades.Busqueda("monedas", o, p);
			cbMonedas.Properties.ValueMember = "id";
			cbMonedas.Properties.DisplayMember = "nombre";
			cbMonedas.EditValue = Program.Nori.Configuracion.moneda_id;

			cbVendedores.Properties.DataSource = Vendedor.Vendedores().Where(x => x.activo == true).Select(x => new { x.id, x.nombre }).ToList();
			cbVendedores.Properties.ValueMember = "id";
			cbVendedores.Properties.DisplayMember = "nombre";

			cbPropietarios.Properties.DataSource = Propietario.Propietarios().Where(x => x.activo == true).Select(x => new { x.id, x.nombre }).ToList();
			cbPropietarios.Properties.ValueMember = "id";
			cbPropietarios.Properties.DisplayMember = "nombre";

			cbPaises.Properties.DataSource = Utilidades.Busqueda("paises", null, p);
			cbPaises.Properties.ValueMember = "id";
			cbPaises.Properties.DisplayMember = "nombre";

			cbEstados.Properties.DataSource = Utilidades.Busqueda("estados", null, new { fields = "id, pais_id, codigo, nombre" });
			cbEstados.Properties.ValueMember = "id";
			cbEstados.Properties.DisplayMember = "nombre";

			cbImpuestos.Properties.DataSource = Utilidades.Busqueda("impuestos", null, p);
			cbImpuestos.Properties.ValueMember = "id";
			cbImpuestos.Properties.DisplayMember = "nombre";

			p = new { fields = "id, nombre" };

			cbListaPrecios.Properties.DataSource = Utilidades.Busqueda("listas_precios", o, p);
			cbListaPrecios.Properties.ValueMember = "id";
			cbListaPrecios.Properties.DisplayMember = "nombre";
			cbListaPrecios.EditValue = Program.Nori.Configuracion.lista_precio_id;

			p = new { fields = "id, tipo, codigo, nombre" };

			cbGruposSocios.Properties.DataSource = Utilidades.Busqueda("grupos_socios", o, p);
			cbGruposSocios.Properties.ValueMember = "id";
			cbGruposSocios.Properties.DisplayMember = "nombre";

			cbTipo.Properties.DataSource = Socio.Tipo.Tipos();
			cbTipo.Properties.ValueMember = "tipo";
			cbTipo.Properties.DisplayMember = "nombre";
			cbTipo.EditValue = Socio.Tipo.ObtenerPredeterminado();

			cbTipoDireccion.Properties.DataSource = Socio.Direccion.Tipo.Tipos();
			cbTipoDireccion.Properties.ValueMember = "tipo";
			cbTipoDireccion.Properties.DisplayMember = "nombre";

			cbFrecuencia.Properties.DataSource = Socio.Frecuencia.Frequencias();
			cbFrecuencia.Properties.ValueMember = "frecuencia";
			cbFrecuencia.Properties.DisplayMember = "nombre";

			cbGenero.DataSource = Socio.PersonaContacto.Genero.Generos();
			cbGenero.ValueMember = "genero";
			cbGenero.DisplayMember = "nombre";

			cbSocios.Properties.DataSource = Socio.Socios().Where(x => x.activo == true).Select(x => new { x.id, x.codigo, x.nombre }).ToList();
			cbSocios.Properties.ValueMember = "id";
			cbSocios.Properties.DisplayMember = "nombre";

			cbMonedero.Properties.DataSource = Monedero.Monederos().Where(x => x.activo == true).Select(x => new { x.id, x.folio }).ToList();
			cbMonedero.Properties.ValueMember = "id";
			cbMonedero.Properties.DisplayMember = "folio";

			cbUsoPrincipal.Properties.DataSource = Documento.UsoCFDI.UsosCFDI();
			cbUsoPrincipal.Properties.ValueMember = "uso";
			cbUsoPrincipal.Properties.DisplayMember = "nombre";

			cbRutas.Properties.DataSource = Ruta.Rutas().Where(x => x.activo == true).Select(x => new { x.id, x.codigo, x.nombre }).ToList();
			cbRutas.Properties.ValueMember = "id";
			cbRutas.Properties.DisplayMember = "nombre";

			for (int i = 0; i < 32; i++)
			{
				cbPropiedades.Items.Add(string.Format("Propiedad {0}", i + 1));
			}
		}

		private void CargarPersonasContacto()
		{
			cbPersonasContacto.Properties.DataSource = Socio.PersonaContacto.PersonasContacto().Where(x => x.socio_id == socio.id).Select(x => new { x.id, x.nombre }).ToList();
			cbPersonasContacto.Properties.ValueMember = "id";
			cbPersonasContacto.Properties.DisplayMember = "nombre";
			cbPersonasContacto.EditValue = socio.persona_contacto_id;

			gcPersonasContacto.DataSource = Utilidades.EjecutarQuery(string.Format("SELECT * FROM personas_contacto WHERE socio_id = {0}", socio.id));
		}

		private void CargarDirecciones()
		{
			try
			{
				cbDireccionesFacturacion.Properties.DataSource = Socio.Direccion.Direcciones().Where(x => x.socio_id == socio.id && x.tipo == 'F').Select(x => new { x.id, x.nombre }).ToList();
				cbDireccionesFacturacion.Properties.ValueMember = "id";
				cbDireccionesFacturacion.Properties.DisplayMember = "nombre";
				cbDireccionesFacturacion.EditValue = socio.direccion_facturacion_id;

				cbDireccionesEnvio.Properties.DataSource = Socio.Direccion.Direcciones().Where(x => x.socio_id == socio.id && x.tipo == 'E').Select(x => new { x.id, x.nombre }).ToList();
				cbDireccionesEnvio.Properties.ValueMember = "id";
				cbDireccionesEnvio.Properties.DisplayMember = "nombre";
				cbDireccionesEnvio.EditValue = socio.direccion_envio_id;

				cbDirecciones.Properties.DataSource = cbDireccionesEnvio.Properties.DataSource = Socio.Direccion.Direcciones().Where(x => x.socio_id == socio.id).Select(x => new { x.id, x.nombre }).ToList();
				cbDirecciones.Properties.ValueMember = "id";
				cbDirecciones.Properties.DisplayMember = "nombre";
				cbDirecciones.EditValue = socio.direccion_facturacion_id;
			}
			catch { }
		}

		private void CargarPropiedades()
		{
			try
			{
				cbPropiedades.Items[0].CheckState = (socio.propiedad_1) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[1].CheckState = (socio.propiedad_2) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[2].CheckState = (socio.propiedad_3) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[3].CheckState = (socio.propiedad_4) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[4].CheckState = (socio.propiedad_5) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[5].CheckState = (socio.propiedad_6) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[6].CheckState = (socio.propiedad_7) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[7].CheckState = (socio.propiedad_8) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[8].CheckState = (socio.propiedad_9) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[9].CheckState = (socio.propiedad_10) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[10].CheckState = (socio.propiedad_11) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[11].CheckState = (socio.propiedad_12) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[12].CheckState = (socio.propiedad_13) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[13].CheckState = (socio.propiedad_14) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[14].CheckState = (socio.propiedad_15) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[15].CheckState = (socio.propiedad_16) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[16].CheckState = (socio.propiedad_17) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[17].CheckState = (socio.propiedad_18) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[18].CheckState = (socio.propiedad_19) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[19].CheckState = (socio.propiedad_20) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[20].CheckState = (socio.propiedad_21) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[21].CheckState = (socio.propiedad_22) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[22].CheckState = (socio.propiedad_23) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[23].CheckState = (socio.propiedad_24) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[24].CheckState = (socio.propiedad_25) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[25].CheckState = (socio.propiedad_26) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[26].CheckState = (socio.propiedad_27) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[27].CheckState = (socio.propiedad_28) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[28].CheckState = (socio.propiedad_29) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[29].CheckState = (socio.propiedad_30) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[30].CheckState = (socio.propiedad_31) ? CheckState.Checked : CheckState.Unchecked;
				cbPropiedades.Items[31].CheckState = (socio.propiedad_32) ? CheckState.Checked : CheckState.Unchecked;
			} catch { }
		}

		private void CargarGruposSocios()
		{
			string tipo = cbTipo.EditValue.ToString();

			if (tipo == "L")
				tipo = "C";

			(cbGruposSocios.Properties.DataSource as DataTable).DefaultView.RowFilter = string.Format("tipo = '{0}'", tipo);
		}

		private bool Llenar()
		{
			try
			{
				if (socio.lista_precio_id >= 0)
					socio.lista_precio_id = (cbListaPrecios.EditValue.IsNullOrEmpty()) ? 0 : (int)cbListaPrecios.EditValue;

				socio.moneda_id = (cbMonedas.EditValue.IsNullOrEmpty()) ? 0 : (int)cbMonedas.EditValue;
				socio.condicion_pago_id = (cbCondicionesPago.EditValue.IsNullOrEmpty()) ? 0 : (int)cbCondicionesPago.EditValue;
				socio.metodo_pago_id = (cbMetodosPago.EditValue.IsNullOrEmpty()) ? 0 : (int)cbMetodosPago.EditValue;
				socio.grupo_socio_id = (cbGruposSocios.EditValue.IsNullOrEmpty()) ? 0 : (int)cbGruposSocios.EditValue;
				socio.direccion_facturacion_id = (cbDireccionesFacturacion.EditValue.IsNullOrEmpty()) ? 0 : (int)cbDireccionesFacturacion.EditValue;
				socio.direccion_envio_id = (cbDireccionesEnvio.EditValue.IsNullOrEmpty()) ? 0 : (int)cbDireccionesEnvio.EditValue;
				socio.vendedor_id = (cbVendedores.EditValue.IsNullOrEmpty()) ? 0 : (int)cbVendedores.EditValue;
				socio.propietario_id = (cbPropietarios.EditValue.IsNullOrEmpty()) ? 0 : (int)cbPropietarios.EditValue;
				socio.codigo = txtCodigo.Text;
				socio.tipo = (char)cbTipo.EditValue;
				socio.nombre = txtNombre.Text;
				socio.nombre_comercial = txtNombreComercial.Text;
				socio.rfc = txtRFC.Text;
				socio.curp = txtCURP.Text;
				socio.telefono = txtTelefono.Text;
				socio.telefono2 = txtTelefono2.Text;
				socio.celular = txtTelefonoCelular.Text;
				socio.correo = txtCorreo.Text;
				socio.sitio_web = txtSitioWeb.Text;
				socio.porcentaje_interes_retraso = decimal.Parse(txtPorcentajeInteresRetraso.EditValue.ToString());
				socio.porcentaje_descuento = decimal.Parse(txtPorcentajeDescuento.EditValue.ToString());
				socio.limite_credito = decimal.Parse(txtLimiteCredito.EditValue.ToString());
				socio.cuenta = txtCuenta.Text;
				socio.cuenta_pago = txtCuentaPago.Text;
				socio.orden_compra = cbOrdenCompra.Checked;
				socio.multiplicador_puntos = decimal.Parse(txtMultiplicador.EditValue.ToString());
				socio.uso_principal = cbUsoPrincipal.EditValue.ToString();
				socio.eventual = cbEventual.Checked;
				socio.socio_eventual_id = (cbSocios.EditValue.IsNullOrEmpty()) ? 0 : (int)cbSocios.EditValue;
				socio.monedero_id = (cbMonedero.EditValue.IsNullOrEmpty()) ? 0 : (int)cbMonedero.EditValue;
				socio.api = cbAPI.Checked;
				socio.latitud = decimal.Parse(txtLatitud.Text);
				socio.longitud = decimal.Parse(txtLongitud.Text);
				socio.frecuencia = (char)cbFrecuencia.EditValue;
				socio.ruta_id = (cbRutas.EditValue.IsNullOrEmpty()) ? 0 : (int)cbRutas.EditValue;
				socio.orden_ruta = int.Parse(txtOrdenRuta.Text);
				socio.activo = cbActivo.Checked;

				try
				{
					//Propiedades
					socio.propiedad_1 = (cbPropiedades.Items[0].CheckState == CheckState.Checked) ? true : false;
					socio.propiedad_2 = (cbPropiedades.Items[1].CheckState == CheckState.Checked) ? true : false;
					socio.propiedad_3 = (cbPropiedades.Items[2].CheckState == CheckState.Checked) ? true : false;
					socio.propiedad_4 = (cbPropiedades.Items[3].CheckState == CheckState.Checked) ? true : false;
					socio.propiedad_5 = (cbPropiedades.Items[4].CheckState == CheckState.Checked) ? true : false;
					socio.propiedad_6 = (cbPropiedades.Items[5].CheckState == CheckState.Checked) ? true : false;
					socio.propiedad_7 = (cbPropiedades.Items[6].CheckState == CheckState.Checked) ? true : false;
					socio.propiedad_8 = (cbPropiedades.Items[7].CheckState == CheckState.Checked) ? true : false;
					socio.propiedad_9 = (cbPropiedades.Items[8].CheckState == CheckState.Checked) ? true : false;
					socio.propiedad_10 = (cbPropiedades.Items[9].CheckState == CheckState.Checked) ? true : false;
					socio.propiedad_11 = (cbPropiedades.Items[10].CheckState == CheckState.Checked) ? true : false;
					socio.propiedad_12 = (cbPropiedades.Items[11].CheckState == CheckState.Checked) ? true : false;
					socio.propiedad_13 = (cbPropiedades.Items[12].CheckState == CheckState.Checked) ? true : false;
					socio.propiedad_14 = (cbPropiedades.Items[13].CheckState == CheckState.Checked) ? true : false;
					socio.propiedad_15 = (cbPropiedades.Items[14].CheckState == CheckState.Checked) ? true : false;
					socio.propiedad_16 = (cbPropiedades.Items[15].CheckState == CheckState.Checked) ? true : false;
					socio.propiedad_17 = (cbPropiedades.Items[16].CheckState == CheckState.Checked) ? true : false;
					socio.propiedad_18 = (cbPropiedades.Items[17].CheckState == CheckState.Checked) ? true : false;
					socio.propiedad_19 = (cbPropiedades.Items[18].CheckState == CheckState.Checked) ? true : false;
					socio.propiedad_20 = (cbPropiedades.Items[19].CheckState == CheckState.Checked) ? true : false;
					socio.propiedad_21 = (cbPropiedades.Items[20].CheckState == CheckState.Checked) ? true : false;
					socio.propiedad_22 = (cbPropiedades.Items[21].CheckState == CheckState.Checked) ? true : false;
					socio.propiedad_23 = (cbPropiedades.Items[22].CheckState == CheckState.Checked) ? true : false;
					socio.propiedad_24 = (cbPropiedades.Items[23].CheckState == CheckState.Checked) ? true : false;
					socio.propiedad_25 = (cbPropiedades.Items[24].CheckState == CheckState.Checked) ? true : false;
					socio.propiedad_26 = (cbPropiedades.Items[25].CheckState == CheckState.Checked) ? true : false;
					socio.propiedad_27 = (cbPropiedades.Items[26].CheckState == CheckState.Checked) ? true : false;
					socio.propiedad_28 = (cbPropiedades.Items[27].CheckState == CheckState.Checked) ? true : false;
					socio.propiedad_29 = (cbPropiedades.Items[28].CheckState == CheckState.Checked) ? true : false;
					socio.propiedad_30 = (cbPropiedades.Items[29].CheckState == CheckState.Checked) ? true : false;
					socio.propiedad_31 = (cbPropiedades.Items[30].CheckState == CheckState.Checked) ? true : false;
					socio.propiedad_32 = (cbPropiedades.Items[31].CheckState == CheckState.Checked) ? true : false;
				} catch { }

				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return false;
			}
		}

		private bool Guardar()
		{
			try
			{
				if (MessageBox.Show("¿Desea guardar los cambios?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					Llenar();
					if (socio.id != 0)
					{
						return socio.Actualizar();
					}
					else
					{
						return socio.Agregar();
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

		private void bbiPrimero_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				socio = Socio.Socios().OrderBy(x => x.id).First();
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
				socio = Socio.Socios().Where(x => x.id < socio.id).OrderByDescending(x => x.id).First();
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
				socio = Socio.Socios().Where(x => x.id > socio.id).First();
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
				socio = Socio.Socios().OrderByDescending(x => x.id).First();
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
			socio = new Socio();
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
				socio.imagen = open.FileName;
			}
		}

		private void Buscar()
		{
			try
			{
				if (socio.id != 0)
				{
					socio = new Socio();
					Cargar(false, true);
				}
				else
				{
					object p = new { fields = "id, codigo, nombre, rfc, telefono, celular, activo", like = true };
					object o = new { codigo = txtCodigo.Text, nombre = txtNombre.Text, descripcion = txtNombreComercial.Text, grupo_socio_id = (cbGruposSocios.EditValue.IsNullOrEmpty()) ? null : cbGruposSocios.EditValue };
					DataTable socios = Utilidades.Busqueda("socios", o, p);
					if (socios.Rows.Count > 0)
					{
						if (socios.Rows.Count == 1)
						{
							socio = Socio.Obtener((int)socios.Rows[0]["id"]);
							Cargar();
						}
						else
						{
							frmResultadosBusqueda f = new frmResultadosBusqueda(socios);
							var result = f.ShowDialog();
							if (result == DialogResult.OK)
							{
								socio = Socio.Obtener(f.id);
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
			if (e.KeyCode == Keys.Enter && socio.id == 0)
				Buscar();
		}

		private void lblMonedas_Click(object sender, EventArgs e)
		{
			frmMonedas form = new frmMonedas((cbMonedas.EditValue.IsNullOrEmpty()) ? 0 : (int)cbMonedas.EditValue);
			form.ShowDialog();
			CargarListas();
		}

		private void lblGrupoSocios_Click(object sender, EventArgs e)
		{
			frmGruposSocios form = new frmGruposSocios((cbGruposSocios.EditValue.IsNullOrEmpty()) ? 0 : (int)cbGruposSocios.EditValue);
			form.ShowDialog();
			CargarListas();
		}

		private void lblListaPrecios_Click(object sender, EventArgs e)
		{
			frmListasPrecios form = new frmListasPrecios((cbListaPrecios.EditValue.IsNullOrEmpty()) ? 0 : (int)cbListaPrecios.EditValue);
			form.ShowDialog();
			CargarListas();
		}

		private void lblCondicionesPago_Click(object sender, EventArgs e)
		{
			frmCondicionesPago form = new frmCondicionesPago((cbCondicionesPago.EditValue.IsNullOrEmpty()) ? 0 : (int)cbCondicionesPago.EditValue);
			form.ShowDialog();
			CargarListas();
		}

		private void gridControl1_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
		{
			if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.EndEdit && socio.id != 0)
			{
				try
				{
					DataRow row = gvPersonasContacto.GetDataRow(gvPersonasContacto.GetSelectedRows()[0]);
					gvPersonasContacto.CloseEditor();
					int id = 0;
					int.TryParse(row["id"].ToString(), out id);

					Socio.PersonaContacto persona_contacto = new Socio.PersonaContacto();

					if (id != 0)
						persona_contacto = Socio.PersonaContacto.Obtener(id);

					persona_contacto.codigo = Socio.PersonaContacto.ObtenerSiguienteCodigo();
					persona_contacto.genero = char.Parse(row["genero"].ToString());
					persona_contacto.socio_id = socio.id;
					persona_contacto.nombre = socio.codigo;
					persona_contacto.nombre_persona = row["nombre_persona"].ToString();
					persona_contacto.titulo = row["titulo"].ToString();
					persona_contacto.posicion = row["posicion"].ToString();
					persona_contacto.direccion = row["direccion"].ToString();
					persona_contacto.telefono = row["telefono"].ToString();
					persona_contacto.celular = row["celular"].ToString();
					persona_contacto.correo = row["correo"].ToString();
					persona_contacto.observaciones = row["observaciones"].ToString();
					persona_contacto.activo = (row["activo"].IsNullOrEmpty() ? true : (bool)row["activo"]);

					if (Program.Nori.Estacion.lector_huella)
					{
						string mensaje = (persona_contacto.huella_digital.IsNullOrEmpty()) ? "¿Desea agregar una huella digital?" : "¿Desea actualizar la huella digital existente?";
						if (MessageBox.Show(mensaje, Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
						{
							HuellaDigital.frmHuellaDigitalAgregar f = new HuellaDigital.frmHuellaDigitalAgregar();
							var result = f.ShowDialog();
							if (result == DialogResult.OK)
								persona_contacto.huella_digital = f.huella_digital;
						}
					}

					if (persona_contacto.id != 0)
					{
						if (!persona_contacto.Actualizar())
							MessageBox.Show(NoriSDK.Nori.ObtenerUltimoError().Message);
					}
					else
					{
						if (!persona_contacto.Agregar())
							MessageBox.Show(NoriSDK.Nori.ObtenerUltimoError().Message);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				finally
				{
					CargarPersonasContacto();
				}
			}
		}

		private void cbTipo_EditValueChanged(object sender, EventArgs e)
		{
			CargarGruposSocios();
		}

		private void cbPaises_EditValueChanged(object sender, EventArgs e)
		{
			try
			{
				(cbEstados.Properties.DataSource as DataTable).DefaultView.RowFilter = string.Format("pais_id = '{0}'", (int)cbPaises.EditValue);
			}
			catch { }
		}

		private void bbiDocumentosVencidos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (socio.DocumentosVencidos())
				MessageBox.Show("Este socio tiene documentos vencidos.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			else
				MessageBox.Show("Este socio NO tiene documentos vencidos.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void bbiMonedero_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			frmMonederos f = new frmMonederos(socio.id);
			f.Show();
		}

		private void cbDirecciones_EditValueChanged(object sender, EventArgs e)
		{
			try
			{
				direccion = Socio.Direccion.Obtener((int)cbDirecciones.EditValue);
				CargarDireccion();
			}
			catch { }
		}

		private void CargarDireccion(bool nueva = false)
		{
			try
			{
				if (nueva)
					cbDirecciones.EditValue = 0;

				lblDireccionID.Text = direccion.id.ToString();
				cbTipoDireccion.EditValue = direccion.tipo;
				cbImpuestos.EditValue = direccion.impuesto_id;
				txtNombreDireccion.Text = direccion.nombre;
				txtCalle.Text = direccion.calle;
				txtNumeroExterior.Text = direccion.numero_exterior;
				txtNumeroInterior.Text = direccion.numero_interior;
				txtCP.Text = direccion.cp;
				txtColonia.Text = direccion.colonia;
				txtCiudad.Text = direccion.ciudad;
				txtMunicipio.Text = direccion.municipio;
				cbPaises.EditValue = direccion.pais_id;
				cbEstados.EditValue = direccion.estado_id;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private bool GuardarDireccion()
		{
			try
			{
				if (direccion.id == 0)
				{
					direccion.socio_id = socio.id;
					direccion.tipo = (char)cbTipoDireccion.EditValue;
					direccion.impuesto_id = direccion.impuesto_id;
				}

				direccion.nombre = txtNombreDireccion.Text;
				direccion.calle = txtCalle.Text;
				direccion.numero_exterior = txtNumeroExterior.Text;
				direccion.numero_interior = txtNumeroInterior.Text;
				direccion.cp = txtCP.Text;
				direccion.colonia = txtColonia.Text;
				direccion.ciudad = txtCiudad.Text;
				direccion.municipio = txtMunicipio.Text;
				direccion.estado_id = (int)cbEstados.EditValue;
				direccion.pais_id = (int)cbPaises.EditValue;

				return (direccion.id == 0) ? direccion.Agregar() : direccion.Actualizar();
			}
			catch { return false; }
		}

		private void btnNuevaDireccion_Click(object sender, EventArgs e)
		{
			CargarDireccion(true);
		}

		private void btnGuardarDireccion_Click(object sender, EventArgs e)
		{
			if (GuardarDireccion()) { Guardar(); } else { MessageBox.Show("Error al guardar: " + NoriSDK.Nori.ObtenerUltimoError().Message, Text); };
			CargarDirecciones();
		}

		private void lblBalance_Click(object sender, EventArgs e)
		{
			try
			{
				DataTable balance = Utilidades.EjecutarQuery(string.Format("select numero_documento No, numero_documento_externo NoSAP, fecha_documento Fecha, fecha_vencimiento Vencimiento, total Total, importe_aplicado Aplicado, (total - importe_aplicado) Saldo from documentos where (total - importe_aplicado) > 0.1 and clase in ('FA', 'NC', 'ND') and socio_id = {0}", socio.id));
				if (balance.Rows.Count > 0)
				{
					frmResultadosBusqueda f = new frmResultadosBusqueda(balance);
					f.Text = string.Format("Balance del socio {0}", socio.codigo);
					var result = f.ShowDialog();
				}
			}
			catch { }
		}

		private void lblPropietarios_Click(object sender, EventArgs e)
		{
			frmPropietarios f = new frmPropietarios();
			f.ShowDialog();
			CargarListas();
		}

		private void lblRuta_Click(object sender, EventArgs e)
		{
			frmRutas f = new frmRutas();
			f.ShowDialog();
			CargarListas();
		}
	}
}
