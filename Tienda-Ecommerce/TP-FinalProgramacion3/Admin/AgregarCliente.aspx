﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarCliente.aspx.cs" Inherits="TP_FinalProgramacion3.Admin.AgregarCliente" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <title>Agregar Cliente</title>
</head>
<body class="bg-light">
    <form id="formAgregarCliente" runat="server">
        <div class="container py-5">
            <div class="row justify-content-center">
                <div class="col-md-6">
                    <div class="card shadow-lg">
                        <div class="card-header bg-primary text-white text-center">
                            <h3>Agregar Cliente</h3>
                        </div>
                        <div class="card-body">
                            <!-- Campo de DNI -->
                            <div class="mb-3">
                                <label for="txtDNI" class="form-label">DNI</label>
                                <asp:TextBox
                                    ID="txtDNI"
                                    runat="server"
                                    placeholder="Ingrese el DNI"
                                    CssClass="form-control" />
                            </div>

                            <!-- Campo de Nombre -->
                            <div class="mb-3">
                                <label for="txtNombre" class="form-label">Nombre</label>
                                <asp:TextBox
                                    ID="txtNombre"
                                    runat="server"
                                    placeholder="Ingrese el nombre"
                                    CssClass="form-control" />
                            </div>

                            <!-- Campo de Apellido -->
                            <div class="mb-3">
                                <label for="txtApellido" class="form-label">Apellido</label>
                                <asp:TextBox
                                    ID="txtApellido"
                                    runat="server"
                                    placeholder="Ingrese el apellido"
                                    CssClass="form-control" />
                            </div>

                            <!-- Campo de Dirección -->
                            <div class="mb-3">
                                <label for="txtDireccion" class="form-label">Dirección</label>
                                <asp:TextBox
                                    ID="txtDireccion"
                                    runat="server"
                                    placeholder="Ingrese la dirección"
                                    CssClass="form-control" />
                            </div>

                            <!-- Campo de Provincia -->
                            <div class="mb-3">
                                <label for="ddlProvincia" class="form-label">Provincia</label>
                                <asp:DropDownList
                                    ID="ddlProvincia"
                                    runat="server"
                                    CssClass="form-select">
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
                                    <asp:ListItem Text="L Rioja" Value="La Rioja" />
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

                            <!-- Campo de Código Postal -->
                            <div class="mb-3">
                                <label for="txtCodigoPostal" class="form-label">Código Postal</label>
                                <asp:TextBox
                                    ID="txtCodigoPostal"
                                    runat="server"
                                    placeholder="Ingrese el código postal"
                                    CssClass="form-control" />
                            </div>

                            <!-- Campo de Email -->
                            <div class="mb-3">
                                <label for="txtEmail" class="form-label">Email</label>
                                <asp:TextBox
                                    ID="txtEmail"
                                    runat="server"
                                    TextMode="Email"
                                    placeholder="Ingrese el email"
                                    CssClass="form-control" />
                            </div>

                            <!-- Campo de Contraseña -->
                            <div class="mb-3">
                                <label for="txtPassword" class="form-label">Contraseña</label>
                                <asp:TextBox
                                    ID="txtPassword"
                                    runat="server"
                                    TextMode="Password"
                                    placeholder="Ingrese la contraseña"
                                    CssClass="form-control" />
                            </div>

                            <!-- Botón de Agregar -->
                            <div class="d-grid">
                                <asp:Button
                                    ID="btnAgregar"
                                    runat="server"
                                    Text="Agregar Cliente"
                                    CssClass="btn btn-primary"
                                    OnClick="btnAgregar_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>