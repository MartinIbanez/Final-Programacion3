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
            // Verificar si el mensaje está almacenado en la sesión y mostrarlo
            if (Session["MensajeCompra"] != null)
            {
                string mensajeCompra = Session["MensajeCompra"].ToString();

                // Usar JavaScript para mostrar la alerta en la página
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + mensajeCompra + "');", true);

                // Limpiar el mensaje de la sesión para que no se repita
                Session.Remove("MensajeCompra");
            }

           
        }
    }
}