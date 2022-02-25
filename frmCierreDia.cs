using NoriSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Nori
{
    public partial class frmCierreDia : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		public frmCierreDia()
		{
			InitializeComponent();
			this.MetodoDinamico();
		
			EventoControl.SuscribirEventos(this);

            deFechaInicial.DateTime = DateTime.Today;
            deFechaFinal.DateTime = DateTime.Today;
		}

        private bool CajasAbiertas()
        {
            try
            {
                bool caja_abierta = false;
                List<Usuario> usuarios = Usuario.Usuarios().ToList();
                foreach (Usuario usuario in usuarios)
                {
                    if (NoriSDK.PuntoVenta.EstadoCaja(usuario.id).Equals('A'))
                    {
                        caja_abierta = true;
                        MessageBox.Show(string.Format("La caja del usuario {0} esta abierta, realice el corte de caja para continuar.", usuario.usuario));
                    }
                }

                return caja_abierta;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return true;
            }
        }

        private void btnCierre_Click(object sender, EventArgs e)
        {
            try
            {
                if (CajasAbiertas())
                {
                    MessageBox.Show("No se puede realizar el cierre ya que existen cajas abiertas.");
                }
                else
                {
                    Informe informe = Informe.ObtenerPredeterminado("CD");
                    Dictionary<string, object> parametros = new Dictionary<string, object>();

                    parametros.Add("fecha_inicial", deFechaInicial.DateTime);
                    parametros.Add("fecha_final", deFechaFinal.DateTime);

                    Funciones.ImprimirInforme(informe.id, parametros);

                    MessageBox.Show("Se realizó el cierre correctamente.");
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}