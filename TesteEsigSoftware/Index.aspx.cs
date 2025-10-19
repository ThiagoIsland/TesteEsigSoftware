using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TesteEsigSoftware.Entity;
using TesteEsigSoftware.Repositories;

namespace TesteEsigSoftware
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin(object sender, EventArgs e)
        {
            try
            {
                Repository repository = new Repository();

                bool loginSucesso = repository.ValidarUsuario(txtUsuario.Text, txtSenha.Text);

                if (loginSucesso)
                {
                    Session["usuario"] = txtUsuario.Text;
                    Response.Redirect("~/ListarPessoas.aspx"); 
                }
                else
                {
                    mensagem.Text = "Usuário ou senha inválidos!";
                }
            }
            catch (Exception ex)
            {
                mensagem.Text = "Ocorreu um erro no sistema: " + ex.Message;
            }
        }
    }
}