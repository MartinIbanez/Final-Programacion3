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
                cn.setearConsulta("SELECT IdArticulo,Art_Descripcion,Art_IdCategoria,Art_IdMarca,Art_Proveedor,Art_Nombre,Art_Stock,Art_UrlImagen,Art_Precio,Art_StockMinimo,Art_Estado FROM Articulos ORDER BY IdArticulo");
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

                    // Busco el nombre de la categoria y de la marca 
                    int idCategoria = ArticuloAux.IdCategoria;
                    string nombreCategoria = BuscarNombreCat(idCategoria);
                    ArticuloAux.NombreCategoria = nombreCategoria;

                    int idMarca = ArticuloAux.IdMarca;
                    string nombreMarca = BuscarNombreMarca(idMarca);
                    ArticuloAux.NombreMarca = nombreMarca;

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

        private string BuscarNombreCat(int idCategoria)
        {
            string nombreCategoria = "";
            AccesoDatos cn = new AccesoDatos();

            try
            {
                cn.setearConsulta($"SELECT NombreCategoria FROM Categorias WHERE IdCategoria = {idCategoria}");
                cn.ejecutarLectura();

                if (cn.Lector.Read())
                {
                    nombreCategoria = cn.Lector["NombreCategoria"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cn.cerrarConexion();
            }

            return nombreCategoria;
        }

        private string BuscarNombreMarca(int idMarca)
        {
            string nombreMarca = "";
            AccesoDatos cn = new AccesoDatos();

            try
            {
                cn.setearConsulta($"SELECT DescripcionMarca FROM Marcas WHERE IdMarca = {idMarca}");
                cn.ejecutarLectura();

                if (cn.Lector.Read())
                {
                    nombreMarca = cn.Lector["DescripcionMarca"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cn.cerrarConexion();
            }

            return nombreMarca;
        }

        public Articulo BuscarArticuloPorId(int idArticulo)
        {
            string consulta = $"SELECT IdArticulo, Art_Descripcion, Art_IdCategoria, Art_IdMarca, Art_Proveedor, Art_Nombre, Art_Stock, Art_UrlImagen, Art_Precio, Art_StockMinimo, Art_Estado FROM Articulos WHERE IdArticulo = '{idArticulo}'";
            Articulo articulo = null;
            AccesoDatos cn = new AccesoDatos();

            try
            {
                cn.setearConsulta(consulta);
                cn.ejecutarLectura();

                if (cn.Lector.Read())
                {
                    articulo = new Articulo
                    {
                        IdArticulo = (int)cn.Lector["IdArticulo"],
                        Descripcion = cn.Lector["Art_Descripcion"].ToString(),
                        IdCategoria = (int)cn.Lector["Art_IdCategoria"],
                        IdMarca = (int)cn.Lector["Art_IdMarca"],
                        IdProveedor = (int)cn.Lector["Art_Proveedor"],
                        Nombre = cn.Lector["Art_Nombre"].ToString(),
                        Stock = (int)cn.Lector["Art_Stock"],
                        UrlImagen = cn.Lector["Art_UrlImagen"].ToString(),
                        Precio = cn.Lector["Art_Precio"] != DBNull.Value ? Convert.ToDecimal(cn.Lector["Art_Precio"]) : 0,
                        StockMinimo = (int)cn.Lector["Art_StockMinimo"],
                        Estado = (bool)cn.Lector["Art_Estado"]
                    };

                    articulo.NombreCategoria = BuscarNombreCat(articulo.IdCategoria);
                    articulo.NombreMarca = BuscarNombreMarca(articulo.IdMarca);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el artículo por ID", ex);
            }
            finally
            {
                cn.cerrarConexion();
            }

            return articulo;
        }

        public List<Articulo> FiltrarProductos(string marca, string categoria, decimal precioMin, decimal precioMax)
        { 
            List<Articulo> todosLosProductos = ListaArticulos();

            return todosLosProductos.FindAll(p =>
                (string.IsNullOrEmpty(marca) || p.IdMarca.ToString() == marca) &&
                (string.IsNullOrEmpty(categoria) || p.IdCategoria.ToString() == categoria) &&
                p.Precio >= precioMin &&
                p.Precio <= precioMax
            );
        }



        //Metodos para el ABM de Articulos
        public void NuevoArticulo(Articulo nuevoArt)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("NuevoArticulo");
                datos.setearParametro("@Art_Descripcion", nuevoArt.Descripcion ?? "");
                datos.setearParametro("@Art_IdCategoria", nuevoArt.IdCategoria);
                datos.setearParametro("@Art_IdMarca", nuevoArt.IdMarca);
                datos.setearParametro("@Art_Proveedor", nuevoArt.IdProveedor);
                datos.setearParametro("@Art_Nombre", nuevoArt.Nombre ?? "");
                datos.setearParametro("@Art_Stock", nuevoArt.Stock);
                datos.setearParametro("@Art_UrlImagen", nuevoArt.UrlImagen ?? "");
                datos.setearParametro("@Art_Precio", nuevoArt.Precio);
                datos.setearParametro("@Art_StockMinimo", nuevoArt.StockMinimo);
                datos.setearParametro("@Art_Estado", nuevoArt.Estado);

                datos.ejecutarAccion();
            }
            catch (FormatException ex)
            {
                throw new Exception("Ocurrió un error en el formato de datos: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar el artículo: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void ModificarArticulo(Articulo editarArticulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("editarArticulo");
                datos.setearParametro("@Art_Descripcion", editarArticulo.Descripcion);
                datos.setearParametro("@Art_IdCategoria", editarArticulo.IdCategoria);
                datos.setearParametro("@Art_IdMarca", editarArticulo.IdMarca);
                datos.setearParametro("@Art_Proveedor", editarArticulo.IdProveedor);
                datos.setearParametro("@Art_Nombre", editarArticulo.Nombre);
                datos.setearParametro("@Art_Stock", editarArticulo.Stock);
                datos.setearParametro("@Art_UrlImagen", editarArticulo.UrlImagen);
                datos.setearParametro("@Art_Precio", editarArticulo.Precio);
                datos.setearParametro("@Art_StockMinimo", editarArticulo.StockMinimo);
                datos.setearParametro("@Art_Estado", editarArticulo.Estado);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void EliminarArticulo(int idArticulo)
        {
            AccesoDatos cn = new AccesoDatos();
            try
            {
                cn.setearProcedimiento("EliminarArticulo");
                cn.setearParametro("@IdArticulo", idArticulo);
                cn.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar Articulo", ex);
            }
            finally
            {
                cn.cerrarConexion();
            }
        }

    }
}
