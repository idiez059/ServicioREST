using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ServicioRest5.Areas.Api.Models
{
    public class CaloriaManager
    {
        private static string cadenaConexion =
            @"Server=DESKTOP-NSHQPSH;Initial Catalog=BDCalorias;Integrated Security=true"; //Integrated Security en True, 
                                                                                           //lo cambio a false

        public bool InsertarCaloria(Caloria cal)
        {
            SqlConnection con = new SqlConnection(cadenaConexion);

            con.Open();

            string sql = "INSERT INTO calorias (email, fecha, tipocomida, codigoalimento, cantidad)" +
                " VALUES (@email, @fecha, @tipocomida, @codigoalimento, @cantidad)";

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.Add("@email", System.Data.SqlDbType.NVarChar).Value = cal.email;
            cmd.Parameters.Add("@fecha", System.Data.SqlDbType.NVarChar).Value = cal.fecha;
            cmd.Parameters.Add("@tipocomida", System.Data.SqlDbType.NVarChar).Value = cal.tipocomida;
            cmd.Parameters.Add("@codigoalimento", System.Data.SqlDbType.Int).Value = cal.codigoalimento;
            cmd.Parameters.Add("@cantidad", System.Data.SqlDbType.Int).Value = cal.cantidad;

            int res = cmd.ExecuteNonQuery();

            con.Close();

            return (res == 1);
        }

        public bool ActualizarCaloria(Caloria cal)
        {
            SqlConnection con = new SqlConnection(cadenaConexion);

            con.Open();

            string sql = "UPDATE usuario SET email = @email, password = @password, foto = @foto" +
                " WHERE email = @email";

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.Add("@email", System.Data.SqlDbType.NVarChar).Value = cal.email;
            cmd.Parameters.Add("@fecha", System.Data.SqlDbType.NVarChar).Value = cal.fecha;
            cmd.Parameters.Add("@tipocomida", System.Data.SqlDbType.NVarChar).Value = cal.tipocomida;
            cmd.Parameters.Add("@codigoalimento", System.Data.SqlDbType.Int).Value = cal.codigoalimento;
            cmd.Parameters.Add("@cantidad", System.Data.SqlDbType.Int).Value = cal.cantidad;

            int res = cmd.ExecuteNonQuery();

            con.Close();

            return (res == 1);
        }

        public Caloria ObtenerCaloria(string email) //esto habría que retocarlo si lo queremos usar
        {
            Caloria cal = null;

            SqlConnection con = new SqlConnection(cadenaConexion);

            con.Open();

            string sql = "SELECT email, fecha, tipocomida, codigoalimento, cantidad FROM calorias" +
                " WHERE email = @email";

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.Add("@email", System.Data.SqlDbType.NVarChar).Value = email;
            SqlDataReader reader =
                 cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);


            if (reader.Read())
            {
                cal = new Caloria();
                cal.email = email;
                cal.fecha = reader.GetString(1);
                cal.tipocomida = reader.GetString(2);
                cal.codigoalimento = reader.GetInt32(3);
                cal.cantidad = reader.GetInt32(4);
            }

            reader.Close();

            return cal;
        }

        public List<Caloria> ObtenerCalorias()
        {
            List<Caloria> lista = new List<Caloria>();

            SqlConnection con = new SqlConnection(cadenaConexion);

            con.Open();

            string sql = "SELECT email, fecha, tipocomida, codigoalimento, cantidad FROM calorias";

            SqlCommand cmd = new SqlCommand(sql, con);

            SqlDataReader reader =
                cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

            while (reader.Read())
            {
                Caloria cal = new Caloria();

                cal = new Caloria();
                cal.email = reader.GetString(0);
                cal.fecha = reader.GetString(1);
                cal.tipocomida = reader.GetString(2);
                cal.codigoalimento = reader.GetInt32(3);
                cal.cantidad = reader.GetInt32(4);

                lista.Add(cal);
            }

            reader.Close();

            return lista;
        }

        public bool EliminarCaloria(string email) //esto habría que retocarlo si lo queremos usar
        {
            SqlConnection con = new SqlConnection(cadenaConexion);

            con.Open();

            string sql = "DELETE FROM calorias WHERE email= @email";

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.Add("@email", System.Data.SqlDbType.NVarChar).Value = email;

            int res = cmd.ExecuteNonQuery();

            con.Close();

            return (res == 1);
        }
    }
}