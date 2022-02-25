using NoriSDK;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Nori
{
    public partial class frmConceptosFlujo : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        ConceptoFlujo concepto_flujo = new ConceptoFlujo();

        public frmConceptosFlujo(int id = 0)
        {
            InitializeComponent();

            cbTipos.Properties.DataSource = ConceptoFlujo.Tipo.Tipos();
            cbTipos.Properties.ValueMember = "tipo";
            cbTipos.Properties.DisplayMember = "nombre";

            if (id != 0)
            {
                concepto_flujo = ConceptoFlujo.Obtener(id);
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
            lblID.Text = concepto_flujo.id.ToString();

            cbTipos.EditValue = concepto_flujo.tipo;
            txtNombre.Text = concepto_flujo.nombre;

            lblFechaActualizacion.Text = concepto_flujo.fecha_actualizacion.ToShortDateString();

            if (nuevo)
            {
                bbiNuevo.Enabled = false;
                bbiGuardar.Enabled = true;
                bbiGuardarCerrar.Enabled = true;
                bbiGuardarNuevo.Enabled = true;
                cbTipos.Focus();
            }
            else
            {
                if (busqueda)
                {
                    bbiNuevo.Enabled = true;
                    bbiGuardar.Enabled = false;
                    bbiGuardarCerrar.Enabled = false;
                    bbiGuardarNuevo.Enabled = false;
                    cbTipos.Focus();
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
            concepto_flujo.tipo = (char)cbTipos.EditValue;
            concepto_flujo.nombre = txtNombre.Text;
        }

        private bool Guardar()
        {
            try
            {
                if (MessageBox.Show("¿Desea guardar los cambios?", this.Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Llenar();
                    if (concepto_flujo.id != 0)
                        return concepto_flujo.Actualizar();
                    else
                        return concepto_flujo.Agregar();
                }
                else
                    return false;
            }
            catch
            {
                MessageBox.Show(NoriSDK.Nori.ObtenerUltimoError().Message, this.Text);
                return false;
            }
        }

        private void bbiGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Guardar()) { Cargar(); } else { MessageBox.Show( "Error al guardar: " + NoriSDK.Nori.ObtenerUltimoError().Message, this.Text); };
        }

        private void bbiGuardarCerrar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Guardar())
                this.Close();
        }

        private void bbiGuardarNuevo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Guardar())
            {
                concepto_flujo = new ConceptoFlujo();
                Cargar();
            }
        }

        private void bbiPrimero_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                concepto_flujo = ConceptoFlujo.ConceptosFlujo.OrderBy(x => x.id).First();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                concepto_flujo = ConceptoFlujo.ConceptosFlujo.Where(x => x.id < concepto_flujo.id).OrderByDescending(x => x.id).First();
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
                concepto_flujo = ConceptoFlujo.ConceptosFlujo.Where(x => x.id > concepto_flujo.id).First();
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
                concepto_flujo = ConceptoFlujo.ConceptosFlujo.OrderByDescending(x => x.id).First();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                if (concepto_flujo.id != 0)
                {
                    concepto_flujo = new ConceptoFlujo();
                    Cargar(false, true);
                }
                else
                {
                    object p = new { fields = "id, tipo, nombre", like = true };
                    object o = new { nombre = txtNombre.Text };
                    DataTable conceptos_flujo = Utilidades.Busqueda("conceptos_flujo", o, p);
                    if (conceptos_flujo.Rows.Count > 0)
                    {
                        if (conceptos_flujo.Rows.Count == 1)
                        {
                            concepto_flujo = ConceptoFlujo.Obtener((int)conceptos_flujo.Rows[0]["id"]);
                            Cargar();
                        }
                        else
                        {
                            frmResultadosBusqueda f = new frmResultadosBusqueda(conceptos_flujo);
                            var result = f.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                concepto_flujo = ConceptoFlujo.Obtener(f.id);
                                Cargar();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron resultados", this.Text);
                    }
                }
            }
            catch { }
        }

        private void bbiNuevo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            concepto_flujo = new ConceptoFlujo();
            Cargar(true);
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && concepto_flujo.id == 0)
                Buscar();
        }
    }
}