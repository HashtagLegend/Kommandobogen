namespace NewDBConnector
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DateTable")]
    public partial class DateTable
    {
        [StringLength(50)]
        public string Id { get; set; }

        [Required]
        [StringLength(100)]
        public string DatesTimeOffset { get; set; }

        [Required]
        [StringLength(50)]
        public string ActivityID { get; set; }

        public virtual ActivityTable ActivityTable { get; set; }
    }
}
