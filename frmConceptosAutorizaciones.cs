using NoriSDK;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Nori
{
	public partial class frmConceptosAutorizaciones : DevExpress.XtraEditors.XtraForm
	{
		public frmConceptosAutorizaciones()
		{
			InitializeComponent();
			this.MetodoDinamico();
			CargarListas();
			Cargar();
		}

		private void CargarListas()
		{
			var usuarios = Usuario.Usuarios().Where(x => x.activo == true).Select(x => new { x.id, x.usuario }).ToList();
			usuarios.Insert(0, new { id = 0, usuario = "-- Cualquier usuario --" });
			cbUsuarios.DataSource = usuarios;
			cbUsuarios.ValueMember = "id";
			cbUsuarios.DisplayMember = "usuario";
		}

		private void Cargar()
		{
			gcConceptos.DataSource = Utilidades.EjecutarQuery("SELECT * FROM conceptos_autorizaciones");
			gcConceptos.RefreshDataSource();
		}

		private void gcCorreosElectronicos_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
		{
			try
			{
				DataRow row = gvConceptos.GetDataRow(gvConceptos.GetSelectedRows()[0]);
				gvConceptos.CloseEditor();

				Autorizacion.ConceptoAutorizacion concepto_autorizacion = Autorizacion.ConceptoAutorizacion.Obtener(row["codigo"].ToString());

				if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.EndEdit)
				{
					concepto_autorizacion.operador = row["operador"].ToString();
					concepto_autorizacion.nivel_acceso = (byte)row["nivel_acceso"];
					concepto_autorizacion.usuario_autorizacion_id = (int)row["usuario_autorizacion_id"];

					concepto_autorizacion.Actualizar();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}