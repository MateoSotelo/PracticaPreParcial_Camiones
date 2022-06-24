using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesServicioREST
{
    public class PaqueteServicio
    {
        public int Peso { get; set; }
        public int Numero { get; set; }
        public string CiudadOrigen { get; set; }
        public PaqueteServicio(int peso, int numero, string ciudadOrigen)
        {
            Peso = peso;
            Numero = numero;
            CiudadOrigen = ciudadOrigen;
        }
    }
}
