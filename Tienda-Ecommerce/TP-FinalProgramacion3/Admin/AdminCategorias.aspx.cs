using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_FinalProgramacion3.Admin
{
    public partial class Categorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCategorias();
            }
        }

        private void CargarCategorias()
        {
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

            try
            {
                List<Categoria> listaCategorias = categoriaNegocio.ListarCategorias();

                rptCategorias.DataSource = listaCategorias;
                rptCategorias.DataBind();
            }
            catch (Exception ex)
            {             
                lblError.Text = "Error al cargar las categorías: " + ex.Message;
                lblError.Visible = true;
            }
        }
        protected void rptCategorias_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                int idCategoria = int.Parse(e.CommandArgument.ToString()); // Obtiene el ID de la marca

                if (e.CommandName == "Editar")
                {
                    Response.Redirect("AgregarCategoria.aspx?IdCategoria=" + idCategoria);
                }
                else if (e.CommandName == "Eliminar")
                {
                    CategoriaNegocio catNegocio= new CategoriaNegocio();
                    
                    catNegocio.EliminarCategoria(idCategoria);


                    CargarCategorias(); 
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al ejecutar la acción: " + ex.Message;
                lblError.Visible = true;
            }
        }

        protected void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarCategoria.aspx");
        }
    }
}