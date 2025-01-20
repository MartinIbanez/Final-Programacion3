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
            txtIdCategoria.Enabled = false; // El ID es solo lectura

            try
            {
                if (!IsPostBack)
                {
                    if (Request.QueryString["IdCategoria"] != null)
                    {
                        int idCategoria = int.Parse(Request.QueryString["IdCategoria"]);
                        CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                        Categoria categoria = categoriaNegocio.ListarCategorias().FirstOrDefault(c => c.IdCategoria == idCategoria);

                        if (categoria != null)
                        {
                            txtIdCategoria.Text = categoria.IdCategoria.ToString();
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
                Categoria categoria = new Categoria
                {
                    NombreCategoria = txtNombreCategoria.Text,
                    Estado = bool.Parse(ddlEstado.SelectedValue)
                };

                if (string.IsNullOrEmpty(txtIdCategoria.Text)) // Si el ID está vacío, es una nueva categoría
                {
                    categoriaNeg.NuevaCategoria(categoria);
                }
                else // Si el ID tiene valor, se edita la categoría existente
                {
                    categoria.IdCategoria = int.Parse(txtIdCategoria.Text);
                    categoriaNeg.ModificarCategoria(categoria);
                }

                Response.Redirect("AdminCategorias.aspx"); // Redirige a la lista de categorías
            }
            catch (Exception ex)
            {
                lblError.Text = "Ocurrió un error al guardar la categoría: " + ex.Message;
                lblError.Visible = true;
            }
        }
    }
}