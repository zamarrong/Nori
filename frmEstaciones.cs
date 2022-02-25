using NoriSDK;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace Nori
{
    public partial class frmEstaciones : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        Estacion estacion = new Estacion();

        public frmEstaciones(int id = 0)
        {
            InitializeComponent();
			this.MetodoDinamico();
            if (id != 0)
            {
                estacion = Estacion.Obtener(id);
                Cargar();
            }
            else
            {
                Cargar(false, true);
            }

            CargarImpresoras();
            CargarListas();

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
            lblID.Text = estacion.id.ToString();

            txtCodigo.Text = estacion.codigo;
            txtNombre.Text = estacion.nombre;
            cbImpresoraTickets.EditValue = estacion.impresora_tickets;
            cbImpresoraDocumentos.EditValue = estacion.impresora_documentos;
            cbLectorHuella.Checked = estacion.lector_huella;
            cbBascula.Checked = estacion.bascula;
            cbBasculas.EditValue = estacion.bascula_id;
            cbImpresion.Checked = estacion.impresion;
            cbEnvioCorreoAutomatico.Checked = estacion.envio_correo_automatico;

            cbActivo.Checked = estacion.activo;

            lblFechaActualizacion.Text = estacion.fecha_actualizacion.ToShortDateString();

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

        private void CargarImpresoras()
        {
            List<string> impresoras = new List<string>();
            foreach (var printer in PrinterSettings.InstalledPrinters)
            {
                impresoras.Add(printer.ToString());
            }
            cbImpresoraTickets.Properties.DataSource = impresoras;
            cbImpresoraDocumentos.Properties.DataSource = impresoras;
        }

        private void CargarListas()
        {
            cbBasculas.Properties.DataSource = Bascula.Basculas().Where(x => x.activo == true).Select(x => new { x.id, x.puerto, x.nombre }).ToList();
            cbBasculas.Properties.ValueMember = "id";
            cbBasculas.Properties.DisplayMember = "nombre";
        }

        private void Llenar()
        {
            estacion.codigo = txtCodigo.Text;
            estacion.nombre = txtNombre.Text;
            estacion.impresora_tickets = cbImpresoraTickets.EditValue.ToString();
            estacion.impresora_documentos = cbImpresoraDocumentos.EditValue.ToString();
            estacion.lector_huella = cbLectorHuella.Checked;
            estacion.bascula = cbBascula.Checked;
            estacion.bascula_id = (cbBasculas.EditValue.IsNullOrEmpty()) ? 0 : (int)cbBasculas.EditValue;
            estacion.impresion = cbImpresion.Checked;
            estacion.envio_correo_automatico = cbEnvioCorreoAutomatico.Checked;
            estacion.activo = cbActivo.Checked;
        }

        private bool Guardar()
        {
            try
            {
                if (MessageBox.Show("¿Desea guardar los cambios?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Llenar();
                    if (estacion.id != 0)
                    {
                        return estacion.Actualizar();
                    }
                    else
                    {
                        return estacion.Agregar();
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
                estacion = new Estacion();
                Cargar();
            }
        }

        private void bbiPrimero_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                estacion = Estacion.Estaciones().OrderBy(x => x.id).First();
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
                estacion = Estacion.Estaciones().Where(x => x.id < estacion.id).OrderByDescending(x => x.id).First();
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
                estacion = Estacion.Estaciones().Where(x => x.id > estacion.id).First();
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
                estacion = Estacion.Estaciones().OrderByDescending(x => x.id).First();
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
                if (estacion.id != 0)
                {
                    estacion = new Estacion();
                    Cargar(false, true);
                }
                else
                {
                    object p = new { fields = "id, codigo, nombre, activo", like = true };
                    object o = new { codigo = txtCodigo.Text, nombre = txtNombre.Text };
                    DataTable estaciones = Utilidades.Busqueda("estaciones", o, p);
                    if (estaciones.Rows.Count > 0)
                    {
                        if (estaciones.Rows.Count == 1)
                        {
                            estacion = Estacion.Obtener((int)estaciones.Rows[0]["id"]);
                            Cargar();
                        }
                        else
                        {
                            frmResultadosBusqueda f = new frmResultadosBusqueda(estaciones);
                            var result = f.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                estacion = Estacion.Obtener(f.id);
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
            estacion = new Estacion();
            Cargar(true);
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && estacion.id == 0)
                Buscar();
        }

        private void lblBasculas_Click(object sender, EventArgs e)
        {
            frmBasculas f = new frmBasculas();
            f.ShowDialog();
        }

        private void frmEstaciones_Load(object sender, EventArgs e)
        {

        }
    }
}