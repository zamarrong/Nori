using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Nori
{
	public partial class frmResultadosBusqueda : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		public int id { get; internal set; }
		public int fila { get; internal set; }
		public List<int> ids { get; internal set; }
		public List<int> filas { get; internal set; }
		public frmResultadosBusqueda(object resultados, bool seleccion_multiple = false)
		{
			InitializeComponent();
			this.MetodoDinamico();

			try
			{
				ids = new List<int>();
				filas = new List<int>();

				if (seleccion_multiple)
				{
					gvResultados.OptionsSelection.MultiSelect = true;
					gvResultados.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
				}

				gcResultados.DataSource = resultados;

				if (gvResultados.Columns[0].FieldName != "ID")
					gvResultados.Columns[0].Visible = false;

				gvResultados.BestFitColumns();
			} catch { }
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
					id = int.Parse(row[0].ToString());
				}

				DialogResult = DialogResult.OK;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void frmResultadosBusqueda_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
				Close();
		}
	}
}