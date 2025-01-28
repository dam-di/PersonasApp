using Newtonsoft.Json;
using PersonasApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonasApp.Models
{
    public class Gasto
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int? Id { get; set; }

        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }

        [JsonConverter(typeof(DateConverter))]
        [JsonProperty("fecha")]
        public DateTime Fecha { get; set; }

        [JsonProperty("total")]
        public decimal Total { get; set; }

        [JsonProperty("persona")]
        public Persona Persona { get; set; }
        public Gasto() { }
    }
}
