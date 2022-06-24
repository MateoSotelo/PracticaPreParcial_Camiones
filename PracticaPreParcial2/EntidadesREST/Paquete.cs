using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesREST
{
    public class Paquete
    {
        public int Peso { get; set; }
        public int Numero { get; set; }
        public string CiudadOrigen { get; set; }
        public Paquete(int peso, int numero, string ciudadOrigen)
        {
            Peso = peso;
            Numero = numero;
            CiudadOrigen = ciudadOrigen;
        }
    }
}
