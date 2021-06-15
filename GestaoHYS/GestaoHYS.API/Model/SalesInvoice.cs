using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoHIS.API.Model
{
    [Table("SalesInvoice")]
    public class SalesInvoice
    {

        [Column("Id")]
        [Key]
        [DatabaseGenerated
        (DatabaseGeneratedOption.Identity)]
        [Required]
        public string Id { get; set; }

        //[Column("version")]
        //public List<int> Version { get; set; }

        [Column("versionByte")]
        public string VersionByte { get; set; }

        [Column("seriesNumber")]
        public int SeriesNumber { get; set; }

        //[Column("documentDate")]
        //public DateTime DocumentDate { get; set; }

        //[Column("postingDate")]
        //public DateTime PostingDate { get; set; }

        [Column("taxIncluded")]
        public bool TaxIncluded { get; set; }

        [Column("buyerCustomerPartyName")]
        public string BuyerCustomerPartyName { get; set; }

        [Column("buyerCustomerPartyTaxId")]
        public string BuyerCustomerPartyTaxId { get; set; }

        [Column("buyerCustomerPartyAddress")]
        public string BuyerCustomerPartyAddress { get; set; }

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

        //[Column("exchangeRateDate")]
        //public DateTime ExchangeRateDate { get; set; }

        [Column("discount")]
        public double Discount { get; set; }

        [Column("cashInvoice")]
        public bool CashInvoice { get; set; }

        //[Column("checkDate")]
        //public object CheckDate { get; set; }

        //[Column("checkBank")]
        //public object CheckBank { get; set; }

        //[Column("checkBranch")]
        //public object CheckBranch { get; set; }

        //[Column("checkAccount")]
        //public object CheckAccount { get; set; }

        //[Column("checkEndorsed")]
        //public object CheckEndorsed { get; set; }

        //[Column("checkNumber")]
        //public object CheckNumber { get; set; }

        //[Column("issuePlace")]
        //public object IssuePlace { get; set; }

        [Column("checkPayment")]
        public bool CheckPayment { get; set; }

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

        //[Column("wTaxTotal")]
        //public WTaxTotal WTaxTotal { get; set; }

        [Column("wTaxTotalAmount")]
        public double WTaxTotalAmount { get; set; }

        //[Column("totalLiability")]
        //public TotalLiability TotalLiability { get; set; }

        [Column("totalLiabilityAmount")]
        public double TotalLiabilityAmount { get; set; }

        [Column("remarks")]
        public string Remarks { get; set; }

        [Column("note")]
        public string Note { get; set; }

        [Column("noteToRecipient")]
        public string NoteToRecipient { get; set; }

        [Column("isPrinted")]
        public bool IsPrinted { get; set; }

        [Column("settlementDiscountPercent")]
        public double SettlementDiscountPercent { get; set; }

        [Column("loadingPoint")]
        public string LoadingPoint { get; set; }

        [Column("loadingStreetName")]
        public string LoadingStreetName { get; set; }

        //[Column("loadingBuildingNumber")]
        //public object LoadingBuildingNumber { get; set; }

        [Column("loadingPostalZone")]
        public string LoadingPostalZone { get; set; }

        [Column("loadingCityName")]
        public string LoadingCityName { get; set; }

        //[Column("loadingDateTime")]
        //public DateTime LoadingDateTime { get; set; }

        [Column("loadingPointAddress")]
        public string LoadingPointAddress { get; set; }

        [Column("unloadingPoint")]
        public string UnloadingPoint { get; set; }

        [Column("unloadingStreetName")]
        public string UnloadingStreetName { get; set; }

        [Column("unloadingBuildingNumber")]
        public string UnloadingBuildingNumber { get; set; }

        [Column("unloadingPostalZone")]
        public string UnloadingPostalZone { get; set; }

        [Column("unloadingCityName")]
        public string UnloadingCityName { get; set; }

        [Column("unloadingPointAddress")]
        public string UnloadingPointAddress { get; set; }

        [Column("unloadingDateTime")]
        public DateTime UnloadingDateTime { get; set; }

        //[Column("vehiclePlateNumber")]
        //public object VehiclePlateNumber { get; set; }

        [Column("hash")]
        public string Hash { get; set; }

        [Column("hashControl")]
        public string HashControl { get; set; }

        [Column("legalStamp")]
        public string LegalStamp { get; set; }

        //[Column("manualNumber")]
        //public object ManualNumber { get; set; }

        //[Column("manualDate")]
        //public object ManualDate { get; set; }

        //[Column("manualSerie")]
        //public object ManualSerie { get; set; }

        [Column("isTransformed")]
        public bool IsTransformed { get; set; }

        [Column("dueDate")]
        public DateTime DueDate { get; set; }

        [Column("isManualSerie")]
        public bool IsManualSerie { get; set; }

        [Column("isExternal")]
        public bool IsExternal { get; set; }

        [Column("isManual")]
        public bool IsManual { get; set; }

        //[Column("isOneTimeCustomer")]
        //public object IsOneTimeCustomer { get; set; }

        [Column("isSimpleInvoice")]
        public bool IsSimpleInvoice { get; set; }

        [Column("isWsCommunicable")]
        public bool IsWsCommunicable { get; set; }

        [Column("emailTo")]
        public string EmailTo { get; set; }

        //[Column("isCheckPayment")]
        //public object IsCheckPayment { get; set; }

        //[Column("defaultItemWithholding")]
        //public object DefaultItemWithholding { get; set; }

        //[Column("partyWithholdingMessage")]
        //public object PartyWithholdingMessage { get; set; }

        //[Column("partyHasWithholding")]
        //public object PartyHasWithholding { get; set; }

        //[Column("defaultItemWithholdingId")]
        //public object DefaultItemWithholdingId { get; set; }

        [Column("isCommunicated")]
        public bool IsCommunicated { get; set; }

        //[Column("discountInValueAmount")]
        //public DiscountInValueAmount DiscountInValueAmount { get; set; }

        [Column("discountInValueAmountAmount")]
        public double DiscountInValueAmountAmount { get; set; }

        [Column("printAllDiscounts")]
        public string PrintAllDiscounts { get; set; }

        [Column("isLocked")]
        public bool IsLocked { get; set; }

        //[Column("aTCUD")]
        //public object ATCUD { get; set; }

        [Column("aTQRCode")]
        public string ATQRCode { get; set; }

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

        [Column("cashFlowItem")]
        public string CashFlowItem { get; set; }

        [Column("cashFlowItemId")]
        public string CashFlowItemId { get; set; }

        [Column("cashFlowItemDescription")]
        public string CashFlowItemDescription { get; set; }

        [Column("financialAccount")]
        public string FinancialAccount { get; set; }

        [Column("financialAccountId")]
        public string FinancialAccountId { get; set; }

        [Column("financialAccountDescription")]
        public string FinancialAccountDescription { get; set; }

        [Column("deliveryTerm")]
        public string DeliveryTerm { get; set; }

        [Column("deliveryTermId")]
        public string DeliveryTermId { get; set; }

        [Column("deliveryTermDescription")]
        public string DeliveryTermDescription { get; set; }

        [Column("paymentTerm")]
        public string PaymentTerm { get; set; }

        [Column("paymentTermId")]
        public string PaymentTermId { get; set; }

        [Column("paymentTermDescription")]
        public string PaymentTermDescription { get; set; }

        [Column("paymentMethod")]
        public string PaymentMethod { get; set; }

        [Column("paymentMethodId")]
        public string PaymentMethodId { get; set; }

        [Column("paymentMethodDescription")]
        public string PaymentMethodDescription { get; set; }

        [Column("currency")]
        public string Currency { get; set; }

        [Column("currencyId")]
        public string CurrencyId { get; set; }

        [Column("currencyDescription")]
        public string CurrencyDescription { get; set; }

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

        [Column("priceList")]
        public string PriceList { get; set; }

        [Column("priceListId")]
        public string PriceListId { get; set; }

        [Column("priceListDescription")]
        public string PriceListDescription { get; set; }

        //[Column("salesperson")]
        //public object Salesperson { get; set; }

        //[Column("salespersonId")]
        //public object SalespersonId { get; set; }

        //[Column("salespersonBaseEntityId")]
        //public object SalespersonBaseEntityId { get; set; }

        //[Column("salespersonDescription")]
        //public object SalespersonDescription { get; set; }

        //[Column("altAddress")]
        //public object AltAddress { get; set; }

        //[Column("altAddressId")]
        //public object AltAddressId { get; set; }

        [Column("documentStatus")]
        public int DocumentStatus { get; set; }

        [Column("documentStatusDescription")]
        public string DocumentStatusDescription { get; set; }

        [Column("loadingCountry")]
        public string LoadingCountry { get; set; }

        [Column("loadingCountryId")]
        public string LoadingCountryId { get; set; }

        [Column("loadingCountryDescription")]
        public string LoadingCountryDescription { get; set; }

        //[Column("loadingWarehouse")]
        //public object LoadingWarehouse { get; set; }

        //[Column("loadingWarehouseId")]
        //public object LoadingWarehouseId { get; set; }

        //[Column("loadingWarehouseDescription")]
        //public object LoadingWarehouseDescription { get; set; }

        [Column("unloadingCountry")]
        public string UnloadingCountry { get; set; }

        [Column("unloadingCountryId")]
        public string UnloadingCountryId { get; set; }

        [Column("unloadingCountryDescription")]
        public string UnloadingCountryDescription { get; set; }

        //TODO
        //[Column("documentLines")]
        //public List<DocumentLine> DocumentLines { get; set; }

        //[Column("documentTaxes")]
        //public List<DocumentTax> DocumentTaxes { get; set; }

        //[Column("documentWTaxes")]
        //public List<object> DocumentWTaxes { get; set; }

        //[Column("salesChannel")]
        //public object SalesChannel { get; set; }

        //[Column("salesChannelId")]
        //public object SalesChannelId { get; set; }

        //[Column("salesChannelDescription")]
        //public object SalesChannelDescription { get; set; }

        [Column("fiscalDocumentType")]
        public string FiscalDocumentType { get; set; }

        [Column("fiscalDocumentTypeId")]
        public string FiscalDocumentTypeId { get; set; }

        [Column("fiscalDocumentTypeDescription")]
        public string FiscalDocumentTypeDescription { get; set; }

        //[Column("accountingAltAddress")]
        //public object AccountingAltAddress { get; set; }

        //[Column("accountingAltAddressId")]
        //public object AccountingAltAddressId { get; set; }

        [Column("accountingSchema")]
        public int AccountingSchema { get; set; }

        [Column("accountingSchemaDescription")]
        public string AccountingSchemaDescription { get; set; }

        [Column("partyAccountingSchema")]
        public int PartyAccountingSchema { get; set; }

        [Column("partyAccountingSchemaDescription")]
        public string PartyAccountingSchemaDescription { get; set; }

        [Column("notification")]
        public string Notification { get; set; }

        [Column("notificationId")]
        public string NotificationId { get; set; }

        [Column("notificationDescription")]
        public string NotificationDescription { get; set; }

        //[Column("lockReason")]
        //public object LockReason { get; set; }

        //[Column("lockReasonId")]
        //public object LockReasonId { get; set; }

        //[Column("lockReasonDescription")]
        //public object LockReasonDescription { get; set; }

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
}
