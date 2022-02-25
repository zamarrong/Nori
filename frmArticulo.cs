using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using NoriSDK;
using DevExpress.XtraGrid;

namespace Nori
{
    public partial class frmArticulo : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        Articulo articulo = new Articulo();
        List<Almacen> almacenes = Almacen.buscar();
        public frmArticulo()
        {
            InitializeComponent();
            cargar(false, true);
            gcInventario.DataSource = Utilidades.ObtenerVista("datos_inventario");
        }

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            guardar();
        }

        private void bbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (guardar())
            {
                this.Close();
            }
        }

        private void bbiSaveAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (guardar())
            {
                articulo = new Articulo();
                cargar();
            }
        }

        private void cargar(bool nuevo = false, bool busqueda = false)
        {
            lblID.Text = articulo.id.ToString();

            cbAlmacenable.Checked = articulo.almacenable;
            cbVenta.Checked = articulo.venta;
            cbCompra.Checked = articulo.compra;
            cbJuego.Checked = articulo.juego;
            cbSobrepedido.Checked = articulo.sobrepedido;
            cbCanjeable.Checked = articulo.canjeable;

            switch (articulo.seguimiento)
            {
                case 'N':
                    rbNormal.Checked = true;
                    rbSeries.Checked = false;
                    break;
                case 'S':
                    rbNormal.Checked = false;
                    rbSeries.Checked = true;
                    break;
            }

            txtDiasGarantia.Text = articulo.dias_garantia.ToString();

            txtSKU.Text = articulo.sku;
            txtSKUFabricante.Text = articulo.sku_fabricante;
            txtNombre.Text = articulo.nombre;
            txtDescripcion.Text = articulo.descripcion;

            if (articulo.imagen != null)
            {
                try {
                    Image imagen = Image.FromFile(articulo.imagen);
                    pbImagen.Image = imagen;
                }
                catch
                {
                    pbImagen.Image = null;
                }
            }
            else
            {
                pbImagen.Image = null;
            }

            txtCodigoBarras.Text = articulo.codigo_barras;
            txtStock.Text = articulo.stock.ToString();
            txtPeso.Text = articulo.peso.ToString();

            cbActivo.Checked = articulo.activo;

            lblFechaActualizacion.Text = articulo.fecha_actualizacion.ToShortDateString();

            bool primero = (articulo.id == Articulo.primer()) ? false : true;
            bool ultimo = (articulo.id == Articulo.ultimo()) ? false : true;

            bbiFirst.Enabled = primero;
            bbiLast.Enabled = ultimo;

            if (nuevo)
            {
                bbiNew.Enabled = false;
                bbiSave.Enabled = true;
                bbiSaveAndClose.Enabled = true;
                bbiSaveAndNew.Enabled = true;
            }
            else
            {
                if (busqueda)
                {
                    bbiNew.Enabled = true;
                    bbiSave.Enabled = false;
                    bbiSaveAndClose.Enabled = false;
                    bbiSaveAndNew.Enabled = false;
                }
                else
                {
                    bbiNew.Enabled = true;
                    bbiSave.Enabled = true;
                    bbiSaveAndClose.Enabled = true;
                    bbiSaveAndNew.Enabled = true;
                }
            }
        }

        private void llenar()
        {
            articulo.almacenable = cbAlmacenable.Checked;
            articulo.venta = cbVenta.Checked;
            articulo.compra = cbCompra.Checked;
            articulo.juego = cbJuego.Checked;
            articulo.sobrepedido = cbSobrepedido.Checked;
            articulo.canjeable = cbCanjeable.Checked;
            articulo.seguimiento = (rbNormal.Checked) ? 'N' : 'S';
            articulo.dias_garantia = int.Parse(txtDiasGarantia.Text);

            articulo.sku = txtSKU.Text;
            articulo.sku_fabricante = txtSKUFabricante.Text;
            articulo.nombre = txtNombre.Text;
            articulo.descripcion = txtDescripcion.Text;
            articulo.codigo_barras = txtCodigoBarras.Text;

            articulo.peso = double.Parse(txtPeso.Text);

            articulo.activo = cbActivo.Checked;
        }

        private bool guardar()
        {
            try
            {
                if (MessageBox.Show("¿Desea guardar los cambios?", "Confirmación", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    llenar();
                    if (articulo.id != 0)
                    {
                        Articulo.actualizar(articulo);
                    }
                    else
                    {
                        articulo.id = Articulo.agregar(articulo);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Ocurrio un error, trate nuevamente", "Error");
                return false;
            }
        }

        private void bbiFirst_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int id = Articulo.primer();
            if (id != 0)
            {
                articulo = Articulo.obtener(id);
                cargar();
            }
        }

        private void bbiPrev_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int id = Articulo.anterior(articulo.id);
            if (id != 0)
            {
                articulo = Articulo.obtener(id);
                cargar();
            }
            else
            {
                id = Articulo.ultimo();
                articulo = Articulo.obtener(id);
                cargar();
            }
        }

        private void bbiNext_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int id = Articulo.siguiente(articulo.id);
            if (id != 0)
            {
                articulo = Articulo.obtener(id);
                cargar();
            }
            else
            {
                id = Articulo.primer();
                articulo = Articulo.obtener(id);
                cargar();
            }
        }

        private void bbiLast_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int id = Articulo.ultimo();
            if (id != 0)
            {
                articulo = Articulo.obtener(id);
                cargar();
            }
        }

        private void bbiSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (articulo.id != 0) 
            {
                articulo = new Articulo();
                Articulo.primer();
                cargar(false, true);
            }
            else
            {
                object p = new { separator = "OR", like = true };
                object o = new { sku = txtSKU.Text, nombre = txtNombre.Text, descripcion = txtDescripcion.Text };
                List<Articulo> articulos = Articulo.buscar(o, p);
                if (articulos.Count > 0)
                {
                    if (articulos.Count == 1)
                    {
                        articulo = Articulo.obtener(articulos[0].id);
                        cargar();
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron resultados", "Alerta");
                }
            }
        }

        private void bbiNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            articulo = new Articulo();
            cargar(true);
        }

        private void btnImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Archivos de imagen(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pbImagen.Image = new Bitmap(open.FileName);
                articulo.imagen = open.FileName;
            }
        }

        private void lblGrupoArticulos_Click(object sender, EventArgs e)
        {
            frmGrupoArticulo form = new frmGrupoArticulo();
            form.ShowDialog();
        }
    }
}
