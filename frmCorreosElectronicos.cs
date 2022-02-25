using NoriSDK;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Nori
{
	public partial class frmCorreosElectronicos : DevExpress.XtraEditors.XtraForm
	{
		public frmCorreosElectronicos()
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
		}

		private void Cargar()
		{
			gcCorreosElectronicos.DataSource = Utilidades.EjecutarQuery("SELECT * FROM correos_electronicos");
			gcCorreosElectronicos.RefreshDataSource();
		}

		private void gcCorreosElectronicos_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
		{
			try
			{
				DataRow row = gvCorreosElectronicos.GetDataRow(gvCorreosElectronicos.GetSelectedRows()[0]);
				gvCorreosElectronicos.CloseEditor();

				int id = 0;
				int.TryParse(row["id"].ToString(), out id);

				Usuario.CorreoElectronico correo_electronico = Usuario.CorreoElectronico.Obtener(id);

				if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.EndEdit)
				{
					correo_electronico.usuario_id = (int)row["usuario_id"];
					correo_electronico.servidor = row["servidor"].ToString();
					correo_electronico.puerto = (int)row["puerto"];
					correo_electronico.ssl = (bool)row["ssl"];
					correo_electronico.usuario = row["usuario"].ToString();
					correo_electronico.contraseña = row["contraseña"].ToString();
					correo_electronico.remitente = row["remitente"].ToString();
					correo_electronico.asunto = row["asunto"].ToString();
					correo_electronico.mensaje = row["mensaje"].ToString();
					correo_electronico.activo = (bool)row["activo"];

					if (correo_electronico.id != 0)
						correo_electronico.Actualizar();
					else
						correo_electronico.Agregar();
				}
				else if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
				{
					if (correo_electronico.id != 0)
						correo_electronico.Eliminar();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}