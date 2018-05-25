namespace DatabaseConnector
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DatesTable")]
    public partial class DatesTable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int ActivityID { get; set; }

        public DateTimeOffset DatesTimeOffset { get; set; }

        public virtual ActivityTable ActivityTable { get; set; }
    }
}
