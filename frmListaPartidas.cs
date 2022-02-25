using NoriSDK;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Nori
{
	public partial class frmListaPartidas : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		List<Documento.Clase> clases = new List<Documento.Clase>();
		List<Vendedor> vendedores = new List<Vendedor>();
		public frmListaPartidas()
		{
			InitializeComponent();
			this.MetodoDinamico();

			deDesde.EditValue = DateTime.Now;
			deHasta.EditValue = DateTime.Now;

			CargarListas();
		}

		private void CargarListas()
		{
			try
			{
				clases = Documento.Clase.Clases();

				Vendedor vendedor = new Vendedor();
				vendedor.nombre = "Todos";
				vendedores.Add(vendedor);
				vendedores.AddRange(Vendedor.Vendedores().Where(x => x.activo == true).ToList());

				cbVendedores.Properties.DataSource = vendedores;
				cbVendedores.Properties.ValueMember = "id";
				cbVendedores.Properties.DisplayMember = "nombre";

				cbClases.Properties.DataSource = clases;
				cbClases.Properties.ValueMember = "clase";
				cbClases.Properties.DisplayMember = "nombre";

                var estados = Documento.Estado.Estados();
                estados.Add(new Documento.Estado { estado = '*', nombre = "Todos" });
                cbEstados.Properties.DataSource = estados;
				cbEstados.Properties.ValueMember = "estado";
				cbEstados.Properties.DisplayMember = "nombre";

				var socios = Socio.Socios().Where(x => x.activo == true).Select(x => new { x.id, x.codigo, x.nombre }).ToList();
				socios.Add(new { id = 0, codigo = "NA", nombre = "Todos" });
				cbSocios.Properties.DataSource = socios;
				cbSocios.Properties.ValueMember = "id";
				cbSocios.Properties.DisplayMember = "nombre";

				cbClases.EditValue = "PE";
				cbEstados.EditValue = 'A';
				cbVendedores.EditValue = 0;
				cbSocios.EditValue = 0;
			}
			catch { }
		}

		private void CargarDocumentos()
		{
			try
			{
				string query_vendedor = ((int)cbVendedores.EditValue == 0) ? string.Empty : string.Format("AND documentos.vendedor_id = {0}", ((int)cbVendedores.EditValue));
				string query_socio = string.Empty;
				try
				{
					query_socio = ((int)cbSocios.EditValue == 0) ? string.Empty : string.Format("AND (documentos.socio_id = {0} OR socios.socio_eventual_id = {0})", ((int)cbSocios.EditValue));
				}
				catch { }
                string query_estado = string.Empty;
                switch ((char)cbEstados.EditValue)
                {
                    case '*':
                        query_estado = string.Empty;
                        break;
                    default:
                        query_estado = string.Format("AND documentos.estado = '{0}'", cbEstados.EditValue);
                        break;
                }
				string query = string.Format("SELECT documentos.id ID, series.nombre Serie, numero_documento 'N° Documento', fecha_documento Fecha, cast(documentos.fecha_creacion as time) Hora, socios.codigo 'Codigo SN', socios.nombre Nombre, total Total, condiciones_pago.nombre CondicionPago, metodos_pago.codigo MetodoPago, vendedores.nombre Vendedor, referencia Referencia, impreso Impreso, documentos.foraneo Foraneo, documentos.fecha_actualizacion 'Fecha actualización' FROM documentos INNER JOIN socios ON documentos.socio_id = socios.id LEFT JOIN vendedores ON documentos.vendedor_id = vendedores.id LEFT JOIN condiciones_pago ON condiciones_pago.id = documentos.condicion_pago_id LEFT JOIN metodos_pago ON metodos_pago.id = documentos.metodo_pago_id  LEFT JOIN series ON series.id = documentos.serie_id WHERE documentos.clase = '{0}' AND fecha_documento BETWEEN '{1}' AND '{2}' {3} {4} {5}", cbClases.EditValue, ((DateTime)deDesde.EditValue).ToString("yyyyMMdd"), ((DateTime)deHasta.EditValue).ToString("yyyyMMdd"), query_estado, query_vendedor, query_socio);
				gcDocumentos.DataSource = Utilidades.EjecutarQuery(query);
			}
			catch { }
		}

		private void ImprimirSeleccionados()
		{
			try
			{
				if (MessageBox.Show("¿Estas seguro(a) que deseas imprimir los documentos seleccionados?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					List<DataRow> rows = new List<DataRow>();
					Informe informe = Informe.Informes().Where(x => x.tipo == (string)cbClases.EditValue && x.activo == true && x.predeterminado == true).First();

					for (int i = 0; i < gvDocumentos.SelectedRowsCount; i++)
					{
						if (gvDocumentos.GetSelectedRows()[i] >= 0)
							rows.Add(gvDocumentos.GetDataRow(gvDocumentos.GetSelectedRows()[i]));
					}

					for (int i = 0; i < rows.Count; i++)
					{
						DataRow row = rows[i] as DataRow;
						Funciones.ImprimirInforme(informe.id, (int)row["ID"], true);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void AbrirSeleccionados()
		{
			try
			{
				if (MessageBox.Show("¿Estas seguro(a) que deseas abrir los documentos seleccionados?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					List<DataRow> rows = new List<DataRow>();
					for (int i = 0; i < gvDocumentos.SelectedRowsCount; i++)
					{
						if (gvDocumentos.GetSelectedRows()[i] >= 0)
							rows.Add(gvDocumentos.GetDataRow(gvDocumentos.GetSelectedRows()[i]));
					}

					for (int i = 0; i < rows.Count; i++)
					{
						DataRow row = rows[i] as DataRow;
						frmDocumentos f = new frmDocumentos((string)cbClases.EditValue, (int)row["ID"]);
						f.ShowDialog();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void EntregarSeleccionados()
		{
			try
			{
				if (cbClases.EditValue.Equals("PE"))
				{
					List<DataRow> rows = new List<DataRow>();
					for (int i = 0; i < gvDocumentos.SelectedRowsCount; i++)
					{
						if (gvDocumentos.GetSelectedRows()[i] >= 0)
							rows.Add(gvDocumentos.GetDataRow(gvDocumentos.GetSelectedRows()[i]));
					}

					for (int i = 0; i < rows.Count; i++)
					{
						DataRow row = rows[i] as DataRow;
						frmDocumentos f = new frmDocumentos("EN");
						var documento = Documento.Obtener((int)row["ID"]);
						f.documento.CopiarDe(documento, "EN", true);

						if (f.documento.clase.Equals("EN"))
						{
							if (MessageBox.Show("¿Desea realizar una entrega de mercancías diferencial?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
							{
								f.documento.partidas.ForEach(x => { x.cantidad = 0; });
								if (Program.Nori.UsuarioAutenticado.almacen_id != 0)
								{
									if (MessageBox.Show("¿Cargar solo partidas del almacén predeterminado para este usuario?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
										f.documento.partidas.RemoveAll(x => x.almacen_id != Program.Nori.UsuarioAutenticado.almacen_id);
								}
							}
						}

						try
						{
							f.documento.partidas.ForEach(x => { x.CalcularTotal(); x.ObtenerStock(); });
						}
						catch { }

						f.Cargar(true);
						f.Show();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void FacturarSeleccionados()
		{
			try
			{
				if (cbClases.EditValue.Equals("EN") && !cbSocios.EditValue.Equals("0"))
				{
					if (MessageBox.Show("¿Estas seguro(a) que deseas facturar los documentos seleccionados?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
					{
						List<DataRow> rows = new List<DataRow>();
						List<int> ids = new List<int>();

						for (int i = 0; i < gvDocumentos.SelectedRowsCount; i++)
						{
							if (gvDocumentos.GetSelectedRows()[i] >= 0)
								rows.Add(gvDocumentos.GetDataRow(gvDocumentos.GetSelectedRows()[i]));
						}

						for (int i = 0; i < rows.Count; i++)
						{
							DataRow row = rows[i] as DataRow;
							ids.Add((int)row["ID"]);
						}

						Documento documento = new Documento();
						List<Documento.Partida> partidas = Documento.Partida.Partidas().Where(x => ids.Contains(x.documento_id) && x.cantidad_pendiente > 0).ToList();

						decimal importe_aplicado = Documento.Documentos().Where(x => ids.Contains(x.id)).Sum(x => x.importe_aplicado);
						var descuentos = Documento.Documentos().Where(x => ids.Contains(x.id) && x.porcentaje_descuento > 0).Select(x => new { x.id, x.porcentaje_descuento }).ToList();
						var flujo = Flujo.Flujos().Where(x => ids.Contains(x.documento_id)).ToList();

						foreach (var descuento in descuentos)
						{
							partidas.Where(x => x.documento_id == descuento.id).ToList().ForEach(x => { x.porcentaje_descuento = (x.porcentaje_descuento + descuento.porcentaje_descuento); x.CalcularTotal(); });
						}

						partidas.All(x => { x.cantidad = x.cantidad_pendiente; x.cantidad_pendiente = x.cantidad; x.CalcularTotal(); return true; });

						documento.clase = "FA";
						documento.socio_id = Documento.Documentos().Where(x => x.id == ids.First()).Select(x => x.socio_id).First();

						if (documento.socio_id == Program.Nori.UsuarioAutenticado.socio_id)
							documento.comentario = string.Format("Factura global del día: {0}", DateTime.Today.ToShortDateString());

						try
						{
							documento.vendedor_id = Documento.Documentos().Where(x => x.id == partidas.First().documento_id).Select(x => x.vendedor_id).First();
						} catch { }

						documento.partidas.Clear();
						documento.partidas = partidas;

						documento.importe_aplicado = importe_aplicado;
						documento.CalcularTotal();

						frmDocumentos f = new frmDocumentos("FA");
						f.documento.CopiarDe(documento, "FA", true);
						f.documento.descuento = f.documento.porcentaje_descuento = 0;
						//f.documento.AgregarFlujos(flujo);
						f.documento.CalcularTotal();
						f.Cargar(true);
						f.ShowDialog();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void cbClases_EditValueChanged(object sender, EventArgs e)
		{
			try
			{
				CargarDocumentos();
			}
			catch { }
		}

		private void frmListaPartidasAbiertas_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.Control && e.KeyCode == Keys.I)
				ImprimirSeleccionados();
			if (e.Control && e.KeyCode == Keys.R)
				CargarDocumentos();
			if (e.Control && e.KeyCode == Keys.E)
				EntregarSeleccionados();
			if (e.Control && e.KeyCode == Keys.D)
				AbrirSeleccionados();
			if (e.Control && e.KeyCode == Keys.F)
				FacturarSeleccionados();
		}

		private void toolStripMenuItem1_Click(object sender, EventArgs e)
		{
			try
			{
				string archivo = string.Format(@"{0}\{1}.xlsx", Program.Nori.Configuracion.directorio_documentos, "ListaPartidasAbiertas");
				gcDocumentos.ExportToXlsx(archivo);
				Funciones.AbrirArchivo(archivo);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void toolStripMenuItem2_Click(object sender, EventArgs e)
		{
			try
			{
				string archivo = string.Format(@"{0}\{1}.pdf", Program.Nori.Configuracion.directorio_documentos, "ListaPartidasAbiertas");
				gcDocumentos.ExportToPdf(archivo);
				Funciones.AbrirArchivo(archivo);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnCargar_Click(object sender, EventArgs e)
		{
			CargarDocumentos();
		}

		private void btnImprimir_Click(object sender, EventArgs e)
		{
			ImprimirSeleccionados();
		}

		private void btnAbrir_Click(object sender, EventArgs e)
		{
			AbrirSeleccionados();
		}

		private void btnEntregar_Click(object sender, EventArgs e)
		{
			EntregarSeleccionados();
		}

		private void btnFacturar_Click(object sender, EventArgs e)
		{
			FacturarSeleccionados();
		}
	}
}