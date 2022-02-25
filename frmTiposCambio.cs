using NoriSDK;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Nori
{
	public partial class frmTiposCambio : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		public frmTiposCambio()
		{
			InitializeComponent();
			this.MetodoDinamico();

			CargarListas();
		}

		private void CargarListas()
		{
			object p = new { fields = "id, codigo, nombre" };
			object o = new { activo = 1 };

			cbMonedas.DataSource = Utilidades.Busqueda("monedas", o, p);
			cbMonedas.ValueMember = "id";
			cbMonedas.DisplayMember = "nombre";

			deFecha.MinValue = DateTime.Now;

			try
			{
				TipoCambio primero = TipoCambio.TiposCambio().OrderBy(x => x.id).First();
				TipoCambio ultimo = TipoCambio.TiposCambio().OrderByDescending(x => x.id).First();
				for (int i = primero.fecha.Year - 1; i < ultimo.fecha.Year - 1; i++)
				{
					cbAño.Properties.Items.Add(primero.fecha.Year + 1);
				}
				cbAño.EditValue = DateTime.Now.Year;
                try {
                    cbMes.SelectedIndex = int.Parse(DateTime.Now.Month.ToString("00")) - 1;
                }
                catch { }
			}
			catch
			{
				//cbMes.Enabled = false;
				//cbAño.Enabled = false;
				//gcTiposCambio.DataSource = TipoCambio.TiposCambio().ToList();
			}
		}

		private void gcTiposCambio_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
		{
			if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.EndEdit)
			{
				try
				{
					DataRow row = gvTiposCambio.GetDataRow(gvTiposCambio.GetSelectedRows()[0]);
					gvTiposCambio.CloseEditor();
					int id = 0;
					int.TryParse(row["id"].ToString(), out id);
					int moneda_id = (int)row["moneda_id"];
					DateTime fecha = (DateTime)row["fecha"];
					decimal compra = decimal.Parse(row["compra"].ToString());
					decimal venta = decimal.Parse(row["venta"].ToString());

					TipoCambio tc = new TipoCambio();

					if (id != 0)
					{
						tc = TipoCambio.Obtener(id);
					}

					tc.moneda_id = moneda_id;
					tc.fecha = fecha;
					tc.compra = compra;
					tc.venta = venta;

					if (tc.id != 0)
					{
						tc.Actualizar();
					}
					else
					{
						tc.Agregar();
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void cbMes_SelectedIndexChanged(object sender, EventArgs e)
		{
			int mes = cbMes.SelectedIndex + 1;
			int año = int.Parse(cbAño.EditValue.ToString());
			string fecha_inicial = año.ToString() + mes.ToString("00") + "01";
			string fecha_final = año.ToString() + mes.ToString("00") + DateTime.DaysInMonth(año, mes).ToString();
			gcTiposCambio.DataSource = Utilidades.EjecutarQuery("SELECT * FROM tipos_cambio WHERE fecha BETWEEN '" + fecha_inicial + "' AND '" + fecha_final + "'");
		}

		private void gvTiposCambio_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
		{
			gvTiposCambio.SetRowCellValue(e.RowHandle, "fecha", DateTime.Today);
			gvTiposCambio.SetRowCellValue(e.RowHandle, "moneda_id", Program.Nori.Configuracion.moneda_id);
			gvTiposCambio.SetRowCellValue(e.RowHandle, "compra", 1);
			gvTiposCambio.SetRowCellValue(e.RowHandle, "venta", 1);
		}
	}
}