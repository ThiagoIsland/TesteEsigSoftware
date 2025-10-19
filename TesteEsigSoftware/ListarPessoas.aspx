<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPagePrincipal.Master" AutoEventWireup="true" CodeBehind="ListarPessoas.aspx.cs" Inherits="TesteEsigSoftware.ListarPessoas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <h2>Tela de Listagem, Busca e Exclusão</h2>

            <h3>Lista de Pessoas</h3>
            <asp:Literal ID="mensagem" runat="server"></asp:Literal>


  <asp:GridView ID="GridPessoas" runat="server" 
         AutoGenerateColumns="False" AllowPaging="True" PageSize="10" OnPageIndexChanging="GridPessoas_Indexacao" EmptyDataText="Nenhuma pessoa encontrada." ShowHeaderWhenEmpty="True">
         <Columns>
             <asp:BoundField DataField="nome" HeaderText="Nome" />
             <asp:BoundField DataField="CargoNome" HeaderText="Cargo" />
             <asp:BoundField DataField="usuario" HeaderText="usuario"/>
             <asp:BoundField DataField="email" HeaderText="E-mail"/>
             <asp:BoundField DataField="cep" HeaderText="CEP" />
             <asp:BoundField DataField="telefone" HeaderText="Telefone"/>
             <asp:BoundField DataField="cidade" HeaderText="Cidade"/>
             <asp:BoundField DataField="pais" HeaderText="País"/>
             <asp:BoundField DataField="endereco" HeaderText="Endereco"/>
             <asp:BoundField DataField="salario_liquido" HeaderText="Salario Líquido"/>
         </Columns>
     </asp:GridView>

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

            <h3>Excluir Pessoa</h3>

         <asp:TextBox ID="txtExcluirPessoa" runat="server"></asp:TextBox> <br />

         <asp:Button ID="btnExcluir" runat="server" Text="Excluir Pessoa" OnClick="btnExcluirPessoa" />
</asp:Content>
