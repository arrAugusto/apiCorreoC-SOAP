using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace corpEmail.Models
{
    public class ClassUsuario
    {
        
        public List<string> usuarioConect(string usuario, string password)
        {
            DataSet dsi = new DataSet();
            List<string> lista = new List<string>();
            MySqlConnection conection = new MySqlConnection();
            conection.ConnectionString = ConfigurationManager.ConnectionStrings["conectDB"].ConnectionString;

            
            conection.Open();
                
            string sqlCmd = "CALL `spUsuarioLogin`('" + usuario+"')";
            MySqlDataAdapter da;
            da = new MySqlDataAdapter(sqlCmd, conection);
            da.Fill(dsi);

            DataTable dt = dsi.Tables[0];
            
            foreach(DataRow row in dt.Rows)
            {
                lista.Add(row["name_email"].ToString());
                lista.Add(row["pass_email"].ToString());
            }

            conection.Close();
            return lista;




        }
        }
}