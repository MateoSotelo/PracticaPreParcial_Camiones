using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EntidadesREST;
using EntidadesServicioREST;
using LogicaCamionesREST;

namespace ServicioCamionesREST.Controllers
{
    [RoutePrefix("api/Camiones")]
    public class CamionesController : ApiController
    {
        public IHttpActionResult Get(string marca = "")
        {
            List<CamionServicio> lista = ConvertirLista(Logica.Instance.obtenerCamiones(marca));

            if (lista.Count != 0)
            {
                return Ok(lista);
            }

            return BadRequest("No se econtraron valores a entregar");
        }
        [Route("{numero}")]
        public IHttpActionResult Get(int numero)
        {
            CamionServicio camion = ConvertirCamion(Logica.Instance.BuscarCamion(numero));

            if (camion != null)
            {
                return Ok(camion);
            }

            return BadRequest("No se encontro el camion buscado");
        }
        [Route("nuevoCamion")]
        public IHttpActionResult Post([FromBody] CamionServicio nuevoCamion)
        {
            if (ModelState.IsValid)
            {
                Logica.Instance.AltaCamion(ConvertirCamionLogica(nuevoCamion));
                return Ok();
            }

            return BadRequest(ModelState);
        }
        [Route("{numero}")]
        public IHttpActionResult Delete(int numero)
        {
            if (Logica.Instance.BajaCamion(numero) == true)
            {
                return Ok("Camion eliminado");
            }

            return BadRequest("No se encontro el numero del camion");
        }
        public IHttpActionResult Put([FromBody] CamionServicio camionServicio)
        {
            CamionServicio camionModificado = ConvertirCamion(Logica.Instance.ModificarCamion(ConvertirCamionLogica(camionServicio)));

            if (camionModificado != null)
            {
                return Ok(camionModificado);
            }

            return BadRequest("No se encotro el camion a modificar");
        }
        public CamionServicio ConvertirCamion(Camion camion)
        {
            if (camion != null) return new CamionServicio(camion.Numero,camion.Marca,camion.FechaHoraSalida,camion.FechaHoraLlegada,camion.PesoMaximo);

            return null;
        }
        public Camion ConvertirCamionLogica(CamionServicio camion)
        {
            return new Camion(camion.Numero, camion.Marca, camion.FechaHoraSalida, camion.FechaHoraLlegada, camion.PesoMaximo);
        }
        public List<CamionServicio> ConvertirLista(List<Camion> camiones)
        {
            List<CamionServicio> lista = new List<CamionServicio>();

            foreach (Camion camion in camiones)
            {
                lista.Add(ConvertirCamion(camion));
            }

            return lista;
        }
    }
}
