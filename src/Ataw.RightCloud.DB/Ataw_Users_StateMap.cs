
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using Ataw.RightCloud.Data;

namespace Ataw.RightCloud.DB
{
    // bd_User
    public class Ataw_Users_StateMap : EntityTypeConfiguration<Ataw_Users_State>
    {
        public Ataw_Users_StateMap(string schema = "dbo")
        {
            ToTable(schema + ".Ataw_Users_State");
            HasKey(x => x.ID);

            Property(x => x.ID).HasColumnName("ID").IsRequired().HasMaxLength(50);

            Property(x => x.UserID).HasColumnName("UserID").IsOptional();

            Property(x => x.IsOnline).HasColumnName("IsOnline").IsOptional();

            Property(x => x.IP).HasColumnName("IP").IsOptional();

            Property(x => x.Mac).HasColumnName("Mac").IsOptional();

            Property(x => x.LifeStart).HasColumnName("LifeStart").IsOptional();

            Property(x => x.LifeEnd).HasColumnName("LifeEnd").IsOptional();

            Ignore(x => x.FID);
            Ignore(x => x.CREATE_ID);
            Ignore(x => x.CREATE_TIME);
            Ignore(x => x.UPDATE_ID);
            Ignore(x => x.UPDATE_TIME);
            Ignore(x => x.ISDELETE);
            Ignore(x => x.UDVARCHAR1);
            Ignore(x => x.UDVARCHAR2);
            Ignore(x => x.UDINT1);
            Ignore(x => x.UDDATETIME);
        }
    }

}

