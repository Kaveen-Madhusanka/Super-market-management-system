using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMMS.SalesMGT.Domain
{
    public static class GlobalBillDTO
    {
        public static SalesDTO Bill = new SalesDTO();
        public static bool isUpdate { get; set; }
    }
}
