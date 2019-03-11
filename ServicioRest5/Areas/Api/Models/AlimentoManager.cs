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
            @"Server=DESKTOP-3VURD55;Initial Catalog=BDCalorias;Integrated Security=True"; //Integrated Security en True, 
                                                                                           //lo cambio a false

        public bool InsertarAlimento(Alimento ali)
        {
            SqlConnection con = new SqlConnection(cadenaConexion);

            con.Open();

            string sql = "INSERT INTO alimentos (codigo, nombre, calorias) VALUES (@codigo, @nombre, @calorias)";

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.Add("@codigo", System.Data.SqlDbType.NVarChar).Value = ali.codigo;
            cmd.Parameters.Add("@nombre", System.Data.SqlDbType.NVarChar).Value = ali.nombre;
            cmd.Parameters.Add("@calorias", System.Data.SqlDbType.NVarChar).Value = ali.calorias;

            int res = cmd.ExecuteNonQuery();

            con.Close();

            return (res == 1);
        }

        public bool ActualizarAlimento(Alimento ali)
        {
            SqlConnection con = new SqlConnection(cadenaConexion);

            con.Open();

            string sql = "UPDATE Alimentos SET codigo = @codigo, nombre = @nombre, calorias = @calorias" +
                " WHERE codigo = @codigo";

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.Add("@codigo", System.Data.SqlDbType.NVarChar).Value = ali.codigo;
            cmd.Parameters.Add("@nombre", System.Data.SqlDbType.Int).Value = ali.nombre;
            cmd.Parameters.Add("@calorias", System.Data.SqlDbType.Int).Value = ali.calorias;

            int res = cmd.ExecuteNonQuery();

            con.Close();

            return (res == 1);
        }

        public Alimento ObtenerAlimento(int codigo)
        {
            Alimento ali = null;

            SqlConnection con = new SqlConnection(cadenaConexion);

            con.Open();

            string sql = "SELECT codigo, nombre, calorias FROM Alimentos WHERE codigo = @codigo";

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.Add("@codigo", System.Data.SqlDbType.Int).Value = codigo;
            SqlDataReader reader =
                 cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);


            if (reader.Read())
            {
                ali = new Alimento();
                ali.codigo = codigo;
                ali.nombre = reader.GetString(1);
                ali.calorias = reader.GetInt32(2);//Me obliga a poner Int32 espero que no de problemas
            }

            reader.Close();

            return ali;
        }

        public List<Alimento> ObtenerAlimentos()
        {
            List<Alimento> lista = new List<Alimento>();

            SqlConnection con = new SqlConnection(cadenaConexion);

            con.Open();

            string sql = "SELECT codigo, nombre, calorias FROM alimentos";

            SqlCommand cmd = new SqlCommand(sql, con);

            SqlDataReader reader =
                cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

            while (reader.Read())
            {
                Alimento ali = new Alimento();

                ali = new Alimento();
                ali.codigo = reader.GetInt32(0);
                ali.nombre = reader.GetString(1);
                ali.calorias = reader.GetInt32(2);

                lista.Add(ali);
            }

            reader.Close();

            return lista;
        }

        public bool EliminarAlimento(int codigo)
        {
            SqlConnection con = new SqlConnection(cadenaConexion);

            con.Open();

            string sql = "DELETE FROM Alimentos WHERE codigo= @codigo";

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.Add("@codigo", System.Data.SqlDbType.Int).Value = codigo;

            int res = cmd.ExecuteNonQuery();

            con.Close();

            return (res == 1);
        }
    }
}