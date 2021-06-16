using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoHYS.Core.Models
{
    public class DocumentLineInvoice
    {
        //[Column("version")]
        //public List<int> Version { get; set; }

        [Column("versionByte")]
        public string VersionByte { get; set; }

        [Column("invoiceId")]
        public string InvoiceId { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("quantity")]
        public double Quantity { get; set; }

        [Column("quantityDecimalPlaces")]
        public int QuantityDecimalPlaces { get; set; }

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

        [Column("complementaryDescription")]
        public string ComplementaryDescription { get; set; }

        //[Column("sourceDoc")]
        //public object SourceDoc { get; set; }

        //[Column("sourceDocId")]
        //public object SourceDocId { get; set; }

        //[Column("sourceDocLine")]
        //public object SourceDocLine { get; set; }

        //[Column("sourceDocLineId")]
        //public object SourceDocLineId { get; set; }

        //[Column("delivery")]
        //public object Delivery { get; set; }

        //[Column("deliveryId")]
        //public object DeliveryId { get; set; }

        //[Column("deliveryLine")]
        //public object DeliveryLine { get; set; }

        //[Column("deliveryLineId")]
        //public object DeliveryLineId { get; set; }

        //[Column("billingRequestId")]
        //public object BillingRequestId { get; set; }

        //[Column("billingRequestLineId")]
        //public object BillingRequestLineId { get; set; }

        [Column("printTaxCodes")]
        public string PrintTaxCodes { get; set; }

        [Column("printAllDiscounts")]
        public string PrintAllDiscounts { get; set; }

        //[Column("commitmentReference")]
        //public object CommitmentReference { get; set; }

        [Column("salesItem")]
        public string SalesItem { get; set; }

        [Column("salesItemId")]
        public string SalesItemId { get; set; }

        [Column("salesItemBaseEntityId")]
        public string SalesItemBaseEntityId { get; set; }

        [Column("salesItemDescription")]
        public string SalesItemDescription { get; set; }

        [Column("unit")]
        public string Unit { get; set; }

        [Column("unitId")]
        public string UnitId { get; set; }

        [Column("unitDescription")]
        public string UnitDescription { get; set; }

        [Column("warehouse")]
        public string Warehouse { get; set; }

        [Column("warehouseId")]
        public string WarehouseId { get; set; }

        [Column("warehouseDescription")]
        public string WarehouseDescription { get; set; }

        //[Column("itemWithholdingTaxSchema")]
        //public object ItemWithholdingTaxSchema { get; set; }

        //[Column("itemWithholdingTaxSchemaId")]
        //public object ItemWithholdingTaxSchemaId { get; set; }

        //[Column("itemWithholdingTaxSchemaDescription")]
        //public object ItemWithholdingTaxSchemaDescription { get; set; }

        [Column("itemTaxSchema")]
        public string ItemTaxSchema { get; set; }

        [Column("itemTaxSchemaId")]
        public string ItemTaxSchemaId { get; set; }

        [Column("itemTaxSchemaDescription")]
        public string ItemTaxSchemaDescription { get; set; }

        //[Column("partyWithholdingTaxSchema")]
        //public object PartyWithholdingTaxSchema { get; set; }

        //[Column("partyWithholdingTaxSchemaId")]
        //public object PartyWithholdingTaxSchemaId { get; set; }

        //[Column("partyWithholdingTaxSchemaDescription")]
        //public object PartyWithholdingTaxSchemaDescription { get; set; }

        [Column("partyTaxSchema")]
        public string PartyTaxSchema { get; set; }

        [Column("partyTaxSchemaId")]
        public string PartyTaxSchemaId { get; set; }

        [Column("partyTaxSchemaDescription")]
        public string PartyTaxSchemaDescription { get; set; }

        [Column("currency")]
        public string Currency { get; set; }

        [Column("currencyId")]
        public string CurrencyId { get; set; }

        [Column("currencyDescription")]
        public string CurrencyDescription { get; set; }

        [Column("documentLineStatus")]
        public int DocumentLineStatus { get; set; }

        [Column("documentLineStatusDescription")]
        public string DocumentLineStatusDescription { get; set; }

        [Column("documentLineWTaxes")]
        public List<object> DocumentLineWTaxes { get; set; }

        //TODO
        //[Column("documentLineTaxes")]
        //public List<DocumentLineTax> DocumentLineTaxes { get; set; }

        //[Column("sourceSchemaEntity")]
        //public object SourceSchemaEntity { get; set; }

        //[Column("sourceSchemaEntityId")]
        //public object SourceSchemaEntityId { get; set; }

        [Column("itemType")]
        public int ItemType { get; set; }

        [Column("itemTypeDescription")]
        public string ItemTypeDescription { get; set; }

        [Column("transactionAccount")]
        public string TransactionAccount { get; set; }

        [Column("transactionAccountId")]
        public string TransactionAccountId { get; set; }

        [Column("transactionAccountDescription")]
        public string TransactionAccountDescription { get; set; }

        [Column("baseCurrencyId")]
        public string BaseCurrencyId { get; set; }

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
}
