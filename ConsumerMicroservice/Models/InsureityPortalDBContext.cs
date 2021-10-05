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

    }
}
