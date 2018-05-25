namespace PersistencyConsoleTest
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ActivityTable")]
    public partial class ActivityTable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Navn { get; set; }

        [Required]
        [StringLength(50)]
        public string Kommentar { get; set; }

        [Required]
        [StringLength(50)]
        public string MaNummer { get; set; }

        public TimeSpan TimeStart { get; set; }

        public TimeSpan TimeEnd { get; set; }

        [Required]
        [StringLength(50)]
        public string Color { get; set; }

        public virtual UserTable UserTable { get; set; }

        public virtual DatesTable DatesTable { get; set; }
    }
}
