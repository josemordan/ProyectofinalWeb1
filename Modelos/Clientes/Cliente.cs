using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Clientes
{
    public class Cliente
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Identificacion { get; set; }
        public string Tipo_Identificacion { get; set; }

    }
}
