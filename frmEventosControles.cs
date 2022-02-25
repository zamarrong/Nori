using NoriSDK;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Nori
{
	public partial class frmEventosControles : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		EventoControl evento_control = new EventoControl();

		public frmEventosControles(int id = 0)
		{
			InitializeComponent();
			this.MetodoDinamico();

			CargarFormulariosAbiertos();

			if (id != 0)
			{
				evento_control = EventoControl.Obtener(id);
				Cargar();
			}
			else
				Cargar(false, true);

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

		private void CargarFormulariosAbiertos()
		{
			List<string> formularios = new List<string>();
			for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
			{
				if (Application.OpenForms[i].Name.Length > 0)
					formularios.Add(Application.OpenForms[i].Name);
			}
			cbFormularios.Properties.DataSource = formularios;
		}

		private void CargarControles()
		{
			List<string> controles = new List<string>();
			Form f = Application.OpenForms[cbFormularios.Text];
			foreach(var control in Funciones.ObtenerControles(f).OfType<Control>())
			{
				controles.Add(control.Name);
			}
			if (controles.Count > 0)
			{
				cbControles.Properties.DataSource = controles;
				cbControlDestino.Properties.DataSource = controles;
			}
			else
			{
				cbControles.Enabled = false;
				cbControlDestino.Enabled = false;
			}

		}

		private void Cargar(bool nuevo = false, bool busqueda = false)
		{
			lblID.Text = evento_control.id.ToString();

			txtFormulario.Text = evento_control.formulario;
			txtControl.Text = evento_control.control;
			txtControlDestino.Text = evento_control.control_destino;
			cbEventos.EditValue = evento_control.evento;
			txtQuery.Text = evento_control.query;

			cbActivo.Checked = evento_control.activo;

			lblFechaActualizacion.Text = evento_control.fecha_actualizacion.ToShortDateString();

			if (nuevo)
			{
				bbiNuevo.Enabled = false;
				bbiGuardar.Enabled = true;
				bbiGuardarCerrar.Enabled = true;
				bbiGuardarNuevo.Enabled = true;
				cbFormularios.Focus();
			}
			else
			{
				if (busqueda)
				{
					bbiNuevo.Enabled = true;
					bbiGuardar.Enabled = false;
					bbiGuardarCerrar.Enabled = false;
					bbiGuardarNuevo.Enabled = false;
					cbFormularios.Focus();
				}
				else
				{
					bbiNuevo.Enabled = true;
					bbiGuardar.Enabled = true;
					bbiGuardarCerrar.Enabled = true;
					bbiGuardarNuevo.Enabled = true;
				}
			}
		}

		private void Llenar()
		{
			evento_control.formulario = txtFormulario.Text;
			evento_control.control = txtControl.Text;
			evento_control.control_destino = txtControlDestino.Text;
			evento_control.evento = cbEventos.EditValue.ToString();
			evento_control.query = txtQuery.Text;
			evento_control.activo = cbActivo.Checked;
		}

		private bool Guardar()
		{
			try
			{
				if (MessageBox.Show("¿Desea guardar los cambios?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					Llenar();
					if (evento_control.id != 0)
						return evento_control.Actualizar();
					else
						return evento_control.Agregar();
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
				evento_control = new EventoControl();
				Cargar();
			}
		}

		private void bbiPrimero_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				evento_control = EventoControl.EventosControles().OrderBy(x => x.id).First();
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
				evento_control = EventoControl.EventosControles().Where(x => x.id < evento_control.id).OrderByDescending(x => x.id).First();
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
				evento_control = EventoControl.EventosControles().Where(x => x.id > evento_control.id).First();
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
				evento_control = EventoControl.EventosControles().OrderByDescending(x => x.id).First();
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
				if (evento_control.id != 0)
				{
					evento_control = new EventoControl();
					Cargar(false, true);
				}
				else
				{
					object p = new { fields = "id, formulario, control, evento, query", like = true };
					object o = new { };
					DataTable eventos_controles = Utilidades.Busqueda("eventos_controles", o, p);
					if (eventos_controles.Rows.Count > 0)
					{
						if (eventos_controles.Rows.Count == 1)
						{
							evento_control = EventoControl.Obtener((int)eventos_controles.Rows[0]["id"]);
							Cargar();
						}
						else
						{
							frmResultadosBusqueda f = new frmResultadosBusqueda(eventos_controles);
							var result = f.ShowDialog();
							if (result == DialogResult.OK)
							{
								evento_control = EventoControl.Obtener(f.id);
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
			evento_control = new EventoControl();
			Cargar(true);
		}

		private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && evento_control.id == 0)
				Buscar();
		}

		private void bbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			CargarFormulariosAbiertos();
		}

		private void cbFormularios_TextChanged(object sender, System.EventArgs e)
		{
			CargarControles();
			txtFormulario.Text = cbFormularios.Text;
		}

		private void cbControles_TextChanged(object sender, System.EventArgs e)
		{
			txtControl.Text = cbControles.Text;
		}

		private void cbControlDestino_TextChanged(object sender, System.EventArgs e)
		{
			txtControlDestino.Text = cbControlDestino.Text;
		}
	}
}