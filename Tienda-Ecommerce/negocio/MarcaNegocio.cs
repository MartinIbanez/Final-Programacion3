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

        


    }
}
