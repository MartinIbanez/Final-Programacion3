<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="TP_FinalProgramacion3.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<section class="flex items-center justify-center min-h-screen bg-gray-100">
  <div class="w-full max-w-2xl bg-slate-800 rounded-lg shadow-lg p-8">
    <h2 class="text-3xl font-bold text-white text-center">Registro</h2>

    <% if (Session["Msg_error"] != null) { %>
      <div class="bg-red-500 text-white text-sm font-medium rounded-md p-3 mt-4">
        <%= Session["Msg_error"] %>
        <% Session["Msg_error"] = null; %>
      </div>
    <% } %>
    
    <% if (Session["Msg_ok"] != null) { %>
      <div class="bg-green-500 text-white text-sm font-medium rounded-md p-3 mt-4">
        <%= Session["Msg_ok"] %>
        <% Session["Msg_ok"] = null; %>
      </div>
    <% } %>

    <!-- Campos del formulario -->
    <div class="mt-6 grid grid-cols-2 gap-6">
      <!-- DNI -->
      <div>
        <label for="DNI" class="block text-sm font-medium text-slate-400">DNI</label>
        <asp:TextBox 
          ID="txtDNI" 
          runat="server" 
          CssClass="w-full mt-1 px-4 py-2 bg-slate-900 border border-slate-700 rounded-md text-white placeholder-slate-500 focus:outline-none focus:ring-2 focus:ring-blue-500" 
          placeholder="Ingrese su DNI"></asp:TextBox>
      </div>

      <!-- Nombre -->
      <div>
        <label for="Nombre" class="block text-sm font-medium text-slate-400">Nombre</label>
        <asp:TextBox 
          ID="txtNombre" 
          runat="server" 
          CssClass="w-full mt-1 px-4 py-2 bg-slate-900 border border-slate-700 rounded-md text-white placeholder-slate-500 focus:outline-none focus:ring-2 focus:ring-blue-500" 
          placeholder="Ingrese su nombre"></asp:TextBox>
      </div>

      <!-- Apellido -->
      <div>
        <label for="Apellido" class="block text-sm font-medium text-slate-400">Apellido</label>
        <asp:TextBox 
          ID="txtApellido" 
          runat="server" 
          CssClass="w-full mt-1 px-4 py-2 bg-slate-900 border border-slate-700 rounded-md text-white placeholder-slate-500 focus:outline-none focus:ring-2 focus:ring-blue-500" 
          placeholder="Ingrese su apellido"></asp:TextBox>
      </div>

      <!-- Dirección -->
      <div>
        <label for="Direccion" class="block text-sm font-medium text-slate-400">Dirección</label>
        <asp:TextBox 
          ID="txtDireccion" 
          runat="server" 
          CssClass="w-full mt-1 px-4 py-2 bg-slate-900 border border-slate-700 rounded-md text-white placeholder-slate-500 focus:outline-none focus:ring-2 focus:ring-blue-500" 
          placeholder="Ingrese su dirección"></asp:TextBox>
      </div>

      <!-- Provincia -->
      <div>
        <label for="Provincia" class="block text-sm font-medium text-slate-400">Provincia</label>
        <asp:DropDownList 
          ID="ddlProvincia" 
          runat="server" 
          CssClass="w-full mt-1 px-4 py-2 bg-slate-900 border border-slate-700 rounded-md text-white focus:outline-none focus:ring-2 focus:ring-blue-500">
          <asp:ListItem Text="Seleccione una provincia" Value="" />
          <asp:ListItem Text="Buenos Aires" Value="Buenos Aires" />
          <asp:ListItem Text="Córdoba" Value="Córdoba" />
          <asp:ListItem Text="Santa Fe" Value="Santa Fe" />
         
        </asp:DropDownList>
      </div>

      <!-- Código Postal -->
      <div>
        <label for="CodigoPostal" class="block text-sm font-medium text-slate-400">Código Postal</label>
        <asp:TextBox 
          ID="txtCodigoPostal" 
          runat="server" 
          CssClass="w-full mt-1 px-4 py-2 bg-slate-900 border border-slate-700 rounded-md text-white placeholder-slate-500 focus:outline-none focus:ring-2 focus:ring-blue-500" 
          placeholder="Ingrese su código postal"></asp:TextBox>
      </div>

      <!-- Email -->
      <div>
        <label for="Email" class="block text-sm font-medium text-slate-400">Email</label>
        <asp:TextBox 
          ID="txtEmail" 
          runat="server" 
          CssClass="w-full mt-1 px-4 py-2 bg-slate-900 border border-slate-700 rounded-md text-white placeholder-slate-500 focus:outline-none focus:ring-2 focus:ring-blue-500" 
          placeholder="Ingrese su email"></asp:TextBox>
      </div>

      <!-- Contraseña -->
      <div>
        <label for="Password" class="block text-sm font-medium text-slate-400">Contraseña</label>
        <asp:TextBox 
          ID="txtPassword" 
          runat="server" 
          TextMode="Password" 
          CssClass="w-full mt-1 px-4 py-2 bg-slate-900 border border-slate-700 rounded-md text-white placeholder-slate-500 focus:outline-none focus:ring-2 focus:ring-blue-500" 
          placeholder="Ingrese su contraseña"></asp:TextBox>
      </div>

      <!-- Botón Registrar -->
      <div class="col-span-2">
        <asp:Button 
          ID="btnRegistrar" 
          runat="server" 
          CssClass="w-full py-2 bg-blue-600 hover:bg-blue-700 text-white font-medium rounded-md transition" 
          Text="Registrarse" 
          OnClick="btnRegistrar_Click" />
      </div>
    </div>
  </div>
</section>

</asp:Content>