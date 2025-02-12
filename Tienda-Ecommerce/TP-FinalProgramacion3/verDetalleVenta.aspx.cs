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
    public partial class verDetalleVenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["numFactura"] != null)
                {
                    int numFactura = Convert.ToInt32(Request.QueryString["numFactura"]);
                    lblNumFactura.Text = $"Factura N ° {numFactura}";
                    CargarDetallesVentas(numFactura);
                }
            }
        }

        private void CargarDetallesVentas(int numFactura)
        {
            VentaNegocio venNeg = new VentaNegocio();
            try
            {
                List<DetalleVenta> listaVenta = venNeg.ListaDetalleVenta(numFactura);

                rptDetallesVentas.DataSource = listaVenta;
                rptDetallesVentas.DataBind();
            }
            catch (Exception ex)
            {
                // Manejo de errores
                lblError.Text = "Ocurrió un error al cargar los artículos: " + ex.Message;
                lblError.Visible = true;
            }
        }

        protected void volverHistorial_Click(object sender, EventArgs e)
        {
            Response.Redirect("VerCompras.aspx");
        }
    }
}