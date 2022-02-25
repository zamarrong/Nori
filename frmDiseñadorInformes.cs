using System;
using System.Windows.Forms;

namespace Nori
{
    public partial class frmDiseñadorInformes : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmDiseñadorInformes()
        {
            InitializeComponent();
			this.MetodoDinamico();
            try
            {
                DevExpress.XtraReports.Configuration.Settings.Default.StorageOptions.RootDirectory = Program.Nori.Configuracion.directorio_informes;
            } catch { }
        }

        public void AbrirInforme(string informe)
        {
            try
            {
                reportDesigner1.OpenReport(@informe);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}