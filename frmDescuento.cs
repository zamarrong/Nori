using NoriSDK;
using System.Windows.Forms;

namespace Nori
{
	public partial class frmDescuento : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		public decimal descuento { get; internal set; }
		public decimal total { internal get; set; }
		public frmDescuento()
		{
			InitializeComponent();
			this.MetodoDinamico();
			txtDescuento.Focus();
		}

		private void cbPorcentaje_CheckedChanged(object sender, System.EventArgs e)
		{
			if (cbPorcentaje.Checked && decimal.Parse(txtDescuento.EditValue.ToString()) > 100)
				txtDescuento.EditValue = 100;
		}

		private void btnAceptar_Click(object sender, System.EventArgs e)
		{
			if (cbPorcentaje.Checked && decimal.Parse(txtDescuento.EditValue.ToString()) > 100)
				txtDescuento.EditValue = 100;

			if (cbPorcentaje.Checked)
				descuento = (total / 100) * decimal.Parse(txtDescuento.EditValue.ToString());
			else
				descuento = decimal.Parse(txtDescuento.EditValue.ToString());

			decimal porcentaje_descuento = (cbPorcentaje.Checked == true) ? decimal.Parse(txtDescuento.EditValue.ToString()) : (total * 100) / decimal.Parse(txtDescuento.EditValue.ToString());

			if (MessageBox.Show(string.Format("Se realizara un descuento de {0}% ({1}), ¿Desea continuar?", decimal.Parse(txtDescuento.EditValue.ToString()), descuento.ToString("c2")), Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				Autorizacion autorizacion = new Autorizacion();

				autorizacion.codigo = "DSCTO";
				autorizacion.referencia = string.Format("Descuento global al documento de {0}% ({1}), Total del documento {2}", decimal.Parse(txtDescuento.EditValue.ToString()), descuento.ToString("c2"), total.ToString("c2"));
				autorizacion.comentario = Microsoft.VisualBasic.Interaction.InputBox("Comentario descuento global (Opcional)", "");

				autorizacion.Agregar();

				if (!autorizacion.autorizado)
				{
					frmSolicitarAutorizacion f = new frmSolicitarAutorizacion(autorizacion);
					f.ShowDialog();
					autorizacion.autorizado = (f.DialogResult == DialogResult.OK) ? true : false;
				}

				if (!autorizacion.autorizado)
					DialogResult = DialogResult.Cancel;
				else
					DialogResult = DialogResult.OK;

			}
		}

		private void btnCancelar_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private void frmDescuento_Load(object sender, System.EventArgs e)
		{
			lblTotal.Text = string.Format("Total {0}", total.ToString("c2"));
		}
	}
}