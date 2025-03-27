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

                    int idProveedor = ArticuloAux.IdProveedor;
                    string nombreProveedor = BuscarNombreProveedor(idProveedor);
                    ArticuloAux.NombreProveedor = nombreProveedor;

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
                cn.setearConsulta("SELECT NombreCategoria FROM Categorias WHERE IdCategoria = @id");
                cn.setearParametro("@id", idCategoria);

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

        private string BuscarNombreProveedor(int idProveedor)
        {
            string nombreMarca = "";
            AccesoDatos cn = new AccesoDatos();

            try
            {
                cn.setearConsulta($"SELECT PR_Nombre FROM Proveedores WHERE Id_Proveedores = {idProveedor}");
                cn.ejecutarLectura();

                if (cn.Lector.Read())
                {
                    nombreMarca = cn.Lector["PR_Nombre"].ToString();
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
                string consulta = "UPDATE Articulos SET Art_Descripcion = @descripcion, Art_IdCategoria = @idCat, " +
                    "Art_IdMarca = @idMarca,Art_Proveedor = @idProv,Art_Nombre = @nombre,Art_Stock = @stock," +
                    "Art_UrlImagen = @url,Art_Precio = @precio,Art_StockMinimo = @stockMin, Art_Estado = 1 " +
                    "WHERE IdArticulo = @idArt;";

                datos.setearConsulta(consulta);
                datos.setearParametro("@descripcion", editarArticulo.Descripcion);
                datos.setearParametro("@idCat", editarArticulo.IdCategoria);
                datos.setearParametro("@idMarca", editarArticulo.IdMarca);
                datos.setearParametro("@idProv", editarArticulo.IdProveedor);
                datos.setearParametro("@nombre", editarArticulo.Nombre);
                datos.setearParametro("@stock", editarArticulo.Stock);
                datos.setearParametro("@url", editarArticulo.UrlImagen);
                datos.setearParametro("@precio", editarArticulo.Precio);
                datos.setearParametro("@stockMin", editarArticulo.StockMinimo);
                datos.setearParametro("@idArt", editarArticulo.IdArticulo);

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
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "delete from Articulos where IdArticulo = @id";

                datos.setearConsulta(consulta);
                datos.setearParametro("@id", idArticulo);

                datos.ejecutarAccion();

                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar: " + ex.Message);
                return;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public int StockActual(int idArticulo)
        {
            AccesoDatos cn = new AccesoDatos();
            int stock = 0;

            try
            {
                cn.setearConsulta("SELECT Art_Stock FROM Articulos WHERE IdArticulo = @idArticulo");
                cn.setearParametro("@idArticulo", idArticulo);
                cn.ejecutarLectura();

                if (cn.Lector.Read())
                {
                    stock = (int)cn.Lector["Art_Stock"];
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
            finally
            {
                cn.cerrarConexion();
            }

            return stock;
        }

    }
}
