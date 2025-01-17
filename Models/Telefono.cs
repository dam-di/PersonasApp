using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonasApp.Models
{
    public class Telefono
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("numero")]
        public string Numero { get; set; }

        [JsonProperty("tipo")]
        public string Tipo { get; set; }

        public Telefono() { }
    }
}
