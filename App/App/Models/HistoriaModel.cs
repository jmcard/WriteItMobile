using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Models
{
    public class HistoriaModel
    {
        [JsonProperty("IdHistoria")]
        public String IdHistoria { get; set; }

        [JsonProperty("TituloHistoria")]
        public String TituloHistoria { get; set; }

        [JsonProperty("Sinopse")]
        public String Sinopse { get; set; }

        [JsonProperty("Banner")]
        public String Banner { get; set; }

        public string Categoria { get; set; }

        public string IdPerfil { get; set; }

        public HistoriaModel(string idHistoria, string tituloHistoria, string sinopse, string banner, string categoria, string idPerfil)
        {
            IdHistoria = idHistoria;
            TituloHistoria = tituloHistoria;
            Sinopse = sinopse;
            Banner = banner;
            Categoria = categoria;
            IdPerfil = idPerfil;
        }

        public HistoriaModel()
        {

        }
    }
}
