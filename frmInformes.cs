using NoriSDK;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Nori
{
	public partial class frmInformes : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		Informe informe = new Informe();

		public frmInformes(int id = 0)
		{
			InitializeComponent();
			this.MetodoDinamico();

			CargarListas();

			if (id != 0)
			{
				informe = Informe.Obtener(id);
				Cargar();
			}
			else
			{
				Cargar(false, true);
			}
            CargarImpresoras();
            Permisos();
		}


		private void CargarListas()
		{
			cbTipos.Properties.DataSource = Informe.Tipo.Tipos();
			cbTipos.Properties.ValueMember = "tipo";
			cbTipos.Properties.DisplayMember = "nombre";


			cbTiposInforme.Properties.DataSource = Informe.TipoInforme.TipoInformes();
			cbTiposInforme.Properties.ValueMember = "tipo";
			cbTiposInforme.Properties.DisplayMember = "nombre";

			cbInformeSecuencia.Properties.DataSource = Informe.Informes().Where(x => x.activo == true).Select(x => new { x.id, x.tipo, x.nombre });
			cbInformeSecuencia.Properties.ValueMember = "id";
			cbInformeSecuencia.Properties.DisplayMember = "nombre";
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

        private void CargarImpresoras()
        {
            List<string> impresoras = new List<string>();
            impresoras.Add(string.Empty);
            foreach (var printer in PrinterSettings.InstalledPrinters)
            {
                impresoras.Add(printer.ToString());
            }
            cbImpresoras.Properties.DataSource = impresoras;
        }

        private void Cargar(bool nuevo = false, bool busqueda = false)
		{
			lblID.Text = informe.id.ToString();

			cbTipos.EditValue = informe.tipo;
			txtNombre.Text = informe.nombre;
			txtDescripcion.Text = informe.descripcion;
			txtInforme.Text = informe.informe;
			cbTiposInforme.EditValue = informe.tipo_informe;
			cbInformeSecuencia.EditValue = informe.informe_sequencia_id;
			txtCopias.Text = informe.copias.ToString();
            cbImpresoras.EditValue = informe.impresora;

            cbPredeterminado.Checked = informe.predeterminado;
			cbPredeterminadoCorreoElectronico.Checked = informe.predeterminado_correo_electronico;
			cbAlmacen.Checked = informe.almacen;
			cbActivo.Checked = informe.activo;

			lblFechaActualizacion.Text = informe.fecha_actualizacion.ToShortDateString();

			if (nuevo)
			{
				bbiNuevo.Enabled = false;
				bbiGuardar.Enabled = true;
				bbiGuardarCerrar.Enabled = true;
				bbiGuardarNuevo.Enabled = true;
				bbiEliminar.Enabled = false;
				btnEditarInforme.Enabled = false;
				cbTipos.Focus();
			}
			else
			{
				if (busqueda)
				{
					bbiNuevo.Enabled = true;
					bbiGuardar.Enabled = false;
					bbiGuardarCerrar.Enabled = false;
					bbiGuardarNuevo.Enabled = false;
					bbiEliminar.Enabled = false;
					btnEditarInforme.Enabled = false;
					cbTipos.Focus();
				}
				else
				{
					bbiNuevo.Enabled = true;
					bbiGuardar.Enabled = true;
					bbiGuardarCerrar.Enabled = true;
					bbiGuardarNuevo.Enabled = true;
					bbiEliminar.Enabled = true;
					btnEditarInforme.Enabled = true;
				}
			}
		}

		private void Llenar()
		{
			informe.tipo = cbTipos.EditValue.ToString();
			informe.nombre = txtNombre.Text;
			informe.descripcion = txtDescripcion.Text;
			informe.informe = txtInforme.Text;
			informe.tipo_informe = (char)cbTiposInforme.EditValue;
			informe.informe_sequencia_id = (cbInformeSecuencia.EditValue.IsNullOrEmpty()) ? 0 : (int)cbInformeSecuencia.EditValue;
			informe.copias = int.Parse(txtCopias.Text);
            informe.impresora = cbImpresoras.EditValue.ToString();
            informe.almacen = cbAlmacen.Checked;
			informe.predeterminado = cbPredeterminado.Checked;
			informe.predeterminado_correo_electronico = cbPredeterminadoCorreoElectronico.Checked;
			informe.activo = cbActivo.Checked;
		}

		private bool Guardar()
		{
			try
			{
				if (MessageBox.Show("¿Desea guardar los cambios?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					Llenar();
					if (informe.id != 0)
						return informe.Actualizar();
					else
						return informe.Agregar();
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
				informe = new Informe();
				Cargar();
			}
		}

		private void bbiPrimero_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				informe = Informe.Informes().OrderBy(x => x.id).First();
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
				informe = Informe.Informes().Where(x => x.id < informe.id).OrderByDescending(x => x.id).First();
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
				informe = Informe.Informes().Where(x => x.id > informe.id).First();
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
				informe = Informe.Informes().OrderByDescending(x => x.id).First();
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
				if (informe.id != 0)
				{
					informe = new Informe();
					Cargar(false, true);
				}
				else
				{
					object p = new { fields = "id, nombre, descripcion, informe, tipo, activo", like = true };
					object o = new { nombre = txtNombre.Text };
					DataTable informes = Utilidades.Busqueda("informes", o, p);
					if (informes.Rows.Count > 0)
					{
						if (informes.Rows.Count == 1)
						{
							informe = Informe.Obtener((int)informes.Rows[0]["id"]);
							Cargar();
						}
						else
						{
							frmResultadosBusqueda f = new frmResultadosBusqueda(informes);
							var result = f.ShowDialog();
							if (result == DialogResult.OK)
							{
								informe = Informe.Obtener(f.id);
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
			informe = new Informe();
			Cargar(true);
		}

		private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && informe.id == 0)
				Buscar();
		}

		private void btnEditarInforme_Click(object sender, EventArgs e)
		{
			if (txtInforme.Text.Length > 0)
			{
				frmDiseñadorInformes f = new frmDiseñadorInformes();
				f.AbrirInforme(Path.Combine(Program.Nori.Configuracion.directorio_informes, txtInforme.Text));
				f.Show();
			}
		}

		private void btnInforme_Click(object sender, EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.InitialDirectory = Program.Nori.Configuracion.directorio_informes;
			dialog.Filter = "Archivos de informe (*.repx) | *.repx";
			dialog.Title = "Por favor seleccione un informe.";
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				txtInforme.Text = dialog.SafeFileName;
			}
		}

		private void bbiEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				if (MessageBox.Show("¿Esta seguro de eliminar este elemento?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					if (informe.id != 0)
						if (informe.Eliminar())
							bbiUltimo.PerformClick();
						else
							MessageBox.Show(NoriSDK.Nori.ObtenerUltimoError().Message, Text);
				}
			}
			catch
			{
				MessageBox.Show(NoriSDK.Nori.ObtenerUltimoError().Message, Text);
			}
		}

		private void lblQuitarSecuencia_Click(object sender, EventArgs e)
		{
			cbInformeSecuencia.EditValue = 0;
		}
	}
}