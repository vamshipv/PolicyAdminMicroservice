using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PolicyMicroservice.Models
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


        public virtual DbSet<Business> Businesses { get; set; }
        public virtual DbSet<BusinessMaster> BusinessMasters { get; set; }
        public virtual DbSet<Consumer> Consumers { get; set; }
        public virtual DbSet<ConsumerPolicy> ConsumerPolicies { get; set; }
        public virtual DbSet<PolicyMaster> PolicyMasters { get; set; }
        public virtual DbSet<Property> Properties { get; set; }
        public virtual DbSet<PropertyMaster> PropertyMasters { get; set; }
        public virtual DbSet<Quote> Quotes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=SATHZZ;Database=PolicyDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Business>(entity =>
            {
                entity.ToTable("Business");

                entity.Property(e => e.BusinessId).ValueGeneratedNever();

                entity.Property(e => e.BusinessName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BusinessType)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.BusinessMaster)
                    .WithMany(p => p.Businesses)
                    .HasForeignKey(d => d.BusinessMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Business__Busine__6FE99F9F");

                entity.HasOne(d => d.Consumer)
                    .WithMany(p => p.Businesses)
                    .HasForeignKey(d => d.ConsumerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Business__Consum__70DDC3D8");
            });

            modelBuilder.Entity<BusinessMaster>(entity =>
            {
                entity.ToTable("BusinessMaster");

                entity.Property(e => e.BusinessMasterId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Consumer>(entity =>
            {
                entity.ToTable("Consumer");

                entity.Property(e => e.ConsumerId).ValueGeneratedNever();

                entity.Property(e => e.AgentName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Dob).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PanNumber)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ConsumerPolicy>(entity =>
            {
                entity.HasKey(e => e.PolicyId)
                    .HasName("PK__Consumer__2E1339A4F7A35C02");

                entity.ToTable("ConsumerPolicy");

                entity.Property(e => e.PolicyStatus)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.QuoteId).HasColumnName("QuoteID");

                entity.HasOne(d => d.PolicyMaster)
                    .WithMany(p => p.ConsumerPolicies)
                    .HasForeignKey(d => d.PolicyMasterid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ConsumerP__Polic__05D8E0BE");

                entity.HasOne(d => d.Property)
                    .WithMany(p => p.ConsumerPolicies)
                    .HasForeignKey(d => d.PropertyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ConsumerP__Prope__03F0984C");

                entity.HasOne(d => d.Quote)
                    .WithMany(p => p.ConsumerPolicies)
                    .HasForeignKey(d => d.QuoteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ConsumerP__Quote__04E4BC85");
            });

            modelBuilder.Entity<PolicyMaster>(entity =>
            {
                entity.HasKey(e => e.Pmid)
                    .HasName("PK__PolicyMa__5C86FF4661C44D0E");

                entity.ToTable("PolicyMaster");

                entity.Property(e => e.Pmid).HasColumnName("PMId");

                entity.Property(e => e.AssuredSum).HasColumnType("decimal(10, 3)");

                entity.Property(e => e.BaseLocation)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ConsumerType)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PropertyType)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Ptype)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PType");
            });

            modelBuilder.Entity<Property>(entity =>
            {
                entity.ToTable("Property");

                entity.Property(e => e.PropertyId).ValueGeneratedNever();

                entity.Property(e => e.BuildingType)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Business)
                    .WithMany(p => p.Properties)
                    .HasForeignKey(d => d.BusinessId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Property__Busine__73BA3083");

                entity.HasOne(d => d.PropertyMaster)
                    .WithMany(p => p.Properties)
                    .HasForeignKey(d => d.PropertyMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Property__Proper__74AE54BC");
            });

            modelBuilder.Entity<PropertyMaster>(entity =>
            {
                entity.ToTable("PropertyMaster");

                entity.Property(e => e.PropertyMasterId).ValueGeneratedNever();
            });

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
