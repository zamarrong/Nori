using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using NoriSAPB1SDK;
using NoriSDK;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nori.PuntoVenta
{
    public partial class frmPuntoVenta : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        Documento documento = new Documento();
        Socio socio = new Socio();
        Moneda moneda = new Moneda();
        List<UnidadMedida> unidades_medida = new List<UnidadMedida>();
        public frmPuntoVenta()
        {
            InitializeComponent();
            this.MetodoDinamico();

            ribbonControl1.Manager.UseAltKeyForMenu = false;
            gvPartidas.OptionsSelection.EnableAppearanceFocusedCell = false;
            gvPartidas.OptionsSelection.EnableAppearanceFocusedRow = false;
            gvPartidas.OptionsSelection.EnableAppearanceHideSelection = false;

            if (Program.Nori.UsuarioAutenticado.rol.Equals('C'))
                bbiCortesCaja.Enabled = false;

            lblEstacion.Caption = Program.Nori.Estacion.nombre;
            lblUsuario.Caption = Program.Nori.UsuarioAutenticado.nombre;

            pbLogo.LoadImage(Program.Nori.Empresa.logotipo);

            CargarListas();
            CargarGruposArticulos();
            Inicializar();
        }

        private void Cargar()
        {
            if (documento.socio_id == 0)
                MessageBox.Show("No esta definido el socio de negocio predeterminado");
            else
                socio = Socio.Obtener(documento.socio_id);

            txtCodigoSN.Text = socio.codigo;
            lblSocio.Text = socio.nombre;
            lblEstadoCredito.Text = string.Format("Límite de crédito: {0} | Disponible: {1}", socio.limite_credito.ToString("c2"), (socio.limite_credito - socio.balance).ToString("c2"));

            if (socio.DocumentosVencidos())
                lblEstadoCredito.ForeColor = Color.Firebrick;
            else
                lblEstadoCredito.ForeColor = Color.DimGray;

            lblVendedor.EditValue = documento.vendedor_id;

            if (documento.clase == "FA")
            {
                cbFactura.Checked = true;
                cbReserva.Checked = documento.reserva;
            }

            Calcular();
        }

        private void CargarListas()
        {
            try
            {
                object p = new { fields = "id, nombre" };
                object o = new { activo = 1 };

                cbVendedores.DataSource = Utilidades.Busqueda("vendedores", o, p);
                cbVendedores.ValueMember = "id";
                cbVendedores.DisplayMember = "nombre";
                lblVendedor.EditValue = Program.Nori.UsuarioAutenticado.vendedor_id;

                cbTiposEmpaques.DataSource = Utilidades.Busqueda("tipos_empaques", o, p);
                cbTiposEmpaques.ValueMember = "id";
                cbTiposEmpaques.DisplayMember = "nombre";

                unidades_medida = UnidadMedida.UnidadesMedida().Where(x => x.activo == true).ToList();
                cbUnidadesMedida.DataSource = unidades_medida;
                cbUnidadesMedida.ValueMember = "id";
                cbUnidadesMedida.DisplayMember = "nombre";

                cbAlmacenes.DataSource = Almacen.Almacenes().Where(x => x.activo == true).Select(x => new { x.id, x.codigo, x.nombre });
                cbAlmacenes.ValueMember = "id";
                cbAlmacenes.DisplayMember = "codigo";

                moneda = Moneda.Obtener(documento.moneda_id);
                lblMoneda.Caption = moneda.nombre;

                pbImagen.Image = null;
                lblArticuloComentarios.Text = "";
            } catch { }
        }

        private void CargarPersonasContacto()
        {
            try
            {
                cbPersonasContacto.Properties.DataSource = Socio.PersonaContacto.PersonasContacto().Where(x => x.socio_id == documento.socio_id && x.activo == true).Select(x => new { x.id, x.nombre, x.nombre_persona }).ToList();
                cbPersonasContacto.Properties.ValueMember = "id";
                cbPersonasContacto.Properties.DisplayMember = "nombre_persona";
                cbPersonasContacto.EditValue = documento.persona_contacto_id;
            } catch { }
        }

        private void BuscarSocios(string q)
        {
            try
            {
                string query = string.Format("SELECT id, codigo Código, nombre Nombre, rfc RFC, (SELECT direccion FROM BloqueDireccion(direccion_facturacion_id)) AS 'Dirección de facturación' FROM socios WHERE codigo like '%{0}%' OR nombre LIKE '%{0}%' AND tipo = 'C' AND activo = 1", q.Replace(" ", "%"));
                DataTable socios = Utilidades.EjecutarQuery(query);

                if (socios.Rows.Count > 0)
                {
                    if (socios.Rows.Count == 1)
                    {
                        socio = Socio.Obtener((int)socios.Rows[0]["id"]);
                        if (socio.orden_compra)
                            OrdenCompra();
                    }
                    else
                    {
                        frmResultadosBusqueda f = new frmResultadosBusqueda(socios);
                        var result = f.ShowDialog();
                        if (result == DialogResult.OK)
                            socio = Socio.Obtener(f.id);
                        if (socio.orden_compra)
                            OrdenCompra();
                    }

                    Cursor = Cursors.WaitCursor;
                    EstablecerSocio(socio);
                    Cursor = Cursors.Default;
                }
                else
                    MessageBox.Show(string.Format("No se encontraron resultados para {0}", q), Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void AgregarPartida(string q)
        {
            try
            {
                Buscar:
                if (documento.AgregarPartida(q))
                {
                    txtArticulo.Text = string.Empty;
                    gvPartidas.MoveLast();
                    Calcular();
                    await Task.Run(() => pbImagen.LoadImage(Articulo.ObtenerImagen(documento.partidas.Last().articulo_id)));
                    lblArticuloComentarios.Text = Articulo.ObtenerComentario(documento.partidas.Last().articulo_id);
                }
                else
                    if (MessageBox.Show(NoriSDK.Nori.ObtenerUltimoError().Message, Text, MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                    goto Buscar;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                txtArticulo.Text = string.Empty;
                txtArticulo.Focus();
            }
        }

        private void Calcular()
        {
            try
            {
                gcPartidas.DataSource = documento.partidas;
                gcPartidas.RefreshDataSource();

                documento.CalcularTotal();

                lblPartidas.Caption = string.Format("Partidas {0}", documento.numero_partidas);
                lblArticulos.Caption = string.Format("Artículos {0}", documento.cantidad_partidas);
                lblCantidadEmpaque.Caption = string.Format("Cantidad empaque {0}", documento.cantidad_empaque);

                lblDescuento.Text = documento.descuento.ToString("C");

                lblTotal.Text = documento.total.ToString("C");
            } catch { }
        }

        private void txtCodigoSN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtCodigoSN.Text.Length > 0)
            {
                try
                {
                    socio = Socio.Socios().Where(x => x.codigo == txtCodigoSN.Text).First();
                    EstablecerSocio(socio);
                }
                catch
                {
                    MessageBox.Show("No se encontraron resultados.");
                }
            }

            if (e.Control && e.KeyCode == Keys.S)
            {
                frmAltaRapidaSocio f = new frmAltaRapidaSocio();
                if (f.ShowDialog() == DialogResult.OK)
                {
                    socio = Socio.Obtener(Socio.Socios().OrderByDescending(x => x.id).Select(x => x.id).First());
                    EstablecerSocio(socio);
                }
            }

            if (e.Control && e.KeyCode == Keys.E)
            {
                frmAltaRapidaSocioEventual f = new frmAltaRapidaSocioEventual();
                if (f.ShowDialog() == DialogResult.OK)
                {
                    socio = Socio.Obtener(Socio.Socios().OrderByDescending(x => x.id).Select(x => x.id).First());
                    EstablecerSocio(socio);
                }
            }
        }

        private void txtCodigoSN_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab && txtCodigoSN.Text.Length > 0)
                BuscarSocios(txtCodigoSN.Text);
        }

        private void txtArticulo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtArticulo.Text.Length > 0)
                AgregarPartida(txtArticulo.Text);
        }
        private void txtArticulo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
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

                Autorizacion autorizacion = new Autorizacion();

                autorizacion.codigo = "BSQDA";
                autorizacion.referencia = q;
                //autorizacion.comentario = Microsoft.VisualBasic.Interaction.InputBox("Comentario búsqueda de artículo (Opcional)", "");

                autorizacion.Agregar();

                if (!autorizacion.autorizado)
                {
                    frmSolicitarAutorizacion fa = new frmSolicitarAutorizacion(autorizacion);
                    fa.ShowDialog();
                    autorizacion.autorizado = (fa.DialogResult == DialogResult.OK) ? true : false;
                }

                if (autorizacion.autorizado)
                {
                    //SELECT articulos.id, sku as sku_articulo, articulos.nombre, (SELECT SUM(stock) FROM inventario WHERE articulo_id = articulos.id), (SELECT dbo.[PrecioNetoArticulo](articulo_id, " + documento.socio_id + ", " + documento.lista_precio_id + ")) AS precio, monedas.codigo as moneda FROM articulos JOIN precios ON precios.articulo_id = articulos.id JOIN monedas ON monedas.id = precios.moneda_id AND precios.lista_precio_id = " + Program.Nori.Configuracion.lista_precio_id + "  WHERE sku = '" + q + "' OR articulos.nombre LIKE '%" + q.Replace(" ", "%") + "%' OR codigo_barras LIKE '%" + q + "%' AND venta = 1 AND articulos.activo = 1;
                    ConsultaPersonalizada consulta = ConsultaPersonalizada.Obtener("txtArticulo");

                    if (consulta.query.IsNullOrEmpty())
                        consulta.query = "SELECT articulos.id, sku as sku_articulo, articulos.nombre, (SELECT SUM(stock) FROM inventario WHERE articulo_id = articulos.id) stock, precios.precio, monedas.codigo as moneda FROM articulos JOIN precios ON precios.articulo_id = articulos.id JOIN monedas ON monedas.id = precios.moneda_id AND precios.lista_precio_id = {lista_precio_id} WHERE (sku = '{q}' OR articulos.nombre LIKE '%{q}%' OR codigo_barras LIKE '%{q}%') AND venta = 1 AND articulos.activo = 1 ORDER BY articulos.nombre";
                    
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

                            txtArticulo.Text = string.Empty;
                            txtArticulo.Focus();

                            if (result == DialogResult.OK)
                            {
                                Cursor = Cursors.WaitCursor;
                                f.filas.ForEach(x => documento.AgregarPartida(string.Format("{0}*{1}", cantidad, articulos.Rows[x][1].ToString())));
                                Calcular();
                                Cursor = Cursors.Default;
                            }
                        }
                    }
                    else
                        MessageBox.Show(string.Format("No se encontraron resultados para {0}", q), Text);
                }
            }
        }
        private void frmPuntoVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void ribbonControl1_ApplicationButtonClick(object sender, EventArgs e)
        {
            FormClosing -= new FormClosingEventHandler(frmPuntoVenta_FormClosing);
            Close();
        }

        private void bbiNuevo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Nuevo();
        }

        private void Nuevo()
        {
            if (MessageBox.Show("¿Estas seguro(a) de inicializar un nuevo documento?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
                Inicializar();
        }

        private void Inicializar()
        {
            try
            {
                if (NoriSDK.PuntoVenta.EstadoCaja().Equals('C'))
                {
                    if (MessageBox.Show("¿Deseas realizar una apertura de caja?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        frmIngresos f = new frmIngresos("INACA");
                        f.ShowDialog();
                        Inicializar();
                        return;
                    }
                    scPV.Enabled = false;
                }
                else
                {
                    scPV.Enabled = true;
                    txtCodigoSN.Enabled = true;
                    cbFactura.Checked = false;
                    documento = new Documento();
                    EstablecerSocio(Socio.Obtener(Program.Nori.UsuarioAutenticado.socio_id));
                    Cargar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EstablecerSocio(Socio socio)
        {
            try
            {
                if (socio.tipo == 'C')
                {
                    if (socio.activo)
                    {
                        if (socio.lista_precio_id != Program.Nori.Configuracion.lista_precio_id)
                        {
                            Autorizacion autorizacion = new Autorizacion();

                            autorizacion.codigo = "CALIP";
                            autorizacion.referencia = string.Format("Cambio de lista de precio diferente a la predeterminada al socio {0}", socio.codigo);
                            autorizacion.comentario = Microsoft.VisualBasic.Interaction.InputBox("Comentario cambio de lista (Opcional)", "");

                            autorizacion.Agregar();

                            if (!autorizacion.autorizado)
                            {
                                frmSolicitarAutorizacion fa = new frmSolicitarAutorizacion(autorizacion);
                                fa.ShowDialog();
                                autorizacion.autorizado = (fa.DialogResult == DialogResult.OK) ? true : false;
                            }

                            if (!autorizacion.autorizado)
                                socio.lista_precio_id = Program.Nori.Configuracion.lista_precio_id;
                        }

                        if (!documento.EstablecerSocio(socio))
                        {
                            MessageBox.Show(NoriSDK.Nori.ObtenerUltimoError().Message);
                            return;
                        }
                        else
                        {
                            Calcular();

                            txtCodigoSN.Text = socio.codigo;
                            lblSocio.Text = socio.nombre;
                            lblEstadoCredito.Text = string.Format("Límite de crédito: {0} | Disponible: {1}", socio.limite_credito.ToString("c2"), (socio.limite_credito - socio.balance).ToString("c2"));
                            lblVendedor.EditValue = documento.vendedor_id;

                            CargarPersonasContacto();
                        }

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

                        try
                        {
                            lblCondicionPago.Text = NoriSDK.CondicionesPago.CondicionesPagos().Where(x => x.id == socio.condicion_pago_id).Select(x => new { x.nombre }).First().nombre;
                        }
                        catch
                        {
                            lblCondicionPago.Text = string.Empty;
                            MessageBox.Show("El socio no tiene establecida la condición de pago.");
                            return;
                        }

                        txtArticulo.Text = string.Empty;
                        txtArticulo.Focus();
                    }
                    else
                    {
                        MessageBox.Show("El socio esta inactivo");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("El socio seleccionado no es del tipo cliente");
                }
            }
            catch
            {
                return;
            }
        }

        private static void Imprimir(Documento documento, short copias = 1)
        {
            try
            {
                if (Program.Nori.Estacion.impresion)
                {
                    if (MessageBox.Show("¿Desas imprimir el documento?", "Imprimir documento", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (documento.impreso && documento.id != 0)
                        {
                            Autorizacion autorizacion = new Autorizacion();

                            autorizacion.codigo = "REIMP";
                            autorizacion.referencia = string.Format("Re-impresión del documento {0}", documento.id);
                            autorizacion.comentario = Microsoft.VisualBasic.Interaction.InputBox("Comentario re-impresión (Opcional)", "");

                            autorizacion.Agregar();

                            if (!autorizacion.autorizado)
                            {
                                frmSolicitarAutorizacion fa = new frmSolicitarAutorizacion(autorizacion);
                                fa.ShowDialog();
                                autorizacion.autorizado = (fa.DialogResult == DialogResult.OK) ? true : false;
                            }

                            if (autorizacion.autorizado)
                                Funciones.ImprimirInformePredeterminado(documento.clase, documento.id);

                            documento.Impreso();
                        }
                        else if (!documento.impreso && documento.id != 0)
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
                }

                if (Program.Nori.Estacion.envio_correo_automatico)
                {
                    string correo = null;
                    if (Program.Nori.UsuarioAutenticado.socio_id == documento.socio_id)
                    {
                        correo = Microsoft.VisualBasic.Interaction.InputBox("Ingresa el correo(s) electrónico del cliente separados por ;", "Correo electrónico", "");
                    }

                    Funciones.EnviarDocumentoAsync(documento.id, correo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Documentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                txtArticulo.Text = string.Empty;
                txtArticulo.Focus();
            }
        }

        public void Comentario()
        {
            try
            {
                string comentario = Microsoft.VisualBasic.Interaction.InputBox("Ingresa un comentario.", "Comentario", documento.comentario);
                if (comentario.Length <= 0 && documento.reserva)
                {
                    MessageBox.Show("El comentario es obligatorio.");
                    Comentario();
                }
                if (comentario.Length <= 254)
                    documento.comentario = comentario;
                else
                    MessageBox.Show("El comentario no puede exceder los 254 caracteres.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Guardar()
        {
            try
            {
                if (documento.id == 0)
                {
                    if (documento.clase.Equals("DV") || documento.clase.Equals("NC"))
                    {
                        if (MessageBox.Show("¿Estas seguro(a) de guardar el documento?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            documento.persona_contacto_id = (cbPersonasContacto.EditValue.IsNullOrEmpty()) ? 0 : (int)cbPersonasContacto.EditValue;
                            documento.vendedor_id = (int)lblVendedor.EditValue;
                            documento.generar_documento_electronico = documento.GenerarDocumentoElectronico();

                            if (documento.Agregar())
                            {
                                if (documento.generar_documento_electronico)
                                    Funciones.TimbrarDocumento(documento);
                                Imprimir(documento);

                                //if (documento.clase.Equals("DV"))
                                //{
                                //    Flujo flujo = new Flujo();

                                //    flujo.codigo = "RERET";
                                //    flujo.importe = documento.total;
                                //    flujo.documento_id = documento.id;

                                //    flujo.Agregar();
                                //}

                                Inicializar();
                            }
                            else
                                MessageBox.Show(NoriSDK.Nori.ObtenerUltimoError().Message);
                        }
                    }
                    else
                    {
                        if (documento.reserva)
                            Comentario();

                        frmMediosPago f = new frmMediosPago(documento, socio);

                        if (f.ShowDialog() == DialogResult.OK)
                        {
                            if (MessageBox.Show("¿Estas seguro(a) de guardar el documento?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                if (cbFactura.Checked)
                                    documento.clase = "FA";

                                documento.persona_contacto_id = (cbPersonasContacto.EditValue.IsNullOrEmpty()) ? 0 : (int)cbPersonasContacto.EditValue;
                                documento.vendedor_id = (int)lblVendedor.EditValue;
                                documento.generar_documento_electronico = documento.GenerarDocumentoElectronico();

                                if (!VerificarExistencias())
                                    return;

                                if (documento.flujo.Count > 0)
                                {
                                    if (documento.Agregar())
                                    {
                                        if (documento.generar_documento_electronico)
                                            Funciones.TimbrarDocumento(documento);
                                        Imprimir(documento);
                                        Inicializar();
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
                                        #region SepararDocumento
                                        //List<Documento> documentos = Documento.SepararDocumento(documento);

                                        //foreach (Documento documento in documentos)
                                        //{
                                        //    if (documento.generar_documento_electronico)
                                        //        Funciones.TimbrarDocumento(documento);
                                        //    Imprimir(documento, 2);
                                        //}
                                        #endregion

                                        if (documento.Agregar())
                                        {
                                            if (documento.generar_documento_electronico)
                                                Funciones.TimbrarDocumento(documento);
                                            Imprimir(documento, 2);
                                            Inicializar();
                                        }
                                        else
                                            MessageBox.Show(NoriSDK.Nori.ObtenerUltimoError().Message);
                                    }

                                    Inicializar();
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Este documento ya ha sido guardado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool VerificarExistencias()
        {
            try
            {
                if ((documento.clase.Equals("EN") || documento.clase.Equals("FA") || documento.clase.Equals("TS") || (documento.clase.Equals("PE")) && Program.Nori.Empresa.rfc.Equals("CVR981030480")))
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

        private void Buscar()
        {
            try
            {
                var docs = (Documento.Documentos().Where(x => x.socio_id == documento.socio_id && x.clase == documento.clase && x.reserva == documento.reserva).OrderByDescending(x => x.fecha_creacion)).Select(x => new { x.id, No = x.numero_documento, Total = x.total, Aplicado = x.importe_aplicado, Saldo = x.total - x.importe_aplicado, Estado = x.estado, Fecha = x.fecha_documento, Vencimiento = x.fecha_vencimiento, COD = x.cod, Reserva = x.reserva});
                DataTable documentos = docs.ToList().ToDataTable();
                if (documentos.Rows.Count > 0)
                {
                    if (documentos.Rows.Count == 1)
                    {
                        documento = Documento.Obtener((int)documentos.Rows[0]["id"]);
                        Cargar();
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
            catch { }
        }

        private void BuscarReservas()
        {
            try
            {
                DataTable documentos = Utilidades.EjecutarQuery("SELECT documentos.id, numero_documento 'Numero documento', socios.nombre Nombre, total Total, importe_aplicado 'Importe aplicado', (total - importe_aplicado) Saldo, fecha_documento Fecha, fecha_vencimiento Vencimiento, comentario Comentario FROM documentos JOIN socios on socios.id = documentos.socio_id WHERE estado = 'A' AND clase = 'FA' AND reserva = 1");
                if (documentos.Rows.Count > 0)
                {
                    frmResultadosBusqueda f = new frmResultadosBusqueda(documentos);
                    f.Text = "Búsqueda de facturas de reserva";
                    var result = f.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        documento = Documento.Obtener(f.id);
                        Cargar();
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron resultados", Text);
                }
            }
            catch { }
        }

        private void bbiGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Guardar();
        }

        private void frmPuntoVenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.A)
                txtArticulo.Focus();

            if (e.Alt && e.KeyCode == Keys.S)
                txtCodigoSN.Focus();

            if (e.Alt && e.KeyCode == Keys.P)
                gvPartidas.Focus();

            if (e.KeyCode == Keys.F3)
                new frmDocumentos("EN").Show();

            if (e.KeyCode == Keys.F4)
                new frmDocumentos("DV").Show();

            if (e.KeyCode == Keys.F5)
                new frmDocumentos("FA").Show();

            if (e.KeyCode == Keys.F6)
                new frmDocumentos("NC").Show();

            if (e.KeyCode == Keys.F8)
                new frmDocumentos("AE").Show();
        }

        private void CopiarDe(bool todos = false)
        {
            try
            {
                var docs = (todos) ? (Documento.Documentos().Where(x => x.fecha_documento == DateTime.Today && (x.clase == "PE" || (x.clase == "FA" && x.reserva == true)) && x.estado == 'A' && x.cancelado == false).OrderByDescending(x => x.fecha_creacion)).Select(x => new { ID = x.id, Clase = x.clase, No = x.numero_documento, CodigoSN = x.codigo_sn, Total = x.total, Aplicado = x.importe_aplicado, Estado = x.estado, Fecha = x.fecha_documento }) : (Documento.Documentos().Where(x => x.socio_id == documento.socio_id && (x.clase == "PE" || (x.clase == "FA" && x.reserva == true)) && x.estado == 'A' && x.cancelado == false).OrderByDescending(x => x.fecha_creacion)).Select(x => new { ID = x.id, Clase = x.clase,  No = x.numero_documento, CodigoSN = x.codigo_sn, Total = x.total, Aplicado = x.importe_aplicado, Estado = x.estado, Fecha = x.fecha_documento });
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
                            txtCodigoSN.Enabled = false;
                            Cargar();
                        }
                        else
                        {
                            documento.CopiarDe(Documento.Obtener(f.ids[0]), documento.clase, true);
                            documento.descuento = documento.porcentaje_descuento = 0;
                            documento.partidas.ForEach(x => { x.CalcularTotal(); x.ObtenerStock(); });
                            txtCodigoSN.Enabled = false;
                            Cargar();
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

        private void CargarMonedero()
        {
            try
            {
                if (documento.monedero_id != 0)
                    if (MessageBox.Show("El documento ya tiene asignado un monedero, ¿desea remplazarlo?", Text, MessageBoxButtons.YesNo) != DialogResult.Yes)
                        return;

                string folio_monedero = Microsoft.VisualBasic.Interaction.InputBox("Ingresa el folio del monedero electrónico", "Monedero electrónico", "");
                documento.monedero_id = Monedero.Monederos().Where(x => x.folio == folio_monedero).Select(x => new { x.id }).First().id;
            }
            catch
            {
                MessageBox.Show("No se encontraron resultados", "Monedero electrónico");
            }
        }

        private void frmPuntoVenta_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Control && e.KeyCode == Keys.N)
                    Nuevo();

                if (e.Control && e.KeyCode == Keys.R)
                    BuscarReservas();

                if (e.Control && e.KeyCode == Keys.I)
                    CopiarDe();

                if (e.Control && e.KeyCode == Keys.T)
                    CopiarDe(true);

                if (e.Control && e.KeyCode == Keys.F)
                {
                    int documento_id = int.Parse(Microsoft.VisualBasic.Interaction.InputBox("Ingresa el ID del documento que deseas facturar", Text, "0"));
                    var documento_relacion = Documento.Obtener(documento_id);
                    if (documento.clase.Equals("EN") || documento.clase.Equals("PE") || documento.clase.Equals("CO"))
                    {
                        if (documento.estado.Equals('A'))
                        {
                            documento.CopiarDe(documento_relacion, "FA", true, true);
                            documento.descuento = documento.porcentaje_descuento = 0;
                            documento.partidas.ForEach(x => { x.CalcularTotal(); x.ObtenerStock(); });
                            Cargar();
                            cbFactura.Checked = true;
                        }
                        else
                        {
                            MessageBox.Show("El documento ya ha sido cerrado.");
                        }  
                    }
                    else
                    {
                        MessageBox.Show("No es posible facturar esta clase de documento.");
                    }
                }

                if (e.Alt && e.KeyCode == Keys.D)
                {
                    try
                    {
                        int documento_id = int.Parse(Microsoft.VisualBasic.Interaction.InputBox("Ingresa el ID del documento que deseas devolver", Text, "0"));
                        Documento documento_relacion = Documento.Obtener(documento_id);
                        if (documento_relacion.id != 0)
                        {
                            if (documento.clase.Equals("EN") || documento.clase.Equals("FA"))
                            {
                                if (documento.estado.Equals('A'))
                                {
                                    documento.CopiarDe(documento_relacion, (documento.clase.Equals("EN") ? "DV" : "NC"), true);
                                    documento.descuento = documento.porcentaje_descuento = 0;
                                    documento.partidas.ForEach(x => { x.CalcularTotal(); x.ObtenerStock(); });
                                    Cargar();
                                }
                                else
                                {
                                    MessageBox.Show("El documento ya ha sido cerrado.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("No es posible realizar la devolución de esta clase de documento.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("No fue posible encontrar el documento que se desea devolver.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                if (e.Control && e.KeyCode == Keys.B)
                    Buscar();

                if (e.Control && e.KeyCode == Keys.O)
                {
                    int documento_id = int.Parse(Microsoft.VisualBasic.Interaction.InputBox("Ingresa el ID del documento", Text, "0"));
                    documento = Documento.Obtener(documento_id);
                    Cargar();

                    //int documento_id = int.Parse(Microsoft.VisualBasic.Interaction.InputBox("Ingresa el ID del documento pedido", Text, "0"));
                    //Documento documento_a_copiar = Documento.Obtener(documento_id);
                    //if (documento.clase.Equals("PE"))
                    //{
                    //    documento.CopiarDe(documento_a_copiar, documento.clase, true);
                    //    txtCodigoSN.Enabled = false;
                    //    Cargar();
                    //}
                    //else
                    //{
                    //    MessageBox.Show("No es posible importar esta clase de documento.");
                    //}
                }

                if (e.Alt && e.KeyCode == Keys.B)
                {
                    frmBascula f = new frmBascula();
                    f.ShowDialog();
                }

                if (e.Alt && e.KeyCode == Keys.O)
                    OrdenCompra();

                if (e.Shift && e.KeyCode == Keys.A)
                {
                    frmArqueo f = new frmArqueo();
                    f.ShowDialog();
                    if (NoriSDK.PuntoVenta.EstadoCaja().Equals('C'))
                    {
                        FormClosing -= new FormClosingEventHandler(frmPuntoVenta_FormClosing);
                        Close();
                    }
                }

                if (e.Shift && e.KeyCode == Keys.D)
                {
                    frmIngresos f = new frmIngresos("INDEP");
                    f.ShowDialog();
                }

                if (e.Shift && e.KeyCode == Keys.C)
                {
                    frmCanjes f = new frmCanjes();
                    f.ShowDialog();
                }

                if (e.Shift && e.KeyCode == Keys.V)
                    lblVendedor.Links[0].Focus();

                if (e.Control && e.KeyCode == Keys.M)
                    CargarMonedero();

                if (e.Control && e.KeyCode == Keys.P)
                    Imprimir(documento);

                if (e.Alt && e.KeyCode == Keys.C)
                {
                    Comentario();
                    txtArticulo.Focus();
                }

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
            }
            catch { }
        }

        private void bbiImprimir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Imprimir(documento);
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
                    autorizacion.comentario = Microsoft.VisualBasic.Interaction.InputBox("Comentario modificación del total (Opcional)", "");

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
                else if (e.Column.Name == "gridColumnPrecio")
                {
                    Autorizacion autorizacion = new Autorizacion();

                    autorizacion.codigo = "MOTPP";
                    autorizacion.referencia = string.Format("Modificación del precio del artículo {0} de {1:c2} a {2:c2} al socio {3}", documento.partidas[e.RowHandle].sku, gvPartidas.ActiveEditor.OldEditValue, gvPartidas.ActiveEditor.EditValue, socio.codigo);
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
                else if (e.Column.FieldName == "porcentaje_descuento")
                {
                    Autorizacion autorizacion = new Autorizacion();

                    autorizacion.codigo = "DSCPP";
                    autorizacion.referencia = string.Format("Descuento al artículo {0} de {1:p2}% al socio {2}", documento.partidas[e.RowHandle].sku, gvPartidas.ActiveEditor.EditValue, socio.codigo);
                    autorizacion.comentario = Microsoft.VisualBasic.Interaction.InputBox("Comentario descuento (Opcional)", "");

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
                    if (decimal.Parse(gvPartidas.ActiveEditor.OldEditValue.ToString()) > decimal.Parse(gvPartidas.ActiveEditor.EditValue.ToString()))
                    {
                        Autorizacion autorizacion = new Autorizacion();

                        autorizacion.codigo = "MOCPP";
                        autorizacion.referencia = string.Format("Modificar cantidad al artículo {0} de {1} a {2}", documento.partidas[e.RowHandle].sku, gvPartidas.ActiveEditor.OldEditValue, gvPartidas.ActiveEditor.EditValue);
                        autorizacion.comentario = Microsoft.VisualBasic.Interaction.InputBox("Comentario modificar cantidad artículos (Opcional)", "");

                        autorizacion.Agregar();

                        if (!autorizacion.autorizado)
                        {
                            frmSolicitarAutorizacion fa = new frmSolicitarAutorizacion(autorizacion);
                            fa.ShowDialog();
                            autorizacion.autorizado = (fa.DialogResult == DialogResult.OK) ? true : false;
                        }

                        if (!autorizacion.autorizado)
                            documento.partidas[e.RowHandle].cantidad = (decimal)gvPartidas.ActiveEditor.OldEditValue;
                    }

                    if (documento.partidas[e.RowHandle].id == 0 && documento.partidas[e.RowHandle].porcentaje_descuento == 0)
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

        private void gvPartidas_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (Convert.ToDouble(gvPartidas.GetRowCellValue(e.RowHandle, gvPartidas.Columns["porcentaje_descuento"])) > 0)
                    e.Appearance.BackColor = Color.GreenYellow;
                e.Appearance.BackColor2 = Color.White;
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
                DataTable existencias = Utilidades.EjecutarQuery(string.Format("SELECT codigo AS Almacén, nombre AS [Nombre del almacén], stock AS Stock, comprometido AS Compormetido, pedido AS Pedido, disponible AS Disponible FROM DatosInventario WHERE articulo_id = {0} AND activo =  1", documento.partidas[gvPartidas.GetSelectedRows()[0]].articulo_id));
                frmResultadosBusqueda f = new frmResultadosBusqueda(existencias);
                f.Text = "Existencias " + documento.partidas[gvPartidas.GetSelectedRows()[0]].sku;
                f.ShowDialog();
            }

            if (e.Shift && e.KeyCode == Keys.C)
            {
                MessageBox.Show(Articulo.Articulos().Where(x => x.id == documento.partidas[gvPartidas.GetSelectedRows()[0]].articulo_id).Select(x => x.comentario).First(), "Comentario del artículo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (e.Alt && e.KeyCode == Keys.D)
                gvPartidas.FocusedColumn = gvPartidas.Columns["porcentaje_descuento"];

            if (e.Alt && e.KeyCode == Keys.T)
                gvPartidas.FocusedColumn = gvPartidas.Columns["total"];

            if (e.Alt && e.KeyCode == Keys.C)
                documento.partidas[gvPartidas.GetSelectedRows()[0]].comentario = Microsoft.VisualBasic.Interaction.InputBox("Agregar un comentario a esta linea", Text, documento.partidas[gvPartidas.GetSelectedRows()[0]].comentario);
        }

        private void gvPartidas_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            BeginInvoke(new MethodInvoker(delegate {
                try
                {
                    if (documento.partidas.Count > 0) 
                    {
                        pbImagen.LoadImage(Articulo.ObtenerImagen(documento.partidas[e.FocusedRowHandle].articulo_id));
                        lblArticuloComentarios.Text = Articulo.ObtenerComentario(documento.partidas[e.FocusedRowHandle].articulo_id);
                    }
                }
                catch { }
            }
            ));
        }

        private void cbFactura_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFactura.Checked)
            {
                documento.clase = "FA";
                cbReserva.Visible = true;
                cbReserva.Checked = documento.reserva;
            }
            else
            {
                documento.clase = "EN";
                cbReserva.Visible = false;
                cbReserva.Checked = false;
                documento.reserva = false;
            }

            txtArticulo.Text = string.Empty;
            txtArticulo.Focus();
        }

        private void cbReserva_CheckedChanged(object sender, EventArgs e)
        {
            documento.reserva = cbReserva.Checked;
        }

        private void bbiCortesCaja_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmCortesCaja f = new frmCortesCaja();
            f.Show();
        }

        private void lblVendedor_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                documento.vendedor_id = (int)lblVendedor.EditValue;
            }
            catch { }
        }

        private void bbiArqueo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmArqueo f = new frmArqueo();
            f.ShowDialog();
            if (NoriSDK.PuntoVenta.EstadoCaja().Equals('C'))
            {
                FormClosing -= new FormClosingEventHandler(frmPuntoVenta_FormClosing);
                Close();
            }
        }

        private void bbiPagos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmPagos f = new frmPagos();
            f.ShowDialog();
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

        private void btnAtras_Click(object sender, EventArgs e)
        {
            CargarGruposArticulos();
        }

        private void CargarGruposArticulos()
        {
            tlp.Controls.Clear();
            tlp.RowStyles.Clear();

            int columna = 0;
            int fila = 0;

            tlp.AutoScroll = false;
            var grupos_articulos = GrupoArticulo.GruposArticulos().Where(x => x.activo == true && x.grupo_superior_id == 0).OrderBy(x => x.orden).Select(x => new { x.id, x.nombre, x.color }).ToList();
            tlp.SuspendLayout();

            foreach (var grupo_articulo in grupos_articulos)
            {
                Button boton = new Button();

                boton.Name = grupo_articulo.id.ToString();
                boton.Text = grupo_articulo.nombre;

                if (!grupo_articulo.color.IsNullOrEmpty())
                {
                    boton.BackColor = Color.FromArgb(grupo_articulo.color.GetValueOrDefault());
                }

                boton.Width = 250;
                boton.Height = 50;

                boton.Font = new Font(boton.Font, FontStyle.Bold);

                boton.Click += new EventHandler(botonGrupoArticulo_Click);

                tlp.Controls.Add(boton, columna, fila);

                columna++;

                if (columna == 3)
                {
                    columna = 0;
                    fila++;
                }
            }

            tlp.AutoScroll = true;
            tlp.ResumeLayout();
        }

        protected void botonGrupoArticulo_Click(object sender, EventArgs e)
        {
            Button boton = sender as Button;
            CargarGrupos(int.Parse(boton.Name));
            
        }

        private async void CargarGrupos(int grupo_articulo_id)
        {
            tlp.Controls.Clear();
            tlp.RowStyles.Clear();

            int columna = 0;
            int fila = 0;

            tlp.AutoScroll = false;
            var grupos_articulos = GrupoArticulo.GruposArticulos().Where(x => x.activo == true && x.grupo_superior_id == grupo_articulo_id).OrderBy(x => x.orden).Select(x => new { x.id, x.nombre, x.color }).ToList();
            tlp.SuspendLayout();

            foreach (var grupo_articulo in grupos_articulos)
            {
                Button boton = new Button();

                boton.Name = grupo_articulo.id.ToString();
                boton.Text = grupo_articulo.nombre;

                if (!grupo_articulo.color.IsNullOrEmpty())
                {
                    boton.BackColor = Color.FromArgb(grupo_articulo.color.GetValueOrDefault());
                }

                boton.Width = 250;
                boton.Height = 50;

                boton.Font = new Font(boton.Font, FontStyle.Bold);

                boton.Click += new EventHandler(botonGrupoArticulo_Click);

                tlp.Controls.Add(boton, columna, fila);

                columna++;

                if (columna == 3)
                {
                    columna = 0;
                    fila++;
                }
            }

            tlp.AutoScroll = true;
            tlp.ResumeLayout();

            CargarArticulos(grupo_articulo_id, columna, fila);
        }

        private async void CargarArticulos(int grupo_articulo_id, int columna, int fila)
        {
            tlp.AutoScroll = false;
            List<int> grupos_articulos = Articulo.Grupo.Grupos().Where(x => x.grupo_articulo_id == grupo_articulo_id).Select(x => x.articulo_id).ToList();
            var articulos = Articulo.Articulos().Where(x => grupos_articulos.Contains(x.id) && x.activo == true && x.venta == true).Select(x => new { x.id, x.sku, x.nombre, x.imagen }).ToList();
            tlp.SuspendLayout();

            foreach (var articulo in articulos)
            {
                Button boton = new Button();

                boton.Name = articulo.id.ToString();
                boton.Text = articulo.nombre;
                boton.Tag = articulo.sku;

                if (!articulo.imagen.IsNullOrEmpty())
                    await Task.Run(() => boton.LoadImage(articulo.imagen));

                boton.Width = 250;
                boton.Height = 50;

                boton.Font = new Font(boton.Font, FontStyle.Bold);

                boton.Click += new EventHandler(botonArticulo_Click);

                tlp.Controls.Add(boton, columna, fila);

                columna++;

                if (columna == 3)
                {
                    columna = 0;
                    fila++;
                }
            }


            tlp.AutoScroll = true;
            tlp.ResumeLayout();
        }

        protected void botonArticulo_Click(object sender, EventArgs e)
        {
            Button boton = sender as Button;

            AgregarPartida((string)boton.Tag);
        }
    }
}