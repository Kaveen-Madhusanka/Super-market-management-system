using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMMS.SalesMGT.Domain
{
    public class SalesDTO
    {
        public string pID { get; set; }
        public string Name { get; set; }
        public double quntity { get; set; }
        public double price { get; set; }
        public double discount { get; set; }
        public double subTotal { get; set; }
    }
}
