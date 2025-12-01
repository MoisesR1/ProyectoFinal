<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Login.aspx.vb" Inherits="ProyectoFinal.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

      <div class="d-flex justify-content-center align-items-center vh-100">
    <div class="card shadow-lg p-4" style="max-width: 380px; width:100%;">
        
        <h3 class="text-center mb-3">Iniciar Sesión</h3>

        <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger fw-bold d-block text-center mb-3"></asp:Label>

        <div class="mb-3">
            <label for="txtUsuario" class="form-label">Usuario</label>
            <div class="input-group">
                <span class="input-group-text">
                    <i class="bi bi-person"></i>
                </span>
                <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" />
            </div>
        </div>

        <div class="mb-3">
            <label for="txtPassword" class="form-label">Contraseña</label>
            <div class="input-group">
                <span class="input-group-text">
                    <i class="bi bi-lock"></i>
                </span>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" />
            </div>
        </div>

        <asp:Button ID="btnIniciarSesion" 
                    runat="server" 
                    Text="Iniciar Sesión" 
                    CssClass="btn btn-primary w-100 mt-2" 
                    OnClick="btnIniciarSesion_Click" />

    </div>
</div>


</asp:Content>
