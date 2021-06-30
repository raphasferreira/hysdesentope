using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GestaoHYS.Core.Models
{
    public class Contato
    {
        [Column("Id")]
        [Key]
        [DatabaseGenerated
        (DatabaseGeneratedOption.Identity)]
        [Required]
        public long Id { get; set; }

        [Column("Telefone")]
        public string Telefone { get; set; }
        [Column("Email")]
        public string Email { get; set; }
        [Column("Telemovel")]
        public string Telemovel { get; set; }
        [Column("WebSite")]
        public string WebSite { get; set; }


    }
}
