using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class MarcaNegocio
    {
        public List<Marca> ListarMarcas()
        {
            List<Marca> ListaMarcas = new List<Marca>();
            AccesoDatos cn = new AccesoDatos();

            try
            {
                cn.setearConsulta("SELECT IdMarca,DescripcionMarca, EstadoMarca FROM Marcas ORDER BY IdMarca");
                cn.ejecutarLectura();

                while (cn.Lector.Read())
                {
                    Marca MarcaAux = new Marca();
                 
                    MarcaAux.IdMarca = (int)cn.Lector["IdMarca"];
                    MarcaAux.Descripcion = cn.Lector["DescripcionMarca"].ToString();
                    MarcaAux.Estado = (bool)cn.Lector["EstadoMarca"];

                    ListaMarcas.Add(MarcaAux);
                   
                }
                return ListaMarcas;
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

        public void AgregarMarca(Marca nuevaMarca)
        {
            AccesoDatos cn = new AccesoDatos();
            try
            {
                cn.setearConsulta("INSERT INTO Marcas (DescripcionMarca, EstadoMarca) VALUES (@Descripcion, @Estado)");
                cn.setearParametro("@Descripcion", nuevaMarca.Descripcion);
                cn.setearParametro("@Estado", nuevaMarca.Estado);
                cn.ejecutarAccion();
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

        public void ModificarMarca(Marca marca)
        {
            AccesoDatos cn = new AccesoDatos();
            try
            {
                cn.setearConsulta("UPDATE Marcas SET DescripcionMarca = @Descripcion, EstadoMarca = @Estado WHERE IdMarca = @Id");
                cn.setearParametro("@Descripcion", marca.Descripcion);
                cn.setearParametro("@Estado", marca.Estado);
                cn.setearParametro("@Id", marca.IdMarca);
                cn.ejecutarAccion();
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
        public void EliminarMarca(int idMarca)
        {
            AccesoDatos cn = new AccesoDatos();
            try
            {
                cn.setearConsulta("DELETE FROM Marcas WHERE IdMarca = @IdMarca");
                cn.setearParametro("@IdMarca", idMarca);
                cn.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la marca.", ex);
            }
            finally
            {
                cn.cerrarConexion();
            }
        }




    }
}
