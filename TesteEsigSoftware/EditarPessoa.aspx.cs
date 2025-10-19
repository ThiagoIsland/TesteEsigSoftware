using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TesteEsigSoftware.Entity;
using TesteEsigSoftware.Repositories;

namespace TesteEsigSoftware
{
    public partial class EditarPessoa : System.Web.UI.Page
    {
        private Repository repository;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargoSelec.Items.Add(new ListItem("Estagiario", "1"));
                cargoSelec.Items.Add(new ListItem("Tecnico", "2"));
                cargoSelec.Items.Add(new ListItem("Analista", "3"));
                cargoSelec.Items.Add(new ListItem("Coordenador", "4"));
                cargoSelec.Items.Add(new ListItem("Gerente", "5"));
            }
        }
        protected void btnPesquisarPessoa(object sender, EventArgs e)
        {
            if (int.TryParse(txtPesquisarPessoa.Text, out int id))
            {
                BuscarPessoa(id);
            }
            else
            {
                Response.Write("<script>alert('Digite um ID válido!');</script>");
            }
        }
        private void BuscarPessoa(int id)
        {
            repository = new Repository();
            DataTable dtPessoas = repository.BuscarPessoa(id);

            GridPessoa.DataSource = dtPessoas;
            GridPessoa.DataBind();

        }

        protected void btnSalvarPessoa(object sender, EventArgs e)
        {
            try
            {
                Pessoa pessoa = new Pessoa();
                pessoa.Id = Convert.ToInt32(txtId.Text);
                pessoa.Nome = txtNome.Text;
                pessoa.Email = txtEmail.Text;
                pessoa.Cidade = txtCidade.Text;
                pessoa.CEP = txtCEP.Text;
                pessoa.Endereco = txtEndereco.Text;
                pessoa.Pais = txtPais.Text;
                pessoa.Usuario = txtUsuario.Text;
                pessoa.SenhaHash = txtSenha.Text;
                pessoa.Telefone = txtTelefone.Text;
                pessoa.DataNascimento = Convert.ToDateTime(txtData.Text);
                pessoa.CargoId = Convert.ToInt32(cargoSelec.SelectedValue);

                Repository repository = new Repository();
                repository.EditarPessoa(pessoa);

                Response.Redirect("~/ListarPessoas.aspx");
            }
            catch (Exception ex)
            {
                mensagem.Text = "Ocorreu um erro ao salvar: " + ex.Message;
            }
        }
    }
}