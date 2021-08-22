using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GestaoHYS.Core.Models
{
    public class Pagamentos
    {
        [Column("IdPagamento")]
        [Key]
        [DatabaseGenerated
        (DatabaseGeneratedOption.Identity)]
        [Required]
        public long IdPagamento { get; set; }
        public DateTime DataPagamento { get; set; }

        public long TitulosId { get; set; }
        public virtual Titulos Titulos { get; set; }
        public double ValorPagamento { get; set; }

    }
}
