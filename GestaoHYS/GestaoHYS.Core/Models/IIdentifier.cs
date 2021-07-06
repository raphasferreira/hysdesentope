using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GestaoHYS.Core.Models
{
    public class IIdentifier
    {
        [Column("Id")]
        [Key]
        [DatabaseGenerated
        (DatabaseGeneratedOption.Identity)]
        [Required]
        [JsonProperty("idBaseLocal")]

        public long Id { get; set; }
    }
}
