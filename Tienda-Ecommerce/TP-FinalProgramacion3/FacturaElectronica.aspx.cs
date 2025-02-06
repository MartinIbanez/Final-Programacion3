using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_FinalProgramacion3
{
    public partial class FacturaElectronica : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MensajeCompra"] != null) //muestro mensaje de compra exitosa, que guardamos al confirmar compra
            {
                string mensajeCompra = Session["MensajeCompra"].ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + mensajeCompra + "');", true);
                Session.Remove("MensajeCompra");
            }

            if (!IsPostBack)
            {
                CargarFactura();
            }
        }

        private void CargarFactura()
        {
            List<Articulo> carrito = Session["Carrito"] as List<Articulo>;

            if (carrito != null && carrito.Count > 0)
            {
                decimal totalFactura = 0;

                // Crear lista con detalles de los artículos para el Repeater
                var detallesFactura = new List<dynamic>();

                foreach (var articulo in carrito)
                {
                    decimal totalArticulo = articulo.Precio * articulo.Cantidad;
                    totalFactura += totalArticulo;

                    detallesFactura.Add(new
                    {
                        articulo.IdArticulo,
                        articulo.Descripcion,
                        articulo.Cantidad,
                        Precio = articulo.Precio,
                        Total = totalArticulo
                    });
                }

                rptFactura.DataSource = detallesFactura;
                rptFactura.DataBind();

                lblTotalFactura.Text = $" $ {totalFactura: F2} "; //total de la venta $
            }
        }
    }
}