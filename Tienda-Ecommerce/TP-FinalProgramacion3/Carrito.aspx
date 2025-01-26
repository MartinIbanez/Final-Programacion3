<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="TP_FinalProgramacion3.Carrito" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Carrito de Compras</title>
    <style>
        .cart-container {
            max-width: 1200px;
            margin: 0 auto;
            padding: 20px;
        }

        .cart-header {
            text-align: center;
            margin-bottom: 30px;
        }

        .cart-img {
            width: 80px;
            height: auto;
            border-radius: 8px;
        }

        .cart-summary {
            font-weight: bold;
            font-size: 16px;
        }

        .quantity-btn {
            width: 36px;
            height: 36px;
            border: 1px solid #ccc;
            border-radius: 4px;
            text-align: center;
            line-height: 36px;
            font-size: 18px;
            cursor: pointer;
        }

        .quantity-btn:hover {
            background-color: #f0f0f0;
        }

        .cart-btn {
            margin-top: 20px;
        }

        .cart-actions a {
            margin-right: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="cart-container">
            <h2 class="cart-header">Tu Carrito</h2>
            <asp:Label ID="lblError" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
            <asp:Repeater ID="rptCarrito" runat="server">
                <HeaderTemplate>
                    <table class="table">
                        <thead>
                            <tr>
                                <th>Imagen</th>
                                <th>Descripción</th>
                                <th>Cantidad</th>
                                <th>Precio</th>
                                <th>Total</th>
                                <th>Acciones</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <img src="<%# Eval("ImagenUrl", "imagenes/{0}") %>" alt="Producto" class="cart-img" />
                        </td>
                        <td><%# Eval("Descripcion") %></td>
                        <td>
                            <div class="d-flex align-items-center">
                                <a href="Carrito.aspx?id=<%# Eval("Id") %>&accion=decrementar" class="quantity-btn">-</a>
                                <input type="text" value="<%# Eval("Cantidad") %>" readonly class="form-control text-center mx-2" style="width: 60px;" />
                                <a href="Carrito.aspx?id=<%# Eval("Id") %>&accion=incrementar" class="quantity-btn">+</a>
                            </div>
                        </td>
                        <td>$<%# Eval("Precio", "{0:F2}") %></td>
                        <td>$<%# Eval("Total", "{0:F2}") %></td>
                        <td class="cart-actions">
                            <a href="Carrito.aspx?id=<%# Eval("Id") %>&accion=eliminar" class="btn btn-danger btn-sm">Eliminar</a>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                        </tbody>
                    </table>
                </FooterTemplate>
            </asp:Repeater>

            <!-- Resumen del carrito -->
            <div class="mt-4">
                <div class="row">
                    <div class="col-md-6 offset-md-6">
                        <div class="d-flex justify-content-between">
                            <span>Subtotal:</span>
                            <asp:Label ID="lblSubtotal" runat="server" Text="$0.00" CssClass="cart-summary"></asp:Label>
                        </div>
                        <div class="d-flex justify-content-between">
                            <span>IVA (21%):</span>
                            <asp:Label ID="lblIva" runat="server" Text="$0.00" CssClass="cart-summary"></asp:Label>
                        </div>
                        <div class="d-flex justify-content-between mb-3">
                            <span>Total:</span>
                            <asp:Label ID="lblTotal" runat="server" Text="$0.00" CssClass="cart-summary"></asp:Label>
                        </div>
                        <div class="text-end">
                            <a href="Comprar.aspx" class="btn btn-primary">Proceder al Pago</a>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Botones de acción -->
            <div class="mt-4">
                <a href="Productos.aspx" class="btn btn-secondary">Seguir Comprando</a>
            </div>
        </div>
    </form>
</body>
</html>
