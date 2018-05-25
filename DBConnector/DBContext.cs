namespace DBConnector
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<ActivityTable> ActivityTables { get; set; }
        public virtual DbSet<AfdelingTable> AfdelingTables { get; set; }
        public virtual DbSet<DatesTable> DatesTables { get; set; }
        public virtual DbSet<UserTable> UserTables { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActivityTable>()
                .HasMany(e => e.DatesTables)
                .WithRequired(e => e.ActivityTable)
                .HasForeignKey(e => e.ActivityID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AfdelingTable>()
                .HasMany(e => e.UserTables)
                .WithRequired(e => e.AfdelingTable)
                .HasForeignKey(e => e.AfdId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserTable>()
                .HasMany(e => e.ActivityTables)
                .WithRequired(e => e.UserTable)
                .WillCascadeOnDelete(false);
        }
    }
}
