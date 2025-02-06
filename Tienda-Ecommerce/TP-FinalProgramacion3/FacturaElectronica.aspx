<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FacturaElectronica.aspx.cs" Inherits="TP_FinalProgramacion3.FacturaElectronica" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Factura Electrónica</title>
    <!-- Enlace a Bootstrap -->
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">

            <!-- Card de la factura -->
            <div class="card">
                <div class="card-header">
                    <h3>Factura Electrónica</h3>
                    <p class="mb-0">Fecha de compra: <%= DateTime.Now.ToString("dd/MM/yyyy") %></p>
                </div>
                <div class="card-body">

                    <!-- Datos del comprador y vendedor -->
                    <div class="row mb-3">
                        <div class="col-md-6">
                            <h5>CLIENTE</h5>
                            <ul class="list-unstyled">
                                <li><strong>Nombre:</strong> <%= Session["UsuarioLogin"] != null ? ((dominio.Cliente)Session["UsuarioLogin"]).Nombre +" "+((dominio.Cliente)Session["UsuarioLogin"]).Apellido : "No disponible" %></li>
                                <li><strong>DNI:</strong> <%= Session["UsuarioLogin"] != null ? ((dominio.Cliente)Session["UsuarioLogin"]).Dni : "No disponible" %></li>
                                <li><strong>Dirección:</strong> <%= Session["UsuarioLogin"] != null ? ((dominio.Cliente)Session["UsuarioLogin"]).Direccion: "No disponible" %></li>
                            </ul>
                        </div>
                        <div class="col-md-6">
                            <h5>UTN DEPORTES</h5>
                            <ul class="list-unstyled">
                                <li><strong>Nombre:</strong> UTN - Tienda Online</li>
                                <li><strong>Dirección:</strong> Av. Hipólito Yrigoyen 288</li>
                                <li><strong>Email:</strong> martin.ibanez@alumnos.frgp.utn.edu.ar</li>
                            </ul>
                        </div>
                    </div>

                    <!-- Detalle de la venta -->
                    <table class="table table-bordered">
                        <thead>
                            <tr>
                                <th>ID Artículo</th>
                                <th>Descripción</th>
                                <th>Cantidad</th>
                                <th>Precio Unitario</th>
                                <th>Total</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptFactura" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("IdArticulo") %></td>
                                        <td><%# Eval("Descripcion") %></td>
                                        <td><%# Eval("Cantidad") %></td>
                                        <td><%# String.Format("{0:C2}", Eval("Precio")) %></td>
                                        <td><%# String.Format("{0:C2}", Eval("Total")) %></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>

                    <!-- Total de la compra -->
                    <div class="text-right">
                        <h4>TOTAL: <asp:Label ID="lblTotalFactura" runat="server" Text="$ 0.00"></asp:Label></h4>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <!-- Scripts de Bootstrap -->
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.5.2/dist/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
