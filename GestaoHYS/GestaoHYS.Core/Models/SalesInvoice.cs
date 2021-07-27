using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoHYS.Core.Models
{
    [Table("SalesInvoice")]
    public class SalesInvoice
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
        //public List<int?> Version { get; set; }

        [Column("versionByte")]
        [JsonProperty("versionByte")]
        public string VersionByte { get; set; }

        [Column("seriesNumber")]
        [JsonProperty("seriesNumber")]
        public int? SeriesNumber { get; set; }

        [Column("documentDate")]
        [JsonProperty("documentDate")]
        public DateTime? DocumentDate { get; set; }

        //[Column("postingDate")]
        //public DateTime? PostingDate { get; set; }

        [Column("taxIncluded")]
        [JsonProperty("taxIncluded")]
        public bool? TaxIncluded { get; set; }

        [Column("buyerCustomerPartyName")]
        [JsonProperty("buyerCustomerPartyName")]
        public string BuyerCustomerPartyName { get; set; }

        [Column("buyerCustomerPartyTaxId")]
        [JsonProperty("buyerCustomerPartyTaxId")]
        public string BuyerCustomerPartyTaxId { get; set; }

        [Column("buyerCustomerPartyAddress")]
        [JsonProperty("buyerCustomerPartyAddress")]
        public string BuyerCustomerPartyAddress { get; set; }

        [Column("accountingPartyName")]
        [JsonProperty("accountingPartyName")]
        public string AccountingPartyName { get; set; }

        [Column("accountingPartyTaxId")]
        [JsonProperty("accountingPartyTaxId")]
        public string AccountingPartyTaxId { get; set; }

        [Column("accountingPartyAddress")]
        [JsonProperty("accountingPartyAddress")]
        public string AccountingPartyAddress { get; set; }


        [Column("exchangeRateDecimalPlaces")]
        [JsonProperty("exchangeRateDecimalPlaces")]
        public int? ExchangeRateDecimalPlaces { get; set; }

        //[Column("exchangeRateDate")]
        //public DateTime? ExchangeRateDate { get; set; }

        [Column("discount")]
        [JsonProperty("discount")]
        public double? Discount { get; set; }

        [Column("cashInvoice")]
        [JsonProperty("cashInvoice")]
        public bool? CashInvoice { get; set; }

        

        [Column("checkPayment")]
        [JsonProperty("checkPayment")]
        public bool? CheckPayment { get; set; }

 
        [Column("grossValueAmount")]
        [JsonProperty("grossValueAmount")]
        public double? GrossValueAmount { get; set; }

       
        [Column("allowanceChargeAmountAmount")]
        [JsonProperty("allowanceChargeAmountAmount")]
        public double? AllowanceChargeAmountAmount { get; set; }



        [Column("taxExclusiveAmountAmount")]
        [JsonProperty("taxExclusiveAmountAmount")]
        public double? TaxExclusiveAmountAmount { get; set; }

 
        [Column("taxTotalAmount")]
        [JsonProperty("taxTotalAmount")]
        public double? TaxTotalAmount { get; set; }

  

        [Column("payableAmountAmount")]
        [JsonProperty("payableAmountAmount")]
        public double? PayableAmountAmount { get; set; }


        [Column("wTaxTotalAmount")]
        [JsonProperty("wTaxTotalAmount")]
        public double? WTaxTotalAmount { get; set; }


        [Column("totalLiabilityAmount")]
        [JsonProperty("totalLiabilityAmount")]
        public double? TotalLiabilityAmount { get; set; }

        [Column("remarks")]
        [JsonProperty("remarks")]
        public string Remarks { get; set; }

        [Column("note")]
        [JsonProperty("note")]
        public string Note { get; set; }

        [Column("noteToRecipient")]
        [JsonProperty("noteToRecipient")]
        public string NoteToRecipient { get; set; }

        [Column("isPrinted")]
        [JsonProperty("isPrinted")]
        public bool? IsPrinted { get; set; }

        [Column("settlementDiscountPercent")]
        [JsonProperty("settlementDiscountPercent")]
        public double? SettlementDiscountPercent { get; set; }

        [Column("loadingPoint")]
        [JsonProperty("loadingPoint")]
        public string LoadingPoint { get; set; }

        [Column("loadingStreetName")]
        [JsonProperty("loadingStreetName")]
        public string LoadingStreetName { get; set; }



        [Column("loadingPostalZone")]
        [JsonProperty("loadingPostalZone")]
        public string LoadingPostalZone { get; set; }

        [Column("loadingCityName")]
        [JsonProperty("loadingCityName")]
        public string LoadingCityName { get; set; }


        [Column("loadingPointAddress")]
        [JsonProperty("loadingPointAddress")]
        public string LoadingPointAddress { get; set; }

        [Column("unloadingPoint")]
        [JsonProperty("unloadingPoint")]
        public string UnloadingPoint { get; set; }

        [Column("unloadingStreetName")]
        [JsonProperty("unloadingStreetName")]
        public string UnloadingStreetName { get; set; }

        [Column("unloadingBuildingNumber")]
        [JsonProperty("unloadingBuildingNumber")]
        public string UnloadingBuildingNumber { get; set; }

        [Column("unloadingPostalZone")]
        [JsonProperty("unloadingPostalZone")]
        public string UnloadingPostalZone { get; set; }

        [Column("unloadingCityName")]
        [JsonProperty("unloadingCityName")]
        public string UnloadingCityName { get; set; }

        [Column("unloadingPointAddress")]
        [JsonProperty("unloadingPointAddress")]
        public string UnloadingPointAddress { get; set; }

        [Column("hash")]
        [JsonProperty("hash")]
        public string Hash { get; set; }

        [Column("hashControl")]
        [JsonProperty("hashControl")]
        public string HashControl { get; set; }

        [Column("legalStamp")]
        [JsonProperty("legalStamp")]
        public string LegalStamp { get; set; }

        [Column("isTransformed")]
        [JsonProperty("isTransformed")]
        public bool? IsTransformed { get; set; }

        [Column("dueDate")]
        [JsonProperty("dueDate")]
        public DateTime? DueDate { get; set; }

        [Column("isManualSerie")]
        [JsonProperty("isManualSerie")]
        public bool? IsManualSerie { get; set; }

        [Column("isExternal")]
        [JsonProperty("isExternal")]
        public bool? IsExternal { get; set; }

        [Column("isManual")]
        [JsonProperty("isManual")]
        public bool? IsManual { get; set; }

        [Column("isSimpleInvoice")]
        [JsonProperty("isSimpleInvoice")]
        public bool? IsSimpleInvoice { get; set; }

        [Column("isWsCommunicable")]
        [JsonProperty("isWsCommunicable")]
        public bool? IsWsCommunicable { get; set; }

        [Column("emailTo")]
        [JsonProperty("emailTo")]
        public string EmailTo { get; set; }

        [Column("isCommunicated")]
        [JsonProperty("isCommunicated")]
        public bool? IsCommunicated { get; set; }

        [Column("discountInValueAmountAmount")]
        [JsonProperty("discountInValueAmountAmount")]
        public double? DiscountInValueAmountAmount { get; set; }

        [Column("printAllDiscounts")]
        [JsonProperty("printAllDiscounts")]
        public string PrintAllDiscounts { get; set; }

        [Column("isLocked")]
        [JsonProperty("isLocked")]
        public bool? IsLocked { get; set; }


        [Column("aTQRCode")]
        [JsonProperty("aTQRCode")]
        public string ATQRCode { get; set; }

        [Column("documentType")]
        [JsonProperty("documentType")]
        public string DocumentType { get; set; }

        [Column("documentTypeId")]
        [JsonProperty("documentTypeId")]
        public string DocumentTypeId { get; set; }

        [Column("documentTypeDescription")]
        [JsonProperty("documentTypeDescription")]
        public string DocumentTypeDescription { get; set; }

        [Column("serie")]
        [JsonProperty("serie")]
        public string Serie { get; set; }

        [Column("serieId")]
        [JsonProperty("serieId")]
        public string SerieId { get; set; }

        [Column("serieDescription")]
        [JsonProperty("serieDescription")]
        public string SerieDescription { get; set; }

        [Column("company")]
        [JsonProperty("company")]
        public string Company { get; set; }

        [Column("companyId")]
        [JsonProperty("companyId")]
        public string CompanyId { get; set; }

        [Column("companyDescription")]
        [JsonProperty("companyDescription")]
        public string CompanyDescription { get; set; }

        [Column("cashFlowItem")]
        [JsonProperty("cashFlowItem")]
        public string CashFlowItem { get; set; }

        [Column("cashFlowItemId")]
        [JsonProperty("cashFlowItemId")]
        public string CashFlowItemId { get; set; }

        [Column("cashFlowItemDescription")]
        [JsonProperty("cashFlowItemDescription")]
        public string CashFlowItemDescription { get; set; }

        [Column("financialAccount")]
        [JsonProperty("financialAccount")]
        public string FinancialAccount { get; set; }

        [Column("financialAccountId")]
        [JsonProperty("financialAccountId")]
        public string FinancialAccountId { get; set; }

        [Column("financialAccountDescription")]
        [JsonProperty("financialAccountDescription")]
        public string FinancialAccountDescription { get; set; }

        [Column("deliveryTerm")]
        [JsonProperty("deliveryTerm")]
        public string DeliveryTerm { get; set; }

        [Column("deliveryTermId")]
        [JsonProperty("deliveryTermId")]
        public string DeliveryTermId { get; set; }

        [Column("deliveryTermDescription")]
        [JsonProperty("deliveryTermDescription")]
        public string DeliveryTermDescription { get; set; }

        [Column("paymentTerm")]
        [JsonProperty("paymentTerm")]
        public string PaymentTerm { get; set; }

        [Column("paymentTermId")]
        [JsonProperty("paymentTermId")]
        public string PaymentTermId { get; set; }

        [Column("paymentTermDescription")]
        [JsonProperty("paymentTermDescription")]
        public string PaymentTermDescription { get; set; }

        [Column("paymentMethod")]
        [JsonProperty("paymentMethod")]
        public string PaymentMethod { get; set; }

        [Column("paymentMethodId")]
        [JsonProperty("paymentMethodId")]
        public string PaymentMethodId { get; set; }

        [Column("paymentMethodDescription")]
        [JsonProperty("paymentMethodDescription")]
        public string PaymentMethodDescription { get; set; }

        [Column("currency")]
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [Column("currencyId")]
        [JsonProperty("currencyId")]
        public string CurrencyId { get; set; }

        [Column("currencyDescription")]
        [JsonProperty("currencyDescription")]
        public string CurrencyDescription { get; set; }

        [Column("buyerCustomerParty")]
        [JsonProperty("buyerCustomerParty")]
        public string BuyerCustomerParty { get; set; }

        [Column("buyerCustomerPartyId")]
        [JsonProperty("buyerCustomerPartyId")]
        public string BuyerCustomerPartyId { get; set; }

        [Column("buyerCustomerPartyBaseEntityId")]
        [JsonProperty("buyerCustomerPartyBaseEntityId")]
        public string BuyerCustomerPartyBaseEntityId { get; set; }

        [Column("buyerCustomerPartyDescription")]
        [JsonProperty("buyerCustomerPartyDescription")]
        public string BuyerCustomerPartyDescription { get; set; }

        [Column("accountingParty")]
        [JsonProperty("accountingParty")]
        public string AccountingParty { get; set; }

        [Column("accountingPartyId")]
        [JsonProperty("accountingPartyId")]
        public string AccountingPartyId { get; set; }

        [Column("accountingPartyDescription")]
        [JsonProperty("accountingPartyDescription")]
        public string AccountingPartyDescription { get; set; }

        [Column("priceList")]
        [JsonProperty("priceList")]
        public string PriceList { get; set; }

        [Column("priceListId")]
        [JsonProperty("priceListId")]
        public string PriceListId { get; set; }

        [Column("priceListDescription")]
        [JsonProperty("priceListDescription")]
        public string PriceListDescription { get; set; }

        [Column("documentStatus")]
        [JsonProperty("documentStatus")]
        public int? DocumentStatus { get; set; }

        [Column("documentStatusDescription")]
        [JsonProperty("documentStatusDescription")]
        public string DocumentStatusDescription { get; set; }

        [Column("loadingCountry")]
        [JsonProperty("loadingCountry")]
        public string LoadingCountry { get; set; }

        [Column("loadingCountryId")]
        [JsonProperty("loadingCountryId")]
        public string LoadingCountryId { get; set; }

        [Column("loadingCountryDescription")]
        [JsonProperty("loadingCountryDescription")]
        public string LoadingCountryDescription { get; set; }

        [Column("unloadingCountry")]
        [JsonProperty("unloadingCountry")]
        public string UnloadingCountry { get; set; }

        [Column("unloadingCountryId")]
        [JsonProperty("unloadingCountryId")]
        public string UnloadingCountryId { get; set; }

        [Column("unloadingCountryDescription")]
        [JsonProperty("unloadingCountryDescription")]
        public string UnloadingCountryDescription { get; set; }

        [JsonProperty("documentLines")]
        public List<DocumentLineInvoice> DocumentLines { get; set; }

        [Column("fiscalDocumentType")]
        [JsonProperty("fiscalDocumentType")]
        public string FiscalDocumentType { get; set; }

        [Column("fiscalDocumentTypeId")]
        [JsonProperty("fiscalDocumentTypeId")]
        public string FiscalDocumentTypeId { get; set; }

        [Column("fiscalDocumentTypeDescription")]
        [JsonProperty("fiscalDocumentTypeDescription")]
        public string FiscalDocumentTypeDescription { get; set; }

        [Column("accountingSchema")]
        [JsonProperty("accountingSchema")]
        public int? AccountingSchema { get; set; }

        [Column("accountingSchemaDescription")]
        [JsonProperty("accountingSchemaDescription")]
        public string AccountingSchemaDescription { get; set; }

        [Column("partyAccountingSchema")]
        [JsonProperty("partyAccountingSchema")]
        public int? PartyAccountingSchema { get; set; }

        [Column("partyAccountingSchemaDescription")]
        [JsonProperty("partyAccountingSchemaDescription")]
        public string PartyAccountingSchemaDescription { get; set; }

        [Column("notification")]
        [JsonProperty("notification")]
        public string Notification { get; set; }

        [Column("notificationId")]
        [JsonProperty("notificationId")]
        public string NotificationId { get; set; }

        [Column("notificationDescription")]
        [JsonProperty("notificationDescription")]
        public string NotificationDescription { get; set; }


        [Column("baseCurrencyId")]
        [JsonProperty("baseCurrencyId")]
        public string BaseCurrencyId { get; set; }


        [Column("reportingCurrencyId")]
        [JsonProperty("reportingCurrencyId")]
        public string ReportingCurrencyId { get; set; }


        [Column("naturalKey")]
        [JsonProperty("naturalKey")]
        public string NaturalKey { get; set; }

        [Column("isDraft")]
        [JsonProperty("isDraft")]
        public bool? IsDraft { get; set; }

        [Column("isActive")]
        [JsonProperty("isActive")]
        public bool? IsActive { get; set; }

        [Column("isDeleted")]
        [JsonProperty("isDeleted")]
        public bool IsDeleted { get; set; }

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

        [Column("_state")]
        [JsonProperty("_state")]
        public int? State { get; set; }

        public bool isIntegrated { get; set; }
        public bool isIntegration { get; set; }
        public string ErrosIntegracao { get; set; }
    }
}
