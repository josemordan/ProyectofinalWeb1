using Modelos.Incidencias;
using Modelos.Vehiculos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Incidencias
{
    public class IncidenciaDataContext
    {
        public List<Taller> ObtenerTalleres(int id)
        {
            var list = new List<Taller>();
            using (var cnn = ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                if (id == 0) cmd.CommandText = QuerysIncidencias.ConsultarTaller;
                else
                {
                    cmd.CommandText = $"{QuerysIncidencias.ConsultarTaller} and id =@id";
                    cmd.Parameters.AddWithValue("id", id);
                }
                var dr = cmd.ExecuteReader();
                if (!dr.HasRows) return list;
                while (dr.Read())
                {
                    list.Add(new Taller
                    {
                        ID = dr.IsDBNull(dr.GetOrdinal("ID")) ? 0 : int.Parse(dr["ID"].ToString()),
                        Nombre = dr.IsDBNull(dr.GetOrdinal("Nombre")) ? string.Empty : dr["Nombre"].ToString(),
                        Direccion = dr.IsDBNull(dr.GetOrdinal("Direccion")) ? string.Empty : dr["Direccion"].ToString(),
                        Telefono = dr.IsDBNull(dr.GetOrdinal("Telefono")) ? string.Empty : dr["Telefono"].ToString()
                    });
                }
                return list;
            }
        }

        public void InsertarTaller(Taller taller)
        {
            using (var cnn = ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysIncidencias.InsertarTaller;
                cmd.Parameters.AddWithValue("nombre", taller.Nombre);
                cmd.Parameters.AddWithValue("Direccion", taller.Direccion);
                cmd.Parameters.AddWithValue("Telefono", taller.Telefono);
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizarTaller(Taller taller)
        {
            using (var cnn = ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysIncidencias.ActualizarTaller;
                cmd.Parameters.AddWithValue("nombre", taller.Nombre);
                cmd.Parameters.AddWithValue("Direccion", taller.Direccion);
                cmd.Parameters.AddWithValue("Telefono", taller.Telefono);
                cmd.Parameters.AddWithValue("id", taller.ID);
                cmd.ExecuteNonQuery();
            }
        }

        public void BorrarTaller(int id)
        {
            using (var cnn = ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysIncidencias.BorrarTaller;
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
            }
        }
        /////////////////////////////////////////////////

        public List<Vehiculo> ObtenerVehiculosIncidencia()
        {
            var list = new List<Vehiculo>();
            using (var cnn = ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysIncidencias.ConsultarVehiculosMatenimientos;

                var dr = cmd.ExecuteReader();
                if (!dr.HasRows) return list;
                while (dr.Read())
                {
                    list.Add(new Vehiculo
                    {
                        ID = dr.IsDBNull(dr.GetOrdinal("ID")) ? 0 : int.Parse(dr["ID"].ToString()),
                        Chasis = dr.IsDBNull(dr.GetOrdinal("Nombre")) ? string.Empty : dr["Nombre"].ToString()
                    });
                }
                return list;
            }
        }

        public List<Incidencia> ObtenerIncidencias(int id)
        {
            var list = new List<Incidencia>();
            using (var cnn = ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                if (id == 0) cmd.CommandText = QuerysIncidencias.ConsultarIncidencia;
                else
                {
                    cmd.CommandText = $"{QuerysIncidencias.ConsultarIncidencia} and a.id =@id";
                    cmd.Parameters.AddWithValue("id", id);
                }
                var dr = cmd.ExecuteReader();
                if (!dr.HasRows) return list;
                while (dr.Read())
                {
                    list.Add(new Incidencia
                    {
                        ID = dr.IsDBNull(dr.GetOrdinal("ID")) ? 0 : int.Parse(dr["ID"].ToString()),
                        Descripcion = dr.IsDBNull(dr.GetOrdinal("Descripcion")) ? string.Empty : dr["Descripcion"].ToString(),
                        Fecha_Entrada = dr.IsDBNull(dr.GetOrdinal("Fecha_Entrada")) ? new DateTime(1900, 1, 1) : DateTime.Parse(dr["Fecha_Entrada"].ToString()),
                        Fecha_Salida = dr.IsDBNull(dr.GetOrdinal("Fecha_Salida")) ? new DateTime(1900, 1, 1) : DateTime.Parse(dr["Fecha_Salida"].ToString()),
                        TallerID = dr.IsDBNull(dr.GetOrdinal("TallerID")) ? 0 : int.Parse(dr["TallerID"].ToString()),
                        VehiculoID = dr.IsDBNull(dr.GetOrdinal("VehiculoID")) ? 0 : int.Parse(dr["VehiculoID"].ToString()),
                        Completada = dr.IsDBNull(dr.GetOrdinal("Completada")) ? false : bool.Parse(dr["Completada"].ToString()),
                        Taller = dr.IsDBNull(dr.GetOrdinal("taller")) ? string.Empty : dr["taller"].ToString(),
                        Vehiculo = dr.IsDBNull(dr.GetOrdinal("vehiculo")) ? string.Empty : dr["vehiculo"].ToString()
                    });
                }
                return list;
            }
        }

        public void InsertarIncidencia(Incidencia incidencia)
        {
            using (var cnn = ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysIncidencias.InsertarIncidencia;
                cmd.Parameters.AddWithValue("Descripcion", incidencia.Descripcion);
                cmd.Parameters.AddWithValue("Fecha_Entrada", incidencia.Fecha_Entrada);
                cmd.Parameters.AddWithValue("Fecha_Salida", incidencia.Fecha_Salida);
                cmd.Parameters.AddWithValue("TallerID", incidencia.TallerID);
                cmd.Parameters.AddWithValue("VehiculoID", incidencia.VehiculoID);
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizarIncidencia(Incidencia incidencia)
        {
            using (var cnn = ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysIncidencias.ActualizarIncidencia;
                cmd.Parameters.AddWithValue("Descripcion", incidencia.Descripcion);
                cmd.Parameters.AddWithValue("TallerID", incidencia.TallerID);
                cmd.Parameters.AddWithValue("VehiculoID", incidencia.VehiculoID);
                cmd.Parameters.AddWithValue("Completada", incidencia.Completada);
                cmd.Parameters.AddWithValue("id", incidencia.ID);
                cmd.ExecuteNonQuery();
            }
        }

        public void BorrarIncidencia(int id)
        {
            using (var cnn = ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysIncidencias.BorrarIncidencia;
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizarIncidenciamatenimiento(int id)
        {
            using (var cnn = ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysIncidencias.ActualizarMatenimientoVehiculos;
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
