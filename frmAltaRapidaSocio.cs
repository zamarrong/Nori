using NoriSDK;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Nori
{
	public partial class frmAltaRapidaSocio : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		Socio socio = new Socio();
		Socio.Direccion direccion = new Socio.Direccion();
		Socio.PersonaContacto persona_contacto = new Socio.PersonaContacto();
		public frmAltaRapidaSocio()
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
			cbPaises.Properties.DataSource = Pais.Paises().Select(x => new { x.id, x.nombre });
			cbPaises.Properties.ValueMember = "id";
			cbPaises.Properties.DisplayMember = "nombre";

			try
			{
				var estado = Estado.Estados().Where(x => x.id == Program.Nori.UsuarioAutenticado.estado_id).Select(x => new { x.id, x.pais_id }).First();
				cbPaises.EditValue = estado.pais_id;
				cbEstados.EditValue = estado.id;
			} catch { }

			cbSocios.Properties.DataSource = Socio.Socios().Where(x => x.activo == true).Select(x => new { x.id, x.codigo, x.nombre }).ToList();
			cbSocios.Properties.ValueMember = "id";
			cbSocios.Properties.DisplayMember = "nombre";
			cbSocios.EditValue = Program.Nori.UsuarioAutenticado.socio_id;

			cbUsoPrincipal.Properties.DataSource = Documento.UsoCFDI.UsosCFDI();
			cbUsoPrincipal.Properties.ValueMember = "uso";
			cbUsoPrincipal.Properties.DisplayMember = "nombre";
		}

		private void Cargar()
		{
			txtCodigo.Text = socio.codigo;
			txtNombre.Text = socio.nombre;
			txtNombreComercial.Text = socio.nombre_comercial;
			txtRFC.Text = socio.rfc;
			txtTelefono.Text = socio.telefono;
			txtTelefono2.Text = socio.telefono2;
			txtTelefonoCelular.Text = socio.celular;
			txtCorreo.Text = socio.correo;

			if (Program.Nori.UsuarioAutenticado.rol.Equals('C'))
				socio.eventual = true;

			cbEventual.Checked = socio.eventual;
			if (socio.socio_eventual_id != 0)
				cbSocios.EditValue = socio.socio_eventual_id;

			cbUsoPrincipal.EditValue = socio.uso_principal;

			txtCodigo.Focus();
		}

		private bool Validar()
		{
			try {
				if (txtCodigo.Text.Length == 0 || txtRFC.Text.Length == 0 || txtNombre.Text.Length == 0 || txtCalle.Text.Length == 0 || txtNumeroExterior.Text.Length == 0 || txtCiudad.Text.Length == 0 || txtCP.Text.Length == 0 || txtColonia.Text.Length == 0 || txtTelefono.Text.Length == 0 || txtCorreo.Text.Length == 0 || (int)cbPaises.EditValue == 0 || (int)cbEstados.EditValue == 0)
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
				socio.codigo = txtCodigo.Text;
				socio.nombre = txtNombre.Text;
				socio.nombre_comercial = txtNombreComercial.Text;
				socio.rfc = txtRFC.Text;
				socio.uso_principal = cbUsoPrincipal.EditValue.ToString();
                socio.vendedor_id = Program.Nori.UsuarioAutenticado.vendedor_id;
				socio.eventual = cbEventual.Checked;

				try
				{
					if (socio.eventual)
						socio.socio_eventual_id = (int)cbSocios.EditValue;
				} catch { }

				socio.telefono = txtTelefono.Text;
				socio.telefono2 = txtTelefono2.Text;
				socio.celular = txtTelefonoCelular.Text;
				socio.correo = txtCorreo.Text;
				//Dirección
				direccion.nombre = "Facturación";
				direccion.calle = txtCalle.Text;
				direccion.numero_exterior = txtNumeroExterior.Text;
				direccion.numero_interior = txtNumeroInterior.Text;
				direccion.cp = txtCP.Text;
				direccion.colonia = txtColonia.Text;
				direccion.ciudad = txtCiudad.Text;
				direccion.municipio = txtMunicipio.Text;
				direccion.estado_id = (int)cbEstados.EditValue;
				direccion.pais_id = (int)cbPaises.EditValue;
				//Persona de contacto
				try
				{
					persona_contacto.codigo = (short)(Socio.PersonaContacto.PersonasContacto().Select(x => new { x.codigo }).OrderByDescending(x => x.codigo).First().codigo + 1);
				} catch { persona_contacto.codigo = 1; }
				persona_contacto.nombre = txtCodigo.Text;
				persona_contacto.nombre_persona = txtNombre.Text;
				persona_contacto.telefono = txtTelefono.Text;
				persona_contacto.celular = txtTelefonoCelular.Text;
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

		private void cbPaises_EditValueChanged(object sender, System.EventArgs e)
		{
			cbEstados.Properties.DataSource = Estado.Estados().Where(x => x.pais_id == (int)cbPaises.EditValue).Select(x => new { x.id, x.nombre });
			cbEstados.Properties.ValueMember = "id";
			cbEstados.Properties.DisplayMember = "nombre";
		}

		private void btnHuellaDigital_Click(object sender, System.EventArgs e)
		{
			if (Program.Nori.Estacion.lector_huella)
			{
				if (MessageBox.Show("¿Desea agregar una huella digital?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					HuellaDigital.frmHuellaDigitalAgregar f = new HuellaDigital.frmHuellaDigitalAgregar();
					var result = f.ShowDialog();
					if (result == DialogResult.OK)
						persona_contacto.huella_digital = f.huella_digital;
				}
			}
		}

		private void cbEventual_CheckedChanged(object sender, System.EventArgs e)
		{
			cbSocios.Visible = cbEventual.Checked;
		}

		private void frmAltaRapidaSocio_Load(object sender, EventArgs e)
		{

		}
	}
}