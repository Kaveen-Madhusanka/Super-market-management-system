using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMMS.HRIMGT.Domain
{
    public class empRequestedLeaveDTo
    {
        public string empId { get; set; }
        public int leaveType { get; set; }
        public string leaveTypeText { get; set; }
        public int isFullDay { get; set; }
        public string isFullDayText { get; set; }
        public int half { get; set; }
        public string halfText { get; set; }
        public DateTime fromDate { get; set; }
        public DateTime toDate { get; set; }
        public string discription { get; set; }
        public int isApprove { get; set; }
        public DateTime modifiedDateTime { get; set; }
        public string modifiedUser { get; set; }
        public string modifiedMachine { get; set; }
    }
}
