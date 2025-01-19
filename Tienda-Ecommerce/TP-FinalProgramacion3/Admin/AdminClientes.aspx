<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminClientes.aspx.cs" Inherits="TP_FinalProgramacion3.Admin.AdminClientes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Clientes</title>
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
                <!-- Clientes -->
                <div class="col-lg-12">
                    <table class="table table-dark table-hover table-bordered">
                        <thead>
                            <tr>
                                <th scope="col" class="text-nowrap">DNI</th>
                                <th scope="col" class="text-nowrap">Nombre</th>
                                <th scope="col" class="text-nowrap">Apellido</th>
                                <th scope="col" class="text-nowrap">Dirección</th>
                                <th scope="col" class="text-nowrap">Provincia</th>
                                <th scope="col" class="text-nowrap">CodPostal</th>
                                <th scope="col" class="text-nowrap">Email</th>
                                <th scope="col" class="text-nowrap">Password</th>
                                <th scope="col" class="text-nowrap">Estado</th>
                                <th scope="col" class="text-nowrap">Tipo</th>
                                <th scope="col" class="text-nowrap">Acciones</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>12345678</td>
                                <td>Juan</td>
                                <td>Pérez</td>
                                <td>Calle Falsa 123</td>
                                <td>Buenos Aires</td>
                                <td>1000</td>
                                <td>juan@example.com</td>
                                <td>password123</td>
                                <td>Activo</td>
                                <td>Administrador</td>
                                <td>
                                    <button type="button" class="btn btn-warning btn-sm">Editar</button>
                                    <button type="button" class="btn btn-danger btn-sm">Eliminar</button>
                                </td>
                            </tr>
                            <tr>
                                <td>87654321</td>
                                <td>Maria</td>
                                <td>Gómez</td>
                                <td>Avenida Siempre Viva 456</td>
                                <td>Córdoba</td>
                                <td>5000</td>
                                <td>maria@example.com</td>
                                <td>password456</td>
                                <td>Inactivo</td>
                                <td>Usuario</td>
                                <td>
                                    <button type="button" class="btn btn-warning btn-sm">Editar</button>
                                    <button type="button" class="btn btn-danger btn-sm">Eliminar</button>
                                </td>
                            </tr>
                            <!-- Agregar más filas aquí según sea necesario -->
                        </tbody>
                    </table>

                    <div class="d-flex justify-content-end mt-3">
                        <asp:Button ID="btnAgregarCliente" runat="server" Text="+ Agregar Cliente" CssClass="btn btn-success" OnClick="btnAgregarCliente_Click" />
                    </div>

                </div>
            </div>
        </section>
    </form>

    <!-- Bootstrap 5 JS y Popper.js -->
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.6/dist/umd/popper.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.min.js"></script>
</body>
</html>
