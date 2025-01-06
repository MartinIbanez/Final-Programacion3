<%@ Page Title="Productos" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <form id="formProductos" runat="server">
    <section class="flex items-start justify-center min-h-screen bg-gray-100">
      <div class="container mx-auto flex space-x-6 py-8">
        
        <!-- Filtros (Columna izquierda) -->
        <div class="w-1/4 bg-white p-6 rounded-lg shadow-lg">
          <h3 class="text-xl font-bold text-blue-800 mb-4">Filtros</h3>

          <!-- Filtro por Marca -->
          <div class="mb-4">
            <label for="ddlMarca" class="block text-sm font-medium text-slate-600">Marca</label>
            <select id="ddlMarca" class="w-full mt-1 px-4 py-2 bg-slate-200 border border-slate-300 rounded-md text-slate-700">
              <option value="">Seleccione una marca</option>
              <option value="Marca 1">Marca 1</option>
              <option value="Marca 2">Marca 2</option>
              <option value="Marca 3">Marca 3</option>
            </select>
          </div>

          <!-- Filtro por Categoría -->
          <div class="mb-4">
            <label for="ddlCategoria" class="block text-sm font-medium text-slate-600">Categoría</label>
            <select id="ddlCategoria" class="w-full mt-1 px-4 py-2 bg-slate-200 border border-slate-300 rounded-md text-slate-700">
              <option value="">Seleccione una categoría</option>
              <option value="Categoria 1">Categoría 1</option>
              <option value="Categoria 2">Categoría 2</option>
              <option value="Categoria 3">Categoría 3</option>
            </select>
          </div>

          <!-- Filtro por Rango de Precios -->
          <div class="mb-4">
            <label for="txtPrecioMin" class="block text-sm font-medium text-slate-600">Rango de Precios</label>
            <div class="flex space-x-2">
              <input type="number" id="txtPrecioMin" placeholder="Min" class="w-1/2 px-4 py-2 bg-slate-200 border border-slate-300 rounded-md text-slate-700" />
              <input type="number" id="txtPrecioMax" placeholder="Max" class="w-1/2 px-4 py-2 bg-slate-200 border border-slate-300 rounded-md text-slate-700" />
            </div>
          </div>

          <!-- Botón de Reset -->
          <div>
            <button type="button" id="btnReset" class="w-full py-2 bg-gray-500 hover:bg-gray-600 text-white font-medium rounded-md transition">
              Resetear filtros
            </button>
          </div>
        </div>

        <!-- Productos (Columna derecha) -->
        <div class="w-3/4">
          <h2 class="text-3xl font-bold text-blue-800 mb-6">Productos</h2>
          
          <!-- Contenedor de productos -->
          <div id="productos" class="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-6">
            <!-- Aquí se generarán las tarjetas con productos -->
          </div>
        </div>
      </div>
    </section>
  </form>
  
  <script>
      // Simulando datos de productos
      const productos = [
          { id: 1, nombre: "Producto 1", categoria: "Categoria 1", marca: "Marca 1", precio: 50, imagenUrl: "https://via.placeholder.com/150" },
          { id: 2, nombre: "Producto 2", categoria: "Categoria 2", marca: "Marca 2", precio: 100, imagenUrl: "https://via.placeholder.com/150" },
          { id: 3, nombre: "Producto 3", categoria: "Categoria 1", marca: "Marca 3", precio: 150, imagenUrl: "https://via.placeholder.com/150" },
          { id: 4, nombre: "Producto 4", categoria: "Categoria 3", marca: "Marca 1", precio: 200, imagenUrl: "https://via.placeholder.com/150" },
          { id: 5, nombre: "Producto 5", categoria: "Categoria 2", marca: "Marca 2", precio: 80, imagenUrl: "https://via.placeholder.com/150" },
          { id: 6, nombre: "Producto 6", categoria: "Categoria 3", marca: "Marca 3", precio: 120, imagenUrl: "https://via.placeholder.com/150" }
      ];

      // Función para filtrar productos
      function filtrarProductos() {
          const marca = document.getElementById("ddlMarca").value;
          const categoria = document.getElementById("ddlCategoria").value;
          const precioMin = parseFloat(document.getElementById("txtPrecioMin").value) || 0;
          const precioMax = parseFloat(document.getElementById("txtPrecioMax").value) || Infinity;

          const productosFiltrados = productos.filter(producto => {
              return (
                  (marca ? producto.marca === marca : true) &&
                  (categoria ? producto.categoria === categoria : true) &&
                  (producto.precio >= precioMin && producto.precio <= precioMax)
              );
          });

          mostrarProductos(productosFiltrados);
      }

      // Función para mostrar productos en la página
      function mostrarProductos(productos) {
          const contenedorProductos = document.getElementById("productos");
          contenedorProductos.innerHTML = "";

          productos.forEach(producto => {
              const tarjetaProducto = `
          <div class="bg-white p-4 rounded-lg shadow-lg">
            <img src="${producto.imagenUrl}" alt="${producto.nombre}" class="w-full h-48 object-cover rounded-lg mb-4"/>
            <h3 class="text-xl font-semibold text-blue-800">${producto.nombre}</h3>
            <p class="text-sm text-gray-600 mb-2">${producto.categoria}</p>
            <p class="text-lg font-bold text-blue-800">$${producto.precio}</p>
            <button class="w-full py-2 bg-blue-800 hover:bg-blue-900 text-white font-medium rounded-md transition mt-4">Comprar</button>
          </div>
        `;
              contenedorProductos.innerHTML += tarjetaProducto;
          });
      }

      // Evento para aplicar filtros al cambiar las opciones
      document.getElementById("ddlMarca").addEventListener("change", filtrarProductos);
      document.getElementById("ddlCategoria").addEventListener("change", filtrarProductos);
      document.getElementById("txtPrecioMin").addEventListener("input", filtrarProductos);
      document.getElementById("txtPrecioMax").addEventListener("input", filtrarProductos);

      // Evento para resetear los filtros
      document.getElementById("btnReset").addEventListener("click", () => {
          document.getElementById("ddlMarca").value = "";
          document.getElementById("ddlCategoria").value = "";
          document.getElementById("txtPrecioMin").value = "";
          document.getElementById("txtPrecioMax").value = "";
          filtrarProductos(); // Recargar todos los productos sin filtros
      });

      // Cargar productos iniciales
      filtrarProductos();
  </script>
</asp:Content>