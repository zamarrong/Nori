using NoriSDK;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Nori
{
	public partial class frmMapaRelacionesPagos : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		public frmMapaRelacionesPagos(Pago pago)
		{
			InitializeComponent();
			this.MetodoDinamico();

			List<Pago.Partida> partidas = pago.ObtenerPartidas();
			TreeNode n = new TreeNode();

			n.Text = string.Format("{0} {1} Total: {2}", Documento.Clase.Clases().Where(x => x.clase == "PR").First().nombre, pago.numero_documento, pago.total.ToString("c2"));
			n.Tag = pago.id;
			n.ForeColor = Color.GreenYellow;

			tv.Nodes.Add(n);

			if (partidas.Count > 0)
			{
				foreach (Pago.Partida partida in partidas)
				{
					var documento_relacion = Documento.Documentos().Where(x => x.id == partida.documento_id).Select(x => new { x.id, x.numero_documento, x.clase, x.estado, x.cancelado, x.total }).First();

					TreeNode node = new TreeNode(string.Format("{0} {1} Total: {2} {3}", Documento.Clase.Clases().Where(x => x.clase == documento_relacion.clase).First().nombre, documento_relacion.numero_documento, documento_relacion.total.ToString("c2"), Documento.Estado.Estados().Where(x => x.estado == documento_relacion.estado).First().nombre));
					node.ForeColor = (documento_relacion.cancelado) ? Color.Firebrick : Color.DimGray;
					node.Tag = documento_relacion.id;

					tv.Nodes[0].Nodes.Add(node);
				}         
			}

			tv.SelectedNode = null;
			tv.ExpandAll();
		}

		private void tv_NodeMouseDoubleClick(object sender, System.Windows.Forms.TreeNodeMouseClickEventArgs e)
		{
			try
			{
				if (e.Node.ForeColor == Color.GreenYellow)
				{
					frmPagos f = new frmPagos((int)e.Node.Tag);
					f.Show();
				}
				else
				{
					var documento = Documento.Documentos().Where(x => x.id == (int)e.Node.Tag).Select(x => new { x.id, x.clase }).First();
					frmDocumentos f = new frmDocumentos(documento.clase, documento.id);
					f.Show();
				}
			} catch { }
		}
	}
}