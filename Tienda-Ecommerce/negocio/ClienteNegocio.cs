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
       // Conexion cn = new Conexion();

        public List<Cliente> ClientesListado()
        {
            string consulta = "SELECT CL_DNI, CL_Nombre,CL_Apellido,CL_Direccion,CL_Provincia,CL_CodPostal, CL_Email,CL_Password,CL_Estado,CL_Tipo FROM CLIENTES ORDER BY CL_Apellido";

            List<Cliente> ListarClientes = new List<Cliente>();
            AccesoDatos datos= new AccesoDatos();

            try
            {
                datos.setearConsulta( consulta );
                datos.ejecutarLectura();

                while (datos.Lector.Read()) 
                {
                    Cliente ClientesAux = new Cliente();

                    ClientesAux.Dni = (string)datos.Lector["CL_DNI"];
                    ClientesAux.Nombre = (string)datos.Lector["CL_Nombre"];
                    ClientesAux.Apellido = (string)datos.Lector["CL_Apellido"];
                    ClientesAux.Direccion = (string)datos.Lector["CL_Direccion"];
                    ClientesAux.Provincia = (string)datos.Lector["CL_Provincia"];
                    ClientesAux.CodPostal = (string)datos.Lector["CL_CodPostal"];
                    ClientesAux.Email = (string)datos.Lector["CL_Email"];
                    ClientesAux.Password = (string)datos.Lector["CL_Password"];
                    // campos booleanos
                    ClientesAux.Estado = (bool)datos.Lector["CL_Estado"];
                    ClientesAux.Tipo = (bool)datos.Lector["CL_Tipo"];

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

        // Método para autenticar al cliente con email y contraseña
        public Cliente Login(string mail, string password)
        {
            // Consulta para obtener los datos del cliente que coinciden con el email proporcionado
            string consulta = "SELECT CL_DNI, CL_Nombre, CL_Apellido, CL_Direccion, CL_Provincia, CL_CodPostal, CL_Email, CL_Password, CL_Estado, CL_Tipo FROM CLIENTES WHERE CL_Email = @Email";

            // Creamos una instancia de AccesoDatos
            AccesoDatos cn = new AccesoDatos();

            // Establecemos la consulta
            cn.setearConsulta(consulta);

            // Agregamos el parámetro para la consulta
            cn.setearParametro("@Email", mail);

            try
            {
                // Ejecutamos la lectura de datos
                cn.ejecutarLectura();

                // Si se encontró un cliente con ese email
                if (cn.Lector.Read())
                {
                    string storedPassword = cn.Lector["CL_Password"].ToString(); // Obtén la contraseña almacenada

                    // Aquí debes verificar si la contraseña ingresada coincide con la almacenada en la base de datos
                    // Si estás usando hash para las contraseñas, deberías comparar el hash en vez de la contraseña en texto claro
                    if (storedPassword == password) // Comparación sin encriptación (en escenarios reales deberías usar un hash)
                    {
                        // Crear un objeto Cliente con los datos recuperados
                        Cliente cliente = new Cliente
                        {
                            Dni = cn.Lector["CL_DNI"].ToString(),
                            Nombre = cn.Lector["CL_Nombre"].ToString(),
                            Apellido = cn.Lector["CL_Apellido"].ToString(),
                            Direccion = cn.Lector["CL_Direccion"].ToString(),
                            Provincia = cn.Lector["CL_Provincia"].ToString(),
                            CodPostal = cn.Lector["CL_CodPostal"].ToString(),
                            Email = cn.Lector["CL_Email"].ToString(),
                            Password = storedPassword, // Aunque es una mala práctica, por ahora usaremos el password directamente
                            Estado = (bool)cn.Lector["CL_Estado"],
                            Tipo = (bool)cn.Lector["CL_Tipo"]
                        };

                        return cliente; // Devuelve el cliente autenticado
                    }
                }

                return null; // Si no se encuentra el cliente o la contraseña no es válida
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en la autenticación del cliente: {ex.Message}");
            }
            finally
            {
                // Asegurarse de que la conexión se cierre
                cn.cerrarConexion();
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
    }
}
