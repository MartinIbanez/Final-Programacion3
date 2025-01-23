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
                datos.setearParametro("@Dni", nuevo.Dni); 
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Apellido", nuevo.Apellido);
                datos.setearParametro("@Direccion", nuevo.Direccion);
                datos.setearParametro("@Provincia", nuevo.Provincia);
                datos.setearParametro("@CodPostal", nuevo.CodPostal);
                datos.setearParametro("@Email", nuevo.Email);
                datos.setearParametro("@Pass", nuevo.Password);
                datos.setearParametro("@Estado", nuevo.Estado);
                datos.setearParametro("@Tipo", nuevo.Tipo);

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
    }
}
