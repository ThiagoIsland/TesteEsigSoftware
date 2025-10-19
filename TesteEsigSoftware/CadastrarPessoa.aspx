<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPagePrincipal.Master" AutoEventWireup="true" CodeBehind="CadastrarPessoa.aspx.cs" Inherits="TesteEsigSoftware.CadastrarPessoa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <h2>Tela de cadastros</h2>

        Nome: <asp:TextBox ID="txtNome" runat="server"></asp:TextBox><br />
        Email: <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><br />
        Cidade: <asp:TextBox ID="txtCidade" runat="server"></asp:TextBox><br />
        CEP: <asp:TextBox ID="txtCEP" runat="server"></asp:TextBox><br />
        Endereco: <asp:TextBox ID="txtEndereco" runat="server"></asp:TextBox><br />
        País: <asp:TextBox ID="txtPais" runat="server"></asp:TextBox><br />
        Usuário: <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox><br />
        Senha: <asp:TextBox ID="txtSenha" runat="server" TextMode="Password"></asp:TextBox><br />
        Telefone: <asp:TextBox ID="txtTelefone" runat="server"></asp:TextBox><br />
        Data de Nascimento: <asp:TextBox ID="txtDataNascimento" runat="server" TextMode="Date"></asp:TextBox><br />
        Cargo: <asp:DropDownList ID="ddlCargo" runat="server"></asp:DropDownList><br /><br />

        <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvarPessoa" />
        <asp:Literal ID="mensagem" runat="server"></asp:Literal>

</asp:Content>
