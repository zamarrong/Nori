using NoriSDK;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Nori
{
	public partial class frmUsuariosAlmacenes : DevExpress.XtraEditors.XtraForm
	{
		public frmUsuariosAlmacenes()
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

			cbAlmacenes.DataSource = Almacen.Almacenes().Select(x => new { x.id, x.codigo, x.nombre}).ToList();
			cbAlmacenes.ValueMember = "id";
			cbAlmacenes.DisplayMember = "nombre";
		}

		private void Cargar()
		{
			gc.DataSource = Utilidades.EjecutarQuery("SELECT * FROM usuarios_almacenes");
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

				Usuario.Almacen almacen = Usuario.Almacen.Obtener(id);

				if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.EndEdit)
				{
					almacen.usuario_id = (int)row["usuario_id"];
					almacen.almacen_id = (int)row["almacen_id"];

					if (almacen.id != 0)
						almacen.Actualizar();
					else
						almacen.Agregar();
				}
				else if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
				{
					if (almacen.id != 0)
						almacen.Eliminar();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}