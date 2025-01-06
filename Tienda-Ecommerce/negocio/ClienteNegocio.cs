using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class ClienteNegocio
    {
        Conexion cn = new Conexion();

        public List<Cliente> ClientesListado()
        {
            string consulta = "SELECT CL_DNI, CL_Nombre,CL_Apellido,CL_Direccion,CL_Provincia,CL_CodPostal, CL_Email,CL_Password,CL_Estado,CL_Tipo FROM CLIENTES ORDER BY CL_Apellido";

            List<Cliente> ListarClientes = new List<Cliente>();

            try
            {
                SqlDataAdapter Adapter = cn.ObtenerAdaptador(consulta);
                DataTable Clientes = new DataTable();

                Adapter.Fill(Clientes);

                foreach (DataRow fila in Clientes.Rows)
                {
                    Cliente ClientesAux = new Cliente();

                    ClientesAux.Dni = fila["CL_DNI"].ToString();
                    ClientesAux.Nombre = fila["CL_Nombre"].ToString();
                    ClientesAux.Apellido = fila["CL_Apellido"].ToString();
                    ClientesAux.Direccion = fila["CL_Direccion"].ToString();
                    ClientesAux.Provincia = fila["CL_Provincia"].ToString();
                    ClientesAux.CodPostal = fila["CL_CodPostal"].ToString();
                    ClientesAux.Email = fila["CL_Email"].ToString();
                    ClientesAux.Password = fila["CL_Password"].ToString();
                    ClientesAux.Estado = (bool)fila["CL_Estado"];
                    ClientesAux.Tipo = (bool)fila["CL_Tipo"];
                    
                    ListarClientes.Add(ClientesAux);
                }
                return ListarClientes;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en Listado de Clientes {ex.Message}");
            }
        }

        // Método para autenticar al cliente con email y contraseña
        public static Cliente Login(string mail, string password)
        {
            // Consulta para obtener los datos del cliente que coinciden con el email proporcionado
            string consulta = "SELECT CL_DNI, CL_Nombre, CL_Apellido, CL_Direccion, CL_Provincia, CL_CodPostal, CL_Email, CL_Password, CL_Estado, CL_Tipo FROM CLIENTES WHERE CL_Email = @Email";

            // Creamos una instancia de Conexion
            Conexion cn = new Conexion();

            // Obtenemos un adaptador con la consulta
            SqlDataAdapter adapter = cn.ObtenerAdaptador(consulta);

            // Usamos la conexión obtenida a través del adaptador
            SqlCommand command = new SqlCommand(consulta, cn.ObtenerConexion());
            command.Parameters.AddWithValue("@Email", mail);

            try
            {
                // Ejecutar la consulta y leer los datos
                SqlDataReader reader = command.ExecuteReader();

                // Si se encontró un cliente con ese email
                if (reader.HasRows)
                {
                    reader.Read(); // Lee el primer (y único) registro que debe coincidir con el email
                    string storedPassword = reader["CL_Password"].ToString(); // Obtén la contraseña almacenada

                    // Aquí debes verificar si la contraseña ingresada coincide con la almacenada en la base de datos
                    // Si estás usando hash para las contraseñas, debes encriptar `password` antes de compararlo
                    if (storedPassword == password) // Deberías usar encriptación de contraseñas en un escenario real
                    {
                        // Crear un objeto Cliente con los datos recuperados
                        Cliente cliente = new Cliente
                        {
                            Dni = reader["CL_DNI"].ToString(),
                            Nombre = reader["CL_Nombre"].ToString(),
                            Apellido = reader["CL_Apellido"].ToString(),
                            Direccion = reader["CL_Direccion"].ToString(),
                            Provincia = reader["CL_Provincia"].ToString(),
                            CodPostal = reader["CL_CodPostal"].ToString(),
                            Email = reader["CL_Email"].ToString(),
                            Password = storedPassword, // Aunque es una mala práctica, por ahora usaremos el password directamente
                            Estado = (bool)reader["CL_Estado"],
                            Tipo = (bool)reader["CL_Tipo"]
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
                cn.ObtenerConexion().Close();
            }
        }
    }
    }

