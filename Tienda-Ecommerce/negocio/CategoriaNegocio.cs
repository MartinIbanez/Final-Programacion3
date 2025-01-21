using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> ListarCategorias()
        {
            List<Categoria> ListaCategorias = new List<Categoria>();
            AccesoDatos cn = new AccesoDatos();

            try
            {
                cn.setearConsulta("SELECT IdCategoria, NombreCategoria, EstadoCategoria FROM Categorias ORDER BY IdCategoria");
                cn.ejecutarLectura();

                while (cn.Lector.Read())
                {
                    Categoria CategoriaAux = new Categoria();                   

                    CategoriaAux.IdCategoria = (int)cn.Lector["IdCategoria"];
                    CategoriaAux.NombreCategoria = cn.Lector["NombreCategoria"].ToString();
                    CategoriaAux.Estado = (bool)cn.Lector["EstadoCategoria"];

                    ListaCategorias.Add(CategoriaAux);

                }
                return ListaCategorias;
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

        public List<Categoria> CategoriasActivas()
        {
            List<Categoria> catActivas = new List<Categoria>();
            AccesoDatos cn = new AccesoDatos();
            try
            {
                cn.setearConsulta("SELECT IdCategoria, NombreCategoria FROM Categorias WHERE EstadoCategoria = 1");
                cn.ejecutarLectura();
                while (cn.Lector.Read())
                {
                    Categoria cat = new Categoria
                    {
                        IdCategoria = (int)cn.Lector["IdCategoria"],
                        NombreCategoria = cn.Lector["NombreCategoria"].ToString()
                        

                    };
                    catActivas.Add(cat);
                }
                return catActivas;
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

        public void NuevaCategoria(Categoria nuevaCat)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("NuevaCategoria");
                datos.setearParametro("@NombreCategoria", nuevaCat.NombreCategoria);
                datos.setearParametro("@EstadoCategoria", nuevaCat.Estado);

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

        public void ModificarCategoria(Categoria editarCat)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {                
                datos.setearProcedimiento("editarCategoria");
                datos.setearParametro("@IdCategoria", editarCat.IdCategoria); 
                datos.setearParametro("@NombreCategoria", editarCat.NombreCategoria);
                datos.setearParametro("@EstadoCategoria", editarCat.Estado);
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

        public void EliminarCategoria(int idCategoria)
        {
            AccesoDatos cn = new AccesoDatos();
            try
            {               
                cn.setearProcedimiento("EliminarCategoria");
                cn.setearParametro("@IdCategoria", idCategoria);
                cn.ejecutarAccion(); 
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la categoría", ex);
            }
            finally
            {
                cn.cerrarConexion();
            }
        }
    }
}

  
