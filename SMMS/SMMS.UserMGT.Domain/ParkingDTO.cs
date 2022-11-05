using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMMS.UserMGT.Domain
{
    public class ParkingDTO
    {
        public string cusId { get; set; }
        public int slotNo { get; set; }
        public DateTime time { get; set; }
        public int isBooked { get; set; }
    }
}
