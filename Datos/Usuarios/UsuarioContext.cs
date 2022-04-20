using Modelos.Usuarios;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Usuarios
{
    public class UsuarioContext
    {
        public List<Usuario> ConsultarUsuario(int id)
        {
            var datos = new List<Usuario>();
            using (var cnn = ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysUsuarios.ConsultarUsuarios;
                cmd.Parameters.AddWithValue("id", id);
                var dr = cmd.ExecuteReader();
                if (!dr.HasRows)
                {
                    cnn.Close();
                    return datos;
                }
                while (dr.Read())
                {
                    datos.Add(new Usuario
                    {
                        UsuarioId = dr.IsDBNull(dr.GetOrdinal("UsuarioId")) ? 0 : int.Parse(dr["UsuarioId"].ToString()),
                        Nombre = dr.IsDBNull(dr.GetOrdinal("Nombre")) ? string.Empty : dr["Nombre"].ToString(),
                        Apellido = dr.IsDBNull(dr.GetOrdinal("Apellido")) ? string.Empty : dr["Apellido"].ToString(),                        
                        NombreUsuario = dr.IsDBNull(dr.GetOrdinal("NombreUsuario")) ? string.Empty : dr["NombreUsuario"].ToString(),
                        Contrasena = dr.IsDBNull(dr.GetOrdinal("Contrasena")) ? string.Empty : dr["Contrasena"].ToString()
                    });
                }
                cnn.Close();
                return datos;
            }
        }

        public int Autentica(string userId, string clave)
        {
            using (var cnn = ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysUsuarios.Autentica;
                cmd.Parameters.AddWithValue("userID", userId);
                cmd.Parameters.AddWithValue("clave", clave);
                var dr = cmd.ExecuteReader();
                if (!dr.HasRows)
                {
                    cnn.Close();
                    return 0;
                }
                dr.Read();
                int id = dr.IsDBNull(dr.GetOrdinal("UsuarioId")) ? 0 : int.Parse(dr["UsuarioId"].ToString());
                cnn.Close();
                return id;
            }
        }

        public SqlConnection ObtenerConexion()
        {
            var conexion = new SqlConnection(new Conexion().ConexionDB());
            return conexion;
        }
    }
}
