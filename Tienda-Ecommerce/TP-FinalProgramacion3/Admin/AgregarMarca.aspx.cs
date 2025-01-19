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
                    // Verifico si se está editando una marca
                    if (Request.QueryString["IdMarca"] != null)
                    {
                        int idMarca = int.Parse(Request.QueryString["IdMarca"]);
                        MarcaNegocio marcaNegocio = new MarcaNegocio();
                        Marca marca = marcaNegocio.ListarMarcas().FirstOrDefault(m => m.IdMarca == idMarca);

                        if (marca != null)
                        {
                            txtIdMarca.Text = marca.IdMarca.ToString(); //Completo con los datos de la marca
                            txtDescripcion.Text = marca.Descripcion;
                            ddlEstado.SelectedValue = marca.Estado.ToString();
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
                    // Para actualizar marca existente
                    nuevaMarca.IdMarca = int.Parse(txtIdMarca.Text);
                    marcaNegocio.ModificarMarca(nuevaMarca);
                }

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