using SMMS.Common;
using SMMS.UserMGT.DAL;
using SMMS.UserMGT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMMS.UserMGT.BL
{
    public class UserBL
    {
        UserDAL oUserDAL = new UserDAL();

        public UserDTO GetUserbyName(string UserName)
        {
            return oUserDAL.GetUserbyName(UserName);
        }

        public int IsValidUser(string UserName,string Password)
        {
            try
            {
                Password = Common.EncriptionFcatory.Encrypt(Password,UserName);
                UserDTO oUser = GetUserbyName(UserName);
                if (!string.IsNullOrEmpty(oUser.userID))
                {
                    if (Password.Equals(oUser.userPassword))
                    {
                        if (oUser.userStatus.Equals((int)Enums.UserStatus.Active))
                        {
                            return (int)Enums.UserLoginResult.ValidUser;
                        }
                        else
                        {
                            return (int)Enums.UserLoginResult.InactiveUser;
                        }
                    }
                    else
                    {
                        return (int)Enums.UserLoginResult.InvalidPassword;
                    }
                }
                else
                {
                    return (int)Enums.UserLoginResult.InvalidUser;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<RequestLeaveDTO> GetRequestLeaveDetails(string empID)
        {
            return oUserDAL.GetRequestLeaveDetails(empID);
        }
        public bool InsertUser(UserDTO user)
        {
            return oUserDAL.InsertUser(user);
        }

        public bool ApplayLeave(RequestLeaveDTO oRequestLeaveDTO)
        {
            return oUserDAL.ApplayLeave(oRequestLeaveDTO);
        }

        public EmployeeLeavesDTO GetLeaveDetails(string empID)
        {
            return oUserDAL.GetLeaveDetails(empID);
        }

        public reportSalaryDTO GetSalaryData(string empID, int month, int year)
        {
            return oUserDAL.GetSalaryData(empID, month, year);
        }
        public bool ChangeUserData(UserDTO user)
        {
            return oUserDAL.ChangeUserData(user);
        }

        public bool BookSlot(ParkingDTO oParkingDTO)
        {
            return oUserDAL.BookSlot(oParkingDTO);
        }

        public List<ParkingDTO> GetAllBookedSlots()
        {
            return oUserDAL.GetAllBookedSlots();
        }

        public bool UpdateEmailsettings(EmailDTO oEmailDTO)
        {
            return oUserDAL.UpdateEmailsettings(oEmailDTO);        
        }
        public EmailDTO GetEmailDetails()
        {
            return oUserDAL.GetEmailDetails();
        }
    }
}
