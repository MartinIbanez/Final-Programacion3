using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class ProveedorNegocio
    {
        public List<Proveedores> ListarProveedores()
        {
            List<Proveedores> ListaProveedores = new List<Proveedores>();
            AccesoDatos cn = new AccesoDatos();

            try
            {
                cn.setearConsulta("SELECT Id_Proveedores,PR_Cuit,PR_Nombre,PR_NombreContacto,PR_CargoContacto,PR_Direccion,PR_Ciudad,PR_CodPostal,PR_Telefono,PR_Estado FROM Proveedores ORDER BY Id_Proveedores");
                cn.ejecutarLectura();

                while (cn.Lector.Read())
                {
                    Proveedores proveedorAux = new Proveedores();
                    
                    proveedorAux.IdProveedor= (int)cn.Lector["Id_Proveedores"];
                    proveedorAux.Cuit= cn.Lector["PR_Cuit"].ToString();
                    proveedorAux.Nombre= cn.Lector["PR_Nombre"].ToString();
                    proveedorAux.NombreContacto= cn.Lector["PR_NombreContacto"].ToString();
                    proveedorAux.CargoContacto = cn.Lector["PR_CargoContacto"].ToString();
                    proveedorAux.Direccion = cn.Lector["PR_Direccion"].ToString();
                    proveedorAux.Ciudad = cn.Lector["PR_Ciudad"].ToString();
                    proveedorAux.CodPostal = cn.Lector["PR_CodPostal"].ToString();
                    proveedorAux.Telefono = cn.Lector["PR_Telefono"].ToString();                    
                    proveedorAux.Estado = (bool) cn.Lector["PR_Estado"];
                    

                    ListaProveedores.Add(proveedorAux);

                }
                return ListaProveedores;
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

        public List<Proveedores> ProveedoresActivos()
        {
            List<Proveedores> proveedores = new List<Proveedores>();
            AccesoDatos cn = new AccesoDatos();
            try
            {
                cn.setearConsulta("SELECT Id_Proveedores,PR_Nombre FROM Proveedores WHERE PR_Estado=1");
                cn.ejecutarLectura();
                while (cn.Lector.Read())
                {
                    Proveedores provAct = new Proveedores
                    {
                        IdProveedor = (int)cn.Lector["Id_Proveedores"],
                        Nombre = cn.Lector["PR_Nombre"].ToString()
                    };

                    proveedores.Add(provAct);
                }
                return proveedores;
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

        //Metodos para el ABM de Proveedores
        public void NuevoProveedor(Proveedores nuevoProv)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("NuevoProveedor");
                datos.setearParametro("@Cuit", nuevoProv.Cuit);
                datos.setearParametro("@Nombre", nuevoProv.Nombre);
                datos.setearParametro("@NombreContacto", nuevoProv.NombreContacto);
                datos.setearParametro("@CargoContacto", nuevoProv.CargoContacto);
                datos.setearParametro("@Direccion", nuevoProv.Direccion);
                datos.setearParametro("@Ciudad", nuevoProv.Ciudad);
                datos.setearParametro("@CodPostal", nuevoProv.CodPostal);
                datos.setearParametro("@Telefono", nuevoProv.Telefono);

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

        public void ModificarProveedor(Proveedores editarProv)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("ModificarProveedor");
                datos.setearParametro("@idProveedor", editarProv.IdProveedor);
                datos.setearParametro("@Cuit", editarProv.Cuit);
                datos.setearParametro("@Nombre", editarProv.Nombre);
                datos.setearParametro("@NombreContacto", editarProv.NombreContacto);
                datos.setearParametro("@CargoContacto", editarProv.CargoContacto);
                datos.setearParametro("@Direccion", editarProv.Direccion);
                datos.setearParametro("@Ciudad", editarProv.Ciudad);
                datos.setearParametro("@CodPostal", editarProv.CodPostal);
                datos.setearParametro("@Telefono", editarProv.Telefono);

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

        
    }
}
