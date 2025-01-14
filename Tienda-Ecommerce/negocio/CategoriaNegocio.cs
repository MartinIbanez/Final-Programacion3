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
                cn.setearConsulta("SELECT IdCategoria, NombreCategoria, EstadoCategoria FROM Categorias ORDER BY NombreCategoria");
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

        

    }
}
