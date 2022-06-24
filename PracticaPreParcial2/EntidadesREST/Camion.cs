using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesREST
{
    public class Camion
    {
        public int Numero { get; set; }
        public string Marca { get; set; }
        public DateTime FechaHoraSalida { get; set; }
        public DateTime FechaHoraLlegada { get; set; }
        public int PesoMaximo { get; set; }
        public Camion(int numero, string marca, DateTime fechaHoraSalida, DateTime fechaHoraLlegada, int pesoMaximo)
        {
            Numero = numero;
            Marca = marca;
            FechaHoraSalida = fechaHoraSalida;
            FechaHoraLlegada = fechaHoraLlegada;
            PesoMaximo = pesoMaximo;
        }
    }
}
