using DevExpress.XtraBars.Docking;
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
    public partial class frmPrincipal : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmPrincipal()
        {
            InitializeComponent();
            this.MetodoDinamico();

            barEditItemAutorizaciones.EditValue = Program.Nori.UsuarioAutenticado.suscribir_autorizaciones;
            accordionControlElementUsuario.Text = Program.Nori.UsuarioAutenticado.nombre;
            barHeaderItemEstacion.Caption = Program.Nori.Estacion.nombre + " | Conectado a: " + Program.Nori.Conexion.DataSource;
            Text = Program.Nori.Empresa.nombre_fiscal;
            lblEmpresa.Text = Program.Nori.Empresa.nombre_comercial;

            if (Program.Nori.UsuarioAutenticado.usuario == "admin")
                accordionControlElementRestaurante.Visible = true;

            switch (Program.Nori.UsuarioAutenticado.rol)
            {
                case 'C':
                    accordionControlElementGestion.Visible = false;
                    accordionControlElementGestionInventario.Visible = false;
                    accordionControlElementInventario.Visible = false;
                    accordionControlElementCompras.Visible = false;
                    
                    accordionControlElementCotizaciones.Visible = false;
                    accordionControlElementEntregas.Visible = false;
                    accordionControlElementPedidos.Visible = false;
                    accordionControlElementFacturas.Visible = false;
                    accordionControlElementDevoluciones.Visible = false;
                    accordionControlElementNotasCredito.Visible = false;
                    accordionControlElementNotasDebito.Visible = false;

                    accordionControlElementSocios.Visible = false;
                    accordionControlElementExtras.Visible = false;
                    ribbonPageHerramientas.Visible = false;

                    break;
                case 'V':
                    accordionControlElementGestion.Visible = false;
                    accordionControlElementInventarioListasPrecios.Visible = false;
                    ribbonPageGroupHerramientas.Visible = false;
                    accordionControlElementCompras.Visible = false;
                    accordionControlElementExtras.Visible = false;

                    if (Program.Nori.UsuarioAutenticado.VendedorForaneo())
                    {
                        accordionControlElementEntregas.Visible = false;
                        accordionControlElementEntregaMercancia.Visible = false;
                        accordionControlElementFacturas.Visible = false;
                        accordionControlElementDevoluciones.Visible = false;
                        accordionControlElementNotasCredito.Visible = false;
                        accordionControlElementNotasDebito.Visible = false;

                        accordionControlElementPuntoVenta.Visible = false;
                    }

                    break;
                case 'L':
                    accordionControlElementInventarioListasPrecios.Visible = false;
                    accordionControlElementGeneral.Visible = false;
                    accordionControlElementMonedas.Visible = false;
                    ribbonPageGroupHerramientas.Visible = false;
                    accordionControlElementCompras.Visible = false;
                    accordionControlElementExtras.Visible = false;

                    accordionControlElementFacturas.Visible = false;
                    accordionControlElementNotasCredito.Visible = false;
                    accordionControlElementNotasDebito.Visible = false;


                    accordionControlElementPuntoVenta.Visible = false;

                    break;
                case 'S':
                    accordionControlElementGestionInventario.Visible = false;
                    accordionControlElementInventarioListasPrecios.Visible = false;
                    accordionControlElementGeneral.Visible = false;
                    accordionControlElementMonedas.Visible = false;
                    ribbonPageGroupHerramientas.Visible = false;
                    accordionControlElementExtras.Visible = false;

                    break;
            }

            try
            {
                List<Informe> informes = Informe.Informes().Where(x => x.activo == true && (x.tipo == "US" || x.tipo == "SI")).OrderBy(x => x.nombre).ToList();
                foreach (Informe.Tipo tipo in Informe.Tipo.Tipos().Where(x => x.tipo == "US" || x.tipo == "SI"))
                {

                    if (!Program.Nori.UsuarioAutenticado.rol.Equals('A') && tipo.tipo == "SI")
                        continue;

                    DevExpress.XtraBars.Navigation.AccordionControlElement menu = new DevExpress.XtraBars.Navigation.AccordionControlElement();

                    menu.Style = DevExpress.XtraBars.Navigation.ElementStyle.Group;
                    menu.Text = tipo.nombre;

                    accordionControlElementInformes.Elements.Add(menu);

                    foreach (Informe informe in informes.Where(x => x.tipo == tipo.tipo))
                    {
                        DevExpress.XtraBars.Navigation.AccordionControlElement submenu = new DevExpress.XtraBars.Navigation.AccordionControlElement();

                        submenu.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
                        submenu.Name = informe.informe;
                        submenu.Text = informe.nombre;
                        submenu.Click += (object sender, EventArgs e) => { Funciones.PrevisualizarInforme(informe.informe); };

                        menu.Elements.Add(submenu);
                    }                      
                }
            }
            catch { }

            try
            {
                foreach (Sucursal sucursal in Sucursal.Sucursales().Where(x => x.activo == true).ToList())
                {
                    bbiSucursales.Strings.Add(sucursal.codigo);
                    Program.sucursales.Add(sucursal);
                }
            }
            catch
            {

            }

            CargarAsync();
        }

        private async void CargarModuloFacturacion()
        {
            try
            {
                Program.CFDI = await Task.Run(() => new NoriCFDI.CFDI());

                if (Program.Nori.Configuracion.certificado_id != 0)
                {
                    Certificado certificado = Certificado.Obtener(Program.Nori.Configuracion.certificado_id);

                    if (certificado.id != 0)
                    {
                        if (System.IO.File.Exists(certificado.cer) && System.IO.File.Exists(certificado.key))
                        {
                            Program.CFDI.certificado.cer = certificado.cer;
                            Program.CFDI.certificado.key = certificado.key;
                            Program.CFDI.certificado.contraseña = certificado.contraseña;
                            Program.CFDI.certificado.pfx = certificado.pfx;
                            Program.CFDI.certificado.contraseña_pfx = certificado.contraseña_pfx;

                            bool estado = await Task.Run(() => Program.CFDI.Inicializar());
                            if (!estado)
                                MessageBox.Show("Imposible cargar el módulo de facturación electrónica.");
                        }
                        else
                        {
                            MessageBox.Show("No se pudieron cargar los archivos del certificado.");
                        }
                    }

                    Program.CFDI.usuario = Program.Nori.Configuracion.timbrado_usuario;
                    Program.CFDI.contraseña = Program.Nori.Configuracion.timbrado_contraseña;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }
        private async void CargarAsync()
        {
            try
            {
                Extensiones.SetImage(this, await Funciones.CargarImagen(Program.Nori.Empresa.logotipo));

                if (Program.Nori.Configuracion.sap)
                    Program.NoriSAP = new NoriSAPB1SDK.NoriSAPSQL(Configuracion.SAP.Obtener());

                CargarModuloFacturacion();

                if (Program.Nori.Estacion.bascula && Program.Nori.Estacion.bascula_id != 0)
                {
                    if (Program.Nori.Estacion.ObtenerBascula())
                    {
                        if (!Program.Nori.Estacion.Bascula.Inicializar())
                        {
                            Program.Nori.Estacion.Bascula = null;
                            MessageBox.Show("Error al inicializar la báscula: " + NoriSDK.Nori.ObtenerUltimoError());
                        }
                    }
                }

                Funciones.NoriDynamic();

                if (Program.Nori.UsuarioAutenticado.escritorio.Length > 0)
                {
                    frmEscritorio escritorio = new frmEscritorio(Program.Nori.UsuarioAutenticado.escritorio);
                    AbrirFormulario(escritorio, false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void accordionControlElementCerrarSesion_Click(object sender, EventArgs e)
        {
            Funciones.CerrarSesion();
        }

        private void accordionControlElementGruposArticulos_Click(object sender, EventArgs e)
        {
            frmGruposArticulos f = new frmGruposArticulos();
            AbrirFormulario(f);
        }

        private void accordionControlElementAlmacenes_Click(object sender, EventArgs e)
        {
            frmAlmacenes f = new frmAlmacenes();
            AbrirFormulario(f, false);
        }

        private void accordionControlElementUsuarios_Click(object sender, EventArgs e)
        {
            frmUsuarios f = new frmUsuarios();
            AbrirFormulario(f);
        }

        private void accordionControlElementArticulos_Click(object sender, EventArgs e)
        {
            frmArticulos f = new frmArticulos();
            AbrirFormulario(f, false);
        }

        private void accordionControlElementBloquear_Click(object sender, EventArgs e)
        {
            Funciones.Desbloquear();
        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.Nori.UsuarioAutenticado.Desconectar();
        }

        private void accordionControlElementMonedas_Click(object sender, EventArgs e)
        {
            frmMonedas f = new frmMonedas();
            AbrirFormulario(f);
        }

        private void accordionControlElementListasPrecios_Click(object sender, EventArgs e)
        {
            frmListasPrecios f = new frmListasPrecios();
            AbrirFormulario(f);
        }

        private void accordionControlElementFabricantes_Click(object sender, EventArgs e)
        {
            frmFabricantes f = new frmFabricantes();
            AbrirFormulario(f);
        }

        private void accordionControlElementDepartamentos_Click(object sender, EventArgs e)
        {
            frmDepartamentos f = new frmDepartamentos();
            AbrirFormulario(f);
        }

        private void accordionControlElementEstaciones_Click(object sender, EventArgs e)
        {
            frmEstaciones f = new frmEstaciones();
            AbrirFormulario(f);
        }

        private void accordionControlElementVendedores_Click(object sender, EventArgs e)
        {
            frmVendedores f = new frmVendedores();
            AbrirFormulario(f);
        }

        private void accordionControlElementZonas_Click(object sender, EventArgs e)
        {
            frmZonas f = new frmZonas();
            AbrirFormulario(f);
        }

        private void accordionControlElementTipoCambio_Click(object sender, EventArgs e)
        {
            frmTiposCambio f = new frmTiposCambio();
            AbrirFormulario(f);
        }

        private void accordionControlElementGruposSocios_Click(object sender, EventArgs e)
        {
            frmGruposSocios f = new frmGruposSocios();
            AbrirFormulario(f);
        }

        private void accordionControlElementSocios_Click(object sender, EventArgs e)
        {
            frmSocios f = new frmSocios();
            AbrirFormulario(f, false);
        }

        private void accordionControlElementCondicionesPago_Click(object sender, EventArgs e)
        {
            frmCondicionesPago f = new frmCondicionesPago();
            AbrirFormulario(f);
        }

        private void accordionControlElementConfiguracion_Click(object sender, EventArgs e)
        {
            frmConfiguracion f = new frmConfiguracion();
            AbrirFormulario(f);
        }

        private void accordionControlElementPuntoVenta_Click(object sender, EventArgs e)
        {
            PuntoVenta.frmPuntoVenta f = new PuntoVenta.frmPuntoVenta();
            if (Program.Nori.UsuarioAutenticado.rol == 'A')
            {
                f.MaximizeBox = true;
                f.MinimizeBox = true;
                f.ControlBox = true;
                f.FormBorderStyle = FormBorderStyle.Sizable;
                f.Show();
            }
            else
            {
                f.FormBorderStyle = FormBorderStyle.None;
                f.ShowDialog();
            }
        }

        private void accordionControlElementEmpresa_Click(object sender, EventArgs e)
        {
            frmEmpresa f = new frmEmpresa();
            AbrirFormulario(f);
        }

        private void accordionControlElementPaises_Click(object sender, EventArgs e)
        {
            frmPaises f = new frmPaises();
            AbrirFormulario(f);
        }

        private void accordionControlElementEstados_Click(object sender, EventArgs e)
        {
            frmEstados f = new frmEstados();
            AbrirFormulario(f);
        }

        private void accordionControlElementImpuestos_Click(object sender, EventArgs e)
        {
            frmImpuestos f = new frmImpuestos();
            AbrirFormulario(f);
        }

        private void accordionControlElementMetodosPago_Click(object sender, EventArgs e)
        {
            frmMetodosPago f = new frmMetodosPago();
            AbrirFormulario(f);
        }

        private void bbiEventosControles_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmEventosControles f = new frmEventosControles();
            AbrirFormulario(f, false);
        }

        private void bbiDiseñadorInformes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDiseñadorInformes f = new frmDiseñadorInformes();
            f.Show();
        }

        private void ribbonControl1_ApplicationButtonClick(object sender, EventArgs e)
        {
            Funciones.CerrarSesion();
        }

        private void dockManager1_ClosingPanel(object sender, DockPanelCancelEventArgs e)
        {
            dockManager1.RemovePanel(e.Panel);
        }

        private void AbrirFormulario(Form form, bool dialog = true)
        {
            bool panel = Program.Nori.Configuracion.formulario_panel;

            if (form.Name.Equals("frmEscritorio"))
                panel = true;

            if (panel)
            {
                Size size = new Size();
                size = form.Size;
                size.Width = size.Width + 50;
                size.Height = size.Height + 50;

                form.TopLevel = false;
                form.Visible = true;
                form.ControlBox = false;
                form.ShowInTaskbar = false;

                form.FormBorderStyle = FormBorderStyle.None;

                DockPanel dp = dockManager1.AddPanel(DockingStyle.Float);

                (dp.Parent as Form).StartPosition = FormStartPosition.CenterScreen;
                dp.Controls.Add(form);
                dp.Text = form.Text;
                dp.FloatSize = size;
                dp.Size = size;

                if (!dialog)
                    dp.DockedAsTabbedDocument = true;

                form.Dock = DockStyle.Fill;
            }

            if (!dialog)
                form.Show();
            else
                if (!panel)
                    form.ShowDialog();
        }

        private void bbiConsultasPersonalizadas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmConsultasPersonalizadas f = new frmConsultasPersonalizadas();
            AbrirFormulario(f, false);
        }

        private void accordionControlElementTiposMetodosPagos_Click(object sender, EventArgs e)
        {
            frmTiposMetodosPago f = new frmTiposMetodosPago();
            AbrirFormulario(f);
        }

        private void bbiSincronizacion_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Program.Nori.UsuarioAutenticado.rol == 'A')
            {
                timerAutorizaciones.Enabled = false;
                frmSincronizacion f = new frmSincronizacion();
                f.Show();
            }
            else
            {
                MessageBox.Show("Solo los adminstradores pueden iniciar la sincronización.");
            }
            
        }

        private void accordionControlElementSeries_Click(object sender, EventArgs e)
        {
            frmSeries f = new frmSeries();
            AbrirFormulario(f);
        }

        private async void timerAutorizaciones_Tick(object sender, EventArgs e)
        {
            try
            {
                Autorizacion autorizacion = await Task.Run(() => Autorizacion.ObtenerAutorizacionPendiente());
                if (autorizacion.id != 0)
                {
                    timerAutorizaciones.Stop();
                    frmAutorizacion f = new frmAutorizacion(autorizacion);
                    f.ShowDialog();
                    timerAutorizaciones.Start();
                }
                Application.DoEvents();
            }
            catch { }
        }

        private void accordionControlElementCotizaciones_Click(object sender, EventArgs e)
        {
            frmDocumentos f = new frmDocumentos("CO");
            AbrirFormulario(f, false);
        }

        private void accordionControlElementPedidos_Click(object sender, EventArgs e)
        {
            frmDocumentos f = new frmDocumentos("PE");
            AbrirFormulario(f, false);
        }

        private void accordionControlElementEntregas_Click(object sender, EventArgs e)
        {
            frmDocumentos f = new frmDocumentos("EN");
            AbrirFormulario(f, false);
        }

        private void accordionControlElementFacturas_Click(object sender, EventArgs e)
        {
            frmDocumentos f = new frmDocumentos("FA");
            AbrirFormulario(f, false);
        }
        private void accordionControlElementDevoluciones_Click(object sender, EventArgs e)
        {
            frmDocumentos f = new frmDocumentos("DV");
            AbrirFormulario(f, false);
        }

        private void accordionControlElementNotasCredito_Click(object sender, EventArgs e)
        {
            frmDocumentos f = new frmDocumentos("NC");
            AbrirFormulario(f, false);
        }

        private void accordionControlElementNotasDebito_Click(object sender, EventArgs e)
        {
            frmDocumentos f = new frmDocumentos("ND");
            AbrirFormulario(f, false);
        }

        private void accordionControlElementInformes_Click(object sender, EventArgs e)
        {
            frmInformes f = new frmInformes();
            AbrirFormulario(f);
        }

        private void accordionControKioscoFacturacion_Click(object sender, EventArgs e)
        {
            Kiosco.frmKiosco f = new Kiosco.frmKiosco();
            f.ShowDialog();
        }

        private void bbiEntradasAbiertas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Program.Nori.UsuarioAutenticado.rol.Equals('A'))
                Funciones.FacturarEntregas();
        }

        private void frmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Funciones.CerrarSesion();
        }

        private void barEditItemAutorizaciones_EditValueChanged(object sender, EventArgs e)
        {
            if ((bool)barEditItemAutorizaciones.EditValue)
                timerAutorizaciones.Start();
            else
                timerAutorizaciones.Stop();
        }

        private void bbiEtiquetas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmEtiquetas f = new frmEtiquetas();
            f.Show();
        }

        private void accordionControlElementRestauranteMesas_Click(object sender, EventArgs e)
        {
            Restaurante.frmRestaurante f = new Restaurante.frmRestaurante();
            f.Show();
        }

        private void accordionControlElementEntradasMercancias_Click(object sender, EventArgs e)
        {
            frmDocumentos f = new frmDocumentos("EM");
            AbrirFormulario(f, false);
        }

        private void accordionControlElementPagos_Click(object sender, EventArgs e)
        {
            frmPagos f = new frmPagos();
            AbrirFormulario(f, false);
        }

        private void accordionControlElementOrdenCompra_Click(object sender, EventArgs e)
        {
            frmDocumentos f = new frmDocumentos("OC");
            AbrirFormulario(f, false);
        }

        private void accordionControlElementEntregaMercancia_Click(object sender, EventArgs e)
        {
            frmEntregaMercancia f = new frmEntregaMercancia();
            AbrirFormulario(f, false);
        }

        private void bbiTransmitirRecibir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Program.Nori.UsuarioAutenticado.VendedorForaneo())
            {
                bbiTransmitirRecibir.Enabled = false;
                Funciones.TransmitirRecibir();
                bbiTransmitirRecibir.Enabled = true;
            }
            else
            {
                MessageBox.Show("Este usuario no esta enlazado a un vendedor foraneo.");
            }
        }

        private void accordionControlElementSolicitudTraslado_Click(object sender, EventArgs e)
        {
            frmDocumentos f = new frmDocumentos("ST");
            AbrirFormulario(f, false);
        }

        private void accordionControlElementTransferenciaStock_Click(object sender, EventArgs e)
        {
            frmDocumentos f = new frmDocumentos("TS");
            AbrirFormulario(f, false);
        }

        private void accordionControlElementCotizacionCompra_Click(object sender, EventArgs e)
        {
            frmDocumentos f = new frmDocumentos("CC");
            AbrirFormulario(f, false);
        }

        private void bbiDiseñadorEscritorios_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDiseñadorEscritorios f = new frmDiseñadorEscritorios();
            f.Show();
        }

        private void accordionControlElementDevolucionMercancias_Click(object sender, EventArgs e)
        {
            frmDocumentos f = new frmDocumentos("DM");
            AbrirFormulario(f, false);
        }

        private void accordionControlElementCierreDia_Click(object sender, EventArgs e)
        {
            frmCierreDia f = new frmCierreDia();
            f.ShowDialog();
        }

        private void accordionControlElementAjusteEntrada_Click(object sender, EventArgs e)
        {
            frmDocumentos f = new frmDocumentos("AE");
            AbrirFormulario(f, false);
        }

        private void accordionControlElementAjusteSalida_Click(object sender, EventArgs e)
        {
            frmDocumentos f = new frmDocumentos("AS");
            AbrirFormulario(f, false);
        }

        private void bbiSucursales_ListItemClick(object sender, DevExpress.XtraBars.ListItemClickEventArgs e)
        {
            try
            {
                if (Funciones.ConectarSucursal(bbiSucursales.Strings[e.Index]))
                {
                    barHeaderItemEstacion.Caption = Program.Nori.Estacion.nombre + " | Conectado a: " + Program.Nori.Conexion.DataSource + " (" + bbiSucursales.Strings[e.Index] + ")";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmPrincipal_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
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

            } catch { }
        }

        private void accordionControlElementAnticiposClientes_Click(object sender, EventArgs e)
        {
            frmDocumentos f = new frmDocumentos("AC");
            AbrirFormulario(f, false);
        }

        private void accordionControlElementActivosFijos_Click(object sender, EventArgs e)
        {
            frmActivosFijos f = new frmActivosFijos();
            AbrirFormulario(f, false);
        }

        private void accordionControlElementInventarioFisico_Click(object sender, EventArgs e)
        {
            frmDocumentos f = new frmDocumentos("IF");
            AbrirFormulario(f, false);
        }

        private void accordionControlElementListaPartidas_Click(object sender, EventArgs e)
        {
            frmListaPartidas f = new frmListaPartidas();
            f.Show();
        }
    }
}