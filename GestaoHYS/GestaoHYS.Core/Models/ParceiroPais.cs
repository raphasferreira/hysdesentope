
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoHYS.Core.Models
{
    [Table("ParceiroPais")]
    public class ParceiroPais
    {
        [Column("Id")]
        [Key]
        [DatabaseGenerated
        (DatabaseGeneratedOption.Identity)]
        [Required]
        public long Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }
        [Column("Alpha2Code")]
        public string Alpha2Code { get; set; }
        [Column("Alpha3Code")]
        public string Alpha3Code { get; set; }
        [Column("NumericCode")]
        public string NumericCode { get; set; }
    }
}
