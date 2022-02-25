using NoriSDK;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Nori.Restaurante
{
    public partial class frmComanda : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        Documento documento = new Documento();
        Socio socio = new Socio();
        public frmComanda(int id = 0)
        {
            InitializeComponent();
			this.MetodoDinamico();
            if (id != 0)
            {
                //estado = Estado.Obtener(id);
                //Cargar();
            }
            else
            {
                //Cargar(false, true);
            }

            Permisos();

            Inicializar();

            CargarGruposArticulos();
        }

        private void Permisos()
        {
            switch (Program.Nori.UsuarioAutenticado.rol)
            {
                case 'C':
                    mainRibbonPageGroup.Visible = false;
                    break;
                case 'V':
                    mainRibbonPageGroup.Visible = false;
                    break;
                case 'S':
                    mainRibbonPageGroup.Visible = false;
                    break;
            }
        }

        private void CargarGruposArticulos()
        {
            tlp.Controls.Clear();
            tlp.RowStyles.Clear();

            int columna = 0;
            int fila = 0;

            tlp.AutoScroll = false;
            var grupos_articulos = GrupoArticulo.GruposArticulos().Where(x => x.activo == true).Select(x => new { x.id, x.nombre }).ToList();
            tlp.SuspendLayout();

            foreach (var grupo_articulo in grupos_articulos)
            {
                Button boton = new Button();

                boton.Name = grupo_articulo.id.ToString();
                boton.Text =  grupo_articulo.nombre;

                boton.Width =  250;
                boton.Height = 50;

                boton.Font = new Font(boton.Font, FontStyle.Bold);

                boton.Click += new EventHandler(botonGrupoArticulo_Click);

                tlp.Controls.Add(boton, fila, columna);

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
            CargarArticulos(int.Parse(boton.Name));
        }

        private void CargarArticulos(int grupo_articulo_id)
        {
            tlp.Controls.Clear();
            tlp.RowStyles.Clear();

            int columna = 0;
            int fila = 0;

            tlp.AutoScroll = false;
            var articulos = Articulo.Articulos().Where(x => x.grupo_articulo_id == grupo_articulo_id && x.activo == true).Select(x => new { x.id, x.sku, x.nombre, x.imagen }).ToList();
            tlp.SuspendLayout();

            foreach (var articulo in articulos)
            {
                Button boton = new Button();

                boton.Name = articulo.id.ToString();
                boton.Text = articulo.nombre;
                boton.Tag = articulo.sku;

                //if (!articulo.imagen.IsNullOrEmpty())
                    //boton.LoadImage(articulo.imagen);

                boton.Width = 250;
                boton.Height = 50;

                boton.Font = new Font(boton.Font, FontStyle.Bold);

                boton.Click += new EventHandler(botonArticulo_Click);

                tlp.Controls.Add(boton, fila, columna);

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

        private void Inicializar()
        {
            try
            {
                documento = new Documento();
                EstablecerSocio(Socio.Obtener(Program.Nori.UsuarioAutenticado.socio_id));
                Cargar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cargar()
        {
            CargarListas();

            if (documento.socio_id == 0)
                MessageBox.Show("No esta definido el socio de negocio predeterminado");
            else
                socio = Socio.Obtener(Program.Nori.UsuarioAutenticado.socio_id);

            Calcular();
        }

        private void CargarListas()
        {
            object p = new { fields = "id, nombre" };
            object o = new { activo = 1 };

            cbVendedores.Properties.DataSource = Utilidades.Busqueda("vendedores", o, p);
            cbVendedores.Properties.ValueMember = "id";
            cbVendedores.Properties.DisplayMember = "nombre";
            cbVendedores.EditValue = Program.Nori.UsuarioAutenticado.vendedor_id;
        }

        private void Calcular()
        {
            gcPartidas.DataSource = documento.partidas;
            gcPartidas.RefreshDataSource();

            documento.CalcularTotal();

            lblTotal.Text = documento.total.ToString("C");
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

                            //txtCodigoSN.Text = socio.codigo;
                            //lblSocio.Text = socio.nombre;
                        }

                        //try
                        //{
                        //    lblDireccion.Text = Socio.Direccion.Obtener(socio.direccion_facturacion_id).Bloque();
                        //}
                        //catch
                        //{
                        //    lblDireccion.Text = string.Empty;
                        //    MessageBox.Show("El socio no tiene establecida la dirección de facturación.");
                        //    return;
                        //}

                        //try
                        //{
                        //    lblCondicionPago.Text = CondicionesPago.CondicionesPagos().Where(x => x.id == socio.condicion_pago_id).Select(x => new { x.nombre }).First().nombre;
                        //}
                        //catch
                        //{
                        //    lblCondicionPago.Text = string.Empty;
                        //    MessageBox.Show("El socio no tiene establecida la condición de pago.");
                        //    return;
                        //}

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

        private void txtArticulo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtArticulo.Text.Length > 0)
                AgregarPartida(txtArticulo.Text);
        }

        private void AgregarPartida(string q)
        {
            Buscar:
            if (documento.AgregarPartida(q))
            {
                txtArticulo.Text = string.Empty;
                Calcular();
            }
            else
                if (MessageBox.Show(NoriSDK.Nori.ObtenerUltimoError().Message, Text, MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                goto Buscar;

            txtArticulo.Text = string.Empty;
            txtArticulo.Focus();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            CargarGruposArticulos();
        }
    }
}