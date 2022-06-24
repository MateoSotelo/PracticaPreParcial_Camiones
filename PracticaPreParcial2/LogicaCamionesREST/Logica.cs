using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesREST;
using PersistenciaREST;


namespace LogicaCamionesREST
{
    public sealed class Logica
    {
        private static Logica instance = null;
        private Logica() { }
        public static Logica Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Logica();
                }
                return instance;
            }
        }
        Persistencia persistencia = new Persistencia();
        public List<Camion> Camiones;
        public List<Paquete> Paquetes;
        public Camion AltaCamion(Camion nuevoCamion)
        {
            ActualizarCamiones();
            Camiones.Add(nuevoCamion);
            GuardarCamiones();

            return nuevoCamion;
        }
        public List<Camion> obtenerCamiones(string marca,int pesoMaximo)
        {
            ActualizarCamiones();
            List<Camion> listaFiltrada = Camiones;

            if (marca != "")
            {
                listaFiltrada = Camiones.Where(x => x.Marca.ToLower() == marca.ToLower()).ToList();
            }

            if (pesoMaximo != 0)
            {
                listaFiltrada = listaFiltrada.Where(x => x.PesoMaximo < pesoMaximo).ToList();
            }

            return listaFiltrada;
        }
        public bool BajaCamion(int numeroCamionEliminar)
        {
            ActualizarCamiones();
            Camion camionEliminar = Camiones.FirstOrDefault(x => x.Numero == numeroCamionEliminar);

            if (camionEliminar != null)
            {
                Camiones.Remove(camionEliminar);
                GuardarCamiones();
                return true;
            }

            return false;
        }
        public Paquete AltaPaquete(Paquete paquete)
        {
            ActualizarPaquetes();
            Paquetes.Add(paquete);
            GuardarPaquetes();

            return paquete;
        }
        public Camion BuscarCamion(int numeroCamion)
        {
            ActualizarCamiones();
            Camion camionEncontrado = Camiones.FirstOrDefault(x => x.Numero == numeroCamion);
            return camionEncontrado;
        }
        public Paquete BuscarPaquete(int numeroCamion)
        {
            ActualizarPaquetes();
            Paquete paqueteEncontrado = Paquetes.FirstOrDefault(x => x.Numero == numeroCamion);
            return paqueteEncontrado;
        }
        public void ActualizarCamiones()
        {
            Camiones = persistencia.LeerCamiones();

            if (Camiones == null)
            {
                Camiones = new List<Camion>();
            }
        }
        public void ActualizarPaquetes()
        {
            if (Paquetes != null)
            {
                this.Paquetes = persistencia.LeerPaquetes();
            }
            else
            {
                Paquetes = new List<Paquete>();
            }
        }
        public void GuardarPaquetes()
        {
            persistencia.GuardarPaquetes(Paquetes);
        }
        public void GuardarCamiones()
        {
            persistencia.GuardarCamiones(Camiones);
        }
        public Camion ModificarCamion(Camion camionModificando)
        {
            ActualizarCamiones();
            Camion modificar = Camiones.FirstOrDefault(x => x.Numero == camionModificando.Numero);

            if (modificar != null) modificar = IntercambiarValores(modificar, camionModificando);
            GuardarCamiones();
            return modificar;
        }
        public Camion IntercambiarValores(Camion modificar,Camion modificando)
        {
            modificar.Marca = modificando.Marca;
            modificar.FechaHoraLlegada = modificando.FechaHoraLlegada;
            modificar.FechaHoraSalida = modificando.FechaHoraSalida;
            modificar.PesoMaximo = modificando.PesoMaximo;

            return modificar;
        }
    }


}
