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

        public string ultimoNumFactura()
        {
            AccesoDatos cn = new AccesoDatos();

            try
            {
                cn.setearConsulta("SELECT TOP 1 Vta_NroFactura FROM Ventas ORDER BY Vta_NroFactura DESC");
                cn.ejecutarLectura();
                string numFactura = "";
                while (cn.Lector.Read())
                {
                    numFactura = cn.Lector["Vta_NroFactura"].ToString();
                };

                return numFactura;
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

        public bool IngresarVenta(string dni, string metodoPago)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "INSERT INTO Ventas (Vta_DNI, Vta_MetodoPago) VALUES (@dni, @metodoPago)";

                datos.setearConsulta(consulta);
                datos.setearParametro("@dni", dni);
                datos.setearParametro("@metodoPago", metodoPago);

                datos.ejecutarAccion();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al ingresar la venta: " + ex.Message);
                return false;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        public bool IngresarDetalleVenta(string numFact, int idArt, decimal precio, int cantidad)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "insert into Detalle_Ventas (DV_NroFactura,DV_IdArticulo ,DV_Precio ,DV_Cantidad) values (@NroFactura ,@idArticulo,@precio,@cantidad)";

                datos.setearConsulta(consulta);
                datos.setearParametro("@NroFactura", numFact);
                datos.setearParametro("@idArticulo", idArt);
                datos.setearParametro("@precio", precio);
                datos.setearParametro("@cantidad", cantidad);
                datos.ejecutarAccion();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al ingresar la venta: " + ex.Message);
                return false;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<DetalleVenta> ListaDetalleVenta(int numFactura)
        {
            List<DetalleVenta> ListaDetalle = new List<DetalleVenta>();
            AccesoDatos cn = new AccesoDatos();

            try
            {
                cn.setearConsulta("select DV_NroFactura,DV_IdArticulo,Art_Nombre,DV_Precio,DV_Cantidad from Detalle_Ventas join Articulos on DV_IdArticulo = IdArticulo where DV_NroFactura = @numFact");
                cn.setearParametro("@numFact", numFactura);
                cn.ejecutarLectura();

                while (cn.Lector.Read())
                {
                    DetalleVenta VentaAux = new DetalleVenta();
                    {
                        VentaAux.NroFactura = cn.Lector["DV_NroFactura"].ToString();
                        VentaAux.IdArticulo = Convert.ToInt32(cn.Lector["DV_IdArticulo"]);
                        VentaAux.NombreArticulo = cn.Lector["Art_Nombre"].ToString();
                        VentaAux.Precio = (decimal)cn.Lector["DV_Precio"];
                        VentaAux.Cantidad = Convert.ToInt32(cn.Lector["DV_Cantidad"]);

                        ListaDetalle.Add(VentaAux);
                    }

                };

                return ListaDetalle;
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



