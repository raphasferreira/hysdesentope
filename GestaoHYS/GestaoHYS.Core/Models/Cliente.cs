using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoHYS.Core.Models
{
    [Table("customer")]
    public class Cliente : ClientePropriedadesAtualizacao
    {
        [Column("Id")]
        [Key]
        [DatabaseGenerated
        (DatabaseGeneratedOption.Identity)]
        [Required]
        [JsonProperty("idBaseLocal")]

        public long Id { get; set; }

        [NotMapped]
        [JsonProperty("version")]
        public List<int> Version { get; set; }

        [Column("IdReferencia")]
        [JsonProperty("id")]
        public string IdReferencia { get; set; }

        [Column("versionByte")]
        [JsonProperty("versionByte")]
        public string VersionByte { get; set; }

        [Column("partyKey")]
        [JsonProperty("partyKey")]
        public string PartyKey { get; set; }

        [Column("partyKeySegments")]
        [JsonProperty("partyKeySegments")]
        public string PartyKeySegments { get; set; }

        [Column("partyKeySequenceId")]
        [JsonProperty("partyKeySequenceId")]
        public string PartyKeySequenceId { get; set; }

        [Column("notes")]
        [JsonProperty("notes")]
        public string Notes { get; set; }

        [Column("picture")]
        [JsonProperty("picture")]
        public string Picture { get; set; }

        [Column("pictureThumbnail")]
        [JsonProperty("pictureThumbnail")]
        public string PictureThumbnail { get; set; }

        [Column("username")]
        [JsonProperty("username")]
        public string Username { get; set; }

        [Column("externalId")]
        [JsonProperty("externalId")]
        public string ExternalId { get; set; }

        [Column("externalVersion")]
        [JsonProperty("externalVersion")]
        public string ExternalVersion { get; set; }

        [Column("isExternallyManaged")]
        [JsonProperty("isExternallyManaged")]
        public Boolean IsExternallyManaged { get; set; }

        [Column("customerGroupId")]
        [JsonProperty("customerGroupId")]
        public string CustomerGroupId { get; set; }

        [Column("customerGroupDescription")]
        [JsonProperty("customerGroupDescription")]
        public string CustomerGroupDescription { get; set; }

        [Column("priceList")]
        [JsonProperty("priceList")]
        public string PriceList { get; set; }

        [Column("priceListId")]
        [JsonProperty("priceListId")]
        public string PriceListId { get; set; }

        [Column("priceListDescription")]
        [JsonProperty("priceListDescription")]
        public string PriceListDescription { get; set; }

        [Column("paymentMethodId")]
        [JsonProperty("paymentMethodId")]
        public string PaymentMethodId { get; set; }

        [Column("paymentMethodDescription")]
        [JsonProperty("paymentMethodDescription")]
        public string PaymentMethodDescription { get; set; }

        [Column("paymentTermId")]
        [JsonProperty("paymentTermId")]
        public string PaymentTermId { get; set; }

        [Column("paymentTermDescription")]
        [JsonProperty("paymentTermDescription")]
        public string PaymentTermDescription { get; set; }

        [Column("salesperson")]
        [JsonProperty("salesperson")]
        public string Salesperson { get; set; }

        [Column("salespersonId")]
        [JsonProperty("salespersonId")]
        public string SalespersonId { get; set; }

        [Column("salespersonBaseEntityId")]
        [JsonProperty("salespersonBaseEntityId")]
        public string SalespersonBaseEntityId { get; set; }

        [Column("salespersonDescription")]
        [JsonProperty("salespersonDescription")]
        public string SalespersonDescription { get; set; }

        [Column("partyTaxSchemaId")]
        [JsonProperty("partyTaxSchemaId")]
        public string PartyTaxSchemaId { get; set; }

        [Column("partyTaxSchemaDescription")]
        [JsonProperty("partyTaxSchemaDescription")]
        public string PartyTaxSchemaDescription { get; set; }

        [Column("partyWithholdingTaxSchemaId")]
        [JsonProperty("partyWithholdingTaxSchemaId")]
        public string PartyWithholdingTaxSchemaId { get; set; }

        [Column("partyWithholdingTaxSchemaDescription")]
        [JsonProperty("partyWithholdingTaxSchemaDescription")]
        public string PartyWithholdingTaxSchemaDescription { get; set; }

        [Column("deliveryTermId")]
        [JsonProperty("deliveryTermId")]
        public string DeliveryTermId { get; set; }

        [Column("deliveryTermDescription")]
        [JsonProperty("deliveryTermDescription")]
        public string DeliveryTermDescription { get; set; }

        [Column("accountingSchema")]
        [JsonProperty("accountingSchema")]
        public int AccountingSchema { get; set; }

        [Column("accountingSchemaDescription")]
        [JsonProperty("accountingSchemaDescription")]
        public string AccountingSchemaDescription { get; set; }

        [Column("accountingParty")]
        [JsonProperty("accountingParty")]
        public string AccountingParty { get; set; }

        [Column("accountingPartyId")]
        [JsonProperty("accountingPartyId")]
        public string AccountingPartyId { get; set; }

        [Column("accountingPartyDescription")]
        [JsonProperty("accountingPartyDescription")]
        public string AccountingPartyDescription { get; set; }

        [Column("currencyId")]
        [JsonProperty("currencyId")]
        public string CurrencyId { get; set; }

        [Column("currencyDescription")]
        [JsonProperty("currencyDescription")]
        public string CurrencyDescription { get; set; }

        [Column("countryId")]
        [JsonProperty("countryId")]
        public string CountryId { get; set; }

        [Column("countryDescription")]
        [JsonProperty("countryDescription")]
        public string CountryDescription { get; set; }

        [Column("address")]
        [JsonProperty("address")]
        public string Address { get; set; }

        [Column("addressId")]
        [JsonProperty("addressId")]
        public string AddressId { get; set; }

        [Column("contact")]
        [JsonProperty("contact")]
        public string Contact { get; set; }

        [Column("contactId")]
        [JsonProperty("contactId")]
        public string ContactId { get; set; }

        [Column("cultureId")]
        [JsonProperty("cultureId")]
        public string CultureId { get; set; }

        [Column("cultureDescription")]
        [JsonProperty("cultureDescription")]
        public string CultureDescription { get; set; }

        [Column("baseEntityId")]
        [JsonProperty("baseEntityId")]
        public string BaseEntityId { get; set; }

        [Column("isDraft")]
        [JsonProperty("isDraft")]
        public Boolean IsDraft { get; set; }

        [Column("isActive")]
        [JsonProperty("isActive")]
        public Boolean IsActive { get; set; }

        [Column("isDeleted")]
        [JsonProperty("isDeleted")]
        public Boolean IsDeleted { get; set; }

        [Column("isSystem")]
        [JsonProperty("isSystem")]
        public Boolean IsSystem { get; set; }

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

        [Column("subscriptionId")]
        [JsonProperty("subscriptionId")]
        public string SubscriptionId { get; set; }

        [Column("state")]
        [JsonProperty("state")]
        public Boolean State { get; set; }

        [Column("isIntegration")]
        [JsonProperty("isIntegration")]
        public Boolean isIntegration { get; set; }

        [Column("isIntegrated")]
        [JsonProperty("isIntegrated")]
        public Boolean isIntegrated { get; set; }

        [Column("ErrosIntegracao")]
        [JsonProperty("ErrosIntegracao")]
        public string ErrosIntegracao { get; set; }

    }
}
