using SMMS.HRIMGT.DAL;
using SMMS.HRIMGT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMMS.HRIMGT.BL
{
    public class EmployeeBL
    {
        EmployeeDAL oEmployeeDAL = new EmployeeDAL();

        public bool AddEmployee(EmployeeDTO employee)
        {
            return oEmployeeDAL.AddEmployee(employee);
        }
        public bool UpdateEmployee(EmployeeDTO employee)
        {
            return oEmployeeDAL.UpdateEmployee(employee);
        }
        public List<EmployeeDTO> SearchEmployee(EmployeeDTO employee)
        {
            return oEmployeeDAL.SearchEmployee(employee);
        }
        public List<EmployeeDTO> GetEmployees()
        {
            return oEmployeeDAL.GetEmployees();
        }
        public bool DeleteEmployee(string empId)
        {
            return oEmployeeDAL.DeleteEmployee(empId);
        }

        public EmployeeDTO GetEmployee(string empId)
        {
            return oEmployeeDAL.GetEmployee(empId);
        }
    }
}
