using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.Api.Data
{
    public class DayNewData
    {
        public string DayString { get; set; }
        public ICollection<NewData> NewDataList { get; set; }
    }
}
