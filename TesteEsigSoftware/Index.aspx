<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPagePrincipal.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="TesteEsigSoftware.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>PÁGINA INICIAL DO PROJETO</h2>
    <h3>FAÇA SEU LOGIN</h3>
    <div>
        Usuário: <br />
        <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
        <br /><br />
        Senha: <br />
        <asp:TextBox ID="txtSenha" runat="server" TextMode="Password"></asp:TextBox>
        <br /><br />
        
        <asp:Button ID="btnLogar" runat="server" Text="Entrar" OnClick="btnLogin" />
        <br /><br />
        
        <asp:Label ID="mensagem" runat="server" ForeColor="Red"></asp:Label>
    </div>
</asp:Content>
