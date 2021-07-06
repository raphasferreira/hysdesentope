using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GestaoHYS.Core.Models
{
    public class Currencies
    {

        [Column("id")]
        [JsonProperty("id")]
        public string id { get; set; }

        [Column("currencyKey")]
        [JsonProperty("currencyKey")]
        public string currencyKey { get; set; }

        [Column("description")]
        [JsonProperty("description")]
        public string description { get; set; }
    }
}
