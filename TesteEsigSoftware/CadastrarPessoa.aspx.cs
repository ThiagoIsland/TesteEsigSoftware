using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TesteEsigSoftware.Entity;
using TesteEsigSoftware.Repositories;

namespace TesteEsigSoftware
{
    public partial class CadastrarPessoa : System.Web.UI.Page
    {
        private Repository repository;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlCargo.Items.Add(new ListItem("Estagiario", "1"));
                ddlCargo.Items.Add(new ListItem("Tecnico", "2"));
                ddlCargo.Items.Add(new ListItem("Analista", "3"));
                ddlCargo.Items.Add(new ListItem("Coordenador", "4"));
                ddlCargo.Items.Add(new ListItem("Gerente", "5"));
            }

        }
        protected void btnSalvarPessoa(object sender, EventArgs e)
        {
            try
            {
                Pessoa pessoa = new Pessoa();
                pessoa.Nome = txtNome.Text;
                pessoa.Email = txtEmail.Text;
                pessoa.Cidade = txtCidade.Text;
                pessoa.CEP = txtCEP.Text;
                pessoa.Endereco = txtEndereco.Text;
                pessoa.Pais = txtPais.Text;
                pessoa.Usuario = txtUsuario.Text;
                pessoa.SenhaHash = txtSenha.Text;
                pessoa.Telefone = txtTelefone.Text; 
                pessoa.DataNascimento = Convert.ToDateTime(txtDataNascimento.Text);
                pessoa.CargoId = Convert.ToInt32(ddlCargo.SelectedValue);

                Repository repository = new Repository();
                repository.CadastrarPessoa(pessoa);

                Response.Redirect("~/ListarPessoas.aspx");
            }
            catch (Exception ex)
            {
                mensagem.Text = "Ocorreu um erro ao salvar: " + ex.Message;
            }
        }
    }
}