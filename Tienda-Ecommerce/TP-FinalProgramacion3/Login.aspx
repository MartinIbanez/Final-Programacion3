<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TP_FinalProgramacion3.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<section class="flex items-center justify-center min-h-screen bg-gray-100">
  <div class="w-full max-w-md bg-slate-800 rounded-lg shadow-lg p-8">
    <h2 class="text-3xl font-bold text-white text-center">Iniciar sesión</h2>
    
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

    <form action="#" method="post" class="mt-6 space-y-4">
      <!-- Email Field -->
      <div>
        <label for="UserEmail" class="block text-sm font-medium text-slate-400">
          Email
        </label>
        <input 
          type="email" 
          id="UserEmail" 
          name="mail" 
          placeholder="Ingrese su email" 
          class="w-full mt-1 px-4 py-2 bg-slate-900 border border-slate-700 rounded-md text-white placeholder-slate-500 focus:outline-none focus:ring-2 focus:ring-blue-500"
        />
      </div>

      <!-- Password Field -->
      <div>
        <label for="Password" class="block text-sm font-medium text-slate-400">
          Contraseña
        </label>
        <input 
          type="password" 
          id="Password" 
          name="password" 
          placeholder="Ingrese su contraseña" 
          class="w-full mt-1 px-4 py-2 bg-slate-900 border border-slate-700 rounded-md text-white placeholder-slate-500 focus:outline-none focus:ring-2 focus:ring-blue-500"
        />
      </div>

      <!-- Submit Button -->
      <div>
        <button 
          type="submit" 
          class="w-full py-2 bg-blue-600 hover:bg-blue-700 text-white font-medium rounded-md transition">
          Iniciar sesión
        </button>
      </div>
    </form>

    <p class="mt-4 text-center text-sm text-slate-400">
      ¿No tienes una cuenta? 
      <a href="/Registro.aspx" class="text-blue-400 hover:underline">
        Regístrate
      </a>.
    </p>
  </div>
</section>

</asp:Content>