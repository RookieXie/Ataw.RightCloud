using Ataw.Framework.Web;
using Ataw.RightCloud.DA;
using Ataw.RightCloud.Data.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.BF
{
    public class BFXP_WebSite : RightCloudBaseBF
    {
        public string DeleteFile(string fid)
        {
            DAXP_Folder_Tree da = new DAXP_Folder_Tree(UnitOfData);
            var model = da.GetByKey(fid);
            if (model != null)
            {
                model.ISDELETE = true;
                da.Update(model);
            }
            return model.FID;
        
        }

        public string NewFile(string PID, string Name)
        {
            DAXP_Folder_Tree da = new DAXP_Folder_Tree(UnitOfData);
            XP_Folder_Tree modle = new XP_Folder_Tree();
            modle.FID = UnitOfData.GetUniId();
            modle.F_Name = Name;
            modle.IS_PARENT = false;
            modle.PID = PID;
            modle.FControlUnitID = GlobalVariable.FControlUnitID;
            modle.F_UserID = GlobalVariable.UserFID;

            da.Add(modle);

            return modle.FID;

        }


    }
}
