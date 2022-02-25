using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Nori.API
{
    public class DocumentoAPI
    {
        HttpClient client = new HttpClient();

        private string path = Program.Nori.Configuracion.api_url + "documentos";
        public async Task<List<NoriSDK.Documento>> Obtener()
        {
            List<NoriSDK.Documento> documentos = new List<NoriSDK.Documento>();

            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                documentos = await response.Content.ReadAsAsync<List<NoriSDK.Documento>>();
            }

            return documentos;
        }
        public async Task<NoriSDK.Documento> Obtener(int id)
        {
            NoriSDK.Documento documento = new NoriSDK.Documento();

            HttpResponseMessage response = await client.GetAsync(string.Format("{0}/{1}", path, id));
            if (response.IsSuccessStatusCode)
            {
                documento = await response.Content.ReadAsAsync<NoriSDK.Documento>();
            }

            return documento;
        }

        public async Task<NoriSDK.Documento> Agregar(NoriSDK.Documento documento)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(path, documento);

            if (response.IsSuccessStatusCode)
            {
                documento = await response.Content.ReadAsAsync<NoriSDK.Documento>();
            }

            return documento;
        }

        public async Task<bool> Actualizar(NoriSDK.Documento documento)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(string.Format("{0}/{1}", path, documento.id), documento);

            return (response.IsSuccessStatusCode) ? true : false;
        }
    }
}
