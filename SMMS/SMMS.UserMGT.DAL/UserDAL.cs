using SMMS.Common;
using SMMS.UserMGT.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMMS.UserMGT.DAL
{
    public class UserDAL
    {
        public UserDTO GetUserbyName(string UserName)
        {
            UserDTO result = new UserDTO();
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.Clear();
                sb.Append("SELECT ");
                sb.Append(" userID,");
                sb.Append(" userName,");
                sb.Append(" userEmailAddress,");
                sb.Append(" userPhoneNo,");
                sb.Append(" userType,");
                sb.Append(" userRole,");
                sb.Append(" userStatus,");
                sb.Append(" userLoginMachine,");
                sb.Append(" userInvLoginAttempts,");
                sb.Append(" userLastLoginAttempt,");
                sb.Append(" userLastLogin,");
                sb.Append(" userLastPwdChange,");
                sb.Append(" userPassword,");
                sb.Append(" isPwdNeverExpire");
                sb.Append(" FROM [tblUser]");
                sb.Append("WHERE 1=1");
                sb.Append("AND userID = @userID");

                SqlCommand command = new SqlCommand(sb.ToString(), ConnectionDetails.Conn);
                string cmdText = command.CommandText;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("userID", UserName);
                ConnectionDetails.Conn.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader != null && reader.Read())
                    {
                        result.userID = reader[ "userID"].ToString();
                        result.userName = reader[ "userName"].ToString();
                        result.userEmailAddress = reader[ "userEmailAddress"].ToString();
                        result.userPhoneNo = reader[ "userPhoneNo"].ToString();
                        result.userType = (int)reader["userType"];
                        result.userRole = (int)reader["userRole"];
                        result.userStatus = reader["userStatus"].Equals(DBNull.Value)? 0 :(int)reader["userStatus"];
                        result.userLoginMachine = (reader[ "userLoginMachine"] ?? "") .ToString();
                        result.userInvLoginAttempts = reader["userInvLoginAttempts"].Equals(DBNull.Value) ? 0: Convert.ToInt32(reader["userInvLoginAttempts"]);
                        result.userLastLoginAttempt = reader["userLastLoginAttempt"].Equals(DBNull.Value) ? default(DateTime) : Convert.ToDateTime(reader[ "userLastLoginAttempt"]);
                        result.userLastLogin = reader["userLastLogin"].Equals(DBNull.Value)? default(DateTime) : Convert.ToDateTime(reader[ "userLastLogin"]);
                        result.userLastPwdChange = reader["userLastPwdChange"].Equals(DBNull.Value) ? default(DateTime) : Convert.ToDateTime(reader[ "userLastPwdChange"]);
                        result.userPassword = (reader[ "userPassword"] ?? "").ToString();
                        result.isPwdNeverExpire = reader["isPwdNeverExpire"].Equals(DBNull.Value) ? 0 :(int)reader["isPwdNeverExpire"];
                    }
                    ConnectionDetails.Conn.Close();
                }

                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                ConnectionDetails.Conn.Close();
            }
        }

        public bool InsertUser(UserDTO user)
        {
            StringBuilder sb = new StringBuilder();
            bool result = false;
            try
            {
                sb.Clear();
                sb.AppendLine(" INSERT INTO tblUser VALUES(");
                sb.AppendLine("@userID,");
                sb.AppendLine("@userName,");
                sb.AppendLine("@userEmailAddress,");
                sb.AppendLine("@userPhoneNo,");
                sb.AppendLine("@userType,");
                sb.AppendLine("@userRole,");
                sb.AppendLine("@userStatus,");
                sb.AppendLine("@userLoginMachine,");
                sb.AppendLine("@userInvLoginAttempts,");
                sb.AppendLine("@userLastLoginAttempt,");
                sb.AppendLine("@userLastLogin,");
                sb.AppendLine("@userLastPwdChange,");
                sb.AppendLine("@userPassword,"); 
                sb.AppendLine("@isPwdNeverExpire,");
                sb.AppendLine("@modifiedDateTime,");
                sb.AppendLine("@modifiedUser,");
                sb.AppendLine("@modifiedMachine)");

                using (SqlCommand command = new SqlCommand(sb.ToString(), ConnectionDetails.Conn))
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("userID", user.userID);
                    command.Parameters.AddWithValue("userName", user.userName);
                    command.Parameters.AddWithValue("userEmailAddress", user.userEmailAddress);
                    command.Parameters.AddWithValue("userPhoneNo", user.userPhoneNo);
                    command.Parameters.AddWithValue("userType", user.userType);
                    command.Parameters.AddWithValue("userRole", user.userRole);
                    command.Parameters.AddWithValue("userStatus", user.userStatus);
                    command.Parameters.AddWithValue("userLoginMachine", user.userLoginMachine);
                    command.Parameters.AddWithValue("userInvLoginAttempts", user.userInvLoginAttempts);
                    command.Parameters.AddWithValue("userLastLoginAttempt", user.userLastLoginAttempt);
                    command.Parameters.AddWithValue("userLastLogin", user.userLastLogin);
                    command.Parameters.AddWithValue("userLastPwdChange", user.userLastPwdChange);
                    command.Parameters.AddWithValue("userPassword", EncriptionFcatory.Encrypt(user.userPassword, user.userID));
                    command.Parameters.AddWithValue("isPwdNeverExpire", user.isPwdNeverExpire);
                    command.Parameters.AddWithValue("modifiedDateTime", user.modifiedDateTime);
                    command.Parameters.AddWithValue("modifiedUser", user.modifiedUser);
                    command.Parameters.AddWithValue("modifiedMachine", user.modifiedMachine);

                    ConnectionDetails.Conn.Open();
                    if (command.ExecuteNonQuery() > 0)
                        result = true;

                    ConnectionDetails.Conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                ConnectionDetails.Conn.Close();
            }
            return result;
        }

        public bool ApplayLeave(RequestLeaveDTO oRequestLeaveDTO)
        {
            StringBuilder sb = new StringBuilder();
            bool result = false;
            try
            {
                sb.Clear();
                sb.AppendLine(" INSERT INTO tblRequestLeaves VALUES(");
                sb.AppendLine("@empId,");
                sb.AppendLine("@leaveType,");
                sb.AppendLine("@isFullDay,");
                sb.AppendLine("@half,");
                sb.AppendLine("@fromDate,");
                sb.AppendLine("@toDate,");
                sb.AppendLine("@discription,");
                sb.AppendLine("@isApprove,");
                sb.AppendLine("@modifiedDateTime,");
                sb.AppendLine("@modifiedUser,");
                sb.AppendLine("@modifiedMachine)");

                using (SqlCommand command = new SqlCommand(sb.ToString(), ConnectionDetails.Conn))
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("empId", oRequestLeaveDTO.empId);
                    command.Parameters.AddWithValue("leaveType", oRequestLeaveDTO.leaveType);
                    command.Parameters.AddWithValue("isFullDay", oRequestLeaveDTO.isFullDay);
                    command.Parameters.AddWithValue("half", oRequestLeaveDTO.half);
                    command.Parameters.AddWithValue("fromDate", oRequestLeaveDTO.fromDate);
                    command.Parameters.AddWithValue("toDate", oRequestLeaveDTO.toDate);
                    command.Parameters.AddWithValue("discription", oRequestLeaveDTO.discription);
                    command.Parameters.AddWithValue("isApprove", oRequestLeaveDTO.isApprove);
                    command.Parameters.AddWithValue("modifiedDateTime", oRequestLeaveDTO.modifiedDateTime);
                    command.Parameters.AddWithValue("modifiedUser", oRequestLeaveDTO.modifiedUser);
                    command.Parameters.AddWithValue("modifiedMachine", oRequestLeaveDTO.modifiedMachine);

                    ConnectionDetails.Conn.Open();
                    if (command.ExecuteNonQuery() > 0)
                        result = true;

                    ConnectionDetails.Conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                ConnectionDetails.Conn.Close();
            }
            return result;
        }

        public EmployeeLeavesDTO GetLeaveDetails(string empID)
        {
            EmployeeLeavesDTO result = new EmployeeLeavesDTO();
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.Clear();
                sb.AppendLine(" SELECT ");
                sb.AppendLine("empId,");
                sb.AppendLine("casualLeaveBal,");
                sb.AppendLine("medicalLeaveBal,");
                sb.AppendLine("anualLeaveBal,");
                sb.AppendLine("shortLeave,");
                sb.AppendLine("modifiedDateTime,");
                sb.AppendLine("modifiedUser,");
                sb.AppendLine("modifiedMachine");
                sb.AppendLine(" FROM tblEmployeeLeaves ");
                sb.AppendLine(" WHERE 1=1 ");
                sb.AppendLine(" AND (empId=@empId)");

                SqlCommand command = new SqlCommand(sb.ToString(), ConnectionDetails.Conn);
                string cmdText = command.CommandText;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("empId", empID);
                ConnectionDetails.Conn.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader != null && reader.Read())
                    {
                        result.empId = reader["empId"].ToString();
                        result.casualLeaveBal = Convert.ToDouble(reader["casualLeaveBal"]);
                        result.medicalLeaveBal = Convert.ToDouble(reader["medicalLeaveBal"]);
                        result.anualLeaveBal = Convert.ToDouble(reader["anualLeaveBal"]);
                        result.shortLeave = Convert.ToDouble(reader["shortLeave"]);
                    }
                    ConnectionDetails.Conn.Close();
                }

                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                ConnectionDetails.Conn.Close();
            }
        }

        public List<RequestLeaveDTO> GetRequestLeaveDetails(string empID)
        {
            List<RequestLeaveDTO> result = new List<RequestLeaveDTO>();
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.Clear();
                sb.AppendLine(" SELECT ");
                sb.AppendLine("empId,");
                sb.AppendLine("leaveType,");
                sb.AppendLine("isFullDay,");
                sb.AppendLine("half,");
                sb.AppendLine("fromDate,");
                sb.AppendLine("toDate,");
                sb.AppendLine("discription,");
                sb.AppendLine("isApprove,");
                sb.AppendLine("modifiedDateTime,");
                sb.AppendLine("modifiedUser,");
                sb.AppendLine("modifiedMachine");
                sb.AppendLine(" FROM tblRequestLeaves ");
                sb.AppendLine(" WHERE 1=1 ");
                sb.AppendLine(" AND (empId=@empId)");

                SqlCommand command = new SqlCommand(sb.ToString(), ConnectionDetails.Conn);
                string cmdText = command.CommandText;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("empId", empID);
                ConnectionDetails.Conn.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader != null && reader.Read())
                    {
                        RequestLeaveDTO oRequestLeaveDTO = new RequestLeaveDTO();
                        oRequestLeaveDTO.empId = reader["empId"].ToString();
                        oRequestLeaveDTO.leaveType = Convert.ToInt32(reader["leaveType"]);
                        oRequestLeaveDTO.leaveTypeText = Enum.GetName(typeof(Enums.LeaveType), oRequestLeaveDTO.leaveType);
                        oRequestLeaveDTO.isFullDay = Convert.ToInt32(reader["isFullDay"]);
                        oRequestLeaveDTO.isFullDayText = Enum.GetName(typeof(Enums.LeaveMode), oRequestLeaveDTO.isFullDay);
                        oRequestLeaveDTO.half = Convert.ToInt32(reader["half"]);
                        oRequestLeaveDTO.halfText = Enum.GetName(typeof(Enums.LeaveHalf), oRequestLeaveDTO.half);
                        oRequestLeaveDTO.fromDate = Convert.ToDateTime(reader["fromDate"]);
                        oRequestLeaveDTO.toDate = Convert.ToDateTime(reader["toDate"]);
                        oRequestLeaveDTO.isApprove = Convert.ToInt32(reader["isApprove"]);
                        oRequestLeaveDTO.discription = Convert.ToString(reader["discription"]);
                        result.Add(oRequestLeaveDTO);
                    }
                    ConnectionDetails.Conn.Close();
                }

                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                ConnectionDetails.Conn.Close();
            }
        }

        public reportSalaryDTO GetSalaryData(string empID,int month,int year)
        {
            reportSalaryDTO result = new reportSalaryDTO();
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.Clear();
                sb.AppendLine(" SELECT ");
                sb.AppendLine("empId,");
                sb.AppendLine("noOfFullDay,");
                sb.AppendLine("noOfHalfDay,");
                sb.AppendLine("NoPay,");
                sb.AppendLine("Basic,");
                sb.AppendLine("bonus,");
                sb.AppendLine("deduction,");
                sb.AppendLine("salary,");
                sb.AppendLine("discription1,");
                sb.AppendLine("discription2,");
                sb.AppendLine("month,");
                sb.AppendLine("year");
                sb.AppendLine(" FROM tblSalary ");
                sb.AppendLine(" WHERE 1=1 ");
                sb.AppendLine(" AND (empId=@empId)");
                sb.AppendLine(" AND (month=@month)");
                sb.AppendLine(" AND (year=@year)");

                SqlCommand command = new SqlCommand(sb.ToString(), ConnectionDetails.Conn);
                string cmdText = command.CommandText;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("empId", empID);
                command.Parameters.AddWithValue("month", month);
                command.Parameters.AddWithValue("year", year);
                ConnectionDetails.Conn.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader != null && reader.Read())
                    {
                        result.empId = reader["empId"].ToString();
                        result.NoPay = Convert.ToInt32(reader["NoPay"]);
                        result.NoPayAmount = result.NoPay * 1000;
                        result.Basic = Convert.ToDouble(reader["Basic"]);
                        result.bonus = Convert.ToDouble(reader["bonus"]);
                        result.deduction = Convert.ToDouble(reader["deduction"]);
                        result.salary = Convert.ToDouble(reader["salary"]);
                        result.discription1 = reader["discription1"].ToString();
                        result.discription2 = reader["discription2"].ToString();
                        result.month = Convert.ToInt32(reader["month"]);
                        result.year = Convert.ToInt32(reader["year"]);
                    }
                    ConnectionDetails.Conn.Close();
                }

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool ChangeUserData(UserDTO user)
        {
            StringBuilder sb = new StringBuilder();
            bool result = false;
            try
            {
                sb.Clear();
                sb.AppendLine(" UPDATE tblUser SET");
                sb.AppendLine("userPhoneNo = @userPhoneNo,");
                sb.AppendLine("userPassword = @userPassword,");
                sb.AppendLine("modifiedDateTime = @modifiedDateTime,");
                sb.AppendLine("modifiedUser = @modifiedUser,");
                sb.AppendLine("modifiedMachine = @modifiedMachine");
                sb.AppendLine("WHERE  userID= @userID");

                using (SqlCommand command = new SqlCommand(sb.ToString(), ConnectionDetails.Conn))
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("userID", user.userID);
                    command.Parameters.AddWithValue("userPhoneNo", user.userPhoneNo);
                    command.Parameters.AddWithValue("userPassword", user.userPassword);
                    command.Parameters.AddWithValue("modifiedDateTime", user.modifiedDateTime);
                    command.Parameters.AddWithValue("modifiedUser", user.modifiedUser);
                    command.Parameters.AddWithValue("modifiedMachine", user.modifiedMachine);

                    ConnectionDetails.Conn.Open();
                    if (command.ExecuteNonQuery() > 0)
                        result = true;

                    ConnectionDetails.Conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                ConnectionDetails.Conn.Close();
            }
            return result;
        }

        public bool BookSlot(ParkingDTO oParkingDTO)
        {
            StringBuilder sb = new StringBuilder();
            bool result = false;
            try
            {
                sb.Clear();
                sb.AppendLine(" UPDATE tblParking");
                sb.AppendLine(" SET ");
                sb.AppendLine("cusId=@cusId,");
                sb.AppendLine("time=@time,");
                sb.AppendLine("isBooked=@isBooked");
                sb.AppendLine(" WHERE 1=1");
                sb.AppendLine(" AND (slotNo=@slotNo)");

                using (SqlCommand command = new SqlCommand(sb.ToString(), ConnectionDetails.Conn))
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("cusId", oParkingDTO.cusId);
                    command.Parameters.AddWithValue("slotNo", oParkingDTO.slotNo);
                    command.Parameters.AddWithValue("time", oParkingDTO.time);
                    command.Parameters.AddWithValue("isBooked", oParkingDTO.isBooked);
                    ConnectionDetails.Conn.Open();
                    if (command.ExecuteNonQuery() > 0)
                        result = true;

                    ConnectionDetails.Conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                ConnectionDetails.Conn.Close();
            }
            return result;
        }

        public List<ParkingDTO> GetAllBookedSlots()
        {
            List<ParkingDTO> result = new List<ParkingDTO>();
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.Clear();
                sb.AppendLine(" SELECT ");
                sb.AppendLine("cusId,");
                sb.AppendLine("slotNo,");
                sb.AppendLine("time,");
                sb.AppendLine("isBooked");
                sb.AppendLine("  FROM tblParking ");

                SqlCommand command = new SqlCommand(sb.ToString(), ConnectionDetails.Conn);
                string cmdText = command.CommandText;
                ConnectionDetails.Conn.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader != null && reader.Read())
                    {
                        ParkingDTO oParkingDTO = new ParkingDTO();
                        oParkingDTO.cusId = reader["cusId"].ToString();
                        oParkingDTO.slotNo = Convert.ToInt32(reader["slotNo"]);
                        oParkingDTO.time = Convert.ToDateTime(reader["time"]);
                        oParkingDTO.isBooked = Convert.ToInt32(reader["isBooked"]);
                        result.Add(oParkingDTO);
                    }
                    ConnectionDetails.Conn.Close();
                }

                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                ConnectionDetails.Conn.Close();
            }
        }

        public bool UpdateEmailsettings(EmailDTO oEmailDTO)
        {
            StringBuilder sb = new StringBuilder();
            bool result = false;
            try
            {
                sb.Clear();
                sb.AppendLine(" UPDATE tblEmailSettings");
                sb.AppendLine(" SET ");
                sb.AppendLine("email=@email,");
                sb.AppendLine("password=@password,");
                sb.AppendLine("host=@host,");
                sb.AppendLine("ssl=@ssl");
                sb.AppendLine(" WHERE 1=1");
                sb.AppendLine(" AND (id= 1)");

                using (SqlCommand command = new SqlCommand(sb.ToString(), ConnectionDetails.Conn))
                {
                    command.Parameters.Clear();
                    //command.Parameters.AddWithValue("id", oEmailDTO.id);
                    command.Parameters.AddWithValue("email", oEmailDTO.email);
                    command.Parameters.AddWithValue("password", Common.EncriptionFcatory.Encrypt(oEmailDTO.password,oEmailDTO.email));
                    command.Parameters.AddWithValue("host", oEmailDTO.host);
                    command.Parameters.AddWithValue("ssl", oEmailDTO.ssl);
                    ConnectionDetails.Conn.Open();
                    if (command.ExecuteNonQuery() > 0)
                        result = true;

                    ConnectionDetails.Conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                ConnectionDetails.Conn.Close();
            }
            return result;
        }

        public EmailDTO GetEmailDetails()
        {
            EmailDTO result = new EmailDTO();
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.Clear();
                sb.AppendLine(" SELECT ");
                sb.AppendLine("email,");
                sb.AppendLine("password,");
                sb.AppendLine("host,");
                sb.AppendLine("ssl");
                sb.AppendLine(" FROM tblEmailSettings ");
                sb.AppendLine(" WHERE 1=1 ");
                sb.AppendLine(" AND (id=1)");

                SqlCommand command = new SqlCommand(sb.ToString(), ConnectionDetails.Conn);
                string cmdText = command.CommandText;
                ConnectionDetails.Conn.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader != null && reader.Read())
                    {
                        result.email = reader["email"].ToString();
                        result.password = Common.EncriptionFcatory.Decrypt(reader["password"].ToString(),result.email);
                        result.host = reader["host"].ToString();
                        result.ssl = Convert.ToInt32(reader["ssl"]);
                    }
                    ConnectionDetails.Conn.Close();
                }

                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                ConnectionDetails.Conn.Close();
            }
        }
    }
}
