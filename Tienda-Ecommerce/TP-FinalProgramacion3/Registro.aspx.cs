using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_FinalProgramacion3
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Aquí puedes procesar los datos del formulario
            string dni = txtDNI.Text;
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string direccion = txtDireccion.Text;
            string provincia = ddlProvincia.SelectedValue;
            string codigoPostal = txtCodigoPostal.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            // Aquí puedes agregar la lógica para guardar en la base de datos
            try
            {
                // Simulación de guardado (reemplazar con lógica real)
                bool isSaved = GuardarEnBaseDeDatos(dni, nombre, apellido, direccion, provincia, codigoPostal, email, password);
                if (isSaved)
                {
                    Session["Msg_ok"] = "Registro exitoso.";
                }
                else
                {
                    Session["Msg_error"] = "Ocurrió un error al registrar.";
                }
            }
            catch (Exception ex)
            {
                Session["Msg_error"] = "Error: " + ex.Message;
            }
            finally
            {
                Response.Redirect("Registro.aspx");
            }
        }

        private bool GuardarEnBaseDeDatos(string dni, string nombre, string apellido, string direccion, string provincia, string codigoPostal, string email, string password)
        {
            // Implementa aquí la lógica para conectar y guardar en la base de datos
            // Retorna true si se guarda correctamente, false si hay algún error
            return true;
        }
    }
}
    
