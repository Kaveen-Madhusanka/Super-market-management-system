using SMMS.HRIMGT.BL;
using SMMS.HRIMGT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SMMS_WebAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        EmployeeBL oEmployeeBL = new EmployeeBL();

        [HttpPost]
        public IHttpActionResult AddEmployee(EmployeeDTO employee)
        {
            if (oEmployeeBL.AddEmployee(employee))
            {
                return this.Ok(true);
            }
            else
            {
                return this.InternalServerError(new Exception("False"));
            }
        }

        [HttpPut]
        public IHttpActionResult UpdateEmployee(EmployeeDTO employee)
        {
            if (oEmployeeBL.UpdateEmployee(employee))
            {
                return this.Ok(true);
            }
            else
            {
                return this.InternalServerError(new Exception("False"));
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteEmployee(string employee)
        {
            if (oEmployeeBL.DeleteEmployee(employee))
            {

                return this.Ok(true);
            }
            else
            {
                return this.InternalServerError(new Exception("False"));
            }
        }

        [HttpPost]
        public IHttpActionResult SearchEmployee(EmployeeDTO employee)
        {
            return this.Ok(oEmployeeBL.SearchEmployee(employee));
        }

        [HttpGet]
        public IHttpActionResult GetEmployees()
        {
            return this.Ok(oEmployeeBL.GetEmployees());
        }

        [HttpGet]
        public IHttpActionResult GetEmployee(string empId)
        {
            return this.Ok(oEmployeeBL.GetEmployee(empId));
        }
    }
}
