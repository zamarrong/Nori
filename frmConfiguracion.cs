using DevExpress.XtraBars;
using NoriSDK;
using System;
using System.Windows.Forms;

namespace Nori
{
	public partial class frmConfiguracion : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		Configuracion configuracion = Configuracion.Obtener();
		Configuracion.SAP sap = Configuracion.SAP.Obtener();

		public frmConfiguracion()
		{
			InitializeComponent();
			this.MetodoDinamico();

			Cargar();
			CargarListas();
		}

		private void Cargar()
		{
			cbFormularioPanel.Checked = configuracion.formulario_panel;
			cbVentaArticuloPrecioCero.Checked = configuracion.venta_articulo_precio_cero;
			cbVentaArticuloMenorCosto.Checked = configuracion.venta_precio_menor_costo;
			cbVentaArticuloStockCero.Checked = configuracion.venta_articulo_stock_cero;
			cbDocumentoBorrador.Checked = configuracion.documento_borrador;
			cbAgruparPartidas.Checked = configuracion.agrupar_partidas;
			cbVendedorSegunUsuario.Checked = configuracion.vendedor_segun_usuario;
            cbListaPrecioSegunUsuario.Checked = configuracion.lista_precio_segun_usuario;
			cbGenerarDocumentoElectronicoAutomaticamente.Checked = configuracion.generar_documento_electronico_automaticamente;
			cbVendedorSegunEstacion.Checked = configuracion.vendedor_segun_estacion;
			cbDocumentosModoNuevo.Checked = configuracion.documentos_modo_nuevo;
			cbSeleccionarSucursal.Checked = configuracion.seleccionar_sucursal;
			cbTiposMetodosPago.EditValue = configuracion.tipo_metodo_pago_monedero_id;
			txtAPIURL.Text = configuracion.api_url;

			try
			{
				ceTema.Color = System.Drawing.Color.FromArgb(Convert.ToInt32(configuracion.tema));
			} catch { }

			cbPAC.SelectedIndex = configuracion.pac;
			txtTimbradoUsuario.EditValue = configuracion.timbrado_usuario;
			txtTimbradoContraseña.EditValue = configuracion.timbrado_contraseña;
			cbTimbradoModoPrueba.Checked = configuracion.timbrado_modo_prueba;
            cbPedimentos.Checked = configuracion.pedimentos;

			txtDirectorioInformes.Text = configuracion.directorio_informes;
			txtDirectorioDocumentos.Text = configuracion.directorio_documentos;
			txtDirectorioImagenes.Text = configuracion.directorio_imagenes;
			txtDirectorioXML.Text = configuracion.directorio_xml;
			txtDirectorioHuellas.Text = configuracion.directorio_huellas;
			txtDirectorioAnexos.Text = configuracion.directorio_anexos;
			cbDiasSemana.SelectedIndex = configuracion.dia_semana;

			gbSAP.Visible = cbSAP.Checked = configuracion.sap;
			cbSAP.Enabled = !cbSAP.Checked;
			cbInventarioSAP.Checked = configuracion.inventario_sap;

			txtServidor.Text = sap.servidor;
			txtServidorLicencias.Text = sap.servidor_licencias;
			cbTipoServidorBD.SelectedIndex = sap.tipo_servidor_bd - 1;
			txtBD.Text = sap.bd;
			txtUsuarioBD.Text = sap.usuario_bd;
			txtContraseñaBD.Text = sap.contraseña_bd;
			txtUsuario.Text = sap.usuario;
			txtContraseña.Text = sap.contraseña;
			cbConfiable.Checked = sap.confiable;

			cbGenerarAjusteInventario.Checked = sap.generar_ajuste_inventario;
			txtNumeroCuentaAjusteInventario.Text = sap.numero_cuenta_ajuste_inventario;
			cbFacturarEntregas.Checked = sap.facturar_entregas;
			txtSAPAPIURL.Text = sap.api_url;

			teHoraSincronizacionGenerales.Time = new DateTime(sap.hora_sincronizacion_general.Ticks);
		}

		private void CargarListas()
		{
			object p = new { fields = "id, codigo, nombre" };
			object o = new { activo = 1 };

			cbCondicionesPago.Properties.DataSource = Utilidades.Busqueda("condiciones_pago", o, p);
			cbCondicionesPago.Properties.ValueMember = "id";
			cbCondicionesPago.Properties.DisplayMember = "nombre";
			cbCondicionesPago.EditValue = configuracion.condicion_pago_id;

			cbFabricantes.Properties.DataSource = Utilidades.Busqueda("fabricantes", o, p);
			cbFabricantes.Properties.ValueMember = "id";
			cbFabricantes.Properties.DisplayMember = "nombre";
			cbFabricantes.EditValue = configuracion.fabricante_id;

			cbMetodosPago.Properties.DataSource = Utilidades.Busqueda("metodos_pago", o, p);
			cbMetodosPago.Properties.ValueMember = "id";
			cbMetodosPago.Properties.DisplayMember = "nombre";
			cbMetodosPago.EditValue = configuracion.metodo_pago_id;

			cbGruposArticulos.Properties.DataSource = Utilidades.Busqueda("grupos_articulos", o, p);
			cbGruposArticulos.Properties.ValueMember = "id";
			cbGruposArticulos.Properties.DisplayMember = "nombre";
			cbGruposArticulos.EditValue = configuracion.grupo_articulo_id;

			cbImpuestos.Properties.DataSource = Utilidades.Busqueda("impuestos", null, p);
			cbImpuestos.Properties.ValueMember = "id";
			cbImpuestos.Properties.DisplayMember = "nombre";
			cbImpuestos.EditValue = configuracion.impuesto_id;

			cbMonedas.Properties.DataSource = Utilidades.Busqueda("monedas", o, p);
			cbMonedas.Properties.ValueMember = "id";
			cbMonedas.Properties.DisplayMember = "nombre";
			cbMonedas.EditValue = configuracion.moneda_id;

			cbZonas.Properties.DataSource = Utilidades.Busqueda("zonas", o, p);
			cbZonas.Properties.ValueMember = "id";
			cbZonas.Properties.DisplayMember = "nombre";
			cbZonas.EditValue = configuracion.zona_id;

			p = new { fields = "id, nombre" };

			cbCertificados.Properties.DataSource = Utilidades.Busqueda("certificados", o, p);
			cbCertificados.Properties.ValueMember = "id";
			cbCertificados.Properties.DisplayMember = "nombre";
			cbCertificados.EditValue = configuracion.certificado_id;

			cbTiposMetodosPago.Properties.DataSource = Utilidades.Busqueda("tipos_metodos_pago", o, p);
			cbTiposMetodosPago.Properties.ValueMember = "id";
			cbTiposMetodosPago.Properties.DisplayMember = "nombre";
			cbTiposMetodosPago.EditValue = configuracion.tipo_metodo_pago_monedero_id;

			cbListasPrecios.Properties.DataSource = Utilidades.Busqueda("listas_precios", o, p);
			cbListasPrecios.Properties.ValueMember = "id";
			cbListasPrecios.Properties.DisplayMember = "nombre";
			cbListasPrecios.EditValue = configuracion.lista_precio_id;

			cbDepartamentos.Properties.DataSource = Utilidades.Busqueda("departamentos", o, p);
			cbDepartamentos.Properties.ValueMember = "id";
			cbDepartamentos.Properties.DisplayMember = "nombre";
			cbDepartamentos.EditValue = configuracion.departamento_id;
		}

		private void Llenar()
		{
			configuracion.formulario_panel = cbFormularioPanel.Checked;
			configuracion.venta_articulo_precio_cero = cbVentaArticuloPrecioCero.Checked;
			configuracion.venta_precio_menor_costo = cbVentaArticuloMenorCosto.Checked;
			configuracion.venta_articulo_stock_cero = cbVentaArticuloStockCero.Checked;
			configuracion.documento_borrador = cbDocumentoBorrador.Checked;
			configuracion.agrupar_partidas = cbAgruparPartidas.Checked;
			configuracion.vendedor_segun_usuario = cbVendedorSegunUsuario.Checked;
            configuracion.lista_precio_segun_usuario = cbListaPrecioSegunUsuario.Checked;
			configuracion.vendedor_segun_estacion = cbVendedorSegunEstacion.Checked;
			configuracion.documentos_modo_nuevo = cbDocumentosModoNuevo.Checked;
			configuracion.generar_documento_electronico_automaticamente = cbGenerarDocumentoElectronicoAutomaticamente.Checked;
			configuracion.seleccionar_sucursal = cbSeleccionarSucursal.Checked;
			configuracion.tipo_metodo_pago_monedero_id = (cbTiposMetodosPago.EditValue.IsNullOrEmpty()) ? 0 : (int)cbTiposMetodosPago.EditValue;
			configuracion.api_url = txtAPIURL.Text;
			configuracion.tema = ceTema.Color.ToArgb().ToString();

			configuracion.certificado_id = (cbCertificados.EditValue.IsNullOrEmpty()) ? 0 : (int)cbCertificados.EditValue;
            configuracion.pedimentos = cbPedimentos.Checked;

			if (configuracion.certificado_id != 0)
			{
				configuracion.pac = cbPAC.SelectedIndex;
				configuracion.timbrado_usuario = txtTimbradoUsuario.EditValue.ToString();
				configuracion.timbrado_contraseña = txtTimbradoContraseña.EditValue.ToString();
				configuracion.timbrado_modo_prueba = cbTimbradoModoPrueba.Checked;
			}

			configuracion.directorio_informes = txtDirectorioInformes.Text;
			configuracion.directorio_documentos = txtDirectorioDocumentos.Text;
			configuracion.directorio_imagenes = txtDirectorioImagenes.Text;
			configuracion.directorio_xml = txtDirectorioXML.Text;
			configuracion.directorio_huellas = txtDirectorioHuellas.Text;
			configuracion.directorio_anexos = txtDirectorioAnexos.Text;
			configuracion.dia_semana = cbDiasSemana.SelectedIndex;
			configuracion.sap = cbSAP.Checked;
			configuracion.inventario_sap = cbInventarioSAP.Checked;

			configuracion.condicion_pago_id = (cbCondicionesPago.EditValue.IsNullOrEmpty()) ? 0 : (int)cbCondicionesPago.EditValue;
			configuracion.departamento_id = (cbDepartamentos.EditValue.IsNullOrEmpty()) ? 0 : (int)cbDepartamentos.EditValue;
			configuracion.fabricante_id = (cbFabricantes.EditValue.IsNullOrEmpty()) ? 0 : (int)cbFabricantes.EditValue;
			configuracion.grupo_articulo_id = (cbGruposArticulos.EditValue.IsNullOrEmpty()) ? 0 : (int)cbGruposArticulos.EditValue;
			configuracion.impuesto_id = (cbImpuestos.EditValue.IsNullOrEmpty()) ? 0 : (int)cbImpuestos.EditValue;
			configuracion.metodo_pago_id = (cbMetodosPago.EditValue.IsNullOrEmpty()) ? 0 : (int)cbMetodosPago.EditValue;
			configuracion.lista_precio_id = (cbListasPrecios.EditValue.IsNullOrEmpty()) ? 0 : (int)cbListasPrecios.EditValue;
			configuracion.moneda_id = (cbMonedas.EditValue.IsNullOrEmpty()) ? 0 : (int)cbMonedas.EditValue;
			configuracion.zona_id = (cbZonas.EditValue.IsNullOrEmpty()) ? 0 : (int)cbZonas.EditValue;

			sap.servidor = txtServidor.Text;
			sap.servidor_licencias = txtServidorLicencias.Text;
			sap.tipo_servidor_bd = cbTipoServidorBD.SelectedIndex + 1;
			sap.bd = txtBD.Text;
			sap.usuario_bd = txtUsuarioBD.Text;
			sap.contraseña_bd = txtContraseñaBD.Text;
			sap.usuario = txtUsuario.Text;
			sap.contraseña = txtContraseña.Text;
			sap.confiable = cbConfiable.Checked;

			sap.generar_ajuste_inventario = cbGenerarAjusteInventario.Checked;
			sap.numero_cuenta_ajuste_inventario = txtNumeroCuentaAjusteInventario.Text;
			sap.facturar_entregas = cbFacturarEntregas.Checked;
			sap.api_url = txtSAPAPIURL.Text;

			sap.hora_sincronizacion_general = teHoraSincronizacionGenerales.Time.TimeOfDay;
		}

		private bool Guardar()
		{
			try
			{
				if (MessageBox.Show("¿Desea guardar los cambios?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					Llenar();
					if (configuracion.id != 0)
						configuracion.Actualizar();
					if (sap.id != 0)
						sap.Actualizar();

					MessageBox.Show("Es necesario reiniciar el programa para que los cambios surtan efecto.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

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

		private void bbiGuardar_ItemClick(object sender, ItemClickEventArgs e)
		{
			Guardar();
		}

		private void cbSAP_CheckedChanged(object sender, EventArgs e)
		{
			gbSAP.Visible = cbSAP.Checked;
		}

		private void txtDirectorioDocumentos_DoubleClick(object sender, EventArgs e)
		{
			using (var fbd = new FolderBrowserDialog())
			{
				DialogResult result = fbd.ShowDialog();

				if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
				{
					DevExpress.XtraEditors.TextEdit te = (DevExpress.XtraEditors.TextEdit)sender;
					te.Text = fbd.SelectedPath;
				}
			}
		}

		private void btnCertificados_Click(object sender, EventArgs e)
		{
			frmCertificados f = new frmCertificados();
			f.ShowDialog();
		}

		private void lblSucursales_Click(object sender, EventArgs e)
		{
			frmSucursales f = new frmSucursales();
			f.ShowDialog();
		}
	}
}