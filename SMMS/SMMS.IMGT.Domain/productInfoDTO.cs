using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMMS.IMGT.Domain
{
    public class productInfoDTO
    {
        public string pId { get; set; }
        public float uQuntity { get; set; }
        public float minQuntity { get; set; }
        public float maxQuntity { get; set; }
        public DateTime modifiedDateTime { get; set; }
        public string modifiedUser { get; set; }
        public string modifiedMachine { get; set; }
    }
}
