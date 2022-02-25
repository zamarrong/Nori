using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using NoriSDK;

namespace Nori
{
    public partial class frmGrupoArticulo : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        GrupoArticulo grupo_articulo = new GrupoArticulo();

        public frmGrupoArticulo()
        {
            InitializeComponent();
        }

        private void cargar(bool nuevo = false, bool busqueda = false)
        {
            lblID.Text = grupo_articulo.id.ToString();

            txtCodigo.Text = grupo_articulo.codigo;
            txtNombre.Text = grupo_articulo.nombre;

            cbPredeterminado.Checked = grupo_articulo.predeterminado;
            cbActivo.Checked = grupo_articulo.activo;

            lblFechaActualizacion.Text = grupo_articulo.fecha_actualizacion.ToShortDateString();

            bool primero = (grupo_articulo.id == GrupoArticulo.primer()) ? false : true;
            bool ultimo = (grupo_articulo.id == GrupoArticulo.ultimo()) ? false : true;

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
            grupo_articulo.codigo = txtCodigo.Text;
            grupo_articulo.nombre = txtNombre.Text;
            grupo_articulo.predeterminado = cbPredeterminado.Checked;
            grupo_articulo.activo = cbActivo.Checked;
        }

        private bool guardar()
        {
            try
            {
                if (MessageBox.Show("¿Desea guardar los cambios?", "Confirmación", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    llenar();
                    if (grupo_articulo.id != 0)
                    {
                        GrupoArticulo.actualizar(grupo_articulo);
                    }
                    else
                    {
                        grupo_articulo.id = GrupoArticulo.agregar(grupo_articulo);
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
                grupo_articulo = new GrupoArticulo();
                cargar();
            }
        }

        private void bbiFirst_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int id = GrupoArticulo.primer();
            if (id != 0)
            {
                grupo_articulo = GrupoArticulo.obtener(id);
                cargar();
            }
        }

        private void bbiPrev_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int id = GrupoArticulo.anterior(grupo_articulo.id);
            if (id != 0)
            {
                grupo_articulo = GrupoArticulo.obtener(id);
                cargar();
            }
            else
            {
                id = GrupoArticulo.ultimo();
                grupo_articulo = GrupoArticulo.obtener(id);
                cargar();
            }
        }

        private void bbiNext_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int id = GrupoArticulo.siguiente(grupo_articulo.id);
            if (id != 0)
            {
                grupo_articulo = GrupoArticulo.obtener(id);
                cargar();
            }
            else
            {
                id = GrupoArticulo.primer();
                grupo_articulo = GrupoArticulo.obtener(id);
                cargar();
            }
        }

        private void bbiLast_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int id = GrupoArticulo.ultimo();
            if (id != 0)
            {
                grupo_articulo = GrupoArticulo.obtener(id);
                cargar();
            }
        }

        private void bbiSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grupo_articulo.id != 0)
            {
                grupo_articulo = new GrupoArticulo();
                GrupoArticulo.primer();
                cargar(false, true);
            }
            else
            {
                object p = new { separator = "OR", like = true };
                object o = new { codigo = txtCodigo.Text, nombre = txtNombre.Text };
                List<GrupoArticulo> grupo_articulos = GrupoArticulo.buscar(o, p);
                if (grupo_articulos.Count > 0)
                {
                    if (grupo_articulos.Count == 1)
                    {
                        grupo_articulo = GrupoArticulo.obtener(grupo_articulos[0].id);
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
            grupo_articulo = new GrupoArticulo();
            cargar(true);
        }
    }
}