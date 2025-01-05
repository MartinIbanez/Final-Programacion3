using dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class ArticuloNegocio
    {
        Conexion cn=new Conexion();
        public List<Articulo> ArticulosDestacados()
        {

            string Consulta = "SELECT TOP 5 IdArticulo,Art_Nombre, Art_UrlImagen, Art_Precio FROM Articulos ORDER BY NEWID()";

            List<Articulo> ListaArtDestacados=new List<Articulo>();

            try
            {
                SqlDataAdapter Adapter = cn.ObtenerAdaptador(Consulta);
                DataTable ArticulosDest = new DataTable();

                Adapter.Fill( ArticulosDest );

                foreach(DataRow fila in ArticulosDest.Rows)
                {
                   Articulo ArtDest = new Articulo();
                   ArtDest.IdArticulo=Convert.ToInt32(fila["IdArticulo"]);
                    ArtDest.Nombre = fila["Art_Nombre"].ToString();
                    ArtDest.UrlImagen = fila["Art_UrlImagen"].ToString();
                    ArtDest.Precio = Convert.ToDecimal(fila["Art_Precio"]);

                    ListaArtDestacados.Add( ArtDest );
                    
                }
            return ListaArtDestacados;
            }

            catch (Exception ex) {
                throw new Exception($"Error en ArticulosDestacados: {ex.Message}");
            }
        }
    }
}
