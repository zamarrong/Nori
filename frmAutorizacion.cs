using NoriSDK;
using System.Windows.Forms;

namespace Nori
{
    public partial class frmAutorizacion: DevExpress.XtraBars.Ribbon.RibbonForm
    {
        internal static Autorizacion autorizacion;
        internal static Autorizacion.ConceptoAutorizacion concepto_autorizacion;
        public frmAutorizacion(Autorizacion _)
        {
            InitializeComponent();
			this.MetodoDinamico();

            btnAutorizar.Focus();

            autorizacion = _;
            concepto_autorizacion = Autorizacion.ConceptoAutorizacion.Obtener(autorizacion.codigo);
            autorizacion.usuario_autorizacion_id = Program.Nori.UsuarioAutenticado.id;
            autorizacion.estacion_autorizacion_id = Program.Nori.Estacion.id;

            Usuario usuario = Usuario.Obtener(autorizacion.usuario_creacion_id);
            Estacion estacion = Estacion.Obtener(autorizacion.estacion_id);

            Text += string.Format(" - {0} | {1}", usuario.nombre, estacion.nombre);

            lblAutorizacion.Text = concepto_autorizacion.nombre;
            lblReferencia.Text = autorizacion.referencia;
            lblComentario.Text = autorizacion.comentario;
        }

        private void btnAutorizar_Click(object sender, System.EventArgs e)
        {
            autorizacion.comentario += " | " + txtComentario.Text;
            if (autorizacion.comentario.Length > 254)
            {
                MessageBox.Show("El comentario no puede tener una longitud mayor a 254 caracteres.");
            }
            else
            {
                autorizacion.autorizado = Funciones.Autenticar();
                autorizacion.usuario_autorizacion_id = Program.Nori.UsuarioAutenticado.id;
                autorizacion.estacion_autorizacion_id = Program.Nori.Estacion.id;
                autorizacion.Actualizar();
                Close();
            }
        }

        private void btnDenegar_Click(object sender, System.EventArgs e)
        {
            autorizacion.comentario += " " + txtComentario.Text;
            if (autorizacion.comentario.Length > 254)
            {
                MessageBox.Show("El comentario no puede tener una longitud mayor a 254 caracteres.");
            }
            else
            {
                autorizacion.autorizado = false;
                autorizacion.Actualizar();
                Close();
            }
        }

        private void timer_Tick(object sender, System.EventArgs e)
        {
            try
            {
                autorizacion.Verificar();
                if (!autorizacion.pendiente)
                {
                    Close();
                }
            }
            catch { }
        }
    }
}