namespace Nori
{
    public partial class frmEscritorio : DevExpress.XtraEditors.XtraForm
    {
        public frmEscritorio(string escritorio)
        {
            InitializeComponent();
			this.MetodoDinamico();
            dashboardViewer1.LoadDashboard(escritorio);
        }
    }
}