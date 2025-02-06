<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="TP_FinalProgramacion3.Perfil" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Perfil del Cliente</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <div class="card shadow">
                <div class="card-header text-center">
                    <h2>DATOS DE TU PERFIL</h2>
                </div>
                <div class="card-body">
                    <div class="row mb-3">
                        <label class="col-sm-3 col-form-label"><strong>DNI:</strong></label>
                        <div class="col-sm-9">
                            <asp:Label ID="lblDni" runat="server" CssClass="form-control-plaintext" />
                        </div>
                    </div>
                    <div class="row mb-3">
                        <label class="col-sm-3 col-form-label"><strong>Nombre:</strong></label>
                        <div class="col-sm-9">
                            <asp:Label ID="lblNombre" runat="server" CssClass="form-control-plaintext" />
                        </div>
                    </div>
                    <div class="row mb-3">
                        <label class="col-sm-3 col-form-label"><strong>Apellido:</strong></label>
                        <div class="col-sm-9">
                            <asp:Label ID="lblApellido" runat="server" CssClass="form-control-plaintext" />
                        </div>
                    </div>
                    <div class="row mb-3">
                        <label class="col-sm-3 col-form-label"><strong>Dirección:</strong></label>
                        <div class="col-sm-9">
                            <asp:Label ID="lblDireccion" runat="server" CssClass="form-control-plaintext" />
                        </div>
                    </div>
                    <div class="row mb-3">
                        <label class="col-sm-3 col-form-label"><strong>Provincia:</strong></label>
                        <div class="col-sm-9">
                            <asp:Label ID="lblProvincia" runat="server" CssClass="form-control-plaintext" />
                        </div>
                    </div>
                    <div class="row mb-3">
                        <label class="col-sm-3 col-form-label"><strong>Código Postal:</strong></label>
                        <div class="col-sm-9">
                            <asp:Label ID="lblCodPostal" runat="server" CssClass="form-control-plaintext" />
                        </div>
                    </div>
                    <div class="row mb-3">
                        <label class="col-sm-3 col-form-label"><strong>Email:</strong></label>
                        <div class="col-sm-9">
                            <asp:Label ID="lblEmail" runat="server" CssClass="form-control-plaintext" />
                        </div>
                    </div>
                    <div class="row mb-3">
                        <label class="col-sm-3 col-form-label"><strong>Contraseña:</strong></label>
                        <div class="col-sm-9">
                            <asp:Label ID="lblPassword" runat="server" CssClass="form-control-plaintext" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>