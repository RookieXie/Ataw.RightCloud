using Ataw.Framework.Core.Interface;
using Ataw.Framework.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using  Ataw.Framework.Core;
namespace Ataw.RightCloud.Web
{
    public class TestController : AtawBaseController
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        public string Email(string email)
        {
            string _emailtitle = "邮件测试" ;
            var _email = "DefaultEmailServices".CodePlugIn<IEmailServices>();
            List<string> useremail = new List<string>();

            //var _emails = _users.GroupBy(a => a.T9Email).ToList();
            //foreach (var users in _emails)
            //{
            useremail.Add("zyk2003xxx@163.com");
            //  }
            _email.ToUsers = useremail;
            _email.StrBody = _emailtitle;//主体
            _email.StrSubject = "经理又有配件要采购了";//标题
            _email.Send();
            return "ok";
        }
    }
}