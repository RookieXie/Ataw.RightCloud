
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using Ataw.RightCloud.Data;

namespace Ataw.RightCloud.DB
{
    // bd_User
    public class Ataw_GruopMap : EntityTypeConfiguration<Ataw_Gruop>
    {
        public Ataw_GruopMap(string schema = "dbo")
        {
            ToTable(schema + ".Ataw_Gruop");
            HasKey(x => x.GroupID);
            
             Property(x => x.IsParent).HasColumnName("IsParent").IsOptional();

             //Property(x => x.GroupID).HasColumnName("GroupID");

             Property(x => x.FParentFID).HasColumnName("FParentFID").IsOptional();

             Property(x => x.GroupName).HasColumnName("GroupName").IsOptional();

             Property(x => x.GroupCode).HasColumnName("GroupCode").IsOptional();

             Property(x => x.GroupDescrible).HasColumnName("GroupDescrible").IsOptional();

             Property(x => x.FAddress).HasColumnName("FAddress").IsOptional();

             Property(x => x.ProductFIDs).HasColumnName("ProductFIDs").IsOptional();

             Property(x => x.FPhone).HasColumnName("FPhone").IsOptional();

             Property(x => x.Fax).HasColumnName("Fax").IsOptional();

             Property(x => x.Post).HasColumnName("Post").IsOptional();

             Property(x => x.FCreateUser).HasColumnName("FCreateUser").IsOptional();

             Property(x => x.FCreateTime).HasColumnName("FCreateTime").IsOptional();

             Ignore(a=>a.FID);


        }
    }

}

