<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarArticulo.aspx.cs" Inherits="TP_FinalProgramacion3.Admin.AgregarArticulo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Agregar/Modificar Artículo</title>
    <!-- Bootstrap 5 CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        .form-label {
            font-weight: bold;
        }
    </style>
</head>
<body class="bg-light">
    <form id="form1" runat="server">
        <section class="container py-5">
            <div class="row">
                <div class="col-lg-8 mx-auto">
                    <h2 class="mb-4 text-center">Agregar/Modificar Artículo</h2>
                    <asp:Label ID="lblError" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
                    <div class="card shadow">
                        <div class="card-body">
                            <!-- ID -->
                            <div class="mb-3">
                                <label for="txtId" class="form-label">ID (Automático)</label>
                                <asp:TextBox ID="txtId" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                            </div>
                            <!-- Nombre -->
                            <div class="mb-3">
                                <label for="txtNombre" class="form-label">Nombre</label>
                                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" MaxLength="100" Placeholder="Ingrese el nombre"></asp:TextBox>
                            </div>
                            <!-- Descripción -->
                            <div class="mb-3">
                                <label for="txtDescripcion" class="form-label">Descripción</label>
                                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" Placeholder="Ingrese la descripción"></asp:TextBox>
                            </div>
                            <!-- Categoría -->
                            <div class="mb-3">
                                <label for="ddlCategoria" class="form-label">Categoría</label>
                                <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-select">
                                    <asp:ListItem Text="Seleccione una categoría" Value=""></asp:ListItem>
                                   
                                </asp:DropDownList>
                            </div>
                            <!-- Marca -->
                            <div class="mb-3">
                                <label for="ddlMarca" class="form-label">Marca</label>
                                <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-select">
                                    <asp:ListItem Text="Seleccione una marca" Value=""></asp:ListItem>
                                   
                                </asp:DropDownList>
                            </div>
                            <!-- Proveedor -->
                            <div class="mb-3">
                                <label for="ddlProveedor" class="form-label">Proveedor</label>
                                <asp:DropDownList ID="ddlProveedor" runat="server" CssClass="form-select">
                                    <asp:ListItem Text="Seleccione un proveedor" Value=""></asp:ListItem>
                                    
                                </asp:DropDownList>
                            </div>
                            <!-- Stock -->
                            <div class="mb-3">
                                <label for="txtStock" class="form-label">Stock</label>
                                <asp:TextBox ID="txtStock" runat="server" CssClass="form-control" TextMode="Number" Placeholder="Ingrese el stock"></asp:TextBox>
                            </div>
                            <!-- Stock Mínimo -->
                            <div class="mb-3">
                                <label for="txtStockMinimo" class="form-label">Stock Mínimo</label>
                                <asp:TextBox ID="txtStockMinimo" runat="server" CssClass="form-control" TextMode="Number" Placeholder="Ingrese el stock mínimo"></asp:TextBox>
                            </div>
                            <!-- URL Imagen -->
                            <div class="mb-3">
                                <label for="txtUrlImagen" class="form-label">URL de Imagen</label>
                                <asp:TextBox ID="txtUrlImagen" runat="server" CssClass="form-control" Placeholder="Ingrese la URL de la imagen"></asp:TextBox>
                            </div>
                            <!-- Precio -->
                            <div class="mb-3">
                                <label for="txtPrecio" class="form-label">Precio</label>
                                <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" TextMode="Number" Placeholder="Ingrese el precio"></asp:TextBox>
                            </div>
                            <!-- Estado -->
                            <div class="mb-3">
                                <label for="ddlEstado" class="form-label">Estado</label>
                                <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-select">
                                    <asp:ListItem Text="Activo" Value="true"></asp:ListItem>
                                    <asp:ListItem Text="Inactivo" Value="false"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <!-- Botones -->
                            <div class="d-flex justify-content-end">

                                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary me-2" OnClick="btnGuardar_Click" />
                                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" OnClick="btnCancelar_Click" />
                            </div>
                        </div>
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
