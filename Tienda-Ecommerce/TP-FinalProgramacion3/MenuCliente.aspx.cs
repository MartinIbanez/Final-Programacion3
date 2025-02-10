using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_FinalProgramacion3
{
    public partial class MenuCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["cerrar"] != null)
            {
                Session.Remove("usuarioLogin");
                Response.Redirect("Login.aspx");
            }

        }


    }
}