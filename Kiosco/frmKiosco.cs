using NoriSDK;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Nori.Kiosco
{
	public partial class frmKiosco : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		Documento documento = new Documento();
		public frmKiosco()
		{
			InitializeComponent();
			this.MetodoDinamico();
			lblTitulo.Text = Program.Nori.Empresa.nombre_comercial;
			txtNumeroDocumento.Focus();
			CargarImagenFondo();
		}

		private async void CargarImagenFondo()
		{
			pbLogo.SetImage(await Funciones.CargarImagen(Program.Nori.Empresa.logotipo));
		}

		private void txtNumeroDocumento_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
				txtPIN.Focus();
		}

		private void BuscarDocumento(string NumeroDocumento, string PIN)
		{
			try
			{
				documento = Documento.Obtener(int.Parse(NumeroDocumento));
				Documento factura = new Documento();
				if (documento.id == 0)
				{
					MessageBox.Show("Documento no encontrado.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
					txtNumeroDocumento.Focus();
					return;
				}
				else
				{
					if (PIN != documento.pin.ToString())
					{
						MessageBox.Show("El PIN no coincide con el del documento", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
						txtPIN.Text = string.Empty;
						txtPIN.Focus();
						return;
					}
					if (documento.clase == "EN" && documento.estado != 'C')
					{
						if (!documento.cancelado)
						{
							factura.CopiarDe(documento, "FA");

							if (factura.socio_id == Usuario.Usuarios().Where(x => x.id == documento.usuario_creacion_id).Select(x => x.socio_id).First())
							{
								frmSocio frm = new frmSocio();
								frm.ShowDialog();
								if (frm.DialogResult == DialogResult.OK)
								{
									Socio nuevo_socio = Socio.Obtener(frm.codigo_socio);
                                    factura.EstablecerSocio(nuevo_socio);
								}
								else
								{
									MessageBox.Show("No se generó la factura ya que no se ha establecido un socio válido", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
									return;
								}
							}

							if (factura.socio_id != documento.socio_id)
								factura.partidas.All(x => { x.documento_id = 0; return true; });

							factura.generar_documento_electronico = factura.GenerarDocumentoElectronico();

							if (factura.Agregar())
							{
								if (factura.socio_id == documento.socio_id)
									documento.Cerrar();
								else
									documento.Cancelar(true);

								if (factura.DocumentoElectronico().id == 0)
								{
									if (factura.generar_documento_electronico)
									{
										if (!Funciones.TimbrarDocumento(factura))
										{
											string error = "Error desconocido.";
											try
											{
												error = DocumentoElectronico.DocumentosElectronicos().Where(x => x.documento_id == factura.id).Select(x => new { x.mensaje }).First().mensaje;
											}
											catch { }
											MessageBox.Show("Ocurrió un error al timbrar la factura: " + error, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
											return;
										}
									}
									else
									{
										MessageBox.Show("El documento aún no se ha timbrado por favor intente más tarde.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
										return;
									}
								}

								Funciones.ImprimirInformePredeterminado(factura.clase, factura.id);
							}
							else
								MessageBox.Show("Ocurrió un error al tratar de hacer la factura: " + NoriSDK.Nori.ObtenerUltimoError().Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
						else
							MessageBox.Show("Esta remisión no se puede facturar ya que se encuentra cancelada.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					else
					{
						Funciones.ImprimirInformePredeterminado(documento.clase, documento.id);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				btnLimpiar.PerformClick();
			}
		}

		private void btnFacturar_Click(object sender, EventArgs e)
		{
			BuscarDocumento(txtNumeroDocumento.Text, txtPIN.Text);
		}

		private void btnLimpiar_Click(object sender, EventArgs e)
		{
			txtNumeroDocumento.Text = string.Empty;
			txtPIN.Text = string.Empty;
			txtNumeroDocumento.Focus();
		}

		private void txtPIN_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				BuscarDocumento(txtNumeroDocumento.Text, txtPIN.Text);
			if (e.KeyCode == Keys.Tab)
				btnFacturar.Focus();
		}

		private void txtNumeroDocumento_Enter(object sender, EventArgs e)
		{
			Funciones.AbrirTecladoTactil();
		}
	}
}