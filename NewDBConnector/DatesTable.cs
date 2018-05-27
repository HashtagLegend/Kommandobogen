namespace NewDBConnector
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DatesTable")]
    public partial class DatesTable
    {
        [StringLength(50)]
        public string Id { get; set; }

        [Required]
        [StringLength(100)]
        public string DatesTimeOffset { get; set; }

        [Required]
        [StringLength(50)]
        public string ActivityID { get; set; }
    }
}
