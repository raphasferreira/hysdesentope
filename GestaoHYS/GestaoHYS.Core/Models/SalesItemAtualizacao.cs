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
        public string Brand { get; set; }
      

        [Column("brandModel")]
        public string BrandModel { get; set; }

        [Column("assortment")]
        public string Assortment { get; set; }      

        [Column("baseUnit")]
        public string BaseUnit { get; set; }
        

        [Column("complementaryDescription")]
        public string complementaryDescription { get; set; }

        [Column("description")]
        public string description { get; set; }

        [Column("isActive")]
        public bool IsActive { get; set; }

     

       
        public int itemType { get; set; }
    }

}
