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
    public class ClassUsuario
    {
        public List<string> usuarioConect(string usuario, string password)
        {
            DataSet dsi = new DataSet();
            List<string> lista = new List<string>();
            MySqlConnection conection = new MySqlConnection();
            conection.ConnectionString = ConfigurationManager.ConnectionStrings["conectDB"].ConnectionString;
            conection.Open();
            string sqlCmd = "CALL `spUsuarioLogin`('" + usuario + "')";
            MySqlDataAdapter da;
            da = new MySqlDataAdapter(sqlCmd, conection);
            da.Fill(dsi);
            DataTable dt = dsi.Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                lista.Add(row["name_email"].ToString());
                lista.Add(row["pass_email"].ToString());
                lista.Add(row["telefono"].ToString());
                lista.Add(row["nom_usuario"].ToString());
                lista.Add(row["ape_usuario"].ToString());
                lista.Add(row["dominio_email"].ToString());
                lista.Add(row["razon_social"].ToString());
                lista.Add(row["corpCorreo"].ToString());
            }
            conection.Close();
            return lista;
        }

        public List<string> usuarioConsult(int idUsuario)
        {
            DataSet dsi = new DataSet();
            List<string> lista = new List<string>();
            MySqlConnection conection = new MySqlConnection();
            conection.ConnectionString = ConfigurationManager.ConnectionStrings["conectDB"].ConnectionString;
            conection.Open();
            string sqlCmd = "CALL `spConsultUser`('" + idUsuario + "')";
            MySqlDataAdapter da;
            da = new MySqlDataAdapter(sqlCmd, conection);
            da.Fill(dsi);
            DataTable dt = dsi.Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                lista.Add(row["nit"].ToString());
                lista.Add(row["nom_usuario"].ToString());
                lista.Add(row["ape_usuario"].ToString());
                lista.Add(row["name_email"].ToString());
                lista.Add(row["pass_email"].ToString());
                lista.Add(row["telefono"].ToString());
                lista.Add(row["nivel"].ToString());
                lista.Add(row["id_usuario"].ToString());
                lista.Add(row["razon_social"].ToString());

            }
            conection.Close();
            return lista;
        }
        public int newUsuario(string nitProve, string nom_usuarioParam, string ape_usuarioParam, string name_emailParam, string pass_emailParam, string telefonoParam, int nivelParam)
        {
            try
            {

             DataSet dsi = new DataSet();
             MySqlConnection conection = new MySqlConnection();
             conection.ConnectionString = ConfigurationManager.ConnectionStrings["conectDB"].ConnectionString;
             conection.Open();
             string sqlCmd = "CALL `spNewUsuario` (" + nitProve + ", '" + nom_usuarioParam + "', '" + ape_usuarioParam + "', '" + name_emailParam + "', '" + pass_emailParam + "', '" + telefonoParam + "', " + nivelParam + ")";
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


        public int deleteUsuario(int id_user)
        {
            try
            {

                DataSet dsi = new DataSet();
                MySqlConnection conection = new MySqlConnection();
                conection.ConnectionString = ConfigurationManager.ConnectionStrings["conectDB"].ConnectionString;
                conection.Open();
                string sqlCmd = "CALL `spDeleteUser`('" + id_user + "')";
                MySqlDataAdapter da;
                da = new MySqlDataAdapter(sqlCmd, conection);
                da.Fill(dsi);
                conection.Close();

            }
            catch (Exception e)
            {
                return id_user;
            }
            return 0;
        }


        public List<string> allUser()
        {
            List<string> lista = new List<string>();
                DataSet dsi = new DataSet();
                MySqlConnection conection = new MySqlConnection();
                conection.ConnectionString = ConfigurationManager.ConnectionStrings["conectDB"].ConnectionString;
                conection.Open();
                string sqlCmd = "CALL `spAllUser`";
                MySqlDataAdapter da;
                da = new MySqlDataAdapter(sqlCmd, conection);
                da.Fill(dsi);
                DataTable dt = dsi.Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(row["id_usuario"].ToString());
                    lista.Add(row["nom_usuario"].ToString());
                    lista.Add(row["ape_usuario"].ToString());
                    lista.Add(row["name_email"].ToString());
                    lista.Add(row["pass_email"].ToString());
                    lista.Add(row["telefono"].ToString());
                    lista.Add(row["es_activo"].ToString());
                    lista.Add(row["nivel"].ToString());
                 
            }

                conection.Close();
                return lista;

        }
        //        
        public int editUsuario(string nom_usuarioParam, string ape_usuarioParam, string name_emailParam, string pass_emailParam, string telefonoParam,  int isActivo, int nivelParam, int idUser)
        {
            try
            {
                DataSet dsi = new DataSet();
                MySqlConnection conection = new MySqlConnection();
                conection.ConnectionString = ConfigurationManager.ConnectionStrings["conectDB"].ConnectionString;
                conection.Open();
                string sqlCmd = "CALL `spUpdateUser` ('" + nom_usuarioParam + "', '" + ape_usuarioParam + "', '" + name_emailParam + "', '" + pass_emailParam + "', '" + telefonoParam + "', "+ isActivo+", " + nivelParam +", "+ idUser  + ")";
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