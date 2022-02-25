using NoriSDK;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Nori
{
    public partial class frmTiposEmpaques : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        TipoEmpaque tipo_empaque = new TipoEmpaque();

        public frmTiposEmpaques(int id = 0)
        {
            InitializeComponent();
			this.MetodoDinamico();

            if (id != 0)
            {
                tipo_empaque = TipoEmpaque.Obtener(id);
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
            lblID.Text = tipo_empaque.id.ToString();

            txtNombre.Text = tipo_empaque.nombre;
            txtLargo.Text = tipo_empaque.largo.ToString();
            txtAlto.Text = tipo_empaque.alto.ToString();
            txtAncho.Text = tipo_empaque.ancho.ToString();
            txtVolumen.Text = tipo_empaque.volumen.ToString();
            txtPeso.Text = tipo_empaque.peso.ToString();

            cbActivo.Checked = tipo_empaque.activo;

            lblFechaActualizacion.Text = tipo_empaque.fecha_actualizacion.ToShortDateString();

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
            tipo_empaque.nombre = txtNombre.Text;

            tipo_empaque.largo = decimal.Parse(txtLargo.Text);
            tipo_empaque.alto = decimal.Parse(txtAlto.Text);
            tipo_empaque.ancho = decimal.Parse(txtAncho.Text);
            tipo_empaque.volumen = decimal.Parse(txtVolumen.Text);
            tipo_empaque.peso = decimal.Parse(txtPeso.Text);

            tipo_empaque.activo = cbActivo.Checked;
        }

        private bool Guardar()
        {
            try
            {
                if (MessageBox.Show("¿Desea guardar los cambios?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Llenar();
                    if (tipo_empaque.id != 0)
                        return tipo_empaque.Actualizar();
                    else
                        return tipo_empaque.Agregar();
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
                tipo_empaque = new TipoEmpaque();
                Cargar();
            }
        }

        private void bbiPrimero_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                tipo_empaque = TipoEmpaque.TiposEmpaques().OrderBy(x => x.id).First();
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
                tipo_empaque = TipoEmpaque.TiposEmpaques().Where(x => x.id < tipo_empaque.id).OrderByDescending(x => x.id).First();
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
                tipo_empaque = TipoEmpaque.TiposEmpaques().Where(x => x.id > tipo_empaque.id).First();
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
                tipo_empaque = TipoEmpaque.TiposEmpaques().OrderByDescending(x => x.id).First();
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
                if (tipo_empaque.id != 0)
                {
                    tipo_empaque = new TipoEmpaque();
                    Cargar(false, true);
                }
                else
                {
                    object p = new { fields = "id, nombre, activo", like = true };
                    object o = new { nombre = txtNombre.Text };
                    DataTable tipos_empaques = Utilidades.Busqueda("tipos_empaques", o, p);
                    if (tipos_empaques.Rows.Count > 0)
                    {
                        if (tipos_empaques.Rows.Count == 1)
                        {
                            tipo_empaque = TipoEmpaque.Obtener((int)tipos_empaques.Rows[0]["id"]);
                            Cargar();
                        }
                        else
                        {
                            frmResultadosBusqueda f = new frmResultadosBusqueda(tipos_empaques);
                            var result = f.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                tipo_empaque = TipoEmpaque.Obtener(f.id);
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
            tipo_empaque = new TipoEmpaque();
            Cargar(true);
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && tipo_empaque.id == 0)
                Buscar();
        }
    }
}