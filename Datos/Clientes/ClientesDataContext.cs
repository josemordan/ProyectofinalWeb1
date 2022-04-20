using Modelos.Clientes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Clientes
{
    public class ClientesDataContext
    {
        public List<Cliente> ObtenerClientes(int id)
        {
            var list = new List<Cliente>();
            using (var cnn = ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                if (id == 0) cmd.CommandText = QuerysClientes.ConsultarClientes;
                else
                {
                    cmd.CommandText = $"{QuerysClientes.ConsultarClientes} and  id =@id";
                    cmd.Parameters.AddWithValue("id", id);
                }
                var dr = cmd.ExecuteReader();
                if (!dr.HasRows) return list;
                while (dr.Read())
                {
                    list.Add(new Cliente
                    {
                        ID = dr.IsDBNull(dr.GetOrdinal("id")) ? 0 : int.Parse(dr["id"].ToString()),
                        Nombre = dr.IsDBNull(dr.GetOrdinal("nombre")) ? string.Empty : dr["nombre"].ToString(),
                        Direccion = dr.IsDBNull(dr.GetOrdinal("Direccion")) ? string.Empty : dr["Direccion"].ToString(),
                        Correo = dr.IsDBNull(dr.GetOrdinal("Correo")) ? string.Empty : dr["Correo"].ToString(),
                        Telefono = dr.IsDBNull(dr.GetOrdinal("Telefono")) ? string.Empty : dr["Telefono"].ToString(),
                        Identificacion = dr.IsDBNull(dr.GetOrdinal("Identificacion")) ? string.Empty : dr["Identificacion"].ToString(),
                        Tipo_Identificacion = dr.IsDBNull(dr.GetOrdinal("Tipo_Identificacion")) ? string.Empty : dr["Tipo_Identificacion"].ToString()
                    });
                }
                return list;
            }
        }

        public void InsertarClientes(Cliente cliente)
        {
            using (var cnn = ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysClientes.InsertarCliente;
                cmd.Parameters.AddWithValue("Nombre", cliente.Nombre);
                cmd.Parameters.AddWithValue("Direccion", cliente.Direccion);
                cmd.Parameters.AddWithValue("Correo", cliente.Correo);
                cmd.Parameters.AddWithValue("Telefono", cliente.Telefono);
                cmd.Parameters.AddWithValue("Identificacion", cliente.Identificacion);
                cmd.Parameters.AddWithValue("Tipo_Identificacion", cliente.Tipo_Identificacion);
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizarClientes(Cliente cliente)
        {
            using (var cnn = ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysClientes.ActualizarCliente;
                cmd.Parameters.AddWithValue("nombre", cliente.Nombre);
                cmd.Parameters.AddWithValue("Direccion", cliente.Direccion);
                cmd.Parameters.AddWithValue("Correo", cliente.Correo);
                cmd.Parameters.AddWithValue("Telefono", cliente.Telefono);
                cmd.Parameters.AddWithValue("Identificacion", cliente.Identificacion);
                cmd.Parameters.AddWithValue("Tipo_Identificacion", cliente.Tipo_Identificacion);
                cmd.Parameters.AddWithValue("id", cliente.ID);
                cmd.ExecuteNonQuery();
            }
        }

        public void BorrarClientes(int id)
        {
            using (var cnn = ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysClientes.BorrarCliente;
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
            }
        }


        public SqlConnection ObtenerConexion()
        {
            var conexion = new SqlConnection(new Conexion().ConexionDB());
            return conexion;
        }
    }
}
