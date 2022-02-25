using NoriSDK;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Nori
{
	public partial class frmSeleccionarSucural : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		public frmSeleccionarSucural()
		{
			InitializeComponent();
			this.MetodoDinamico();

			Cargar();

			cbAlmacenes.EditValue = Program.Nori.UsuarioAutenticado.almacen_id;
		}

		private void Cargar()
		{
			try
			{
				cbAlmacenes.Properties.DataSource = Almacen.Almacenes().Where(x => x.activo == true && x.transito == false).Select(x => new { x.id, x.codigo, x.nombre }).ToList();
				cbAlmacenes.Properties.ValueMember = "id";
				cbAlmacenes.Properties.DisplayMember = "nombre";
			} catch { }
		}

		private void frmSeleccionarSucural_Load(object sender, EventArgs e)
		{
			this.Activate();
		}

		private void btnAceptar_Click(object sender, EventArgs e)
		{
			Program.Nori.UsuarioAutenticado.almacen_id = (int)cbAlmacenes.EditValue;
			Hide();
		}
	}
}