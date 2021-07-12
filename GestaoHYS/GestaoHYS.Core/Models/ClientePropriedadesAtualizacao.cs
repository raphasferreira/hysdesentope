using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GestaoHYS.Core.Models
{
    public abstract class ClientePropriedadesAtualizacao : ClientePropriedadesAtualizacaoSalesCore
    {
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

        [Column("searchTerm")]
        [JsonProperty("searchTerm")]
        public string SearchTerm { get; set; }

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

        [Column("isPerson")]
        [JsonProperty("isPerson")]
        public Boolean IsPerson { get; set; }

        [Column("currency")]
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [Column("country")]
        [JsonProperty("country")]
        public string Country { get; set; }

        [Column("culture")]
        [JsonProperty("culture")]
        public string Culture { get; set; }

  

    }
}
