using NoriSDK;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Nori.API
{
    class Transmitir
    {
        public async Task<bool> Socios()
        {
            try
            {
                SocioAPI socio_api = new SocioAPI();

                DataTable socios = Utilidades.EjecutarQuery("SELECT id FROM sincronizacion WHERE tabla = 'socios' ORDER BY id ASC");
                foreach (DataRow socios_row in socios.Rows)
                {
                    try
                    {
                        Sincronizacion sincronizacion = Sincronizacion.Obtener((int)socios_row["id"]);

                        Socio socio = Socio.Obtener(sincronizacion.registro);
                        Socio socio_agregado = await socio_api.Agregar(socio);

                        if (socio_agregado.id != 0)
                        {
                            List<Socio.Direccion> direcciones = socio.Direcciones();

                            foreach (Socio.Direccion direccion in direcciones)
                            {
                                await socio_api.AgregarDireccion(direccion);
                            }

                            List<Socio.PersonaContacto> personas_contacto = socio.PersonasContacto();

                            foreach (Socio.PersonaContacto persona_contacto in personas_contacto)
                            {
                                await socio_api.AgregarPersonaContacto(persona_contacto);
                            }

                            sincronizacion.Eliminar();
                        }
                    }
                    catch { continue; }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> Documentos()
        {
            try
            {
                DocumentoAPI documento_api = new DocumentoAPI();

                DataTable documentos = Utilidades.EjecutarQuery("SELECT id FROM sincronizacion WHERE tabla = 'documentos' ORDER BY id ASC");
                foreach (DataRow documentos_row in documentos.Rows)
                {
                    try
                    {
                        Sincronizacion sincronizacion = Sincronizacion.Obtener((int)documentos_row["id"]);

                        Documento documento = Documento.Obtener(sincronizacion.registro);
                        if (documento.clase.Equals("PE"))
                        {
                            Documento documento_agregado = await documento_api.Agregar(documento);

                            if (documento_agregado.id != 0)
                            {
                                documento.identificador_externo = documento_agregado.id;
                                documento.numero_documento_externo = documento_agregado.numero_documento;

                                documento.ActualizarIdentificadoresExternos();

                                if (sincronizacion.id != 0)
                                    sincronizacion.Eliminar();
                            }
                        }
                        else
                        {
                            if (sincronizacion.id != 0)
                                sincronizacion.Eliminar();
                        }
                    }
                    catch { continue; }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
