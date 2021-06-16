using System;
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
        public long Id { get; set; }

        //[Column("version")]
        //public List<int> Version { get; set; }

        [Column("IdReferencia")]
        public string IdReferencia { get; set; }

        [Column("versionByte")]
        public string VersionByte { get; set; }

        [Column("settlementDiscountPercent")]
        public double SettlementDiscountPercent { get; set; }

        [Column("locked")]
        public bool Locked { get; set; }

        [Column("oneTimeCustomer")]
        public bool OneTimeCustomer { get; set; }

        [Column("endCustomer")]
        public bool EndCustomer { get; set; }

        [Column("partyKey")]
        public string PartyKey { get; set; }

        [Column("partyKeySegments")]
        public string PartyKeySegments { get; set; }

        [Column("partyKeySequenceId")]
        public string PartyKeySequenceId { get; set; }

        [Column("searchTerm")]
        public string SearchTerm { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("companyTaxID")]
        public string CompanyTaxID { get; set; }

        [Column("electronicMail")]
        public string ElectronicMail { get; set; }

        [Column("telephone")]
        public string Telephone { get; set; }

        [Column("mobile")]
        public string Mobile { get; set; }

        [Column("websiteUrl")]
        public string WebsiteUrl { get; set; }

        [Column("notes")]
        public string Notes { get; set; }

        [Column("picture")]
        public string Picture { get; set; }

        [Column("pictureThumbnail")]
        public string PictureThumbnail { get; set; }

        [Column("streetName")]
        public string StreetName { get; set; }

        [Column("buildingNumber")]
        public string BuildingNumber { get; set; }

        [Column("postalZone")]
        public string PostalZone { get; set; }

        [Column("cityName")]
        public string CityName { get; set; }

        [Column("contactName")]
        public string ContactName { get; set; }

        [Column("contactTitle")]
        public string ContactTitle { get; set; }

        [Column("username")]
        public string Username { get; set; }

        [Column("externalId")]
        public string ExternalId { get; set; }

        [Column("externalVersion")]
        public string ExternalVersion { get; set; }

        [Column("isExternallyManaged")]
        public bool IsExternallyManaged { get; set; }

        [Column("isPerson")]
        public bool IsPerson { get; set; }

        [Column("customerGroup")]
        public string CustomerGroup { get; set; }

        [Column("customerGroupId")]
        public string CustomerGroupId { get; set; }

        [Column("customerGroupDescription")]
        public string CustomerGroupDescription { get; set; }

        [Column("priceList")]
        public string PriceList { get; set; }

        [Column("priceListId")]
        public string PriceListId { get; set; }

        [Column("priceListDescription")]
        public string PriceListDescription { get; set; }

        [Column("paymentMethod")]
        public string PaymentMethod { get; set; }

        [Column("paymentMethodId")]
        public string PaymentMethodId { get; set; }

        [Column("paymentMethodDescription")]
        public string PaymentMethodDescription { get; set; }

        [Column("paymentTerm")]
        public string PaymentTerm { get; set; }

        [Column("paymentTermId")]
        public string PaymentTermId { get; set; }

        [Column("paymentTermDescription")]
        public string PaymentTermDescription { get; set; }

        [Column("salesperson")]
        public string Salesperson { get; set; }

        [Column("salespersonId")]
        public string SalespersonId { get; set; }

        [Column("salespersonBaseEntityId")]
        public string SalespersonBaseEntityId { get; set; }

        [Column("salespersonDescription")]
        public string SalespersonDescription { get; set; }

        [Column("partyTaxSchema")]
        public string PartyTaxSchema { get; set; }

        [Column("partyTaxSchemaId")]
        public string PartyTaxSchemaId { get; set; }

        [Column("partyTaxSchemaDescription")]
        public string PartyTaxSchemaDescription { get; set; }

        [Column("partyWithholdingTaxSchema")]
        public string PartyWithholdingTaxSchema { get; set; }

        [Column("partyWithholdingTaxSchemaId")]
        public string PartyWithholdingTaxSchemaId { get; set; }

        [Column("partyWithholdingTaxSchemaDescription")]
        public string PartyWithholdingTaxSchemaDescription { get; set; }

        [Column("deliveryTerm")]
        public string DeliveryTerm { get; set; }

        [Column("deliveryTermId")]
        public string DeliveryTermId { get; set; }

        [Column("deliveryTermDescription")]
        public string DeliveryTermDescription { get; set; }

        [Column("accountingSchema")]
        public int AccountingSchema { get; set; }

        [Column("accountingSchemaDescription")]
        public string AccountingSchemaDescription { get; set; }

        [Column("accountingParty")]
        public string AccountingParty { get; set; }

        [Column("accountingPartyId")]
        public string AccountingPartyId { get; set; }

        [Column("accountingPartyDescription")]
        public string AccountingPartyDescription { get; set; }

        [Column("currency")]
        public string Currency { get; set; }

        [Column("currencyId")]
        public string CurrencyId { get; set; }

        [Column("currencyDescription")]
        public string CurrencyDescription { get; set; }

        [Column("country")]
        public string Country { get; set; }

        [Column("countryId")]
        public string CountryId { get; set; }

        [Column("countryDescription")]
        public string CountryDescription { get; set; }

        [Column("address")]
        public string Address { get; set; }

        [Column("addressId")]
        public string AddressId { get; set; }

        [Column("contact")]
        public string Contact { get; set; }

        [Column("contactId")]
        public string ContactId { get; set; }

        [Column("culture")]
        public string Culture { get; set; }

        [Column("cultureId")]
        public string CultureId { get; set; }

        [Column("cultureDescription")]
        public string CultureDescription { get; set; }

        [Column("baseEntityId")]
        public string BaseEntityId { get; set; }

        [Column("isDraft")]
        public bool IsDraft { get; set; }

        [Column("isActive")]
        public bool IsActive { get; set; }

        [Column("isDeleted")]
        public bool IsDeleted { get; set; }

        [Column("isSystem")]
        public bool IsSystem { get; set; }

        [Column("createdBy")]
        public string CreatedBy { get; set; }

        //[Column("createdOn")]
        //public DateTime CreatedOn { get; set; }

        [Column("modifiedBy")]
        public string ModifiedBy { get; set; }

        //[Column("modifiedOn")]
        //public DateTime ModifiedOn { get; set; }

        [Column("draftId")]
        public string DraftId { get; set; }

        [Column("subscriptionId")]
        public string SubscriptionId { get; set; }

        [Column("state")]
        public bool State { get; set; }

    }
}
