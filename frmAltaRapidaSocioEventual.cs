using NoriSDK;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Nori
{
	public partial class frmAltaRapidaSocioEventual : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		Socio socio = new Socio();
		Socio.Direccion direccion = new Socio.Direccion();
		Socio.PersonaContacto persona_contacto = new Socio.PersonaContacto();
		public frmAltaRapidaSocioEventual()
		{
			InitializeComponent();
			this.MetodoDinamico();
		
			EventoControl.SuscribirEventos(this);

			CargarListas();

			Cargar();
		}

		private void bbiGuardarCerrar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (Validar())
			{
				if (Guardar())
				{
					DialogResult = DialogResult.OK;
					Close();
				}
				else
					MessageBox.Show(NoriSDK.Nori.ObtenerUltimoError().Message, Text);
			}
			else
				MessageBox.Show("La información del socio no esta completa.");
		}

		private void CargarListas()
		{
			cbUsoPrincipal.Properties.DataSource = Documento.UsoCFDI.UsosCFDI();
			cbUsoPrincipal.Properties.ValueMember = "uso";
			cbUsoPrincipal.Properties.DisplayMember = "nombre";
		}

		private void Cargar()
		{
			txtNombre.Text = socio.nombre;
			txtRFC.Text = socio.rfc;
			txtCorreo.Text = socio.correo;

			cbUsoPrincipal.EditValue = socio.uso_principal;

            ActiveControl = txtRFC;
			txtRFC.Focus();
		}

		private bool Validar()
		{
			try {
				if (txtRFC.Text.Length == 0 || txtNombre.Text.Length == 0 || txtCorreo.Text.Length == 0)
					return false;
				else
					return true;
			} catch { return false; }
		}

		private bool Llenar()
		{
			try
			{
				//Socio
				socio.grupo_socio_id = GrupoSocio.GruposSocios().Where(x => x.tipo == socio.tipo && x.activo == true).First().id;
                socio.codigo = txtRFC.Text;
				socio.nombre = txtNombre.Text;
				socio.rfc = txtRFC.Text;
				socio.uso_principal = cbUsoPrincipal.EditValue.ToString();
                socio.vendedor_id = Program.Nori.UsuarioAutenticado.vendedor_id;
                socio.eventual = true;
                socio.socio_eventual_id = Program.Nori.UsuarioAutenticado.socio_id;

				socio.correo = txtCorreo.Text;
				//Dirección
				direccion.nombre = "Facturación";
				direccion.calle = "";
				direccion.numero_exterior = "";
				direccion.cp = txtCP.Text;
				direccion.colonia = "";
				direccion.ciudad = "";
				direccion.municipio = "";
                direccion.estado_id = Program.Nori.UsuarioAutenticado.estado_id;
                var estado = Estado.Obtener(direccion.estado_id);
                direccion.pais_id = estado.pais_id;
				//Persona de contacto
				try
				{
					persona_contacto.codigo = (short)(Socio.PersonaContacto.PersonasContacto().Select(x => new { x.codigo }).OrderByDescending(x => x.codigo).First().codigo + 1);
				} catch { persona_contacto.codigo = 1; }
                persona_contacto.nombre = socio.codigo;
				persona_contacto.nombre_persona = txtNombre.Text;
				persona_contacto.telefono = "";
				persona_contacto.celular = "";
				persona_contacto.correo = txtCorreo.Text;

				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return false;
			}
		}

		private bool Guardar()
		{
			try
			{
				if (MessageBox.Show("¿Desea guardar los cambios?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					if (Llenar())
					{
						if (socio.Agregar())
						{
							direccion.socio_id = socio.id;
							persona_contacto.socio_id = socio.id;
							direccion.Agregar();

							socio.direccion_facturacion_id = direccion.id;

							direccion.nombre = "Envío";
							direccion.tipo = 'E';

							direccion.Agregar();

							socio.direccion_envio_id = direccion.id;

							persona_contacto.Agregar();

							socio.persona_contacto_id = persona_contacto.id;

							socio.Actualizar(false);

							return true;
						}
					}
				}

				return false;
			}
			catch
			{
				MessageBox.Show(NoriSDK.Nori.ObtenerUltimoError().Message, Text);
				return false;
			}
		}
	}
}