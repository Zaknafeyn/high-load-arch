using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DbManipulator.Models
{
    public partial class MariadbtestContext : DbContext
    {
        public MariadbtestContext()
        {
        }

        public MariadbtestContext(DbContextOptions<MariadbtestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Test> Test { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=192.168.2.102;port=3306;user=root;password=admin;database=mariadbtest");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Test>(entity =>
            {
                entity.ToTable("test");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasCharSet(Pomelo.EntityFrameworkCore.MySql.Storage.CharSet.Latin1);

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnType("varchar(500)")
                    .HasCharSet(Pomelo.EntityFrameworkCore.MySql.Storage.CharSet.Latin1);

                entity.Property(e => e.Time)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'current_timestamp()'")
                    .ValueGeneratedOnAddOrUpdate();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
