using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class VentaNegocio
    {
        public List<Venta> ListaVentas()
        {
            List<Venta> ListaVentas = new List<Venta>();
            AccesoDatos cn = new AccesoDatos();

            try
            {
                cn.setearConsulta("SELECT Vta_NroFactura, Vta_DNI, Vta_Fecha, Vta_Monto, Vta_MetodoPago FROM Ventas");
                cn.ejecutarLectura();

                while (cn.Lector.Read())
                {
                    Venta VentaAux = new Venta();
                    {
                        VentaAux.NroFactura = cn.Lector["Vta_NroFactura"].ToString();
                        VentaAux.Dni = cn.Lector["Vta_DNI"].ToString();
                        VentaAux.Fecha = (DateTime)cn.Lector["Vta_Fecha"];
                        VentaAux.Monto = (decimal)cn.Lector["Vta_Monto"];
                        VentaAux.MetodoPago = cn.Lector["Vta_MetodoPago"].ToString();

                        ListaVentas.Add(VentaAux);
                    }

                };

                return ListaVentas;
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

        public void RegistrarVenta(Venta ventas)
        {
            AccesoDatos cn = new AccesoDatos();

            try
            {
                cn.setearProcedimiento("RegistroVenta");

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


