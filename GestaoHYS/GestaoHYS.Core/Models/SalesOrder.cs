using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoHYS.Core.Models
{
    [Table("SalesOrder")]
    public class SalesOrder
    {

        [Column("Id")]
        [Key]
        [DatabaseGenerated
        (DatabaseGeneratedOption.Identity)]
        [Required]
        public string Id { get; set; }

        [Column("versionByte")]
        public string VersionByte { get; set; }

        [Column("seriesNumber")]
        public int SeriesNumber { get; set; }

        [Column("documentDate")]
        public DateTime DocumentDate { get; set; }

        [Column("postingDate")]
        public DateTime PostingDate { get; set; }

        [Column("taxIncluded")]
        public bool TaxIncluded { get; set; }

        [Column("note")]
        public string Note { get; set; }

        [Column("buyerCustomerPartyName")]
        public string BuyerCustomerPartyName { get; set; }

        [Column("buyerCustomerPartyAddress")]
        public string BuyerCustomerPartyAddress { get; set; }

        [Column("buyerCustomerPartyTaxId")]
        public string BuyerCustomerPartyTaxId { get; set; }

        [Column("accountingPartyName")]
        public string AccountingPartyName { get; set; }

        [Column("accountingPartyTaxId")]
        public string AccountingPartyTaxId { get; set; }

        [Column("accountingPartyAddress")]
        public string AccountingPartyAddress { get; set; }

        [Column("exchangeRate")]
        public double ExchangeRate { get; set; }

        [Column("exchangeRateDecimalPlaces")]
        public int ExchangeRateDecimalPlaces { get; set; }

        [Column("exchangeRateDate")]
        public DateTime ExchangeRateDate { get; set; }

        [Column("discount")]
        public double Discount { get; set; }

        //[Column("grossValue")]
        //public GrossValue GrossValue { get; set; }

        [Column("grossValueAmount")]
        public double GrossValueAmount { get; set; }

        //[Column("allowanceChargeAmount")]
        //public AllowanceChargeAmount AllowanceChargeAmount { get; set; }

        [Column("allowanceChargeAmountAmount")]
        public double AllowanceChargeAmountAmount { get; set; }

        //[Column("taxExclusiveAmount")]
        //public TaxExclusiveAmount TaxExclusiveAmount { get; set; }

        [Column("taxExclusiveAmountAmount")]
        public double TaxExclusiveAmountAmount { get; set; }

        //[Column("taxTotal")]
        //public TaxTotal TaxTotal { get; set; }

        [Column("taxTotalAmount")]
        public double TaxTotalAmount { get; set; }

        //[Column("payableAmount")]
        //public PayableAmount PayableAmount { get; set; }

        [Column("payableAmountAmount")]
        public double PayableAmountAmount { get; set; }

        [Column("remarks")]
        public string Remarks { get; set; }

        [Column("loadingPoint")]
        public string LoadingPoint { get; set; }

        [Column("loadingPointAddress")]
        public string LoadingPointAddress { get; set; }

        [Column("loadingStreetName")]
        public string LoadingStreetName { get; set; }

        //[Column("loadingBuildingNumber")]
        //public object LoadingBuildingNumber { get; set; }

        [Column("loadingPostalZone")]
        public string LoadingPostalZone { get; set; }

        [Column("loadingCityName")]
        public string LoadingCityName { get; set; }

        [Column("unloadingPoint")]
        public string UnloadingPoint { get; set; }

        [Column("unloadingPointAddress")]
        public string UnloadingPointAddress { get; set; }

        [Column("unloadingStreetName")]
        public string UnloadingStreetName { get; set; }

        [Column("unloadingBuildingNumber")]
        public string UnloadingBuildingNumber { get; set; }

        [Column("unloadingPostalZone")]
        public string UnloadingPostalZone { get; set; }

        [Column("unloadingCityName")]
        public string UnloadingCityName { get; set; }

        //[Column("pickingTime")]
        //public object PickingTime { get; set; }

        //[Column("vehiclePlateNumber")]
        //public object VehiclePlateNumber { get; set; }

        [Column("legalStamp")]
        public string LegalStamp { get; set; }

        [Column("isPrinted")]
        public bool IsPrinted { get; set; }

        [Column("noteToRecipient")]
        public string NoteToRecipient { get; set; }

        [Column("sourceDoc")]
        public string SourceDoc { get; set; }

        [Column("sourceDocId")]
        public string SourceDocId { get; set; }

        [Column("autoCreated")]
        public bool AutoCreated { get; set; }

        //[Column("isOneTimeCustomer")]
        //public object IsOneTimeCustomer { get; set; }

        [Column("deliveryOnInvoice")]
        public bool DeliveryOnInvoice { get; set; }

        [Column("emailTo")]
        public string EmailTo { get; set; }

        //[Column("hash")]
        //public object Hash { get; set; }

        //[Column("hashControl")]
        //public object HashControl { get; set; }

        //[Column("discountInValueAmount")]
        //public DiscountInValueAmount DiscountInValueAmount { get; set; }

        [Column("discountInValueAmountAmount")]
        public double DiscountInValueAmountAmount { get; set; }

        [Column("printAllDiscounts")]
        public string PrintAllDiscounts { get; set; }

        //[Column("aTCUD")]
        //public object ATCUD { get; set; }

        //[Column("aTQRCode")]
        //public object ATQRCode { get; set; }

        [Column("documentType")]
        public string DocumentType { get; set; }

        [Column("documentTypeId")]
        public string DocumentTypeId { get; set; }

        [Column("documentTypeDescription")]
        public string DocumentTypeDescription { get; set; }

        [Column("serie")]
        public string Serie { get; set; }

        [Column("serieId")]
        public string SerieId { get; set; }

        [Column("serieDescription")]
        public string SerieDescription { get; set; }

        [Column("buyerCustomerParty")]
        public string BuyerCustomerParty { get; set; }

        [Column("buyerCustomerPartyId")]
        public string BuyerCustomerPartyId { get; set; }

        [Column("buyerCustomerPartyBaseEntityId")]
        public string BuyerCustomerPartyBaseEntityId { get; set; }

        [Column("buyerCustomerPartyDescription")]
        public string BuyerCustomerPartyDescription { get; set; }

        [Column("accountingParty")]
        public string AccountingParty { get; set; }

        [Column("accountingPartyId")]
        public string AccountingPartyId { get; set; }

        [Column("accountingPartyDescription")]
        public string AccountingPartyDescription { get; set; }

        [Column("loadingCountry")]
        public string LoadingCountry { get; set; }

        [Column("loadingCountryId")]
        public string LoadingCountryId { get; set; }

        [Column("loadingCountryDescription")]
        public string LoadingCountryDescription { get; set; }

        [Column("unloadingCountry")]
        public string UnloadingCountry { get; set; }

        [Column("unloadingCountryId")]
        public string UnloadingCountryId { get; set; }

        [Column("unloadingCountryDescription")]
        public string UnloadingCountryDescription { get; set; }

        [Column("currency")]
        public string Currency { get; set; }

        [Column("currencyId")]
        public string CurrencyId { get; set; }

        [Column("currencyDescription")]
        public string CurrencyDescription { get; set; }

        //TODO
        //[Column("documentLines")]
        //public List<DocumentLine> DocumentLines { get; set; }

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

        [Column("deliveryTerm")]
        public string DeliveryTerm { get; set; }

        [Column("deliveryTermId")]
        public string DeliveryTermId { get; set; }

        [Column("deliveryTermDescription")]
        public string DeliveryTermDescription { get; set; }

        [Column("company")]
        public string Company { get; set; }

        [Column("companyId")]
        public string CompanyId { get; set; }

        [Column("companyDescription")]
        public string CompanyDescription { get; set; }

        //[Column("economicActivityClassification")]
        //public object EconomicActivityClassification { get; set; }

        //[Column("economicActivityClassificationId")]
        //public object EconomicActivityClassificationId { get; set; }

        //[Column("economicActivityClassificationDescription")]
        //public object EconomicActivityClassificationDescription { get; set; }

        //[Column("priceList")]
        //public object PriceList { get; set; }

        //[Column("priceListId")]
        //public object PriceListId { get; set; }

        //[Column("priceListDescription")]
        //public object PriceListDescription { get; set; }

        //[Column("salesperson")]
        //public object Salesperson { get; set; }

        //[Column("salespersonId")]
        //public object SalespersonId { get; set; }

        //[Column("salespersonBaseEntityId")]
        //public object SalespersonBaseEntityId { get; set; }

        //[Column("salespersonDescription")]
        //public object SalespersonDescription { get; set; }

        //TODO
        //[Column("documentTaxes")]
        //public List<DocumentTax> DocumentTaxes { get; set; }

        //[Column("altAddress")]
        //public object AltAddress { get; set; }

        //[Column("altAddressId")]
        //public object AltAddressId { get; set; }

        [Column("documentStatus")]
        public int DocumentStatus { get; set; }

        [Column("documentStatusDescription")]
        public string DocumentStatusDescription { get; set; }

        //[Column("salesChannel")]
        //public object SalesChannel { get; set; }

        //[Column("salesChannelId")]
        //public object SalesChannelId { get; set; }

        //[Column("salesChannelDescription")]
        //public object SalesChannelDescription { get; set; }

        [Column("sourceSchemaEntity")]
        public string SourceSchemaEntity { get; set; }

        [Column("sourceSchemaEntityId")]
        public string SourceSchemaEntityId { get; set; }

        [Column("orderNature")]
        public int OrderNature { get; set; }

        [Column("orderNatureDescription")]
        public string OrderNatureDescription { get; set; }

        //[Column("accountingAltAddress")]
        //public object AccountingAltAddress { get; set; }

        //[Column("accountingAltAddressId")]
        //public object AccountingAltAddressId { get; set; }

        //[Column("notification")]
        //public object Notification { get; set; }

        //[Column("notificationId")]
        //public object NotificationId { get; set; }

        //[Column("notificationDescription")]
        //public object NotificationDescription { get; set; }

        [Column("baseCurrencyId")]
        public string BaseCurrencyId { get; set; }

        //[Column("baseCurrency")]
        //public object BaseCurrency { get; set; }

        //[Column("baseCurrencyDescription")]
        //public object BaseCurrencyDescription { get; set; }

        [Column("reportingCurrencyId")]
        public string ReportingCurrencyId { get; set; }

        //[Column("reportingCurrency")]
        //public object ReportingCurrency { get; set; }

        //[Column("reportingCurrencyDescription")]
        //public object ReportingCurrencyDescription { get; set; }

        //[Column("customAttributes")]
        //public CustomAttributes CustomAttributes { get; set; }

        [Column("naturalKey")]
        public string NaturalKey { get; set; }

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

        [Column("_state")]
        public int State { get; set; }
    }

    public class DocumentTaxOrder
    {
        //[Column("version")]
        //public List<int> Version { get; set; }

        [Column("versionByte")]
        public string VersionByte { get; set; }

        [Column("orderId")]
        public string OrderId { get; set; }

        [Column("isExempt")]
        public bool IsExempt { get; set; }

        [Column("taxableAmount")]
        public TaxableAmount TaxableAmount { get; set; }

        [Column("taxableAmountAmount")]
        public double TaxableAmountAmount { get; set; }

        [Column("taxPercentage")]
        public double TaxPercentage { get; set; }

        [Column("taxAmount")]
        public TaxAmount TaxAmount { get; set; }

        [Column("taxAmountAmount")]
        public double TaxAmountAmount { get; set; }

        [Column("taxTypeCode")]
        public string TaxTypeCode { get; set; }

        [Column("taxTypeCodeId")]
        public string TaxTypeCodeId { get; set; }

        [Column("taxTypeCodeDescription")]
        public string TaxTypeCodeDescription { get; set; }

        [Column("currency")]
        public string Currency { get; set; }

        [Column("currencyId")]
        public string CurrencyId { get; set; }

        [Column("currencyDescription")]
        public string CurrencyDescription { get; set; }

        [Column("exemptionReasonCode")]
        public string ExemptionReasonCode { get; set; }

        [Column("exemptionReasonCodeId")]
        public string ExemptionReasonCodeId { get; set; }

        [Column("exemptionReasonCodeDescription")]
        public string ExemptionReasonCodeDescription { get; set; }

        [Column("baseCurrencyId")]
        public string BaseCurrencyId { get; set; }

        //[Column("baseCurrency")]
        //public object BaseCurrency { get; set; }

        //[Column("baseCurrencyDescription")]
        //public object BaseCurrencyDescription { get; set; }

        [Column("reportingCurrencyId")]
        public string ReportingCurrencyId { get; set; }

        //[Column("reportingCurrency")]
        //public object ReportingCurrency { get; set; }

        //[Column("reportingCurrencyDescription")]
        //public object ReportingCurrencyDescription { get; set; }

        [Column("index")]
        public int Index { get; set; }

        [Column("id")]
        public string Id { get; set; }

        [Column("isActive")]
        public bool IsActive { get; set; }

        [Column("isDeleted")]
        public bool IsDeleted { get; set; }

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

        [Column("_state")]
        public int State { get; set; }
    }

    public class DocumentLineOrder
    {
        //[Column("version")]
        //public List<int> Version { get; set; }

        [Column("versionByte")]
        public string VersionByte { get; set; }

        [Column("orderId")]
        public string OrderId { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("quantity")]
        public double Quantity { get; set; }

        [Column("quantityDecimalPlaces")]
        public int QuantityDecimalPlaces { get; set; }

        [Column("deliveredQuantity")]
        public double DeliveredQuantity { get; set; }

        [Column("deliveredQuantityDecimalPlaces")]
        public int DeliveredQuantityDecimalPlaces { get; set; }

        [Column("invoicedQuantity")]
        public double InvoicedQuantity { get; set; }

        [Column("invoicedQuantityDecimalPlaces")]
        public int InvoicedQuantityDecimalPlaces { get; set; }

        [Column("unitPrice")]
        public UnitPrice UnitPrice { get; set; }

        [Column("unitPriceAmount")]
        public double UnitPriceAmount { get; set; }

        [Column("deliveryDate")]
        public DateTime DeliveryDate { get; set; }

        [Column("discount1")]
        public double Discount1 { get; set; }

        [Column("discount2")]
        public double Discount2 { get; set; }

        [Column("discount3")]
        public double Discount3 { get; set; }

        //[Column("taxTotal")]
        //public TaxTotal TaxTotal { get; set; }

        [Column("taxTotalAmount")]
        public double TaxTotalAmount { get; set; }

        //[Column("allowanceChargeAmount")]
        //public AllowanceChargeAmount AllowanceChargeAmount { get; set; }

        [Column("allowanceChargeAmountAmount")]
        public double AllowanceChargeAmountAmount { get; set; }

        //[Column("taxExclusiveAmount")]
        //public TaxExclusiveAmount TaxExclusiveAmount { get; set; }

        [Column("taxExclusiveAmountAmount")]
        public double TaxExclusiveAmountAmount { get; set; }

        //[Column("grossValue")]
        //public GrossValue GrossValue { get; set; }

        [Column("grossValueAmount")]
        public double GrossValueAmount { get; set; }

        [Column("lineExtensionAmount")]
        public LineExtensionAmount LineExtensionAmount { get; set; }

        [Column("lineExtensionAmountAmount")]
        public double LineExtensionAmountAmount { get; set; }

        [Column("sourceDoc")]
        public string SourceDoc { get; set; }

        [Column("sourceDocId")]
        public string SourceDocId { get; set; }

        [Column("sourceDocLine")]
        public int SourceDocLine { get; set; }

        [Column("sourceDocLineId")]
        public string SourceDocLineId { get; set; }

        [Column("complementaryDescription")]
        public string ComplementaryDescription { get; set; }

        [Column("printAllDiscounts")]
        public string PrintAllDiscounts { get; set; }

        //[Column("commitmentReference")]
        //public object CommitmentReference { get; set; }

        [Column("sourceSchemaEntity")]
        public string SourceSchemaEntity { get; set; }

        [Column("sourceSchemaEntityId")]
        public string SourceSchemaEntityId { get; set; }

        [Column("currency")]
        public string Currency { get; set; }

        [Column("currencyId")]
        public string CurrencyId { get; set; }

        [Column("currencyDescription")]
        public string CurrencyDescription { get; set; }

        [Column("unit")]
        public string Unit { get; set; }

        [Column("unitId")]
        public string UnitId { get; set; }

        [Column("unitDescription")]
        public string UnitDescription { get; set; }

        [Column("salesItem")]
        public string SalesItem { get; set; }

        [Column("salesItemId")]
        public string SalesItemId { get; set; }

        [Column("salesItemBaseEntityId")]
        public string SalesItemBaseEntityId { get; set; }

        [Column("salesItemDescription")]
        public string SalesItemDescription { get; set; }

        [Column("itemTaxSchema")]
        public string ItemTaxSchema { get; set; }

        [Column("itemTaxSchemaId")]
        public string ItemTaxSchemaId { get; set; }

        [Column("itemTaxSchemaDescription")]
        public string ItemTaxSchemaDescription { get; set; }

        [Column("partyTaxSchema")]
        public string PartyTaxSchema { get; set; }

        [Column("partyTaxSchemaId")]
        public string PartyTaxSchemaId { get; set; }

        [Column("partyTaxSchemaDescription")]
        public string PartyTaxSchemaDescription { get; set; }

        //TODO
        //[Column("documentLineTaxes")]
        //public List<DocumentLineTax> DocumentLineTaxes { get; set; }

        [Column("warehouse")]
        public string Warehouse { get; set; }

        [Column("warehouseId")]
        public string WarehouseId { get; set; }

        [Column("warehouseDescription")]
        public string WarehouseDescription { get; set; }

        [Column("documentLineStatus")]
        public int DocumentLineStatus { get; set; }

        [Column("documentLineStatusDescription")]
        public string DocumentLineStatusDescription { get; set; }

        [Column("itemType")]
        public int ItemType { get; set; }

        [Column("itemTypeDescription")]
        public string ItemTypeDescription { get; set; }

        [Column("baseCurrencyId")]
        public string BaseCurrencyId { get; set; }

        //[Column("baseCurrency")]
        //public object BaseCurrency { get; set; }

        //[Column("baseCurrencyDescription")]
        //public object BaseCurrencyDescription { get; set; }

        [Column("reportingCurrencyId")]
        public string ReportingCurrencyId { get; set; }

        //[Column("reportingCurrency")]
        //public object ReportingCurrency { get; set; }

        //[Column("reportingCurrencyDescription")]
        //public object ReportingCurrencyDescription { get; set; }

        //[Column("customAttributes")]
        //public CustomAttributes CustomAttributes { get; set; }

        [Column("index")]
        public int Index { get; set; }

        [Column("id")]
        public string Id { get; set; }

        [Column("isActive")]
        public bool IsActive { get; set; }

        [Column("isDeleted")]
        public bool IsDeleted { get; set; }

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

        [Column("_state")]
        public int State { get; set; }
    }

    public class CustomAttributes
    {
    }

    public class DocumentLineTaxOrder
    {
        //[Column("version")]
        //public List<int> Version { get; set; }

        [Column("versionByte")]
        public string VersionByte { get; set; }

        [Column("orderLineId")]
        public string OrderLineId { get; set; }

        [Column("orderId")]
        public string OrderId { get; set; }

        [Column("isExempt")]
        public bool IsExempt { get; set; }

        [Column("taxableAmount")]
        public TaxableAmount TaxableAmount { get; set; }

        [Column("taxableAmountAmount")]
        public double TaxableAmountAmount { get; set; }

        [Column("taxPercentage")]
        public double TaxPercentage { get; set; }

        [Column("taxAmount")]
        public TaxAmount TaxAmount { get; set; }

        [Column("taxAmountAmount")]
        public double TaxAmountAmount { get; set; }

        [Column("taxTypeCode")]
        public string TaxTypeCode { get; set; }

        [Column("taxTypeCodeId")]
        public string TaxTypeCodeId { get; set; }

        [Column("taxTypeCodeDescription")]
        public string TaxTypeCodeDescription { get; set; }

        [Column("currency")]
        public string Currency { get; set; }

        [Column("currencyId")]
        public string CurrencyId { get; set; }

        [Column("currencyDescription")]
        public string CurrencyDescription { get; set; }

        [Column("exemptionReasonCode")]
        public string ExemptionReasonCode { get; set; }

        [Column("exemptionReasonCodeId")]
        public string ExemptionReasonCodeId { get; set; }

        [Column("exemptionReasonCodeDescription")]
        public string ExemptionReasonCodeDescription { get; set; }

        [Column("baseCurrencyId")]
        public string BaseCurrencyId { get; set; }

        //[Column("baseCurrency")]
        //public object BaseCurrency { get; set; }

        //[Column("baseCurrencyDescription")]
        //public object BaseCurrencyDescription { get; set; }

        [Column("reportingCurrencyId")]
        public string ReportingCurrencyId { get; set; }

        //[Column("reportingCurrency")]
        //public object ReportingCurrency { get; set; }

        //[Column("reportingCurrencyDescription")]
        //public object ReportingCurrencyDescription { get; set; }

        [Column("index")]
        public int Index { get; set; }

        [Column("id")]
        public string Id { get; set; }

        [Column("isActive")]
        public bool IsActive { get; set; }

        [Column("isDeleted")]
        public bool IsDeleted { get; set; }

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

        [Column("_state")]
        public int State { get; set; }
    }

    public class TaxAmount
    {
        [Column("amount")]
        public double Amount { get; set; }

        [Column("baseAmount")]
        public double? BaseAmount { get; set; }

        [Column("reportingAmount")]
        public double ReportingAmount { get; set; }

        [Column("fractionDigits")]
        public int FractionDigits { get; set; }

        [Column("symbol")]
        public string Symbol { get; set; }
    }

    public class TaxableAmount
    {
        [Column("amount")]
        public double Amount { get; set; }

        [Column("baseAmount")]
        public double? BaseAmount { get; set; }

        [Column("reportingAmount")]
        public double ReportingAmount { get; set; }

        [Column("fractionDigits")]
        public int FractionDigits { get; set; }

        [Column("symbol")]
        public string Symbol { get; set; }
    }

    public class LineExtensionAmount
    {
        [Column("amount")]
        public double Amount { get; set; }

        [Column("baseAmount")]
        public double BaseAmount { get; set; }

        [Column("reportingAmount")]
        public double ReportingAmount { get; set; }

        [Column("fractionDigits")]
        public int FractionDigits { get; set; }

        [Column("symbol")]
        public string Symbol { get; set; }
    }

    public class UnitPrice
    {
        [Column("Id")]
        [Key]
        [DatabaseGenerated
        (DatabaseGeneratedOption.Identity)]
        [Required]
        [JsonProperty("idBaseLocal")]

        public long Id { get; set; }

        [Column("amount")]
        [JsonProperty("amount")]
        public double? Amount { get; set; }

        [Column("baseAmount")]
        [JsonProperty("baseAmount")]
        public double? BaseAmount { get; set; }

        [Column("reportingAmount")]
        [JsonProperty("reportingAmount")]
        public double? ReportingAmount { get; set; }

        [Column("fractionDigits")]
        [JsonProperty("fractionDigits")]
        public int? FractionDigits { get; set; }

        [Column("symbol")]
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

    }

    public class DiscountInValueAmount
    {
        [Column("amount")]
        public double Amount { get; set; }

        [Column("baseAmount")]
        public double BaseAmount { get; set; }

        [Column("reportingAmount")]
        public double ReportingAmount { get; set; }

        [Column("fractionDigits")]
        public int FractionDigits { get; set; }

        [Column("symbol")]
        public string Symbol { get; set; }
    }

    public class PayableAmount
    {
        [Column("amount")]
        public double Amount { get; set; }

        [Column("baseAmount")]
        public double BaseAmount { get; set; }

        [Column("reportingAmount")]
        public double ReportingAmount { get; set; }

        [Column("fractionDigits")]
        public int FractionDigits { get; set; }

        [Column("symbol")]
        public string Symbol { get; set; }
    }

    public class TaxTotal
    {
        [Column("amount")]
        public double Amount { get; set; }

        [Column("baseAmount")]
        public double BaseAmount { get; set; }

        [Column("reportingAmount")]
        public double ReportingAmount { get; set; }

        [Column("fractionDigits")]
        public int FractionDigits { get; set; }

        [Column("symbol")]
        public string Symbol { get; set; }
    }

    public class TaxExclusiveAmount
    {
        [Column("amount")]
        public double Amount { get; set; }

        [Column("baseAmount")]
        public double BaseAmount { get; set; }

        [Column("reportingAmount")]
        public double ReportingAmount { get; set; }

        [Column("fractionDigits")]
        public int FractionDigits { get; set; }

        [Column("symbol")]
        public string Symbol { get; set; }
    }

    public class AllowanceChargeAmount
    {
        [Column("amount")]
        public double Amount { get; set; }

        [Column("baseAmount")]
        public double BaseAmount { get; set; }

        [Column("reportingAmount")]
        public double ReportingAmount { get; set; }

        [Column("fractionDigits")]
        public int FractionDigits { get; set; }

        [Column("symbol")]
        public string Symbol { get; set; }
    }

    public class GrossValue
    {
        [Column("amount")]
        public double Amount { get; set; }

        [Column("baseAmount")]
        public double BaseAmount { get; set; }

        [Column("reportingAmount")]
        public double ReportingAmount { get; set; }

        [Column("fractionDigits")]
        public int FractionDigits { get; set; }

        [Column("symbol")]
        public string Symbol { get; set; }
    }

}
