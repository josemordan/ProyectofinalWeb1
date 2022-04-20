using Modelos.Empleados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Vehiculos
{
    public class Vehiculo
    {
        public int ID { get; set; }
        public string Chasis { get; set; }
        public string Placa { get; set; }
        public string Transmision { get; set; }
        public string Combustible { get; set; }
        public bool Mantenimiento { get; set; }
        public string Anio { get; set; }
        public int ModeloID { get; set; }
        public int ColorID { get; set; }
        public int EmpleadoID { get; set; }
        public string Borrado { get; set; }
        public string Color { get; set; }
        public string Modelo { get; set; }
        public string Empleado { get; set; }
        public List<Modelo> Modelos { get; set; }
        public List<Color> Colores { get; set; }
        public List<Empleado> Empleados { get; set; }
    }
}
