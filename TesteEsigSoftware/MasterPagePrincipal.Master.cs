using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TesteEsigSoftware
{
    public partial class MasterPagePrincipal : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string paginaAtual = Request.AppRelativeCurrentExecutionFilePath;

            if (Session["usuario"] == null && paginaAtual.ToLower() != "~/index")
            {
                Response.Redirect("~/Index");
            }
        }
        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            if (e.Item.Value == "Sair")
            {
                Session.Clear();

                Session.Abandon();

                Response.Redirect("~/Index");
            }
        }
    }
}
