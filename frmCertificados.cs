using NoriSDK;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Nori
{
	public partial class frmCertificados : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		Certificado certificado = new Certificado();

		public frmCertificados(int id = 0)
		{
			InitializeComponent();
			this.MetodoDinamico();

			if (id != 0)
			{
				certificado = Certificado.Obtener(id);
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
			lblID.Text = certificado.id.ToString();

			txtNombre.Text = certificado.nombre;
			txtCER.Text = certificado.cer;
			txtKEY.Text = certificado.key;
			txtContraseña.Text = certificado.contraseña;
			txtPFX.Text = certificado.pfx;
			txtContraseñaPFX.Text = certificado.contraseña_pfx;
			cbActivo.Checked = certificado.activo;

			lblFechaActualizacion.Text = certificado.fecha_actualizacion.ToShortDateString();

			if (nuevo)
			{
				bbiNuevo.Enabled = false;
				bbiGuardar.Enabled = true;
				bbiGuardarCerrar.Enabled = true;
				bbiGuardarNuevo.Enabled = true;
				txtNombre.Focus();
			}
			else
			{
				if (busqueda)
				{
					bbiNuevo.Enabled = true;
					bbiGuardar.Enabled = false;
					bbiGuardarCerrar.Enabled = false;
					bbiGuardarNuevo.Enabled = false;
					txtNombre.Focus();
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
			certificado.nombre = txtNombre.Text;
			certificado.cer = txtCER.Text;
			certificado.key = txtKEY.Text;
			certificado.contraseña = txtContraseña.Text;
			certificado.pfx = txtPFX.Text;
			certificado.contraseña_pfx = txtContraseñaPFX.Text;
			certificado.activo = cbActivo.Checked;
		}

		private bool Guardar()
		{
			try
			{
				if (MessageBox.Show("¿Desea guardar los cambios?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					Llenar();
					if (certificado.id != 0)
						return certificado.Actualizar();
					else
						return certificado.Agregar();
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
				certificado = new Certificado();
				Cargar();
			}
		}

		private void bbiPrimero_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				certificado = Certificado.Certificados().OrderBy(x => x.id).First();
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
				certificado = Certificado.Certificados().Where(x => x.id < certificado.id).OrderByDescending(x => x.id).First();
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
				certificado = Certificado.Certificados().Where(x => x.id > certificado.id).First();
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
				certificado = Certificado.Certificados().OrderByDescending(x => x.id).First();
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
				if (certificado.id != 0)
				{
					certificado = new Certificado();
					Cargar(false, true);
				}
				else
				{
					object p = new { fields = "id, nombre, activo", like = true };
					object o = new { nombre = txtNombre.Text };
					DataTable certificados = Utilidades.Busqueda("certificados", o, p);
					if (certificados.Rows.Count > 0)
					{
						if (certificados.Rows.Count == 1)
						{
							certificado = Certificado.Obtener((int)certificados.Rows[0]["id"]);
							Cargar();
						}
						else
						{
							frmResultadosBusqueda f = new frmResultadosBusqueda(certificados);
							var result = f.ShowDialog();
							if (result == DialogResult.OK)
							{
								certificado = Certificado.Obtener(f.id);
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
			certificado = new Certificado();
			Cargar(true);
		}

		private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && certificado.id == 0)
				Buscar();
		}

		private void txtCER_DoubleClick(object sender, EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter = "CER (*.cer) | *.cer";
			dialog.Title = "Por favor seleccione un archivo.";
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				if (dialog.FileName.Length > 254)
					MessageBox.Show("La ruta es mayor de 254 caracteres, por favor seleccione una ruta más corta");
				else
					txtCER.Text = dialog.FileName;
			}
		}

		private void txtKEY_DoubleClick(object sender, EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter = "KEY (*.key) | *.key";
			dialog.Title = "Por favor seleccione un archivo.";
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				if (dialog.FileName.Length > 254)
					MessageBox.Show("La ruta es mayor de 254 caracteres, por favor seleccione una ruta más corta");
				else
					txtKEY.Text = dialog.FileName;
			}
		}

		private void txtPFX_DoubleClick(object sender, EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter = "PFX (*.pfx) | *.pfx";
			dialog.Title = "Por favor seleccione un archivo.";
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				if (dialog.FileName.Length > 254)
					MessageBox.Show("La ruta es mayor de 254 caracteres, por favor seleccione una ruta más corta");
				else
					txtPFX.Text = dialog.FileName;
			}
		}
	}
}