<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="verDetalleVenta.aspx.cs" Inherits="TP_FinalProgramacion3.verDetalleVenta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Detalle de Venta</title>
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
<body>
    <form id="form1" runat="server">
        <section class="container py-5">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="mb-4">Historial de Compras</h1>
                    <asp:Label ID="lblError" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
                    <asp:Label ID="lblNumFactura" runat="server" Text="" CssClass="h2 fw-bold text-primary mb-2"></asp:Label>
                    <table class="table table-dark table-hover table-bordered mt-3">
                        <thead>
                            <tr>
                                <th>ID Articulo</th>
                                <th>Nombre Articulo</th>
                                <th>Precio</th>
                                <th>Cantidad</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptDetallesVentas" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        
                                        <td><%# Eval("IdArticulo") %></td>
                                        <td><%# Eval("NombreArticulo") %></td>
                                        <td><%# String.Format("{0:C}", Eval("Precio")) %></td>
                                        <td><%# Eval("Cantidad") %></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                    <div class="d-flex justify-content-center mt-3">
                        <asp:Button ID="volverHistorial" runat="server" Text="Volver" CssClass="btn btn-success btn-sm" OnClick="volverHistorial_Click" />
                    </div>
                </div>
            </div>
        </section>
    </form>
        <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.6/dist/umd/popper.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.min.js"></script>
</body>
</html>
