using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoHYS.Core.Models
{
    public class SalesChannelLine
    {
        //[Column("version")]
        //public List<int> Version { get; set; }

        [Column("versionByte")]
        public string VersionByte { get; set; }

        [Column("salesItemId")]
        public string SalesItemId { get; set; }

        [Column("selected")]
        public bool Selected { get; set; }

        [Column("salesChannel")]
        public string SalesChannel { get; set; }

        [Column("salesChannelId")]
        public string SalesChannelId { get; set; }

        [Column("salesChannelDescription")]
        public string SalesChannelDescription { get; set; }

        [Column("index")]
        public int Index { get; set; }

        [Column("id")]
        public string Id { get; set; }

        [Column("isActive")]
        public bool IsActive { get; set; }

        [Column("isDeleted")]
        public bool IsDeleted { get; set; }

        [Column("isSystem")]
        public bool IsSystem { get; set; }

        [Column("createdBy")]
        public string CreatedBy { get; set; }

        [Column("createdOn")]
        public DateTime CreatedOn { get; set; }

        [Column("modifiedBy")]
        public string ModifiedBy { get; set; }

        [Column("modifiedOn")]
        public DateTime ModifiedOn { get; set; }

        [Column("draftId")]
        public string DraftId { get; set; }

        //[Column("subscriptionId")]
        //public object SubscriptionId { get; set; }

        [Column("_state")]
        public int State { get; set; }
    }

}
