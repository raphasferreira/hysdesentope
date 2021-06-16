using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoHYS.Core.Models
{
    public class PriceListLine
    {
        //[Column("version")]
        //public List<int> Version { get; set; }

        [Column("versionByte")]
        public string VersionByte { get; set; }

        [Column("salesItemId")]
        public string SalesItemId { get; set; }

        //[Column("priceAmount")]
        //public PriceAmount PriceAmount { get; set; }

        [Column("priceAmountAmount")]
        public double PriceAmountAmount { get; set; }

        [Column("unit")]
        public string Unit { get; set; }

        [Column("unitId")]
        public string UnitId { get; set; }

        [Column("unitDescription")]
        public string UnitDescription { get; set; }

        [Column("priceList")]
        public string PriceList { get; set; }

        [Column("priceListId")]
        public string PriceListId { get; set; }

        [Column("priceListDescription")]
        public string PriceListDescription { get; set; }

        [Column("currency")]
        public string Currency { get; set; }

        [Column("currencyId")]
        public string CurrencyId { get; set; }

        [Column("currencyDescription")]
        public string CurrencyDescription { get; set; }

        //[Column("baseCurrencyId")]
        //public object BaseCurrencyId { get; set; }

        //[Column("baseCurrency")]
        //public object BaseCurrency { get; set; }

        //[Column("baseCurrencyDescription")]
        //public object BaseCurrencyDescription { get; set; }

        //[Column("reportingCurrencyId")]
        //public string ReportingCurrencyId { get; set; }

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
