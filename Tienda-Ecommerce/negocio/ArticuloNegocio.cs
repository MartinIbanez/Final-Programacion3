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
        //AccesoDatos cn=new AccesoDatos();
        //Conexion cn=new Conexion();
        public List<Articulo> ArticulosDestacados()
        {     
            //string Consulta = "SELECT TOP 5 IdArticulo,Art_Nombre, Art_UrlImagen, Art_Precio FROM Articulos ORDER BY NEWID()";
            List<Articulo> ListaArtDestacados=new List<Articulo>();
            AccesoDatos cn = new AccesoDatos();

            try              
            {
                cn.setearConsulta("SELECT TOP 5 IdArticulo,Art_Nombre, Art_UrlImagen, Art_Precio FROM Articulos ORDER BY NEWID()");
                cn.ejecutarLectura();

                while (cn.Lector.Read())
                {
                    Articulo ArtDest = new Articulo();

                    ArtDest.IdArticulo = (int)cn.Lector["IdArticulo"];                  
                    ArtDest.Nombre = cn.Lector["Art_Nombre"].ToString();
                    ArtDest.UrlImagen = cn.Lector["Art_UrlImagen"].ToString();
                    ArtDest.Precio = cn.Lector["Art_Precio"] != DBNull.Value ? Convert.ToDecimal(cn.Lector["Art_Precio"]) : 0;


                    ListaArtDestacados.Add( ArtDest );
                    
                }
            return ListaArtDestacados;
            }

            catch (Exception ex) {
                throw ex;
            }
            finally
            {
                cn.cerrarConexion();
            }
        }
    }
}
