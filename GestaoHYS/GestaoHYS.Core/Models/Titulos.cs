using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GestaoHYS.Core.Models
{
    public class Titulos
    {
        [Column("IdTitulos")]
        [Key]
        [DatabaseGenerated
        (DatabaseGeneratedOption.Identity)]
        [Required]
        public long IdTitulos { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataVencimento { get; set; }
        public double ValorTotal { get; set; }
        public long SalesInvoiceId { get; set; }
        public SalesInvoice SalesInvoice { get; set; }
        public string ReferenciaSalesInvoice { get; set; }
        public StatusTitulo StatusTitulo { get; set; }
        public virtual List<Pagamentos> Pagamentos { get;set; }
    }

    public enum StatusTitulo
    {
        Pendente = 1,
        Liquidado = 2

    }
}
