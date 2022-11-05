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
    public class LeaveManagementController : ApiController
    {
        RequestLeaveBL oRequestLeaveBL = new RequestLeaveBL();
        [HttpGet]
        public IHttpActionResult GetRequestLeavesDetails()
        {
            return this.Ok(oRequestLeaveBL.GetRequestLeavesDetails());
        }

        [HttpPost]
        public bool ApproveLeave(empRequestedLeaveDTo oempRequestedLeaveDTo)
        {
            return oRequestLeaveBL.ApproveLeave(oempRequestedLeaveDTo);
        }

        [HttpGet]
        public IHttpActionResult GetNoPaysById(string empId)
        {
            return this.Ok(oRequestLeaveBL.GetNoPaysById(empId));
        }
    }
}
