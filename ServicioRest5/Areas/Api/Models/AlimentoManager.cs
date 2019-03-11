using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ServicioRest5.Areas.Api.Models
{
    public class AlimentoManager
    {
        private static string cadenaConexion =
            @"Server=DESKTOP-NSHQPSH;Initial Catalog=BDCalorias;Integrated Security=True"; //Integrated Security en True, 
                                                                                           //lo cambio a false

        public bool InsertarAlimento(Alimento ali)
        {
            SqlConnection con = new SqlConnection(cadenaConexion);

            con.Open();

            string sql = "INSERT INTO alimentos (email, password, foto) VALUES (@email, @password, @foto)";

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.Add("@email", System.Data.SqlDbType.NVarChar).Value = usu.email;
            cmd.Parameters.Add("@password", System.Data.SqlDbType.NVarChar).Value = usu.password;
            cmd.Parameters.Add("@foto", System.Data.SqlDbType.NVarChar).Value = usu.foto;

            int res = cmd.ExecuteNonQuery();

            con.Close();

            return (res == 1);
        }

        public bool ActualizarAlimento(Alimento ali)
        {
            SqlConnection con = new SqlConnection(cadenaConexion);

            con.Open();

            string sql = "UPDATE usuario SET email = @email, password = @password, foto = @foto" +
                " WHERE email = @email";

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.Add("@email", System.Data.SqlDbType.NVarChar).Value = usu.email;
            cmd.Parameters.Add("@password", System.Data.SqlDbType.Int).Value = usu.password;
            cmd.Parameters.Add("@foto", System.Data.SqlDbType.Int).Value = usu.foto;

            int res = cmd.ExecuteNonQuery();

            con.Close();

            return (res == 1);
        }

        public Alimento ObtenerAlimento(int codigo)
        {
            Alimento ali = null;

            SqlConnection con = new SqlConnection(cadenaConexion);

            con.Open();

            string sql = "SELECT email, password, foto FROM usuario WHERE email = @email";

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.Add("@email", System.Data.SqlDbType.NVarChar).Value = email;
            SqlDataReader reader =
                 cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);


            if (reader.Read())
            {
                ali = new Alimento();
                ali.codigo = codigo;
                usu.password = reader.GetString(1);
                usu.foto = reader.GetString(2);
            }

            reader.Close();

            return ali;
        }

        public List<Alimento> ObtenerAlimentos()
        {
            List<Alimento> lista = new List<Alimento>();

            SqlConnection con = new SqlConnection(cadenaConexion);

            con.Open();

            string sql = "SELECT email, password, foto FROM usuario";

            SqlCommand cmd = new SqlCommand(sql, con);

            SqlDataReader reader =
                cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

            while (reader.Read())
            {
                Alimento ali = new Alimento();

                ali = new Alimento();
                ali.codigo = reader.GetInt(0);
                //usu.password = reader.GetString(1);
                //usu.foto = reader.GetString(2);

                lista.Add(ali);
            }

            reader.Close();

            return lista;
        }

        public bool EliminarUsuario(string email)
        {
            SqlConnection con = new SqlConnection(cadenaConexion);

            con.Open();

            string sql = "DELETE FROM usuario WHERE email= @email";

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.Add("@email", System.Data.SqlDbType.NVarChar).Value = email;

            int res = cmd.ExecuteNonQuery();

            con.Close();

            return (res == 1);
        }
    }
}