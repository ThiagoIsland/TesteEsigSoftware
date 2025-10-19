using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using TesteEsigSoftware.Repositories;

namespace TesteEsigSoftware
{
    public partial class CalcularSalarios : System.Web.UI.Page
    {
        private Repository repository;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.repository = new Repository();
            if (!IsPostBack)
            {
                CarregarPessoas();
            }
        }
        private void CarregarPessoas()
        {
            repository = new Repository();
            DataTable dtPessoas = repository.ListarPessoasComSalario();

            GridPessoas.DataSource = dtPessoas;
            GridPessoas.DataBind();
        }
        protected async void btnCalcularSalarios(object sender, EventArgs e)
        {
            await Task.Run(() => repository.CalcularSalarios());
            CarregarPessoas();
        }

        protected void btnExportarPDF(object sender, EventArgs e)
        {
            ReportDocument reportDoc = new ReportDocument();
            string reportPath = Server.MapPath("~/Reports/RelatorioSalarios.rpt");

            try
            {
                reportDoc.Load(reportPath);


                ConnectionInfo connInfo = new ConnectionInfo();
                connInfo.ServerName = ConfigurationManager.AppSettings["RPT_ServerName"];
                connInfo.DatabaseName = ConfigurationManager.AppSettings["RPT_DatabaseName"];
                connInfo.UserID = ConfigurationManager.AppSettings["RPT_UserID"];
                connInfo.Password = ConfigurationManager.AppSettings["RPT_Password"];

                foreach (CrystalDecisions.CrystalReports.Engine.Table table in reportDoc.Database.Tables)
                {
                    table.LogOnInfo.ConnectionInfo = connInfo;
                    table.ApplyLogOnInfo(table.LogOnInfo);
                }

                reportDoc.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "RelatorioSalarios.pdf");


                Response.End();
            }
            catch (Exception ex)
            {
                Response.Write("Erro ao gerar relatório: " + ex.Message);
            }
            finally
            {
                reportDoc.Dispose();
            }
        }
        protected void GridPessoas_Indexacao(object sender, GridViewPageEventArgs e)
        {
            GridPessoas.PageIndex = e.NewPageIndex;
            CarregarPessoas();
        }
    }
}