<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPagePrincipal.Master" Async="true"AutoEventWireup="true" CodeBehind="CalcularSalarios.aspx.cs" Inherits="TesteEsigSoftware.CalcularSalarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <h2>Calculo/Recalculo Salário</h2>

        <asp:Button ID="btnCalcular" runat="server" Text="Calcular/Recalcular Salários" OnClick="btnCalcularSalarios" />
        <br /><br />
        <asp:Button ID="btnExportar" runat="server" Text="Exportar Relatório para PDF" OnClick="btnExportarPDF" />
        <br /><br />

        
        <asp:GridView ID="GridPessoas" runat="server" AutoGenerateColumns="false" AllowPaging="True" PageSize="10" OnPageIndexChanging="GridPessoas_Indexacao" EmptyDataText="Nenhuma pessoa encontrada." >
            <Columns>
                <asp:BoundField DataField="nome" HeaderText="Nome" />
                <asp:BoundField DataField="CargoNome" HeaderText="Cargo" />
                <asp:BoundField DataField="salario_bruto" HeaderText="Salário Bruto"/>
                <asp:BoundField DataField="descontos" HeaderText="Descontos" />
                <asp:BoundField DataField="salario_liquido" HeaderText="Salario Líquido"/>
            </Columns>
        </asp:GridView>

</asp:Content>
