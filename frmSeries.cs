using NoriSDK;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Nori
{
	public partial class frmSeries : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		Serie serie = new Serie();

		public frmSeries(int id = 0)
		{
			InitializeComponent();
			this.MetodoDinamico();
			if (id != 0)
			{
				serie = Serie.Obtener(id);
				Cargar();
			}
			else
			{
				Cargar(false, true);
			}
			CargarListas();
			Permisos();
		}

		private void Permisos()
		{
			switch (Program.Nori.UsuarioAutenticado.rol)
			{
				case 'C':
					mainRibbonPageGroup.Visible = false;
					break;
				case 'V':
					mainRibbonPageGroup.Visible = false;
					break;
				case 'S':
					mainRibbonPageGroup.Visible = false;
					break;
			}
		}

		private void Cargar(bool nuevo = false, bool busqueda = false)
		{
			lblID.Text = serie.id.ToString();
			txtCodigo.Text = serie.codigo.ToString();
			txtNombre.Text = serie.nombre;
			cbClases.EditValue = serie.clase;
			txtInicial.Text = serie.inicial.ToString();
			txtSiguiente.Text = serie.siguiente.ToString();
			txtFinal.Text = serie.final.ToString();
            cbAlmacenes.EditValue = serie.almacen_id;
			cbPredeterminado.Checked = serie.predeterminado;
            cbPredeterminadoCancelacion.Checked = serie.predeterminado_cancelacion;
            cbDigital.Checked = serie.digital;
            cbFacturarAutomaticamente.Checked = serie.facturar_automaticamente;
            if (cbFacturarAutomaticamente.Checked)
                cbSeriesFacturacion.EditValue = serie.serie_facturacion_id;
			cbActivo.Checked = serie.activo;

			lblFechaActualizacion.Text = serie.fecha_actualizacion.ToShortDateString();

            gcFacturacion.Visible = (serie.clase.Equals("EN") && serie.id != 0) ? true : false;
            if (nuevo)
			{
				bbiNuevo.Enabled = false;
				bbiGuardar.Enabled = true;
				bbiGuardarCerrar.Enabled = true;
				bbiGuardarNuevo.Enabled = true;
				txtCodigo.Focus();
				txtCodigo.Enabled = true;
				txtInicial.Enabled = true;
				txtFinal.Enabled = true;
			}
			else
			{
				if (busqueda)
				{
					bbiNuevo.Enabled = true;
					bbiGuardar.Enabled = false;
					bbiGuardarCerrar.Enabled = false;
					bbiGuardarNuevo.Enabled = false;
					txtCodigo.Focus();
				}
				else
				{
					bbiNuevo.Enabled = true;
					bbiGuardar.Enabled = true;
					bbiGuardarCerrar.Enabled = true;
					bbiGuardarNuevo.Enabled = true;
				}
				txtCodigo.Enabled = false;
				txtInicial.Enabled = false;
				txtFinal.Enabled = false;
			}
		}

		private void CargarListas()
		{
			cbClases.Properties.DataSource = Documento.Clase.Clases();
			cbClases.Properties.ValueMember = "clase";
			cbClases.Properties.DisplayMember = "nombre";

            cbSeriesFacturacion.Properties.DataSource = Serie.Series().Where(x => x.activo == true && x.clase == "FA").Select(x => new { x.id, x.codigo, x.nombre }).ToList();
            cbSeriesFacturacion.Properties.ValueMember = "id";
            cbSeriesFacturacion.Properties.DisplayMember = "nombre";

            var almacenes = Almacen.Almacenes().Where(x => x.activo == true).Select(x => new { x.id, x.codigo, x.nombre }).ToList();
            almacenes.Insert(0, new { id = 0, codigo = "NA", nombre = "-- Ningún almacén --" });
            cbAlmacenes.Properties.DataSource = almacenes;
            cbAlmacenes.Properties.ValueMember = "id";
            cbAlmacenes.Properties.DisplayMember = "nombre";
        }

		private void Llenar()
		{
            try
            {
                serie.codigo = short.Parse(txtCodigo.Text);
                serie.nombre = txtNombre.Text;
                serie.clase = cbClases.EditValue.ToString();
                serie.inicial = int.Parse(txtInicial.Text);
                serie.siguiente = int.Parse(txtSiguiente.Text);
                serie.final = int.Parse(txtFinal.Text);
                serie.almacen_id = (cbAlmacenes.EditValue.IsNullOrEmpty()) ? 0 : (int)cbAlmacenes.EditValue;
                serie.predeterminado = cbPredeterminado.Checked;
                serie.predeterminado_cancelacion = cbPredeterminadoCancelacion.Checked;
                serie.digital = cbDigital.Checked;
                serie.facturar_automaticamente = cbFacturarAutomaticamente.Checked;
                if (cbFacturarAutomaticamente.Checked)
                    serie.serie_facturacion_id = (int)cbSeriesFacturacion.EditValue;
                serie.activo = cbActivo.Checked;
            } catch { }
		}

		private bool Guardar()
		{
			try
			{
				if (MessageBox.Show("¿Desea guardar los cambios?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					Llenar();
					if (serie.id != 0)
					{
						return serie.Actualizar();
					}
					else
					{
						return serie.Agregar();
					}
				}
				else
				{
					return false;
				}
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
			{
				Close();
			}
		}

		private void bbiGuardarNuevo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (Guardar())
			{
				serie = new Serie();
				Cargar();
			}
		}

		private void bbiPrimero_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				serie = Serie.Series().OrderBy(x => x.id).First();
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
				serie = Serie.Series().Where(x => x.id < serie.id).OrderByDescending(x => x.id).First();
			}
			catch
			{
				bbiUltimo.PerformClick();
			}
			finally
			{
				Cargar();
			}
		}

		private void bbiSiguiente_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				serie = Serie.Series().Where(x => x.id > serie.id).First();
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
				serie = Serie.Series().OrderByDescending(x => x.id).First();
				Cargar();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
				if (serie.id != 0)
				{
					serie = new Serie();
					Cargar(false, true);
				}
				else
				{
					object p = new { fields = "id, codigo, nombre", like = true };
					object o = new { codigo = txtCodigo.Text, nombre = txtNombre.Text };
					DataTable series = Utilidades.Busqueda("series", o, p);
					if (series.Rows.Count > 0)
					{
						if (series.Rows.Count == 1)
						{
							serie = Serie.Obtener((int)series.Rows[0]["id"]);
							Cargar();
						}
						else
						{
							frmResultadosBusqueda f = new frmResultadosBusqueda(series);
							var result = f.ShowDialog();
							if (result == DialogResult.OK)
							{
								serie = Serie.Obtener(f.id);
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
			serie = new Serie();
			Cargar(true);
		}

		private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && serie.id == 0)
				Buscar();
		}

		private void bbiUsuarios_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			frmUsuariosSeries f = new frmUsuariosSeries();
			f.Show();
		}
	}
}