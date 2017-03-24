
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ataw.Framework.Core;
using Ataw.RightCloud.DA;
using Ataw.RightCloud.DB;
using Ataw.RightCloud.Data;
using Ataw.RightCloud.Api;
using Ataw.RightCloud.Api.Data;
using Ataw.RightCloud.Core;

namespace Ataw.RightCloud.BF
{
    public class BFAtaw_Menus_Button : RightCloudBaseBF
    {
        internal List<MenuButtonData> getbuttoninfo(string rightId)
        {
            DAAtaw_Menus_Button _da = new DAAtaw_Menus_Button(this.UnitOfData);
            List<Ataw_Menus_Button> modelList = new List<Ataw_Menus_Button>();
            modelList = _da.QueryMany(a => (a.ParentRightValue == rightId)).OrderBy(a => a.FValue).ToList();
            if (modelList.Count > 1)
            {
                List<MenuButtonData> buttonList = new List<MenuButtonData>();
                for (int i = 0; i < modelList.Count; i++)
                {
                    MenuButtonData _model = new MenuButtonData();
                    _model.FID = modelList[i].FID;
                    _model.FKey = modelList[i].FKey;
                    _model.FName = modelList[i].FName;
                    _model.FValue = modelList[i].FValue.ToString();
                    _model.OrderId = modelList[i].OrderId.ToString();
                    _model.ParentRightValue = modelList[i].ParentRightValue;
                    buttonList.Add(_model);
                }
                return buttonList;
            }
            return null;
        }

        public void AddMenuButton(IEnumerable<MenuButtonData> enumerable, String ParentRightValue)
        {
            DAAtaw_Menus_Button _da = new DAAtaw_Menus_Button(this.UnitOfData);
            foreach (var item in enumerable)
            {
                Ataw_Menus_Button model = new Ataw_Menus_Button();
                AtawDebug.AssertNotNullOrEmpty(item.FKey, "按钮编码不能为空", this);
                AtawDebug.AssertNotNullOrEmpty(item.FName, "按钮名称不能为空", this);
                AtawDebug.AssertNotNullOrEmpty(item.FValue, "按钮编码不能为空", this);
                model.FID = UnitOfData.GetUniId();
                model.ParentRightValue = ParentRightValue;
                model.FKey = item.FKey;
                model.FName = item.FName;
                model.FValue = item.FValue.Value<int?>();
                _da.Add(model);
            }
        }
        //菜单组织权限中添加按钮
        public void AddMenuButton(Ataw_Menus_Button model)
        {
            DAAtaw_Menus_Button da = new DAAtaw_Menus_Button(this.UnitOfData);
            da.Add(model);
        }

        //菜单组织权限中按钮删除
        public void DelMenuButton(string pValue)
        {
            DAAtaw_Menus_Button da = new DAAtaw_Menus_Button(this.UnitOfData);
            da.Delete(a => a.ParentRightValue == pValue);
        }

        //菜单组织权限中修改按钮
        public void UpdateMenuButton(string fid, string menuName)
        {
            DAAtaw_Menus_Button da = new DAAtaw_Menus_Button(this.UnitOfData);
            Ataw_Menus_Button model = new Ataw_Menus_Button();
            model = da.QueryMany(a => a.FID == fid).FirstOrDefault();
            model.FName = menuName;
            da.Edit(model);
        }
        public void UpdateMenuButton(IEnumerable<MenuButtonData> enumerable, string ParentRightValue)
        {
            DAAtaw_Menus_Button _da = new DAAtaw_Menus_Button(this.UnitOfData);

            foreach (var item in enumerable)
            {
                if (!item.FID.IsAkEmpty())
                {
                    Ataw_Menus_Button model = _da.QueryDefault(a => a.FID == item.FID).FirstOrDefault();

                    // model.ParentRightValue = ParentRightValue;
                    if (item.FKey != null)
                    {
                        model.FKey = item.FKey;
                    }

                    if (item.FName != null)
                    {
                        model.FName = item.FName;
                    }
                    if (item.FValue != null)
                    {
                        model.FValue = item.FValue.Value<int?>();
                    }

                    if (item.OrderId != null)
                    {
                        model.OrderId = item.OrderId.Value<int?>();
                    }
                    if (item.ParentRightValue != null)
                    {
                        model.ParentRightValue = item.ParentRightValue;
                    }

                    _da.Update(model);
                }
                else
                {
                    Ataw_Menus_Button model = new Ataw_Menus_Button();

                    // BFAtaw_Menus bf = new BFAtaw_Menus();
                    // var MenuModel = bf.getMenuDetail(ParentRightValue);

                    model.ParentRightValue = item.ParentRightValue;
                    model.FName = item.FName;
                    model.FKey = item.FKey;
                    model.FID = this.UnitOfData.GetUniId();
                    model.FValue = item.FValue.Value<int?>();
                    model.OrderId = item.OrderId.Value<int?>();
                    //smodel.ParentRightValue = ParentRightValue;

                    _da.Add(model);
                }
            }
        }

        public List<Ataw_Menus_Button> GetMenus_Button(string p, int functionRight)
        {
            string strBtnValues = GetBtnValues(functionRight);

            IList<Ataw_Menus_Button> lmodel = GetAllByCache();
            List<Ataw_Menus_Button> lmodelrtn = new List<Ataw_Menus_Button>();
            if (lmodel != null)
            {
                var lmodelBtn = lmodel.Where(r => r.ParentRightValue == p && strBtnValues.Split(',').Contains(r.FValue.ToString()));//.OrderBy(r => r.FValue);
                //lmodel = (List<Ataw_Menus_ButtonInfo>)lmodelBtn;
                lmodelrtn = lmodelBtn.ToList();
                return lmodelrtn;
            }
            return null;
        }


        /// <summary>
        /// 根据2的次方和 获得2的次方列表
        /// </summary>
        /// <param name="FunctionRight">按钮的次方和</param>
        /// <returns>2的次方列表</returns>
        public static string GetBtnValues(int FunctionRight)
        {
            string strRtnBtn = "";
            string arrBtnList = "";
            if (FunctionRight > 0)
            {
                for (int i = 1; i < FunctionRight; i++)
                {
                    int intValue = Convert.ToInt32(Math.Pow(2, i));//所有拥有的按钮value
                    if (intValue > FunctionRight)
                    {
                        break;
                    }
                    arrBtnList += "," + intValue;
                }
                if (arrBtnList.IndexOf(",") == 0)
                    arrBtnList = arrBtnList.Substring(1);
                int Values = FunctionRight;
                string[] arrBtnLists = arrBtnList.Split(',');//拥有的权限
                for (int i = arrBtnLists.Length - 1; i >= 0; i--)
                {
                    if (arrBtnLists[i] != "")
                    {
                        int maxValue = Convert.ToInt32(arrBtnLists[i]);
                        if (Values >= maxValue)
                        {
                            Values -= Convert.ToInt32(arrBtnLists[i]);
                            strRtnBtn += "," + arrBtnLists[i];
                        }
                    }
                }

                if (strRtnBtn.IndexOf(",") == 0)
                    strRtnBtn = strRtnBtn.Substring(1);
            }
            if (string.IsNullOrEmpty(strRtnBtn))
                strRtnBtn = "0";
            return strRtnBtn;
        }

        public static IList<Ataw_Menus_Button> GetAllByCache()
        {
            var bf = new BFAtaw_Menus_Button();

            string CacheKey = "Ataw_Menus_ButtonInfoList_New";
            object objModel = DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = bf.GetAll();
                    if (objModel != null)
                    {
                        DataCache.SetCache(CacheKey, objModel);
                    }
                }
                catch { }
            }
            return (IList<Ataw_Menus_Button>)objModel;
        }

        public object GetAll()
        {
            DAAtaw_Menus_Button _da = new DAAtaw_Menus_Button(this.UnitOfData);
            var listbutton = _da.QueryMany(a => 1 == 1).ToList();
            return listbutton;
        }

        public void deleteButtonList(List<string> list)
        {
            DAAtaw_Menus_Button _da = new DAAtaw_Menus_Button(this.UnitOfData);
            foreach (var item in list)
            {
                _da.Delete(a => a.FID == item);
            }
        }

        public bool hasButton(string KeyVaue)
        {
            DAAtaw_Menus_Button _da = new DAAtaw_Menus_Button(this.UnitOfData);
            var list = _da.QueryMany(a => a.ParentRightValue == KeyVaue).ToList();
            if (list.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal string getRigthKey(string fid)
        {
            DAAtaw_Menus_Button _da = new DAAtaw_Menus_Button(this.UnitOfData);
            var list = _da.QueryMany(a => a.FID == fid).FirstOrDefault();
            if (list == null)
            {
                return "";
            }
            else
            {
                return list.ParentRightValue;
            }
        }
    }
}

