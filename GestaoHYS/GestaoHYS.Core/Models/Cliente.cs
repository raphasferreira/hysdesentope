using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoHYS.Core.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        [Column("Id")]
        [Key]
        [DatabaseGenerated
        (DatabaseGeneratedOption.Identity)]
        [Required]
        [JsonIgnore]
      
        public long Id { get; set; }

        [NotMapped]
        [JsonProperty("version")]
        public List<int> Version { get; set; }

        [Column("IdReferencia")]
        [JsonProperty("id")]
        public Guid IdReferencia { get; set; }

        [Column("versionByte")]
        [JsonProperty("versionByte")]
        public string VersionByte { get; set; }

        [Column("settlementDiscountPercent")]
        [JsonProperty("settlementDiscountPercent")]
        public double SettlementDiscountPercent { get; set; }

        [Column("locked")]
        [JsonProperty("locked")]
        public bool Locked { get; set; }

        [Column("oneTimeCustomer")]
        [JsonProperty("oneTimeCustomer")]
        public bool OneTimeCustomer { get; set; }

        [Column("endCustomer")]
        [JsonProperty("endCustomer")]
        public bool EndCustomer { get; set; }

        [Column("partyKey")]
        [JsonProperty("partyKey")]
        public string PartyKey { get; set; }

        [Column("partyKeySegments")]
        [JsonProperty("partyKeySegments")]
        public string PartyKeySegments { get; set; }

        [Column("partyKeySequenceId")]
        [JsonProperty("partyKeySequenceId")]
        public string PartyKeySequenceId { get; set; }

        [Column("searchTerm")]
        [JsonProperty("searchTerm")]
        public string SearchTerm { get; set; }

        [Column("name")]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Column("companyTaxID")]
        [JsonProperty("companyTaxID")]
        public string CompanyTaxID { get; set; }

        [Column("electronicMail")]
        [JsonProperty("electronicMail")]
        public string ElectronicMail { get; set; }

        [Column("telephone")]
        [JsonProperty("telephone")]
        public string Telephone { get; set; }

        [Column("mobile")]
        [JsonProperty("mobile")]
        public string Mobile { get; set; }

        [Column("websiteUrl")]
        [JsonProperty("websiteUrl")]
        public string WebsiteUrl { get; set; }

        [Column("notes")]
        [JsonProperty("notes")]
        public string Notes { get; set; }

        [Column("picture")]
        [JsonProperty("picture")]
        public string Picture { get; set; }


        [Column("pictureThumbnail")]
        [JsonProperty("pictureThumbnail")]
        public string PictureThumbnail { get; set; }

        [Column("streetName")]
        [JsonProperty("streetName")]
        public string StreetName { get; set; }

        [Column("buildingNumber")]
        [JsonProperty("buildingNumber")]
        public string BuildingNumber { get; set; }

        [Column("postalZone")]
        [JsonProperty("postalZone")]
        public string PostalZone { get; set; }

        [Column("cityName")]
        [JsonProperty("cityName")]
        public string CityName { get; set; }

        [Column("contactName")]
        [JsonProperty("contactName")]
        public string ContactName { get; set; }

        [Column("contactTitle")]
        [JsonProperty("contactTitle")]
        public string ContactTitle { get; set; }

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
        public string IsExternallyManaged { get; set; }

        [Column("isPerson")]
        [JsonProperty("isPerson")]
        public string IsPerson { get; set; }

        [Column("customerGroup")]
        [JsonProperty("customerGroup")]
        public string CustomerGroup { get; set; }

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

        [Column("paymentMethod")]
        [JsonProperty("paymentMethod")]
        public string PaymentMethod { get; set; }

        [Column("paymentMethodId")]
        [JsonProperty("paymentMethodId")]
        public string PaymentMethodId { get; set; }

        [Column("paymentMethodDescription")]
        [JsonProperty("paymentMethodDescription")]
        public string PaymentMethodDescription { get; set; }

        [Column("paymentTerm")]
        [JsonProperty("paymentTerm")]
        public string PaymentTerm { get; set; }

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

        [Column("partyTaxSchema")]
        [JsonProperty("partyTaxSchema")]
        public string PartyTaxSchema { get; set; }

        [Column("partyTaxSchemaId")]
        [JsonProperty("partyTaxSchemaId")]
        public string PartyTaxSchemaId { get; set; }

        [Column("partyTaxSchemaDescription")]
        [JsonProperty("partyTaxSchemaDescription")]
        public string PartyTaxSchemaDescription { get; set; }

        [Column("partyWithholdingTaxSchema")]
        [JsonProperty("partyWithholdingTaxSchema")]
        public string PartyWithholdingTaxSchema { get; set; }

        [Column("partyWithholdingTaxSchemaId")]
        [JsonProperty("partyWithholdingTaxSchemaId")]
        public string PartyWithholdingTaxSchemaId { get; set; }

        [Column("partyWithholdingTaxSchemaDescription")]
        [JsonProperty("partyWithholdingTaxSchemaDescription")]
        public string PartyWithholdingTaxSchemaDescription { get; set; }

        [Column("deliveryTerm")]
        [JsonProperty("deliveryTerm")]
        public string DeliveryTerm { get; set; }

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

        [Column("currency")]
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [Column("currencyId")]
        [JsonProperty("currencyId")]
        public string CurrencyId { get; set; }

        [Column("currencyDescription")]
        [JsonProperty("currencyDescription")]
        public string CurrencyDescription { get; set; }

        [Column("country")]
        [JsonProperty("country")]
        public string Country { get; set; }

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

        [Column("culture")]
        [JsonProperty("culture")]
        public string Culture { get; set; }

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
        public string IsDraft { get; set; }

        [Column("isActive")]
        [JsonProperty("isActive")]
        public string IsActive { get; set; }

        [Column("isDeleted")]
        [JsonProperty("isDeleted")]
        public string IsDeleted { get; set; }

        [Column("isSystem")]
        [JsonProperty("isSystem")]
        public string IsSystem { get; set; }

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
        public bool State { get; set; }

    }
}
