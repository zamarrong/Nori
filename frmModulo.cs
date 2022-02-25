using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Nori
{
    public partial class frmModulo : DevExpress.XtraEditors.XtraForm
    {
        public frmModulo()
        {
            InitializeComponent();
			this.MetodoDinamico();
        }
    }
}