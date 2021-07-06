using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GestaoHYS.Core.Models
{
    public class Cultures
    {

        [Column("id")]
        [JsonProperty("id")]
        public string id { get; set; }

        [Column("cultureKey")]
        [JsonProperty("cultureKey")]
        public string cultureKey { get; set; }

        [Column("name")]
        [JsonProperty("name")]
        public string name { get; set; }
    }
}
