using DevExpress.XtraSplashScreen;
using NoriSDK;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nori.API
{
    class Recibir
    {
        public async Task<bool> Articulos()
        {
            try
            {
                ArticuloAPI api = new ArticuloAPI();
                DateTime fecha_inicio_sincronizacion = DateTime.Now;
                FechaSincronizacion fecha_sincronizacion = FechaSincronizacion.Obtener("articulos");
                fecha_sincronizacion.fecha = fecha_sincronizacion.fecha.AddMinutes(-3);
                List<ArticuloAPI> articulos = await api.ActualizadosAPI(fecha_sincronizacion.fecha);

                int index_articulos = 0;
                foreach (ArticuloAPI articulo_api in articulos)
                {
                    try
                    {
                        SplashScreenManager.Default.SetWaitFormDescription(string.Format("Recibiendo artículo {0} de {1}", index_articulos, articulos.Count));

                        Articulo articulo_local = Articulo.Obtener(articulo_api.articulo.sku);
                        int articulo_id = articulo_local.id;
                        articulo_api.articulo.CopyProperties(articulo_local);
                        articulo_local.id = articulo_id;
                        bool a = (articulo_id == 0) ? articulo_local.Agregar() : articulo_local.Actualizar();

                        try
                        {
                            //Precios
                            List<Articulo.Precio> precios = articulo_api.precios;

                            foreach (Articulo.Precio precio in precios)
                            {
                                Articulo.Precio precio_local = Articulo.Precio.Obtener(articulo_local.id, precio.lista_precio_id);
                                int precio_id = precio_local.id;
                                precio.CopyProperties(precio_local);
                                precio_local.id = precio_id;
                                precio_local.articulo_id = articulo_local.id;
                                bool p = (precio_id == 0) ? precio_local.Agregar() : precio_local.Actualizar();
                            }
                        }
                        catch { continue; }

                        try
                        {
                            //Inventario
                            List<Articulo.Inventario> inventarios = articulo_api.inventario;

                            foreach (Articulo.Inventario inventario in inventarios)
                            {
                                Articulo.Inventario inventario_local = Articulo.Inventario.Obtener(articulo_local.id, inventario.almacen_id);
                                int inventario_id = inventario_local.id;
                                inventario.CopyProperties(inventario_local);
                                inventario_local.id = inventario_id;
                                inventario_local.articulo_id = articulo_local.id;
                                bool i = (inventario_id == 0) ? inventario_local.Agregar() : inventario_local.Actualizar();
                            }
                        }
                        catch { continue; }

                        //try
                        //{
                        //    //Códigos de barras
                        //    List<Articulo.CodigoBarras> codigos_barras = await articulo_api.CodigosBarras(articulo.id);

                        //    foreach (Articulo.CodigoBarras codigo_barras in codigos_barras)
                        //    {
                        //        Articulo.CodigoBarras codigo_barras_local = Articulo.CodigoBarras.Obtener(articulo_local.id);
                        //        int codigo_barras_id = codigo_barras_local.id;
                        //        codigo_barras.CopyProperties(codigo_barras_local);
                        //        codigo_barras_local.articulo_id = articulo_local.id;
                        //        bool c = (codigo_barras_id == 0) ? codigo_barras_local.Agregar() : codigo_barras_local.Actualizar();
                        //    }
                        //} catch { continue; }
                    }
                    catch
                    {
                        continue;
                    }
                    index_articulos++;
                }

                //await Precios(fecha_sincronizacion);
                //await Inventario(fecha_sincronizacion);

                fecha_sincronizacion.Actualizar(fecha_inicio_sincronizacion);

                return true;
            }
            catch
            {
                return false;
            }
        }

        private async Task<bool> Precios(FechaSincronizacion fecha_sincronizacion)
        {
            try
            {
                ArticuloAPI articulo_api = new ArticuloAPI();

                fecha_sincronizacion.fecha = fecha_sincronizacion.fecha.AddMinutes(-3);
                List<Articulo.Precio> precios = await articulo_api.PreciosActualizados(fecha_sincronizacion.fecha);

                foreach (Articulo.Precio precio in precios)
                {
                    try
                    {
                        Articulo.Precio precio_local = Articulo.Precio.Obtener(precio.articulo_id, precio.lista_precio_id);
                        precio.CopyProperties(precio_local);
                        bool i = (precio_local.id == 0) ? precio_local.Agregar() : precio_local.Actualizar();
                    }
                    catch
                    {
                        continue;
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private async Task<bool> Inventario(FechaSincronizacion fecha_sincronizacion)
        {
            try
            {
                ArticuloAPI articulo_api = new ArticuloAPI();

                fecha_sincronizacion.fecha = fecha_sincronizacion.fecha.AddMinutes(-3);
                List<Articulo.Inventario> inventarios = await articulo_api.InventariosActualizados(fecha_sincronizacion.fecha);

                foreach (Articulo.Inventario inventario in inventarios)
                {
                    try
                    {
                        Articulo.Inventario inventario_local = Articulo.Inventario.Obtener(inventario.articulo_id, inventario.almacen_id);
                        inventario.CopyProperties(inventario_local);
                        bool i = (inventario_local.id == 0) ? inventario_local.Agregar() : inventario_local.Actualizar();
                    }
                    catch
                    {
                        continue;
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private async Task<bool> CodigosBarras(FechaSincronizacion fecha_sincronizacion)
        {
            try
            {
                ArticuloAPI articulo_api = new ArticuloAPI();

                fecha_sincronizacion.fecha = fecha_sincronizacion.fecha.AddMinutes(-3);
                List<Articulo.CodigoBarras> codigos_barras = await articulo_api.CodigosBarrasActualizados(fecha_sincronizacion.fecha);

                foreach (Articulo.CodigoBarras codigo_barras in codigos_barras)
                {
                    try
                    {
                        Articulo.CodigoBarras codigo_barras_local = Articulo.CodigoBarras.Obtener(codigo_barras.codigo);
                        codigo_barras.CopyProperties(codigo_barras_local);
                        bool c = (codigo_barras_local.id == 0) ? codigo_barras_local.Agregar() : codigo_barras_local.Actualizar();
                    } catch { continue; }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Descuentos()
        {
            try
            {
                ArticuloAPI articulo_api = new ArticuloAPI();
                DateTime fecha_inicio_sincronizacion = DateTime.Now;
                FechaSincronizacion fecha_sincronizacion = FechaSincronizacion.Obtener("descuentos");
                fecha_sincronizacion.fecha = fecha_sincronizacion.fecha.AddMinutes(-3);
                List<Descuento> descuentos = await articulo_api.DescuentosActualizados(fecha_sincronizacion.fecha);

                foreach (Descuento descuento in descuentos)
                {
                    try
                    {
                        Descuento descuento_local = Descuento.Obtener(descuento.articulo_id, descuento.socio_id, descuento.lista_precio_id);
                        int descuento_id = descuento_local.id;
                        descuento.CopyProperties(descuento_local);
                        bool p = (descuento_id == 0) ? descuento_local.Agregar() : descuento_local.Actualizar();
                    } catch { continue; }
                }

                List<Descuento.Periodo> descuentos_periodo = await articulo_api.DescuentosPeriodoActualizados(fecha_sincronizacion.fecha);

                foreach (Descuento.Periodo descuento in descuentos_periodo)
                {
                    try
                    {
                        Descuento.Periodo descuento_local = Descuento.Periodo.Obtener(descuento.articulo_id, descuento.socio_id, descuento.lista_precio_id);
                        int descuento_id = descuento_local.id;
                        descuento.CopyProperties(descuento_local);
                        bool p = (descuento_id == 0) ? descuento_local.Agregar() : descuento_local.Actualizar();
                    } catch { continue; }
                }

                List<Descuento.Cantidad> descuentos_cantidad = await articulo_api.DescuentosCantidadActualizados(fecha_sincronizacion.fecha);

                foreach (Descuento.Cantidad descuento in descuentos_cantidad)
                {
                    try
                    {
                        Descuento.Cantidad descuento_local = Descuento.Cantidad.Obtener(descuento.cantidad, descuento.articulo_id, descuento.socio_id);
                        int descuento_id = descuento_local.id;
                        descuento.CopyProperties(descuento_local);
                        bool p = (descuento_id == 0) ? descuento_local.Agregar() : descuento_local.Actualizar();
                    } catch { continue; }
                }

                fecha_sincronizacion.Actualizar(fecha_inicio_sincronizacion);

                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> Socios()
        {
            try
            {
                SocioAPI socio_api = new SocioAPI();
                DateTime fecha_inicio_sincronizacion = DateTime.Now;
                FechaSincronizacion fecha_sincronizacion = FechaSincronizacion.Obtener("socios");
                fecha_sincronizacion.fecha = fecha_sincronizacion.fecha.AddMinutes(-3);

                List<Socio> socios = await socio_api.Actualizados(fecha_sincronizacion.fecha);

                foreach (Socio socio in socios)
                {
                    try
                    {
                        Socio socio_local = Socio.Obtener(socio.codigo);
                        int socio_id = socio_local.id;
                        socio.CopyProperties(socio_local);
                        bool s = (socio_id == 0) ? socio_local.Agregar(false) : socio_local.Actualizar(false);

                        //Direcciones
                        List<Socio.Direccion> direcciones = await socio_api.Direcciones(socio.id);

                        foreach (Socio.Direccion direccion in direcciones)
                        {
                            Socio.Direccion direccion_local = Socio.Direccion.Obtener(socio_local.id, direccion.nombre);
                            int direccion_id = direccion_local.id;
                            direccion.CopyProperties(direccion_local);
                            direccion_local.socio_id = socio_local.id;
                            bool d = (direccion_local.id == 0) ? direccion_local.Agregar() : direccion_local.Actualizar();
                        }

                        //Personas de contacto
                        List<Socio.PersonaContacto> personas_contacto = await socio_api.PersonasContacto(socio.id);

                        foreach (Socio.PersonaContacto persona_contacto in personas_contacto)
                        {
                            Socio.PersonaContacto persona_contacto_local = Socio.PersonaContacto.Obtener(socio_local.id, persona_contacto.codigo);
                            int persona_contacto_id = persona_contacto_local.id;
                            persona_contacto.CopyProperties(persona_contacto_local);
                            persona_contacto_local.socio_id = socio_local.id;
                            bool p = (persona_contacto_id == 0) ? persona_contacto_local.Agregar() : persona_contacto_local.Actualizar();
                        }
                    } catch { continue; }
                }

                fecha_sincronizacion.Actualizar(fecha_inicio_sincronizacion);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
