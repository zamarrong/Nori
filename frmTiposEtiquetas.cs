using NoriSDK;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Nori
{
    public partial class frmTiposEtiquetas : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        Etiqueta.Tipo tipo = new Etiqueta.Tipo();

        public frmTiposEtiquetas(int id = 0)
        {
            InitializeComponent();
			this.MetodoDinamico();

            if (id != 0)
            {
                tipo = Etiqueta.Tipo.Obtener(id);
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
            lblID.Text = tipo.id.ToString();

            txtNombre.Text = tipo.nombre;
            txtFormato.Text = tipo.formato;

            cbActivo.Checked = tipo.activo;

            lblFechaActualizacion.Text = tipo.fecha_actualizacion.ToShortDateString();

            if (nuevo)
            {
                bbiNuevo.Enabled = false;
                bbiGuardar.Enabled = true;
                bbiGuardarCerrar.Enabled = true;
                bbiGuardarNuevo.Enabled = true;
                txtFormato.Focus();
            }
            else
            {
                if (busqueda)
                {
                    bbiNuevo.Enabled = true;
                    bbiGuardar.Enabled = false;
                    bbiGuardarCerrar.Enabled = false;
                    bbiGuardarNuevo.Enabled = false;
                    txtFormato.Focus();
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
            tipo.nombre = txtNombre.Text;
            tipo.formato = txtFormato.Text;
            tipo.activo = cbActivo.Checked;
        }

        private bool Guardar()
        {
            try
            {
                if (MessageBox.Show("¿Desea guardar los cambios?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Llenar();
                    if (tipo.id != 0)
                        return tipo.Actualizar();
                    else
                        return tipo.Agregar();
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
                tipo = new Etiqueta.Tipo();
                Cargar();
            }
        }

        private void bbiPrimero_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                tipo = Etiqueta.Tipo.Tipos().OrderBy(x => x.id).First();
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
                tipo = Etiqueta.Tipo.Tipos().Where(x => x.id < tipo.id).OrderByDescending(x => x.id).First();
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
                tipo = Etiqueta.Tipo.Tipos().Where(x => x.id > tipo.id).First();
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
                tipo = Etiqueta.Tipo.Tipos().OrderByDescending(x => x.id).First();
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
                if (tipo.id != 0)
                {
                    tipo = new Etiqueta.Tipo();
                    Cargar(false, true);
                }
                else
                {
                    object p = new { fields = "id, nombre, activo", like = true };
                    object o = new { nombre = txtNombre.Text };
                    DataTable tipos = Utilidades.Busqueda("tipos", o, p);
                    if (tipos.Rows.Count > 0)
                    {
                        if (tipos.Rows.Count == 1)
                        {
                            tipo = Etiqueta.Tipo.Obtener((int)tipos.Rows[0]["id"]);
                            Cargar();
                        }
                        else
                        {
                            frmResultadosBusqueda f = new frmResultadosBusqueda(tipos);
                            var result = f.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                tipo = Etiqueta.Tipo.Obtener(f.id);
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
            tipo = new Etiqueta.Tipo();
            Cargar(true);
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && tipo.id == 0)
                Buscar();
        }

        private void btnInforme_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = Program.Nori.Configuracion.directorio_informes;
            dialog.Filter = "Archivos de informe (*.repx) | *.repx";
            dialog.Title = "Por favor seleccione un informe.";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtFormato.Text = dialog.SafeFileName;
            }
        }

        private void btnEditarInforme_Click(object sender, EventArgs e)
        {
            if (txtFormato.Text.Length > 0)
            {
                frmDiseñadorInformes f = new frmDiseñadorInformes();
                f.AbrirInforme(txtFormato.Text);
                f.Show();
            }
        }
    }
}