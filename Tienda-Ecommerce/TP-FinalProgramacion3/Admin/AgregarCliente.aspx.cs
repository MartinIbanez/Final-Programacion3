using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_FinalProgramacion3.Admin
{
    public partial class AgregarCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!IsPostBack)
                {

                    if (Request.QueryString["dni"] != null)
                    {
                        string dniCliente = Request.QueryString["dni"];
                        ClienteNegocio clienteNegocio = new ClienteNegocio();
                        Cliente cliente = clienteNegocio.ClientesListado().FirstOrDefault(c => c.Dni == dniCliente);

                        if (cliente != null)
                        {
                            txtDNI.Text = cliente.Dni;
                            txtNombre.Text = cliente.Nombre;
                            txtApellido.Text = cliente.Apellido;
                            txtDireccion.Text = cliente.Direccion;
                            ddlProvincia.SelectedValue = cliente.Provincia;
                            txtCodigoPostal.Text = cliente.CodPostal;
                            txtEmail.Text = cliente.Email;
                            txtPassword.Text = cliente.Password;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.Message);
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminClientes.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                bool est = false;
                bool estado = false;
                if (ddlTipoCliente.SelectedValue == "1")
                {
                    est = true;
                }
                if (ddlEstado.SelectedValue=="1")
                {
                    estado = true;
                }
                ClienteNegocio clienteNegocio = new ClienteNegocio();
                Cliente cliente = new Cliente
                {
                    Dni = txtDNI.Text,
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Direccion = txtDireccion.Text,
                    Provincia = ddlProvincia.SelectedValue,
                    CodPostal = txtCodigoPostal.Text,
                    Email = txtEmail.Text,
                    Password = txtPassword.Text,
                    Estado= estado,
                    Tipo = est
                };
                bool nuevo = false;
                if (Request.QueryString["dni"] == null) // Nuevo 
                {
                    nuevo = clienteNegocio.NuevoCliente(cliente);
                }
                else // edito cliente
                {
                    cliente.Dni = Request.QueryString["dni"];
                    clienteNegocio.ModificarCliente(cliente);
                }

                Response.Redirect("AdminClientes.aspx");
            }
            catch (Exception ex)
            {
                lblError.Text = "Ocurrió un error al guardar el cliente: " + ex.Message;
                lblError.Visible = true;
            }
        }
    }
}