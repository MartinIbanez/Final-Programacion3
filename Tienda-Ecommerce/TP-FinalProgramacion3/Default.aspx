<%@ Page Title="Página Principal" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TP_FinalProgramacion3.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* Estilo general */
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
        }

        /* Banner */
        .banner {
            text-align: center;
            background: url('https://via.placeholder.com/1200x400') no-repeat center center;
            background-size: cover;
            color: white;
            padding: 50px 20px;
        }
        .banner h1 {
            font-size: 2.5em;
            margin: 0 0 10px;
        }
        .banner p {
            font-size: 1.2em;
        }

        /* Sección de productos más vendidos */
        .productos-mas-vendidos {
            padding: 20px;
            background-color: #f9f9f9;
        }
        .productos-mas-vendidos h2 {
            text-align: center;
            margin-bottom: 20px;
        }
        .productos-grid {
            display: grid;
            grid-template-columns: repeat(auto-fit, minmax(200px, 1fr));
            gap: 20px;
            margin: 0 auto;
            max-width: 1200px;
        }
        .producto-card {
            border: 1px solid #ddd;
            border-radius: 5px;
            padding: 10px;
            text-align: center;
            background-color: white;
            box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
        }
        .producto-card img {
            max-width: 100%;
            border-radius: 5px;
            margin-bottom: 10px;
        }
        .producto-card h3 {
            font-size: 1.1em;
            margin: 0 0 10px;
        }
        .producto-card p {
            color: #007bff;
            font-weight: bold;
            margin: 0 0 10px;
        }
        .ver-mas {
            text-align: center;
            margin-top: 20px;
        }
        .btn-ver-mas {
            display: inline-block;
            padding: 10px 20px;
            background-color: #007bff;
            color: white;
            text-decoration: none;
            border-radius: 5px;
        }
        .btn-ver-mas:hover {
            background-color: #0056b3;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Banner -->
    <div class="banner">
        <h1>¡Bienvenido a nuestro Ecommerce Deportivo!</h1>
        <p>Encuentra los mejores productos para tu deporte favorito.</p>
    </div>

    
    
    

    <!-- Productos más vendidos -->
    <div class="productos-mas-vendidos">
        <h2>Productos más vendidos</h2>
        <div class="productos-grid">
            <asp:Repeater ID="rptArt" runat="server">
                <ItemTemplate>
                    <div class="producto-card">
                        <img src=<%#Eval("UrlImagen") %>>
                        <h3><%#Eval("Nombre") %></h3>
                        <p><%#Eval("Precio") %></p>
                    </div>
                </ItemTemplate>

            </asp:Repeater>
            
        </div>
        <div class="ver-mas">
            <a href="#" class="btn-ver-mas">Ver más productos</a>
        </div>
    </div>
        </form>
</asp:Content>