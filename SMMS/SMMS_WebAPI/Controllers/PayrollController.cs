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
    public class PayrollController : ApiController
    {
        PayrollBL oPayrollBL = new PayrollBL();
        [HttpPost]
        public IHttpActionResult AddSalary(List<SalaryDTO> salary)
        {
            return this.Ok(oPayrollBL.AddSalary(salary));
        }
    }
}
