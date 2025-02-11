using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace TP_FinalProgramacion3
{
    public partial class Productos : System.Web.UI.Page
    {
        private ArticuloNegocio articuloNegocio = new ArticuloNegocio(); 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarFiltros();
                CargarProductos();
            }
        }

        private void CargarProductos()
        {
            List<Articulo> productos = CatalogoArticulos();
            rptProductos.DataSource = productos;
            rptProductos.DataBind();
        }

        private void CargarFiltros()
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

            List<Marca> listaMarcas = marcaNegocio.MarcasActivas();
            List<Categoria> listaCategorias = categoriaNegocio.CategoriasActivas();

            // Marcas
            ddlMarca.DataSource = listaMarcas;
            ddlMarca.DataTextField = "Descripcion"; 
            ddlMarca.DataValueField = "IdMarca";   
            ddlMarca.DataBind();
            ddlMarca.Items.Insert(0, new ListItem("Seleccione una marca", ""));

            // Categorías
            ddlCategoria.DataSource = listaCategorias;
            ddlCategoria.DataTextField = "NombreCategoria"; 
            ddlCategoria.DataValueField = "IdCategoria";   
            ddlCategoria.DataBind();
            ddlCategoria.Items.Insert(0, new ListItem("Seleccione una categoría", ""));
        }

        private List<Articulo> CatalogoArticulos()
        {
            return articuloNegocio.ListaArticulos();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {             
                string marca = ddlMarca.SelectedValue;
                string categoria = ddlCategoria.SelectedValue;

                decimal precioMin = string.IsNullOrEmpty(txtPrecioMin.Text) ? 0 : Convert.ToDecimal(txtPrecioMin.Text);
                decimal precioMax = string.IsNullOrEmpty(txtPrecioMax.Text) ? decimal.MaxValue : Convert.ToDecimal(txtPrecioMax.Text);

                
                List<Articulo> productosFiltrados = articuloNegocio.FiltrarProductos(marca, categoria, precioMin, precioMax);

                rptProductos.DataSource = productosFiltrados;
                rptProductos.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al filtrar productos: {ex.Message}");
            }
        }

        protected void ComprarProducto(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            if (e.CommandName == "AgregarCarrito")
            {
                int idArticulo = int.Parse(e.CommandArgument.ToString());

                // Obtener la lista del carrito de la sesión
                List<Articulo> carrito = Session["Carrito"] as List<Articulo> ?? new List<Articulo>();

                // Buscar si ya existe el artículo en el carrito
                Articulo articuloExistente = carrito.FirstOrDefault(a => a.IdArticulo == idArticulo);
                
                if (articuloExistente != null)
                {
                    articuloExistente.Cantidad++;
                }
                else
                {
                    Articulo nuevoArticulo = ObtenerArticuloPorId(idArticulo);
                    if (nuevoArticulo != null)
                    {
                        nuevoArticulo.Cantidad = 1;
                        carrito.Add(nuevoArticulo);
                    }
                }

                // Guardar el carrito actualizado en la sesión
                Session["Carrito"] = carrito;

                Response.Redirect("~/Carrito.aspx");
            }
        }
        protected void btnBorrarFiltros_Click(object sender, EventArgs e)
        {
            ddlMarca.SelectedIndex = -1;
            ddlCategoria.SelectedIndex = -1;
            txtPrecioMin.Text = string.Empty;
            txtPrecioMax.Text = string.Empty;
            CargarProductos();
        }

        private Articulo ObtenerArticuloPorId(int idArticulo)
        {
            return articuloNegocio.BuscarArticuloPorId(idArticulo);
        }
    }
}