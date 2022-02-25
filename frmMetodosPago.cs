using NoriSDK;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Nori
{
	public partial class frmMetodosPago : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		MetodoPago metodo_pago = new MetodoPago();

		public frmMetodosPago(int id = 0)
		{
			InitializeComponent();
			this.MetodoDinamico();
			if (id != 0)
			{
				metodo_pago = MetodoPago.Obtener(id);
				Cargar();
			}
			else
			{
				Cargar(false, true);
			}
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
            if (metodo_pago.id != 0)
            {
                object p = new { fields = "id, nombre" };
                object o = new { metodo_pago_id = metodo_pago.id, activo = 1 };

                cbTiposMetodosPago.Properties.DataSource = Utilidades.Busqueda("tipos_metodos_pago", o, p);
                cbTiposMetodosPago.Properties.ValueMember = "id";
                cbTiposMetodosPago.Properties.DisplayMember = "nombre";
                cbTiposMetodosPago.EditValue = metodo_pago.tipo_metodo_pago_id;
            }

            lblID.Text = metodo_pago.id.ToString();

            txtCodigo.Text = metodo_pago.codigo;
            txtNombre.Text = metodo_pago.nombre;
            rgOpciones.SelectedIndex = (metodo_pago.tipo.Equals('E')) ? 0 : 1;

			cbActivo.Checked = metodo_pago.activo;

			lblFechaActualizacion.Text = metodo_pago.fecha_actualizacion.ToShortDateString();

			if (nuevo)
			{
				bbiNuevo.Enabled = false;
				bbiGuardar.Enabled = true;
				bbiGuardarCerrar.Enabled = true;
				bbiGuardarNuevo.Enabled = true;
				cbTiposMetodosPago.Enabled = false;
				txtCodigo.Focus();
			}
			else
			{
				if (busqueda)
				{
					bbiNuevo.Enabled = true;
					bbiGuardar.Enabled = false;
					bbiGuardarCerrar.Enabled = false;
					bbiGuardarNuevo.Enabled = false;
					cbTiposMetodosPago.Enabled = false;
					txtCodigo.Focus();
				}
				else
				{
					bbiNuevo.Enabled = true;
					bbiGuardar.Enabled = true;
					bbiGuardarCerrar.Enabled = true;
					bbiGuardarNuevo.Enabled = true;
					cbTiposMetodosPago.Enabled = true;
				}
			}
		}

		private void Llenar()
		{
			metodo_pago.codigo = txtCodigo.Text;
			metodo_pago.nombre = txtNombre.Text;
			metodo_pago.tipo_metodo_pago_id = (cbTiposMetodosPago.EditValue.IsNullOrEmpty()) ? 0 : (int)cbTiposMetodosPago.EditValue;
            metodo_pago.tipo = (rgOpciones.SelectedIndex == 0) ? 'E' : 'S';
            metodo_pago.activo = cbActivo.Checked;
		}

		private bool Guardar()
		{
			try
			{
				if (MessageBox.Show("¿Desea guardar los cambios?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					Llenar();
					if (metodo_pago.id != 0)
					{
						return metodo_pago.Actualizar();
					}
					else
					{
						return metodo_pago.Agregar();
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
				metodo_pago = new MetodoPago();
				Cargar();
			}
		}

		private void bbiPrimero_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				metodo_pago = MetodoPago.MetodosPago().OrderBy(x => x.id).First();
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
				metodo_pago = MetodoPago.MetodosPago().Where(x => x.id < metodo_pago.id).OrderByDescending(x => x.id).First();
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
				metodo_pago = MetodoPago.MetodosPago().Where(x => x.id > metodo_pago.id).First();
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
				metodo_pago = MetodoPago.MetodosPago().OrderByDescending(x => x.id).First();
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
				if (metodo_pago.id != 0)
				{
					metodo_pago = new MetodoPago();
					Cargar(false, true);
				}
				else
				{
					object p = new { fields = "id, codigo, nombre, activo", like = true };
					object o = new { codigo = txtCodigo.Text, nombre = txtNombre.Text };
					DataTable metodos_pago = Utilidades.Busqueda("metodos_pago", o, p);
					if (metodos_pago.Rows.Count > 0)
					{
						if (metodos_pago.Rows.Count == 1)
						{
							metodo_pago = MetodoPago.Obtener((int)metodos_pago.Rows[0]["id"]);
							Cargar();
						}
						else
						{
							frmResultadosBusqueda f = new frmResultadosBusqueda(metodos_pago);
							var result = f.ShowDialog();
							if (result == DialogResult.OK)
							{
								metodo_pago = MetodoPago.Obtener(f.id);
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
			metodo_pago = new MetodoPago();
			Cargar(true);
		}

		private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && metodo_pago.id == 0)
				Buscar();
		}
	}
}