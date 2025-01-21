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
    public partial class Productos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarArticulos();
            }
        }

        private void CargarArticulos()
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            try
            {
                // Obtenemos la lista de artículos
                List<Articulo> listaArticulos = articuloNegocio.ListaArticulos();

                // Enlazamos la lista al control repeater
                rptArticulos.DataSource = listaArticulos;
                rptArticulos.DataBind();
            }
            catch (Exception ex)
            {
                // Manejo de errores
                lblError.Text = "Ocurrió un error al cargar los artículos: " + ex.Message;
                lblError.Visible = true;
            }
        }

        protected void rptArticulos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                int idArticulo = int.Parse(e.CommandArgument.ToString()); // Obtiene el ID de la marca

                if (e.CommandName == "Editar")
                {
                    Response.Redirect("AgregarArticulo.aspx?IdArticulo=" + idArticulo);
                }
                else if (e.CommandName == "Eliminar")
                {
                    ArticuloNegocio artNegocio= new ArticuloNegocio();
                    artNegocio.EliminarArticulo(idArticulo);

                    CargarArticulos();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al ejecutar la acción: " + ex.Message;
                lblError.Visible = true;
            }
        }

        protected void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarArticulo.aspx");
        }
    }
}