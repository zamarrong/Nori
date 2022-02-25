using NoriSDK;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace Nori
{
	public partial class frmAlmacenes : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		Almacen almacen = new Almacen();

		public frmAlmacenes(int id = 0)
		{
			InitializeComponent();
			this.MetodoDinamico();

			if (id != 0)
			{
				almacen = Almacen.Obtener(id);
				Cargar();
			}
			else
			{
				Cargar(false, true);
			}

			CargarImpresoras();

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

		private void CargarUbicaciones()
		{
			try
			{
				cbUbicacion.Properties.DataSource = almacen.Ubicaciones();
				cbUbicacion.Properties.ValueMember = "id";
				cbUbicacion.Properties.DisplayMember = "ubicacion";
			}
			catch
			{

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
			lblID.Text = almacen.id.ToString();

			txtCodigo.Text = almacen.codigo;
			txtNombre.Text = almacen.nombre;
			cbImpresoras.EditValue = almacen.impresora;
			txtNumeroCuentaAjusteInventario.Text = almacen.numero_cuenta_ajuste_inventario;

			cbUbicaciones.Checked = almacen.ubicaciones;

            CargarUbicaciones();

            cbUbicacion.EditValue = almacen.ubicacion_id;
			cbTransito.Checked = almacen.transito;
			cbActivo.Checked = almacen.activo;

			lblFechaActualizacion.Text = almacen.fecha_actualizacion.ToShortDateString();

			if (nuevo)
			{
				bbiNuevo.Enabled = false;
				bbiGuardar.Enabled = true;
				bbiGuardarCerrar.Enabled = true;
				bbiGuardarNuevo.Enabled = true;
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
					txtCodigo.Focus();
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
			almacen.codigo = txtCodigo.Text;
			almacen.nombre = txtNombre.Text;
			almacen.ubicacion_id = (cbUbicacion.EditValue.IsNullOrEmpty()) ? 0 : (int)cbUbicacion.EditValue;
			almacen.impresora = cbImpresoras.EditValue.ToString();
			almacen.numero_cuenta_ajuste_inventario = txtNumeroCuentaAjusteInventario.Text;
			almacen.ubicaciones = cbUbicaciones.Checked;
			almacen.transito = cbTransito.Checked;
			almacen.activo = cbActivo.Checked;
		}

		private bool Guardar()
		{
			try
			{
				if (MessageBox.Show("¿Desea guardar los cambios?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					Llenar();
					if (almacen.id != 0)
						return almacen.Actualizar();
					else
						return almacen.Agregar();
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
				almacen = new Almacen();
				Cargar();
			}
		}

		private void bbiPrimero_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				almacen = Almacen.Almacenes().OrderBy(x => x.id).First();
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
				almacen = Almacen.Almacenes().Where(x => x.id < almacen.id).OrderByDescending(x => x.id).First();
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
				almacen = Almacen.Almacenes().Where(x => x.id > almacen.id).First();
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
				almacen = Almacen.Almacenes().OrderByDescending(x => x.id).First();
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
				if (almacen.id != 0)
				{
					almacen = new Almacen();
					Cargar(false, true);
				}
				else
				{
					object p = new { fields = "id, codigo, nombre, activo", like = true };
					object o = new { codigo = txtCodigo.Text, nombre = txtNombre.Text };
					DataTable almacenes = Utilidades.Busqueda("almacenes", o, p);
					if (almacenes.Rows.Count > 0)
					{
						if (almacenes.Rows.Count == 1)
						{
							almacen = Almacen.Obtener((int)almacenes.Rows[0]["id"]);
							Cargar();
						}
						else
						{
							frmResultadosBusqueda f = new frmResultadosBusqueda(almacenes);
							var result = f.ShowDialog();
							if (result == DialogResult.OK)
							{
								almacen = Almacen.Obtener(f.id);
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
			almacen = new Almacen();
			Cargar(true);
		}

		private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && almacen.id == 0)
				Buscar();
		}

        private void lblUbicacion_Click(object sender, EventArgs e)
        {
            frmUbicaciones f = new frmUbicaciones((cbUbicacion.EditValue.IsNullOrEmpty()) ? 0 : (int)cbUbicacion.EditValue);
            f.ShowDialog();
        }

        private void bbiUsuarios_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmUsuariosAlmacenes f = new frmUsuariosAlmacenes();
            f.ShowDialog();
        }
    }
}