<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Administrador.aspx.vb" Inherits="ProyectoFinal.Administrador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<div class="container mt-4">
    <h2 class="mb-4">Productos y Proveedores</h2>

    <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover">
        <Columns>
            <asp:BoundField DataField="IDproducto" HeaderText="ID" />
            <asp:BoundField DataField="Descripcion" HeaderText="Producto" />
            <asp:BoundField DataField="precio" HeaderText="Precio" DataFormatString="{0:C}" />
            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
            <asp:BoundField DataField="proveedor_id" HeaderText="Proveedor" />
        </Columns>
    </asp:GridView>
</div>
    <div class="container mt-5">
    <h4>Agregar Nuevo Producto</h4>
    <div class="row g-3">
        <div class="col-md-4">
            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" placeholder="Descripción"></asp:TextBox>
        </div>
        <div class="col-md-2">
            <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" placeholder="Precio"></asp:TextBox>
        </div>
        <div class="col-md-2">
            <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control" placeholder="Cantidad"></asp:TextBox>
        </div>
        <div class="col-md-3">
            <asp:DropDownList ID="ddlProveedores" runat="server" CssClass="form-select"></asp:DropDownList>
        </div>
        <div class="col-md-1">
            
        </div>
    </div>
</div>


</asp:Content>
