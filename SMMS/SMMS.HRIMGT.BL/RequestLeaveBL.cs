using SMMS.HRIMGT.DAL;
using SMMS.HRIMGT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SMMS.HRIMGT.BL
{
    public class RequestLeaveBL
    {
        RequestLeaveDAL oRequestLeaveDAL = new RequestLeaveDAL();
        EmployeeDAL oEmployeeDAL = new EmployeeDAL();
        public List<empRequestedLeaveDTo> GetRequestLeavesDetails()
        {
            return oRequestLeaveDAL.GetRequestLeavesDetails();
        }

        public bool ApproveLeave(empRequestedLeaveDTo oempRequestedLeaveDTo)
        {
            if (oRequestLeaveDAL.ApproveLeave(oempRequestedLeaveDTo))
            {
                sendEmail(oempRequestedLeaveDTo);
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool sendEmail(empRequestedLeaveDTo oempRequestedLeaveDTo)
        {
            try
            {
                EmployeeDTO oEmployeeDTO = GetEmaployee(oempRequestedLeaveDTo.empId);
                if (string.IsNullOrEmpty(oEmployeeDTO.empEmail))
                {
                    return false;
                }

                SmtpClient clientDetails = new SmtpClient();
                clientDetails.Port = 587;
                clientDetails.Host = "smtp.gmail.com";
                clientDetails.EnableSsl = true;
                clientDetails.DeliveryMethod = SmtpDeliveryMethod.Network;
                clientDetails.UseDefaultCredentials = false;
                clientDetails.Credentials = new NetworkCredential("kaveen.madhusanka1998@gmail.com", "kaveen@123");

                MailMessage mailDetails = new MailMessage();
                mailDetails.From = new MailAddress("kaveen.madhusanka1998@gmail.com");
                mailDetails.To.Add(oEmployeeDTO.empEmail);//to address
                mailDetails.Subject = "Leave confirmation ".Trim();
                mailDetails.IsBodyHtml = true;
                mailDetails.Body = " <p>Dear Employee, <br /> <br /> You requested " + " " + oempRequestedLeaveDTo .fromDate + " to "+ oempRequestedLeaveDTo.toDate+ " leaves are approved. <br /> <br /> Best Regards <br />  " + oempRequestedLeaveDTo.modifiedUser + "</p>";

                clientDetails.Send(mailDetails);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private EmployeeDTO GetEmaployee(string empId)
        {
            EmployeeDTO ooEmployeeDAL = new EmployeeDTO();
            ooEmployeeDAL.empId = empId;
            return oEmployeeDAL.SearchEmployee(ooEmployeeDAL).FirstOrDefault();
        }

        public int GetNoPaysById(string empId)
        {
            return oRequestLeaveDAL.GetNoPaysById(empId);
        }
    }
}
