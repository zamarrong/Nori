using NoriSDK;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Nori
{
    public partial class frmRemolques : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        Remolque remolque = new Remolque();

        public frmRemolques(int id = 0)
        {
            InitializeComponent();
            this.MetodoDinamico();

            if (id != 0)
            {
                remolque = Remolque.Obtener(id);
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
            }
        }

        private void Cargar(bool nuevo = false, bool busqueda = false)
        {
            lblID.Text = remolque.id.ToString();

            txtCodigo.Text = remolque.codigo;
            txtNombre.Text = remolque.nombre;
            txtSubTipoRemolque.Text = remolque.sub_tipo_remolque;
            txtNumeroPlacas.Text = remolque.placa;

            cbActivo.Checked = remolque.activo;

            lblFechaActualizacion.Text = remolque.fecha_actualizacion.ToShortDateString();

            if (nuevo)
            {
                bbiNuevo.Enabled = false;
                bbiGuardar.Enabled = true;
                bbiGuardarCerrar.Enabled = true;
                bbiGuardarNuevo.Enabled = true;
                txtCodigo.Focus();
            }
            else
            {
                if (busqueda)
                {
                    bbiNuevo.Enabled = true;
                    bbiGuardar.Enabled = false;
                    bbiGuardarCerrar.Enabled = false;
                    bbiGuardarNuevo.Enabled = false;
                    txtCodigo.Focus();
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
            remolque.codigo = txtCodigo.Text;
            remolque.nombre = txtNombre.Text;

            remolque.sub_tipo_remolque = txtSubTipoRemolque.Text;
            remolque.placa = txtNumeroPlacas.Text;

            remolque.activo = cbActivo.Checked;
        }

        private bool Guardar()
        {
            try
            {
                if (MessageBox.Show("¿Desea guardar los cambios?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Llenar();
                    if (remolque.id != 0)
                        return remolque.Actualizar();
                    else
                        return remolque.Agregar();
                }
                else
                    return false;
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
                Close();
        }

        private void bbiGuardarNuevo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Guardar())
            {
                remolque = new Remolque();
                Cargar();
            }
        }

        private void bbiPrimero_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                remolque = Remolque.Remolques().OrderBy(x => x.id).First();
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
                remolque = Remolque.Remolques().Where(x => x.id < remolque.id).OrderByDescending(x => x.id).First();
                Cargar();
            }
            catch
            {
                bbiUltimo.PerformClick();
            }
        }

        private void bbiSiguiente_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                remolque = Remolque.Remolques().Where(x => x.id > remolque.id).First();
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
                remolque = Remolque.Remolques().OrderByDescending(x => x.id).First();
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

        private void bbiBuscar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            try
            {
                if (remolque.id != 0)
                {
                    remolque = new Remolque();
                    Cargar(false, true);
                }
                else
                {
                    object p = new { fields = "id, codigo, nombre, activo", like = true };
                    object o = new { codigo = txtCodigo.Text, nombre = txtNombre.Text };
                    DataTable remolques = Utilidades.Busqueda("remolques", o, p);
                    if (remolques.Rows.Count > 0)
                    {
                        if (remolques.Rows.Count == 1)
                        {
                            remolque = Remolque.Obtener((int)remolques.Rows[0]["id"]);
                            Cargar();
                        }
                        else
                        {
                            frmResultadosBusqueda f = new frmResultadosBusqueda(remolques);
                            var result = f.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                remolque = Remolque.Obtener(f.id);
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
            remolque = new Remolque();
            Cargar(true);
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && remolque.id == 0)
                Buscar();
        }
    }
}