using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace TesteEsigSoftware.Data
{
    public class Database
    {
        public static OracleConnection GetConnection()
        {
            string connStr = ConfigurationManager.ConnectionStrings["OracleDb"].ConnectionString;
            return new OracleConnection(connStr);
        }
    }
}