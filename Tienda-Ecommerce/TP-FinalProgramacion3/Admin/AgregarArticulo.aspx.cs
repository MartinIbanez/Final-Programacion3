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
    public partial class AgregarArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false; // El ID es solo lectura
            CargarCategorias();
            CargarMarcas();
            

            try
            {
                if (!IsPostBack)
                {
                    CargarCategorias();
                    
                    if (Request.QueryString["IdArticulo"] != null)
                    {
                        int idArticulo = int.Parse(Request.QueryString["IdArticulo"]);
                        ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                        Articulo artAux = articuloNegocio.ListaArticulos().FirstOrDefault(a => a.IdArticulo == idArticulo);

                        if (artAux != null)
                        {
                            txtId.Text = artAux.IdArticulo.ToString();
                            txtNombre.Text = artAux.Nombre; 
                            txtDescripcion.Text = artAux.Descripcion;
                            ddlCategoria.SelectedValue = artAux.IdCategoria.ToString(); 
                            ddlProveedor.SelectedValue = artAux.IdProveedor.ToString(); 
                            txtStock.Text = artAux.Stock.ToString();
                            txtStockMinimo.Text = artAux.StockMinimo.ToString();
                            txtUrlImagen.Text = artAux.UrlImagen; 
                            txtPrecio.Text = artAux.Precio.ToString("F2"); 
                            ddlEstado.SelectedValue = artAux.Estado ? "True" : "False"; 
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
            Response.Redirect("AdminArticulos.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                Articulo articulo = new Articulo
                {
                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    IdCategoria = int.Parse(ddlCategoria.SelectedValue),
                    IdProveedor = int.Parse(ddlProveedor.SelectedValue),
                    Stock = int.Parse(txtStock.Text),
                    StockMinimo = int.Parse(txtStockMinimo.Text),
                    UrlImagen = txtUrlImagen.Text,
                    Precio = decimal.Parse(txtPrecio.Text),
                    Estado = bool.Parse(ddlEstado.SelectedValue)
                };

                if (string.IsNullOrEmpty(txtId.Text)) // Si el ID está vacío, es un nuevo artículo
                {
                    articuloNegocio.NuevoArticulo(articulo);
                }
                else // Si el ID tiene valor, se edita el artículo existente
                {
                    articulo.IdArticulo = int.Parse(txtId.Text);
                    articuloNegocio.ModificarArticulo(articulo);
                }

                Response.Redirect("AdminArticulos.aspx"); // Redirige a la lista de artículos
            }
            catch (Exception ex)
            {
                lblError.Text = "Ocurrió un error al guardar el artículo: " + ex.Message;
                lblError.Visible = true;
            }
        }

        
        private void CargarCategorias()
        {
            try
            {
                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                List<Categoria> categorias = categoriaNegocio.CategoriasActivas();

                ddlCategoria.DataSource = categorias;
                ddlCategoria.DataTextField = "NombreCategoria";
                ddlCategoria.DataValueField = "IdCategoria";
                ddlCategoria.DataBind();

                ddlCategoria.Items.Insert(0, new ListItem("Seleccione una categoría", ""));
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al cargar las categorías: " + ex.Message;
                lblError.Visible = true;
            }
        }

        private void CargarMarcas()
        {
            try
            {
                MarcaNegocio marcaNegocio = new MarcaNegocio();
                List<Marca> marcas = marcaNegocio.MarcasActivas();

                ddlMarca.DataSource = marcas;
                ddlMarca.DataTextField = "Descripcion";
                ddlMarca.DataValueField = "IdMarca";
                ddlMarca.DataBind();

                ddlMarca.Items.Insert(0, new ListItem("Seleccione una marca", ""));
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al cargar las marcas: " + ex.Message;
                lblError.Visible = true;
            }
        }

        
    }
}