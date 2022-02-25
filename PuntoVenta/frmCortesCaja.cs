using NoriSDK;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Nori.PuntoVenta
{
	public partial class frmCortesCaja : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		List<Usuario> usuarios = new List<Usuario>();
		public frmCortesCaja()
		{
			InitializeComponent();
			this.MetodoDinamico();

			deDesde.EditValue = DateTime.Now;
			deHasta.EditValue = DateTime.Now;

			CargarListas();
		}

		private void CargarListas()
		{
			try
			{
				Usuario usuario = new Usuario();
				usuario.usuario = "Todos";
				usuario.nombre = "Todos";
				usuarios.Add(usuario);
				usuarios.AddRange(Usuario.Usuarios().Where(x => x.activo == true).ToList());

				cbUsuarios.Properties.DataSource = usuarios;
				cbUsuarios.Properties.ValueMember = "id";
				cbUsuarios.Properties.DisplayMember = "nombre";

				cbUsuarios.EditValue = 0;
			}
			catch { }
		}

		private void CargarFlujo()
		{
			try
			{
				string query_usuario = ((int)cbUsuarios.EditValue == 0) ? string.Empty : string.Format("AND flujo.usuario_creacion_id = {0}", ((int)cbUsuarios.EditValue));
				string query = (cbFlujo.Checked) ? string.Format("select flujo.id ID, conceptos_flujo.nombre Concepto, flujo.codigo Código, estaciones.nombre Estación, tipos_metodos_pago.nombre 'Método de pago', flujo.tipo_cambio 'Tipo de cambio', flujo.importe Importe, flujo.referencia Referencia, flujo.comentario Comentario, autorizaciones.comentario 'Comentario autorización', usuarios.usuario, flujo.fecha_creacion 'Fecha creación', flujo.fecha_actualizacion 'Fecha actualización' from flujo left join tipos_metodos_pago on flujo.tipo_metodo_pago_id = tipos_metodos_pago.id inner join estaciones on flujo.estacion_id = estaciones.id left join autorizaciones on flujo.autorizacion_id = autorizaciones.id inner join conceptos_flujo on flujo.codigo = conceptos_flujo.codigo left join usuarios on flujo.usuario_creacion_id = usuarios.id WHERE flujo.fecha_creacion BETWEEN '{0}' AND '{1}' {2}", ((DateTime)deDesde.EditValue).ToString("yyyyMMdd"), ((DateTime)deHasta.EditValue).ToString("yyyyMMdd"), query_usuario) : string.Format("select flujo.id ID, estaciones.nombre Estación, flujo.tipo_cambio 'Tipo de cambio', flujo.importe Importe, flujo.comentario Comentario, autorizaciones.comentario 'Comentario autorización', usuarios.usuario, flujo.fecha_creacion 'Fecha creación', flujo.fecha_actualizacion 'Fecha actualización' from flujo inner join estaciones on flujo.estacion_id = estaciones.id inner join autorizaciones on flujo.autorizacion_id = autorizaciones.id left join usuarios on flujo.usuario_creacion_id = usuarios.id WHERE flujo.codigo = 'RECCA' AND flujo.fecha_creacion BETWEEN '{0}' AND '{1}' {2}", ((DateTime)deDesde.EditValue).ToString("yyyyMMdd"), ((DateTime)deHasta.EditValue).ToString("yyyyMMdd"), query_usuario);
				gvFlujo.Columns.Clear();
				gcFlujo.DataSource = Utilidades.EjecutarQuery(query);
			}
			catch { }
		}

		private void ImprimirSeleccionados()
		{
			try
			{
				if (MessageBox.Show("¿Estas seguro(a) que deseas imprimir los elementos seleccionados?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					List<DataRow> rows = new List<DataRow>();
					for (int i = 0; i < gvFlujo.SelectedRowsCount; i++)
					{
						if (gvFlujo.GetSelectedRows()[i] >= 0)
							rows.Add(gvFlujo.GetDataRow(gvFlujo.GetSelectedRows()[i]));
					}

					for (int i = 0; i < rows.Count; i++)
					{
						DataRow row = rows[i] as DataRow;

						if (cbFlujo.Checked)
						{
							Funciones.ImprimirInformePredeterminado("IE", (int)row["ID"]);
						}
						else
						{
							if (MessageBox.Show("¿Desea imprimir el Egreso?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
								Funciones.ImprimirInformePredeterminado("IE", (int)row["ID"]);
							if (MessageBox.Show("¿Desea imprimir el Arqueo?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
								Funciones.ImprimirInformePredeterminado("AR", (int)row["ID"]);
							if (MessageBox.Show("¿Desea imprimir el corte Corte X?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
								Funciones.ImprimirInformePredeterminado("CX", (int)row["ID"]);
							if (MessageBox.Show("¿Desea imprimir el corte Corte Z?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
								Funciones.ImprimirInformePredeterminado("CZ", (int)row["ID"]);
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}


		private void frmCortesCaja_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.Control && e.KeyCode == Keys.I)
				ImprimirSeleccionados();
			if (e.Control && e.KeyCode == Keys.R)
				CargarFlujo();
		}

		private void cbUsuarios_EditValueChanged(object sender, EventArgs e)
		{
			try
			{
				CargarFlujo();
			} catch { }
		}
	}
}