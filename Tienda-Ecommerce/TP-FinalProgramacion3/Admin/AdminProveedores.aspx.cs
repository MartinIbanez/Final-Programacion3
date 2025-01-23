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
    public partial class AdminProveedores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProveedores();
            }
        }

        private void CargarProveedores()
        {
            ProveedorNegocio provNeg = new ProveedorNegocio();

            try
            {
                List<Proveedores> ListaProveedores = provNeg.ListarProveedores();

                rptProveedores.DataSource = ListaProveedores;
                rptProveedores.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al cargar los Proveedores: " + ex.Message;
                lblError.Visible = true;
            }
        }

        protected void rptProveedores_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                int idProveedor = int.Parse(e.CommandArgument.ToString());

                if (e.CommandName == "Editar")
                {
                    Response.Redirect("AgregarProveedor.aspx?IdProveedor=" + idProveedor);
                }
                else if (e.CommandName == "Eliminar")
                {
                    ProveedorNegocio proveedorNegocio = new ProveedorNegocio();
                    proveedorNegocio.EliminarProveedor(idProveedor);

                    CargarProveedores();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al ejecutar la acción: " + ex.Message;
                lblError.Visible = true;
            }
        }

        protected void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarProveedor.aspx");
        }
    }
}