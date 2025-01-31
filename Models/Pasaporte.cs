using Newtonsoft.Json;
using PersonasApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonasApp.Models
{
    public class Pasaporte
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int? Id { get; set; }

        [JsonProperty("numero")]
        public string Numero { get; set; }

        [JsonConverter(typeof(DateConverter))]
        [JsonProperty("fechaEmision")]
        public DateTime? FechaEmision { get; set; } = DateTime.Now;

        [JsonProperty("persona")]
        public Persona Persona { get; set; }

        public Pasaporte()
        {

        }
    }
}
