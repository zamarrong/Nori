using NoriSDK;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Nori
{
    public partial class frmSolicitarAutorizacion: DevExpress.XtraBars.Ribbon.RibbonForm
    {
        internal static Autorizacion autorizacion;
        internal static Autorizacion.ConceptoAutorizacion concepto_autorizacion;
        public frmSolicitarAutorizacion(Autorizacion _)
        {
            InitializeComponent();
			this.MetodoDinamico();

            autorizacion = _;

            concepto_autorizacion = Autorizacion.ConceptoAutorizacion.Obtener(autorizacion.codigo);

            lblAutorizacion.Text = concepto_autorizacion.nombre;
            lblReferencia.Text = autorizacion.referencia;
            lblComentario.Text = autorizacion.comentario;

            if (autorizacion.autorizado)
            {
                timer.Enabled = false;
                btnAceptar.BackColor = Color.ForestGreen;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!autorizacion.pendiente)
            {
                if (autorizacion.autorizado)
                    DialogResult = DialogResult.OK;
                else
                    DialogResult = DialogResult.Cancel;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            autorizacion.Actualizar();
            DialogResult = DialogResult.Cancel;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                autorizacion.Verificar();
                if (!autorizacion.pendiente)
                {
                    lblComentario.Text = autorizacion.comentario;
                    btnAceptar.BackColor = (autorizacion.autorizado) ? Color.ForestGreen : Color.Firebrick;
                    timer.Stop();
                }
                btnAceptar.Focus();
            } catch { }
        }

        private void lblAutorizar_Click(object sender, EventArgs e)
        {
            frmAutenticar f = new frmAutenticar();
            f.usuario = new Usuario();
            f.ShowDialog();
            if (Autorizacion.Autorizado(f.usuario, autorizacion.codigo))
            {
                if (f.DialogResult == DialogResult.OK && f.usuario.id != 0)
                {
                    autorizacion.autorizado = true;
                    autorizacion.usuario_autorizacion_id = f.usuario.id;
                    autorizacion.estacion_autorizacion_id = Program.Nori.Estacion.id;
                    autorizacion.Actualizar();
                }
            }
            else
            {
                MessageBox.Show("El usuario especificado no tiene privilegios para autorizar esta acción");
            }
        }
    }
}