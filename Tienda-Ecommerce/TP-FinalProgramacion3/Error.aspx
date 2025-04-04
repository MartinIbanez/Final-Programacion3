﻿<%@ Page Title="Error" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="TP_FinalProgramacion3.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .error-container {
            text-align: center;
            margin-top: 50px;
            font-family: Arial, sans-serif;
        }

        .error-container h1 {
            font-size: 3rem;
            color: #ff4757;
        }

        .error-container h3 {
            font-size: 1.8rem;
            color: #2f3542;
        }

        .error-container p {
            font-size: 1.2rem;
            color: #57606f;
            margin-bottom: 30px;
        }

        .error-container img {
            width: 150px;
            margin-bottom: 20px;
        }

        .error-container a {
            text-decoration: none;
            color: white;
            background-color: #1e90ff;
            padding: 10px 20px;
            border-radius: 5px;
            font-size: 1.2rem;
        }

        .error-container a:hover {
            background-color: #3742fa;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="error-container">
        <img src="https://via.placeholder.com/150?text=Error" alt="Error Icon" />
        <h1>¡Ups! Algo salió mal.</h1>
        <h3>Error inesperado</h3>
        <p>Lo sentimos, ha ocurrido un error mientras procesábamos tu solicitud.</p>
        <p>
            <asp:Label ID="lblError" runat="server" Text="Detalles del error aquí"></asp:Label>
        </p>
        <a href="Default.aspx">Volver a la página principal</a>
    </div>
</asp:Content>
