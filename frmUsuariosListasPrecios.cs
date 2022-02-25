using NoriSDK;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Nori
{
	public partial class frmUsuariosListasPrecios : DevExpress.XtraEditors.XtraForm
	{
		public frmUsuariosListasPrecios()
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

			cbListasPrecios.DataSource = ListaPrecio.ListasPrecios().Select(x => new { x.id, x.codigo, x.nombre}).ToList();
			cbListasPrecios.ValueMember = "id";
			cbListasPrecios.DisplayMember = "nombre";
		}

		private void Cargar()
		{
			gc.DataSource = Utilidades.EjecutarQuery("SELECT * FROM usuarios_listas_precios");
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

				Usuario.ListaPrecio lista_precio = Usuario.ListaPrecio.Obtener(id);

				if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.EndEdit)
				{
					lista_precio.usuario_id = (int)row["usuario_id"];
					lista_precio.lista_precio_id = (int)row["lista_precio_id"];

					if (lista_precio.id != 0)
						lista_precio.Actualizar();
					else
						lista_precio.Agregar();
				}
				else if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
				{
					if (lista_precio.id != 0)
						lista_precio.Eliminar();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}