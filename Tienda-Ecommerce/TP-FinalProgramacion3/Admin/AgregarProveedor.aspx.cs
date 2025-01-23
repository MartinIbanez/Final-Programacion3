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
    public partial class AgregarProveedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtIdProveedor.Enabled = false; 

            try
            {
                if (!IsPostBack)
                {
                    if (Request.QueryString["IdProveedor"] != null)
                    {
                        int idProveedor = int.Parse(Request.QueryString["IdProveedor"]);
                        ProveedorNegocio proveedorNegocio = new ProveedorNegocio();
                        Proveedores proveedor = proveedorNegocio.ListarProveedores().FirstOrDefault(p => p.IdProveedor == idProveedor);

                        if (proveedor != null)
                        {
                            txtIdProveedor.Text = proveedor.IdProveedor.ToString();
                            txtCuit.Text = proveedor.Cuit;
                            txtNombre.Text = proveedor.Nombre;
                            txtNombreContacto.Text = proveedor.NombreContacto;
                            txtCargoContacto.Text = proveedor.CargoContacto;
                            txtDireccion.Text = proveedor.Direccion;
                            txtCiudad.Text = proveedor.Ciudad;
                            txtCodigoPostal.Text = proveedor.CodPostal;
                            txtTelefono.Text = proveedor.Telefono;
                            ddlEstado.SelectedValue = proveedor.Estado.ToString();
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
            Response.Redirect("AdminProveedores.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                ProveedorNegocio proveedorNeg = new ProveedorNegocio();
                Proveedores proveedor = new Proveedores
                {
                    Cuit = txtCuit.Text,
                    Nombre = txtNombre.Text,
                    NombreContacto = txtNombreContacto.Text,
                    CargoContacto = txtCargoContacto.Text,
                    Direccion = txtDireccion.Text,
                    Ciudad = txtCiudad.Text,
                    CodPostal = txtCodigoPostal.Text,
                    Telefono = txtTelefono.Text,
                    Estado = bool.Parse(ddlEstado.SelectedValue)
                };

                if (string.IsNullOrEmpty(txtIdProveedor.Text)) 
                {
                    proveedorNeg.NuevoProveedor(proveedor);
                }
                else // Editar proveedor existente
                {
                    proveedor.IdProveedor = int.Parse(txtIdProveedor.Text);
                    proveedorNeg.ModificarProveedor(proveedor);
                }

                Response.Redirect("AdminProveedores.aspx"); 
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al guardar el proveedor: " + ex.Message;
                lblError.Visible = true;
            }
        }
    }
}