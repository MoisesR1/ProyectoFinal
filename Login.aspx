<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Login.aspx.vb" Inherits="ProyectoFinal.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<style>
    .fade-in { animation: fadeIn 0.8s ease-in-out; }
    @keyframes fadeIn { from { opacity:0; transform:translateY(15px);} to {opacity:1; transform:translateY(0);} }
    .card-custom { border:none; border-radius:15px; box-shadow:0 6px 18px rgba(0,0,0,0.15);}
    body { background: linear-gradient(135deg, #0d6efd, #6f42c1);}
    .input-group-text i { font-size:1.2rem; color:#0d6efd;}
    .btn-primary { border-radius:30px; font-size:1.1rem; padding:10px;}
</style>

<div class="d-flex justify-content-center align-items-center vh-100 px-3">
    <div class="card card-custom p-4 fade-in" style="max-width:410px; width:100%; background:white;">
        <div class="text-center mb-4">
            <i class="bi bi-shield-lock" style="font-size:3rem; color:#0d6efd;"></i>
            <h3 class="mt-2">Iniciar Sesión</h3>
            <p class="text-muted">Ingresa tus credenciales para continuar</p>
        </div>

        <asp:Label ID="lblMensaje" runat="server" CssClass="alert alert-danger text-center d-none" style="font-weight:bold;"></asp:Label>

        <div class="mb-3">
            <label for="txtUsuario" class="form-label fw-bold">Usuario</label>
            <div class="input-group input-group-lg">
                <span class="input-group-text"><i class="bi bi-person-circle"></i></span>
                <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" placeholder="Ingresa tu usuario" />
            </div>
        </div>

        <div class="mb-4">
            <label for="txtPassword" class="form-label fw-bold">Contraseña</label>
            <div class="input-group input-group-lg">
                <span class="input-group-text"><i class="bi bi-lock-fill"></i></span>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="••••••••" />
            </div>
        </div>

        <asp:Button ID="btnIniciarSesion" runat="server" Text="Iniciar Sesión" CssClass="btn btn-primary w-100 shadow-sm" OnClick="btnIniciarSesion_Click" />

        <div class="text-center mt-3">
            <a href="#" class="text-decoration-none text-muted">¿Olvidaste tu contraseña?</a>
        </div>
    </div>
</div>

</asp:Content>


