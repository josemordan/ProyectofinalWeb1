using Modelos.Empleados;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Empleados
{
    public class EmpleadoDataContext
    {
        /////////////////////////////////////////Empelado
        public List<Empleado> ObtenerEmpleados(int id)
        {
            var list = new List<Empleado>();
            using (var cnn = ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                if (id == 0) cmd.CommandText = QuerysEmpleados.ConsultarEmpleados;
                else
                {
                    cmd.CommandText = $"{QuerysEmpleados.ConsultarEmpleados} and e.id =@id";
                    cmd.Parameters.AddWithValue("id", id);
                }
                var dr = cmd.ExecuteReader();
                if (!dr.HasRows) return list;
                while (dr.Read())
                {
                    list.Add(new Empleado
                    {
                        ID = dr.IsDBNull(dr.GetOrdinal("ID")) ? 0 : int.Parse(dr["ID"].ToString()),
                        Nombre = dr.IsDBNull(dr.GetOrdinal("Nombre")) ? string.Empty : dr["Nombre"].ToString(),
                        Cedula = dr.IsDBNull(dr.GetOrdinal("Cedula")) ? string.Empty : dr["Cedula"].ToString(),
                        Correo = dr.IsDBNull(dr.GetOrdinal("Correo")) ? string.Empty : dr["Correo"].ToString(),
                        Telefono = dr.IsDBNull(dr.GetOrdinal("Telefono")) ? string.Empty : dr["Telefono"].ToString(),
                        Codigo_Empleado = dr.IsDBNull(dr.GetOrdinal("Codigo_Empleado")) ? 0 : long.Parse(dr["Codigo_Empleado"].ToString()),
                        CargoID = dr.IsDBNull(dr.GetOrdinal("CargoID")) ? 0 : int.Parse(dr["CargoID"].ToString()),
                        DepartamentoID = dr.IsDBNull(dr.GetOrdinal("DepartamentoID")) ? 0 : int.Parse(dr["DepartamentoID"].ToString()),
                        Fecha_Ingreso = dr.IsDBNull(dr.GetOrdinal("Fecha_Ingreso")) ? new DateTime(1900, 1, 1) : DateTime.Parse(dr["Fecha_Ingreso"].ToString()),
                        Fecha_Nacimiento = dr.IsDBNull(dr.GetOrdinal("Fecha_Nacimiento")) ? new DateTime(1900, 1, 1) : DateTime.Parse(dr["Fecha_Nacimiento"].ToString()),
                        Cargo = dr.IsDBNull(dr.GetOrdinal("Cargo")) ? string.Empty : dr["Cargo"].ToString(),
                        Departamento = dr.IsDBNull(dr.GetOrdinal("Departamento")) ? string.Empty : dr["Departamento"].ToString()
                    });
                }
                return list;
            }
        }

        public void InsertaEmpleado(Empleado empleado)
        {
            using (var cnn = ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysEmpleados.InsertarEmpleado;
                cmd.Parameters.AddWithValue("Nombre", empleado.Nombre);
                cmd.Parameters.AddWithValue("Cedula", empleado.Cedula);
                cmd.Parameters.AddWithValue("Correo", empleado.Correo);
                cmd.Parameters.AddWithValue("Telefono", empleado.Telefono);
                cmd.Parameters.AddWithValue("Codigo_Empleado", empleado.Codigo_Empleado);
                cmd.Parameters.AddWithValue("CargoID", empleado.CargoID);
                cmd.Parameters.AddWithValue("DepartamentoID", empleado.DepartamentoID);
                cmd.Parameters.AddWithValue("Fecha_Ingreso", empleado.Fecha_Ingreso);
                cmd.Parameters.AddWithValue("Fecha_Nacimiento", empleado.Fecha_Nacimiento);
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizarEmpleado(Empleado empleado)
        {
            using (var cnn = ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysEmpleados.ActualizarEmpleado;
                cmd.Parameters.AddWithValue("Nombre", empleado.Nombre);
                cmd.Parameters.AddWithValue("Cedula", empleado.Cedula);
                cmd.Parameters.AddWithValue("Correo", empleado.Correo);
                cmd.Parameters.AddWithValue("Telefono", empleado.Telefono);
                cmd.Parameters.AddWithValue("Codigo_Empleado", empleado.Codigo_Empleado);
                cmd.Parameters.AddWithValue("CargoID", empleado.CargoID);
                cmd.Parameters.AddWithValue("DepartamentoID", empleado.DepartamentoID);
                cmd.Parameters.AddWithValue("id", empleado.ID);
                cmd.ExecuteNonQuery();
            }
        }

        public void BorrarEmpleado(int id)
        {
            using (var cnn = ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysEmpleados.BorrarEmpleado;
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
            }
        }
        /////////////////////////////////////////
        /////////////////////////////////////////Departamento
        public List<Departamento> ObtenerDepartamento(int id)
        {
            var list = new List<Departamento>();
            using (var cnn = ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                if (id == 0) cmd.CommandText = QuerysEmpleados.ConsultarDepartamaneto;
                else
                {
                    cmd.CommandText = $"{QuerysEmpleados.ConsultarDepartamaneto} and id =@id";
                    cmd.Parameters.AddWithValue("id", id);
                }
                var dr = cmd.ExecuteReader();
                if (!dr.HasRows) return list;
                while (dr.Read())
                {
                    list.Add(new Departamento
                    {
                        ID = dr.IsDBNull(dr.GetOrdinal("id")) ? 0 : int.Parse(dr["id"].ToString()),
                        Nombre = dr.IsDBNull(dr.GetOrdinal("nombre")) ? string.Empty : dr["nombre"].ToString(),
                    });
                }
                return list;
            }
        }

        public void InsertaDepartamento(Departamento departamento)
        {
            using (var cnn = ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysEmpleados.InsertarDepartamento;
                cmd.Parameters.AddWithValue("nombre", departamento.Nombre);
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizarDepartamento(Departamento departamento)
        {
            using (var cnn = ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysEmpleados.ActualizarDepartamento;
                cmd.Parameters.AddWithValue("nombre", departamento.Nombre);
                cmd.Parameters.AddWithValue("id", departamento.ID);
                cmd.ExecuteNonQuery();
            }
        }

        public void BorrarDepartamento(int id)
        {
            using (var cnn = ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysEmpleados.BorrarDepartamento;
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
            }
        }
        /////////////////////////////////////////
        /////////////////////////////////////////Cargo

        public List<Cargo> ObtenerCargos(int id)
        {
            var list = new List<Cargo>();
            using (var cnn = ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                if (id == 0) cmd.CommandText = QuerysEmpleados.ConsultarCargos;
                else
                {
                    cmd.CommandText = $"{QuerysEmpleados.ConsultarCargos} and id =@id";
                    cmd.Parameters.AddWithValue("id", id);
                }
                var dr = cmd.ExecuteReader();
                if (!dr.HasRows) return list;
                while (dr.Read())
                {
                    list.Add(new Cargo
                    {
                        ID = dr.IsDBNull(dr.GetOrdinal("id")) ? 0 : int.Parse(dr["id"].ToString()),
                        Nombre = dr.IsDBNull(dr.GetOrdinal("nombre")) ? string.Empty : dr["nombre"].ToString(),
                    });
                }
                return list;
            }
        }

        public void InsertaCargo(Cargo cargo)
        {
            using (var cnn = ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysEmpleados.InsertarCargo;
                cmd.Parameters.AddWithValue("nombre", cargo.Nombre);
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizarCargo(Cargo cargo)
        {
            using (var cnn = ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysEmpleados.ActualizarCargo;
                cmd.Parameters.AddWithValue("nombre", cargo.Nombre);
                cmd.Parameters.AddWithValue("id", cargo.ID);
                cmd.ExecuteNonQuery();
            }
        }

        public void BorrarCargo(int id)
        {
            using (var cnn = ObtenerConexion())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand();
                cmd.CommandTimeout = 0;
                cmd.CommandText = QuerysEmpleados.BorrarCargo;
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
            }
        }


        /////////////////////////////////////////
        public SqlConnection ObtenerConexion()
        {
            var conexion = new SqlConnection(new Conexion().ConexionDB());
            return conexion;
        }
    }
}
