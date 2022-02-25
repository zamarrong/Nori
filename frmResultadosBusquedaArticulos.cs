using NoriSDK;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Nori
{
	public partial class frmResultadosBusquedaArticulos : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		public int id { get; internal set; }
		public int fila { get; internal set; }
		public List<int> ids { get; internal set; }
		public List<int> filas { get; internal set; }
		public frmResultadosBusquedaArticulos(object resultados, bool seleccion_multiple = false)
		{
			try
			{
				InitializeComponent();
				this.MetodoDinamico();

				ids = new List<int>();
				filas = new List<int>();

				if (seleccion_multiple)
				{
					gvResultados.OptionsSelection.MultiSelect = true;
					gvResultados.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
				}

				gcResultados.DataSource = resultados;

				gvResultados.Columns[0].Visible = false;
				gvResultados.BestFitColumns();
			}
			catch { }
		}

		private void gvResultados_DoubleClick(object sender, EventArgs e)
		{
			Cerrar();
		}

		private void gvResultados_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				Cerrar();
		}
		private void Cerrar()
		{
			try
			{
				if (gvResultados.IsMultiSelect)
				{
					foreach (int i in gvResultados.GetSelectedRows())
					{
						DataRow row = gvResultados.GetDataRow(i);

						ids.Add((int)row[0]);
						filas.Add(i);
					}
				}
				else
				{
					DataRow row = gvResultados.GetDataRow(gvResultados.GetSelectedRows()[0]);

					fila = gvResultados.GetSelectedRows()[0];
					id = (int)row[0];
				}

				DialogResult = DialogResult.OK;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void gvResultados_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{
			try
			{
				BeginInvoke(new MethodInvoker(delegate {
					if (gvResultados.RowCount > 0)
					{
						DataRow row = gvResultados.GetDataRow(gvResultados.GetSelectedRows()[0]);
                        pbImagen.LoadImage(Articulo.ObtenerImagen(int.Parse(row[0].ToString())));
                        lblNombre.Text = row["nombre"].ToString();
                    }
				}
				));
			}
			catch { }
		}

		private void frmResultadosBusquedaArticulos_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
				Close();
		}
	}
}