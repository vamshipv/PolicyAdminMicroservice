using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AuthorizationMicroservice.Models
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

        public virtual DbSet<Agent> Agent { get; set; }

//        protected override void onconfiguring(dbcontextoptionsbuilder optionsbuilder)
//        {
//            if (!optionsbuilder.isconfigured)
//            {
//#warning to protect potentially sensitive information in your connection string, you should move it out of source code. you can avoid scaffolding the connection string by using the name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. for more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?linkid=723263.
//                optionsbuilder.usesqlserver("server=vamshi\\sqlexpress;database=insureityportaldb;trusted_connection=true;");
//            }
//        }

//        protected override void onmodelcreating(modelbuilder modelbuilder)
//        {
//            modelbuilder.hasannotation("relational:collation", "sql_latin1_general_cp1_ci_as");

//            modelbuilder.entity<agent>(entity =>
//            {
//                entity.totable("agent");

//                entity.property(e => e.agentname)
//                    .isrequired()
//                    .hasmaxlength(100)
//                    .isunicode(false);

//                entity.property(e => e.password)
//                    .isrequired()
//                    .hasmaxlength(100)
//                    .isunicode(false);
//            });

//            OnModelCreatingPartial(modelBuilder);
//        }

//        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
