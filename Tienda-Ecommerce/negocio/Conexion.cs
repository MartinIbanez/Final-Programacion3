using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class Conexion
    {
        private string RutaBase = "Data Source=localhost\\SQLEXPRESS; Initial Catalog=ECOMMERCE; Integrated Security=true ";

        public SqlConnection ObtenerConexion()
        {
            SqlConnection conexion = new SqlConnection(RutaBase);
            try
            {
                conexion.Open();

                return conexion;
            }
            catch
            {
                return null;
            }
        }

        public SqlDataAdapter ObtenerAdaptador(string consulta)
        {
            SqlDataAdapter adapter;

            try
            {
                adapter = new SqlDataAdapter(consulta, ObtenerConexion());
                return adapter;
            }
            catch
            {
                return null;
            }
        }
    }


}
