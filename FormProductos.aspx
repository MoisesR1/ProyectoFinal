<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FormProductos.aspx.vb" Inherits="ProyectoFinal.FormProductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <asp:hiddenField ID="editando" runat="server" Visible="true" />
<h2 class="text-center mb-4 fw-bold">Inventario - Ferretería Brenes</h2>

<style>
    .btn-hover-move {
        transition: transform 0.25s ease, box-shadow 0.2s;
    }
    .btn-hover-move:hover {
        transform: translateY(-3px) scale(1.04);
        box-shadow: 0 6px 18px rgba(0, 148, 255, 0.5);
    }
</style>

<div class="container">

    <div class="card shadow-sm mb-4">
        <div class="card-header bg-primary text-white">
            <i class="bi bi-plus-circle"></i> Agregar Producto
        </div>

        <div class="card-body">

            <div class="row g-3">

                <asp:TextBox ID="Txt_idproducto" CssClass="form-control" Visible="false"
                    Placeholder="ID" runat="server"></asp:TextBox>

                <div class="col-md-4">
                    <label class="form-label">Descripción</label>
                    <asp:TextBox ID="Txt_descripcion" CssClass="form-control" Placeholder="Descripción" runat="server"></asp:TextBox>
                </div>

                <div class="col-md-4">
                    <label class="form-label">Precio</label>
                    <asp:TextBox ID="Txt_precio" CssClass="form-control" Placeholder="Precio" runat="server" TextMode="Number"></asp:TextBox>
                </div>

                <div class="col-md-4">
                    <label class="form-label">Cantidad</label>
                    <asp:TextBox ID="Txt_cantidad" CssClass="form-control" Placeholder="Cantidad" runat="server" TextMode="Number"></asp:TextBox>
                </div>

            </div>

            <div class="mt-3 text-end">
                <asp:Button ID="Btn_Agregar" Text="Agregar Producto" runat="server"
                    CssClass="btn btn-primary btn-hover-move px-4"
                    OnClick="Btn_Agregar_Click" />
            </div>

            <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger fw-bold mt-2"></asp:Label>

        </div>
    </div>

</div>


    <br />
    <asp:GridView ID="gvProductos" CssClass="table table-striped table-hover table-bordered align-middle" runat="server" AutoGenerateColumns="False" DataKeyNames="IDproducto" HeaderStyle-CssClass="table-dark" AllowPaging="True"
    PageSize="5"
    PagerStyle-CssClass="pagination justify-content-center"
    PagerSettings-Mode="Numeric"
        DataSourceID="SqlDataSource1" OnRowDeleting="gvProductos_RowDeleting" OnRowEditing="gvProductos_RowEditing" OnRowCancelingEdit="gvProductos_RowCancelingEdit" OnRowUpdating="gvProductos_RowUpdating" OnSelectedIndexChanged="gvProductos_SelectedIndexChanged">
        <Columns>
            <asp:CommandField ShowEditButton="True" ControlStyle-CssClass="btn btn-success"/>
            <asp:BoundField DataField="IDproducto"  visible="false" HeaderText="IDproducto" InsertVisible="False" ReadOnly="True" SortExpression="IDproducto" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
            <asp:BoundField DataField="Precio" HeaderText="Precio" SortExpression="Precio" />
            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" />
            <asp:CommandField ShowDeleteButton="True" ControlStyle-CssClass="btn btn-danger"/>
        </Columns>

    </asp:GridView>

     
     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:II-46ConnectionString %>" SelectCommand="SELECT * FROM [Productos]"></asp:SqlDataSource>

     
</asp:Content>
