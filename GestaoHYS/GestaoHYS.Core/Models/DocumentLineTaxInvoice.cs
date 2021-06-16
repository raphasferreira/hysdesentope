using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoHYS.Core.Models
{
    public class DocumentLineTaxInvoice
    {
        //[Column("version")]
        //public List<int> Version { get; set; }

        [Column("versionByte")]
        public string VersionByte { get; set; }

        [Column("invoiceLineId")]
        public string InvoiceLineId { get; set; }

        [Column("invoiceId")]
        public string InvoiceId { get; set; }

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

        [Column("exemptionReasonCode")]
        public string ExemptionReasonCode { get; set; }

        [Column("exemptionReasonCodeId")]
        public string ExemptionReasonCodeId { get; set; }

        [Column("exemptionReasonCodeDescription")]
        public string ExemptionReasonCodeDescription { get; set; }

        [Column("currency")]
        public string Currency { get; set; }

        [Column("currencyId")]
        public string CurrencyId { get; set; }

        [Column("currencyDescription")]
        public string CurrencyDescription { get; set; }

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
}
