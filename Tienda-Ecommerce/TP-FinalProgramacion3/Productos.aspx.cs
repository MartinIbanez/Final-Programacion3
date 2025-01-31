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
        private ArticuloNegocio articuloNegocio = new ArticuloNegocio(); // Instanciar ArticuloNegocio

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
            // Crear instancias de las clases de negocio
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

            // Obtener las listas desde la base de datos
            List<Marca> listaMarcas = marcaNegocio.MarcasActivas();
            List<Categoria> listaCategorias = categoriaNegocio.CategoriasActivas();

            // Enlazar marcas al DropDownList
            ddlMarca.DataSource = listaMarcas;
            ddlMarca.DataTextField = "Descripcion"; // Nombre de la propiedad que se mostrará
            ddlMarca.DataValueField = "IdMarca";   // Valor que se usará como `SelectedValue`
            ddlMarca.DataBind();
            ddlMarca.Items.Insert(0, new ListItem("Seleccione una marca", ""));

            // Enlazar categorías al DropDownList
            ddlCategoria.DataSource = listaCategorias;
            ddlCategoria.DataTextField = "NombreCategoria"; // Nombre de la propiedad que se mostrará
            ddlCategoria.DataValueField = "IdCategoria";    // Valor que se usará como `SelectedValue`
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
                // Obtener los valores seleccionados en los filtros
                string marca = ddlMarca.SelectedValue;
                string categoria = ddlCategoria.SelectedValue;

                decimal precioMin = string.IsNullOrEmpty(txtPrecioMin.Text) ? 0 : Convert.ToDecimal(txtPrecioMin.Text);
                decimal precioMax = string.IsNullOrEmpty(txtPrecioMax.Text) ? decimal.MaxValue : Convert.ToDecimal(txtPrecioMax.Text);

                // Filtrar los productos con los valores seleccionados
                List<Articulo> productosFiltrados = FiltrarProductos(marca, categoria, precioMin, precioMax);

                // Enlazar la lista filtrada al Repeater
                rptProductos.DataSource = productosFiltrados;
                rptProductos.DataBind();
            }
            catch (Exception ex)
            {
                // Manejar errores y mostrar un mensaje si es necesario
                // Puedes agregar un Label o control para mostrar errores al usuario
                Console.WriteLine($"Error al filtrar productos: {ex.Message}");
            }
        }

        private List<Articulo> FiltrarProductos(string marca, string categoria, decimal precioMin, decimal precioMax)
        {
            // Obtener la lista completa de productos
            List<Articulo> todosLosProductos = CatalogoArticulos();

            // Filtrar los productos según los criterios seleccionados
            return todosLosProductos.FindAll(p =>
                (string.IsNullOrEmpty(marca) || p.IdMarca.ToString() == marca) &&
                (string.IsNullOrEmpty(categoria) || p.IdCategoria.ToString() == categoria) &&
                p.Precio >= precioMin &&
                p.Precio <= precioMax
            );
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
                    // Incrementar cantidad si ya existe
                    articuloExistente.Cantidad++;
                }
                else
                {
                    // Agregar nuevo artículo
                    Articulo nuevoArticulo = ObtenerArticuloPorId(idArticulo);
                    if (nuevoArticulo != null)
                    {
                        nuevoArticulo.Cantidad = 1;
                        carrito.Add(nuevoArticulo);
                    }
                }

                // Guardar el carrito actualizado en la sesión
                Session["Carrito"] = carrito;

                // Redirigir al carrito (opcional)
                Response.Redirect("~/Carrito.aspx");
            }
        }

        private Articulo ObtenerArticuloPorId(int idArticulo)
        {
            // Llamamos al método BuscarArticuloPorId de ArticuloNegocio
            return articuloNegocio.BuscarArticuloPorId(idArticulo);
        }
    }
}