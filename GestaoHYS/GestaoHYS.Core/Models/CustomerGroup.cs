using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GestaoHYS.Core.Models
{
    public class CustomerGroup
    {
        [Column("id")]
        [JsonProperty("id")]
        public string id { get; set; }

        [Column("customerGroupKey")]
        [JsonProperty("customerGroupKey")]
        public string customerGroupKey { get; set; }

        [Column("description")]
        [JsonProperty("description")]
        public string description { get; set; }
    }
}
