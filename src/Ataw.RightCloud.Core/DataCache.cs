using System;
using System.Web;
using System.ComponentModel;
using System.Collections.Generic;
using System.Data;
using Ataw.Framework.Core;
using Ataw.Framework.Web;


namespace Ataw.RightCloud.Core
{
    public class DataCache
    {
        /// <summary>
        /// 获取当前应用程序指定CacheKey的Cache值
        /// </summary>
        /// <param name="CacheKey"></param>
        /// <returns></returns>
        public static object GetCache(string CacheKey)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            return objCache[CacheKey];
        }

        /// <summary>
        /// 设置当前应用程序指定CacheKey的Cache值
        /// </summary>
        /// <param name="CacheKey"></param>
        /// <param name="objObject"></param>
        public static void SetCache(string CacheKey, object objObject)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject);
        }

        /// <summary>
        /// 设置当前应用程序指定CacheKey的Cache值
        /// </summary>
        /// <param name="CacheKey"></param>
        /// <param name="objObject"></param>
        public static void SetCache(string CacheKey, object objObject, DateTime absoluteExpiration, TimeSpan slidingExpiration)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject, null, absoluteExpiration, slidingExpiration);
        }

        public static void DeleteCache(GetCacheType CacheType)
        {
            if (!GlobalVariable.UserFID.IsEmpty())
            {
                string type = CacheType.ToString();
                switch (type)
                {
                    case "Ataw_Menus_ButtonInfo_New":
                        HttpRuntime.Cache.Remove(GlobalVariable.UserFID + ".IList.Ataw_Menus_ButtonInfo_New");
                        break;
                    case "Ataw_RightsInfo_New":
                        HttpRuntime.Cache.Remove(GlobalVariable.UserFID + ".IList.Ataw_RightsInfo_New");
                        break;
                    case "Ataw_RightsWithButtonInfo_New":
                        HttpRuntime.Cache.Remove(GlobalVariable.UserFID + ".IList.Ataw_RightsWithButtonInfo_New");
                        break;
                    case "AvatarPath_New":
                        DefaultAtawCache.Current.Delete(GlobalVariable.UserFID + ".AvatarPath_New");
                        break;
                    case "Ataw_GroupInfo_New":
                        HttpRuntime.Cache.Remove(GlobalVariable.UserFID + ".IList.Ataw_GroupInfo_New");
                        break;
                    case "Ataw_Menus_ButtonInfoList_New":
                        HttpRuntime.Cache.Remove("Ataw_Menus_ButtonInfoList_New");
                        break;
                    case "Ataw_Menus_ButtonInfoList"://旧版使用获取所有按钮
                        HttpRuntime.Cache.Remove("Ataw_Menus_ButtonInfoList");
                        break;
                }
            }
        }

        [DescriptionAttribute("获取缓存类型")]
        public enum GetCacheType
        {
            [DescriptionAttribute("修改基础菜单、自定义菜单时更新")]
            Ataw_Menus_ButtonInfo_New,
            [DescriptionAttribute("修改角色授权用户授权时更新")]
            Ataw_RightsInfo_New,
            [DescriptionAttribute("修改角色授权用户授权时更新")]
            Ataw_RightsWithButtonInfo_New,
            [DescriptionAttribute("修改用户信息时更新")]
            AvatarPath_New,
            [DescriptionAttribute("修改组织，客商信息管理时更新")]
            Ataw_GroupInfo_New,
            [DescriptionAttribute("修改基础菜单时更新/换数据库连接串时更新")]
            Ataw_Menus_ButtonInfoList_New,
            Ataw_Menus_ButtonInfoList
        }
    }
}
