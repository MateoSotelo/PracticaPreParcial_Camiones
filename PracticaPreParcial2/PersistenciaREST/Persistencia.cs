using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using EntidadesREST;


namespace PersistenciaREST
{
    public class Persistencia
    {
        const string path = @"C:\Users\msote\OneDrive\Escritorio\ListasJson\";
        
        public void GuardarCamiones(List<Camion> camiones)
        {
            using(StreamWriter writer = new StreamWriter(path + "camiones.txt"))
            {
                string json = JsonConvert.SerializeObject(camiones);
                writer.Write(json);
            }
        }
        public void GuardarPaquetes(List<Paquete> paquetes)
        {
            using (StreamWriter writer = new StreamWriter(path + "paquetes.txt"))
            {
                string json = JsonConvert.SerializeObject(paquetes);
                writer.Write(json);
            }
        }
        public List<Camion> LeerCamiones()
        {
            using (StreamReader reader = new StreamReader(path + "camiones.txt"))
            {
                return JsonConvert.DeserializeObject<List<Camion>>(reader.ReadToEnd());
            }
        }
        public List<Paquete> LeerPaquetes()
        {
            using (StreamReader reader = new StreamReader(path + "paquetes.txt"))
            {
                return JsonConvert.DeserializeObject<List<Paquete>>(reader.ReadToEnd());
            }
        }

    }
}
