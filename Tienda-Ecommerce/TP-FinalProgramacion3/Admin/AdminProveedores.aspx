<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminProveedores.aspx.cs" Inherits="TP_FinalProgramacion3.Admin.AdminProveedores" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Proveedores</title>
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
                <!-- Proveedores -->
                <div class="col-lg-12 mx-auto">
                    <table class="table table-dark table-hover table-bordered">
                        <thead>
                            <tr>
                                <th scope="col" class="text-nowrap">ID</th>
                                <th scope="col" class="text-nowrap">CUIT</th>
                                <th scope="col" class="text-nowrap">Nombre</th>
                                <th scope="col" class="text-nowrap">Contacto</th>
                                <th scope="col" class="text-nowrap">Cargo</th>
                                <th scope="col" class="text-nowrap">Dirección</th>
                                <th scope="col" class="text-nowrap">Ciudad</th>
                                <th scope="col" class="text-nowrap">Cod. Postal</th>
                                <th scope="col" class="text-nowrap">Teléfono</th>
                                <th scope="col" class="text-nowrap">Estado</th>
                                <th scope="col" class="text-nowrap">Acciones</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>1</td>
                                <td>20-12345678-9</td>
                                <td>Proveedor A</td>
                                <td>Juan Pérez</td>
                                <td>Gerente</td>
                                <td>Calle Falsa 123</td>
                                <td>Buenos Aires</td>
                                <td>1000</td>
                                <td>011-1234-5678</td>
                                <td>Activo</td>
                                <td>
                                    <button type="button" class="btn btn-warning btn-sm">Editar</button>
                                    <button type="button" class="btn btn-danger btn-sm">Eliminar</button>
                                </td>
                            </tr>
                            <tr>
                                <td>2</td>
                                <td>30-87654321-0</td>
                                <td>Proveedor B</td>
                                <td>María López</td>
                                <td>Encargada</td>
                                <td>Av. Siempre Viva 742</td>
                                <td>Córdoba</td>
                                <td>5000</td>
                                <td>0351-5678-1234</td>
                                <td>Inactivo</td>
                                <td>
                                    <button type="button" class="btn btn-warning btn-sm">Editar</button>
                                    <button type="button" class="btn btn-danger btn-sm">Eliminar</button>
                                </td>
                            </tr>
                            <!-- Agregar más filas aquí según sea necesario -->
                        </tbody>
                    </table>
                    <div class="d-flex justify-content-end mt-3">
                        <asp:Button ID="btnAgregarProveedor" runat="server" Text="+ Agregar Proveedor" CssClass="btn btn-success" OnClick="btnAgregarProveedor_Click" />
                    </div>
               
        </section>
    </form>

    <!-- Bootstrap 5 JS y Popper.js -->
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.6/dist/umd/popper.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.min.js"></script>
</body>
</html>
