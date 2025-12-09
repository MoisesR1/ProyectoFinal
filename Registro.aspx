<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Registro.aspx.vb" Inherits="ProyectoFinal.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Registro de Usuario</h2>
    <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>
    <asp:Panel ID="pnlRegistro" runat="server">
        <table>
            <tr>
                <td><asp:Label ID="lblUsuario" runat="server" Text="Nombre:"></asp:Label></td>
                <td><asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label></td>
                <td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label ID="lblPassword" runat="server" Text="Contraseña:"></asp:Label></td>
                <td><asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
                 <td><asp:Label ID="lblConfirmarPassword" runat="server" Text="Confirmar Contraseña:"></asp:Label>
                 <td><asp:TextBox ID="txtConfirmarPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
  
                <td colspan="2">
                    <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" OnClick="btnRegistrar_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
