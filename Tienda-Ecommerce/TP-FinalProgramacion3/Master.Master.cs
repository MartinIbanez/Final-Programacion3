using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;

namespace TP_FinalProgramacion3
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void CerrarSesion_Click(object sender, EventArgs e)
        {
            // Eliminar todos los datos de la sesión
            Session.Clear();
            Session.Abandon();

            // Redirigir a la página de Login
            Response.Redirect("Login.aspx");
        }
    }
}