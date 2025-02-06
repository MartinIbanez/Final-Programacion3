<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminVentas.aspx.cs" Inherits="TP_FinalProgramacion3.Admin.AdminVentas" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Detalle de Ventas</title>
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
                    <h1 class="mb-4">Detalle de Ventas</h1>
                    <asp:Label ID="lblError" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
                    <table class="table table-dark table-hover table-bordered">
                        <thead>
                            <tr>
                                <th scope="col">Nro. Factura</th>
                                <th scope="col">DNI Cliente</th>
                                <th scope="col">Fecha Venta</th>
                                <th scope="col">Monto</th>
                                <th scope="col">Método de Pago</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptVentas" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("NroFactura") %></td>
                                        <td><%# Eval("Dni") %></td>
                                        <td><%# Eval("Fecha", "{0:dd/MM/yyyy}") %></td>
                                        <td><%# Eval("Monto", "{0:C}") %></td>
                                        <td><%# Eval("MetodoPago") %></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
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