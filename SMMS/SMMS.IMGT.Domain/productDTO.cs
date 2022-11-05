using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMMS.IMGT.Domain
{
    public class productDTO
    {
        public string pId { get; set; }
        public string pName { get; set; }
        public int pCategoery { get; set; }
        public string pCategoeryText { get; set; }
        public int pQuntityType { get; set; }
        public string pQuntityTypeText { get; set; }
        public double pQuntity { get; set; }
        public string sId { get; set; }
        public DateTime modifiedDateTime { get; set; }
        public string modifiedUser { get; set; }
        public string modifiedMachine { get; set; }
        public double pPrice { get; set; }
        public string pBarcode { get; set; }
    }
}
