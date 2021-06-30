
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoHYS.Core.Models
{
    [Table("Endereco")]
    public class Endereco
    {
        [Column("Id")]
        [Key]
        [DatabaseGenerated
        (DatabaseGeneratedOption.Identity)]
        [Required]
        public long Id { get; set; }

        [Column("Rua")]
        public string Rua { get; set; }

        [Column("Numero")]
        public string Numero { get; set; }
        [Column("CodigoPostal")]
        public string CodigoPostal { get; set; }

        [Column("Localidade")]
        public string Localidade { get; set; }

        [Column("Titulo")]
        public string Titulo { get; set; }

        [Column("Contato")]
        public string Contato { get; set; }




    }
}
