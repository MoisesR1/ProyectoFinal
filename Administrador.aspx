<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Administrador.aspx.vb" Inherits="ProyectoFinal.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2 class="text-center mb-4 fw-bold">Panel de Administración - Ferretería Brenes</h2>

    <div class="container">

        <div class="card shadow-sm mb-4">
            <div class="card-header bg-primary text-white">
                <i class="bi bi-search"></i> Buscar Producto
            </div>

            <div class="card-body">

                <div class="row g-3 align-items-end">

                    <div class="col-md-6">
                        <label class="form-label">Producto</label>
                        <asp:DropDownList ID="ddlProductos" CssClass="form-select" runat="server"></asp:DropDownList>
                    </div>

                    <div class="col-md-3">
                        <asp:Button ID="BtnBusqueda" CssClass="btn btn-primary mt-2" Text="Buscar" runat="server" />
                    </div>

                </div>

                <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger fw-bold mt-2"></asp:Label>

            </div>
        </div>

   
        <asp:GridView ID="gvAdmin" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" ShowHeader="true">
            <Columns>
                <asp:BoundField DataField="IDproducto" HeaderText="ID Producto" ReadOnly="True" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="{0:N}" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                <asp:BoundField DataField="NombreProveedor" HeaderText="Proveedor" />
            </Columns>
        </asp:GridView>

    </div>

</asp:Content>






