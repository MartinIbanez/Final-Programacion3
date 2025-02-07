<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Comprar.aspx.cs" Inherits="TP_FinalProgramacion3.Comprar" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Comprar</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-4">
            <h2 class="text-center">Confirmación de Compra</h2>
            <hr />

            <!-- GridView para listar productos del carrito -->
            <h4>Resumen de tu compra</h4>
            <asp:GridView ID="gvCarrito" runat="server" CssClass="table table-striped mt-3" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Descripcion" HeaderText="Producto" />
                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                    <asp:BoundField DataField="Precio" HeaderText="Precio Unitario" DataFormatString="{0:C}" />
                    <asp:BoundField DataField="Total" HeaderText="Total" DataFormatString="{0:C}" />
                </Columns>
            </asp:GridView>

            <hr />

            <!-- Formulario para los datos del cliente -->
            <h4>Datos del Cliente</h4>
            <div class="row g-3 mt-3">
                <div class="col-md-6">
                    <label for="txtNombre" class="form-label">Nombre</label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label for="txtApellido" class="form-label">Apellido</label>
                    <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </div>
                <div class="col-md-12">
                    <label for="txtDireccion" class="form-label">Dirección de entrega</label>
                    <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label for="txtProvincia" class="form-label">Provincia</label>
                    <asp:TextBox ID="txtProvincia" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label for="txtCodigoPostal" class="form-label">Código Postal</label>
                    <asp:TextBox ID="txtCodigoPostal" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </div>
            </div>

            <!-- Sección de Método de Envío -->
            <hr />
            <h4 class="mt-4">Entrega del Pedido</h4>
            <div class="form-check">
                <input class="form-check-input" type="radio" name="flexRadioDefault" id="Radio1">
                <label class="form-check-label" for="flexRadioDefault1">Retiro en sucursal </label>
            </div>
            <div class="form-check">
                <input class="form-check-input" type="radio" name="flexRadioDefault" id="Radio2" checked>
                <label class="form-check-label" for="flexRadioDefault2">Envío a mi domicilio  </label>
            </div>
            <hr />

            <!-- Sección de Forma de Pago -->
            <h4 class="mt-4">Metodo de Pago</h4>
            
                <select class="form-select" aria-label="Default select example">
                    <option selected>Forma de pago</option>
                    <option value="1">Efectivo</option>
                    <option value="2">Tarjeta de Credito</option>
                    <option value="3">Tarjeta de Debito</option>
                </select>
           

            <div class="mt-4 text-end">
                <asp:Button ID="btnConfirmarCompra" runat="server" Text="Confirmar Compra" CssClass="btn btn-success" OnClick="btnConfirmarCompra_Click" />
                <asp:Button ID="btnCancelar" runat="server" Text="Volver al carrito" CssClass="btn btn-secondary" PostBackUrl="Carrito.aspx" />
            </div>
        </div>
    </form>
</body>
</html>
