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
            List<Articulo> ListaArtDestacados = new List<Articulo>();
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


                    ListaArtDestacados.Add(ArtDest);

                }
                return ListaArtDestacados;
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cn.cerrarConexion();
            }
        }

        public List<Articulo> ListaArticulos()
        {
            List<Articulo> ListaArticulos = new List<Articulo>();
            AccesoDatos cn = new AccesoDatos();

            try
            {
                cn.setearConsulta("SELECT IdArticulo,Art_Descripcion,Art_IdCategoria,Art_IdMarca,Art_Proveedor,Art_Nombre,Art_Stock,Art_UrlImagen,Art_Precio,Art_StockMinimo,Art_Estado FROM Articulos ORDER BY Art_IdCategoria");
                cn.ejecutarLectura();

                while (cn.Lector.Read())
                {
                    Articulo ArticuloAux = new Articulo();

                    ArticuloAux.IdArticulo = (int)cn.Lector["IdArticulo"];
                    ArticuloAux.Descripcion = cn.Lector["Art_Descripcion"].ToString();
                    ArticuloAux.IdCategoria = (int)cn.Lector["Art_IdCategoria"];
                    ArticuloAux.IdMarca = (int)cn.Lector["Art_IdMarca"];
                    ArticuloAux.IdProveedor = (int)cn.Lector["Art_Proveedor"];
                    ArticuloAux.Nombre = cn.Lector["Art_Nombre"].ToString();
                    ArticuloAux.Stock = (int)cn.Lector["Art_Stock"];
                    ArticuloAux.UrlImagen = cn.Lector["Art_UrlImagen"].ToString();
                    ArticuloAux.Precio = cn.Lector["Art_Precio"] != DBNull.Value ? Convert.ToDecimal(cn.Lector["Art_Precio"]) : 0;
                    ArticuloAux.StockMinimo = (int)cn.Lector["Art_StockMinimo"];
                    ArticuloAux.Estado = (bool)cn.Lector["Art_Estado"];


                    ListaArticulos.Add(ArticuloAux);

                }
                return ListaArticulos;
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cn.cerrarConexion();
            }
        }

    }
}
