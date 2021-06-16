
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoHYS.Core.Models
{
    [Table("Empresa")]
    public class Empresa
    {
        [Column("Id")]
        [Key]
        [DatabaseGenerated
        (DatabaseGeneratedOption.Identity)]
        [Required]
        public long Id { get; set; }

        [Column("Nome")]
        public string Nome { get; set; }
        [Column("Nipc")]
        public string Nipc { get; set; }
        [Column("Endereco")]
        public string Endereco { get; set; }
        [Column("RazaoSocial")]
        public string RazaoSocial { get; set; }
        [Column("Contato")]
        public string Contato { get; set; }
        [Column("Email")]
        public string Email { get; set; }
        [Column("DsServico")]
        public string DsServico { get; set; }
        [Column("IsDelete")]
        public bool IsDeleted { get; set; }
    }
}
