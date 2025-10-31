using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_2.Modelos
{
    public class Camion
    {
        private DateTime fecha;
        private int cantidad;
        private double valorAsegurado;

        public int NroRegistro { get; set; }
        private Stack<Auto> transporte = new Stack<Auto>();
        public Camion(DateTime fecha, int cantidad)
        {
            this.fecha = fecha;
            this.cantidad = cantidad;
        }
        public void CargarVehiculo(Auto unAuto)
        {
            if(cantidad > transporte.Count)
            {
                transporte.Push(unAuto);
            }
            else {
                throw new Exception("No hay mas lugar en el camion");
            }
        }

        public Auto RetirarVehiculo()
        {
         if(transporte.Count > 0)
            {
                return transporte.Pop();
            }
            else
            {
                throw new Exception("No hay vehiculos para retirar");
            }
        }
        public string[] VerCarga ()
        {
            string[] carga = new string[transporte.Count];
            int i = 0;
            foreach (Auto auto in transporte)
            {
                carga[i] = auto.toString();
                i++;
            }
            return carga;
        }
        public string toString()
        {
            return $"{NroRegistro}-{fecha.ToShortDateString()}";
        }

        public double ValorAsegurado()
        {
            return valorAsegurado;
        }

        public int CantidadVehiculos()
        {
            return transporte.Count;
        }

    }
}
