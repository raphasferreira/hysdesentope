using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GestaoHYS.Core.Models
{
    public abstract class ClientePropriedadesAtualizacaoSalesCore
    {
        

        [Column("customerGroup")]
        [JsonProperty("customerGroup")]
        public string CustomerGroup { get; set; }

        [Column("paymentMethod")]
        [JsonProperty("paymentMethod")]
        public string PaymentMethod { get; set; }

        [Column("paymentTerm")]
        [JsonProperty("paymentTerm")]
        public string PaymentTerm { get; set; }

        [Column("deliveryTerm")]
        [JsonProperty("deliveryTerm")]
        public string DeliveryTerm { get; set; }

        [Column("settlementDiscountPercent")]
        [JsonProperty("settlementDiscountPercent")]
        public double SettlementDiscountPercent { get; set; }

        [Column("partyWithholdingTaxSchema")]
        [JsonProperty("partyWithholdingTaxSchema")]
        public string PartyWithholdingTaxSchema { get; set; }

        [Column("partyTaxSchema")]
        [JsonProperty("partyTaxSchema")]
        public string PartyTaxSchema { get; set; }

        [Column("priceList")]
        [JsonProperty("priceList")]
        public string PriceList { get; set; }

        [Column("oneTimeCustomer")]
        [JsonProperty("oneTimeCustomer")]
        public Boolean OneTimeCustomer { get; set; }

        [Column("endCustomer")]
        [JsonProperty("endCustomer")]
        public Boolean EndCustomer { get; set; }

        [Column("locked")]
        [JsonProperty("locked")]
        public Boolean Locked { get; set; }
    }
}
