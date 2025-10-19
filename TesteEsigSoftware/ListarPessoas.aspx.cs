using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TesteEsigSoftware.Repositories;

namespace TesteEsigSoftware
{
    public partial class ListarPessoas : System.Web.UI.Page
    {
        private Repository repository;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                repository = new Repository();
                CarregarPessoas();
            }
        }

        private void CarregarPessoas()
        {
            try
            {
                repository = new Repository();
                DataTable dtPessoas = repository.ListarPessoasComSalario();

                GridPessoas.DataSource = dtPessoas;
                GridPessoas.DataBind();

            }
            catch (Exception ex)
            {
                mensagem.Text = $"Erro ao carregar dados: {ex.Message}";
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
            try
            {
                repository = new Repository();
                DataTable dtPessoas = repository.BuscarPessoa(id);

                GridPessoa.DataSource = dtPessoas;
                GridPessoa.DataBind();
            }
            catch (Exception ex)
            {
                mensagem.Text = $"Erro ao carregar dados: {ex.Message}";
            }

        }
        protected void btnExcluirPessoa(object sender, EventArgs e)
        {
            if (int.TryParse(txtPesquisarPessoa.Text, out int id))
            {
                ExcluirPessoa(id);
                Response.Write($"<script>alert('Pessoa com {id} excluida do sistema!');</script>");
            }
            else
            {
                Response.Write("<script>alert('Digite um ID válido!');</script>");
            }
        }
        private void ExcluirPessoa(int id)
        {
            try
            {
                repository = new Repository();
                repository.RemoverPessoa(id);
            }
            catch (Exception ex)
            {
                mensagem.Text = $"Erro ao carregar dados: {ex.Message}";
            }
        }

        protected void GridPessoas_Indexacao(object sender, GridViewPageEventArgs e)
        {
            GridPessoas.PageIndex = e.NewPageIndex;
            CarregarPessoas();
        }
    }
}