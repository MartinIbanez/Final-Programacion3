<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerCompras.aspx.cs" Inherits="TP_FinalProgramacion3.VerCompras" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Historial De Compras</title>
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
                    <% 
                        string titulo = "Historial de Compras"; // Valor por defecto
                        if (Session["UsuarioLogin"] != null)
                        {
                           dominio.Cliente usuario = Session["UsuarioLogin"] as dominio.Cliente;
                            if (usuario.Tipo) // Si es admin
                            {
                                titulo = "Historial de Ventas";
                            }
                        }
                    %>
                    <h1 class="mb-4"><%= titulo %></h1>

                    <asp:Label ID="lblError" runat="server" CssClass="text-danger" Visible="false"></asp:Label>

                    <table class="table table-dark table-hover table-bordered">
                        <thead>
                            <tr>
                                <th>Numero de Factura</th>
                                <th>Dni Cliente</th>
                                <th>Fecha de Compra</th>
                                <th>Monto Total</th>
                                <th>Metodo de Pago</th>
                                <th>Acciones</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptDetalle" runat="server" OnItemCommand="rptDetalle_ItemCommand">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("NroFactura") %></td>
                                        <td><%# Eval("Dni") %></td>
                                        <td><%# Convert.ToDateTime(Eval("Fecha")).ToString("dd/MM/yyyy") %></td>
                                        <td><%# String.Format("{0:C}", Eval("Monto")) %></td>
                                        <td><%# Eval("MetodoPago") %></td>
                                        <td>
                                            <asp:Button ID="btnDetalle" runat="server" Text="Ver Detalle" CssClass="btn btn-success btn-sm" CommandName="Detalle" CommandArgument='<%# Eval("NroFactura") %>' />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>
            </div>
        </section>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.6/dist/umd/popper.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.min.js"></script>
</body>
</html>
