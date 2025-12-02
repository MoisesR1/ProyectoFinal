<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Home.aspx.vb" Inherits="ProyectoFinal.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="LblUsuario" runat="server" Text="Usuario" CssClass="h3"></asp:Label>   
    <asp:Label ID="Lbl_Email" runat="server"  CssClass="h3"></asp:Label>  

<div class="container mt-4">

    <!-- TARJETA DE BÚSQUEDA -->
    <div class="card shadow-lg border-0">
        
        <div class="card-header bg-primary text-white d-flex align-items-center">
            <i class="bi bi-search me-2"></i>
            <h5 class="mb-0 fw-bold">Consultar Producto</h5>
        </div>

        <div class="card-body">

            <div class="row g-3">

                <!-- CAMPO DE BÚSQUEDA -->
                <div class="col-md-8">
                    <label class="form-label fw-semibold">Buscar por descripción</label>
                    <asp:TextBox ID="TxtBuscar" runat="server" CssClass="form-control form-control-lg"
                        Placeholder="Ejemplo: Martillo, Tornillo, Taladro..."></asp:TextBox>
                </div>

                <!-- BOTÓN -->
                <div class="col-md-4 d-flex align-items-end">
                    <asp:Button 
                        ID="BtnBuscar" 
                        Text="Buscar Producto" 
                        runat="server" 
                        CssClass="btn btn-success btn-lg w-100 shadow-sm" 
                        OnClick="BtnBuscar_Click"/>
                </div>

            </div>

            <!-- RESULTADO -->
            <div class="mt-4">
                <asp:Label ID="lblResultado" runat="server"></asp:Label>
            </div>

        </div>
    </div>
     
     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:II-46ConnectionString %>" SelectCommand="SELECT * FROM [Productos]"></asp:SqlDataSource>
    <asp:SqlDataSource 
    ID="SqlDataSourceBuscar" 
    runat="server" 
    ConnectionString="<%$ ConnectionStrings:II-46ConnectionString %>"
    SelectCommand="SELECT * FROM Productos WHERE Descripcion = @Descripcion">
    <SelectParameters>
        <asp:ControlParameter ControlID="TxtBuscar" Name="Descripcion" PropertyName="Text" Type="String" />
    </SelectParameters>
</asp:SqlDataSource>

     
</asp:Content>


