<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarMarca.aspx.cs" Inherits="TP_FinalProgramacion3.Admin.AgregarMarca" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Agregar/Modificar Marca</title>
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
                <div class="col-lg-6 mx-auto">
                    <h2 class="mb-4 text-center">Agregar/Modificar Marca</h2>
                    <asp:Label ID="lblError" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
                    <div class="card shadow">
                        <div class="card-body">
                            <div class="mb-3">
                                <label for="txtIdMarca" class="form-label">ID (Automático)</label>
                                <asp:TextBox ID="txtIdMarca" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                            </div>
                            <div class="mb-3">
                                <label for="txtDescripcion" class="form-label">Descripción</label>
                                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" MaxLength="50" Placeholder="Ingrese la descripción"></asp:TextBox>
                            </div>
                            <div class="mb-3">
                                <label for="ddlEstado" class="form-label">Estado</label>
                                <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-select">
                                    <asp:ListItem Text="Activo" Value="true"></asp:ListItem>
                                    <asp:ListItem Text="Inactivo" Value="false"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="d-flex justify-content-end">
                                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary me-2" />
                                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" />
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
