namespace WebService
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataBaseContext : DbContext
    {
        public DataBaseContext()
            : base("name=DataBaseContext")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<ActivityTable> ActivityTable { get; set; }
        public virtual DbSet<AfdelingTable> AfdelingTable { get; set; }
        public virtual DbSet<DatesTable> DatesTable { get; set; }
        public virtual DbSet<UserTable> UserTable { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActivityTable>()
                .HasOptional(e => e.DatesTable)
                .WithRequired(e => e.ActivityTable);

            modelBuilder.Entity<AfdelingTable>()
                .HasMany(e => e.UserTable)
                .WithRequired(e => e.AfdelingTable)
                .HasForeignKey(e => e.AfdId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserTable>()
                .HasMany(e => e.ActivityTable)
                .WithRequired(e => e.UserTable)
                .WillCascadeOnDelete(false);
        }
    }
}
