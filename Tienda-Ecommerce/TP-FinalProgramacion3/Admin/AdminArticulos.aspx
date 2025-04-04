﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminArticulos.aspx.cs" Inherits="TP_FinalProgramacion3.Admin.Productos" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Productos</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
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
                <div class="col-lg-12">
                    <h1 class="mb-4">Listado de Productos</h1>
                    <asp:Label ID="lblError" runat="server" CssClass="text-danger" Visible="false"></asp:Label>

                    <table class="table table-dark table-hover table-bordered">
                        <thead>
                            <tr>
                                <th>ID</th>
                                <th>Descripción</th>
                                <th>Categoría</th>
                                <th>Marca</th>
                                <th>Proveedor</th>
                                <th>Nombre</th>
                                <th>Stock</th>
                                <th>URL</th>
                                <th>Precio</th>
                                <th>Stock Mín</th>
                                <th>Estado</th>
                                <th>Acciones</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptArticulos" runat="server" OnItemCommand="rptArticulos_ItemCommand">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("IdArticulo") %></td>
                                        <td><%# Eval("Descripcion") %></td>
                                        <td><%# Eval("NombreCategoria") %></td>
                                        <td><%# Eval("NombreMarca") %></td>
                                        <td><%# Eval("NombreProveedor") %></td>
                                        <td><%# Eval("Nombre") %></td>
                                        <td><%# Eval("Stock") %></td>
                                        <td>
                                            <a href="<%# Eval("UrlImagen") %>" class="text-decoration-none text-light">Link</a>
                                        </td>
                                        <td><%# String.Format("{0:C}", Eval("Precio")) %></td>
                                        <td><%# Eval("StockMinimo") %></td>
                                        <td>
                                            <%# (bool)Eval("Estado") ? "Activo" : "Inactivo" %>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="btn btn-warning btn-sm" CommandName="Editar" CommandArgument='<%# Eval("IdArticulo") %>' />
                                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger btn-sm" CommandName="Eliminar" CommandArgument='<%# Eval("IdArticulo") %>' OnClientClick="return confirm('¿Eliminar este Articulo?');" />
                                            
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>


                    <div class="d-flex justify-content-end mt-3">
                        <asp:Button ID="btnAgregarArticulo" runat="server" Text="+ Agregar Artículo" CssClass="btn btn-success" OnClick="btnAgregarArticulo_Click" />
                    </div>
                </div>
            </div>
        </section>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.6/dist/umd/popper.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.min.js"></script>
</body>
</html>
