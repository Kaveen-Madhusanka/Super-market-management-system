using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMMS.HRIMGT.Domain
{
    public class EmployeeDTO
    {
        public string empId { get; set; }
        public string empName { get; set; }
        public string empEmail { get; set; }
        public string empContact { get; set; }
        public string empAddress { get; set; }
        public string empDepartment { get; set; }
        public int empType { get; set; }
        public string empTypeText { get; set; }
        public DateTime empDOB { get; set; }
        public DateTime modifiedDateTime { get; set; }
        public string modifiedUser { get; set; }
        public string modifiedMachine { get; set; }
    }
}
