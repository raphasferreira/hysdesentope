using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoHYS.Core.Models
{
    [Table("DocumentLine")]
    public class DocumentLineInvoice
    {

        [Column("versionByte")]
        [JsonProperty("versionByte")]
        public string VersionByte { get; set; }


        [Column("description")]
        [JsonProperty("description")]
        public string Description { get; set; }

        [Column("quantity")]
        [JsonProperty("quantity")]
        public double? Quantity { get; set; }

        [Column("quantityDecimalPlaces")]
        [JsonProperty("quantityDecimalPlaces")]
        public int? QuantityDecimalPlaces { get; set; }

        [Column("unitPriceId")]
        [JsonProperty("unitPriceId")]
        public long? UnitPriceId { get; set; }

        [Column("unitPrice")]
        [JsonProperty("unitPrice")]
        public UnitPrice UnitPrice { get; set; }

        [Column("unitPriceAmount")]
        [JsonProperty("unitPriceAmount")]
        public double? UnitPriceAmount { get; set; }

        [Column("deliveryDate")]
        [JsonProperty("deliveryDate")]
        public DateTime? DeliveryDate { get; set; }

        [Column("discount1")]
        [JsonProperty("discount1")]
        public double? Discount1 { get; set; }

        [Column("discount2")]
        [JsonProperty("discount2")]
        public double? Discount2 { get; set; }

        [Column("discount3")]
        [JsonProperty("discount3")]
        public double? Discount3 { get; set; }

        [Column("taxTotalAmount")]
        [JsonProperty("taxTotalAmount")]
        public double? TaxTotalAmount { get; set; }

        //[Column("allowanceChargeAmount")]
        //public AllowanceChargeAmount AllowanceChargeAmount { get; set; }

        [Column("allowanceChargeAmountAmount")]
        [JsonProperty("allowanceChargeAmountAmount")]
        public double? AllowanceChargeAmountAmount { get; set; }

        //[Column("taxExclusiveAmount")]
        //public TaxExclusiveAmount TaxExclusiveAmount { get; set; }

        [Column("taxExclusiveAmountAmount")]
        [JsonProperty("taxExclusiveAmountAmount")]
        public double? TaxExclusiveAmountAmount { get; set; }

        //[Column("grossValue")]
        //public GrossValue GrossValue { get; set; }

        [Column("grossValueAmount")]
        [JsonProperty("grossValueAmount")]
        public double? GrossValueAmount { get; set; }

        [Column("lineExtensionAmountAmount")]
        [JsonProperty("lineExtensionAmountAmount")]
        public double? LineExtensionAmountAmount { get; set; }

        [Column("complementaryDescription")]
        [JsonProperty("complementaryDescription")]
        public string ComplementaryDescription { get; set; }


        [Column("salesItem")]
        [JsonProperty("salesItem")]
        public string SalesItem { get; set; }

        [Column("salesItemId")]
        [JsonProperty("salesItemId")]
        public string SalesItemId { get; set; }

        [Column("salesItemBaseEntityId")]
        [JsonProperty("salesItemBaseEntityId")]
        public string SalesItemBaseEntityId { get; set; }

        [Column("salesItemDescription")]
        [JsonProperty("salesItemDescription")]
        public string SalesItemDescription { get; set; }

        [Column("unit")]
        [JsonProperty("unit")]
        public string Unit { get; set; }

        [Column("unitId")]
        [JsonProperty("unitId")]
        public string UnitId { get; set; }

        [Column("unitDescription")]
        [JsonProperty("unitDescription")]
        public string UnitDescription { get; set; }

        [Column("warehouse")]
        [JsonProperty("warehouse")]
        public string Warehouse { get; set; }

        [Column("warehouseId")]
        [JsonProperty("warehouseId")]
        public string WarehouseId { get; set; }

        [Column("warehouseDescription")]
        [JsonProperty("warehouseDescription")]
        public string WarehouseDescription { get; set; }

        [Column("itemWithholdingTaxSchema")]
        [JsonProperty("itemWithholdingTaxSchema")]
        public string ItemWithholdingTaxSchema { get; set; }

        [Column("itemWithholdingTaxSchemaId")]
        [JsonProperty("itemWithholdingTaxSchemaId")]
        public string ItemWithholdingTaxSchemaId { get; set; }

        [Column("itemWithholdingTaxSchemaDescription")]
        [JsonProperty("itemWithholdingTaxSchemaDescription")]
        public string ItemWithholdingTaxSchemaDescription { get; set; }

        [Column("itemTaxSchema")]
        [JsonProperty("itemTaxSchema")]
        public string ItemTaxSchema { get; set; }

        [Column("itemTaxSchemaId")]
        [JsonProperty("itemTaxSchemaId")]
        public string ItemTaxSchemaId { get; set; }

        [Column("itemTaxSchemaDescription")]
        [JsonProperty("itemTaxSchemaDescription")]
        public string ItemTaxSchemaDescription { get; set; }

        [Column("partyTaxSchema")]
        [JsonProperty("partyTaxSchema")]
        public string PartyTaxSchema { get; set; }

        [Column("partyTaxSchemaId")]
        [JsonProperty("partyTaxSchemaId")]
        public string PartyTaxSchemaId { get; set; }

        [Column("partyTaxSchemaDescription")]
        [JsonProperty("partyTaxSchemaDescription")]
        public string PartyTaxSchemaDescription { get; set; }

        [Column("currency")]
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [Column("currencyId")]
        [JsonProperty("currencyId")]
        public string CurrencyId { get; set; }

        [Column("currencyDescription")]
        [JsonProperty("currencyDescription")]
        public string CurrencyDescription { get; set; }

        [Column("documentLineStatus")]
        [JsonProperty("documentLineStatus")]
        public int? DocumentLineStatus { get; set; }

        [Column("documentLineStatusDescription")]
        [JsonProperty("documentLineStatusDescription")]
        public string DocumentLineStatusDescription { get; set; }


        [Column("itemType")]
        [JsonProperty("itemType")]
        public int? ItemType { get; set; }

        [Column("itemTypeDescription")]
        [JsonProperty("itemTypeDescription")]
        public string ItemTypeDescription { get; set; }

        

        [Column("baseCurrencyId")]
        [JsonProperty("baseCurrencyId")]
        public string BaseCurrencyId { get; set; }

        [Column("Id")]
        [Key]
        [DatabaseGenerated
        (DatabaseGeneratedOption.Identity)]
        [JsonProperty("idBaseLocal")]

        public long? Id { get; set; }


        [Column("IdReferencia")]
        [JsonProperty("id")]
        public string IdReferencia { get; set; }

        [Column("isActive")]
        [JsonProperty("isActive")]
        public bool? IsActive { get; set; }

        [Column("isDeleted")]
        [JsonProperty("isDeleted")]
        public bool? IsDeleted { get; set; }

        [Column("isSystem")]
        [JsonProperty("isSystem")]
        public bool? IsSystem { get; set; }

        [Column("createdBy")]
        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }

        [Column("createdOn")]
        [JsonProperty("createdOn")]
        public DateTime? CreatedOn { get; set; }

        [Column("modifiedBy")]
        [JsonProperty("modifiedBy")]
        public string ModifiedBy { get; set; }

        [Column("modifiedOn")]
        [JsonProperty("modifiedOn")]
        public DateTime? ModifiedOn { get; set; }

        [Column("draftId")]
        [JsonProperty("draftId")]
        public string DraftId { get; set; }

        //[Column("subscriptionId")]
        //public object SubscriptionId { get; set; }

        [Column("_state")]
        [JsonProperty("_state")]
        public int? State { get; set; }
    }
}
