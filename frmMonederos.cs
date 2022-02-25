using NoriSDK;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Nori
{
	public partial class frmMonederos : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		Monedero monedero = new Monedero();

		public frmMonederos(int id = 0)
		{
			InitializeComponent();
			this.MetodoDinamico();

			if (id != 0)
			{
				try
				{
					monedero = Monedero.Monederos().Where(x => x.socio_id == id && x.predeterminado == true).First();
					Cargar();
				} catch { };
			}
			else
			{
				Cargar(false, true);
			}

			Permisos();

			cbSocios.Properties.DataSource = Socio.Socios().Where(x => x.activo == true && x.tipo == 'C').Select(x => new { x.id, x.codigo, x.nombre }).ToList();
			cbSocios.Properties.ValueMember = "id";
			cbSocios.Properties.DisplayMember = "nombre";
			cbSocios.EditValue = id;
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
			lblID.Text = monedero.id.ToString();

			cbSocios.EditValue = monedero.socio_id;
			txtFolio.Text = monedero.folio.ToString();
			txtSaldo.Text = monedero.saldo.ToString();
			cbPredeterminado.Checked = monedero.predeterminado;
			cbActivo.Checked = monedero.activo;

			lblFechaActualizacion.Text = monedero.fecha_actualizacion.ToShortDateString();

			if (nuevo)
			{
				bbiNuevo.Enabled = false;
				bbiGuardar.Enabled = true;
				bbiGuardarCerrar.Enabled = true;
				bbiGuardarNuevo.Enabled = true;
				cbSocios.Focus();
			}
			else
			{
				if (busqueda)
				{
					bbiNuevo.Enabled = true;
					bbiGuardar.Enabled = false;
					bbiGuardarCerrar.Enabled = false;
					bbiGuardarNuevo.Enabled = false;
					txtFolio.Focus();
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
			monedero.socio_id = (int)cbSocios.EditValue;
			monedero.folio = txtFolio.EditValue.ToString();
			monedero.predeterminado = cbPredeterminado.Checked;
			monedero.activo = cbActivo.Checked;
		}

		private bool Guardar()
		{
			try
			{
				if (MessageBox.Show("¿Desea guardar los cambios?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					Llenar();
					if (monedero.id != 0)
						return monedero.Actualizar();
					else
						return monedero.Agregar();
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
				monedero = new Monedero();
				Cargar();
			}
		}

		private void bbiPrimero_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				monedero = Monedero.Monederos().OrderBy(x => x.id).First();
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
				monedero = Monedero.Monederos().Where(x => x.id < monedero.id).OrderByDescending(x => x.id).First();
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
				monedero = Monedero.Monederos().Where(x => x.id > monedero.id).First();
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
				monedero = Monedero.Monederos().OrderByDescending(x => x.id).First();
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
				if (monedero.id != 0)
				{
					monedero = new Monedero();
					Cargar(false, true);
				}
				else
				{
					object p = new { fields = "id, folio, predeterminado, activo", like = true };
					object o = new { socio_id = (cbSocios.EditValue.IsNullOrEmpty()) ? null : cbSocios.EditValue, folio = txtFolio.Text };
					DataTable monederos = Utilidades.Busqueda("monederos", o, p);
					if (monederos.Rows.Count > 0)
					{
						if (monederos.Rows.Count == 1)
						{
							monedero = Monedero.Obtener((int)monederos.Rows[0]["id"]);
							Cargar();
						}
						else
						{
							frmResultadosBusqueda f = new frmResultadosBusqueda(monederos);
							var result = f.ShowDialog();
							if (result == DialogResult.OK)
							{
								monedero = Monedero.Obtener(f.id);
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
			monedero = new Monedero();
			Cargar(true);
		}

		private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && monedero.id == 0)
				Buscar();
		}

		private void bbiMovimientos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			frmResultadosBusqueda f = new frmResultadosBusqueda(Utilidades.EjecutarQuery(string.Format("select partidas_monedero.id ID, documentos.id 'Documento ID', documentos.clase Clase, partidas.nombre Nombre, partidas_monedero.importe Importe, partidas_monedero.fecha_creacion Fecha from partidas_monedero left join partidas on partidas_monedero.partida_id = partidas.id left join documentos on partidas_monedero.documento_id = documentos.id where partidas_monedero.monedero_id = {0} order by partidas_monedero.id desc", monedero.id)));
			f.ShowDialog();
		}
	}
}