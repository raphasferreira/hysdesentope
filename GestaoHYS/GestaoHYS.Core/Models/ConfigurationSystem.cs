using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GestaoHYS.Core.Models
{
    [Table("ConfigurationSystem")]
    public class ConfigurationSystem
    {
        [Column("Id")]
        [Key]
        [DatabaseGenerated
        (DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [Column("BaseAppUrl")]
        public  string BaseAppUrl { get; set; }

        [Column("AccountKey")]
        public  string AccountKey { get; set; }

        [Column("SubscriptionKey")]
        public  string SubscriptionKey { get; set; }

        [Column("ClientId")]
        public  string ClientId { get; set; }

        [Column("ClientSecret")]
        public  string ClientSecret { get; set; }

        [Column("DefaultCulture")]
        public  string DefaultCulture { get; set; }

        [Column("BaseAccessTokenUriKey")]
        public  string BaseAccessTokenUriKey { get; set; }

        [Column("TokenUriKey")]
        public  string TokenUriKey { get; set; }

        [Column("ApplicationScopes")]
        public  string ApplicationScopes { get; set; }


    }
}
