<%@ Page Title="About" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.vb" Inherits="ProyectoFinal.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>
        <p>Your app description page.</p>
        <p>Use this area to provide additional information.</p>

        <asp:TextBox ID="Txt_idproducto" runat="server"></asp:TextBox>
        <asp:TextBox ID="Txt_descripcion" runat="server"></asp:TextBox>
        <asp:TextBox ID="Txt_precio" runat="server"></asp:TextBox>
        <asp:TextBox ID="Txt_cantidad" runat="server"></asp:TextBox>
        <asp:Button ID="Btn_ingresar" runat="server" Text="Ingresar" OnClick="Btn_ingresar_Click" />
        <asp:Label ID="lbl_mensaje" runat="server" Text=""></asp:Label>

    </main>
</asp:Content>
