using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GestaoHYS.Core.Models
{
    public class Unit 
    {
        [Column("id")]
        [JsonProperty("id")]
        public string id { get; set; }

        [Column("unitKey")]
        [JsonProperty("unitKey")]
        public string unitKey { get; set; }

        [Column("description")]
        [JsonProperty("description")]
        public string description { get; set; }
    }
}
