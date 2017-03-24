
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using Ataw.RightCloud.Data;

namespace Ataw.RightCloud.DB
{
    // bd_User
    public class Ataw_Role_RightsMap : EntityTypeConfiguration<Ataw_Role_Rights>
    {
        public Ataw_Role_RightsMap(string schema = "dbo")
        {
            ToTable(schema + ".Ataw_Role_Rights");
            HasKey(x => x.RoleRigthID);

            Property(x => x.RoleRigthID).HasColumnName("RoleRigthID").IsRequired().HasMaxLength(50);

             Property(x => x.FControlUnitID).HasColumnName("FControlUnitID").IsOptional();

             Property(x => x.RoleID).HasColumnName("RoleID").IsOptional();

             Property(x => x.RightID).HasColumnName("RightID").IsOptional();

             Property(x => x.FunctionRight).HasColumnName("FunctionRight").IsOptional();

             Property(x => x.UserRight).HasColumnName("UserRight").IsOptional();

             Ignore(x => x.FID);
             Ignore(x => x.CREATE_ID);
             Ignore(x => x.CREATE_TIME);
             Ignore(x => x.UPDATE_ID);
             Ignore(x => x.UPDATE_TIME);
             Ignore(x => x.ISDELETE);
             Ignore(x => x.UDVARCHAR1);
             Ignore(x => x.UDVARCHAR2);
             Ignore(x => x.ISDELETE);
             Ignore(x => x.UDDATETIME);
             Ignore(x => x.UDINT1);


        }
    }

}

