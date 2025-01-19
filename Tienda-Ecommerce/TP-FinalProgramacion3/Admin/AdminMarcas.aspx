<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminMarcas.aspx.cs" Inherits="TP_FinalProgramacion3.Admin.AdminMarcas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Marcas</title>
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
    </style>
</head>
<body class="bg-light">

    <form id="form1" runat="server">
        <section class="container py-5">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="mb-4">LISTADO DE MARCAS</h1>
                    <asp:Label ID="lblError" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
                    
                    <table class="table table-dark table-hover table-bordered">
                        <thead>
                            <tr>
                                <th scope="col">ID</th>
                                <th scope="col">Descripción</th>
                                <th scope="col">Estado</th>
                                <th scope="col">Acciones</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptMarcas" runat="server" OnItemCommand="rptMarcas_ItemCommand">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("IdMarca") %></td>
                                        <td><%# Eval("Descripcion") %></td>
                                        <td><%# (bool)Eval("Estado") ? "Activo" : "Inactivo" %></td>
                                        <td>
                                            <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="btn btn-warning btn-sm" CommandName="Editar" CommandArgument='<%# Eval("IdMarca") %>' />
                                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger btn-sm" CommandName="Eliminar" CommandArgument='<%# Eval("IdMarca") %>' OnClientClick="return confirm('¿Está seguro que desea eliminar esta marca?');" />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                    
                    
                    <div class="d-flex justify-content-end mt-3">
                        <asp:Button ID="btnAgregarMarca" runat="server" Text="+ Agregar Marca" CssClass="btn btn-success" OnClick="btnAgregarMarca_Click" />
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
