using NoriSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace Nori
{
	public partial class frmCorreoElectronico : DevExpress.XtraEditors.XtraForm
	{
		public Socio socio { get; set; } = new Socio();
		public List<string> anexos { get; set; } = new List<string>();
		public List<Usuario.CorreoElectronico> correos_electronicos = new List<Usuario.CorreoElectronico>();
		public Usuario.CorreoElectronico correo_electronico = new Usuario.CorreoElectronico();
		public frmCorreoElectronico()
		{
			InitializeComponent();
			this.MetodoDinamico();
			CargarListas();
		}

		private void CargarListas()
		{
			try
			{
				correos_electronicos = Usuario.CorreoElectronico.CorreosElectronicos().Where(x => x.usuario_id == Program.Nori.UsuarioAutenticado.id && x.activo == true).ToList();
				cbCorreoElectronico.Properties.DataSource = correos_electronicos;
				cbCorreoElectronico.Properties.ValueMember = "id";
				cbCorreoElectronico.Properties.DisplayMember = "usuario";
				cbCorreoElectronico.EditValue = correos_electronicos.First().id;
			} catch { }
		}

		private void btnAnexo_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog open = new OpenFileDialog();
			if (open.ShowDialog() == DialogResult.OK)
			{
				lbAnexos.Items.Add(open.FileName);
			}
		}

		public bool EnviarCorreo()
		{
			try
			{
                string[] destinatarios = txtDestinatario.Text.Replace(" ", string.Empty).Split(';');

                SmtpClient cliente = new SmtpClient();
				MailMessage mensaje = new MailMessage(correo_electronico.usuario, destinatarios[0], txtAsunto.Text, txtMensaje.Text);

				cliente.Port = correo_electronico.puerto;
				cliente.Host = correo_electronico.servidor;
				cliente.EnableSsl = correo_electronico.ssl;
				cliente.Timeout = 10000;
				cliente.DeliveryMethod = SmtpDeliveryMethod.Network;
				cliente.UseDefaultCredentials = false;
				cliente.Credentials = new System.Net.NetworkCredential(correo_electronico.usuario, correo_electronico.contraseña);

				if (correo_electronico.remitente.Length > 0)
					mensaje.From = new MailAddress(correo_electronico.usuario, correo_electronico.remitente);

				mensaje.BodyEncoding = Encoding.UTF8;
				mensaje.IsBodyHtml = true;
				mensaje.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                foreach (string destinatario in destinatarios)
                {
                    mensaje.CC.Add(destinatario);
                }

                foreach (string destinatario in lbDestinatarios.Items.Where(x => x.CheckState == CheckState.Checked).Select(x => x.Value).ToList())
				{
					mensaje.CC.Add(destinatario);
				}

				foreach (string anexo in lbAnexos.Items.Where(x => x.CheckState == CheckState.Checked).Select(x => x.Value).ToList())
				{
					mensaje.Attachments.Add(new Attachment(anexo));
				}

				cliente.Send(mensaje);

				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}

		private void frmCorreoElectronico_Load(object sender, EventArgs e)
		{
			//Socio
			txtDestinatario.Text = socio.correo;
			foreach (Socio.PersonaContacto persona_contacto in socio.PersonasContacto())
			{
				lbDestinatarios.Items.Add(persona_contacto.correo);
			}

			//Anexos
			foreach (string anexo in anexos)
			{
				lbAnexos.Items.Add(anexo);
			}
		}

		private void btnEnviar_Click(object sender, EventArgs e)
		{
			if (EnviarCorreo())
			{
				MessageBox.Show("Mensaje enviado");
				Close();
			}
		}

		private void cbCorreoElectronico_EditValueChanged(object sender, EventArgs e)
		{
			try
			{
				correo_electronico = correos_electronicos.Where(x => x.id == (int)cbCorreoElectronico.EditValue).First();
				CargarCorreoElectronico();
			} catch { }
		}

		private void CargarCorreoElectronico()
		{
			txtAsunto.Text = correo_electronico.asunto;
			txtMensaje.Text = correo_electronico.mensaje;
		}
	}
}