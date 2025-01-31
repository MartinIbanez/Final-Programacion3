using dominio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_FinalProgramacion3
{
    public partial class Carrito : System.Web.UI.Page
    {
        public List<Articulo> articulos { get; set; }
        public CultureInfo pesos = new CultureInfo("es-AR");
        public int cantidadArticulos = 0;
        private decimal ivaPorcentaje = 0.21m;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
                CargarCarrito();
            }
        }

        private void CargarCarrito()
        {
            List<Articulo> carrito = Session["Carrito"] as List<Articulo>;

            if (carrito != null && carrito.Count > 0)
            {
                // Calcular el subtotal, IVA y total
                decimal subtotal = 0;
                foreach (var articulo in carrito)
                {
                    subtotal += articulo.Precio * articulo.Cantidad;
                }

                decimal iva = subtotal * ivaPorcentaje; // 21% de IVA
                decimal total = subtotal + iva;

                // Asignar los valores a los labels
                lblSubtotal.Text = $"${subtotal:F2}";
                lblIva.Text = $"${iva:F2}";
                lblTotal.Text = $"${total:F2}";

                // Asignar los datos al Repeater
                rptCarrito.DataSource = carrito;
                rptCarrito.DataBind();
            }
            else
            {
                lblError.Text = "Tu carrito de compras está vacío.";
                lblError.Visible = true;
            }
        }

        protected void rptCarrito_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                int idArticulo = Convert.ToInt32(e.CommandArgument);
                List<Articulo> carrito = Session["Carrito"] as List<Articulo>;

                if (carrito != null)
                {
                    // Eliminar el artículo del carrito
                    carrito.RemoveAll(a => a.IdArticulo == idArticulo);

                    // Guardar el carrito actualizado en la sesión
                    Session["Carrito"] = carrito;

                    // Recargar la página para actualizar el carrito
                    Response.Redirect("Carrito.aspx");
                }
            }
            else if (e.CommandName == "Incrementar")
            {
                int idArticulo = Convert.ToInt32(e.CommandArgument);
                List<Articulo> carrito = Session["Carrito"] as List<Articulo>;
               

                if (carrito != null)
                {
                    // Incrementar la cantidad del artículo
                    Articulo articulo = carrito.Find(a => a.IdArticulo == idArticulo);
                    
                    if (articulo != null)
                    {
                        articulo.Cantidad++;
                    }

                    // Guardar el carrito actualizado en la sesión
                    Session["Carrito"] = carrito;

                    // Recargar la página para actualizar el carrito
                    Response.Redirect("Carrito.aspx");
                }
            }
            else if (e.CommandName == "Decrementar")
            {
                int idArticulo = Convert.ToInt32(e.CommandArgument);
                List<Articulo> carrito = Session["Carrito"] as List<Articulo>;

                if (carrito != null)
                {
                    // Decrementar la cantidad del artículo
                    Articulo articulo = carrito.Find(a => a.IdArticulo == idArticulo);
                    if (articulo != null && articulo.Cantidad > 1)
                    {
                        articulo.Cantidad--;
                    }

                    // Guardar el carrito actualizado en la sesión
                    Session["Carrito"] = carrito;

                    // Recargar la página para actualizar el carrito
                    Response.Redirect("Carrito.aspx");
                }
            }
        }
    }
}