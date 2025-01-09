<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MenuAdmin.aspx.cs" Inherits="TP_FinalProgramacion3.MenuAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        iframe {
            width: 100%;
            height: calc(100vh - 64px); /* Ajusta la altura al contenido disponible, restando el header */
            border: none;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="flex h-full">
        <!-- Panel lateral -->
        <nav class="bg-blue-900 text-white w-64 py-6 px-4">
            <h2 class="text-xl font-bold mb-6">ADMINISTRADOR</h2>
            <ul class="space-y-4">
                <li>
                    <a href="Productos.aspx" target="iframeContent" class="block hover:bg-blue-700 p-2 rounded">PRODUCTOS
                    </a>
                </li>
                <li>
                    <a href="WebForm1.aspx" target="iframeContent" class="block hover:bg-blue-700 p-2 rounded">CATEGORIAS
                    </a>
                </li>
                <li>
                    <a href="Clientes.aspx" target="iframeContent" class="block hover:bg-blue-700 p-2 rounded">MARCAS
                    </a>
                </li>
                <li>
                    <a href="Proveedores.aspx" target="iframeContent" class="block hover:bg-blue-700 p-2 rounded">CLIENTES
                    </a>
                </li>
                <li>
                    <a href="Proveedores.aspx" target="iframeContent" class="block hover:bg-blue-700 p-2 rounded">PROVEEDORES
                    </a>
                </li>
                <li>
                    <a href="Proveedores.aspx" target="iframeContent" class="block hover:bg-blue-700 p-2 rounded">DETALLE DE VENTAS
                    </a>
                </li>
            </ul>
        </nav>

        <!-- Contenido principal -->
        <div class="flex-1 bg-gray-100">
            <iframe id="iframeContent" name="iframeContent" src="Bienvenida.aspx"></iframe>
        </div>
    </div>
</asp:Content>
