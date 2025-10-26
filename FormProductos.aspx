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
    <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductoID" OnRowEditing="gvProductos_RowEditing" OnRowCancelingEdit="gvProductos_RowCancelingEdit" OnRowUpdating="gvProductos_RowUpdating" OnRowDeleting="gvProductos_RowDeleting">
        <Columns>
            <asp:BoundField DataField="ProductoID" HeaderText="ID" ReadOnly="True" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
            <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="{0:C}" />
            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
        </Columns>
        <asp:SqlDataSource ID="SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:II-46ConnectionString %>" ProviderName="<%$ ConnectionStrings:II-46ConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [Productos]"></asp:SqlDataSource>
    </asp:GridView>
</asp:Content>
