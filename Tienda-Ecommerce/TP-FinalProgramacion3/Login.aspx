<%@ Page Title="Iniciar sesión" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TP_FinalProgramacion3.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="flex items-center justify-center min-h-screen bg-gray-100">
        <div class="w-full max-w-md bg-white rounded-lg shadow-lg p-8">
            <h2 class="text-3xl font-bold text-blue-800 text-center">Iniciar sesión</h2>

            <!-- Formulario de inicio de sesión -->
            <form id="formLogin" runat="server" method="post" class="mt-6 space-y-6">
                <!-- Campo de Email -->
                <div>
                    <label for="UserEmail" class="block text-sm font-medium text-slate-600">Email</label>
                    <asp:TextBox
                        ID="UserEmail"
                        runat="server"
                        placeholder="Ingrese su email"
                        CssClass="w-full mt-1 px-4 py-2 bg-slate-200 border border-slate-300 rounded-md text-slate-700 placeholder-slate-500 focus:outline-none focus:ring-2 focus:ring-blue-500" />
                </div>

                <!-- Campo de Contraseña -->
                <div>
                    <label for="Password" class="block text-sm font-medium text-slate-600">Contraseña</label>
                    <asp:TextBox
                        ID="Password"
                        runat="server"
                        TextMode="Password"
                        placeholder="Ingrese su contraseña"
                        CssClass="w-full mt-1 px-4 py-2 bg-slate-200 border border-slate-300 rounded-md text-slate-700 placeholder-slate-500 focus:outline-none focus:ring-2 focus:ring-blue-500" />
                </div>

                <!-- Botón de Enviar -->
                <div>
                    <asp:Button
                        ID="btnLogin"
                        runat="server"
                        Text="Iniciar sesión"
                        CssClass="w-full py-2 bg-blue-600 hover:bg-blue-700 text-white font-medium rounded-md transition"
                        OnClick="btnLogin_Click" />
                </div>
            </form>

            <!-- Enlace para registro -->
            <p class="mt-4 text-center text-sm text-slate-600">
                ¿No tienes una cuenta? 
       
                <a href="Registro.aspx" class="text-blue-600 font-bold hover:underline">Regístrate como cliente</a>.
     
            </p>
            
            <asp:Label ID="MensajeLogin" runat="server" class="mt-4 text-center text-l text-red-600 font-bold" Text=""></asp:Label>

        </div>
    </section>
</asp:Content>
