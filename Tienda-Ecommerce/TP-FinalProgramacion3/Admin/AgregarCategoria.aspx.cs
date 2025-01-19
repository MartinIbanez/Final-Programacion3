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
    public partial class AgregarCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtIdCategoria.Enabled = false; // El ID es de solo lectura
            try
            {
                if (!IsPostBack)
                {
                    // Verifico si se está editando una marca
                    if (Request.QueryString["IdCategoria"] != null)
                    {
                        int idCategoria = int.Parse(Request.QueryString["IdCategoria"]);
                        CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                        Categoria categoria = categoriaNegocio.ListarCategorias().FirstOrDefault(c => c.IdCategoria == idCategoria);

                        if (categoria != null)
                        {
                            txtIdCategoria.Text = categoria.IdCategoria.ToString(); //Completo con los datos de la marca
                            txtNombreCategoria.Text = categoria.NombreCategoria;
                            ddlEstado.SelectedValue = categoria.Estado.ToString();
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
            Response.Redirect("AdminCategorias.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                CategoriaNegocio categoriaNeg = new CategoriaNegocio();
                Categoria alta = new Categoria
                {
                    NombreCategoria = txtNombreCategoria.Text,
                    Estado = bool.Parse(ddlEstado.SelectedValue)
                };

                // Si no hay un ID, agrego una nueva categoría
                if (string.IsNullOrEmpty(txtIdCategoria.Text))
                {
                    categoriaNeg.NuevaCategoria(alta);
                }
                else
                {
                    // Si hay un ID, actualizamos la categoría existente
                    alta.IdCategoria = int.Parse(txtIdCategoria.Text);
                    //categoriaNeg.ModificarCategoria(alta);
                }

                Response.Redirect("AdminCategorias.aspx");
            }
            catch (Exception ex)
            {
                lblError.Text = "Ocurrió un error al guardar la categoría: " + ex.Message;
                lblError.Visible = true;
            }
        }

    }
}