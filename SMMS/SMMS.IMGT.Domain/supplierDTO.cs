using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMMS.IMGT.Domain
{
    public class supplierDTO
    {
        public string sId { get; set; }
        public string sName { get; set; }
        public string sAddress { get; set; }
        public int sContactNo { get; set; }
        public string sEmail { get; set; }
        public string pId { get; set; }
        public DateTime modifiedDateTime { get; set; }
        public string modifiedUser { get; set; }
        public string modifiedMachine { get; set; }
    }
}
