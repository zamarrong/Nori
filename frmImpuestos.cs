using NoriSDK;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Nori
{
    public partial class frmImpuestos : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        Impuesto impuesto = new Impuesto();

        public frmImpuestos(int id = 0)
        {
            InitializeComponent();
			this.MetodoDinamico();
            if (id != 0)
            {
                impuesto = Impuesto.Obtener(id);
                Cargar();
            }
            else
            {
                Cargar(false, true);
            }

            Permisos();

            CargarListas();
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

        private void CargarListas()
        {
            cbTiposFactores.Properties.DataSource = Impuesto.TipoFactor.Tipos();
            cbTiposFactores.Properties.ValueMember = "tipo";
            cbTiposFactores.Properties.DisplayMember = "nombre";
        }

        private void Cargar(bool nuevo = false, bool busqueda = false)
        {
            lblID.Text = impuesto.id.ToString();

            txtCodigo.Text = impuesto.codigo;
            cbTiposFactores.EditValue = impuesto.tipo_factor;
            txtNombre.Text = impuesto.nombre;
            cbCompra.Checked = impuesto.compra;
            cbVenta.Checked = impuesto.venta;
            txtPorcentaje.Text = impuesto.porcentaje.ToString();

            cbActivo.Checked = impuesto.activo;

            lblFechaActualizacion.Text = impuesto.fecha_actualizacion.ToShortDateString();

            impuesto.ObtenerLineas();

            gcLineas.DataSource = impuesto.lineas;
            gcLineas.RefreshDataSource();

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
            impuesto.codigo = txtCodigo.Text;
            impuesto.tipo_factor = (char)cbTiposFactores.EditValue;
            impuesto.nombre = txtNombre.Text;
            impuesto.compra = cbCompra.Checked;
            impuesto.venta = cbVenta.Checked;
            impuesto.porcentaje = decimal.Parse(txtPorcentaje.Text);
            impuesto.activo = cbActivo.Checked;
        }

        private bool Guardar()
        {
            try
            {
                if (MessageBox.Show("¿Desea guardar los cambios?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Llenar();
                    if (impuesto.id != 0)
                    {
                        return impuesto.Actualizar();
                    }
                    else
                    {
                        return impuesto.Agregar();
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
                impuesto = new Impuesto();
                Cargar();
            }
        }

        private void bbiPrimero_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                impuesto = Impuesto.Impuestos().OrderBy(x => x.id).First();
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
                impuesto = Impuesto.Impuestos().Where(x => x.id < impuesto.id).OrderByDescending(x => x.id).First();
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
                impuesto = Impuesto.Impuestos().Where(x => x.id > impuesto.id).First();
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
                impuesto = Impuesto.Impuestos().OrderByDescending(x => x.id).First();
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
                if (impuesto.id != 0)
                {
                    impuesto = new Impuesto();
                    Cargar(false, true);
                }
                else
                {
                    object p = new { fields = "id, codigo, nombre", like = true };
                    object o = new { codigo = txtCodigo.Text, nombre = txtNombre.Text };
                    DataTable impuestos = Utilidades.Busqueda("impuestos", o, p);
                    if (impuestos.Rows.Count > 0)
                    {
                        if (impuestos.Rows.Count == 1)
                        {
                            impuesto = Impuesto.Obtener((int)impuestos.Rows[0]["id"]);
                            Cargar();
                        }
                        else
                        {
                            frmResultadosBusqueda f = new frmResultadosBusqueda(impuestos);
                            var result = f.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                impuesto = Impuesto.Obtener(f.id);
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
            impuesto = new Impuesto();
            Cargar(true);
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && impuesto.id == 0)
                Buscar();
        }
    }
}