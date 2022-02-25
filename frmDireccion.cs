using NoriSDK;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Nori
{
    public partial class frmDireccion : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Socio.Direccion direccion { get; set; }
        public frmDireccion()
        {
            InitializeComponent();
			this.MetodoDinamico();

            CargarListas();
        }

        private void bbiGuardarCerrar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Guardar())
                Close();
            else
                MessageBox.Show(NoriSDK.Nori.ObtenerUltimoError().Message, Text);
        }

        private void CargarListas()
        {
            cbPaises.Properties.DataSource = Pais.Paises().Select(x => new { x.id, x.nombre });
            cbPaises.Properties.ValueMember = "id";
            cbPaises.Properties.DisplayMember = "nombre";
            cbPaises.EditValue = 1;
        }

        private void Cargar()
        {
            txtNombre.Text = direccion.nombre;
            txtCalle.Text = direccion.calle;
            txtNumeroExterior.Text = direccion.numero_exterior;
            txtNumeroInterior.Text = direccion.numero_interior;
            txtCP.Text = direccion.cp;
            txtColonia.Text = direccion.colonia;
            txtCiudad.Text = direccion.ciudad;
            txtMunicipio.Text = direccion.municipio;
            txtEntreCalles.Text = direccion.entre_calles;
            txtReferencias.Text = direccion.referencias;
            cbPaises.EditValue = direccion.pais_id;
            cbEstados.EditValue = direccion.estado_id;
        }

        private void Llenar()
        {
            try
            {
                //Dirección
                direccion.nombre = txtNombre.Text;
                direccion.calle = txtCalle.Text;
                direccion.numero_exterior = txtNumeroExterior.Text;
                direccion.numero_interior = txtNumeroInterior.Text;
                direccion.entre_calles = txtEntreCalles.Text;
                direccion.referencias = txtReferencias.Text;
                direccion.cp = txtCP.Text;
                direccion.colonia = txtColonia.Text;
                direccion.ciudad = txtCiudad.Text;
                direccion.municipio = txtMunicipio.Text;
                direccion.estado_id = (int)cbEstados.EditValue;
                direccion.pais_id = (int)cbPaises.EditValue;

                //if (Program.Nori.UsuarioAutenticado.socio_id == direccion.socio_id)
                //    direccion.socio_id = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool Guardar()
        {
            try
            {

                if (MessageBox.Show("¿Desea guardar los cambios?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Llenar();
                    if (direccion.id != 0)
                        return direccion.Actualizar();
                    else
                        return direccion.Agregar();
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

        private void cbPaises_EditValueChanged(object sender, System.EventArgs e)
        {
            cbEstados.Properties.DataSource = Estado.Estados().Where(x => x.pais_id == (int)cbPaises.EditValue).Select(x => new { x.id, x.nombre });
            cbEstados.Properties.ValueMember = "id";
            cbEstados.Properties.DisplayMember = "nombre";
            cbEstados.EditValue = 1;
        }

        private void frmDireccion_Load(object sender, System.EventArgs e)
        {
            Cargar();
        }
    }
}
