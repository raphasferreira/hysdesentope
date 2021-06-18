using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GestaoHYS.Core.Models
{
    [Table("PerfilUsuario")]
    public class PerfilUsuario
    {
        public PerfilUsuario()
        {
           
        }

        [Column("id")]
        [Key]
        [DatabaseGenerated
        (DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

       
    }
}
