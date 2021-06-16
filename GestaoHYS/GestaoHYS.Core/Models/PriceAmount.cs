using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoHYS.Core.Models
{
    public class PriceAmount
    {
        [Column("amount")]
        public double Amount { get; set; }

        //[Column("baseAmount")]
        //public object BaseAmount { get; set; }

        [Column("reportingAmount")]
        public double ReportingAmount { get; set; }

        [Column("fractionDigits")]
        public int FractionDigits { get; set; }

        [Column("symbol")]
        public string Symbol { get; set; }
    }

}
