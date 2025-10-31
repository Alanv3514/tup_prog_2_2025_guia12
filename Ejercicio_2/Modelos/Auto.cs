using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_2.Modelos
{
    public class Auto
    {
        private int numeroRegistro;
        private string modelo;
        public double Precio { get; set; }

        public Auto(int numeroRegistro, string modelo, double precio)
        {
            this.numeroRegistro = numeroRegistro;
            this.modelo = modelo;
        }
        public int NroRegistro()
        {
            return numeroRegistro;
        }
        public string toString()
        {
            return $"{numeroRegistro};{modelo}";
        }
    }
}
