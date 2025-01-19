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
    public partial class AgregarMarca : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtIdMarca.Enabled = false; // El ID es de solo lectura
            try
            {
                if (!IsPostBack)
                {
                    // Verificar si se está editando una marca existente
                    if (Request.QueryString["IdMarca"] != null)
                    {
                        int idMarca = int.Parse(Request.QueryString["IdMarca"]);
                        MarcaNegocio marcaNegocio = new MarcaNegocio();
                        Marca marca = marcaNegocio.ListarMarcas().FirstOrDefault(m => m.IdMarca == idMarca);

                        if (marca != null)
                        {
                            // Rellenar los campos con los datos de la marca
                            txtIdMarca.Text = marca.IdMarca.ToString();
                            txtDescripcion.Text = marca.Descripcion;
                            ddlEstado.SelectedValue = marca.Estado.ToString();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                // Manejar errores y redirigir a una página de error
                Session.Add("Error", ex.Message);
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            // Redirigir al listado de marcas.
            Response.Redirect("AdminMarcas.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                MarcaNegocio marcaNegocio = new MarcaNegocio();
                Marca nuevaMarca = new Marca
                {
                    Descripcion = txtDescripcion.Text,
                    Estado = bool.Parse(ddlEstado.SelectedValue)
                };

                if (string.IsNullOrEmpty(txtIdMarca.Text))
                {
                    // Lógica para agregar una nueva marca
                    // Aquí necesitarías un método para insertar en tu clase MarcaNegocio
                    marcaNegocio.AgregarMarca(nuevaMarca);
                }
                else
                {
                    // Lógica para actualizar una marca existente
                    nuevaMarca.IdMarca = int.Parse(txtIdMarca.Text);
                    marcaNegocio.ModificarMarca(nuevaMarca);
                }

                // Redirigir al listado de marcas después de guardar
                Response.Redirect("AdminMarcas.aspx");
            }
            catch (Exception ex)
            {
                lblError.Text = "Ocurrió un error al guardar la marca: " + ex.Message;
                lblError.Visible = true;
            }
        }

    }
}