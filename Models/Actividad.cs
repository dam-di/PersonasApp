using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonasApp.Models
{
    public class Actividad
    {
        [JsonProperty("id")]
        public string IdActividad { get; set; }

        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("fecha")]
        public DateTime Fecha { get; set; }

        public Actividad() { }
    }
}
