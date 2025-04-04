﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MenuAdmin.aspx.cs" Inherits="TP_FinalProgramacion3.MenuAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        iframe {
            width: 100%;
            height: calc(100vh - 64px);
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
                    <a href="/Admin/AdminArticulos.aspx" target="iframeContent" class="block hover:bg-blue-700 p-2 rounded">PRODUCTOS
                    </a>
                </li>
                <li>
                    <a href="/Admin/AdminCategorias.aspx" target="iframeContent" class="block hover:bg-blue-700 p-2 rounded">CATEGORIAS
                    </a>
                </li>
                <li>
                    <a href="/Admin/AdminMarcas.aspx" target="iframeContent" class="block hover:bg-blue-700 p-2 rounded">MARCAS
                    </a>
                </li>
                <li>
                    <a href="/Admin/AdminClientes.aspx" target="iframeContent" class="block hover:bg-blue-700 p-2 rounded">USUARIOS
                    </a>
                </li>
                <li>
                    <a href="/Admin/AdminProveedores.aspx" target="iframeContent" class="block hover:bg-blue-700 p-2 rounded">PROVEEDORES
                    </a>
                </li>
                <li>
                    <a href="VerCompras.aspx" target="iframeContent" class="block hover:bg-blue-700 p-2 rounded">DETALLE DE VENTAS
                    </a>
                </li>
                <li>
                    <a href="Reportes.aspx" target="iframeContent" class="block hover:bg-blue-700 p-2 rounded">REPORTES
                    </a>
                </li>
                <li>
                    <a href="MenuAdmin.aspx?cerrar=1" target="_top" class="block hover:bg-blue-700 p-2 rounded">CERRAR SESION
                    </a>
                </li>
            </ul>
        </nav>

        <!-- Contenido principal -->
        <div class="flex-1 bg-gray-100">
            <iframe id="iframeContent" name="iframeContent" src="/Admin/AdminArticulos.aspx"></iframe>
        </div>
    </div>
</asp:Content>
