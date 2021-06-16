
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoHYS.Core.Models
{
    [Table("Parceiro")]
    public class Parceiro
    {
        [Column("Id")]
        [Key]
        [DatabaseGenerated
        (DatabaseGeneratedOption.Identity)]
        [Required]
        public long Id { get; set; }

        [Column("Nome")]
        public string Nome { get; set; }
        [Column("Nif")]
        public string Nif { get; set; }
        [Column("Endereco")]
        public string Endereco { get; set; }
        [Column("DtNascimento")]
        public DateTime DtNascimento { get; set; }
        [Column("Telefone")]
        public string Telefone { get; set; }
        [Column("Email")]
        public string Email { get; set; }
        [Column("DsServico")]
        public string DsServico { get; set; }
        [Column("ParceiroPaisId")]
        public long ParceiroPaisId { get; set; }
        public ParceiroPais ParceiroPais { get; set; }
        [Column("IsDelete")]
        public bool IsDeleted { get; set; }
    }
}
