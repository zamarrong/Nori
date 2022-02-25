using NoriSDK;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Nori
{
    public partial class frmListasPrecios : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        ListaPrecio lista_precio = new ListaPrecio();

        public frmListasPrecios(int id = 0)
        {
            InitializeComponent();
			this.MetodoDinamico();
            if (id != 0)
            {
                lista_precio = ListaPrecio.Obtener(id);
                Cargar();
            }
            else
            {
                Cargar(false, true);
            }
            Permisos();
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

        private void Cargar(bool nuevo = false, bool busqueda = false)
        {
            lblID.Text = lista_precio.id.ToString();

            txtCodigo.Text = lista_precio.codigo.ToString();
            txtNombre.Text = lista_precio.nombre;

            cbActivo.Checked = lista_precio.activo;

            lblFechaActualizacion.Text = lista_precio.fecha_actualizacion.ToShortDateString();

            if (nuevo)
            {
                bbiNuevo.Enabled = false;
                bbiGuardar.Enabled = true;
                bbiGuardarCerrar.Enabled = true;
                bbiGuardarNuevo.Enabled = true;
                txtNombre.Focus();
            }
            else
            {
                if (busqueda)
                {
                    bbiNuevo.Enabled = true;
                    bbiGuardar.Enabled = false;
                    bbiGuardarCerrar.Enabled = false;
                    bbiGuardarNuevo.Enabled = false;
                    txtNombre.Focus();
                }
                else
                {
                    bbiNuevo.Enabled = true;
                    bbiGuardar.Enabled = true;
                    bbiGuardarCerrar.Enabled = true;
                    bbiGuardarNuevo.Enabled = true;
                }
            }
        }

        private void Llenar()
        {
            lista_precio.codigo = short.Parse(txtCodigo.Text);
            lista_precio.nombre = txtNombre.Text;
            lista_precio.activo = cbActivo.Checked;
        }

        private bool Guardar()
        {
            try
            {
                if (MessageBox.Show("¿Desea guardar los cambios?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Llenar();
                    if (lista_precio.id != 0)
                    {
                        return lista_precio.Actualizar();
                    }
                    else
                    {
                        return lista_precio.Agregar();
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
                lista_precio = new ListaPrecio();
                Cargar();
            }
        }

        private void bbiPrimero_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                lista_precio = ListaPrecio.ListasPrecios().OrderBy(x => x.id).First();
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
                lista_precio = ListaPrecio.ListasPrecios().Where(x => x.id < lista_precio.id).OrderByDescending(x => x.id).First();
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
                lista_precio = ListaPrecio.ListasPrecios().Where(x => x.id > lista_precio.id).First();
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
                lista_precio = ListaPrecio.ListasPrecios().OrderByDescending(x => x.id).First();
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

        private void Buscar()
        {
            try
            {
                if (lista_precio.id != 0)
                {
                    lista_precio = new ListaPrecio();
                    Cargar(false, true);
                }
                else
                {
                    object p = new { fields = "id, nombre, activo", like = true };
                    object o = new { nombre = txtNombre.Text };
                    DataTable listas_precios = Utilidades.Busqueda("listas_precios", o, p);
                    if (listas_precios.Rows.Count > 0)
                    {
                        if (listas_precios.Rows.Count == 1)
                        {
                            lista_precio = ListaPrecio.Obtener((int)listas_precios.Rows[0]["id"]);
                            Cargar();
                        }
                        else
                        {
                            frmResultadosBusqueda f = new frmResultadosBusqueda(listas_precios);
                            var result = f.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                lista_precio = ListaPrecio.Obtener(f.id);
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

        private void bbiNuevo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            lista_precio = new ListaPrecio();
            Cargar(true);
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && lista_precio.id == 0)
                Buscar();
        }

        private void bbiUsuarios_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmUsuariosListasPrecios f = new frmUsuariosListasPrecios();
            f.Show();
        }
    }
}