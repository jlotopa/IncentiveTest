using System;

namespace IncentiveTest.Models
{
    public class Cliente
    {
        public string Ciudad { get; set; }

        public int Codigo { get; set; }

        public string Direccion { get; set; }

        public bool Estado { get; set; }

        public DateTime FechaRegistro { get; set; }

        public string Nombre { get; set; }
    }
}