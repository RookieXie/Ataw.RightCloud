
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ataw.Framework.Core;
using Ataw.RightCloud.DA;
using Ataw.RightCloud.DB;
using Ataw.RightCloud.Api.Data;
using Ataw.RightCloud.Data;

namespace Ataw.RightCloud.BF
{
    public class BFRC_Menu_Role : RightCloudBaseBF
    {
        public List<RCRole_MenuData> GetRCRoleMenuByGroup(string Group)
        {
            DARC_Menu_Role _da = new DARC_Menu_Role(this.UnitOfData);
            if (Group.IsAkEmpty())
            {
                Group = "1";
            }
            List<RC_Menu_Role> list = _da.QueryMany(a => (a.RCMR_FControlUnitID == Group)).ToList();
            List<RCRole_MenuData> List = new List<RCRole_MenuData>();
            foreach (var item in list)
            {
                RCRole_MenuData model = new RCRole_MenuData();
                CopyModel(item, model);
                List.Add(model);
            }
            foreach (var item in list)
            {
                if (item.RCMR_Button != null)
                {                   
                    var btn = item.RCMR_Button;
                    var btns=btn.Split(',');
                    for (int i = 0; i < btns.Length; i++)
                    {
                        RCRole_MenuData model = new RCRole_MenuData();
                        model.Menu = btns[i] + "," + item.RCMR_MenuFID;
                        model.Role = item.RCMR_RoleFID;
                        List.Add(model);
                    }

                }
            }
            return List;
        }

        public void CopyModel(RC_Menu_Role model,RCRole_MenuData Rightmodel)
        {
            Rightmodel.Menu = model.RCMR_MenuFID;
            Rightmodel.Role = model.RCMR_RoleFID;
        }
        public List<RC_Menu_Role> GetRoleMenuList(string roleId)
        {
            DARC_Menu_Role _da = new DARC_Menu_Role(this.UnitOfData);
            var list=_da.QueryDefault(a => a.RCMR_RoleFID == roleId).ToList();
            return list;
        }

        /// <summary>
        /// ɾ����ɫ�����˵�Ȩ��
        /// </summary>
        /// <param name="roleID"></param>
        public void DeleteByRoleID(string roleID)
        {
            DARC_Menu_Role _da = new DARC_Menu_Role(this.UnitOfData);
            _da.Delete(a => a.RCMR_RoleFID == roleID);
        }
        /// <summary>
        /// ��ӽ�ɫ�˵�Ȩ��
        /// </summary>
        /// <param name="model"></param>
        public void InsertRoleMenu(RC_Menu_Role model)
        {
            DARC_Menu_Role _da = new DARC_Menu_Role(this.UnitOfData);
            model.FID = _da.GetUniId();
            _da.Add(model);           
        }
        //���ݲ˵�ɾ��Ȩ��
        public void DeleteByMenuID(string menuID)
        {
            DARC_Menu_Role _da = new DARC_Menu_Role(this.UnitOfData);
            _da.Delete(a => a.RCMR_MenuFID == menuID);
        }

        //���ݽ�ɫɾ��Ȩ��
        public void delRight(string roleID)
        {
            DARC_Menu_Role _da = new DARC_Menu_Role(this.UnitOfData);
            _da.Delete(a => a.RCMR_RoleFID == roleID);
        }

        //���
        public void ADDRight(RC_Menu_Role model)
        {
            DARC_Menu_Role _da = new DARC_Menu_Role(this.UnitOfData);
            model.FID=_da.GetUniId();
            _da.Add(model);
        }

        //���ݽ�ɫ���˵�����֯ɾ��Ȩ��
        public void DelteByRoleID(string menuID,string roleID,string fControlUnitID)
        {
            DARC_Menu_Role _da = new DARC_Menu_Role(this.UnitOfData);
            _da.Delete(a => a.RCMR_MenuFID == menuID && a.RCMR_RoleFID == roleID && a.RCMR_FControlUnitID == fControlUnitID);
        }
        //��Ӱ�ť
        public void ADDRightButton(RC_Menu_Role model)
        {
            DARC_Menu_Role _da = new DARC_Menu_Role(this.UnitOfData);
            var newModel=_da.QueryDefault(a => a.RCMR_MenuFID == model.RCMR_MenuFID && a.RCMR_RoleFID == model.RCMR_RoleFID && a.RCMR_FControlUnitID == model.RCMR_FControlUnitID).FirstOrDefault();
            if (newModel == null)
            {
                model.FID = _da.GetUniId();
                _da.Add(model);
            }else
            {
                if (string.IsNullOrEmpty(newModel.RCMR_Button))
                    newModel.RCMR_Button = model.RCMR_Button;
                else
                    newModel.RCMR_Button = newModel.RCMR_Button + "," + model.RCMR_Button;

                _da.Update(newModel);
            }

        }

        //ɾ����ť���ݰ�ť�Լ������˵�����֯����ɫ
        public void DeleteBtn(string menuID, string roleID, string fControlUnitID,string btnEGName)
        {
            DARC_Menu_Role _da = new DARC_Menu_Role(this.UnitOfData);
            var menuFID = menuID.Split(',')[1];
            var newModel = _da.QueryDefault(a => a.RCMR_MenuFID == menuFID && a.RCMR_RoleFID == roleID && a.RCMR_FControlUnitID == fControlUnitID).FirstOrDefault();
            if (newModel != null)
            {
                var newBtn = newModel.RCMR_Button;
                List<string> list = new List<string>();
                var btns = newBtn.Split(',');
                for (int i = 0; i < btns.Length; i++)
                {
                    if (btns[i] != btnEGName)
                    {
                        list.Add(btns[i]);
                    }
                }
                string btn_del = list.Count > 0 ? list[0] : "";
                for (int i =1; i < list.Count; i++)
                {
                    btn_del = btn_del + "," + list[i];
                }
                newModel.RCMR_Button = btn_del;
                _da.Update(newModel);
            }

        }
    }
}

