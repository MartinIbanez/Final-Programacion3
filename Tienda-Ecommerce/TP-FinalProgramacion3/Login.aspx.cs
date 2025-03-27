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
            if (Session["UsuarioLogin"]!=null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }
     
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            ClienteNegocio cliNego = new ClienteNegocio();

            string mail= UserEmail.Text;
            string pass= Password.Text;

            int Login= cliNego.verifarLogin(mail, pass);
            
            if (Login == -1)
            {
                MensajeLogin.Text = "Email o contraseña incorrecto. Vuelva a intentarlo";
                UserEmail.Text = "";
                Password.Text = "";
            }
            else
            {
                Cliente usuarioLogin = cliNego.buscarClienteEmail(mail, pass);
                Session["usuarioLogin"]= usuarioLogin;
                 if (Login == 0)
                {
                    Response.Redirect("~/MenuCliente.aspx");
                }
                else
                {
                    Response.Redirect("~/MenuAdmin.aspx");
                }
            }

          
        }
    }
}