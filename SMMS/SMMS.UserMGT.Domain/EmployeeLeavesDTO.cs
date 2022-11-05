using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMMS.UserMGT.Domain
{
    public class EmployeeLeavesDTO
    {
        public string empId { get; set; }
        public double casualLeaveBal { get; set; }
        public double medicalLeaveBal { get; set; }
        public double anualLeaveBal { get; set; }
        public double shortLeave { get; set; }
        public DateTime modifiedDateTime { get; set; }
        public string modifiedUser { get; set; }
        public string modifiedMachine { get; set; }
    }
}
