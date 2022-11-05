using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMMS.SalesMGT.Domain
{
    public class orderDTO
    {
        public string billNo { get; set; }
        public string pid { get; set; }
        public double quantity { get; set; }
        public double discount { get; set; }
        public double subTotal { get; set; }
        public DateTime modifiedDateTime { get; set; }
        public string modifiedUser { get; set; }
        public string modifiedMachine { get; set; }
    }
}
