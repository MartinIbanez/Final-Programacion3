<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarCliente.aspx.cs" Inherits="TP_FinalProgramacion3.Admin.AgregarCliente" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Agregar/Modificar Cliente</title>
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
                    <h2 class="mb-4 text-center">Agregar/Modificar Cliente</h2>
                    <asp:Label ID="lblError" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
                    <div class="card shadow">
                        <div class="card-body">
                            <!-- DNI -->
                            <div class="mb-3">
                                <label for="txtDNI" class="form-label">DNI</label>
                                <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control" MaxLength="8" Placeholder="Ingrese el DNI"></asp:TextBox>
                            </div>
                            <!-- Nombre y Apellido -->
                            <div class="row mb-3">
                                <div class="col-md-6">
                                    <label for="txtNombre" class="form-label">Nombre</label>
                                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" MaxLength="25" Placeholder="Ingrese el nombre"></asp:TextBox>
                                </div>
                                <div class="col-md-6">
                                    <label for="txtApellido" class="form-label">Apellido</label>
                                    <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" MaxLength="25" Placeholder="Ingrese el apellido"></asp:TextBox>
                                </div>
                            </div>
                            <!-- Dirección -->
                            <div class="mb-3">
                                <label for="txtDireccion" class="form-label">Dirección</label>
                                <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" MaxLength="50" Placeholder="Ingrese la dirección"></asp:TextBox>
                            </div>
                            <!-- Provincia y Código Postal -->
                            <div class="row mb-3">
                                <div class="col-md-6">
                                    <label for="ddlProvincia" class="form-label">Provincia</label>
                                    <asp:DropDownList ID="ddlProvincia" runat="server" CssClass="form-select">
                                        <asp:ListItem Text="Seleccione una provincia" Value="" />
                                        <asp:ListItem Text="Buenos Aires" Value="Buenos Aires" />
                                        <asp:ListItem Text="Catamarca" Value="Catamarca" />
                                        <asp:ListItem Text="Chaco" Value="Chaco" />
                                        <asp:ListItem Text="Chubut" Value="Chubut" />
                                        <asp:ListItem Text="Córdoba" Value="Córdoba" />
                                        <asp:ListItem Text="Corrientes" Value="Corrientes" />
                                        <asp:ListItem Text="Entre Rios" Value="Entre Rios" />
                                        <asp:ListItem Text="Formosa" Value="Formosa" />
                                        <asp:ListItem Text="Jujuy" Value="Jujuy" />
                                        <asp:ListItem Text="La Pampa" Value="La Pampa" />
                                        <asp:ListItem Text="La Rioja" Value="La Rioja" />
                                        <asp:ListItem Text="Mendoza" Value="Mendoza" />
                                        <asp:ListItem Text="Misiones" Value="Misiones" />
                                        <asp:ListItem Text="Neuquen" Value="Neuquen" />
                                        <asp:ListItem Text="Rio Negro" Value="Rio Negro" />
                                        <asp:ListItem Text="Salta" Value="Salta" />
                                        <asp:ListItem Text="San Juan" Value="San Juan" />
                                        <asp:ListItem Text="San Luis" Value="San Luis" />
                                        <asp:ListItem Text="Santa Cruz" Value="Santa Cruz" />
                                        <asp:ListItem Text="Santa Fe" Value="Santa Fe" />
                                        <asp:ListItem Text="Santiago del Estero" Value="Santiago del Estero" />
                                        <asp:ListItem Text="Tierra del Fuego" Value="Tierra del Fuego" />
                                        <asp:ListItem Text="Tucuman" Value="Tucuman" />
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-6">
                                    <label for="txtCodigoPostal" class="form-label">Código Postal</label>
                                    <asp:TextBox ID="txtCodigoPostal" runat="server" CssClass="form-control" MaxLength="10" Placeholder="Ingrese el código postal"></asp:TextBox>
                                </div>
                            </div>
                            <!-- Email y Contraseña -->
                            <div class="row mb-3">
                                <div class="col-md-6">
                                    <label for="txtEmail" class="form-label">Email</label>
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" MaxLength="50" Placeholder="Ingrese el email"></asp:TextBox>
                                </div>
                                <div class="col-md-6">
                                    <label for="txtPassword" class="form-label">Contraseña</label>
                                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" MaxLength="30" Placeholder="Ingrese la contraseña"></asp:TextBox>
                                </div>
                            </div>
                            <!-- Estado y Tipo de Cliente -->
                            <div class="row mb-3">
                                <!-- Estado -->
                                <div class="col-md-6">
                                    <label for="ddlEstado" class="form-label">Estado</label>
                                    <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-select">
                                        <asp:ListItem Text="Activo" Value="true"></asp:ListItem>
                                        <asp:ListItem Text="Inactivo" Value="false"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                                <!-- Tipo de Cliente -->
                                <div class="col-md-6">
                                    <label for="ddlTipoCliente" class="form-label">Tipo de Cliente</label>
                                    <asp:DropDownList ID="ddlTipoCliente" runat="server" CssClass="form-select">
                                        <asp:ListItem Text="Administrador" Value="true"></asp:ListItem>
                                        <asp:ListItem Text="Cliente" Value="false"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
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
    <!-- Bootstrap JS -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.min.js"></script>
   
</body>
</html>
