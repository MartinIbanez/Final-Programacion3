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
                // Obtenemos la lista de categorías
                List<Categoria> listaCategorias = categoriaNegocio.ListarCategorias();

                // Enlazamos la lista al control repeater
                rptCategorias.DataSource = listaCategorias;
                rptCategorias.DataBind();
            }
            catch (Exception ex)
            {
                // Manejo de errores
                lblError.Text = "Ocurrió un error al cargar las categorías: " + ex.Message;
                lblError.Visible = true;
            }
        }

        protected void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarCategoria.aspx");
        }
    }
}