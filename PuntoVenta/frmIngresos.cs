using NoriSDK;
using System;
using System.Windows.Forms;

namespace Nori.PuntoVenta
{
    public partial class frmIngresos : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        Flujo flujo = new Flujo();
        Autorizacion autorizacion = new Autorizacion();
        public frmIngresos(string codigo)
        {
            InitializeComponent();
			this.MetodoDinamico();

            Flujo.ConceptoFlujo concepto = Flujo.ConceptoFlujo.Obtener(codigo);

            Text = concepto.nombre;
            flujo.codigo = concepto.codigo;
            autorizacion.codigo = concepto.codigo;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(string.Format("¿Estas seguro(a) de realizar un ingreso por la cantidad de {0}?", txtCantidad.Text), Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string concepto = "Apertura";

                    if (autorizacion.codigo == "INDEP")
                        concepto = "Depósito";

                    autorizacion.referencia = string.Format("{0} de caja al usuario {1} en la estación {2} por la cantidad de {3}", concepto, Program.Nori.UsuarioAutenticado.usuario, Program.Nori.Estacion.nombre, txtCantidad.Text);
                    autorizacion.comentario = Microsoft.VisualBasic.Interaction.InputBox("Comentario ingreso (Opcional)", "");

                    autorizacion.Agregar();

                    if (!autorizacion.autorizado)
                    {
                        frmSolicitarAutorizacion fa = new frmSolicitarAutorizacion(autorizacion);
                        fa.ShowDialog();
                        autorizacion.autorizado = (fa.DialogResult == DialogResult.OK) ? true : false;
                    }

                    if (autorizacion.autorizado)
                    {
                        flujo.autorizacion_id = autorizacion.id;
                        flujo.importe = decimal.Parse(txtCantidad.EditValue.ToString());
                        flujo.comentario = txtComentario.Text;

                        if (flujo.Agregar())
                        {
                            Funciones.ImprimirInformePredeterminado("IE", flujo.id);
                            DialogResult = DialogResult.OK;
                        }
                        else
                            MessageBox.Show("Ocurrio un error, verifica la información y trata nuevamente.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}