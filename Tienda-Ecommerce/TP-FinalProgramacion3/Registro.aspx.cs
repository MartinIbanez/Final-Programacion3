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
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Aquí puedes manejar eventos de carga de la página si es necesario.
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente user = new Cliente();
                ClienteNegocio clienteAlta = new ClienteNegocio();

                user.Dni= txtDNI.Text;
                user.Nombre = txtNombre.Text;
                user.Apellido = txtApellido.Text;
                user.Direccion = txtDireccion.Text;
                user.Provincia=ddlProvincia.Text;
                user.CodPostal=txtCodigoPostal.Text;
                user.Email = txtEmail.Text;
                user.Password = txtPassword.Text;

                char idDni=clienteAlta.NuevoCliente (user);


            }
            catch (Exception ex) 
            {
                Session.Add("error",ex.ToString());
            }

        }
    }
}