using SMMS.UserMGT.BL;
using SMMS.UserMGT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SMMS_WebAPI.Controllers
{
    public class UserController : ApiController
    {
        UserBL oUserBL = new UserBL();

        [HttpGet]
        public IHttpActionResult IsValidUser(string UserName, string Password)
        {
            return this.Ok(oUserBL.IsValidUser(UserName, Password));
        }

        [HttpPost]
        public IHttpActionResult InsertUser(UserDTO user)
        {
            return this.Ok(oUserBL.InsertUser(user));
        }

        [HttpPost]
        public IHttpActionResult ApplayLeave(RequestLeaveDTO oRequestLeaveDTO)
        {
            return this.Ok(oUserBL.ApplayLeave(oRequestLeaveDTO));
        }
        [HttpGet]
        public IHttpActionResult GetLeaveDetails(string empID)
        {
            return this.Ok(oUserBL.GetLeaveDetails(empID));
        }

        [HttpGet]
        public IHttpActionResult GetRequestLeaveDetails(string empID)
        {
            return this.Ok(oUserBL.GetRequestLeaveDetails(empID));
        }
        [HttpGet]
        public IHttpActionResult GetUserbyName(string UserId)
        {
            return this.Ok(oUserBL.GetUserbyName(UserId));
        }

        [HttpGet]
        public IHttpActionResult GetSalaryData(string empID, int month, int year)
        {
            return this.Ok(oUserBL.GetSalaryData(empID, month, year));
        }

        [HttpPut]
        public IHttpActionResult ChangeUserData(UserDTO user)
        {
            return this.Ok(oUserBL.ChangeUserData(user));
        }

        [HttpPost]
        public IHttpActionResult BookSlot(ParkingDTO oParkingDTO)
        {
            return this.Ok(oUserBL.BookSlot(oParkingDTO));
        }
        [HttpGet]
        public IHttpActionResult GetAllBookedSlots()
        {
            return this.Ok(oUserBL.GetAllBookedSlots());
        }

        [HttpPut]
        public IHttpActionResult UpdateEmailsettings(EmailDTO oEmailDTO)
        {
            return this.Ok(oUserBL.UpdateEmailsettings(oEmailDTO));
        }

        [HttpGet]
        public IHttpActionResult GetEmailDetails()
        {
            return this.Ok(oUserBL.GetEmailDetails());
        }
    }
}
