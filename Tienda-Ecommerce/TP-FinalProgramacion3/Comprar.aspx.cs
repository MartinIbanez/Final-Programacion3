using dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_FinalProgramacion3
{
    public partial class Comprar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCarrito();
                CargarCliente();
            }
        }

        private void CargarCarrito()
        {
            List<Articulo> carrito = Session["Carrito"] as List<Articulo>;
            if (carrito != null && carrito.Count > 0)
            {
                DataTable dtCarrito = new DataTable();
                dtCarrito.Columns.Add("Descripcion");
                dtCarrito.Columns.Add("Cantidad");
                dtCarrito.Columns.Add("Precio", typeof(decimal));
                dtCarrito.Columns.Add("Total", typeof(decimal));


                foreach (var articulo in carrito)
                {
                    decimal total = articulo.Precio * articulo.Cantidad;
                    dtCarrito.Rows.Add(articulo.Descripcion, articulo.Cantidad, articulo.Precio, total);
                }

                gvCarrito.DataSource = dtCarrito;
                gvCarrito.DataBind();
            }
            else
            {
                Response.Write("<script>alert('No hay productos en el carrito');</script>");
                Response.Redirect("Productos.aspx");
            }

        }

        private void CargarCliente()
        {
        
            Cliente usuarioLogin = Session["usuarioLogin"] as Cliente;

            if (usuarioLogin != null)
            {
                txtNombre.Text = usuarioLogin.Nombre;
                txtApellido.Text = usuarioLogin.Apellido;
                txtDireccion.Text = usuarioLogin.Direccion;
                txtProvincia.Text = usuarioLogin.Provincia;
                txtCodigoPostal.Text = usuarioLogin.CodPostal;
            }
            else
            {
                Response.Write("<script>alert('Debe iniciar sesión para continuar con la compra.');</script>");
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnConfirmarCompra_Click(object sender, EventArgs e)
        {
            Session["MensajeCompra"] = "COMPRA REALIZADA CON EXITO. MUCHAS GRACIAS";
            Response.Redirect("FacturaElectronica.aspx");
        }
    }
}