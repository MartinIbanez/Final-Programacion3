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
                // Obtenemos la lista de artículos
                List<Venta> listaVenta = venNeg.ListaVentas();

                // Enlazamos la lista al control repeater
                rptDetalle.DataSource = listaVenta;
                rptDetalle.DataBind();
            }
            catch (Exception ex)
            {
                // Manejo de errores
                lblError.Text = "Ocurrió un error al cargar los artículos: " + ex.Message;
                lblError.Visible = true;
            }
        }

        protected void rptDetalle_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                int numFactura = int.Parse(e.CommandArgument.ToString()); // Obtiene el ID de la marca

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