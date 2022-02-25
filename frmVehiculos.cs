using NoriSDK;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Nori
{
    public partial class frmVehiculos : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        Vehiculo vehiculo = new Vehiculo();

        public frmVehiculos(int id = 0)
        {
            InitializeComponent();
            this.MetodoDinamico();

            if (id != 0)
            {
                vehiculo = Vehiculo.Obtener(id);
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
            lblID.Text = vehiculo.id.ToString();

            txtCodigo.Text = vehiculo.codigo;
            txtNombre.Text = vehiculo.nombre;
            txtModelo.Text = vehiculo.modelo.ToString();
            txtConfiguracionVehicular.Text = vehiculo.configuracion_vehicular;
            txtNumeroPlacas.Text = vehiculo.numero_placas;
            txtPermisoSCT.Text = vehiculo.permiso_sct;
            txtNumeroPermisoSCT.Text = vehiculo.numero_permiso_sct;
            txtNumeroPoliza.Text = vehiculo.numero_poliza;
            txtAseguradora.Text = vehiculo.aseguradora;

            cbActivo.Checked = vehiculo.activo;

            lblFechaActualizacion.Text = vehiculo.fecha_actualizacion.ToShortDateString();

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
            vehiculo.codigo = txtCodigo.Text;
            vehiculo.nombre = txtNombre.Text;

            vehiculo.modelo = int.Parse(txtModelo.Text);
            vehiculo.configuracion_vehicular = txtConfiguracionVehicular.Text;
            vehiculo.numero_placas = txtNumeroPlacas.Text;
            vehiculo.permiso_sct = txtPermisoSCT.Text;
            vehiculo.numero_permiso_sct = txtNumeroPermisoSCT.Text;
            vehiculo.numero_poliza = txtNumeroPoliza.Text;
            vehiculo.aseguradora = txtAseguradora.Text;

            vehiculo.activo = cbActivo.Checked;
        }

        private bool Guardar()
        {
            try
            {
                if (MessageBox.Show("¿Desea guardar los cambios?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Llenar();
                    if (vehiculo.id != 0)
                        return vehiculo.Actualizar();
                    else
                        return vehiculo.Agregar();
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
                vehiculo = new Vehiculo();
                Cargar();
            }
        }

        private void bbiPrimero_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                vehiculo = Vehiculo.Vehiculos().OrderBy(x => x.id).First();
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
                vehiculo = Vehiculo.Vehiculos().Where(x => x.id < vehiculo.id).OrderByDescending(x => x.id).First();
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
                vehiculo = Vehiculo.Vehiculos().Where(x => x.id > vehiculo.id).First();
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
                vehiculo = Vehiculo.Vehiculos().OrderByDescending(x => x.id).First();
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
                if (vehiculo.id != 0)
                {
                    vehiculo = new Vehiculo();
                    Cargar(false, true);
                }
                else
                {
                    object p = new { fields = "id, codigo, nombre, activo", like = true };
                    object o = new { codigo = txtCodigo.Text, nombre = txtNombre.Text };
                    DataTable vehiculos = Utilidades.Busqueda("vehiculos", o, p);
                    if (vehiculos.Rows.Count > 0)
                    {
                        if (vehiculos.Rows.Count == 1)
                        {
                            vehiculo = Vehiculo.Obtener((int)vehiculos.Rows[0]["id"]);
                            Cargar();
                        }
                        else
                        {
                            frmResultadosBusqueda f = new frmResultadosBusqueda(vehiculos);
                            var result = f.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                vehiculo = Vehiculo.Obtener(f.id);
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
            vehiculo = new Vehiculo();
            Cargar(true);
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && vehiculo.id == 0)
                Buscar();
        }
    }
}