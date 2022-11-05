using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMMS.HRIMGT.Domain
{
    public class AttendanceDTO
    {
        public string empID { get; set; }
        public string inTime { get; set; }
        public string outTime { get; set; }
        public string dateType { get; set; }
        public string date { get; set; }
        public DateTime modifiedDateTime { get; set; }
        public string modifiedUser { get; set; }
        public string modifiedMachine { get; set; }
    }
}
