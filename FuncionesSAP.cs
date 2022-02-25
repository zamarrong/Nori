using NoriSAPB1SDK;
using NoriSDK;
using System.Data;
using System.Linq;
using System;
using System.Windows.Forms;

namespace Nori
{
    public static class FuncionesSAP
    {
        public static DataTable ObtenerExistencias(string sku)
        {
            try
            {
                DataTable existencias = DBSAP.EjecutarQuery(string.Format("SELECT ItemCode SKU, WhsCode Almacén, OnHand Stock FROM OITW WHERE ItemCode = '{0}' AND OnHand > 0", sku));

                return existencias;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + NoriSAP.ObtenerUltimoError().Message);
                return new DataTable();
            }
        }

        public static decimal ObtenerStock(string sku, string almacen)
        {
            try
            {
                decimal stock = DBSAP.EjecutarEscalarDecimal(string.Format("SELECT OnHand FROM OITW WHERE ItemCode = '{0}' AND WhsCode = '{1}'", sku, almacen));

                if (stock == 0 && Articulo.Articulos().Any(x => x.sku == sku && !x.almacenable))
                    stock = 100;

                return stock;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + NoriSAP.ObtenerUltimoError().Message);
                return 0m;
            }
        }

        public static bool StockNegativo(decimal cantidad, string sku, string unidad_medida, string almacen)
        {
            try
            {
                decimal stock = DBSAP.EjecutarEscalarDecimal(string.Format("SELECT OnHand / (SELECT BaseQty FROM UGP1 WHERE UgpEntry = (SELECT UgpEntry FROM OITM WHERE ItemCode = '{0}') AND UomEntry = '{1}') FROM OITW WHERE ItemCode = '{0}' AND WhsCode = '{2}'", sku, unidad_medida, almacen));

                if (stock <= 0 && Articulo.Articulos().Any(x => x.sku == sku && !x.almacenable))
                    stock = 100;

                return (stock < cantidad) ? true : false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + NoriSAP.ObtenerUltimoError().Message);
                return false;
            }
        }
    }
}
