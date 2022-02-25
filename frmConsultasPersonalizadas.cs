using NoriSDK;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Nori
{
    public partial class frmConsultasPersonalizadas : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        ConsultaPersonalizada consulta_personalizada = new ConsultaPersonalizada();

        public frmConsultasPersonalizadas(int id = 0)
        {
            InitializeComponent();
            this.MetodoDinamico();

            if (id != 0)
            {
                consulta_personalizada = ConsultaPersonalizada.Obtener(id);
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
            lblID.Text = consulta_personalizada.id.ToString();

            txtNombre.Text = consulta_personalizada.nombre;
            txtContexto.Text = consulta_personalizada.contexto;
            txtQuery.Text = consulta_personalizada.query;

            cbActivo.Checked = consulta_personalizada.activo;

            lblFechaActualizacion.Text = consulta_personalizada.fecha_actualizacion.ToShortDateString();

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
            consulta_personalizada.nombre = txtNombre.Text;
            consulta_personalizada.contexto = txtContexto.Text;
            consulta_personalizada.query = txtQuery.Text;
            consulta_personalizada.activo = cbActivo.Checked;
        }

        private bool Guardar()
        {
            try
            {
                if (MessageBox.Show("¿Desea guardar los cambios?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Llenar();
                    if (consulta_personalizada.id != 0)
                        return consulta_personalizada.Actualizar();
                    else
                        return consulta_personalizada.Agregar();
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
                consulta_personalizada = new ConsultaPersonalizada();
                Cargar();
            }
        }

        private void bbiPrimero_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                consulta_personalizada = ConsultaPersonalizada.ConsultasPersonalizadas().OrderBy(x => x.id).First();
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
                consulta_personalizada = ConsultaPersonalizada.ConsultasPersonalizadas().Where(x => x.id < consulta_personalizada.id).OrderByDescending(x => x.id).First();
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
                consulta_personalizada = ConsultaPersonalizada.ConsultasPersonalizadas().Where(x => x.id > consulta_personalizada.id).First();
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
                consulta_personalizada = ConsultaPersonalizada.ConsultasPersonalizadas().OrderByDescending(x => x.id).First();
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
                if (consulta_personalizada.id != 0)
                {
                    consulta_personalizada = new ConsultaPersonalizada();
                    Cargar(false, true);
                }
                else
                {
                    object p = new { fields = "id, nombre, activo", like = true };
                    object o = new { nombre = txtNombre.Text };
                    DataTable consultas_personalizadas = Utilidades.Busqueda("consultas_personalizadas", o, p);
                    if (consultas_personalizadas.Rows.Count > 0)
                    {
                        if (consultas_personalizadas.Rows.Count == 1)
                        {
                            consulta_personalizada = ConsultaPersonalizada.Obtener((int)consultas_personalizadas.Rows[0]["id"]);
                            Cargar();
                        }
                        else
                        {
                            frmResultadosBusqueda f = new frmResultadosBusqueda(consultas_personalizadas);
                            var result = f.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                consulta_personalizada = ConsultaPersonalizada.Obtener(f.id);
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
            consulta_personalizada = new ConsultaPersonalizada();
            Cargar(true);
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && consulta_personalizada.id == 0)
                Buscar();
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            consulta_personalizada.query = txtQuery.Text;
            gcResultados.DataSource = consulta_personalizada.Ejecutar();
            gcResultados.RefreshDataSource();
            gvResultados.Columns.Clear();
            gvResultados.PopulateColumns();
        }

        private void btnXSLX_Click(object sender, EventArgs e)
        {
            try
            {
                string archivo = string.Format(@"{0}\{1}.xlsx", Program.Nori.Configuracion.directorio_documentos, consulta_personalizada.id);
                gcResultados.ExportToXlsx(archivo);
                Funciones.AbrirArchivo(archivo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            try
            {
                string archivo = string.Format(@"{0}\{1}.pdf", Program.Nori.Configuracion.directorio_documentos, consulta_personalizada.id);
                gcResultados.ExportToPdf(archivo);
                Funciones.AbrirArchivo(archivo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}