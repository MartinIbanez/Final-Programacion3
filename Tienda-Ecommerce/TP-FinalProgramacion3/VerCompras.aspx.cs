using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_FinalProgramacion3
{
    public partial class VerCompras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarVenta();
            }
        }

        private void CargarVenta()
        {
            VentaNegocio venNeg = new VentaNegocio();
            try
            {
                if (Session["UsuarioLogin"] != null)
                {
                    Cliente usuario = Session["UsuarioLogin"] as Cliente;

                    List<Venta> listaVenta;
                    if (usuario.Tipo) 
                    {
                        listaVenta = venNeg.ListaVentas();
                    }
                    else 
                    {
                        listaVenta = venNeg.VentasPorCliente(usuario.Dni);
                    }

                    rptDetalle.DataSource = listaVenta;
                    rptDetalle.DataBind();
                }
                
            }
            catch (Exception ex)
            {
                lblError.Text = "Ocurrió un error al cargar las compras: " + ex.Message;
                lblError.Visible = true;
            }
        }

        protected void rptDetalle_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                int numFactura = int.Parse(e.CommandArgument.ToString()); 

                if (e.CommandName == "Detalle")
                {
                    Response.Redirect("verDetalleVenta.aspx?numFactura=" + numFactura);
                }

            }
            catch (Exception ex)
            {
                lblError.Text = "Error al ejecutar la acción: " + ex.Message;
                lblError.Visible = true;
            }
        }
    }
}