using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ConsumerMicroservice.Models
{
    public partial class InsureityPortalDBContext : DbContext
    {
        public InsureityPortalDBContext()
        {
        }

        public InsureityPortalDBContext(DbContextOptions<InsureityPortalDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Business> Business { get; set; }
        public virtual DbSet<BusinessMaster> BusinessMaster { get; set; }
        public virtual DbSet<Consumer> Consumer { get; set; }
        public virtual DbSet<Property> Property { get; set; }
        public virtual DbSet<PropertyMaster> PropertyMaster { get; set; }

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //                optionsBuilder.UseSqlServer("Server=VAMSHI\\SQLEXPRESS;Database=InsureityPortalDB;Trusted_Connection=True;");
        //            }
        //        }

        //        protected override void OnModelCreating(ModelBuilder modelBuilder)
        //        {
        //            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

        //            modelBuilder.Entity<Agent>(entity =>
        //            {
        //                entity.ToTable("Agent");

        //                entity.Property(e => e.AgentName)
        //                    .IsRequired()
        //                    .HasMaxLength(100)
        //                    .IsUnicode(false);

        //                entity.Property(e => e.Password)
        //                    .IsRequired()
        //                    .HasMaxLength(100)
        //                    .IsUnicode(false);
        //            });

        //            modelBuilder.Entity<Business>(entity =>
        //            {
        //                entity.ToTable("Business");

        //                entity.Property(e => e.BusinessName)
        //                    .IsRequired()
        //                    .HasMaxLength(100)
        //                    .IsUnicode(false);

        //                entity.Property(e => e.BusinessType)
        //                    .IsRequired()
        //                    .HasMaxLength(100)
        //                    .IsUnicode(false);

        //                entity.HasOne(d => d.BusinessMaster)
        //                    .WithMany(p => p.Businesses)
        //                    .HasForeignKey(d => d.BusinessMasterId)
        //                    .OnDelete(DeleteBehavior.ClientSetNull)
        //                    .HasConstraintName("FK__Business__Busine__2D27B809");

        //                entity.HasOne(d => d.Consumer)
        //                    .WithMany(p => p.Businesses)
        //                    .HasForeignKey(d => d.ConsumerId)
        //                    .OnDelete(DeleteBehavior.ClientSetNull)
        //                    .HasConstraintName("FK__Business__Consum__2E1BDC42");
        //            });

        //            modelBuilder.Entity<BusinessMaster>(entity =>
        //            {
        //                entity.ToTable("BusinessMaster");
        //            });

        //            modelBuilder.Entity<Consumer>(entity =>
        //            {
        //                entity.ToTable("Consumer");

        //                entity.Property(e => e.ConsumerName)
        //                    .IsRequired()
        //                    .HasMaxLength(100)
        //                    .IsUnicode(false);

        //                entity.Property(e => e.DateOfBirth).HasColumnType("date");

        //                entity.Property(e => e.Email)
        //                    .IsRequired()
        //                    .HasMaxLength(100)
        //                    .IsUnicode(false);

        //                entity.Property(e => e.PanNumber)
        //                    .IsRequired()
        //                    .HasMaxLength(100)
        //                    .IsUnicode(false);

        //                entity.HasOne(d => d.Agent)
        //                    .WithMany(p => p.Consumers)
        //                    .HasForeignKey(d => d.AgentId)
        //                    .OnDelete(DeleteBehavior.ClientSetNull)
        //                    .HasConstraintName("FK__Consumer__AgentI__267ABA7A");
        //            });

        //            modelBuilder.Entity<ConsumerPolicy>(entity =>
        //            {
        //                entity.HasKey(e => e.PolicyId)
        //                    .HasName("PK__Consumer__2E1339A49599273E");

        //                entity.ToTable("ConsumerPolicy");

        //                entity.Property(e => e.PolicyStatus)
        //                    .IsRequired()
        //                    .HasMaxLength(255)
        //                    .IsUnicode(false);

        //                entity.HasOne(d => d.PolicyMaster)
        //                    .WithMany(p => p.ConsumerPolicies)
        //                    .HasForeignKey(d => d.PolicyMasterId)
        //                    .OnDelete(DeleteBehavior.ClientSetNull)
        //                    .HasConstraintName("FK__ConsumerP__Polic__49C3F6B7");

        //                entity.HasOne(d => d.Property)
        //                    .WithMany(p => p.ConsumerPolicies)
        //                    .HasForeignKey(d => d.PropertyId)
        //                    .OnDelete(DeleteBehavior.ClientSetNull)
        //                    .HasConstraintName("FK__ConsumerP__Prope__47DBAE45");

        //                entity.HasOne(d => d.Quote)
        //                    .WithMany(p => p.ConsumerPolicies)
        //                    .HasForeignKey(d => d.QuoteId)
        //                    .OnDelete(DeleteBehavior.ClientSetNull)
        //                    .HasConstraintName("FK__ConsumerP__Quote__48CFD27E");
        //            });

        //            modelBuilder.Entity<PolicyMaster>(entity =>
        //            {
        //                entity.HasKey(e => e.PropertyMasterId)
        //                    .HasName("PK__PolicyMa__2B2E4F001B6680A7");

        //                entity.ToTable("PolicyMaster");

        //                entity.Property(e => e.AssuredSum).HasColumnType("decimal(10, 3)");

        //                entity.Property(e => e.BaseLocation)
        //                    .IsRequired()
        //                    .HasMaxLength(255)
        //                    .IsUnicode(false);

        //                entity.Property(e => e.ConsumerType)
        //                    .IsRequired()
        //                    .HasMaxLength(255)
        //                    .IsUnicode(false);

        //                entity.Property(e => e.PolicyType)
        //                    .IsRequired()
        //                    .HasMaxLength(255)
        //                    .IsUnicode(false);

        //                entity.Property(e => e.PropertyType)
        //                    .IsRequired()
        //                    .HasMaxLength(255)
        //                    .IsUnicode(false);
        //            });

        //            modelBuilder.Entity<Property>(entity =>
        //            {
        //                entity.ToTable("Property");

        //                entity.Property(e => e.BuildingType)
        //                    .IsRequired()
        //                    .HasMaxLength(100)
        //                    .IsUnicode(false);

        //                entity.HasOne(d => d.Business)
        //                    .WithMany(p => p.Properties)
        //                    .HasForeignKey(d => d.BusinessId)
        //                    .OnDelete(DeleteBehavior.ClientSetNull)
        //                    .HasConstraintName("FK__Property__Busine__440B1D61");

        //                entity.HasOne(d => d.PropertyMaster)
        //                    .WithMany(p => p.Properties)
        //                    .HasForeignKey(d => d.PropertyMasterId)
        //                    .OnDelete(DeleteBehavior.ClientSetNull)
        //                    .HasConstraintName("FK__Property__Proper__44FF419A");
        //            });

        //            modelBuilder.Entity<PropertyMaster>(entity =>
        //            {
        //                entity.ToTable("PropertyMaster");
        //            });

        //            modelBuilder.Entity<Quote>(entity =>
        //            {
        //                entity.ToTable("Quote");

        //                entity.Property(e => e.PropertyType)
        //                    .IsRequired()
        //                    .HasMaxLength(50)
        //                    .IsUnicode(false);

        //                entity.Property(e => e.QuoteValue).HasColumnType("decimal(8, 2)");
        //            });

        //            OnModelCreatingPartial(modelBuilder);
        //        }

        //        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
