using NoriSDK;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Nori
{
    public partial class frmVendedores : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        Vendedor vendedor = new Vendedor();

        public frmVendedores(int id = 0)
        {
            InitializeComponent();
			this.MetodoDinamico();
            CargarListas();
            if (id != 0)
            {
                vendedor = Vendedor.Obtener(id);
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
            lblID.Text = vendedor.id.ToString();

            cbZonas.EditValue = vendedor.zona_id;
            cbRutas.EditValue = vendedor.ruta_id;
            txtCodigo.Text = vendedor.codigo.ToString();
            txtNombre.Text = vendedor.nombre;
            txtPorcentajeComision.Text = vendedor.porcentaje_comision.ToString();
            cbForaneo.Checked = vendedor.foraneo;
            cbActivo.Checked = vendedor.activo;

            lblFechaActualizacion.Text = vendedor.fecha_actualizacion.ToShortDateString();

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

        private void CargarListas()
        {
            try
            {
                cbRutas.Properties.DataSource = Ruta.Rutas().Where(x => x.activo == true).Select(x => new { x.id, x.codigo, x.nombre }).ToList();
                cbRutas.Properties.ValueMember = "id";
                cbRutas.Properties.DisplayMember = "nombre";

                object p = new { fields = "id, codigo, nombre" };
                object o = new { activo = 1 };

                cbZonas.Properties.DataSource = Utilidades.Busqueda("zonas", o, p);
                cbZonas.Properties.ValueMember = "id";
                cbZonas.Properties.DisplayMember = "nombre";
            } catch { }
        }

        private void Llenar()
        {
            vendedor.zona_id = (int)cbZonas.EditValue;
            vendedor.ruta_id = (int)cbRutas.EditValue;
            vendedor.codigo = short.Parse(txtCodigo.Text);
            vendedor.nombre = txtNombre.Text;
            vendedor.porcentaje_comision = decimal.Parse(txtPorcentajeComision.Text.ToString());
            vendedor.foraneo = cbForaneo.Checked;
            vendedor.activo = cbActivo.Checked;
        }

        private bool Guardar()
        {
            try
            {
                if (MessageBox.Show("¿Desea guardar los cambios?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Llenar();
                    if (vendedor.id != 0)
                    {
                        return vendedor.Actualizar();
                    }
                    else
                    {
                        return vendedor.Agregar();
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
                vendedor = new Vendedor();
                Cargar();
            }
        }

        private void bbiPrimero_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                vendedor = Vendedor.Vendedores().OrderBy(x => x.id).First();
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
                vendedor = Vendedor.Vendedores().Where(x => x.id < vendedor.id).OrderByDescending(x => x.id).First();
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
                vendedor = Vendedor.Vendedores().Where(x => x.id > vendedor.id).First();
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
                vendedor = Vendedor.Vendedores().OrderByDescending(x => x.id).First();
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
                if (vendedor.id != 0)
                {
                    vendedor = new Vendedor();
                    Cargar(false, true);
                }
                else
                {
                    object p = new { fields = "id, codigo, nombre, activo", like = true };
                    object o = new { codigo = int.Parse(txtCodigo.Text), nombre = txtNombre.Text };
                    DataTable vendedores = Utilidades.Busqueda("vendedores", o, p);
                    if (vendedores.Rows.Count > 0)
                    {
                        if (vendedores.Rows.Count == 1)
                        {
                            vendedor = Vendedor.Obtener((int)vendedores.Rows[0]["id"]);
                            Cargar();
                        }
                        else
                        {
                            frmResultadosBusqueda f = new frmResultadosBusqueda(vendedores);
                            var result = f.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                vendedor = Vendedor.Obtener(f.id);
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
            vendedor = new Vendedor();
            Cargar(true);
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && vendedor.id == 0)
                Buscar();
        }
    }
}