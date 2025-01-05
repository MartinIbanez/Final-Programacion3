using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace TP_FinalProgramacion3
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Código que se ejecuta al cargar la página
            CargarArtDestacados();

        }

        protected void btnExample_Click(object sender, EventArgs e)
        {
            // Ejemplo de acción al hacer clic en el botón
            Response.Write("<script>alert('¡Botón clickeado!');</script>");
        }

        protected void CargarArtDestacados()
        {
            ArticuloNegocio obj = new ArticuloNegocio();
            List<Articulo> listDestacados=obj.ArticulosDestacados();

            if (listDestacados != null && listDestacados.Count > 0)
            {
                rptArt.DataSource = listDestacados;
                rptArt.DataBind();
            }
            else
            {
                Response.Write("No se encontraron artículos destacados.");
            }
        }
    }
}