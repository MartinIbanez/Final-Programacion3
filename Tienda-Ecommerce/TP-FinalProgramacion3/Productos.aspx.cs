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
            // Simulación de datos para los filtros (puedes cargarlos desde la base de datos si es necesario)
            ddlMarca.DataSource = new List<string> { "Marca 1", "Marca 2", "Marca 3" };
            ddlMarca.DataBind();

            ddlCategoria.DataSource = new List<string> { "Categoría 1", "Categoría 2", "Categoría 3" };
            ddlCategoria.DataBind();
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