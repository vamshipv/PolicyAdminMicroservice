using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using QuoteMicroservice.Models;

#nullable disable

namespace QuoteMicroservice.Models
{
    public partial class PolicyAdminDBContext : DbContext
    {
        public PolicyAdminDBContext()
        {
        }

        public PolicyAdminDBContext(DbContextOptions<PolicyAdminDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Quote> Quotes { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=quotedb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Quote>(entity =>
            {
                entity.HasKey(e => e.Qid)
                    .HasName("PK__Quote__CAB1462B0D3762E3");

                entity.ToTable("Quote");

                entity.Property(e => e.Qid).HasColumnName("QId");

                entity.Property(e => e.PropertyType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.QuoteValue).HasColumnType("decimal(8, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
