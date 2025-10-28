<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FormProductos.aspx.vb" Inherits="ProyectoFinal.FormProductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <asp:hiddenField ID="editando" runat="server" Visible="true" />
     <h2>Inventario de Ferreteria Brenes</h2>

    <style>
        .btn-hover-move {
            transition: transform 0.5s ease, box-shadow 0.2s;
        }
        .btn-hover-move:hover{
            transform: translate(-4px) scale(1.04);
            box-shadow: 0 6px 18px rgb(0 148 255);
        }
    </style>

    <div class="container d-flex flex-column mb-3 gap-2">

    <asp:TextBox ID="Txt_idproducto" CssClass="form-control" Placeholder="ID" runat="server"></asp:TextBox>
    <asp:TextBox ID="Txt_descripcion" CssClass="form-control" Placeholder="Descripcion" runat="server"></asp:TextBox>
    <asp:TextBox ID="Txt_precio" CssClass="form-control" Placeholder="Precio" runat="server"></asp:TextBox>
    <asp:TextBox ID="Txt_cantidad" CssClass="form-control" Placeholder="Cantidad" runat="server"></asp:TextBox>
    <asp:Button ID="Btn_Agregar" Text="Agregar Producto" runat="server" CssClass="btn btn-primary" OnClick="Btn_Agregar_Click" />
    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
    </div>

    <br />
    <asp:GridView ID="gvProductos" CssClass="table table-striped table-group-divider table-success" runat="server" AutoGenerateColumns="False" DataKeyNames="IDproducto" 
        DataSourceID="SqlDataSource1" OnRowDeleting="gvProductos_RowDeleting" OnRowEditing="gvProductos_RowEditing" OnRowCancelingEdit="gvProductos_RowCancelingEdit" OnRowUpdating="gvProductos_RowUpdating" OnSelectedIndexChanged="gvProductos_SelectedIndexChanged">
        <Columns>
            <asp:CommandField ShowEditButton="True" ControlStyle-CssClass="btn btn-secondary"/>
            <asp:BoundField DataField="IDproducto" HeaderText="IDproducto" InsertVisible="False" ReadOnly="True" SortExpression="IDproducto" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
            <asp:BoundField DataField="Precio" HeaderText="Precio" SortExpression="Precio" />
            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" />
            <asp:CommandField ShowDeleteButton="True" ControlStyle-CssClass="btn btn-danger"/>
        </Columns>

    </asp:GridView>

     
     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:II-46ConnectionString %>" SelectCommand="SELECT * FROM [Productos]"></asp:SqlDataSource>

     
</asp:Content>
