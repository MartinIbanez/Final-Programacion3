﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminMarcas.aspx.cs" Inherits="TP_FinalProgramacion3.Admin.AdminMarcas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Marcas</title>
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
                <!-- Marcas -->
                <div class="col-lg-8 mx-auto">
                    <table class="table table-dark table-hover table-bordered">
                        <thead>
                            <tr>
                                <th scope="col" class="text-nowrap">ID</th>
                                <th scope="col" class="text-nowrap">Descripción</th>
                                <th scope="col" class="text-nowrap">Estado</th>
                                <th scope="col" class="text-nowrap">Acciones</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>1</td>
                                <td>Marca A</td>
                                <td>Activo</td>
                                <td>
                                    <button type="button" class="btn btn-warning btn-sm">Editar</button>
                                    <button type="button" class="btn btn-danger btn-sm">Eliminar</button>
                                </td>
                            </tr>
                            <tr>
                                <td>2</td>
                                <td>Marca B</td>
                                <td>Inactivo</td>
                                <td>
                                    <button type="button" class="btn btn-warning btn-sm">Editar</button>
                                    <button type="button" class="btn btn-danger btn-sm">Eliminar</button>
                                </td>
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
