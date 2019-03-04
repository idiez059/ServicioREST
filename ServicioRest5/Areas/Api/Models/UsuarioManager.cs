using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ServicioRest5.Areas.Api.Models
{
    public class UsuarioManager
    {
        private static string cadenaConexion =
            @"Server=DESKTOP-NSHQPSH;Initial Catalog=BDCalorias;Integrated Security=True";

        public bool insertarUsuario(Usuario usu)
        {
            SqlConnection con = new SqlConnection(cadenaConexion);

            con.Open();

            string sql = "INSERT INTO usuario (email, password, foto) VALUES (@email, @password, @foto)";

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.Add("@email", System.Data.SqlDbType.NVarChar).Value = usu.email;
            cmd.Parameters.Add("@password", System.Data.SqlDbType.NVarChar).Value = usu.password;
            cmd.Parameters.Add("@foto", System.Data.SqlDbType.NVarChar).Value = usu.foto;

            int res = cmd.ExecuteNonQuery();

            con.Close();

            return (res == 1);
        }

        public bool ActualizarCliente(Usuario usu)
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

        public Usuario obtenerUsuario(string email)
        {
            Usuario usu = null;

            SqlConnection con = new SqlConnection(cadenaConexion);

            con.Open();

            string sql = "SELECT email, password, foto FROM usuario WHERE email = @email";

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.Add("@email", System.Data.SqlDbType.NVarChar).Value = usu.email;
            SqlDataReader reader =
                 cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);


            if (reader.Read())
            {
                usu = new Usuario();
                usu.email = email;
                usu.password= reader.GetString(0);
                usu.foto = reader.GetString(1);
            }

            reader.Close();

            return usu;
        }

        public List<Cliente> ObtenerClientes()
        {
            List<Cliente> lista = new List<Cliente>();

            SqlConnection con = new SqlConnection(cadenaConexion);

            con.Open();

            string sql = "SELECT IdCliente, Nombre, Telefono FROM Clientes";

            SqlCommand cmd = new SqlCommand(sql, con);

            SqlDataReader reader =
                cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

            while (reader.Read())
            {
                Cliente cli = new Cliente();

                cli = new Cliente();
                cli.Id = reader.GetInt32(0);
                cli.Nombre = reader.GetString(1);
                cli.Telefono = reader.GetInt32(2);

                lista.Add(cli);
            }

            reader.Close();

            return lista;
        }

        public bool EliminarCliente(int id)
        {
            SqlConnection con = new SqlConnection(cadenaConexion);

            con.Open();

            string sql = "DELETE FROM Clientes WHERE IdCliente = @idcliente";

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.Add("@idcliente", System.Data.SqlDbType.Int).Value = id;

            int res = cmd.ExecuteNonQuery();

            con.Close();

            return (res == 1);
        }
    }
}