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
    public class AttendanceController : ApiController
    {
        AttendanceBL oAttendanceBL = new AttendanceBL();
        [HttpPost]
        public bool AddAttendance(List<AttendanceDTO> attendance)
        {
            return oAttendanceBL.AddAttendance(attendance);
        }
        [HttpGet]
        public List<AttendanceDTO> GetAttendance()
        {
            return oAttendanceBL.GetAttendance();
        }
    }
}
