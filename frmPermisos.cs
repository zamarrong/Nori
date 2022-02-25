using NoriSDK;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Nori
{
	public partial class frmPermisos : DevExpress.XtraEditors.XtraForm
	{
		public frmPermisos()
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

			Dictionary<string, string> objetos = new Dictionary<string, string>();

			objetos.Add("SN", "Socio de negocio");
			Documento.Clase.Clases().ForEach(x => objetos.Add(x.clase, x.nombre));

			cbObjetos.DataSource = objetos;
			cbObjetos.ValueMember = "Key";
			cbObjetos.DisplayMember = "Value";
		}

		private void Cargar()
		{
			gcPermisos.DataSource = Utilidades.EjecutarQuery("SELECT * FROM permisos");
			gcPermisos.RefreshDataSource();
		}

		private void gcPermisos_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
		{
			try
			{
				DataRow row = gvPermisos.GetDataRow(gvPermisos.GetSelectedRows()[0]);
				gvPermisos.CloseEditor();

				int id = 0;
				int.TryParse(row["id"].ToString(), out id);

				Permiso permiso = Permiso.Obtener(id);

				if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.EndEdit)
				{
					permiso.usuario_id = (int)row["usuario_id"];
					permiso.objeto = (string)row["objeto"];
					permiso.agregar = (bool)row["agregar"];
					permiso.actualizar = (bool)row["actualizar"];
                    permiso.cancelar = (bool)row["cancelar"];
                    permiso.eliminar = (bool)row["eliminar"];
                    permiso.autorizacion = (bool)row["autorizacion"];
                    permiso.usuario_autorizacion_id = (int)row["usuario_autorizacion_id"];
                    permiso.activo = (bool)row["activo"];

					if (permiso.id != 0)
						permiso.Actualizar();
					else
						permiso.Agregar();
				}
				else if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
				{
					if (permiso.id != 0)
						permiso.Eliminar();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void gvPermisos_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
		{
			gvPermisos.SetRowCellValue(e.RowHandle, "agregar", 0);
			gvPermisos.SetRowCellValue(e.RowHandle, "actualizar", 0);
            gvPermisos.SetRowCellValue(e.RowHandle, "cancelar", 0);
            gvPermisos.SetRowCellValue(e.RowHandle, "eliminar", 0);
            gvPermisos.SetRowCellValue(e.RowHandle, "autorizacion", 0);
            gvPermisos.SetRowCellValue(e.RowHandle, "activo", 1);
		}
	}
}