<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarProveedor.aspx.cs" Inherits="TP_FinalProgramacion3.Admin.AgregarProveedor" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Agregar/Modificar Proveedor</title>
    <!-- Bootstrap 5 CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        .form-label {
            font-weight: bold;
        }
    </style>
</head>
<body class="bg-light">
    <form id="formAgregarProveedor" runat="server">
        <section class="container py-5">
            <div class="row">
                <div class="col-lg-6 mx-auto">
                    <h2 class="mb-4 text-center">Agregar/Modificar Proveedor</h2>
                    <asp:Label ID="lblError" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
                    <div class="card shadow">
                        <div class="card-body">
                            <!-- ID -->
                            <div class="mb-3">
                                <label for="txtIdProveedor" class="form-label">ID (Automático)</label>
                                <asp:TextBox ID="txtIdProveedor" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                            </div>
                            <!-- CUIT -->
                            <div class="mb-3">
                                <label for="txtCuit" class="form-label">CUIT</label>
                                <asp:TextBox ID="txtCuit" runat="server" CssClass="form-control" MaxLength="25" Placeholder="Ingrese el CUIT"></asp:TextBox>
                            </div>
                            <!-- Nombre -->
                            <div class="mb-3">
                                <label for="txtNombre" class="form-label">Nombre Proveedor</label>
                                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" MaxLength="25" Placeholder="Ingrese el nombre"></asp:TextBox>
                            </div>
                            <!-- Nombre Contacto -->
                            <div class="mb-3">
                                <label for="txtNombreContacto" class="form-label">Nombre Contacto</label>
                                <asp:TextBox ID="txtNombreContacto" runat="server" CssClass="form-control" MaxLength="25" Placeholder="Ingrese el nombre del contacto"></asp:TextBox>
                            </div>
                            <!-- Cargo Contacto -->
                            <div class="mb-3">
                                <label for="txtCargoContacto" class="form-label">Cargo Contacto</label>
                                <asp:TextBox ID="txtCargoContacto" runat="server" CssClass="form-control" MaxLength="25" Placeholder="Ingrese el cargo del contacto"></asp:TextBox>
                            </div>
                            <!-- Dirección -->
                            <div class="mb-3">
                                <label for="txtDireccion" class="form-label">Dirección</label>
                                <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" MaxLength="50" Placeholder="Ingrese la dirección"></asp:TextBox>
                            </div>
                            <!-- Ciudad -->
                            <div class="mb-3">
                                <label for="txtCiudad" class="form-label">Ciudad</label>
                                <asp:TextBox ID="txtCiudad" runat="server" CssClass="form-control" MaxLength="25" Placeholder="Ingrese la ciudad"></asp:TextBox>
                            </div>
                            <!-- Código Postal -->
                            <div class="mb-3">
                                <label for="txtCodigoPostal" class="form-label">Código Postal</label>
                                <asp:TextBox ID="txtCodigoPostal" runat="server" CssClass="form-control" MaxLength="5" Placeholder="Ingrese el código postal"></asp:TextBox>
                            </div>
                            <!-- Teléfono -->
                            <div class="mb-3">
                                <label for="txtTelefono" class="form-label">Teléfono</label>
                                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" MaxLength="12" Placeholder="Ingrese el teléfono"></asp:TextBox>
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
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
