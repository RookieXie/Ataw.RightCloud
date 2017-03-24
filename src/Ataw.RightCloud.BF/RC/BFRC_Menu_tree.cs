
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ataw.Framework.Core;
using Ataw.RightCloud.DA;
using Ataw.RightCloud.DB;
using Ataw.RightCloud.Api.Data;
using Ataw.Framework.Web;
using System.Data;
using System.Data.SqlClient;
using Ataw.RightCloud.Data;

namespace Ataw.RightCloud.BF
{
    public class BFRC_Menu_tree : RightCloudBaseBF
    {
        /// <summary>
        ///  1,初始化菜单 权限
        /// </summary>
        /// <param name="PId">父级菜单ID 第一次默认为0</param>
        /// <param name="Group">当前组织，为空默认为1</param>
        /// <returns></returns>
        public RCRightMenuData initRCMenuData(string parentId, string Group)
        {
            if (Group.IsAkEmpty())
            {
                Group = "1";
            }
            var dd = GetMenuByParentId(parentId, Group);
            return dd;
        }
        //获取菜单子节点  循环调用
        public RCRightMenuData GetMenuByParentId(string PartId, string Group)
        {
            RCRightMenuData root = new RCRightMenuData();
            DARC_Menu_tree _da = new DARC_Menu_tree(this.UnitOfData);
            //将父节点先装起来
            string unitID = "";
            //string strWhere = "";
            DataTable rightList = new DataTable();
            rightList.Columns.Add("fid");
            rightList.Columns.Add("name");
            rightList.Columns.Add("pid");
            rightList.Columns.Add("TREEORDER");
            //Right.Api.IRCRole _coreGroup = "RCRole".CodePlugIn<Right.Api.IRCRole>();

            if (!GlobalVariable.IsAtawSuperUser)
            {
                unitID = GlobalVariable.FControlUnitID;
                var list=_da.QueryDefault(a => a.FControlUnitID == unitID).ToList();
                foreach (var item in list)
                {
                    DataRow dr = rightList.NewRow();
                    dr["fid"] = item.FID;
                    dr["name"] = item.RCM_Name;
                    dr["pid"] = item.PID;
                    dr["TREEORDER"] = item.TREEORDER;
                    rightList.Rows.Add(dr);
                }
                //strWhere = "where RCMG_MenuFID in (select distinct MenuFID from View_RC_MenuRoleRight where FControlUnitID = '" + unitID + "')";

                //// and ParentID='" + PartId + "'
                //rightList = _coreGroup.InitRightsTree_Send(strWhere, unitID);
            }
            else
            {
                var list=_da.QueryDefault(a => 1==1).ToList();                
                foreach (var item in list)
                {
                    DataRow dr = rightList.NewRow();
                    dr["fid"] = item.FID;
                    dr["name"] = item.RCM_Name;
                    dr["pid"] = item.PID;
                    dr["TREEORDER"] = item.TREEORDER;
                    rightList.Rows.Add(dr);
                }
                //rightList = _coreGroup.GetMenusTree();
            }

            DataView dv = rightList.DefaultView;
            dv.Sort = "TREEORDER asc";
            rightList = dv.ToTable();

            if (!GlobalVariable.IsAtawSuperUser)
            {
                this.tranFormRigth(root, rightList);
            }
            else
            {
                //管理员
                this.tranFormRigth(root, rightList);
            }

            return root;
        }


        private void tranFormRigth(RCRightMenuData root, DataTable rightList)
        {
            if (rightList.Rows.Count != 0)
            {
                if (root.FID.IsAkEmpty())//是最开始的节点
                {
                    root.FID = "0";
                }

                DARC_Menu_tree _da = new DARC_Menu_tree(this.UnitOfData);
                List<RCRightMenuData> list = new List<RCRightMenuData>();
                List<RCRightMenuButton> buttonList = new List<RCRightMenuButton>();
                for (int i = 0; i < rightList.Rows.Count; i++)
                {
                    if (rightList.Rows[i]["pid"].ToString() == root.FID)
                    {
                        RCRightMenuData model = new RCRightMenuData();
                        CopyRightforDataRow(rightList.Rows[i], model, _da);
                        if (ishasChildDataTable(model, rightList))
                        {
                            model.isParent = true;
                            model.isLeaft = false;
                            this.tranFormRigth(model, rightList);
                        }
                        else
                        {
                            if (model.isButton == true)
                            {
                                model.isParent = true;
                                model.isLeaft = false;
                            }else
                            {
                                model.isParent = false;
                                model.isLeaft = true;
                            }
                           
                        }
                        //if (model.isButton == true)
                        //{

                            
                        //    foreach (var item in btns.RCMenu_button)
                        //    {
                        //        RCRightMenuButton mbModel = new RCRightMenuButton();
                        //        mbModel.ButtonName = item.CN_Name;
                        //        mbModel.ButtonValue = item.EG_Name;
                        //        buttonList.Add(mbModel);
                        //    }


                            //mbModel.FID = model.FID;

                        //}

                        list.Add(model);



                    }
                    root.Children = list.Count > 0 ? list : null; ;
                    //root.ButtonList = buttonList.Count > 0 ? buttonList : null;
                }

            }
        }

        private void CopyRightforDataRow(DataRow dataRow, RCRightMenuData model, DARC_Menu_tree da)
        {
            model.FID = dataRow["fid"].ToString();
            model.IsHidden = true;
            //model.isParent = this.haschild(dataRow["id"].ToString(), dataRow["rightvalue"].ToString());
            model.MenuName = dataRow["name"].ToString();
            //需要写个方法
            string fid = model.FID;
            string rightvalue = "";
            var menumodel = da.QueryMany(a => a.FID == fid).FirstOrDefault();
            if (menumodel.RCM_ButtonList != null && menumodel.RCM_ButtonList != "")
            {
                //BFAtaw_Menus_Button bfbtn = new BFAtaw_Menus_Button();
                // rightvalue = bfbtn.getRigthKey(fid);
                var btnJson = menumodel.RCM_ButtonList;
                var btns = btnJson.SafeJsonObject<RC_ButtonList>();
                //model.isButton = true;
                List<RCRightMenuButton> btnList = new List<RCRightMenuButton>();
                foreach (var item in btns.RCMenu_button)
                {
                    RCRightMenuButton RCbtn = new RCRightMenuButton();
                    RCbtn.FID = item.EG_Name+","+model.FID;
                    RCbtn.ButtonName = item.CN_Name;
                    RCbtn.ButtonValue = item.EG_Name;
                    RCbtn.IsHidden = true;
                    btnList.Add(RCbtn);
                }

                model.ButtonList = btnList;
                model.isButton = true;
                //model.ButtonList
            }

            rightvalue = menumodel.RCM_Dir;

            model.RightValue = rightvalue;
            model.OriginalName = dataRow["name"].ToString();
        }

        public bool ishasChildDataTable(RCRightMenuData model, DataTable rightList)
        {
            var haschild = false;
            for (int i = 0; i < rightList.Rows.Count; i++)
            {
                if (rightList.Rows[i]["pid"].ToString() == model.FID)
                {
                    haschild = true;
                }
            }
            return haschild;
        }

        public RC_ButtonList GetMenuModelByFID(string fid)
        {
            DARC_Menu_tree _da = new DARC_Menu_tree(this.UnitOfData);
            var model=_da.QueryDefault(a => a.FID == fid).FirstOrDefault();
            var btnJson = model.RCM_ButtonList;
            var btns = btnJson.SafeJsonObject<RC_ButtonList>();
            return btns;
        }

        public DataTable GetGroupMenusTree1(string unitID, string strWhere)
        {
            var _da = new DARC_Menu_tree(this.UnitOfData);
            var list=_da.QueryDefault(a => 1==1).ToList();
            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("name");
            dt.Columns.Add("rightvalue");
            dt.Columns.Add("pid");
            dt.Columns.Add("fcontrolunitid");
            foreach (var item in list)
            {
                DataRow dr = dt.NewRow();
                dr["id"] = item.FID;
                dr["name"] = item.RCM_Name;
                dr["rightvalue"] = item.RCM_Dir;
                dr["pid"] = item.PID;
                dr["fcontrolunitid"] = item.FControlUnitID;
                dt.Rows.Add(dr);
            }
           
            return dt;
            // _da.DataContext.Database.SqlQuery(,"exec usp_Ataw_GetGroupMenusTree @strwhere,@fcontrolunitid", parameter)
        }

        public RC_Menu_tree GetMenuById(string fid)
        {
            DARC_Menu_tree _da = new DARC_Menu_tree(this.UnitOfData);
            var model=_da.QueryDefault(a => a.FID == fid).FirstOrDefault();
            return model;
        }

        //添加菜单的按钮(实质修改)
        public void AddMenuButton(RC_Menu_tree model)
        {
            DARC_Menu_tree _da = new DARC_Menu_tree(this.UnitOfData);
            var newModel=_da.QueryDefault(a => a.FID == model.FID).FirstOrDefault();
            newModel.RCM_ButtonList = model.RCM_ButtonList;
            _da.Update(newModel);
        }
        //添加菜单
        public void AddMenu(RC_Menu_tree model)
        {
            DARC_Menu_tree _da = new DARC_Menu_tree(this.UnitOfData);
            _da.Add(model);
        }

        //修改菜单
        public void UpdateMenuData(string fid,string menuName)
        {
            DARC_Menu_tree _da = new DARC_Menu_tree(this.UnitOfData);
            var model=_da.QueryDefault(a => a.FID == fid).FirstOrDefault();
            model.RCM_Name = menuName;
            _da.Update(model);
        }
        public bool deleteMenu(string fid)
        {
            DARC_Menu_tree _da = new DARC_Menu_tree(this.UnitOfData);
            try
            {
                _da.Delete(a => a.FID == fid);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            
        }

        /// <summary>
        /// 根据ID 获取单个实体
        /// </summary>
        /// <param name="fid"></param>
        /// <returns></returns>
        public RC_Menu_tree GetMenuByFID(string fid)
        {
            DARC_Menu_tree _da = new DARC_Menu_tree(this.UnitOfData);
            var model=_da.QueryDefault(a => a.FID == fid).FirstOrDefault();
            return model;
        }

        /// <summary>
        /// 检查同一级别下菜单名称是否重复
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pid"></param>
        /// <returns></returns>
        public bool CheckMenuName(string name,string pid)
        {
            DARC_Menu_tree _da = new DARC_Menu_tree(this.UnitOfData);
            var model=_da.QueryDefault(a => a.RCM_Name == name && a.PID == pid).FirstOrDefault();
            if (model != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

