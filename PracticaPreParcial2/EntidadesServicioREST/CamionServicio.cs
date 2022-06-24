using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.ComponentModel.DataAnnotations;

namespace EntidadesServicioREST
{
    public class CamionServicio
    {
        public int Numero { get; set; }
        public string Marca { get; set; }
        public DateTime FechaHoraSalida { get; set; }
        public DateTime FechaHoraLlegada { get; set; }
        [Required(ErrorMessage = "El peso maximo es obligatorio.")]
        public int PesoMaximo { get; set; }
        public CamionServicio(int numero, string marca, DateTime fechaHoraSalida, DateTime fechaHoraLlegada, int pesoMaximo)
        {
            Numero = numero;
            Marca = marca;
            FechaHoraSalida = fechaHoraSalida;
            FechaHoraLlegada = fechaHoraLlegada;
            PesoMaximo = pesoMaximo;
        }
    }
}
