using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoHYS.Core.Models
{
    [Table("SalesItem")]
    public class SalesItem : SalesItemAtualizacao
    {
        [Column("Id")]
        [Key]
        [DatabaseGenerated
        (DatabaseGeneratedOption.Identity)]
        [Required]
        [JsonProperty("idBaseLocal")]

        public long Id { get; set; }


        [Column("IdReferencia")]
        [JsonProperty("id")]
        public string IdReferencia { get; set; }



        //[Column("version")]
        //public List<int> Version { get; set; }

        [Column("versionByte")]
        public string VersionByte { get; set; }

        [Column("locked")]
        public bool Locked { get; set; }

        [Column("itemKey")]
        [JsonProperty("ItemKey")]
        public string ItemKey { get; set; }

        [Column("ErrosIntegracao")]
        public string ErrosIntegracao { get; set; }


    

        [Column("brandId")]
        public string BrandId { get; set; }

        [Column("brandDescription")]
        public string BrandDescription { get; set; }


        [Column("brandModelId")]
        public string BrandModelId { get; set; }

        [Column("brandModelDescription")]
        public string BrandModelDescription { get; set; }




        [Column("assortmentId")]
        public string AssortmentId { get; set; }

        [Column("assortmentDescription")]
        public string AssortmentDescription { get; set; }

   

        [Column("baseUnitId")]
        public string BaseUnitId { get; set; }

        [Column("baseUnitDescription")]
        public string BaseUnitDescription { get; set; }



        [Column("unitId")]
        public string UnitId { get; set; }

        [Column("unitDescription")]
        public string UnitDescription { get; set; }

        [Column("itemTaxSchema")]
        public string ItemTaxSchema { get; set; }

        [Column("itemTaxSchemaId")]
        public string ItemTaxSchemaId { get; set; }

        [Column("itemTaxSchemaDescription")]
        public string ItemTaxSchemaDescription { get; set; }

        [Column("priceListLines")]
        public List<PriceListLine> PriceListLines { get; set; }

        [Column("incomeAccount")]
        public string IncomeAccount { get; set; }

        [Column("incomeAccountId")]
        public string IncomeAccountId { get; set; }

        [Column("incomeAccountDescription")]
        public string IncomeAccountDescription { get; set; }

        [Column("salesChannelLines")]
        public List<SalesChannelLine> SalesChannelLines { get; set; }

        [Column("baseEntityId")]
        public string BaseEntityId { get; set; }

        [Column("isDraft")]
        public bool IsDraft { get; set; }


        [Column("isSystem")]
        public bool IsSystem { get; set; }

        [Column("createdBy")]
        public string CreatedBy { get; set; }

        [Column("createdOn")]
        public DateTime CreatedOn { get; set; }

        [Column("modifiedBy")]
        public string ModifiedBy { get; set; }

        [Column("modifiedOn")]
        public DateTime ModifiedOn { get; set; }

        [Column("draftId")]
        public string DraftId { get; set; }

        //[Column("subscriptionId")]
        //public object SubscriptionId { get; set; }

        [Column("state")]
        [JsonProperty("_state")]
        public int State { get; set; }

        [Column("isIntegration")]
        [JsonProperty("isIntegration")]
        public Boolean isIntegration { get; set; }

        [Column("isIntegrated")]
        [JsonProperty("isIntegrated")]
        public Boolean isIntegrated { get; set; }

        [Column("isDeleted")]
        public bool IsDeleted { get; set; }

    }

}
