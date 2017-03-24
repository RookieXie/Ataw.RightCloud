
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using Ataw.RightCloud.Data;

namespace Ataw.RightCloud.DB
{
    // bd_User
    public class Ataw_UsersMap : EntityTypeConfiguration<Ataw_Users>
    {
        public Ataw_UsersMap(string schema = "dbo")
        {
            ToTable(schema + ".Ataw_Users");
            HasKey(x => x.UserID);

             this.Ignore(a=>a.FID);
             Property(x => x.UserID).HasColumnName("UserID");

             Property(x => x.NickName).HasColumnName("NickName").IsOptional();

             Property(x => x.UserName).HasColumnName("UserName").IsOptional();

             Property(x => x.Password).HasColumnName("Password").IsOptional();

             Property(x => x.Area).HasColumnName("Area").IsOptional();

             Property(x => x.UserType).HasColumnName("UserType").IsOptional();

             Property(x => x.IsActive).HasColumnName("IsActive").IsOptional();

             Property(x => x.CreateTime).HasColumnName("CreateTime").IsOptional();

             Property(x => x.Creater).HasColumnName("Creater").IsOptional();

             Property(x => x.Remark).HasColumnName("Remark").IsOptional();

             Property(x => x.MEID).HasColumnName("MEID").IsOptional();

             Property(x => x.FControlUnitID).HasColumnName("FControlUnitID").IsOptional();

             Property(x => x.UserConfig).HasColumnName("UserConfig").IsOptional();


        }
    }

}

