using NoriSDK;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Nori.API
{
    public class SocioAPI
    {
        HttpClient client = new HttpClient();

        private string path = Program.Nori.Configuracion.api_url + "socios";
        public async Task<List<Socio>> Obtener()
        {
            List<Socio> socios = new List<Socio>();

            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                socios = await response.Content.ReadAsAsync<List<Socio>>();
            }

            return socios;
        }
        public async Task<Socio> Obtener(int id)
        {
            Socio socio = new Socio();

            HttpResponseMessage response = await client.GetAsync(string.Format("{0}/{1}", path, id));
            if (response.IsSuccessStatusCode)
            {
                socio = await response.Content.ReadAsAsync<Socio>();
            }

            return socio;
        }

        public async Task<List<Socio.Direccion>> Direcciones(int id)
        {
            List<Socio.Direccion> direcciones = new List<Socio.Direccion>();

            HttpResponseMessage response = await client.GetAsync(string.Format("{0}/{1}/direcciones", path, id));
            if (response.IsSuccessStatusCode)
            {
                direcciones = await response.Content.ReadAsAsync<List<Socio.Direccion>>();
            }

            return direcciones;
        }

        public async Task<List<Socio.PersonaContacto>> PersonasContacto(int id)
        {
            List<Socio.PersonaContacto> personas_contacto = new List<Socio.PersonaContacto>();

            HttpResponseMessage response = await client.GetAsync(string.Format("{0}/{1}/personas-contacto", path, id));
            if (response.IsSuccessStatusCode)
            {
                personas_contacto = await response.Content.ReadAsAsync<List<Socio.PersonaContacto>>();
            }

            return personas_contacto;
        }

        public async Task<Socio> Agregar(Socio socio)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(path, socio);

            if (response.IsSuccessStatusCode)
            {
                socio = await response.Content.ReadAsAsync<Socio>();
            }

            return socio;
        }

        public async Task<Socio.Direccion> AgregarDireccion(Socio.Direccion direccion)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(string.Format("{0}/direccion", path), direccion);

            if (response.IsSuccessStatusCode)
            {
                direccion = await response.Content.ReadAsAsync<Socio.Direccion>();
            }

            return direccion;
        }

        public async Task<Socio.PersonaContacto> AgregarPersonaContacto(Socio.PersonaContacto persona_contacto)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(string.Format("{0}/persona-contacto", path), persona_contacto);

            if (response.IsSuccessStatusCode)
            {
                persona_contacto = await response.Content.ReadAsAsync<Socio.PersonaContacto>();
            }

            return persona_contacto;
        }

        public async Task<bool> Actualizar(Socio socio)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(string.Format("{0}/{1}", path, socio.id), socio);

            return (response.IsSuccessStatusCode) ? true : false;
        }

        public async Task<List<Socio>> Actualizados(DateTime fecha)
        {
            List<Socio> socios = new List<Socio>();

            string url = string.Format("{0}/actualizados?fecha={1}", path, fecha.ToString());

            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                socios = await response.Content.ReadAsAsync<List<Socio>>();
            }

            return socios;
        }
    }
}
