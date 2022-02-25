using NoriSDK;
using System.Windows.Forms;

namespace Nori
{
	public partial class frmAutorizacionCredito : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		public Socio socio { private get; set; }
		public frmAutorizacionCredito()
		{
			InitializeComponent();
			this.MetodoDinamico();
		}

		private void btnAceptar_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.OK;
		}

		private void btnCancelar_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private void btnAutorizar_Click(object sender, System.EventArgs e)
		{
			Autorizacion autorizacion = new Autorizacion();

			autorizacion.codigo = "VEACR";
			autorizacion.referencia = string.Format("Venta a crédito con firma no autorizada al socio {0}", socio.codigo);
			autorizacion.comentario = Microsoft.VisualBasic.Interaction.InputBox("Comentario venta a crédito (Opcional)", "");

			autorizacion.Agregar();

			if (!autorizacion.autorizado)
			{
				frmSolicitarAutorizacion fa = new frmSolicitarAutorizacion(autorizacion);
				fa.ShowDialog();
				autorizacion.autorizado = (fa.DialogResult == DialogResult.OK) ? true : false;
			}

			if (autorizacion.autorizado)
			{
				DialogResult = DialogResult.OK;
			}
			else
			{
				DialogResult = DialogResult.Cancel;
				MessageBox.Show("No se autorizó este movimiento.");
			}
		}

		private void frmAutorizacionCredito_Load(object sender, System.EventArgs e)
		{
			pbImagen.LoadImage(socio.imagen);
		}
	}
}