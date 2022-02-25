using System;
using System.Windows.Forms;

namespace Nori
{
    public partial class frmBascula : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmBascula()
        {
            InitializeComponent();
			this.MetodoDinamico();

            txtPeso.Text = "0.00";

            if (Program.Nori.Estacion.bascula && Program.Nori.Estacion.bascula_id != 0 && Program.Nori.Estacion.Bascula != null)
                timerObtenerPeso.Enabled = true;
            else
                MessageBox.Show("No es posible inicializar la báscula o no esta configurada una.");
        }

        private void timerObtenerPeso_Tick(object sender, EventArgs e)
        {
            try
            {
                txtPeso.Text = Program.Nori.Estacion.Bascula.ObtenerPeso().ToString("n4");
                if (Program.Nori.Estacion.Bascula.datos.Length == 0)
                {
                    timerObtenerPeso.Enabled = false;
                    MessageBox.Show("Se alcanzó el tiempo máximo de ejecución. Revise la conexión a la báscula y trate nuevamente.");
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}