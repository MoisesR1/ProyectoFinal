<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FormProveedores.aspx.vb" Inherits="ProyectoFinal.FormProveedores" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    

    <h2>Inventario de Ferretería Brenes</h2>

<asp:TextBox ID="Txt_idproveedor" Placeholder="ID (auto)" runat="server" ReadOnly="true" CssClass="form-control mb-2 w-25"></asp:TextBox>
<asp:TextBox ID="Txt_empresa" Placeholder="Empresa" runat="server" CssClass="form-control mb-2 w-25"></asp:TextBox>
<asp:TextBox ID="Txt_telefono" Placeholder="Teléfono" runat="server" CssClass="form-control mb-2 w-25"></asp:TextBox>
<asp:TextBox ID="Txt_direccion" Placeholder="Dirección" runat="server" CssClass="form-control mb-2 w-25"></asp:TextBox>

<asp:Button ID="Btn_Agregar" Text="Agregar Proveedor" runat="server" CssClass="btn btn-primary mb-3" OnClick="Btn_Agregar_Click" />
<asp:Label ID="lblMensaje" runat="server" Text="" CssClass="text-success d-block mb-3"></asp:Label>

<asp:GridView 
    ID="gvProveedores" 
    runat="server" 
    AutoGenerateColumns="False" 
    DataSourceID="SqlDataSource1" 
    DataKeyNames="id"
    CssClass="table table-bordered table-hover text-center"
    HeaderStyle-CssClass="table-dark">

    <Columns>
        <asp:CommandField ShowEditButton="true" ControlStyle-CssClass="btn btn-sm btn-primary me-1" EditText="Editar" UpdateText="Guardar" CancelText="Cancelar" />
        <asp:BoundField DataField="id" HeaderText="ID" ReadOnly="True" SortExpression="id" />
        <asp:BoundField DataField="empresa" HeaderText="Empresa" SortExpression="empresa" />
        <asp:BoundField DataField="telefono" HeaderText="Teléfono" SortExpression="telefono" />
        <asp:BoundField DataField="direccion" HeaderText="Dirección" SortExpression="direccion" />
        <asp:CommandField ShowDeleteButton="true" ControlStyle-CssClass="btn btn-sm btn-danger" DeleteText="Eliminar"/>
    </Columns>
</asp:GridView>

<asp:SqlDataSource 
    ID="SqlDataSource1" 
    runat="server" 
    ConnectionString="<%$ ConnectionStrings:II-46ConnectionString %>" 
    SelectCommand="SELECT * FROM proveedores"
    DeleteCommand="DELETE FROM proveedores WHERE id = @id"
    UpdateCommand="UPDATE proveedores SET empresa = @empresa, telefono = @telefono, direccion = @direccion WHERE id = @id">
    <DeleteParameters>
        <asp:Parameter Name="id" Type="Int32" />
    </DeleteParameters>
    <UpdateParameters>
        <asp:Parameter Name="empresa" Type="String" />
        <asp:Parameter Name="telefono" Type="String" />
        <asp:Parameter Name="direccion" Type="String" />
        <asp:Parameter Name="id" Type="Int32" />
    </UpdateParameters>
</asp:SqlDataSource>


</asp:Content>