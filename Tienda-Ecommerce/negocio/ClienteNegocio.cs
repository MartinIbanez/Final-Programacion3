using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace negocio
{
    public class ClienteNegocio
    {
        public List<Cliente> ClientesListado()
        {
            string consulta = "SELECT CL_DNI, CL_Nombre, CL_Apellido, CL_Direccion, CL_Provincia, CL_CodPostal, CL_Email, CL_Password, CL_Estado, CL_Tipo FROM CLIENTES ORDER BY CL_Apellido";

            List<Cliente> ListarClientes = new List<Cliente>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Cliente ClientesAux = new Cliente
                    {
                        Dni = (string)datos.Lector["CL_DNI"],
                        Nombre = (string)datos.Lector["CL_Nombre"],
                        Apellido = (string)datos.Lector["CL_Apellido"],
                        Direccion = (string)datos.Lector["CL_Direccion"],
                        Provincia = (string)datos.Lector["CL_Provincia"],
                        CodPostal = (string)datos.Lector["CL_CodPostal"],
                        Email = (string)datos.Lector["CL_Email"],
                        Password = (string)datos.Lector["CL_Password"],
                        Estado = (bool)datos.Lector["CL_Estado"],
                        Tipo = (bool)datos.Lector["CL_Tipo"]
                    };

                    ListarClientes.Add(ClientesAux);
                }
                return ListarClientes;
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

        public string NuevoCliente(Cliente nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("NuevoCliente");
                datos.setearParametro("@dni", nuevo.Dni); 
                datos.setearParametro("@nombre", nuevo.Nombre);
                datos.setearParametro("@apellido", nuevo.Apellido);
                datos.setearParametro("@direccion", nuevo.Direccion);
                datos.setearParametro("@provincia", nuevo.Provincia);
                datos.setearParametro("@codPostal", nuevo.CodPostal);
                datos.setearParametro("@email", nuevo.Email);
                datos.setearParametro("@pass", nuevo.Password);
                datos.setearParametro("@estado", nuevo.Estado);
                datos.setearParametro("@tipo", nuevo.Tipo);

                return datos.ejecutarAccionScalar().ToString();
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

        public void ModificarCliente(Cliente editarCliente)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("editarCliente");
                datos.setearParametro("@dni", editarCliente.Dni); 
                datos.setearParametro("@nombre", editarCliente.Nombre);
                datos.setearParametro("@apellido", editarCliente.Apellido);
                datos.setearParametro("@direccion", editarCliente.Direccion);
                datos.setearParametro("@provincia", editarCliente.Provincia);
                datos.setearParametro("@codPostal", editarCliente.CodPostal);
                datos.setearParametro("@email", editarCliente.Email);
                datos.setearParametro("@pass", editarCliente.Password);
                datos.setearParametro("@estado", editarCliente.Estado);
                datos.setearParametro("@tipo", editarCliente.Tipo);

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

        public void EliminarCliente(string dniCliente) 
        {
            AccesoDatos cn = new AccesoDatos();
            try
            {
                cn.setearProcedimiento("EliminarCliente");
                cn.setearParametro("@dni", dniCliente);
                cn.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar eliminar Cliente", ex);
            }
            finally
            {
                cn.cerrarConexion();
            }
        }
         // Retorna -1 si no existe, 0 si existe y es cliente y 1 si existe y es admin
        public int verifarLogin(string email, string pass) 
        {
            string consulta = $"SELECT CL_Tipo FROM Clientes WHERE CL_Email='{email}' AND CL_Password='{pass}' AND CL_Estado=1";
          
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    bool esAdmin = (bool)datos.Lector["CL_Tipo"];

                    if (esAdmin)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }

                }
                return -1 ;
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

        public Cliente buscarClienteEmail(string email, string pass)
        {
            string consulta = $"SELECT CL_DNI, CL_Nombre, CL_Apellido, CL_Direccion, CL_Provincia, CL_CodPostal, CL_Email, CL_Password, CL_Estado, CL_Tipo FROM CLIENTES WHERE CL_Email='{email}' AND CL_Password='{pass}' AND CL_Estado=1";

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Cliente ClienteAux = new Cliente
                    {
                        Dni = (string)datos.Lector["CL_DNI"],
                        Nombre = (string)datos.Lector["CL_Nombre"],
                        Apellido = (string)datos.Lector["CL_Apellido"],
                        Direccion = (string)datos.Lector["CL_Direccion"],
                        Provincia = (string)datos.Lector["CL_Provincia"],
                        CodPostal = (string)datos.Lector["CL_CodPostal"],
                        Email = (string)datos.Lector["CL_Email"],
                        Password = (string)datos.Lector["CL_Password"],
                        Estado = (bool)datos.Lector["CL_Estado"],
                        Tipo = (bool)datos.Lector["CL_Tipo"]
                    };
                    return ClienteAux;
                    
                }
                return null;
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
