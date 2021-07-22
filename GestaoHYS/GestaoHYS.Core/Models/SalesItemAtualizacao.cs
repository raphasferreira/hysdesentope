using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoHYS.Core.Models
{
    public abstract class SalesItemAtualizacao : SalesItemPropriedadesAtualizacao
    {
        [Column("brand")]
        [JsonProperty("brand")]
        public string Brand { get; set; }
      
        [Column("brandModel")]
        [JsonProperty("brandModel")]
        public string BrandModel { get; set; }

        [Column("assortment")]
        [JsonProperty("assortment")]
        public string Assortment { get; set; }      

        [Column("baseUnit")]
        [JsonProperty("baseUnit")]
        public string BaseUnit { get; set; }
        

        [Column("complementaryDescription")]
        [JsonProperty("complementaryDescription")]
        public string complementaryDescription { get; set; }

        [Column("description")]
        [JsonProperty("description")]
        public string description { get; set; }

        [Column("isActive")]
        [JsonProperty("isActive")]
        public bool IsActive { get; set; }

        [JsonProperty("itemType")]
        public int itemType { get; set; }
    }

}
