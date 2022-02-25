using NoriSDK;
using System;
using System.Windows.Forms;

namespace Nori
{
	public partial class frmAutenticar : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		public Usuario usuario { get; set; }
		public frmAutenticar()
		{
			InitializeComponent();
			this.MetodoDinamico();
		}
		private void btnAutenticar_Click(object sender, EventArgs e)
		{
			if (usuario.id == 0)
				usuario = Usuario.Obtener(txtUsuario.Text);

			if (usuario.id != 0)
			{
				if (usuario.ObtenerContraseña() == txtContraseña.Text)
				{
					DialogResult = DialogResult.OK;
				}
				else
				{
					txtContraseña.Text = string.Empty;
					txtContraseña.Focus();
					MessageBox.Show(NoriSDK.Nori.ObtenerUltimoError().Message, Text);
				}
			}
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private void frmAutenticar_Load(object sender, EventArgs e)
		{
			txtUsuario.Text = usuario.usuario;
			txtContraseña.Focus();

			if (usuario.id != 0)
				txtUsuario.Enabled = false;
		}
	}
}