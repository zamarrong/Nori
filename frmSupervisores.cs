using NoriSDK;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Nori
{
    public partial class frmSupervisores : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        Supervisor supervisor = new Supervisor();

        public frmSupervisores(int id = 0)
        {
            InitializeComponent();
            this.MetodoDinamico();

            if (id != 0)
            {
                supervisor = Supervisor.Obtener(id);
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
            lblID.Text = supervisor.id.ToString();

            txtCodigo.Text = supervisor.codigo;
            txtNombre.Text = supervisor.nombre;

            cbActivo.Checked = supervisor.activo;

            lblFechaActualizacion.Text = supervisor.fecha_actualizacion.ToShortDateString();

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
            supervisor.codigo = txtCodigo.Text;
            supervisor.nombre = txtNombre.Text;
            supervisor.activo = cbActivo.Checked;
        }

        private bool Guardar()
        {
            try
            {
                if (MessageBox.Show("¿Desea guardar los cambios?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Llenar();
                    if (supervisor.id != 0)
                        return supervisor.Actualizar();
                    else
                        return supervisor.Agregar();
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
                supervisor = new Supervisor();
                Cargar();
            }
        }

        private void bbiPrimero_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                supervisor = Supervisor.Supervisores().OrderBy(x => x.id).First();
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
                supervisor = Supervisor.Supervisores().Where(x => x.id < supervisor.id).OrderByDescending(x => x.id).First();
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
                supervisor = Supervisor.Supervisores().Where(x => x.id > supervisor.id).First();
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
                supervisor = Supervisor.Supervisores().OrderByDescending(x => x.id).First();
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
                if (supervisor.id != 0)
                {
                    supervisor = new Supervisor();
                    Cargar(false, true);
                }
                else
                {
                    object p = new { fields = "id, codigo, nombre, activo", like = true };
                    object o = new { codigo = txtCodigo.Text, nombre = txtNombre.Text };
                    DataTable supervisores = Utilidades.Busqueda("supervisores", o, p);
                    if (supervisores.Rows.Count > 0)
                    {
                        if (supervisores.Rows.Count == 1)
                        {
                            supervisor = Supervisor.Obtener((int)supervisores.Rows[0]["id"]);
                            Cargar();
                        }
                        else
                        {
                            frmResultadosBusqueda f = new frmResultadosBusqueda(supervisores);
                            var result = f.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                supervisor = Supervisor.Obtener(f.id);
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
            supervisor = new Supervisor();
            Cargar(true);
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && supervisor.id == 0)
                Buscar();
        }
    }
}