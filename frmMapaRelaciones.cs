using NoriSDK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Nori
{
	public partial class frmMapaRelaciones : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		int documento_id = 0;
		public frmMapaRelaciones(Documento documento)
		{
			InitializeComponent();
			this.MetodoDinamico();

			List<Documento.Relacion> relaciones_origen = Documento.Relacion.RelacionDocumentos().Where(x => x.documento_origen_id == documento.id).ToList();
			List<Documento.Relacion> relaciones_destino = Documento.Relacion.RelacionDocumentos().Where(x => x.documento_destino_id == documento.id).ToList();
			List<Pago.Partida> pagos = Pago.Partida.Partidas().Where(x => x.documento_id == documento.id).ToList();
			List<Documento.Referencia> referencias = Documento.Referencia.Referencias().Where(x => x.documento_id == documento.id).ToList();

			TreeNode n = new TreeNode();

			n.Text = string.Format("{0} {1} Total: {2} {3}", Documento.Clase.Clases().Where(x => x.clase == documento.clase).First().nombre, documento.numero_documento, documento.total.ToString("c2"), Documento.Estado.Estados().Where(x => x.estado == documento.estado).First().nombre);
			n.Tag = documento.id;
			documento_id = documento.id;

			tv.Nodes.Add(n);

			if (relaciones_origen.Count > 0)
			{
				//Origen
				foreach (Documento.Relacion relacion in relaciones_origen)
				{
					var documento_relacion = Documento.Documentos().Where(x => x.id == relacion.documento_destino_id).Select(x => new { x.id, x.numero_documento, x.clase, x.estado, x.cancelado, x.total }).First();

					TreeNode node = new TreeNode(string.Format("{0} {1} Total: {2} {3}", Documento.Clase.Clases().Where(x => x.clase == documento_relacion.clase).First().nombre, documento_relacion.numero_documento, documento_relacion.total.ToString("c2"), Documento.Estado.Estados().Where(x => x.estado == documento_relacion.estado).First().nombre));
					node.ForeColor = (documento_relacion.cancelado) ? Color.Firebrick : Color.DimGray;
					node.Tag = documento_relacion.id;

					tv.Nodes[0].Nodes.Add(node);
				}         
			}

			if (relaciones_destino.Count > 0)
			{
				//Destino
				foreach (Documento.Relacion relacion in relaciones_destino)
				{
					var documento_relacion = Documento.Documentos().Where(x => x.id == relacion.documento_origen_id).Select(x => new { x.id, x.numero_documento, x.clase, x.estado, x.cancelado, x.total }).First();

					TreeNode node = new TreeNode(string.Format("{0} {1} Total: {2} {3}", Documento.Clase.Clases().Where(x => x.clase == documento_relacion.clase).First().nombre, documento_relacion.numero_documento, documento_relacion.total.ToString("c2"), Documento.Estado.Estados().Where(x => x.estado == documento_relacion.estado).First().nombre));
					node.ForeColor = (documento_relacion.cancelado) ? Color.Firebrick : Color.DimGray;
					node.Tag = documento_relacion.id;

					tv.Nodes.Add(node);
				}
			}

			if (pagos.Count > 0)
			{
				foreach (Pago.Partida pago in pagos)
				{
					TreeNode node = new TreeNode(string.Format("Pago {0} Importe: {1}", pago.pago_id, pago.importe.ToString("c2")));
					node.ForeColor = Color.GreenYellow;
					node.Tag = pago.pago_id;

					tv.Nodes.Add(node);
				}
			}


			if (referencias.Count > 0)
			{
				foreach (Documento.Referencia referencia in referencias)
				{
					var documento_referencia = Documento.Documentos().Where(x => x.id == referencia.documento_referencia_id).Select(x => new { x.id, x.numero_documento, x.clase, x.estado, x.total }).First();

					TreeNode node = new TreeNode(string.Format("{0} {1} Total: {2} {3}", Documento.Clase.Clases().Where(x => x.clase == documento_referencia.clase).First().nombre, documento_referencia.numero_documento, documento_referencia.total.ToString("c2"), Documento.Estado.Estados().Where(x => x.estado == documento_referencia.estado).First().nombre));
					node.ForeColor = Color.DodgerBlue;
					node.Tag = documento_referencia.id;

					tv.Nodes.Add(node);
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

		private void tv_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Delete)
				{
					if ((int)tv.SelectedNode.Tag != documento_id)
					{
						if (tv.SelectedNode.ForeColor == Color.Firebrick || tv.SelectedNode.ForeColor == Color.DimGray)
						{
							Documento.Relacion relacion = Documento.Relacion.Obtener((int)tv.SelectedNode.Tag, documento_id);
							if (relacion.id != 0)
							{
								if (MessageBox.Show("¿Desea eliminar esta relación?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
								{
									if (relacion.Eliminar())
										tv.SelectedNode.Remove();
									else
										MessageBox.Show(NoriSDK.Nori.ObtenerUltimoError().Message);
								}
							}
						}
						else if (tv.SelectedNode.ForeColor == Color.DodgerBlue)
						{
							Documento.Referencia referencia = Documento.Referencia.Obtener(documento_id, (int)tv.SelectedNode.Tag);
							if (referencia.id != 0)
							{
								if (MessageBox.Show("¿Desea eliminar esta referencia?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
								{
									if (referencia.Eliminar())
										tv.SelectedNode.Remove();
									else
										MessageBox.Show(NoriSDK.Nori.ObtenerUltimoError().Message);
								}
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}