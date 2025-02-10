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
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCarrito();
            }

            if (Request.QueryString["accion"] != null)
            {
                string accion = Request.QueryString["accion"];

                int idArticulo = Convert.ToInt32(Request.QueryString["id"]);
                List<Articulo> carrito = Session["Carrito"] as List<Articulo>;


                if (carrito != null)
                {
                    List<Articulo> ListAux = new List<Articulo>();
                    if (accion == "incrementar")
                    {

                        foreach (Articulo aux in carrito)
                        {
                            if (aux.IdArticulo == idArticulo)
                            {
                                aux.Cantidad++;
                            }
                            ListAux.Add(aux);
                        }

                    }
                    else if (accion == "decrementar")
                    {
                        foreach (Articulo aux in carrito)
                        {
                            if (aux.IdArticulo == idArticulo)
                            {
                                if (aux.Cantidad > 1)
                                {
                                    aux.Cantidad--;
                                }

                            }
                            ListAux.Add(aux);
                        }

                    }
                    else if (accion == "eliminar")
                    {
                        foreach (Articulo aux in carrito)
                        {
                            if (aux.IdArticulo != idArticulo)
                            {
                                ListAux.Add(aux);
                            }

                        }                      

                    }
                    Session["Carrito"] = ListAux;

                    Response.Redirect("Carrito.aspx");

                }
            }
        }

        private void CargarCarrito()
        {
            List<Articulo> carrito = Session["Carrito"] as List<Articulo>;

            if (carrito != null && carrito.Count > 0)
            {
                decimal total = 0;
                foreach (var articulo in carrito)
                {
                    total += articulo.Precio * articulo.Cantidad;
                }
               
                lblTotal.Text = total.ToString("C2", new CultureInfo("es-AR"));

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

        }
    }
}