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
            // Validar campos obligatorios
            if (string.IsNullOrWhiteSpace(txtDNI.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                string.IsNullOrWhiteSpace(ddlProvincia.SelectedValue) ||
                string.IsNullOrWhiteSpace(txtCodigoPostal.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                // Mostrar un mensaje de error si algún campo está vacío
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Por favor, complete todos los campos.');", true);
                return;
            }

            // Simulación de registro exitoso (aquí podrías guardar los datos en la base de datos)
            // Ejemplo: Guardar en una base de datos o llamar a un servicio
            // Código para guardar en la base de datos aquí...

            // Redirigir al usuario o mostrar un mensaje de éxito
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Registro exitoso.');", true);

            // Limpiar campos después del registro
            txtDNI.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDireccion.Text = "";
            ddlProvincia.SelectedIndex = 0;
            txtCodigoPostal.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
        }
    }
}