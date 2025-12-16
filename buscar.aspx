<%@ Page Title="" Language="vb" AutoEventWireup="false"
    MasterPageFile="~/Site.Master"
    CodeBehind="buscar.aspx.vb"
    Inherits="ProyectoFinal.buscar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-4">

        <div class="card shadow-sm">
            <div class="card-body">

                <h4 class="mb-3">Buscar productos por proveedor</h4>

                <div class="row g-3 align-items-end">

                    <div class="col-12 col-md-6">
                        <label class="form-label fw-semibold">Proveedor</label>

                        <asp:DropDownList ID="ddlProveedor" runat="server"
                            DataSourceID="SqlProveedores"
                            DataTextField="empresa"
                            DataValueField="id"
                            CssClass="form-select"
                            AutoPostBack="true">
                        </asp:DropDownList>
                    </div>

                    <div class="col-12 col-md-6">
                        <asp:Label ID="lblProveedorSeleccionado" runat="server"
                            CssClass="text-muted"></asp:Label>
                    </div>

                </div>

                <hr class="my-4" />

                <asp:GridView ID="gvResultado" runat="server"
                    DataSourceID="SqlProveedorProducto"
                    AutoGenerateColumns="False"
                    CssClass="table table-striped table-hover align-middle mb-0">

                    <Columns>
                        <asp:BoundField DataField="Descripcion" HeaderText="Producto" />
                        <asp:BoundField DataField="Precio" HeaderText="Precio Venta" DataFormatString="{0:N2}" />
                        <asp:BoundField DataField="PrecioProveedor" HeaderText="Precio Proveedor" DataFormatString="{0:N2}" />
                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                    </Columns>

                </asp:GridView>

            </div>
        </div>

    </div>




  
    <asp:SqlDataSource ID="SqlProveedores" runat="server"
        ConnectionString="<%$ ConnectionStrings:II-46ConnectionString %>"
        SelectCommand="SELECT id, empresa FROM dbo.proveedores ORDER BY empresa">
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="SqlProveedorProducto" runat="server"
        ConnectionString="<%$ ConnectionStrings:II-46ConnectionString %>"
        SelectCommand="
            SELECT p.Descripcion, p.Precio, p.Cantidad, pp.PrecioProveedor
            FROM dbo.ProveedorProducto pp
            INNER JOIN dbo.Productos p ON p.IDproducto = pp.IdProducto
            WHERE pp.IdProveedor = @IdProveedor
            ORDER BY p.Descripcion">

        <SelectParameters>
            <asp:ControlParameter Name="IdProveedor"
                ControlID="ddlProveedor"
                PropertyName="SelectedValue"
                Type="Int32" />
        </SelectParameters>

    </asp:SqlDataSource>

</asp:Content>
