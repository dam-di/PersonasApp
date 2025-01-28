using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using PersonasApp.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PersonasApp.Models
{
    public class Persona
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int? Id { get; set; }

        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("correo")]
        public string Correo { get; set; }

        [JsonProperty("avatarurl")]
        public string AvatarUrl { set; get; }

        //public string AvatarUrl
        //{
        //    set => _avatarUrl = value;
        //    get
        //    {
        //        if (_avatarUrl != null && !_avatarUrl.Equals("user.png"))
        //        {
        //            return "http://localhost:8081/dropbox/download/" + Id + _avatarUrl;
        //        }
        //        return _avatarUrl;

        //    }
        //}



        [Newtonsoft.Json.JsonConverter(typeof(DateConverter))]
        [JsonProperty("fechaNacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [JsonProperty("pasaporte")]
        public Pasaporte Pasaporte { get; set; }
        [JsonProperty("telefono")]
        public Telefono Telefono { get; set; }

        [JsonProperty("actividades")]
        public ObservableCollection<Actividad> Actividades { get; set; }

        [JsonProperty("gastos")]
        public ObservableCollection<Gasto> Gastos { get; set; }

        public Persona()
        {


        }

    }
}
