using Modelos.Vehiculos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Incidencias
{
    public class Incidencia
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha_Entrada { get; set; }
        public DateTime Fecha_Salida { get; set; }
        public int TallerID { get; set; }
        public int VehiculoID { get; set; }
        public bool Completada { get; set; }
        public string Taller { get; set; }
        public string Vehiculo { get; set; }
        public List<Taller> Talleres { get; set; }
        public List<Vehiculo> Vehiculos { get; set; }
    }
}
