﻿using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_FinalProgramacion3.Admin
{
    public partial class AdminClientes : System.Web.UI.Page
    {     
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarClientes();
            }
        }

        private void CargarClientes()
        {
            ClienteNegocio catCliente = new ClienteNegocio();

            try
            {
                List<Cliente> ListaClientes = catCliente.ClientesListado();

                rptClientes.DataSource = ListaClientes;
                rptClientes.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al cargar los clientes: " + ex.Message;
                lblError.Visible = true;
            }
        }

        protected void rptClientes_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                string dniCliente = e.CommandArgument.ToString(); 

                if (e.CommandName == "Editar")
                {
                    Response.Redirect("AgregarCliente.aspx?dni=" + dniCliente);
                }
                else if (e.CommandName == "Eliminar")
                {
                    ClienteNegocio clienteNegocio = new ClienteNegocio();

                    clienteNegocio.EliminarCliente(dniCliente); 

                    CargarClientes();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al ejecutar la acción: " + ex.Message;
                lblError.Visible = true;
            }
        }

        protected void btnAgregarCliente_Click(object sender, EventArgs e)
        {           
            Response.Redirect("AgregarCliente.aspx");
        }
    }
}