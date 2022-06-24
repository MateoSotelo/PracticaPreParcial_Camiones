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
    [RoutePrefix("api/Camion")]
    public class CamionController : ApiController
    { 
        public IHttpActionResult Get(int numero)
        {
            return Ok(ConvertirCamion(Logica.Instance.BuscarCamion(numero)));
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
        public IHttpActionResult Delete(int numero)
        {
            if (Logica.Instance.BajaCamion(numero) == true)
            {
                return Ok("Camion eliminado");
            }

            return BadRequest("No se encontro el numero del camion");
        }
        public CamionServicio ConvertirCamion(Camion camion)
        {
            return new CamionServicio(camion.Numero,camion.Marca,camion.FechaHoraSalida,camion.FechaHoraLlegada,camion.PesoMaximo);
        }
        public Camion ConvertirCamionLogica(CamionServicio camion)
        {
            return new Camion(camion.Numero, camion.Marca, camion.FechaHoraSalida, camion.FechaHoraLlegada, camion.PesoMaximo);
        }

    }
}
