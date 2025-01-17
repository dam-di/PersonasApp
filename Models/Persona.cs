﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonasApp.Models
{
    public class Persona
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("correo")]
        public string Correo { get; set; }

        [JsonProperty("fechaNacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [JsonProperty("pasaporte")]
        public Pasaporte Pasaporte { get; set; }

        [JsonProperty("telefono")]
        public Telefono Telefono { get; set; }

        [JsonProperty("actividades")]
        public ObservableCollection<Actividad> Actividades { get; set; }

        public Persona() { }

    }
}
