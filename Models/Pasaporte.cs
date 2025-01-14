using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonasApp.Models
{
    class Pasaporte
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("numero")]
        public string Numero { get; set; }

        [JsonProperty("fechaEmision")]
        public DateTime FechaEmision { get; set; }
        public Pasaporte()
        {

        }
    }
}
