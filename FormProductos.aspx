<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FormProductos.aspx.vb" Inherits="ProyectoFinal.FormProductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <asp:hiddenField ID="editando" runat="server" />
     <h2>Inventario de Ferreteria Brenes</h2>

    <asp:TextBox ID="Txt_id" Placeholder="ID" runat="server"></asp:TextBox>
    <asp:TextBox ID="Txt_descripcion" Placeholder="Descripcion" runat="server"></asp:TextBox>
    <asp:TextBox ID="Txt_precio" Placeholder="Precio" runat="server"></asp:TextBox>
    <asp:TextBox ID="Txt_cantidad" Placeholder="Cantidad" runat="server"></asp:TextBox>
    <asp:Button ID="Btn_Agregar" Text="Agregar Producto" runat="server" OnClick="Btn_Agregar_Click" />
    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
    <br />
    <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="False" DataKeyNames="IDproducto" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="IDproducto" HeaderText="IDproducto" InsertVisible="False" ReadOnly="True" SortExpression="IDproducto" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
            <asp:BoundField DataField="Precio" HeaderText="Precio" SortExpression="Precio" />
            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" />
        </Columns>

    </asp:GridView>

     
     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:II-46ConnectionString %>" SelectCommand="SELECT * FROM [Productos]"></asp:SqlDataSource>

     
</asp:Content>
