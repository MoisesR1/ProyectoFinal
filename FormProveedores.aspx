<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FormProveedores.aspx.vb" Inherits="ProyectoFinal.FormProveedores" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    

    <h2>Inventario de Ferretería Brenes</h2>

    <asp:TextBox ID="Txt_idproveedor" Placeholder="ID" runat="server"></asp:TextBox>
    <asp:TextBox ID="Txt_empresa" Placeholder="Empresa" runat="server"></asp:TextBox>
    <asp:TextBox ID="Txt_telefono" Placeholder="Telefono" runat="server"></asp:TextBox>
    <asp:TextBox ID="Txt_direccion" Placeholder="Dirección" runat="server"></asp:TextBox>
    <asp:Button ID="Btn_Agregar" Text="Agregar Proveedor" runat="server" CssClass="btn btn-primary" OnClick="Btn_Agregar_Click"/>
    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
    <br />
    <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="id">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="empresa" HeaderText="empresa" SortExpression="empresa" />
            <asp:BoundField DataField="telefono" HeaderText="telefono" SortExpression="telefono" />
            <asp:BoundField DataField="direccion" HeaderText="direccion" SortExpression="direccion" />
        </Columns>

    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:II-46ConnectionString %>" SelectCommand="SELECT * FROM [proveedores]"></asp:SqlDataSource>
</asp:Content>