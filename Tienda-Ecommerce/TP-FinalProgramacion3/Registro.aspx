<%@ Page Title="Registro de Clientes" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="TP_FinalProgramacion3.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <section class="flex items-center justify-center min-h-screen bg-gray-100">
    <div class="w-full max-w-md bg-white rounded-lg shadow-lg p-8">
      <h2 class="text-3xl font-bold text-blue-800 text-center">Registro de Clientes</h2>

      <!-- Formulario de registro -->
      <form id="formRegistro" runat="server" method="post" class="mt-6 space-y-6">

        <!-- Campo de DNI -->
        <div>
          <label for="txtDNI" class="block text-sm font-medium text-slate-600">DNI</label>
          <asp:TextBox 
            ID="txtDNI" 
            runat="server" 
            placeholder="Ingrese su DNI" 
            CssClass="w-full mt-1 px-4 py-2 bg-slate-200 border border-slate-300 rounded-md text-slate-700 placeholder-slate-500 focus:outline-none focus:ring-2 focus:ring-blue-500" />
        </div>

        <!-- Campo de Nombre -->
        <div>
          <label for="txtNombre" class="block text-sm font-medium text-slate-600">Nombre</label>
          <asp:TextBox 
            ID="txtNombre" 
            runat="server" 
            placeholder="Ingrese su nombre" 
            CssClass="w-full mt-1 px-4 py-2 bg-slate-200 border border-slate-300 rounded-md text-slate-700 placeholder-slate-500 focus:outline-none focus:ring-2 focus:ring-blue-500" />
        </div>

        <!-- Campo de Apellido -->
        <div>
          <label for="txtApellido" class="block text-sm font-medium text-slate-600">Apellido</label>
          <asp:TextBox 
            ID="txtApellido" 
            runat="server" 
            placeholder="Ingrese su apellido" 
            CssClass="w-full mt-1 px-4 py-2 bg-slate-200 border border-slate-300 rounded-md text-slate-700 placeholder-slate-500 focus:outline-none focus:ring-2 focus:ring-blue-500" />
        </div>

        <!-- Campo de Dirección -->
        <div>
          <label for="txtDireccion" class="block text-sm font-medium text-slate-600">Dirección</label>
          <asp:TextBox 
            ID="txtDireccion" 
            runat="server" 
            placeholder="Ingrese su dirección" 
            CssClass="w-full mt-1 px-4 py-2 bg-slate-200 border border-slate-300 rounded-md text-slate-700 placeholder-slate-500 focus:outline-none focus:ring-2 focus:ring-blue-500" />
        </div>

        <!-- Campo de Provincia -->
        <div>
          <label for="ddlProvincia" class="block text-sm font-medium text-slate-600">Provincia</label>
          <asp:DropDownList 
            ID="ddlProvincia" 
            runat="server" 
            CssClass="w-full mt-1 px-4 py-2 bg-slate-200 border border-slate-300 rounded-md text-slate-700 placeholder-slate-500 focus:outline-none focus:ring-2 focus:ring-blue-500">
            <asp:ListItem Text="Seleccione una provincia" Value="" />
            <asp:ListItem Text="Buenos Aires" Value="Buenos Aires" />
            <asp:ListItem Text="Córdoba" Value="Córdoba" />
            <asp:ListItem Text="Santa Fe" Value="Santa Fe" />
            <asp:ListItem Text="Mendoza" Value="Mendoza" />
            <asp:ListItem Text="Salta" Value="Salta" />
          </asp:DropDownList>
        </div>

        <!-- Campo de Código Postal -->
        <div>
          <label for="txtCodigoPostal" class="block text-sm font-medium text-slate-600">Código Postal</label>
          <asp:TextBox 
            ID="txtCodigoPostal" 
            runat="server" 
            placeholder="Ingrese su código postal" 
            CssClass="w-full mt-1 px-4 py-2 bg-slate-200 border border-slate-300 rounded-md text-slate-700 placeholder-slate-500 focus:outline-none focus:ring-2 focus:ring-blue-500" />
        </div>

        <!-- Campo de Email -->
        <div>
          <label for="txtEmail" class="block text-sm font-medium text-slate-600">Email</label>
          <asp:TextBox 
            ID="txtEmail" 
            runat="server" 
            TextMode="Email" 
            placeholder="Ingrese su email" 
            CssClass="w-full mt-1 px-4 py-2 bg-slate-200 border border-slate-300 rounded-md text-slate-700 placeholder-slate-500 focus:outline-none focus:ring-2 focus:ring-blue-500" />
        </div>

        <!-- Campo de Contraseña -->
        <div>
          <label for="txtPassword" class="block text-sm font-medium text-slate-600">Contraseña</label>
          <asp:TextBox 
            ID="txtPassword" 
            runat="server" 
            TextMode="Password" 
            placeholder="Ingrese su contraseña" 
            CssClass="w-full mt-1 px-4 py-2 bg-slate-200 border border-slate-300 rounded-md text-slate-700 placeholder-slate-500 focus:outline-none focus:ring-2 focus:ring-blue-500" />
        </div>

        <!-- Botón de Registrar -->
        <div>
          <asp:Button 
            ID="btnRegistrar" 
            runat="server" 
            Text="Registrar" 
            CssClass="w-full py-2 bg-blue-600 hover:bg-blue-700 text-white font-medium rounded-md transition" 
            OnClick="btnRegistrar_Click" />
        </div>
      </form>

      <!-- Enlace para iniciar sesión -->
      <p class="mt-4 text-center text-sm text-slate-600">
        ¿Ya tienes una cuenta? 
        <a href="Login.aspx" class="text-blue-600 hover:underline">Inicia sesión</a>.
      </p>
    </div>
  </section>
</asp:Content>

