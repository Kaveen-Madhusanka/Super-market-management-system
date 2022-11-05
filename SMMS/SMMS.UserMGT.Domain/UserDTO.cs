using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMMS.UserMGT.Domain
{
    public class UserDTO
    {
        public string userID { get; set; }

        public string userName { get; set; }

        public string userEmailAddress { get; set; }

        public string userPhoneNo { get; set; }

        public int userType { get; set; }

        public int userRole { get; set; }

        public int userStatus { get; set; }

        public string userLoginMachine { get; set; }

        public int userInvLoginAttempts { get; set; }

        public DateTime userLastLoginAttempt { get; set; }

        public DateTime userLastLogin { get; set; }

        public DateTime userLastPwdChange { get; set; }

        public string userPassword { get; set; }

        public int isPwdNeverExpire { get; set; }

        public DateTime modifiedDateTime { get; set; }

        public string modifiedUser { get; set; }

        public string modifiedMachine { get; set; }
    }
}
