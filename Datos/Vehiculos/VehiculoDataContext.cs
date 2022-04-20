using Modelos.Vehiculos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Vehiculos
{
    public class VehiculoDataContext
    {
        /////////////////////Vehiculos
        public List<Vehiculo> ObtenerVehiculos(int id)
        {
            var list = new List<Vehiculo>();
            using (var cnn = ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                if (id == 0) cmd.CommandText = QuerysVehiculos.ConsultarVehiculo;
                else
                {
                    cmd.CommandText = $"{QuerysVehiculos.ConsultarVehiculo} and a.id =@id";
                    cmd.Parameters.AddWithValue("id", id);
                }
                var dr = cmd.ExecuteReader();
                if (!dr.HasRows) return list;
                while (dr.Read())
                {
                    list.Add(new Vehiculo
                    {
                        ID = dr.IsDBNull(dr.GetOrdinal("ID")) ? 0 : int.Parse(dr["ID"].ToString()),
                        Chasis = dr.IsDBNull(dr.GetOrdinal("Chasis")) ? string.Empty : dr["Chasis"].ToString(),
                        Placa= dr.IsDBNull(dr.GetOrdinal("Placa")) ? string.Empty : dr["Placa"].ToString(),
                        Transmision= dr.IsDBNull(dr.GetOrdinal("Transmision")) ? string.Empty : dr["Transmision"].ToString(),
                        Combustible= dr.IsDBNull(dr.GetOrdinal("Combustible")) ? string.Empty : dr["Combustible"].ToString(),
                        Mantenimiento = dr.IsDBNull(dr.GetOrdinal("Mantenimiento")) ? false: bool.Parse(dr["Mantenimiento"].ToString()),
                        Anio= dr.IsDBNull(dr.GetOrdinal("Anio")) ? string.Empty : dr["Anio"].ToString(),
                        ModeloID =dr.IsDBNull(dr.GetOrdinal("ModeloID")) ? 0 : int.Parse(dr["ModeloID"].ToString()),
                        ColorID= dr.IsDBNull(dr.GetOrdinal("ColorID")) ? 0 : int.Parse(dr["ColorID"].ToString()),
                        EmpleadoID=  dr.IsDBNull(dr.GetOrdinal("EmpleadoID")) ? 0 : int.Parse(dr["EmpleadoID"].ToString()),
                        Color=  dr.IsDBNull(dr.GetOrdinal("color")) ? string.Empty : dr["color"].ToString(),
                        Modelo =  dr.IsDBNull(dr.GetOrdinal("modelo")) ? string.Empty : dr["modelo"].ToString(),
                        Empleado =  dr.IsDBNull(dr.GetOrdinal("empleado")) ? string.Empty : dr["empleado"].ToString()
                    });
                }
                return list;
            }
        }

        public void InsertarVehiculo(Vehiculo vehiculo)
        {
            using (var cnn = ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysVehiculos.InsertarVehiculo;
                cmd.Parameters.AddWithValue("Chasis", vehiculo.Chasis);
                cmd.Parameters.AddWithValue("Placa", vehiculo.Placa);
                cmd.Parameters.AddWithValue("Transmision", vehiculo.Transmision);
                cmd.Parameters.AddWithValue("Combustible", vehiculo.Combustible);
                cmd.Parameters.AddWithValue("Mantenimiento", vehiculo.Mantenimiento);
                cmd.Parameters.AddWithValue("Anio", vehiculo.Anio);
                cmd.Parameters.AddWithValue("ModeloID", vehiculo.ModeloID);
                cmd.Parameters.AddWithValue("ColorID", vehiculo.ColorID);
                cmd.Parameters.AddWithValue("EmpleadoID", vehiculo.EmpleadoID);
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizarVehiculo(Vehiculo vehiculo)
        {
            using (var cnn = ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysVehiculos.AcatualizarVehiculo;
                cmd.Parameters.AddWithValue("Chasis", vehiculo.Chasis);
                cmd.Parameters.AddWithValue("Placa", vehiculo.Placa);
                cmd.Parameters.AddWithValue("Transmision", vehiculo.Transmision);
                cmd.Parameters.AddWithValue("Combustible", vehiculo.Combustible);
                cmd.Parameters.AddWithValue("Mantenimiento", vehiculo.Mantenimiento);
                cmd.Parameters.AddWithValue("Anio", vehiculo.Anio);
                cmd.Parameters.AddWithValue("ModeloID", vehiculo.ModeloID);
                cmd.Parameters.AddWithValue("ColorID", vehiculo.ColorID);
                cmd.Parameters.AddWithValue("EmpleadoID", vehiculo.EmpleadoID);
                cmd.Parameters.AddWithValue("id", vehiculo.ID);
                cmd.ExecuteNonQuery();
            }
        }

        public void BorrarVehiculo(int id)
        {
            using (var cnn = ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysVehiculos.BorrarVehiculo;
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
            }
        }

        /////////////////////Colores
        public List<Color> ObtenerColores(int id)
        {
            var list = new List<Color>();
            using (var cnn = ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                if (id == 0) cmd.CommandText = QuerysVehiculos.ConsultaColores;
                else
                {
                    cmd.CommandText = $"{QuerysVehiculos.ConsultaColores} and id =@id";
                    cmd.Parameters.AddWithValue("id", id);
                }
                var dr = cmd.ExecuteReader();
                if (!dr.HasRows) return list;
                while (dr.Read())
                {
                    list.Add(new Color
                    {
                        ID = dr.IsDBNull(dr.GetOrdinal("id")) ? 0 : int.Parse(dr["id"].ToString()),
                        Nombre = dr.IsDBNull(dr.GetOrdinal("nombre")) ? string.Empty : dr["nombre"].ToString()
                    });
                }
                return list;
            }
        }

        public void BorrarColor(int id)
        {
            using (var cnn = ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysVehiculos.BorrarColor;
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public void InsertarColor(Color color)
        {
            using (var cnn = ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysVehiculos.InsertarColor;
                cmd.Parameters.AddWithValue("nombre", color.Nombre);
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizarColor(Color color)
        {
            using (var cnn = ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysVehiculos.ActualizarColor;
                cmd.Parameters.AddWithValue("nombre", color.Nombre);
                cmd.Parameters.AddWithValue("id", color.ID);
                cmd.ExecuteNonQuery();
            }
        }

        //////////////////////


        /////////////////////Marca
        public List<Marca> ObtenerMarcas(int id)
        {
            var list = new List<Marca>();
            using (var cnn = ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                if (id == 0) cmd.CommandText = QuerysVehiculos.ConsultarMarca;
                else
                {
                    cmd.CommandText = $"{QuerysVehiculos.ConsultarMarca} and id =@id";
                    cmd.Parameters.AddWithValue("id", id);
                }
                var dr = cmd.ExecuteReader();
                if (!dr.HasRows) return list;
                while (dr.Read())
                {
                    list.Add(new Marca
                    {
                        ID = dr.IsDBNull(dr.GetOrdinal("id")) ? 0 : int.Parse(dr["id"].ToString()),
                        Nombre = dr.IsDBNull(dr.GetOrdinal("nombre")) ? string.Empty : dr["nombre"].ToString()
                    });
                }
                return list;
            }
        }

        public void InsertarMarca(Marca marca)
        {
            using (var cnn = ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysVehiculos.InsertarMarca;
                cmd.Parameters.AddWithValue("nombre", marca.Nombre);
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizarMarca(Marca marca)
        {
            using (var cnn = ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysVehiculos.ActualizarMarca;
                cmd.Parameters.AddWithValue("nombre", marca.Nombre);
                cmd.Parameters.AddWithValue("id", marca.ID);
                cmd.ExecuteNonQuery();
            }
        }

        public void BorrarMarca(int id)
        {
            using (var cnn = ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysVehiculos.BorrarMarca;
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
            }
        }

        //////////////////////


        /////////////////////Modelo
        public List<Modelo> ObtenerModelos(int id)
        {
            var list = new List<Modelo>();
            using (var cnn = ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                if (id == 0) cmd.CommandText = QuerysVehiculos.ConsultarModelos;
                else
                {
                    cmd.CommandText = $"{QuerysVehiculos.ConsultarModelos} and a.id =@id";
                    cmd.Parameters.AddWithValue("id", id);
                }
                var dr = cmd.ExecuteReader();
                if (!dr.HasRows) return list;
                while (dr.Read())
                {
                    list.Add(new Modelo
                    {
                        ID = dr.IsDBNull(dr.GetOrdinal("id")) ? 0 : int.Parse(dr["id"].ToString()),
                        Nombre = dr.IsDBNull(dr.GetOrdinal("nombre")) ? string.Empty : dr["nombre"].ToString(),
                        MarcaID = dr.IsDBNull(dr.GetOrdinal("MarcaID")) ? 0 : int.Parse(dr["MarcaID"].ToString()),
                        Marca = dr.IsDBNull(dr.GetOrdinal("Marca")) ? string.Empty : dr["Marca"].ToString()
                    });
                }
                return list;
            }
        }

        public void InsertarModelo(Modelo modelo)
        {
            using (var cnn = ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysVehiculos.InsertarModelo;
                cmd.Parameters.AddWithValue("nombre", modelo.Nombre);
                cmd.Parameters.AddWithValue("marcaID", modelo.MarcaID);
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizarModelo(Modelo modelo)
        {
            using (var cnn = ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysVehiculos.ActualizarModelo;
                cmd.Parameters.AddWithValue("nombre", modelo.Nombre);
                cmd.Parameters.AddWithValue("marcaID", modelo.MarcaID);
                cmd.Parameters.AddWithValue("id", modelo.ID);
                cmd.ExecuteNonQuery();
            }
        }

        public void BorrarModelo(int id)
        {
            using (var cnn = ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysVehiculos.BorrarModelo;
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
