using System;
using Microsoft.EntityFrameworkCore;

namespace PopulateDb.Models
{
    public partial class hw8Context : DbContext
    {
        private string _connectionString;
        public hw8Context(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public hw8Context(DbContextOptions<hw8Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Test> Test { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(this._connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Test>(entity =>
            {
                entity.ToTable("temp");

                entity.Property(e => e.Id).HasColumnType("int(10) unsigned");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("varchar(30)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
