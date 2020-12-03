using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebApplication1.Models
{
    public partial class PayScaleDbContext : DbContext
    {
        public PayScaleDbContext()
        {
        }

        public PayScaleDbContext(DbContextOptions<PayScaleDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Payscale> Payscales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=LAPTOP-QDJ4SJPA;database=PayScaleDb;trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payscale>(entity =>
            {
                entity.HasKey(e => e.PayBand)
                    .HasName("PK__payscale__66B0F53F541FE169");

                entity.ToTable("payscale");

                entity.Property(e => e.PayBand).HasMaxLength(50);

                entity.Property(e => e.Da)
                    .HasColumnName("DA")
                    .HasComputedColumnSql("((0.05)*[BasicSalary])", true);

                entity.Property(e => e.Hra)
                    .HasColumnName("HRA")
                    .HasComputedColumnSql("((0.1)*[BasicSalary])", true);

                entity.Property(e => e.InHandSalary).HasComputedColumnSql("((1.01)*[BasicSalary])", true);

                entity.Property(e => e.NetSalary).HasComputedColumnSql("((1.11)*[Basicsalary])", true);

                entity.Property(e => e.Ta)
                    .HasColumnName("TA")
                    .HasComputedColumnSql("((0.05)*[BasicSalary])", true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
