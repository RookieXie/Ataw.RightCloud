using Ataw.Framework.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace Ataw.RightCloud.Core
{
    public static class RCUtil
    {
        public static string GetTextByCD(this string regname, string key)
        {
            var _codeTable = regname.CodePlugIn<CodeTable<CodeDataModel>>();
            if (_codeTable != null)
            {
                var _obj = _codeTable[key];
                if (_obj != null)
                {
                    return _obj.CODE_TEXT;
                }
            }
            return "";
        }       
    }
}
