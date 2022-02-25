using NoriSDK;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Nori.Kiosco
{
	public partial class frmAltaRapidaSocio : DevExpress.XtraEditors.XtraForm
	{
		public Socio socio = new Socio();
		Socio.Direccion direccion = new Socio.Direccion();
		Socio.PersonaContacto persona_contacto = new Socio.PersonaContacto();

		public frmAltaRapidaSocio()
		{
			InitializeComponent();
			this.MetodoDinamico();
			EventoControl.SuscribirEventos(this);
			CargarListas();
		}
		private void CargarListas()
		{
			try
			{
				luePais.Properties.DataSource = Pais.Paises().Select(x => new { x.id, x.nombre });
				luePais.Properties.ValueMember = "id";
				luePais.Properties.DisplayMember = "nombre";

				lueEstado.Properties.DataSource = Estado.Estados().Select(x => new { x.id, x.nombre });
				lueEstado.Properties.ValueMember = "id";
				lueEstado.Properties.DisplayMember = "nombre";

				lueUsoPrincipal.Properties.DataSource = Documento.UsoCFDI.UsosCFDI();
				lueUsoPrincipal.Properties.ValueMember = "uso";
				lueUsoPrincipal.Properties.ValueMember = "nombre";

				txtCiudad.Text = Program.Nori.Empresa.ciudad;
				txtMunicipio.Text = Program.Nori.Empresa.municipio;

				try
				{
					var estado = Estado.Estados().Where(x => x.id == Program.Nori.UsuarioAutenticado.estado_id).Select(x => new { x.id, x.pais_id }).First();
					luePais.EditValue = estado.pais_id;
					lueEstado.EditValue = estado.id;
				}
				catch { }
			} catch { }
		}
		private void CargarSocio()
		{
			try
			{
				txtCodigo.Text = socio.codigo;
				txtRFC.Text = socio.rfc;
				txtNombre.Text = socio.nombre;

				Socio.Direccion direccion = Socio.Direccion.Obtener(socio.direccion_facturacion_id);

				lueEstado.EditValue = direccion.pais_id;
				lueEstado.EditValue = direccion.estado_id;
				lueUsoPrincipal.EditValue = socio.uso_principal;
				txtCiudad.Text = direccion.ciudad;
				txtMunicipio.Text = direccion.municipio;
				txtColonia.Text = direccion.colonia;
				txtCalle.Text = direccion.calle;
				txtNumero.Text = direccion.numero_exterior;
				txtCP.Text = direccion.cp;

				txtEmail.Text = socio.correo;
			} catch { }
		}

		private void luePais_EditValueChanged(object sender, EventArgs e)
		{
			try
			{
				lueEstado.Properties.DataSource = Estado.Estados().Where(x => x.pais_id == (int)luePais.EditValue).Select(x => new { x.id, x.nombre });
				lueEstado.Properties.ValueMember = "id";
				lueEstado.Properties.DisplayMember = "nombre";
			} catch { }
		}
		private void LimpiaCampos()
		{
			try
			{
				txtRFC.Text = string.Empty;
				txtNombre.Text = string.Empty;
				txtCiudad.Text = Program.Nori.Empresa.ciudad;
				txtMunicipio.Text = Program.Nori.Empresa.municipio;
				txtColonia.Text = string.Empty;
				txtCalle.Text = string.Empty;
				txtNumero.Text = string.Empty;
				txtCP.Text = string.Empty;
				txtEmail.Text = string.Empty;
			} catch { }
		}
		private bool Validar()
		{
			try
			{
				if (txtCodigo.Text.Length == 0 || txtRFC.Text.Length == 0 || txtNombre.Text.Length == 0 || txtCalle.Text.Length == 0 || txtNumero.Text.Length == 0 || txtCiudad.Text.Length == 0 || txtCP.Text.Length == 0 || txtColonia.Text.Length == 0 || (int)luePais.EditValue == 0 || (int)lueEstado.EditValue == 0)
					return false;
				else
					return true;
			}
			catch { return false; }
		}
		private bool Llenar()
		{
			try
			{
				//Socio
				socio.grupo_socio_id = GrupoSocio.GruposSocios().Where(x => x.tipo == socio.tipo && x.activo == true).First().id;
				socio.codigo = txtCodigo.Text;
				socio.nombre = txtNombre.Text;
				socio.nombre_comercial = txtNombre.Text;
				socio.rfc = txtRFC.Text;
				socio.correo = txtEmail.Text;
				//Dirección
				direccion.nombre = "Facturación";
				direccion.calle = txtCalle.Text;
				direccion.numero_exterior = txtNumero.Text;
				direccion.cp = txtCP.Text;
				direccion.colonia = txtColonia.Text;
				direccion.ciudad = txtCiudad.Text;
				direccion.municipio = txtMunicipio.Text;
				direccion.estado_id = (int)lueEstado.EditValue;
				direccion.pais_id = (int)luePais.EditValue;
				//Persona de contacto
				persona_contacto.codigo = (short)(Socio.PersonaContacto.PersonasContacto().Select(x => new { x.codigo }).OrderByDescending(x => x.codigo).First().codigo + 1);
				persona_contacto.nombre = socio.codigo;
				persona_contacto.nombre_persona = txtNombre.Text;
				persona_contacto.correo = txtEmail.Text;
				//CFDI
				socio.uso_principal = lueUsoPrincipal.EditValue.ToString();
                if (socio.id == 0)
				    socio.eventual = true;

				return true;
			}
			catch
			{
				return false;
			}
		}
		private bool Guardar()
		{
			try
			{
				if (MessageBox.Show("¿Desea guardar los cambios?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					if (socio.id != 0)
					{
						if (socio.Actualizar())
						{
							return true;
						}
						else
							return false;
					}
					else
					{
						Llenar();
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

							socio.Actualizar();

							return true;
						}
						else
							return false;
					}                    
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

		private void btnLimpiar_Click(object sender, EventArgs e)
		{
			LimpiaCampos();
		}

		private void frmAltaSocio_Load(object sender, EventArgs e)
		{
			if (socio.id != 0)
				CargarSocio();
		}

		private void txtCodigo_Enter(object sender, EventArgs e)
		{
			Funciones.AbrirTecladoTactil();
		}

		private void btnAceptar_Click(object sender, EventArgs e)
		{
			if (Validar())
			{
				if (Guardar())
					Close();
				else
					MessageBox.Show(NoriSDK.Nori.ObtenerUltimoError().Message, Text);
			}
			else
				MessageBox.Show("La información del socio no esta completa.");
		}

		private void btnCerrar_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}