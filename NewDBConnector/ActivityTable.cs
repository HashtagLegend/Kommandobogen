namespace NewDBConnector
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ActivityTable")]
    public partial class ActivityTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ActivityTable()
        {
            DateTable = new HashSet<DateTable>();
        }

        [StringLength(50)]
        public string ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Navn { get; set; }

        [Required]
        [StringLength(50)]
        public string Kommentar { get; set; }

        [Required]
        [StringLength(50)]
        public string MaNummer { get; set; }

        [Required]
        [StringLength(50)]
        public string TimeStart { get; set; }

        [Required]
        [StringLength(50)]
        public string TimeEnd { get; set; }

        [Required]
        [StringLength(50)]
        public string Color { get; set; }

        public virtual UserTable UserTable { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DateTable> DateTable { get; set; }
    }
}
