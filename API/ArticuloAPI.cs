using NoriSDK;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Nori.API
{
    public class ArticuloAPI
    {
        public Articulo articulo { get; set; }
        public List<Articulo.Precio> precios { get; set; }
        public List<Articulo.Inventario> inventario { get; set; }

        public ArticuloAPI()
        {
            precios = new List<Articulo.Precio>();
            inventario = new List<Articulo.Inventario>();
        }

        HttpClient client = new HttpClient();

        private string path = Program.Nori.Configuracion.api_url + "articulos";
        public async Task<List<Articulo>> Obtener()
        {
            List<Articulo> articulos = new List<Articulo>();

            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                articulos = await response.Content.ReadAsAsync<List<Articulo>>();
            }

            return articulos;
        }
        public async Task<Articulo> Obtener(int id)
        {
            Articulo articulo = new Articulo();

            HttpResponseMessage response = await client.GetAsync(string.Format("{0}/{1}", path, id));
            if (response.IsSuccessStatusCode)
            {
                articulo = await response.Content.ReadAsAsync<Articulo>();
            }

            return articulo;
        }

        public async Task<List<Articulo.Precio>> Precios(int id)
        {
            List<Articulo.Precio> precios = new List<Articulo.Precio>();

            HttpResponseMessage response = await client.GetAsync(string.Format("{0}/{1}/precios", path, id));
            if (response.IsSuccessStatusCode)
            {
                precios = await response.Content.ReadAsAsync<List<Articulo.Precio>>();
            }

            return precios;
        }

        public async Task<List<Articulo.Inventario>> Inventario(int id)
        {
            List<Articulo.Inventario> inventarios = new List<Articulo.Inventario>();

            HttpResponseMessage response = await client.GetAsync(string.Format("{0}/{1}/inventario", path, id));
            if (response.IsSuccessStatusCode)
            {
                inventarios = await response.Content.ReadAsAsync<List<Articulo.Inventario>>();
            }

            return inventarios;
        }

        public async Task<List<Articulo.CodigoBarras>> CodigosBarras(int id)
        {
            List<Articulo.CodigoBarras> codigos_barras = new List<Articulo.CodigoBarras>();

            HttpResponseMessage response = await client.GetAsync(string.Format("{0}/{1}/codigos-barras", path, id));
            if (response.IsSuccessStatusCode)
            {
                codigos_barras = await response.Content.ReadAsAsync<List<Articulo.CodigoBarras>>();
            }

            return codigos_barras;
        }

        public async Task<Articulo> Agregar(Articulo articulo)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(path, articulo);

            if (response.IsSuccessStatusCode)
            {
                articulo = await response.Content.ReadAsAsync<Articulo>();
            }

            return articulo;
        }

        public async Task<bool> Actualizar(Articulo articulo)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(string.Format("{0}/{1}", path, articulo.id), articulo);

            return (response.IsSuccessStatusCode) ? true : false;
        }

        public async Task<List<ArticuloAPI>> ActualizadosAPI(DateTime fecha)
        {
            List<ArticuloAPI> articulos = new List<ArticuloAPI>();

            string url = string.Format("{0}/actualizados-api?fecha={1}", path, fecha.ToString());
            client.Timeout = TimeSpan.FromMilliseconds(-1);

            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                articulos = await response.Content.ReadAsAsync<List<ArticuloAPI>>();
            }

            return articulos;
        }

        public async Task<List<Articulo.Precio>> PreciosActualizados(DateTime fecha)
        {
            List<Articulo.Precio> precios = new List<Articulo.Precio>();

            string url = string.Format("{0}/precios/actualizados?fecha={1}", path, fecha.ToString());

            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
               precios = await response.Content.ReadAsAsync<List<Articulo.Precio>>();
            }

            return precios;
        }

        public async Task<List<Descuento>> DescuentosActualizados(DateTime fecha)
        {
            List<Descuento> descuentos = new List<Descuento>();

            string url = string.Format("{0}/descuentos/actualizados?fecha={1}", path, fecha.ToString());

            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                descuentos = await response.Content.ReadAsAsync<List<Descuento>>();
            }

            return descuentos;
        }

        public async Task<List<Descuento.Periodo>> DescuentosPeriodoActualizados(DateTime fecha)
        {
            List<Descuento.Periodo> descuentos = new List<Descuento.Periodo>();

            string url = string.Format("{0}/descuentos/periodo/actualizados?fecha={1}", path, fecha.ToString());

            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                descuentos = await response.Content.ReadAsAsync<List<Descuento.Periodo>>();
            }

            return descuentos;
        }

        public async Task<List<Descuento.Cantidad>> DescuentosCantidadActualizados(DateTime fecha)
        {
            List<Descuento.Cantidad> descuentos = new List<Descuento.Cantidad>();

            string url = string.Format("{0}/descuentos/cantidad/actualizados?fecha={1}", path, fecha.ToString());

            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                descuentos = await response.Content.ReadAsAsync<List<Descuento.Cantidad>>();
            }

            return descuentos;
        }

        public async Task<List<Articulo.Inventario>> InventariosActualizados(DateTime fecha)
        {
            List<Articulo.Inventario> inventarios = new List<Articulo.Inventario>();

            string url = string.Format("{0}/inventario/actualizados?fecha={1}", path, fecha.ToString());

            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                inventarios = await response.Content.ReadAsAsync<List<Articulo.Inventario>>();
            }

            return inventarios;
        }

        public async Task<List<Articulo.CodigoBarras>> CodigosBarrasActualizados(DateTime fecha)
        {
            List<Articulo.CodigoBarras> codigos_barras = new List<Articulo.CodigoBarras>();

            string url = string.Format("{0}/codigos-barras/actualizados?fecha={1}", path, fecha.ToString());

            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                codigos_barras = await response.Content.ReadAsAsync<List<Articulo.CodigoBarras>>();
            }

            return codigos_barras;
        }
    }
}
