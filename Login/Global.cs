using MAPDataClassLib.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Login
{
    public static class Global
    {
        public static bool DbInicializado { get; set; }

        public static void InicializarDb()
        {
            if (!DbInicializado)
            {
                DBConfig.Factory = "System.Data.SqlClient";
                DBConfig.StringConexao = "Server=localhost\\SQLExpress;Database=Modulor;User Id=sa;Password=123456;";
                DBConfig.Factory = "System.Data.SqlClient";
                DbInicializado = true;
            }
        }
    }
}