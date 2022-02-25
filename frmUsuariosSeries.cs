using NoriSDK;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Nori
{
	public partial class frmUsuariosSeries : DevExpress.XtraEditors.XtraForm
	{
		public frmUsuariosSeries()
		{
			InitializeComponent();
			this.MetodoDinamico();
			CargarListas();
			Cargar();
		}

		private void CargarListas()
		{
			cbUsuarios.DataSource = Usuario.Usuarios().Where(x => x.activo == true).Select(x => new { x.id, x.usuario }).ToList();
			cbUsuarios.ValueMember = "id";
			cbUsuarios.DisplayMember = "usuario";

			cbSeries.DataSource = Serie.Series().Select(x => new { x.id, x.codigo, x.clase, x.nombre}).ToList();
			cbSeries.ValueMember = "id";
			cbSeries.DisplayMember = "nombre";
		}

		private void Cargar()
		{
			gc.DataSource = Utilidades.EjecutarQuery("SELECT * FROM usuarios_series");
			gc.RefreshDataSource();
		}

		private void gc_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
		{
			try
			{
				DataRow row = gv.GetDataRow(gv.GetSelectedRows()[0]);
				gv.CloseEditor();

				int id = 0;
				int.TryParse(row["id"].ToString(), out id);

				Usuario.Serie serie = Usuario.Serie.Obtener(id);

				if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.EndEdit)
				{
					serie.usuario_id = (int)row["usuario_id"];
					serie.serie_id = (int)row["serie_id"];

					if (serie.id != 0)
						serie.Actualizar();
					else
						serie.Agregar();
				}
				else if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
				{
					if (serie.id != 0)
						serie.Eliminar();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}