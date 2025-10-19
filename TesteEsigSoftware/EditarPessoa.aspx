<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPagePrincipal.Master" AutoEventWireup="true" CodeBehind="EditarPessoa.aspx.cs" Inherits="TesteEsigSoftware.EditarPessoa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Tela de edição de cadastro</h2>
    <h3>Buscar por Pessoa</h3>

    <asp:TextBox ID="txtPesquisarPessoa" runat="server"></asp:TextBox>  <br />

    <asp:Button ID="btnPesquisar" runat="server" Text="Buscar Pessoa" OnClick="btnPesquisarPessoa" /> <br />

    <asp:GridView ID="GridPessoa" runat="server" AutoGenerateColumns="False" EmptyDataText="Nenhuma pessoa encontrada." ShowHeaderWhenEmpty="True">

          <Columns>
              <asp:BoundField DataField="nome" HeaderText="Nome" />
              <asp:BoundField DataField="CargoNome" HeaderText="Cargo" />
              <asp:BoundField DataField="usuario" HeaderText="Usuário" />
              <asp:BoundField DataField="email" HeaderText="E-mail" />
              <asp:BoundField DataField="cep" HeaderText="CEP" />
              <asp:BoundField DataField="telefone" HeaderText="Telefone" />
              <asp:BoundField DataField="cidade" HeaderText="Cidade" />
              <asp:BoundField DataField="pais" HeaderText="País" />
              <asp:BoundField DataField="endereco" HeaderText="Endereço" />
              <asp:BoundField DataField="salario_liquido" HeaderText="Salário Líquido" />
          </Columns>
      </asp:GridView>

    
    <h3>Edição de cadastro</h3>
        Id:  <asp:TextBox ID="txtId" runat="server"></asp:TextBox><br />
        Nome: <asp:TextBox ID="txtNome" runat="server"></asp:TextBox><br />
        Email: <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><br />
        Cidade: <asp:TextBox ID="txtCidade" runat="server"></asp:TextBox><br />
        CEP: <asp:TextBox ID="txtCEP" runat="server"></asp:TextBox><br />
        Endereco: <asp:TextBox ID="txtEndereco" runat="server"></asp:TextBox><br />
        País: <asp:TextBox ID="txtPais" runat="server"></asp:TextBox><br />
        Usuário: <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox><br />
        Senha: <asp:TextBox ID="txtSenha" runat="server" TextMode="Password" ></asp:TextBox><br />
        Telefone: <asp:TextBox ID="txtTelefone" runat="server"></asp:TextBox><br />
        Data de Nascimento: <asp:TextBox ID="txtData" runat="server" TextMode="Date"></asp:TextBox><br />
        Cargo: <asp:DropDownList ID="cargoSelec" runat="server"></asp:DropDownList><br /><br />

        <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvarPessoa" />
        <asp:Literal ID="mensagem" runat="server"></asp:Literal>
</asp:Content>
