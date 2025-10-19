# Orientações 

## Explicações sobre a aplicação

Este projeto foi desenvolvido como parte do processo seletivo para a ESIG Group, implementando um sistema web completo para gerenciamento de pessoas e cálculo automatizado de salários.

### Requisitos Principais incluídos: 

- **Listagem de Pessoas**: Tela completa com informações de pessoas, cargos e salários calculados ()
- **Cálculo de Salários**: Sistema automatizado de cálculo para calcular/recalcular. Utilizando Stored Procedure (`SP_CALCULAR_SALARIOS`) para processar os calculos e também preenchendo os campos requisitados da tabela pessoa_salario (`salario_bruto`, `descontos` e `salario_liquido`).

### Requisitos Diferenciais incluídos:

- **Processamento Assíncrono**: Cálculo de salários executado de forma assíncrona.
- **CRUD de Pessoas**: Funcionalidades para cadastrar, editar e excluir pessoas 
- **Relatórios Crystal Reports**: Geração de relatórios em PDF dos salários calculados
- **Sistema de Login**: Autenticação de usuários (Hash MD5)

### Front-End e Tecnologias

- **ASP.NET Web Forms**
- **Crystal Reports**

### Back-End

- **ASP.NET Framework 4.8**
- **C#**

## Banco De Dados

- **Oracle Database**
- **Tabelas**

# Orientações 

Neste tópico vamos abordar alguns requisitos e especificidades do projeto para melhor entendimento e para ter seu funcionamento 100% funcional.

## Banco de Dados

Os três arquivos abaixo são necessários para funcionamento do projeto. É necessários executar/criar eles em seu banco de dados. (Aprofundado no tópico de "Como executar o projeto")

- **Tabelas.SQL** - Arquivos com estrutura das tabelas. 
- **SP_Calcular_Salarios.sql** - Arquivos com Stored Procedure para cálculo de salários
- **V_RELATORIO_SALARIOS.sql** - Arquivos com View para relatórios de salários (RPT)

    -> Tabelas: pessoa, cargo, vencimentos, cargo_vencimentos, pessoa_salario

### Lógica do fluxo para Cálculo de Salários

1. **Base Salarial**: Calcula valor base a partir de vencimentos fixos (tipo(C) e da forma_incidencia(V))
2. **Créditos Percentuais**: Adiciona percentuais sobre o salário base (tipo(C) e forma_incidencia(P))
3. **Descontos Fixos**: Aplica descontos em valores fixos (tipo(D) e forma_incidencia(V))
4. **Descontos Percentuais**: Aplica descontos percentuais sobre salário bruto (tipo=(D) e forma_incidencia(P))
5. **Salário Líquido**: Calcula valor final (salario_bruto - total_descontos)
6. **Armazenamento**: Salva resultados na tabela `pessoa_salario`

** Sobre Créditos Percentuais: Apesar de não haver nenhum exemplo na tabela (Vencimentos), a funcionalidade extra foi criada para fins de escalabilidade.
	
## Telas da aplicação

### Sistema de Navegação
- **MasterPagePrincipal.Master** - Layout principal da aplicação
- **Index.aspx** - Página de login do sistema

### Gestão de Pessoas
- **ListarPessoas.aspx** - Listagem de pessoas com dados de salário, Busca por pessoa específica e Exclusão de pessoa específica.
- **CadastrarPessoa.aspx** - Cadastro de novas pessoas
- **EditarPessoa.aspx** - Edição de pessoas existentes

### Cálculo e Relatórios
- **CalcularSalarios.aspx** - Cálculo de salários e Geração de relatórios

## Como executar o projeto

### Pré-requisitos

1. **Visual Studio 2019/2022 com Crystal Reports**
2. **Oracle Database 11g**
3. **Oracle Client**
4. **.NET Framework 4.8**

### Configuração do Banco de Dados

1. **Execute os scripts SQL nessa ordem:**
   ```sql
   @Tabelas.SQL
   
   @SP_Calcular_Salarios.sql
   
   @V_RELATORIO_SALARIOS.sql
   ```

2. **Configure a connection string no `Web.config`:**
   ```xml
   <connectionStrings>
     <add name="OracleDb" 
          connectionString="User Id=SEU_USUARIO;Password=SUA_SENHA;Data Source=SEU_SERVIDOR:1521/XE;" 
          providerName="Oracle.ManagedDataAccess.Client" />
   </connectionStrings>
   ```

3. **Configure as credenciais do Crystal Reports:**
   ```xml
   <appSettings>
     <add key="RPT_ServerName" value="SEU_SERVIDOR/XE" />
     <add key="RPT_DatabaseName" value="" />
     <add key="RPT_UserID" value="SEU_USUARIO" />
     <add key="RPT_Password" value="SUA_SENHA" />
   </appSettings>
   ```
### Execução da Aplicação

1. **Abra o projeto no Visual Studio**
2. **Restore os packages NuGet:**
3. **Execute o projeto** (F5 ou Ctrl+F5)