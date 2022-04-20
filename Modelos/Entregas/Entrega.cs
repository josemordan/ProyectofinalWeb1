using Modelos.Clientes;
using Modelos.Empleados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Entregas
{
   public class Entrega
    {
        public int ID { get; set; }
        public string Destino { get; set; }
        public DateTime Fecha_Salida { get; set; }
        public DateTime Fecha_Regreso { get; set; }
        public string Descripcion { get; set; }
        public double Peso { get; set; }
        public int EmpleadoID { get; set; }
        public int ClienteID { get; set; }
        public int PrioridadID { get; set; }
        public string Empleado { get; set; }
        public string Cliente { get; set; }
        public string Prioridad { get; set; }
        public List<Empleado> Empleados { get; set; }
        public List<Cliente> Clientes { get; set; }
        public List<Prioridades> Prioridades { get; set; }
    }
}
