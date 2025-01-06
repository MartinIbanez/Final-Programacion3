using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security; // Para FormsAuthentication
using negocio;
using dominio;

namespace TP_FinalProgramacion3
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Si el usuario ya está autenticado, lo redirigimos al inicio
            if (User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = UserEmail.Text;
            string password = Password.Text;

            // Llamamos al método Login de ClienteNegocio
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            Cliente cliente = ClienteNegocio.Login(email,password); // Verificamos las credenciales

            if (cliente != null)
            {
                // Si el cliente fue autenticado correctamente, guardamos la información del cliente en la sesión
                Session["Cliente"] = cliente; // Guardamos el objeto cliente en la sesión

                // Autenticamos al usuario con FormsAuthentication
                FormsAuthentication.SetAuthCookie(cliente.Email, false);

                // Redirigimos según el tipo de usuario
                if (cliente.Tipo) // Si es admin
                {
                    Response.Redirect("~/Admin/Dashboard.aspx");
                }
                else // Si es un cliente normal
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
            else
            {
                // Si la autenticación falla, mostramos un mensaje de error
                Session["Msg_error"] = "Credenciales incorrectas. Por favor, intente de nuevo.";
                Response.Redirect(Request.RawUrl); // Recarga la página para mostrar el error
            }
        }
    }
}