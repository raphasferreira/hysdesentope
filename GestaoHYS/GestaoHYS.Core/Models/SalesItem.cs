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


        [Column("versionByte")]
        [JsonProperty("versionByte")]
        public string VersionByte { get; set; }

        [Column("locked")]
        [JsonProperty("locked")]
        public bool Locked { get; set; }

        [Column("itemKey")]
        [JsonProperty("ItemKey")]
        public string ItemKey { get; set; }

        [Column("ErrosIntegracao")]
        public string ErrosIntegracao { get; set; }


        [Column("unit")]
        [JsonProperty("unit")]
        public string Unit { get; set; }

        [Column("brandId")]
        [JsonProperty("brandId")]
        public string BrandId { get; set; }

        [Column("brandDescription")]
        [JsonProperty("brandDescription")]
        public string BrandDescription { get; set; }


        [Column("brandModelId")]
        [JsonProperty("brandModelId")]
        public string BrandModelId { get; set; }

        [Column("brandModelDescription")]
        [JsonProperty("brandModelDescription")]
        public string BrandModelDescription { get; set; }




        [Column("assortmentId")]
        [JsonProperty("assortmentId")]
        public string AssortmentId { get; set; }

        [Column("assortmentDescription")]
        [JsonProperty("assortmentDescription")]
        public string AssortmentDescription { get; set; }

   

        [Column("baseUnitId")]
        [JsonProperty("baseUnitId")]
        public string BaseUnitId { get; set; }

        [Column("baseUnitDescription")]
        [JsonProperty("baseUnitDescription")]
        public string BaseUnitDescription { get; set; }



        [Column("unitId")]
        [JsonProperty("unitId")]
        public string UnitId { get; set; }

        [Column("unitDescription")]
        [JsonProperty("unitDescription")]
        public string UnitDescription { get; set; }

        [Column("itemTaxSchema")]
        [JsonProperty("itemTaxSchema")]
        public string ItemTaxSchema { get; set; }

        [Column("itemTaxSchemaId")]
        [JsonProperty("itemTaxSchemaId")]
        public string ItemTaxSchemaId { get; set; }

        [Column("itemTaxSchemaDescription")]
        [JsonProperty("itemTaxSchemaDescription")]
        public string ItemTaxSchemaDescription { get; set; }

        [Column("priceListLines")]
        [JsonProperty("priceListLines")]
        public List<PriceListLine> PriceListLines { get; set; }

        [Column("incomeAccount")]
        [JsonProperty("incomeAccount")]
        public string IncomeAccount { get; set; }

        [Column("incomeAccountId")]
        [JsonProperty("incomeAccountId")]
        public string IncomeAccountId { get; set; }

        [Column("incomeAccountDescription")]
        [JsonProperty("incomeAccountDescription")]
        public string IncomeAccountDescription { get; set; }

        [Column("salesChannelLines")]
        [JsonProperty("salesChannelLines")]
        public List<SalesChannelLine> SalesChannelLines { get; set; }

        [Column("baseEntityId")]
        [JsonProperty("baseEntityId")]
        public string BaseEntityId { get; set; }

        [Column("isDraft")]
        [JsonProperty("isDraft")]
        public bool IsDraft { get; set; }


        [Column("isSystem")]
        [JsonProperty("isSystem")]
        public bool IsSystem { get; set; }

        [Column("createdBy")]
        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }

        [Column("createdOn")]
        [JsonProperty("createdOn")]
        public DateTime CreatedOn { get; set; }

        [Column("modifiedBy")]
        [JsonProperty("modifiedBy")]
        public string ModifiedBy { get; set; }

        [Column("modifiedOn")]
        [JsonProperty("modifiedOn")]
        public DateTime ModifiedOn { get; set; }

        [Column("draftId")]
        [JsonProperty("draftId")]
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
        [JsonProperty("isDeleted")]
        public bool IsDeleted { get; set; }

    }

}
