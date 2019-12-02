using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PopulateDb.Models
{
    public partial class hw8Context : DbContext
    {
        public hw8Context()
        {
        }

        public hw8Context(DbContextOptions<hw8Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Innodb> Innodb { get; set; }
        public virtual DbSet<Myisam> Myisam { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Innodb>(entity =>
            {
                entity.ToTable("innodb");

                entity.HasIndex(e => e.BirthDate)
                    .HasName("BirthDateHash");

                entity.HasIndex(e => e.BirthDay)
                    .HasName("BirthDayHash");

                entity.HasIndex(e => e.BirthMonth)
                    .HasName("BirthMonthHash");

                entity.HasIndex(e => e.BirthYear)
                    .HasName("BirthYearHash");

                entity.Property(e => e.Id).HasColumnType("int(10) unsigned");

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.BirthDay).HasColumnType("int(11)");

                entity.Property(e => e.BirthMonth).HasColumnType("int(11)");

                entity.Property(e => e.BirthYear).HasColumnType("int(11)");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("varchar(30)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnType("varchar(17)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.SecondName)
                    .IsRequired()
                    .HasColumnType("varchar(30)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<Myisam>(entity =>
            {
                entity.ToTable("myisam");

                entity.HasIndex(e => e.BirthDate)
                    .HasName("BirthDateHash");

                entity.HasIndex(e => e.BirthDay)
                    .HasName("BirthDayHash");

                entity.HasIndex(e => e.BirthMonth)
                    .HasName("BirthMonthHash");

                entity.HasIndex(e => e.BirthYear)
                    .HasName("BirthYearHash");

                entity.Property(e => e.Id).HasColumnType("int(10) unsigned");

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.BirthDay).HasColumnType("int(11)");

                entity.Property(e => e.BirthMonth).HasColumnType("int(11)");

                entity.Property(e => e.BirthYear).HasColumnType("int(11)");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("varchar(30)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnType("varchar(17)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.SecondName)
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
