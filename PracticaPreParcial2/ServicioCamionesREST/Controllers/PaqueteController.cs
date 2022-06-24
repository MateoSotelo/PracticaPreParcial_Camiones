using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LogicaCamionesREST;
using EntidadesServicioREST;
using EntidadesREST;

namespace ServicioCamionesREST.Controllers
{
    [RoutePrefix("api/Paquetes")]
    public class PaqueteController : ApiController
    {
        [Route("{numero}")]
        public IHttpActionResult Get(int numero)
        {
            return Ok(ConvertirPaquete(Logica.Instance.BuscarPaquete(numero)));
        }
        [Route("nuevoPaquete")]
        public IHttpActionResult Post([FromBody] PaqueteServicio nuevoPaquete)
        {
            Logica.Instance.AltaPaquete(ConvertirPaqueteLogica(nuevoPaquete));
            return Ok();
        }
        public PaqueteServicio ConvertirPaquete(Paquete paquete)
        {
            return new PaqueteServicio(paquete.Peso, paquete.Numero, paquete.CiudadOrigen);
        }
        public Paquete ConvertirPaqueteLogica(PaqueteServicio paquete)
        {
            return new Paquete(paquete.Peso, paquete.Numero, paquete.CiudadOrigen);
        }
    }
}