using Modelos.Empleados;
using Modelos.Entregas;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entregas
{
    public class EntregasDataContext
    {
        ///////////////////////////////////////////////////Entregas
        public List<Entrega> ObtenerEntregas(int id)
        {
            var list = new List<Entrega>();
            using (var cnn = ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                if (id == 0) cmd.CommandText = QuerysEntregas.ConsultarEntrega;
                else
                {
                    cmd.CommandText = $" {QuerysEntregas.ConsultarEntrega} and a.id =@id";
                    cmd.Parameters.AddWithValue("id", id);
                }
                var dr = cmd.ExecuteReader();
                if (!dr.HasRows) return list;
                while (dr.Read())
                {
                    list.Add(new Entrega
                    {
                        ID = dr.IsDBNull(dr.GetOrdinal("id")) ? 0 : int.Parse(dr["id"].ToString()),
                        Destino = dr.IsDBNull(dr.GetOrdinal("Destino")) ? string.Empty : dr["Destino"].ToString(),
                        Fecha_Salida = dr.IsDBNull(dr.GetOrdinal("Fecha_Salida")) ? new DateTime(1900, 1, 1) : DateTime.Parse(dr["Fecha_Salida"].ToString()),
                        Fecha_Regreso = dr.IsDBNull(dr.GetOrdinal("Fecha_Regreso")) ? new DateTime(1900, 1, 1) : DateTime.Parse(dr["Fecha_Regreso"].ToString()),
                        Descripcion = dr.IsDBNull(dr.GetOrdinal("Descripcion")) ? string.Empty : dr["Descripcion"].ToString(),
                        Peso = dr.IsDBNull(dr.GetOrdinal("Peso")) ? 0 : double.Parse(dr["Peso"].ToString()),
                        EmpleadoID = dr.IsDBNull(dr.GetOrdinal("EmpleadoID")) ? 0 : int.Parse(dr["EmpleadoID"].ToString()),
                        ClienteID = dr.IsDBNull(dr.GetOrdinal("ClienteID")) ? 0 : int.Parse(dr["ClienteID"].ToString()),
                        PrioridadID = dr.IsDBNull(dr.GetOrdinal("PrioridadID")) ? 0 : int.Parse(dr["PrioridadID"].ToString()),
                        Empleado = dr.IsDBNull(dr.GetOrdinal("Empleado")) ? string.Empty : dr["Empleado"].ToString(),
                        Cliente = dr.IsDBNull(dr.GetOrdinal("Cliente")) ? string.Empty : dr["Cliente"].ToString(),
                        Prioridad = dr.IsDBNull(dr.GetOrdinal("Prioridad")) ? string.Empty : dr["Prioridad"].ToString()
                    });
                }
                return list;
            }
        }

        public void InsertarEntrega(Entrega entrega)
        {
            using (var cnn = ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysEntregas.InsertarEntrega;
                cmd.Parameters.AddWithValue("Destino", entrega.Destino);
                cmd.Parameters.AddWithValue("Fecha_Salida", entrega.Fecha_Salida);
                cmd.Parameters.AddWithValue("Fecha_Regreso", entrega.Fecha_Regreso);
                cmd.Parameters.AddWithValue("Descripcion", entrega.Descripcion);
                cmd.Parameters.AddWithValue("Peso", entrega.Peso);
                cmd.Parameters.AddWithValue("EmpleadoID", entrega.EmpleadoID);
                cmd.Parameters.AddWithValue("ClienteID", entrega.ClienteID);
                cmd.Parameters.AddWithValue("PrioridadID", entrega.PrioridadID);
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizarEntrega(Entrega entrega)
        {
            using (var cnn = ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysEntregas.ActualziarEntrega;
                cmd.Parameters.AddWithValue("Destino", entrega.Destino);
                cmd.Parameters.AddWithValue("Descripcion", entrega.Descripcion);
                cmd.Parameters.AddWithValue("Peso", entrega.Peso);
                cmd.Parameters.AddWithValue("EmpleadoID", entrega.EmpleadoID);
                cmd.Parameters.AddWithValue("ClienteID", entrega.ClienteID);
                cmd.Parameters.AddWithValue("PrioridadID", entrega.PrioridadID);
                cmd.Parameters.AddWithValue("id", entrega.ID);
                cmd.ExecuteNonQuery();
            }
        }

        public void BorrarEntrega(int id)
        {
            using (var cnn = ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysEntregas.BorrarEntrega;
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Empleado> ObtenerEmpleadosDisponibles()
        {
            var list = new List<Empleado>();
            using (var cnn = ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysEntregas.ConsultarVehiculosEmpleadosDisponibles;
              
                var dr = cmd.ExecuteReader();
                if (!dr.HasRows) return list;
                while (dr.Read())
                {
                    list.Add(new Empleado
                    {
                        ID = dr.IsDBNull(dr.GetOrdinal("id")) ? 0 : int.Parse(dr["id"].ToString()),
                        Nombre = dr.IsDBNull(dr.GetOrdinal("Nombre")) ? string.Empty : dr["Nombre"].ToString()
                    });
                }
                return list;
            }
        }

        ///////////////////////////////////////////////////
        ///////////////////////////////////////////////////Prioridades
        public List<Prioridades> ObtenerPrioridad(int id)
        {
            var list = new List<Prioridades>();
            using (var cnn = ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                if (id == 0) cmd.CommandText = QuerysEntregas.ConsultarPrioridad;
                else
                {
                    cmd.CommandText = $" {QuerysEntregas.ConsultarPrioridad} and id =@id";
                    cmd.Parameters.AddWithValue("id", id);
                }
                var dr = cmd.ExecuteReader();
                if (!dr.HasRows) return list;
                while (dr.Read())
                {
                    list.Add(new Prioridades
                    {
                        ID = dr.IsDBNull(dr.GetOrdinal("id")) ? 0 : int.Parse(dr["id"].ToString()),
                        Nombre = dr.IsDBNull(dr.GetOrdinal("nombre")) ? string.Empty : dr["nombre"].ToString(),
                        Horas = dr.IsDBNull(dr.GetOrdinal("Horas")) ? 0 : int.Parse(dr["Horas"].ToString())
                    });
                }
                return list;
            }
        }

        public void InsertaPrioridad(Prioridades prioridades)
        {
            using (var cnn = ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysEntregas.InsertarPrioridad;
                cmd.Parameters.AddWithValue("nombre", prioridades.Nombre);
                cmd.Parameters.AddWithValue("horas", prioridades.Horas);
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizarPrioridad(Prioridades prioridades)
        {
            using (var cnn = ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysEntregas.ActualizarPrioridad;
                cmd.Parameters.AddWithValue("nombre", prioridades.Nombre);
                cmd.Parameters.AddWithValue("horas", prioridades.Horas);
                cmd.Parameters.AddWithValue("id", prioridades.ID);
                cmd.ExecuteNonQuery();
            }
        }

        public void BorrarPrioridad(int id)
        {
            using (var cnn = ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysEntregas.BorrarPrioridad;
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
            }
        }

        ///////////////////////////////////////////////////
        public SqlConnection ObtenerConexion()
        {
            var conexion = new SqlConnection(new Conexion().ConexionDB());
            return conexion;
        }
    }
}
