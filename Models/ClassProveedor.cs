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
    public class ClassProveedor
    {
        public int newProveedor(string razon_socialParam, string dominio_emailParam, string nitParam, string telefonoParam, string direccionParam)
        {
            try
            {
                DataSet dsi = new DataSet();
                MySqlConnection conection = new MySqlConnection();
                conection.ConnectionString = ConfigurationManager.ConnectionStrings["conectDB"].ConnectionString;
                conection.Open();
                string sqlCmd = "CALL `spNewProveedor` ('" + razon_socialParam + "', '" + dominio_emailParam + "', '" + nitParam + "', '" + telefonoParam + "', '" + direccionParam+ "')";
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
        public int updateProveedor(string razon_socialParam, string dominio_emailParam, string nitParam, string telefonoParam, string direccionParam, int id_prove)
        {
            try
            {

                DataSet dsi = new DataSet();
                MySqlConnection conection = new MySqlConnection();
                conection.ConnectionString = ConfigurationManager.ConnectionStrings["conectDB"].ConnectionString;
                conection.Open();
                string sqlCmd = "CALL `spUpdateProveedor` ('" + razon_socialParam + "', '" + dominio_emailParam + "', '" + nitParam + "', '" + telefonoParam + "', '" + direccionParam + "', "+ id_prove+")";
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
        public List<string> allProveedores()
        {
            List<string> lista = new List<string>();
            DataSet dsi = new DataSet();
            MySqlConnection conection = new MySqlConnection();
            conection.ConnectionString = ConfigurationManager.ConnectionStrings["conectDB"].ConnectionString;
            conection.Open();
            string sqlCmd = "CALL `spAllProveedores`";
            MySqlDataAdapter da;
            da = new MySqlDataAdapter(sqlCmd, conection);
            da.Fill(dsi);
            DataTable dt = dsi.Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                lista.Add(row["razon_social"].ToString());
                lista.Add(row["nit"].ToString());
                lista.Add(row["dominio_email"].ToString());
                lista.Add(row["telefono"].ToString());
                lista.Add(row["direccion"].ToString());
                lista.Add(row["id_proveedor"].ToString());
                lista.Add(row["fecha_creacion"].ToString());
            }

            conection.Close();
            return lista;

        }
        public int deletteProveedor(int idProve)
        {
            try
            {

                DataSet dsi = new DataSet();
                MySqlConnection conection = new MySqlConnection();
                conection.ConnectionString = ConfigurationManager.ConnectionStrings["conectDB"].ConnectionString;
                conection.Open();
                string sqlCmd = "CALL `spDeleteProveedor` (" + idProve + ")";
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