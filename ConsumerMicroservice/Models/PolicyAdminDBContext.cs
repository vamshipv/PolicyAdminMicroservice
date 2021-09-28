using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ConsumerMicroservice.Models
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
//                optionsBuilder.UseSqlServer("Server=VAMSHI\\SQLEXPRESS;Database=PolicyAdminDB;Trusted_Connection=True;");
//            }
//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

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
//                    .HasConstraintName("FK__Business__Busine__2A4B4B5E");

//                entity.HasOne(d => d.Consumer)
//                    .WithMany(p => p.Businesses)
//                    .HasForeignKey(d => d.ConsumerId)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK__Business__Consum__2B3F6F97");
//            });

//            modelBuilder.Entity<BusinessMaster>(entity =>
//            {
//                entity.ToTable("BusinessMaster");
//            });

//            modelBuilder.Entity<Consumer>(entity =>
//            {
//                entity.ToTable("Consumer");

//                entity.Property(e => e.AgentName)
//                    .IsRequired()
//                    .HasMaxLength(100)
//                    .IsUnicode(false);

//                entity.Property(e => e.Dob).HasColumnType("datetime");

//                entity.Property(e => e.Email)
//                    .IsRequired()
//                    .HasMaxLength(100)
//                    .IsUnicode(false);

//                entity.Property(e => e.Name)
//                    .IsRequired()
//                    .HasMaxLength(100)
//                    .IsUnicode(false);

//                entity.Property(e => e.PanNumber)
//                    .IsRequired()
//                    .HasMaxLength(100)
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
//                    .HasConstraintName("FK__Property__Busine__2E1BDC42");

//                entity.HasOne(d => d.PropertyMaster)
//                    .WithMany(p => p.Properties)
//                    .HasForeignKey(d => d.PropertyMasterId)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK__Property__Proper__2F10007B");
//            });

//            modelBuilder.Entity<PropertyMaster>(entity =>
//            {
//                entity.ToTable("PropertyMaster");
//            });

//            OnModelCreatingPartial(modelBuilder);
//        }

//        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
