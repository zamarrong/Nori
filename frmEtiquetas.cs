using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using NoriSDK;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nori
{
	public partial class frmEtiquetas : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		Etiqueta etiqueta = new Etiqueta();

		public frmEtiquetas(int id = 0)
		{
			InitializeComponent();
			this.MetodoDinamico();
			CargarListas();

			if (id != 0)
			{
				etiqueta = Etiqueta.Obtener(id);
				Cargar();
			}
			else
			{
				Cargar(false, true);
			}

			Permisos();
		}

		private void CargarListas()
		{
            cbUnidadesMedida.DataSource = UnidadMedida.UnidadesMedida().Where(x => x.activo == true).Select(x => new { x.id, x.nombre });
            cbUnidadesMedida.ValueMember = "id";
            cbUnidadesMedida.DisplayMember = "nombre";

            cbAlmacenes.Properties.DataSource = Almacen.Almacenes().Where(x => x.activo == true).Select(x => new { x.id, x.codigo, x.nombre }).ToList();
			cbAlmacenes.Properties.ValueMember = "id";
			cbAlmacenes.Properties.DisplayMember = "nombre";

			cbTipos.Properties.DataSource = Etiqueta.Tipo.Tipos().Where(x => x.activo == true).Select(x => new { x.id, x.nombre }).ToList();
			cbTipos.Properties.ValueMember = "id";
			cbTipos.Properties.DisplayMember = "nombre";

			cbUsuarios.Properties.DataSource = Usuario.Usuarios().Where(x => x.activo == true).Select(x => new { x.id, x.usuario, x.nombre }).ToList();
			cbUsuarios.Properties.ValueMember = "id";
			cbUsuarios.Properties.DisplayMember = "nombre";
		}

		private void Permisos()
		{
			switch (Program.Nori.UsuarioAutenticado.rol)
			{
				case 'C':
					mainRibbonPageGroup.Visible = false;
					break;
			}
		}

		private void Cargar(bool nuevo = false, bool busqueda = false)
		{
			lblID.Text = etiqueta.id.ToString();

			cbAlmacenes.EditValue = etiqueta.almacen_id;
			cbTipos.EditValue = etiqueta.tipo_etiqueta_id;
			cbUsuarios.EditValue = etiqueta.usuario_creacion_id;
			cbImpreso.Checked = etiqueta.impreso;

			lblFechaActualizacion.Text = etiqueta.fecha_actualizacion.ToShortDateString();

			if (nuevo)
			{
				bbiNuevo.Enabled = false;
				bbiGuardar.Enabled = true;
				bbiGuardarCerrar.Enabled = true;
				bbiGuardarNuevo.Enabled = true;
				cbAlmacenes.Focus();
			}
			else
			{
				if (busqueda)
				{
					bbiNuevo.Enabled = true;
					bbiGuardar.Enabled = false;
					bbiGuardarCerrar.Enabled = false;
					bbiGuardarNuevo.Enabled = false;
					cbAlmacenes.Focus();
				}
				else
				{
					bbiNuevo.Enabled = true;
					bbiGuardar.Enabled = true;
					bbiGuardarCerrar.Enabled = true;
					bbiGuardarNuevo.Enabled = true;
				}
			}

			CargarPartidas();
		}

		private void Llenar()
		{
			etiqueta.almacen_id = (int)cbAlmacenes.EditValue;
			etiqueta.tipo_etiqueta_id = (int)cbTipos.EditValue;
			etiqueta.usuario_creacion_id = (int)cbUsuarios.EditValue;
			etiqueta.impreso = cbImpreso.Checked;
		}

		private bool Guardar()
		{
			try
			{
				if (MessageBox.Show("¿Desea guardar los cambios?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					Llenar();
					if (etiqueta.id != 0)
						return etiqueta.Actualizar();
					else
						return etiqueta.Agregar();
				}
				else
					return false;
			}
			catch
			{
				MessageBox.Show(NoriSDK.Nori.ObtenerUltimoError().Message, Text);
				return false;
			}
		}

		private void bbiGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (Guardar()) { Cargar(); } else { MessageBox.Show( "Error al guardar: " + NoriSDK.Nori.ObtenerUltimoError().Message, Text); };
		}

		private void bbiGuardarCerrar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (Guardar())
				Close();
		}

		private void bbiGuardarNuevo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (Guardar())
			{
				etiqueta = new Etiqueta();
				Cargar();
			}
		}

		private void bbiPrimero_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				etiqueta = Etiqueta.Obtener(Etiqueta.Etiquetas().OrderBy(x => x.id).Select(x => new { x.id }).First().id);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				Cargar();
			}
		}

		private void bbiAnterior_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				etiqueta = Etiqueta.Obtener(Etiqueta.Etiquetas().Where(x => x.id < etiqueta.id).OrderByDescending(x => x.id).Select(x => new { x.id }).First().id);
				Cargar();
			}
			catch
			{
				bbiUltimo.PerformClick();
			}
		}

		private void bbiSiguiente_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				etiqueta = Etiqueta.Obtener(Etiqueta.Etiquetas().Where(x => x.id > etiqueta.id).Select(x => new { x.id }).First().id);
				Cargar();
			}
			catch
			{
				bbiPrimero.PerformClick();
			}
		}

		private void bbiUltimo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				etiqueta = Etiqueta.Obtener(Etiqueta.Etiquetas().OrderByDescending(x => x.id).Select(x => new { x.id }).First().id);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				Cargar();
			}
		}

		private void bbiBuscar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			Buscar();
		}

		private void Buscar()
		{
			try
			{
				if (etiqueta.id != 0)
				{
					etiqueta = new Etiqueta();
					Cargar(false, true);
				}
				else
				{
					object p = new { fields = "*" };

					object o = new { almacen_id = (int)cbAlmacenes.EditValue, tipo_etiqueta_id = (int)cbTipos.EditValue, impreso = (cbImpreso.Checked) ? 1 : 0 };
					DataTable etiquetas = Utilidades.Busqueda("etiquetas", o, p);
					if (etiquetas.Rows.Count > 0)
					{
						if (etiquetas.Rows.Count == 1)
						{
							etiqueta = Etiqueta.Obtener((int)etiquetas.Rows[0]["id"]);
							Cargar();
						}
						else
						{
							frmResultadosBusqueda f = new frmResultadosBusqueda(etiquetas);
							var result = f.ShowDialog();
							if (result == DialogResult.OK)
							{
								etiqueta = Etiqueta.Obtener(f.id);
								Cargar();
							}
						}
					}
					else
					{
						MessageBox.Show("No se encontraron resultados", Text);
					}
				}
			}
			catch { }
		}

		private void bbiNuevo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			etiqueta = new Etiqueta();
			Cargar(true);
		}

		private void txtArticulo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && txtArticulo.Text.Length > 0)
				AgregarPartida(txtArticulo.Text);
		}

		private async void AgregarPartida(string q)
		{
			Buscar:
			if (await Task.Run(() => etiqueta.AgregarPartida(q)))
			{
				txtArticulo.Text = string.Empty;
				CargarPartidas();
			}
			else
			{
				if (MessageBox.Show(NoriSDK.Nori.ObtenerUltimoError().Message, Text, MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
					goto Buscar;
			}

			txtArticulo.Text = string.Empty;
			txtArticulo.Focus();
		}

		private void CargarPartidas()
		{
			gcPartidas.DataSource = etiqueta.partidas;
			gcPartidas.RefreshDataSource();
		}

		private void lblAlmacenes_Click(object sender, EventArgs e)
		{
			frmAlmacenes form = new frmAlmacenes((int)cbAlmacenes.EditValue);
			form.ShowDialog();
		}

		private void lblTipo_Click(object sender, EventArgs e)
		{
			frmTiposEtiquetas form = new frmTiposEtiquetas((int)cbTipos.EditValue);
			form.ShowDialog();
		}

		private void gvPartidas_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete)
			{
				if (etiqueta.partidas.Count > 0)
					etiqueta.partidas.Remove(etiqueta.partidas[gvPartidas.GetSelectedRows()[0]]);

				CargarPartidas();
			}
		}

		private void btnImprimir_Click(object sender, EventArgs e)
		{
			try
			{
				if (etiqueta.id != 0)
				{
					Etiqueta.Tipo tipo = Etiqueta.Tipo.Obtener(etiqueta.tipo_etiqueta_id);
					Funciones.ImprimirInforme(tipo.formato, etiqueta.id);
				}
				else
				{
					MessageBox.Show("Es necesario guardar antes de imprimir.");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnImportar_Click(object sender, EventArgs e)
		{
			try
			{
				List<int> articulos = (rgOpciones.SelectedIndex == 0) ? Articulo.Articulos().Where(x => x.fecha_actualizacion >= deDesde.DateTime && x.fecha_actualizacion <= deHasta.DateTime).Select(x => x.id).Distinct().ToList() : Articulo.Precio.Precios().Where(x => x.fecha_actualizacion >= deDesde.DateTime && x.fecha_actualizacion <= deHasta.DateTime).Select(x => x.articulo_id).Distinct().ToList();
				if (articulos.Count > 0)
				{
					if (MessageBox.Show(string.Format("¿Se encontraron {0} artículos desea importarlos?", articulos.Count), Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
					{
						foreach(int articulo_id in articulos)
						{
							var articulo = Articulo.Articulos().Where(x => x.id == articulo_id).Select(x => x.sku).First();
							etiqueta.AgregarPartida(articulo);
						}

						CargarPartidas();
					}
				}
				else
				{
					MessageBox.Show("No se encontraron registros coincidentes");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

        private void gvPartidas_ShownEditor(object sender, EventArgs e)
        {
            try
            {
                ColumnView view = (ColumnView)sender;
                if (view.FocusedColumn.FieldName == "unidad_medida_id")
                {
                    LookUpEdit editor = (LookUpEdit)view.ActiveEditor;
					int articulo_id = Convert.ToInt32(view.GetFocusedRowCellValue("articulo_id"));
					editor.Properties.DataSource = Articulo.UnidadesMedida(articulo_id);
				}
            }
            catch { }
        }
    }
}