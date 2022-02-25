using DevExpress.XtraBars;
using NoriSDK;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Nori
{
    public partial class frmEmpresa : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        Empresa empresa = new Empresa();

        public frmEmpresa()
        {
            InitializeComponent();
			this.MetodoDinamico();

            empresa = Empresa.Obtener();

            cbTipo.Properties.DataSource = Empresa.TipoPersona.Tipos();
            cbTipo.Properties.ValueMember = "tipo";
            cbTipo.Properties.DisplayMember = "nombre";
            cbTipo.EditValue = Empresa.TipoPersona.ObtenerPredeterminado();

            Cargar();
        }

        private void Cargar()
        {
            txtNombreFiscal.Text = empresa.nombre_fiscal;
            txtNombreComercial.Text = empresa.nombre_comercial;
            txtEslogan.Text = empresa.eslogan;
            txtRFC.Text = empresa.rfc;
            txtRegimenFiscal.Text = empresa.regimen_fiscal;
            cbTipo.EditValue = empresa.tipo_persona;
            txtTelefono.Text = empresa.telefono;
            txtTelefono2.Text = empresa.telefono2;
            txtCorreo.Text = empresa.correo;
            txtSitioWeb.Text = empresa.sitio_web;

            txtCalle.Text = empresa.calle;
            txtColonia.Text = empresa.colonia;
            txtNumeroExterior.Text = empresa.numero_exterior;
            txtNumeroInterior.Text = empresa.numero_interior;
            txtCP.Text = empresa.cp;
            txtCiudad.Text = empresa.ciudad;
            txtMunicipio.Text = empresa.municipio;
            txtEstado.Text = empresa.estado;
            txtPais.Text = empresa.pais;

            pbImagen.LoadImage(empresa.logotipo);

            lblFechaActualizacion.Text = empresa.fecha_actualizacion.ToShortDateString();
        }

        private void Llenar()
        {
            empresa.nombre_fiscal = txtNombreFiscal.Text;
            empresa.nombre_comercial = txtNombreComercial.Text; 
            empresa.eslogan = txtEslogan.Text;
            empresa.rfc = txtRFC.Text;
            empresa.regimen_fiscal = txtRegimenFiscal.Text;
            empresa.tipo_persona = (char)cbTipo.EditValue;
            empresa.telefono = txtTelefono.Text;
            empresa.telefono2 = txtTelefono2.Text;
            empresa.correo = txtCorreo.Text;
            empresa.sitio_web = txtSitioWeb.Text;

            empresa.calle = txtCalle.Text;
            empresa.colonia = txtColonia.Text;
            empresa.numero_exterior = txtNumeroExterior.Text;
            empresa.numero_interior = txtNumeroInterior.Text;
            empresa.cp = txtCP.Text;
            empresa.ciudad = txtCiudad.Text;
            empresa.municipio = txtMunicipio.Text;
            empresa.estado = txtEstado.Text;
            empresa.pais = txtPais.Text;
        }

        private bool Guardar()
        {
            try
            {
                if (MessageBox.Show("¿Desea guardar los cambios?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Llenar();
                    if (empresa.id != 0)
                        return empresa.Actualizar();
                    return false;
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
        private void bbiGuardar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Guardar();
        }

        private void btnImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Archivos de imagen (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            open.Title = "Por favor seleccione una imagen.";
            if (open.ShowDialog() == DialogResult.OK)
            {
                string archivo = (Program.Nori.Configuracion.directorio_imagenes + @"\" + open.SafeFileName);
                File.Copy(open.FileName, archivo, true);
                pbImagen.Image = new Bitmap(archivo);
                empresa.logotipo = open.SafeFileName;
            }
        }
    }
}