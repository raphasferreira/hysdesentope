
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoHYS.Core.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Column("Id")]
        [Key]
        [DatabaseGenerated
        (DatabaseGeneratedOption.Identity)]
        [Required]
        public long Id { get; set; }

        [Column("Nome")]
        public string Nome { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        [Column("Senha")]
        public string Senha { get; set; }

        [Column("perfilId")]
        public int PerfilId { get; set; }
        public virtual PerfilUsuario Perfil { get; set; }

    }
}
