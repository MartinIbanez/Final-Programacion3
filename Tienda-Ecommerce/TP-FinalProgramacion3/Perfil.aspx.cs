using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_FinalProgramacion3
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {             
                if (Session["UsuarioLogin"] != null)
                {
                    Cliente usuario = (Cliente)Session["UsuarioLogin"];
                    lblDni.Text = usuario.Dni;
                    lblNombre.Text = usuario.Nombre;
                    lblApellido.Text = usuario.Apellido;
                    lblDireccion.Text = usuario.Direccion;
                    lblProvincia.Text = usuario.Provincia;
                    lblCodPostal.Text = usuario.CodPostal;
                    lblEmail.Text = usuario.Email;
                    lblPassword.Text ="******";

                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }
    }
}