using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security; 
using negocio;
using dominio;

namespace TP_FinalProgramacion3
{
    public partial class Login : System.Web.UI.Page
    {
        private const string Url = "Productos.aspx";

        protected void Page_Load(object sender, EventArgs e)
        {
            // Si el usuario ya está autenticado, lo redirigimos al inicio
            if (User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        public static class Validacion
        {
            
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
        }
    }
}