using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraWaitForm;
using NoriSAPB1SDK;
using NoriSDK;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nori
{
	public static class Funciones
	{
		public static bool Autenticar(Usuario usuario = null)
		{
			if (usuario.IsNullOrEmpty())
				usuario = Program.Nori.UsuarioAutenticado;

			if (Program.Nori.Estacion.lector_huella)
			{
				HuellaDigital.frmHuellaDigitalVerificar f = new HuellaDigital.frmHuellaDigitalVerificar();
				f.huella_digital = usuario.huella_digital;
				f.ShowInTaskbar = false;
				f.Width = 237;
				f.Text = "Autenticar";
				f.ControlBox = false;
				f.TopMost = true;
				f.ShowDialog();
				if (f.DialogResult != DialogResult.OK)
					return false;
			}
			else
			{
				frmAutenticar f = new frmAutenticar();
				f.usuario = usuario;
				f.ShowDialog();
				if (f.DialogResult != DialogResult.OK)
					return false;
			}
			return true;
		}
		public static void Desbloquear()
		{
			if (Program.Nori.Estacion.lector_huella)
			{
				HuellaDigital.frmHuellaDigitalVerificar f = new HuellaDigital.frmHuellaDigitalVerificar();
				f.huella_digital = Program.Nori.UsuarioAutenticado.huella_digital;
				f.ShowInTaskbar = false;
				f.Width = 237;
				f.Text = "Desbloquear";
				f.ControlBox = false;
				f.TopMost = true;
				f.ShowDialog();
				if (f.DialogResult != DialogResult.OK)
				{
					Desbloquear();
				}
			}
			else
			{
				frmAutenticar f = new frmAutenticar();
				f.usuario = Program.Nori.UsuarioAutenticado;
				f.ShowDialog();
				if (f.DialogResult != DialogResult.OK)
					Desbloquear();
			}
		}
		public static void CerrarSesion()
		{
			try
			{
				for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
				{
					if (Application.OpenForms[i].Name != "frmAcceder")
						Application.OpenForms[i].Close();
				}
			}
			catch { }

			if (Application.OpenForms.Count == 1)
				Application.OpenForms[0].Show();
		}
		public static void MatarProcesos()
		{
			List<Process> processList = Process.GetProcessesByName("Nori").ToList();
			processList.ForEach(x => x.Kill());
		}
		public static bool AccederConHuella(Usuario usuario)
		{
			try
			{
				usuario = Usuario.Usuarios().Where(x => x.usuario == usuario.usuario).First();
				if (!usuario.huella_digital.IsNullOrEmpty())
				{
					HuellaDigital.frmHuellaDigitalVerificar f = new HuellaDigital.frmHuellaDigitalVerificar();
					f.huella_digital = usuario.huella_digital;
					f.Width = 237;
					f.Text = "Acceder";
					f.TopMost = true;
					if (f.ShowDialog() == DialogResult.OK)
					{
						return Program.Nori.Autenticar(usuario);
					}
					return false;
				}
				else
				{
					return false;
				}
			} catch
			{
				return false;
			}
		}
		public static IEnumerable<Control> ObtenerControles(this Control root)
		{
			var stack = new Stack<Control>();
			stack.Push(root);

			while (stack.Any())
			{
				var next = stack.Pop();
				foreach (Control child in next.Controls)
					if (child.Name.Length > 0)
						stack.Push(child);
				yield return next;
			}
		}
		public static bool ImprimirInformePredeterminado(string tipo, int parametro, int copias = 1)
		{
			try
			{
				SplashScreenManager.ShowForm(Form.ActiveForm, typeof(DemoWaitForm), true, true, false);
				SplashScreenManager.Default.SetWaitFormCaption("Por favor espere");
				SplashScreenManager.Default.SetWaitFormDescription("Imprimiendo...");

				Informe informe = Informe.Informes().Where(x => x.tipo == tipo && x.activo == true && x.predeterminado == true).First();

				copias = copias * informe.copias;

				XtraReport report = XtraReport.FromFile(Program.Nori.Configuracion.directorio_informes + @"\" + informe.informe, true);

				report.Parameters["id"].Value = parametro;
				report.Parameters["id"].Visible = false;

				if (tipo == "CX" || tipo == "CZ")
				{
					int usuario_creacion_id = Flujo.Flujos().Where(x => x.id == parametro).Select(x => x.usuario_creacion_id).First();

					report.Parameters["id"].Value = usuario_creacion_id;
					report.Parameters["id"].Visible = false;

					report.Parameters["movimiento_inicial"].Value = Flujo.Flujos().Where(x => x.codigo == "INACA" && x.usuario_creacion_id == usuario_creacion_id && x.id < parametro).OrderByDescending(x => x.id).Select(x => x.id).First();
					report.Parameters["movimiento_inicial"].Visible = false;

					report.Parameters["movimiento_final"].Value = parametro;
					report.Parameters["movimiento_final"].Visible = false;
				}

				report.ShowPrintMarginsWarning = false;
				ReportPrintTool rpt = new ReportPrintTool(report);

				string impresora = null;
				if (informe.tipo_informe.Equals('T'))
					impresora = Program.Nori.Estacion.impresora_tickets;
				else
					impresora = Program.Nori.Estacion.impresora_documentos;

				if (!informe.impresora.IsNullOrEmpty())
					impresora = informe.impresora;

				if (informe.almacen)
				{
					List<int> almacenes = Documento.Partida.Partidas().Where(x => x.documento_id == parametro).Select(x => x.almacen_id).Distinct().ToList();
					foreach (int almacen_id in almacenes)
					{
						report.Parameters["id"].Value = parametro;
						report.Parameters["id"].Visible = false;

						report.Parameters["almacen_id"].Value = almacen_id;
						report.Parameters["almacen_id"].Visible = false;
						report.CreateDocument();

						Almacen almacen = Almacen.Obtener(almacen_id);
						string impresora_almacen = impresora;

						if (!almacen.impresora.IsNullOrEmpty())
						{
							impresora_almacen = almacen.impresora;

							if (copias == 1)
								rpt.Print(impresora_almacen);
							else
								for (short i = 0; i < copias; i++)
									rpt.Print(impresora_almacen);
						}
					}
				}
				else
				{
					if (copias == 1)
						rpt.Print(impresora);
					else
						for (short i = 0; i < copias; i++)
							rpt.Print(impresora);
				}

				if (informe.informe_sequencia_id != 0)
					ImprimirInforme(informe.informe_sequencia_id, parametro);

				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return false;
			}
			finally
			{
				SplashScreenManager.CloseForm(false);
			}
		}
		public static bool ImprimirInforme(int id, int parametro, bool documento = false)
		{
			try
			{
				SplashScreenManager.ShowForm(Form.ActiveForm, typeof(DemoWaitForm), true, true, false);
				SplashScreenManager.Default.SetWaitFormCaption("Por favor espere");
				SplashScreenManager.Default.SetWaitFormDescription("Imprimiendo...");

				Informe informe = Informe.Obtener(id);

				XtraReport report = XtraReport.FromFile(Program.Nori.Configuracion.directorio_informes + @"\" + informe.informe, true);
				report.Parameters["id"].Value = parametro;
				report.Parameters["id"].Visible = false;

				report.ShowPrintMarginsWarning = false;
				ReportPrintTool rpt = new ReportPrintTool(report);

				string impresora = null;

				if (informe.tipo_informe.Equals('T'))
					impresora = Program.Nori.Estacion.impresora_tickets;
				else
					impresora = Program.Nori.Estacion.impresora_documentos;

				if (!informe.impresora.IsNullOrEmpty())
					impresora = informe.impresora;

				if (informe.almacen)
				{
					List<int> almacenes = Documento.Partida.Partidas().Where(x => x.documento_id == parametro).Select(x => x.almacen_id).Distinct().ToList();
					foreach (int almacen_id in almacenes)
					{
						report.Parameters["id"].Value = parametro;
						report.Parameters["id"].Visible = false;

						report.Parameters["almacen_id"].Value = almacen_id;
						report.Parameters["almacen_id"].Visible = false;
						report.CreateDocument();

						Almacen almacen = Almacen.Obtener(almacen_id);
						string impresora_almacen = impresora;

						if (!almacen.impresora.IsNullOrEmpty())
						{
							impresora_almacen = almacen.impresora;
							rpt.Print(impresora_almacen);
						}
					}
				}
				else
				{
					rpt.Print(impresora);
				}

				if (documento)
					Documento.Obtener(parametro).Impreso();

				if (informe.informe_sequencia_id != 0)
					ImprimirInforme(informe.informe_sequencia_id, parametro);

				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Impresión", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			finally
			{
				SplashScreenManager.CloseForm(false);
			}
		}
		public static bool ImprimirInforme(string informe, int parametro)
		{
			try
			{
				SplashScreenManager.ShowForm(Form.ActiveForm, typeof(DemoWaitForm), true, true, false);
				SplashScreenManager.Default.SetWaitFormCaption("Por favor espere");
				SplashScreenManager.Default.SetWaitFormDescription("Imprimiendo...");

				XtraReport report = XtraReport.FromFile(Program.Nori.Configuracion.directorio_informes + @"\" + informe, true);
				report.Parameters["id"].Value = parametro;
				report.Parameters["id"].Visible = false;

				report.ShowPrintMarginsWarning = false;
				ReportPrintTool rpt = new ReportPrintTool(report);

				rpt.Print();

				return true;
			}
			catch
			{
				return false;
			}
			finally
			{
				SplashScreenManager.CloseForm(false);
			}
		}
		public static bool ImprimirInforme(int id, Dictionary<string, object> parametros)
		{
			try
			{
				SplashScreenManager.ShowForm(Form.ActiveForm, typeof(DemoWaitForm), true, true, false);
				SplashScreenManager.Default.SetWaitFormCaption("Por favor espere");
				SplashScreenManager.Default.SetWaitFormDescription("Imprimiendo...");

				Informe informe = Informe.Obtener(id);

				XtraReport report = XtraReport.FromFile(Program.Nori.Configuracion.directorio_informes + @"\" + informe.informe, true);

				foreach (var parametro in parametros)
				{
					report.Parameters[parametro.Key].Value = parametro.Value;
					report.Parameters[parametro.Key].Visible = false;
				}

				report.ShowPrintMarginsWarning = false;
				ReportPrintTool rpt = new ReportPrintTool(report);

				string impresora = null;

				if (informe.tipo_informe.Equals('T'))
					impresora = Program.Nori.Estacion.impresora_tickets;
				else
					impresora = Program.Nori.Estacion.impresora_documentos;

				if (!informe.impresora.IsNullOrEmpty())
					impresora = informe.impresora;

				rpt.Print();

				if (informe.informe_sequencia_id != 0)
					ImprimirInforme(informe.informe_sequencia_id, parametros);

				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Impresión", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			finally
			{
				SplashScreenManager.CloseForm(false);
			}
		}
		public static string PDFInforme(int id, int parametro, string nombre_archivo = null)
		{
			try
			{
				string rutaPDF = @Program.Nori.Configuracion.directorio_documentos + @"\" + ((nombre_archivo.IsNullOrEmpty()) ? Utilidades.CadenaAleatoria(10) : nombre_archivo) + ".pdf";

				Informe informe = Informe.Obtener(id);

				XtraReport report = XtraReport.FromFile(Program.Nori.Configuracion.directorio_informes + @"\" + informe.informe, true);
				report.Parameters["id"].Value = parametro;
				report.Parameters["id"].Visible = false;

				PdfExportOptions pdfOptions = report.ExportOptions.Pdf;

				pdfOptions.ConvertImagesToJpeg = false;
				pdfOptions.ImageQuality = PdfJpegImageQuality.Medium;

				if (informe.almacen && informe.tipo == "PE")
				{
					List<int> almacenes = Documento.Partida.Partidas().Where(x => x.documento_id == parametro).Select(x => x.almacen_id).Distinct().ToList();
					foreach (int almacen_id in almacenes)
					{
						report.Parameters["almacen_id"].Value = almacen_id;
						report.Parameters["almacen_id"].Visible = false;

						report.ExportToPdf(rutaPDF, pdfOptions);
					}
				}
				else
				{
					report.ExportToPdf(rutaPDF, pdfOptions);
				}

				return rutaPDF;
			}
			catch
			{
				return null;
			}
		}
		public static string PDFInforme(string rutaInforme, string rutaPDF)
		{
			try
			{
				XtraReport report = XtraReport.FromFile(@"C: \Users\Z\Documents\Visual Studio 2015\RepoNori\Cfdi32.repx", true);

				PdfExportOptions pdfOptions = report.ExportOptions.Pdf;

				pdfOptions.ConvertImagesToJpeg = false;
				pdfOptions.ImageQuality = PdfJpegImageQuality.Medium;

				report.ExportToPdf(rutaPDF, pdfOptions);

				return rutaPDF;
			}
			catch
			{
				return null;
			}
		}
		public static bool PrevisualizarInforme(string informe)
		{
			try
			{
				XtraReport report = XtraReport.FromFile(Program.Nori.Configuracion.directorio_informes + @"\" + informe, true);
				ReportPrintTool rpt = new ReportPrintTool(report);

				rpt.ShowPreview();
				return true;
			}
			catch
			{
				return false;
			}
		}
		public static bool ConectarSucursal(string codigo)
		{
			try
			{
				Sucursal sucursal = Program.sucursales.Where(x => x.codigo == codigo).First();

				if (sucursal.id != 0)
				{
					SqlConnectionStringBuilder conexion_original = Program.Nori.Conexion;

					Program.Nori.Conexion.DataSource = @sucursal.servidor;
					Program.Nori.Conexion.InitialCatalog = sucursal.bd;
					if (sucursal.contraseña.IsNullOrEmpty())
						Program.Nori.Conexion.IntegratedSecurity = false;
					Program.Nori.Conexion.UserID = sucursal.usuario;
					Program.Nori.Conexion.Password = sucursal.contraseña;
					Program.Nori.Conexion.ConnectTimeout = 30;

					if (Program.Nori.Conectar())
					{
						if (Program.Nori.Autenticar(Usuario.Obtener(Program.Nori.UsuarioAutenticado.usuario), true))
						{
							MessageBox.Show("Conexión realizada correctamente.");
							return true;
						}
						else
						{
							MessageBox.Show(string.Format("El usuario ({0}) no existe en la sucursal seleccionada.", Program.Nori.UsuarioAutenticado.usuario));
						}
					}
					
					Program.Nori.Conexion = conexion_original;
					Program.Nori.Conectar();
					MessageBox.Show(string.Format("No fue posible establecer una conexión con la sucursal {0}", sucursal.nombre));

					return false;
				}
				else
				{
					MessageBox.Show(string.Format("No fue posible establecer una conexión (Sucursal no encontrada)."));

					return false;
				}
			}
			catch
			{
				return false;
			}
		}
		public static async Task<Image> CargarImagen(string ruta)
		{
			if (ruta.Length > 0)
			{
				try
				{
					ruta = Program.Nori.Configuracion.directorio_imagenes + @"\" + ruta;
					FileWebRequest request = (FileWebRequest)WebRequest.Create(@ruta);
					FileWebResponse response = (FileWebResponse)(await request.GetResponseAsync());
					Stream stream = response.GetResponseStream();
					return Image.FromStream(stream);
				}
				catch { return null; }
			}
			else
				return null;
		}
		public static bool TimbrarDocumento(Documento documento, string rfc = null, int documento_electronico_sustitucion_id = 0)
		{
			try
			{
				SplashScreenManager.ShowForm(Form.ActiveForm, typeof(DemoWaitForm), true, true, false);
				SplashScreenManager.Default.SetWaitFormCaption("Por favor espere");
				SplashScreenManager.Default.SetWaitFormDescription("Generando CFDI...");

				bool timbrado = Program.CFDI.Timbrar(documento, rfc, documento_electronico_sustitucion_id);

				if (timbrado)
					EnviarCFDiAsync(documento.id);

				return timbrado;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Timbrar documento", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			finally { SplashScreenManager.CloseForm(false); }
		}
		public static bool CancelarTimbreDocumentoElectronico(DocumentoElectronico documento_electronico)
		{
			try
			{
				SplashScreenManager.ShowForm(Form.ActiveForm, typeof(DemoWaitForm), true, true, false);
				SplashScreenManager.Default.SetWaitFormCaption("Por favor espere");
				SplashScreenManager.Default.SetWaitFormDescription("Cancelando CFDI...");

				return Program.CFDI.Cancelar(documento_electronico);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Cancelar documento", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			finally { SplashScreenManager.CloseForm(false); }
		}
		public static string CancelarCFDi(string uuid, string rfc_receptor, double total)
		{
			try
			{
				SplashScreenManager.ShowForm(Form.ActiveForm, typeof(DemoWaitForm), true, true, false);
				SplashScreenManager.Default.SetWaitFormCaption("Por favor espere");
				SplashScreenManager.Default.SetWaitFormDescription("Cancelando CFDI...");

				return Program.CFDI.Cancelar(uuid, rfc_receptor, total);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Cancelar documento", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return "No fue posible cancelar el documento.";
			}
			finally { SplashScreenManager.CloseForm(false); }
		}
		public static async Task EnviarCFDiAsync(int id, bool pago = false)
		{
			try
			{
				Usuario.CorreoElectronico correo_electronico = Usuario.CorreoElectronico.Obtener(1);
				var documento = (pago) ? Pago.Pagos().Where(x => x.id == id).Select(x => new { x.id, x.socio_id, clase = "PR" }).First() : Documento.Documentos().Where(x => x.id == id).Select(x => new { x.id, x.socio_id, x.clase }).First();

				if (documento.clase.Equals("FA") || documento.clase.Equals("NC") || documento.clase.Equals("PR"))
				{
					var socio = Socio.Socios().Where(x => x.id == documento.socio_id).Select(x => new { x.nombre, x.rfc, x.correo }).First();
					SmtpClient cliente = new SmtpClient();
					string[] destinatarios = socio.correo.Replace(" ", string.Empty).Split(';');

					string cuerpo = (correo_electronico.mensaje.IsNullOrEmpty()) ? string.Format("Te informamos que {0} ha generado un Comprobante Fiscal Digital, el cual encontrarás adjunto en este correo en su formato XML y PDF", Program.Nori.Empresa.nombre_fiscal) : correo_electronico.mensaje;
					MailMessage mensaje = new MailMessage(correo_electronico.usuario, destinatarios[0], string.Format("{0} - Le ha enviado un comprobante fiscal digital ({1})", Program.Nori.Empresa.nombre_fiscal, Documento.Clase.Clases().Where(x => x.clase == documento.clase).First().nombre), cuerpo);

					cliente.Port = correo_electronico.puerto;
					cliente.Host = correo_electronico.servidor;
					cliente.EnableSsl = correo_electronico.ssl;
					cliente.Timeout = 10000;
					cliente.DeliveryMethod = SmtpDeliveryMethod.Network;
					cliente.UseDefaultCredentials = false;
					cliente.Credentials = new NetworkCredential(correo_electronico.usuario, correo_electronico.contraseña);

					if (correo_electronico.remitente.Length > 0)
						mensaje.From = new MailAddress(correo_electronico.usuario, correo_electronico.remitente);

					mensaje.BodyEncoding = Encoding.UTF8;
					mensaje.SubjectEncoding = Encoding.UTF8;
					mensaje.IsBodyHtml = false;
					mensaje.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

					mensaje.CC.Add(correo_electronico.usuario);
					foreach (string destinatario in destinatarios)
					{
						mensaje.CC.Add(destinatario);
					}

					DocumentoElectronico documento_electronico = DocumentoElectronico.ObtenerPorDocumento(documento.id);
					if (documento_electronico.id != 0)
					{
						if (documento_electronico.estado.Equals('A'))
						{
							mensaje.Attachments.Add(new Attachment(PDFInforme(Informe.Informes().Where(x => x.tipo == documento.clase && x.activo == true && x.predeterminado_correo_electronico == true).Select(x => x.id).First(), documento.id, documento_electronico.folio_fiscal)));
							mensaje.Attachments.Add(new Attachment(string.Format(@"{0}\{1}.xml", Program.Nori.Configuracion.directorio_xml, documento_electronico.folio_fiscal)));
						}
					}

					if (mensaje.Attachments.Count < 2)
						return;

					await cliente.SendMailAsync(mensaje);
				}
				else
				{
					return;
				}
			}
			catch { }
		}

		public static async Task EnviarDocumentoAsync(int id, string correo = null)
		{
			try
			{
				SplashScreenManager.ShowForm(Form.ActiveForm, typeof(DemoWaitForm), true, true, false);
				SplashScreenManager.Default.SetWaitFormCaption("Por favor espere");
				SplashScreenManager.Default.SetWaitFormDescription("Enviando correo electrónico...");

				Usuario.CorreoElectronico correo_electronico = Usuario.CorreoElectronico.Obtener(1);
				var documento = Documento.Documentos().Where(x => x.id == id).Select(x => new { x.id, x.numero_documento, x.socio_id, x.clase }).First();

				var socio = Socio.Socios().Where(x => x.id == documento.socio_id).Select(x => new { x.nombre, x.rfc, x.correo }).First();
				SmtpClient cliente = new SmtpClient();
				string[] destinatarios = (correo != null) ? correo.Replace(" ", string.Empty).Split(';') : socio.correo.Replace(" ", string.Empty).Split(';');

				string cuerpo = (correo_electronico.mensaje.IsNullOrEmpty()) ? string.Format("Número de documento: ", documento.numero_documento) : correo_electronico.mensaje;
				MailMessage mensaje = new MailMessage(correo_electronico.usuario, destinatarios[0], string.Format("Comprobante de tu transacción ({1}) realizada en {0}", Program.Nori.Empresa.nombre_fiscal, Documento.Clase.Clases().Where(x => x.clase == documento.clase).First().nombre), cuerpo);

				cliente.Port = correo_electronico.puerto;
				cliente.Host = correo_electronico.servidor;
				cliente.EnableSsl = correo_electronico.ssl;
				cliente.Timeout = 10000;
				cliente.DeliveryMethod = SmtpDeliveryMethod.Network;
				cliente.UseDefaultCredentials = false;
				cliente.Credentials = new NetworkCredential(correo_electronico.usuario, correo_electronico.contraseña);

				if (correo_electronico.remitente.Length > 0)
					mensaje.From = new MailAddress(correo_electronico.usuario, correo_electronico.remitente);

				mensaje.BodyEncoding = Encoding.UTF8;
				mensaje.SubjectEncoding = Encoding.UTF8;
				mensaje.IsBodyHtml = false;
				mensaje.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

				mensaje.CC.Add(correo_electronico.usuario);
				foreach (string destinatario in destinatarios)
				{
					mensaje.CC.Add(destinatario);
				}

				mensaje.Attachments.Add(new Attachment(PDFInforme(Informe.Informes().Where(x => x.tipo == documento.clase && x.activo == true && x.predeterminado_correo_electronico == true).Select(x => x.id).First(), documento.id, documento.numero_documento.ToString())));

				if (mensaje.Attachments.Count < 2)
					return;

				await cliente.SendMailAsync(mensaje);
			}
			catch { }
			finally { SplashScreenManager.CloseForm(false); }
		}

		public static async Task EnviarSeguimientoAsync(string id, string numero_documento, string total, string estado_seguimiento, string nombre, string rfc, string direccion_envio, string correo)
		{
			try
			{
				Usuario.CorreoElectronico correo_electronico = Usuario.CorreoElectronico.Obtener(1);

				SmtpClient cliente = new SmtpClient();
				string[] destinatarios = correo.Replace(" ", string.Empty).Split(';');
				string html = File.ReadAllText("seguimiento.html");

				html = html.Replace("{id}", id);
				html = html.Replace("{numero_documento}", numero_documento);
				html = html.Replace("{total}", total);
				html = html.Replace("{estado_seguimiento}", estado_seguimiento);
				html = html.Replace("{nombre}", nombre);
				html = html.Replace("{rfc}", rfc);
				html = html.Replace("{direccion_envio}", direccion_envio);

				MailMessage mensaje = new MailMessage(correo_electronico.usuario, destinatarios[0], string.Format("{0} - Actualización del estado de su pedido ({1})", Program.Nori.Empresa.nombre_fiscal, estado_seguimiento), html);

				cliente.Port = correo_electronico.puerto;
				cliente.Host = correo_electronico.servidor;
				cliente.EnableSsl = correo_electronico.ssl;
				cliente.Timeout = 10000;
				cliente.DeliveryMethod = SmtpDeliveryMethod.Network;
				cliente.UseDefaultCredentials = false;
				cliente.Credentials = new NetworkCredential(correo_electronico.usuario, correo_electronico.contraseña);

				if (correo_electronico.remitente.Length > 0)
					mensaje.From = new MailAddress(correo_electronico.usuario, correo_electronico.remitente);

				mensaje.BodyEncoding = Encoding.UTF8;
				mensaje.IsBodyHtml = true;
				mensaje.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

				foreach (string destinatario in destinatarios)
				{
					mensaje.CC.Add(destinatario);
				}

				await cliente.SendMailAsync(mensaje);
			}
			catch { }
		}
		public static async Task EnviarLogisticaAsync(int documento_id)
		{
			try
			{
				Usuario.CorreoElectronico correo_electronico = Usuario.CorreoElectronico.Obtener(1);

				SmtpClient cliente = new SmtpClient();
				var correo = Usuario.Usuarios().Where(x => x.rol == 'L').Select(x => x.correo).First();
				string[] destinatarios = correo.Replace(" ", string.Empty).Split(';');
				
				var documento = Documento.Documentos().Where(x => x.id == documento_id).Select(x => new { x.id, x.numero_documento, x.clase, x.serie_id, x.almacen_id, x.almacen_destino_id, x.fecha_creacion, x.total, x.comentario, x.usuario_creacion_id }).First();
				var clase = Documento.Clase.Clases().Where(x => x.clase == documento.clase).Select(x => x.nombre).First();
				var serie = Serie.Series().Where(x => x.id == documento.serie_id).Select(x => x.nombre).First();
				var almacen_origen = Almacen.Almacenes().Where(x => x.id == documento.almacen_id).Select(x => x.nombre).First();
				var almacen_destino = Almacen.Almacenes().Where(x => x.id == documento.almacen_destino_id).Select(x => x.nombre).First();
				var usuario = Usuario.Usuarios().Where(x => x.id == documento.usuario_creacion_id).Select(x => x.nombre).First();

				string cuerpo = string.Format("<strong>{0}:</strong> {1} {2} \n <strong>Fecha:</strong> {3} \n <strong>Almacénes:</strong> De {4} a {5} \n <strong>Usuario:</strong> {6} \n <strong>Total:</strong> {7} \n <strong>Comentarios:</strong> {8} ", clase, serie, documento.numero_documento, documento.fecha_creacion.ToShortDateString(), almacen_origen, almacen_destino, usuario, documento.total.ToString("c2"), documento.comentario);
				MailMessage mensaje = new MailMessage(correo_electronico.usuario, destinatarios[0], string.Format("{0} - Nueva actividad de logística detectada | {1} ({2} {3})", Program.Nori.Empresa.nombre_fiscal, clase, serie, documento.numero_documento), cuerpo);

				cliente.Port = correo_electronico.puerto;
				cliente.Host = correo_electronico.servidor;
				cliente.EnableSsl = correo_electronico.ssl;
				cliente.Timeout = 10000;
				cliente.DeliveryMethod = SmtpDeliveryMethod.Network;
				cliente.UseDefaultCredentials = false;
				cliente.Credentials = new NetworkCredential(correo_electronico.usuario, correo_electronico.contraseña);

				if (correo_electronico.remitente.Length > 0)
					mensaje.From = new MailAddress(correo_electronico.usuario, correo_electronico.remitente);

				mensaje.BodyEncoding = Encoding.UTF8;
				mensaje.IsBodyHtml = true;
				mensaje.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

				foreach (string destinatario in destinatarios)
				{
					mensaje.CC.Add(destinatario);
				}

				await cliente.SendMailAsync(mensaje);
			}
			catch { }
		}
		public static bool TimbrarDocumento(Pago pago)
		{
			try
			{
				SplashScreenManager.ShowForm(Form.ActiveForm, typeof(DemoWaitForm), true, true, false);
				SplashScreenManager.Default.SetWaitFormCaption("Por favor espere");
				SplashScreenManager.Default.SetWaitFormDescription("Generando CFDI...");

				bool timbrado = Program.CFDI.Timbrar(pago);

				if (timbrado)
					EnviarCFDiAsync(pago.id, true);

				return timbrado;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Timbrar pago", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			finally { SplashScreenManager.CloseForm(false); }
		}
		public static string ObtenerEstado(DocumentoElectronico documento_electronico)
		{
			try
			{
				SplashScreenManager.ShowForm(Form.ActiveForm, typeof(DemoWaitForm), true, true, false);
				SplashScreenManager.Default.SetWaitFormCaption("Por favor espere");
				SplashScreenManager.Default.SetWaitFormDescription("Obteniendo estado CFDI...");

				return Program.CFDI.ObtenerEstado(documento_electronico);
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
			finally { SplashScreenManager.CloseForm(false); }
		}
		public static async void TimbrarDocumentoAsync(Pago pago)
		{
			try
			{
				await Task.Run(() => Program.CFDI.Timbrar(pago));
			}
			catch { }
		}
		public static void FacturarEntregas()
		{
			try
			{
				List<int> series = Serie.Series().Where(x => x.activo == true && x.facturar_automaticamente == true && x.serie_facturacion_id != 0 && x.clase == "EN").Select(x => x.id).ToList();
				int entregas = Documento.Documentos().Where(x => x.socio_id != Program.Nori.UsuarioAutenticado.socio_id && x.clase == "EN" && x.estado == 'A' && x.cancelado == false && series.Contains(x.serie_id) && x.importe_aplicado == 0).Select(x => x.id).Count();

				if (MessageBox.Show(string.Format("¿Actualmente hay {0} entregas a crédito pendientes de facturar, desea continuar?", entregas), "Facturar entregas", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					SplashScreenManager.ShowForm(Form.ActiveForm, typeof(DemoWaitForm), true, true, false);
					SplashScreenManager.Default.SetWaitFormCaption("Por favor espere");
					SplashScreenManager.Default.SetWaitFormDescription("Generando facturas de entregas...");

					foreach (int serie_id in series)
					{
						Documento.FacturarEntregas(serie_id, false, true);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Facturar entregas", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally { SplashScreenManager.CloseForm(false); }
		}
		public static void AbrirTecladoTactil()
		{
			try
			{
				string progFiles = @"C:\Program Files\Common Files\Microsoft Shared\ink";
				string keyboardPath = Path.Combine(progFiles, "TabTip.exe");
				Process keyboardProc = Process.Start(keyboardPath);
			} catch { }
		}
		public static void AbrirArchivo(string archivo)
		{
			try
			{
				Process.Start(@archivo);
			}
			catch { }
		}
		public static async void TransmitirRecibir()
		{
			SplashScreenManager.ShowForm(Form.ActiveForm, typeof(DemoWaitForm), true, true, false);
			SplashScreenManager.Default.SetWaitFormCaption("Por favor espere");
			SplashScreenManager.Default.SetWaitFormDescription("Transmitiendo...");

			try
			{
				if (!Program.Nori.Configuracion.api_url.IsNullOrEmpty())
				{
					API.Transmitir transmitir = new API.Transmitir();
					SplashScreenManager.Default.SetWaitFormDescription("Recibiendo...");
					API.Recibir recibir = new API.Recibir();
					SplashScreenManager.Default.SetWaitFormDescription("Recibiendo artículos...");
					await recibir.Articulos();
					SplashScreenManager.Default.SetWaitFormDescription("Recibiendo descuentos...");
					await recibir.Descuentos();
					SplashScreenManager.Default.SetWaitFormDescription("Transmitiendo socios...");
					await transmitir.Socios();
					SplashScreenManager.Default.SetWaitFormDescription("Transmitiendo documentos...");
					await transmitir.Documentos();
					SplashScreenManager.Default.SetWaitFormDescription("Recibiendo socios...");
					await recibir.Socios();
				}
				else
				{
					MessageBox.Show("No esta configurada la URL para el API.");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Transmitir/Recibir", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally { SplashScreenManager.CloseForm(false); }
		}
		public static void Cargando(string titulo, string descripcion)
		{
			SplashScreenManager.ShowForm(Form.ActiveForm, typeof(DemoWaitForm), true, true, false);
			SplashScreenManager.Default.SetWaitFormCaption(titulo);
			SplashScreenManager.Default.SetWaitFormDescription(descripcion);
		}
		public static void DescartarCargando()
		{
			SplashScreenManager.CloseForm(false);
		}
		public static bool ServidorDisponible(string servidor)
		{
			int i = servidor.IndexOf(@"\");

			if (i > 0)
				servidor = servidor.Substring(0, i);

			Ping ping = new Ping();
			PingReply respuesta = ping.Send(servidor);

			if (respuesta.Status == IPStatus.Success)
				return true;

			return false;
		}
		public static string DigitosAleatorios(int length)
		{
			var random = new Random();
			string s = string.Empty;
			for (int i = 0; i < length; i++)
				s = String.Concat(s, random.Next(10).ToString());
			return s;
		}
		public static void NoriDynamic()
		{
			if (File.Exists("NoriDynamic.cs"))
			{
				string codigo = File.ReadAllText("NoriDynamic.cs");

				CodeDomProvider compilador = CodeDomProvider.CreateProvider("CSharp");
				CompilerParameters parametros = new CompilerParameters();
				// Agregar ensamblados
				List<AssemblyName> ensamblados = Assembly.GetExecutingAssembly().GetReferencedAssemblies().ToList();
				parametros.ReferencedAssemblies.Add(Assembly.GetEntryAssembly().Location);
				ensamblados.ForEach(x => parametros.ReferencedAssemblies.Add(x.Name + ".dll"));
				parametros.GenerateInMemory = true;
				parametros.GenerateExecutable = false;
				parametros.OutputAssembly = "NoriDynamic.dll";

				// Compilar
				CompilerResults compilacion = compilador.CompileAssemblyFromSource(parametros, codigo);

				if (compilacion.Errors.HasErrors)
				{
					string lcErrorMsg = "";

					// Error
					lcErrorMsg = compilacion.Errors.Count.ToString() + " Errores:";
					for (int x = 0; x < compilacion.Errors.Count; x++)
						lcErrorMsg = lcErrorMsg + "\r\nLinea: " + compilacion.Errors[x].Line.ToString() + " - " + compilacion.Errors[x].ErrorText;

					MessageBox.Show(lcErrorMsg, "Compilador Nori", MessageBoxButtons.OK, MessageBoxIcon.Error);

					return;
				}

				Assembly ensamblado = compilacion.CompiledAssembly;
				Program.ObjetoDinamico = ensamblado.CreateInstance("Nori.NoriDynamic");
				if (Program.ObjetoDinamico == null)
				{
					MessageBox.Show("No se pudo cargar la clase.");
					return;
				}

				try
				{
					Program.ObjetoDinamico.GetType().InvokeMember("DynamicCode", BindingFlags.InvokeMethod, null, Program.ObjetoDinamico, null);
				}
				catch (Exception loError)
				{
					MessageBox.Show(loError.Message, "Compilador Nori", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}
		public static void MetodoDinamico(object[] parametros, string metodo = "DynamicMethod")
		{
			try
			{
				if (Program.ObjetoDinamico != null)
					Program.ObjetoDinamico.GetType().InvokeMember(metodo, BindingFlags.InvokeMethod, null, Program.ObjetoDinamico, parametros);
			}
			catch
			{ 
				//
			}
		}
		public static void MetodoDinamico(this object obj, string metodo = "DynamicMethod")
		{
			object[] parametros = new object[1];
			parametros[0] = obj;
			MetodoDinamico(parametros, metodo);
		}
	}
}