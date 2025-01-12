<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Articulos.aspx.cs" Inherits="TP_FinalProgramacion3.Admin.Productos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Productos</title>
    <!-- Bootstrap 5 CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        /* Ajustar el ancho de las columnas */
        .table th, .table td {
            white-space: nowrap;
            text-align: center;
            vertical-align: middle;
        }
        .table th {
            font-weight: bold;
        }
    </style>
</head>
<body class="bg-light">

    <form id="form1" runat="server">
        <section class="container py-5">
            <div class="row">
                <!-- Productos -->
                <div class="col-lg-9">
                    <table class="table table-dark table-hover table-bordered">
                        <thead>
                            <tr>
                                <th scope="col" class="text-nowrap">ID</th>
                                <th scope="col" class="text-nowrap">Descripción</th>
                                <th scope="col" class="text-nowrap">Categoría</th>
                                <th scope="col" class="text-nowrap">Marca</th>
                                <th scope="col" class="text-nowrap">Proveedor</th>
                                <th scope="col" class="text-nowrap">Nombre</th>
                                <th scope="col" class="text-nowrap">Stock</th>
                                <th scope="col" class="text-nowrap">URL</th>
                                <th scope="col" class="text-nowrap">Precio</th>
                                <th scope="col" class="text-nowrap">Stock Mín</th>
                                <th scope="col" class="text-nowrap">Estado</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>1</td>
                                <td>Descripción del producto 1</td>
                                <td>Categoría 1</td>
                                <td>101</td>
                                <td>201</td>
                                <td>Producto 1</td>
                                <td>50</td>
                                <td><a href="https://example.com/producto1" class="text-decoration-none text-light">Link</a></td>
                                <td>$100.00</td>
                                <td>10</td>
                                <td>Activo</td>
                            </tr>
                            <tr>
                                <td>2</td>
                                <td>Descripción del producto 2</td>
                                <td>Categoría 2</td>
                                <td>102</td>
                                <td>202</td>
                                <td>Producto 2</td>
                                <td>30</td>
                                <td><a href="https://example.com/producto2" class="text-decoration-none text-light">Link</a></td>
                                <td>$200.00</td>
                                <td>5</td>
                                <td>Inactivo</td>
                            </tr>
                            <!-- Agregar más filas aquí según sea necesario -->
                        </tbody>
                    </table>
                </div>
            </div>
        </section>
    </form>

    <!-- Bootstrap 5 JS y Popper.js -->
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.6/dist/umd/popper.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.min.js"></script>
</body>
</html>
