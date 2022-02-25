using NoriSDK;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Nori
{
    public partial class frmBasculas : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        Bascula bascula = new Bascula();

        public frmBasculas(int id = 0)
        {
            InitializeComponent();
			this.MetodoDinamico();

            if (id != 0)
            {
                bascula = Bascula.Obtener(id);
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
            lblID.Text = bascula.id.ToString();

            txtNombre.Text = bascula.nombre;
            txtPuerto.Text = bascula.puerto;

            txtBaudRate.Text = bascula.baud_rate.ToString();
            txtStopBits.Text = bascula.stop_bits.ToString();
            txtDataBits.Text = bascula.data_bits.ToString();

            txtComando.Text = bascula.comando;

            cbActivo.Checked = bascula.activo;

            lblFechaActualizacion.Text = bascula.fecha_actualizacion.ToShortDateString();

            if (nuevo)
            {
                bbiNuevo.Enabled = false;
                bbiGuardar.Enabled = true;
                bbiGuardarNuevo.Enabled = true;
                txtNombre.Focus();
            }
            else
            {
                if (busqueda)
                {
                    bbiNuevo.Enabled = true;
                    bbiGuardar.Enabled = false;
                    bbiGuardarNuevo.Enabled = false;
                    txtNombre.Focus();
                }
                else
                {
                    bbiNuevo.Enabled = true;
                    bbiGuardar.Enabled = true;
                    bbiGuardarNuevo.Enabled = true;
                }
            }
        }

        private void Llenar()
        {
            bascula.nombre = txtNombre.Text;
            bascula.puerto = txtPuerto.Text;

            bascula.baud_rate = int.Parse(txtBaudRate.Text);
            bascula.stop_bits = int.Parse(txtStopBits.Text);
            bascula.data_bits = int.Parse(txtDataBits.Text);

            bascula.comando = txtComando.Text;

            bascula.activo = cbActivo.Checked;
        }

        private bool Guardar()
        {
            try
            {
                if (MessageBox.Show("¿Desea guardar los cambios?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Llenar();
                    if (bascula.id != 0)
                        return bascula.Actualizar();
                    else
                        return bascula.Agregar();
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

        private void bbiGuardarNuevo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Guardar())
            {
                bascula = new Bascula();
                Cargar();
            }
        }

        private void bbiPrimero_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bascula = Bascula.Basculas().OrderBy(x => x.id).First();
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
                bascula = Bascula.Basculas().Where(x => x.id < bascula.id).OrderByDescending(x => x.id).First();
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
                bascula = Bascula.Basculas().Where(x => x.id > bascula.id).First();
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
                bascula = Bascula.Basculas().OrderByDescending(x => x.id).First();
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
                if (bascula.id != 0)
                {
                    bascula = new Bascula();
                    Cargar(false, true);
                }
                else
                {
                    object p = new { fields = "id, nombre, puerto, activo", like = true };
                    object o = new { nombre = txtNombre.Text, puerto = txtPuerto.Text };
                    DataTable basculas = Utilidades.Busqueda("basculas", o, p);
                    if (basculas.Rows.Count > 0)
                    {
                        if (basculas.Rows.Count == 1)
                        {
                            bascula = Bascula.Obtener((int)basculas.Rows[0]["id"]);
                            Cargar();
                        }
                        else
                        {
                            frmResultadosBusqueda f = new frmResultadosBusqueda(basculas);
                            var result = f.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                bascula = Bascula.Obtener(f.id);
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
            bascula = new Bascula();
            Cargar(true);
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && bascula.id == 0)
                Buscar();
        }
    }
}