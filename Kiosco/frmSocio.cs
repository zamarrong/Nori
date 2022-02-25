using NoriSDK;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Nori.Kiosco
{
    public partial class frmSocio : DevExpress.XtraEditors.XtraForm
    {
        public string codigo_socio;
        public Socio socio_busqueda = new Socio();
        Documento documento = new Documento();
        public frmSocio()
        {
            InitializeComponent();
			this.MetodoDinamico();
        }

        private void textEdit1_TextChanged(object sender, EventArgs e)
        {
            btnBuscar.Enabled = true;
        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {
            btnBuscar.Enabled = true;
        }
        private void EstablecerSocio(Socio socio)
        {
            try
            {
                if (!documento.EstablecerSocio(socio))
                    MessageBox.Show(NoriSDK.Nori.ObtenerUltimoError().Message);
                else
                {
                    socio.CopyProperties(socio_busqueda);
                    txtCodigo.Text = socio.codigo;
                    txtNombre.Text = socio.nombre;
                    txtRFC.Text = socio.rfc;
                    btnAceptar.Enabled = true;
                    btnAlta.Enabled = true;
                }
            }
            catch
            {
                return;
            }            
        }
        private void BuscarSocios(string q, bool rfc = false)
        {
            string query = string.Empty;

            if (rfc)
                query = string.Format("SELECT id, codigo, nombre, rfc FROM socios WHERE rfc like '%{0}%' AND tipo = 'C' AND activo = 1", q.Replace(" ", "%"));
            else
                query = string.Format("SELECT id, codigo, nombre, rfc FROM socios WHERE codigo like '%{0}%' OR nombre LIKE '%{0}%' AND tipo = 'C' AND activo = 1", q.Replace(" ", "%"));

            DataTable socios = Utilidades.EjecutarQuery(query);

            if (socios.Rows.Count > 0)
            {
                if (socios.Rows.Count == 1)
                    socio_busqueda = Socio.Obtener((int)socios.Rows[0]["id"]);
                else
                {
                    frmResultadosBusqueda f = new frmResultadosBusqueda(socios);
                    var result = f.ShowDialog();
                    if (result == DialogResult.OK)
                        socio_busqueda = Socio.Obtener(f.id);
                }

                if (!socio_busqueda.activo)
                {
                    lblError.Visible = true;
                    lblError.Text = "El socio esta inactivo, favor de acudir a cobranza.";
                }
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = string.Format("No se encontraron resultados para los datos proporcionados.");
            }
        }

        private void BuscarSocio()
        {
            try
            {
                if (txtCodigo.Text.Length > 0)
                    EstablecerSocio(Socio.Socios().Where(x => x.codigo == txtCodigo.Text).First());
                else if (txtNombre.Text.Length > 0)
                {
                    BuscarSocios(txtNombre.Text);
                    EstablecerSocio(Socio.Socios().Where(x => x.codigo == socio_busqueda.codigo).First());
                }
                else if (txtRFC.Text.Length > 0)
                {
                    BuscarSocios(txtRFC.Text, true);
                    EstablecerSocio(Socio.Socios().Where(x => x.codigo == socio_busqueda.codigo).First());
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Favor de capturar un código o un nombre.";
                }
            }
            catch
            {
                lblError.Visible = true;
                lblError.Text = "Socio no encontrado.";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblError.Visible = false;
        }

        private void frmSocio_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void btnDatos_Click(object sender, EventArgs e)
        {
            AltaSocios(true);
        }
        private void AltaSocios(bool actualizar= false)
        {
            frmAltaRapidaSocio frm = new frmAltaRapidaSocio();
            if (btnAlta.Text == "Datos")
            {                
                frm.socio = socio_busqueda;
            }
            frm.ShowDialog();
        }

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            Funciones.AbrirTecladoTactil();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Length > 0)
                EstablecerSocio(Socio.Socios().Where(x => x.codigo == txtCodigo.Text).First());
            else if (txtNombre.Text.Length > 0)
            {
                BuscarSocios(txtNombre.Text);
                EstablecerSocio(Socio.Socios().Where(x => x.codigo == socio_busqueda.codigo).First());
            }
            else if (txtRFC.Text.Length > 0)
            {
                BuscarSocios(txtRFC.Text, true);
                EstablecerSocio(Socio.Socios().Where(x => x.codigo == socio_busqueda.codigo).First());
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "Favor de capturar un codigo o un nombre";
            }
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            AltaSocios();
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                BuscarSocio();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            codigo_socio = txtCodigo.Text;
            DialogResult = DialogResult.OK;
        }
    }
}
