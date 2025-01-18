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
        private ArticuloNegocio negocio;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            negocio = new ArticuloNegocio(); // Instancia de ArticuloNegocio
            MarcaNegocio marcaNegocio=new MarcaNegocio();

            if (!IsPostBack)
            {
                CargarFiltros();
                CargarProductos();
                
            }
        }

        private void CargarProductos()
        {
            // Obtener productos desde la base de datos
            var productos = ObtenerProductosDesdeBaseDeDatos();

            // Enlazar productos al Repeater
            rptProductos.DataSource = productos;
            rptProductos.DataBind();
        }

        private void CargarFiltros()
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            // obtengo listado desde db
            List<Marca> listaMarcas=marcaNegocio.ListarMarcas();
            List<Categoria> listaCategorias=categoriaNegocio.ListarCategorias();

            // DropDownList con las marcas
            ddlMarca.DataSource = listaMarcas;
            ddlMarca.DataTextField = "Descripcion";
            ddlMarca.DataValueField = "IdMarca";
            ddlMarca.DataBind();
            ddlMarca.Items.Insert(0, new ListItem("Seleccione una marca"));

            // DropDownList con las categorias
            ddlCategoria.DataSource = listaCategorias;
            ddlCategoria.DataTextField = "NombreCategoria";
            ddlCategoria.DataValueField = "IdCategoria";
            ddlCategoria.DataBind();
            ddlCategoria.Items.Insert(0, new ListItem("Seleccione Categoria"));
        }

        private List<Articulo> ObtenerProductosDesdeBaseDeDatos()
        {
            // Llamar al método ListaArticulos de ArticuloNegocio
            return negocio.ListaArticulos();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            // Obtener valores de los filtros
            string marca = ddlMarca.SelectedValue;
            string categoria = ddlCategoria.SelectedValue;
            decimal precioMin = string.IsNullOrEmpty(txtPrecioMin.Text) ? 0 : Convert.ToDecimal(txtPrecioMin.Text);
            decimal precioMax = string.IsNullOrEmpty(txtPrecioMax.Text) ? decimal.MaxValue : Convert.ToDecimal(txtPrecioMax.Text);

            // Filtrar productos
            var productosFiltrados = FiltrarProductos(marca, categoria, precioMin, precioMax);

            // Enlazar productos filtrados al Repeater
            rptProductos.DataSource = productosFiltrados;
            rptProductos.DataBind();
        }

        private List<Articulo> FiltrarProductos(string marca, string categoria, decimal precioMin, decimal precioMax)
        {
            // Filtrar usando ListaArticulos
            var todosLosProductos = ObtenerProductosDesdeBaseDeDatos();

            return todosLosProductos.FindAll(p =>
                (string.IsNullOrEmpty(marca) || p.IdMarca.ToString() == marca) &&
                (string.IsNullOrEmpty(categoria) || p.IdCategoria.ToString() == categoria) &&
                p.Precio >= precioMin &&
                p.Precio <= precioMax);
        }
    }
}