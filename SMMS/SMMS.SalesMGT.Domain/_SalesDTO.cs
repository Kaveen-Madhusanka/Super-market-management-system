using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMMS.SalesMGT.Domain
{
    public class _SalesDTO
    {
        public string billNo { get; set; }
        public string cashier { get; set; }
        public double total { get; set; }
        public double discount { get; set; }
        public DateTime modifiedDateTime { get; set; }
        public string modifiedUser { get; set; }
        public string modifiedMachine { get; set; }
    }
}
