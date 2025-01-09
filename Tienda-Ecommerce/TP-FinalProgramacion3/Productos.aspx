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
                <!-- Panel de Filtros (ubicado en la parte izquierda) -->
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
                            <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" CssClass="btn btn-primary w-100" />
                        </div>
                    </div>
                </div>

                <!-- Productos -->
                <div class="col-lg-9">
                    <h2 class="h3 text-primary mb-4">Productos</h2>
                    <div id="productos" class="row row-cols-1 row-cols-md-2 row-cols-lg-3 g-4">
                        <!-- Tarjetas de productos (sin backend por ahora) -->
                        <div class="col">
                            <div class="card shadow-sm border-light rounded-3">
                                <img src="https://via.placeholder.com/300x200" alt="Producto 1" class="card-img-top" />
                                <div class="card-body">
                                    <h5 class="card-title text-primary">Producto 1</h5>
                                    <p class="card-text text-muted">Descripción breve del producto.</p>
                                    <p class="text-secondary">Categoría 1</p>
                                    <p class="fw-bold text-primary">$100</p>
                                    <button class="btn btn-primary w-100">Comprar</button>
                                </div>
                            </div>
                        </div>
                        <div class="col">
                            <div class="card shadow-sm border-light rounded-3">
                                <img src="https://via.placeholder.com/300x200" alt="Producto 2" class="card-img-top" />
                                <div class="card-body">
                                    <h5 class="card-title text-primary">Producto 2</h5>
                                    <p class="card-text text-muted">Descripción breve del producto.</p>
                                    <p class="text-secondary">Categoría 2</p>
                                    <p class="fw-bold text-primary">$150</p>
                                    <button class="btn btn-primary w-100">Comprar</button>
                                </div>
                            </div>
                        </div>
                        <div class="col">
                            <div class="card shadow-sm border-light rounded-3">
                                <img src="https://via.placeholder.com/300x200" alt="Producto 3" class="card-img-top" />
                                <div class="card-body">
                                    <h5 class="card-title text-primary">Producto 3</h5>
                                    <p class="card-text text-muted">Descripción breve del producto.</p>
                                    <p class="text-secondary">Categoría 3</p>
                                    <p class="fw-bold text-primary">$200</p>
                                    <button class="btn btn-primary w-100">Comprar</button>
                                </div>
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
