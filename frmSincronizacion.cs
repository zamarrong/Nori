using NoriSDK;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Nori
{
	public partial class frmSincronizacion : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		internal static NoriSAPB1SDK.NoriSAP NoriSAP;
		internal static List<Sucursal> sucursales;
		string servidor_local = "";
		bool solo_bajada = false;
		bool solo_subida = false;
		public frmSincronizacion()
		{
			InitializeComponent();
			this.MetodoDinamico();

			sucursales = Sucursal.Sucursales().Where(x => x.activo == true).ToList();
			servidor_local = Program.Nori.Conexion.DataSource;

			if (sucursales.Count == 0)
				MessageBox.Show("No hay sucursales activas.");
		}

		private async void InicializarSAP()
		{
			try
			{
				if (Program.Nori.UsuarioAutenticado.rol != 'A')
				{
					solo_bajada = true;
				}
				else
				{
					if (MessageBox.Show("¿Desea iniciar la sincronización en modo de solo bajada?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
						solo_bajada = true;

					if (!solo_bajada)
						if (MessageBox.Show("¿Desea iniciar la sincronización en modo de solo subida?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
							solo_subida = true;
				}

				NoriSAP = new NoriSAPB1SDK.NoriSAP(Configuracion.SAP.Obtener(), solo_bajada);

				bool conexion_sap = false;
				if (!solo_bajada)
					conexion_sap = await NoriSAP.Conectar();

				if (!conexion_sap && !solo_bajada)
					MessageBox.Show(NoriSAPB1SDK.NoriSAP.ObtenerUltimoError().Message);

				if (solo_bajada || conexion_sap)
				{
					NoriSAPB1SDK.NoriSAP.ReportProgress += new EventHandler<NoriSAPB1SDK.NoriSAP.ProgressArgs>(bw_ReportProgress);
					bw.RunWorkerAsync();
				}
				else
				{
					MessageBox.Show("Imposible inicializar la sincronización, resvise su conexión y/o la configuración de las sucursales");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ocurrió un problema al iniciar la sincronización. " + ex.Message);
			}
		}

		protected void bw_ReportProgress(object sender, NoriSAPB1SDK.NoriSAP.ProgressArgs e)
		{
			try
			{
				bw.ReportProgress(1, e.Message);
			} catch { }
		}
		private void bw_DoWork(object sender, DoWorkEventArgs e)
		{
			try
			{
				foreach (Sucursal sucursal in sucursales)
				{
					try
					{
						Program.Nori.Conexion.DataSource = @sucursal.servidor;
						Program.Nori.Conexion.InitialCatalog = sucursal.bd;
						if (sucursal.contraseña.IsNullOrEmpty())
							Program.Nori.Conexion.IntegratedSecurity = true;
						Program.Nori.Conexion.UserID = sucursal.usuario;
						Program.Nori.Conexion.Password = sucursal.contraseña;
						
						Program.Nori.Conexion.ConnectTimeout = 10;

						if (Funciones.ServidorDisponible(sucursal.servidor))
						{
							if (Program.Nori.Conectar())
							{
								string mensaje = (solo_bajada) ? " - BAJADA - " : "";
								mensaje = (solo_subida) ? " - SUBIDA - " : mensaje;

								SafeInvoke(this, () => { Text = string.Format("Sincronización SAP Business One ({0}){1}", sucursal.nombre, mensaje); });

								if (solo_subida)
									sucursal.solo_subida = true;
								else if (solo_bajada && sucursal.solo_subida)
									continue;

								lbLogs.Items.Add(NoriSAPB1SDK.NoriSAP.Sincronizar(sucursal));

								//if (1 > 2)
								//{
								//	try
								//	{
								//		if (servidor_local.Equals(sucursal.servidor))
								//		{
								//			List<int> documentos_electronicos = Sincronizacion.Sincronizaciones().Where(x => x.tabla == "documentos" && x.error == "El documento aún no ha sido timbrado").Select(x => x.registro).Distinct().ToList();
								//			if (documentos_electronicos.Count > 0)
								//			{
								//				lbLogs.Items.Add(string.Format("Generando CFDI de documentos electrónicos pendientes ({0}).", documentos_electronicos.Count));
								//				foreach (int documento_electronico in documentos_electronicos)
								//				{
								//					Documento documento = Documento.Obtener(documento_electronico);
								//					lbLogs.Items.Add(string.Format("Generando CFDI del documento {0} de clase {1}.", documento.id, documento.clase));
								//					if (documento.id != 0 && documento.generar_documento_electronico)
								//					{
								//						if (Funciones.TimbrarDocumento(documento))
								//							lbLogs.Items.Add(string.Format("Se timbro el documento {0} de clase {1} correctamente.", documento.id, documento.clase));
								//						else
								//							lbLogs.Items.Add(string.Format("Ocurrió un error al timbrar el documento {0} de clase {1}.", documento.id, documento.clase));
								//					}
								//				}
								//			}
								//		}
								//	}
								//	catch { }
								//}
							}
							else
							{
								lbLogs.Items.Add(string.Format("No se pudo conectar al servidor {0}", sucursal.servidor));
							}
						}
						else
						{
							lbLogs.Items.Add(string.Format("No se pudo conectar al servidor {0}", sucursal.servidor));
						}   
					} catch { continue; }
				}
			}
			catch (Exception ex)
			{
				lbLogs.Items.Add(ex.Message);
				bw.RunWorkerAsync();
			}
		}

		public static void SafeInvoke(Control control, Action action)
		{
			try
			{
				if (control.InvokeRequired)
					control.Invoke(new MethodInvoker(() => { action(); }));
				else
					action();
			} catch { }
		}

		private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			try
			{
				Application.DoEvents();
				lbLogs.Items.Insert(0, e.UserState.ToString());
				Application.DoEvents();
			} catch { }
		}

		private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			try
			{
				if (!bw.IsBusy)
				{
					if (Program.Nori.UsuarioAutenticado.VendedorForaneo())
					{
						timer.Stop();
						timer.Enabled = false;
						Close();
					}
					else
					{
						lbLogs.Items.Clear();
						bw.RunWorkerAsync();
					}
				}
			} catch { }
		}

		private void timer_Tick(object sender, EventArgs e)
		{
			try
			{
				gcSincronizacion.DataSource = Utilidades.EjecutarQuery("SELECT ID, Tabla, Registro, (CASE WHEN tabla = 'documentos' THEN (SELECT clase FROM documentos WHERE id = registro) WHEN tabla = 'socios' THEN (SELECT codigo FROM socios WHERE id = registro) ELSE '' END) Info, Error, Fecha FROM sincronizacion");
				gcSincronizacion.RefreshDataSource();
			} catch { }
		}

		private void frmSincronizacion_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				if (bw.IsBusy)
					bw.CancelAsync();

				NoriSAP = null;
				bw.Dispose();
				Dispose();
				GC.Collect();

				if (!Program.Nori.UsuarioAutenticado.VendedorForaneo())
				{
					Program.Nori.UsuarioAutenticado.Desconectar();
					Funciones.MatarProcesos();
				}
			}
			catch { }
		}

		private void frmSincronizacion_Load(object sender, EventArgs e)
		{
			try
			{
				if (Program.Nori.Configuracion.sap)
					if (MessageBox.Show("Desea iniciar la sincronización con SAP B1", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
						InicializarSAP();

				timer.Enabled = true;
				timer.Start();
			} catch { }
		}

		private void bbiRestablecerErrores_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				Utilidades.EjecutarQuery("UPDATE sincronizacion SET error = ''");
			} catch { }
		}

		private void bbiAgregarBajada_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				string tabla = Microsoft.VisualBasic.Interaction.InputBox("Ingresa la tabla del registro que deseas descargar.", "Agregar bajada", "OINV");
				string registro = Microsoft.VisualBasic.Interaction.InputBox("Ingresa el registro que deseas descargar.", "Agregar bajada", "");

				if (tabla.Length > 0 && registro.Length > 0)
				{
					if (MessageBox.Show(string.Format("¿Esta seguro de agregar el registro {0} de la tabla {1}?", registro, tabla), Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
					{
						Sincronizacion.Manual sincronizacion = new Sincronizacion.Manual();

						sincronizacion.tabla = tabla;
						sincronizacion.registro = registro;

						if (sincronizacion.Agregar())
							MessageBox.Show("Se agregó el registro correctamente.");
						else
							MessageBox.Show("No fue posible agregar el registro.");
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void bbiEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				string registro = Microsoft.VisualBasic.Interaction.InputBox("Ingresa ID del registro que deseas eliminar de la sincronización", "Eliminar registro", "");
				if (registro.Length > 0)
				{
					if (MessageBox.Show(string.Format("¿Esta seguro de eliminar el registro {0}?", registro), Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
					{
						Sincronizacion sincronizacion = Sincronizacion.Obtener(int.Parse(registro));
						if (sincronizacion.id != 0)
						{
							if (sincronizacion.Eliminar())
								MessageBox.Show("Registro eliminado correctamente.");
							else
								MessageBox.Show("No fue posible eliminar el registro.");
						}
						else
						{
							MessageBox.Show("No se encontraron registros coincidentes.");
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void bbiAregarSubida_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				string tabla = Microsoft.VisualBasic.Interaction.InputBox("Ingresa la tabla del registro que deseas cargar.", "Agregar subida", "documentos");
				string registro = Microsoft.VisualBasic.Interaction.InputBox("Ingresa el ID del registro que deseas cargar.", "Agregar subida", "");

				if (tabla.Length > 0 && registro.Length > 0)
				{
					if (MessageBox.Show(string.Format("¿Esta seguro de agregar el registro {0} de la tabla {1}?", registro, tabla), Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
					{
						Sincronizacion sincronizacion = new Sincronizacion();

						sincronizacion.tabla = tabla;
						sincronizacion.registro = int.Parse(registro);

						if (sincronizacion.Agregar())
							MessageBox.Show("Se agregó el registro correctamente.");
						else
							MessageBox.Show("No fue posible agregar el registro.");
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