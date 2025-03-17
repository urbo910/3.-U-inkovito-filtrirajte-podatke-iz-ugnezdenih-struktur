using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterOsebe
{
    public class Oseba
    {
        public string Ime { get; set; }
        public int Starost { get; set; }
        public decimal Placa { get; set; }

        public Oseba(string ime, int starost, decimal placa)
        {
            Ime = ime;
            Starost = starost;
            Placa = placa;
        }
    }
}
