using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMMS.UserMGT.Domain
{
    public class reportSalaryDTO
    {
        public string empId { get; set; }
        public int noOfFullDay { get; set; }
        public int noOfHalfDay { get; set; }
        public int NoPay { get; set; }
        public double NoPayAmount { get; set; }
        public double Basic { get; set; }
        public double bonus { get; set; }
        public double deduction { get; set; }
        public double salary { get; set; }
        public int EmployeeType { get; set; }
        public string EmployeeTypeText { get; set; }
        public string discription1 { get; set; }
        public string discription2 { get; set; }
        public int month { get; set; }
        public int year { get; set; }
        public DateTime modifiedDateTime { get; set; }
        public string modifiedUser { get; set; }
        public string modifiedMachine { get; set; }
    }
}
