﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Vehiculos
{
    public class Modelo
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int MarcaID { get; set; }
        public string Marca { get; set; }
        public List<Marca> Marcas { get; set; }
    }
}

