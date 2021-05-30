using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace wsEmailCorp.Models
{
    public class ClassEmailEnviado
    {
        public int newEmailEnviado(int idUserEnvia, int idUserRecibe, string asuntEnvia, string correoCuerpo)
        {
            try
            {
                DataSet dsi = new DataSet();
                MySqlConnection conection = new MySqlConnection();
                conection.ConnectionString = ConfigurationManager.ConnectionStrings["conectDB"].ConnectionString;
                conection.Open();
                string sqlCmd = "CALL `spNewCorreoeEnvia` (" + idUserEnvia + ", " + idUserRecibe + ", '" + asuntEnvia + "', '" + correoCuerpo+"')";
                MySqlDataAdapter da;
                da = new MySqlDataAdapter(sqlCmd, conection);
                da.Fill(dsi);
                conection.Close();

            }
            catch (Exception e)
            {
                return 1;
            }
            return 0;
        }

    }
}