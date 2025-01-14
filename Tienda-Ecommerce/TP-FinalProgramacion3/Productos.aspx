<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="TP_FinalProgramacion3.Productos" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Productos</title>
    <!-- Bootstrap 5 CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body class="bg-light">
    <form id="form1" runat="server">
        <section class="container py-5">
            <div class="row">
                <!-- Panel de Filtros -->
                <div class="col-lg-3 mb-4">
                    <div class="card p-4">
                        <h3 class="h5 text-primary mb-4">Filtros</h3>

                        <!-- Filtro por Marca -->
                        <div class="mb-3">
                            <label for="ddlMarca" class="form-label">Marca</label>
                            <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-select">
                                <asp:ListItem Text="Seleccione una marca" Value="" />
                            </asp:DropDownList>
                        </div>

                        <!-- Filtro por Categoría -->
                        <div class="mb-3">
                            <label for="ddlCategoria" class="form-label">Categoría</label>
                            <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-select">
                                <asp:ListItem Text="Seleccione una categoría" Value="" />
                            </asp:DropDownList>
                        </div>

                        <!-- Filtro por Precio -->
                        <div class="mb-3">
                            <label class="form-label">Rango de Precios</label>
                            <div class="d-flex gap-2">
                                <asp:TextBox ID="txtPrecioMin" runat="server" CssClass="form-control" Placeholder="Min"></asp:TextBox>
                                <asp:TextBox ID="txtPrecioMax" runat="server" CssClass="form-control" Placeholder="Max"></asp:TextBox>
                            </div>
                        </div>

                        <!-- Botón de Filtrar -->
                        <div>
                            <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" CssClass="btn btn-primary w-100" OnClick="btnFiltrar_Click" />
                        </div>
                    </div>
                </div>

                <!-- Productos -->
                <div class="col-lg-9">
                    <h2 class="h3 text-primary mb-4">Productos</h2>
                    <div id="productos" class="row row-cols-1 row-cols-md-2 row-cols-lg-3 g-4">
                        <asp:Repeater ID="rptProductos" runat="server">
                            <ItemTemplate>
                                <div class="col">
                                    <div class="card shadow-sm border-light rounded-3">
                                        <img src="<%# Eval("UrlImagen") %>" alt="<%# Eval("Nombre") %>" class="card-img-top" />
                                        <div class="card-body">
                                            <h5 class="card-title text-primary"><%# Eval("Nombre") %></h5>
                                            <p class="card-text text-muted"><%# Eval("Descripcion") %></p>
                                            <p class="text-secondary"><%# Eval("IdCategoria") %></p>
                                            <p class="fw-bold text-primary">$<%# Eval("Precio") %></p>
                                            <button class="btn btn-primary w-100">Comprar</button>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
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
