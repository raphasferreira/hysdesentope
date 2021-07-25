using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GestaoHYS.Core.Models
{
    public class Warehouses
    {
        [Column("id")]
        [JsonProperty("id")]
        public string id { get; set; }

        [Column("warehouseKey")]
        [JsonProperty("warehouseKey")]
        public string warehouseKey { get; set; }

        [Column("description")]
        [JsonProperty("description")]
        public string description { get; set; }
    }
}
