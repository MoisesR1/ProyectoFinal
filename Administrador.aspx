
<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Administrador.aspx.vb" Inherits="ProyectoFinal.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2 class="text-center mb-4 fw-bold">Panel de Administración - Ferretería Brenes</h2>

    <div class="container">

        <!-- Formulario para agregar producto -->
        <div class="card shadow-sm mb-4">
            <div class="card-header bg-primary text-white">
                <i class="bi bi-plus-circle"></i> Agregar Producto
            </div>

            <div class="card-body">

                <div class="row g-3">

                    <div class="col-md-3">
                        <label class="form-label">Descripción</label>
                        <asp:TextBox ID="TxtDescripcion" CssClass="form-control" runat="server" Placeholder="Descripción"></asp:TextBox>
                    </div>

                    <div class="col-md-2">
                        <label class="form-label">Precio</label>
                        <asp:TextBox ID="TxtPrecio" CssClass="form-control" runat="server" Placeholder="Precio" TextMode="Number"></asp:TextBox>
                    </div>

                    <div class="col-md-2">
                        <label class="form-label">Cantidad</label>
                        <asp:TextBox ID="TxtCantidad" CssClass="form-control" runat="server" Placeholder="Cantidad" TextMode="Number"></asp:TextBox>
                    </div>

                    <div class="col-md-4">
                        <label class="form-label">Proveedor</label>
                        <asp:DropDownList ID="ddlProveedores" CssClass="form-select" runat="server"></asp:DropDownList>
                    </div>

                </div>

                <div class="mt-3 text-end">
                    <asp:Button ID="BtnAgregar" CssClass="btn btn-primary" Text="Agregar Producto" runat="server"  />
                </div>

                <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger fw-bold mt-2"></asp:Label>

            </div>
        </div>

        <!-- GridView para mostrar Productos con Proveedores -->
        <asp:GridView ID="gvAdmin" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" ShowHeader="true">
            <Columns>
                <asp:BoundField DataField="IDproducto" HeaderText="ID Producto" ReadOnly="True" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="{0:C}" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                <asp:BoundField DataField="NombreProveedor" HeaderText="Proveedor" />
            </Columns>
        </asp:GridView>

    </div>

</asp:Content>

