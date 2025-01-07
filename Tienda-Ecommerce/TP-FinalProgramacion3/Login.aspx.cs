using System;
using System.Collections.Generic;
using System.Linq;
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
            public static bool validaTextoVacio(object control)
            {
                if (control is TextBox texto)
                {
                    if (string.IsNullOrEmpty(texto.Text))
                        return true;
                    else
                        return false;
                }
                return false;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Recuperamos el correo y la contraseña ingresados por el usuario
            string email = UserEmail.Text;
            string password = Password.Text;

            ClienteNegocio negocio = new ClienteNegocio();
            Cliente cliente = new Cliente();

            try
            {
                // Verificamos que ambos campos estén completos
                if (Validacion.validaTextoVacio(UserEmail) || Validacion.validaTextoVacio(Password))
                {
                    // Si algún campo está vacío, mostramos un mensaje de error
                    Session.Add("error", "Debes completar ambos campos...");
                    Response.Redirect("Error.aspx");
                }

                // Asignamos los valores ingresados por el usuario a las propiedades del cliente
                cliente.Email = email;
                cliente.Password = password;

                // Verificamos si las credenciales del cliente son correctas
                Cliente clienteAutenticado = negocio.Login(cliente.Email, cliente.Password);

                if (clienteAutenticado != null)
                {
                    // Si la autenticación es exitosa, guardamos al cliente en la sesión
                    Session.Add("cliente", clienteAutenticado);

                    // Redirigimos al usuario dependiendo de su tipo
                    if (clienteAutenticado.Tipo) // Si es un administrador
                    {
                        Response.Redirect("~/Admin/Dashboard.aspx", false); // Página de administrador
                    }
                    else // Si es un cliente normal
                    {
                        Response.Redirect("~/Default.aspx", false); // Página principal del cliente
                    }
                }
                else
                {
                    // Si las credenciales son incorrectas, mostramos un mensaje de error
                    Session.Add("error", "Usuario o contraseña incorrectos.");
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (System.Threading.ThreadAbortException ex)
            {
                // Excepción que ocurre al hacer redirecciones, se ignora
            }
            catch (Exception ex)
            {
                // En caso de error inesperado, lo registramos y redirigimos a la página de error
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}