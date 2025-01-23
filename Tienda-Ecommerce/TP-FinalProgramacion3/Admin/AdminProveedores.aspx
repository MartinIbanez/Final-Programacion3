<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminProveedores.aspx.cs" Inherits="TP_FinalProgramacion3.Admin.AdminProveedores" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Proveedores</title>
    <!-- Bootstrap 5 CSS -->
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

        .d-flex {
            margin-top: 20px;
        }

        .btn {
            margin-right: 20px;
        }

        .table-footer {
            text-align: right;
            padding-top: 10px;
        }
    </style>
</head>
<body class="bg-light">

    <form id="form1" runat="server">
        <section class="container py-5">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="mb-4">Listado de Proveedores</h1>
                    <asp:Label ID="lblError" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
                    <table class="table table-dark table-hover table-bordered">
                        <thead>
                            <tr>
                                <th>ID</th>
                                <th>CUIT</th>
                                <th>Proveedor</th>
                                <th>Contacto</th>
                                <th>Cargo</th>
                                <th>Dirección</th>
                                <th>Ciudad</th>
                                <th>Código Postal</th>
                                <th>Teléfono</th>
                                <th>Estado</th>
                                <th>Acciones</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptProveedores" runat="server" OnItemCommand="rptProveedores_ItemCommand">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("IdProveedor") %></td>
                                        <td><%# Eval("CUIT") %></td>
                                        <td><%# Eval("Nombre") %></td>
                                        <td><%# Eval("NombreContacto") %></td>
                                        <td><%# Eval("CargoContacto") %></td>
                                        <td><%# Eval("Direccion") %></td>
                                        <td><%# Eval("Ciudad") %></td>
                                        <td><%# Eval("CodPostal") %></td>
                                        <td><%# Eval("Telefono") %></td>
                                        <td><%# (bool)Eval("Estado") ? "Activo" : "Inactivo" %></td>
                                        <td>
                                            <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="btn btn-warning btn-sm" CommandName="Editar" CommandArgument='<%# Eval("IdProveedor") %>' />
                                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger btn-sm" CommandName="Eliminar" CommandArgument='<%# Eval("IdProveedor") %>' OnClientClick="return confirm('¿Eliminar este proveedor?');" />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>

                    <!-- Fila para el botón de agregar proveedor alineado a la derecha -->
                    <div class="table-footer">
                        <asp:Button ID="btnAgregarProveedor" runat="server" Text="+ Agregar Proveedor" CssClass="btn btn-success" OnClick="btnAgregarProveedor_Click" />
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