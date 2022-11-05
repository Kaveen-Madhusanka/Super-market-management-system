using SMMS.HRIMGT.DAL;
using SMMS.HRIMGT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMMS.HRIMGT.BL
{
    public class PayrollBL
    {
        PayrollDAL oPayrollDAL = new PayrollDAL();
        public bool AddSalary(List<SalaryDTO> salary)
        {
            return oPayrollDAL.AddSalary(salary);
        }
    }
}
