using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GestaoHYS.Core.Models
{
    public class Countries
    {
        [Column("id")]
        [JsonProperty("id")]
        public string id { get; set; }

        [Column("countryKey")]
        [JsonProperty("countryKey")]
        public string countryKey { get; set; }

        [Column("name")]
        [JsonProperty("name")]
        public string name { get; set; }

        

            
    }
}
