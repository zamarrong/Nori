using NoriSDK;
using System.Windows.Forms;

namespace Nori.PuntoVenta
{
    public partial class frmIngresosEgresos : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        Flujo flujo = new Flujo();
        public frmIngresosEgresos()
        {
            InitializeComponent();
            CargarListas();
        }

        private void CargarListas()
        {
            cbConceptos.Properties.DataSource = Flujo.ConceptoFlujo.Listar();
            cbConceptos.Properties.ValueMember = "codigo";
            cbConceptos.Properties.DisplayMember = "nombre";
        }

        private void btnAceptar_Click(object sender, System.EventArgs e)
        {
            
        }

        private void btnCancelar_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}