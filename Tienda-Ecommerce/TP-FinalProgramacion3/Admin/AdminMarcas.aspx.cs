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
    public partial class AdminMarcas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarMarcas();
            }
        }

        private void CargarMarcas()
        {
            try
            {
                MarcaNegocio negocio = new MarcaNegocio();
                
                List<Marca> listaMarcas = negocio.ListarMarcas();

                if (listaMarcas != null && listaMarcas.Count > 0)
                {
                    rptMarcas.DataSource = listaMarcas;
                    rptMarcas.DataBind();
                }
                else
                {
                    lblError.Text = "No se encontraron marcas.";
                    lblError.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al cargar las marcas: " + ex.Message;
                lblError.Visible = true;
            }
        }
    }
}