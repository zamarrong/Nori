using NoriSDK;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Nori
{
	public partial class frmUsuariosTiposMetodosPago : DevExpress.XtraEditors.XtraForm
	{
		public frmUsuariosTiposMetodosPago()
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

			cbTiposMetodosPago.DataSource = MetodoPago.Tipo.Tipos().Select(x => new { x.id, x.codigo, x.nombre}).ToList();
			cbTiposMetodosPago.ValueMember = "id";
			cbTiposMetodosPago.DisplayMember = "nombre";
		}

		private void Cargar()
		{
			gc.DataSource = Utilidades.EjecutarQuery("SELECT * FROM usuarios_tipos_metodos_pago");
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

				Usuario.TipoMetodoPago tipo_metodo_pago = Usuario.TipoMetodoPago.Obtener(id);

				if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.EndEdit)
				{
					tipo_metodo_pago.usuario_id = (int)row["usuario_id"];
					tipo_metodo_pago.tipo_metodo_pago_id = (int)row["tipo_metodo_pago_id"];

					if (tipo_metodo_pago.id != 0)
						tipo_metodo_pago.Actualizar();
					else
						tipo_metodo_pago.Agregar();
				}
				else if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
				{
					if (tipo_metodo_pago.id != 0)
						tipo_metodo_pago.Eliminar();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}