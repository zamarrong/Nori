using NoriSDK;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Nori
{
    public partial class frmGruposSocios : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        GrupoSocio grupo_socio = new GrupoSocio();

        public frmGruposSocios(int id = 0)
        {
            InitializeComponent();
			this.MetodoDinamico();
            if (id != 0)
            {
                grupo_socio = GrupoSocio.Obtener(id);
                Cargar();
            }
            else
            {
                Cargar(false, true);
            }

            cbTipo.Properties.DataSource = GrupoSocio.Tipo.Tipos();
            cbTipo.Properties.ValueMember = "tipo";
            cbTipo.Properties.DisplayMember = "nombre";

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
            lblID.Text = grupo_socio.id.ToString();

            cbTipo.EditValue = grupo_socio.tipo;
            txtCodigo.Text = grupo_socio.codigo.ToString();
            txtNombre.Text = grupo_socio.nombre;

            cbActivo.Checked = grupo_socio.activo;

            lblFechaActualizacion.Text = grupo_socio.fecha_actualizacion.ToShortDateString();

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
            grupo_socio.tipo = (char)cbTipo.EditValue;
            grupo_socio.codigo = short.Parse(txtCodigo.Text);
            grupo_socio.nombre = txtNombre.Text;
            grupo_socio.activo = cbActivo.Checked;
        }

        private bool Guardar()
        {
            try
            {
                if (MessageBox.Show("¿Desea guardar los cambios?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Llenar();
                    if (grupo_socio.id != 0)
                    {
                        return grupo_socio.Actualizar();
                    }
                    else
                    {
                        return grupo_socio.Agregar();
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
                grupo_socio = new GrupoSocio();
                Cargar();
            }
        }

        private void bbiPrimero_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                grupo_socio = GrupoSocio.GruposSocios().OrderBy(x => x.id).First();
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
                grupo_socio = GrupoSocio.GruposSocios().Where(x => x.id < grupo_socio.id).OrderByDescending(x => x.id).First();
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
                grupo_socio = GrupoSocio.GruposSocios().Where(x => x.id > grupo_socio.id).First();
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
                grupo_socio = GrupoSocio.GruposSocios().OrderByDescending(x => x.id).First();
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

        private void bbiNuevo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grupo_socio = new GrupoSocio();
            Cargar(true);
        }

        private void Buscar()
        {
            try
            {
                if (grupo_socio.id != 0)
                {
                    grupo_socio = new GrupoSocio();
                    Cargar(false, true);
                }
                else
                {
                    object p = new { fields = "id, codigo, nombre, activo", like = true };
                    object o = new { codigo = txtCodigo.Text, nombre = txtNombre.Text };
                    DataTable grupo_socios = Utilidades.Busqueda("grupo_socios", o, p);
                    if (grupo_socios.Rows.Count > 0)
                    {
                        if (grupo_socios.Rows.Count == 1)
                        {
                            grupo_socio = GrupoSocio.Obtener((int)grupo_socios.Rows[0]["id"]);
                            Cargar();
                        }
                        else
                        {
                            frmResultadosBusqueda f = new frmResultadosBusqueda(grupo_socios);
                            var result = f.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                grupo_socio = GrupoSocio.Obtener(f.id);
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

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && grupo_socio.id == 0)
                Buscar();
        }
    }
}