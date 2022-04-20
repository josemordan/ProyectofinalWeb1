using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Empleados
{
    public class Empleado
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public long Codigo_Empleado { get; set; }
        public int CargoID { get; set; }
        public int DepartamentoID { get; set; }
        public DateTime Fecha_Ingreso { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public string Cargo { get; set; }
        public string Departamento { get; set; }
        public List<Departamento>  Departamentos{ get; set; }
        public List<Cargo>  Cargos{ get; set; }


    }
}
