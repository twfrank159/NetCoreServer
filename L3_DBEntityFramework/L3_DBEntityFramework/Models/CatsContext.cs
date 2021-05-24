using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace L3_DBEntityFramework.Models
{
    public partial class CatsContext : DbContext
    {
        public CatsContext()
        {
        }

        public CatsContext(DbContextOptions<CatsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cat> Cats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3306;database=test;user=user;password=user", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.34-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            modelBuilder.Entity<Cat>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.Cute).HasColumnName("cute");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
