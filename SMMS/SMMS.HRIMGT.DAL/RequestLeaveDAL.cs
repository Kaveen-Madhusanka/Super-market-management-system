using SMMS.Common;
using SMMS.HRIMGT.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMMS.HRIMGT.DAL
{
    public class RequestLeaveDAL
    {
        public List<empRequestedLeaveDTo> GetRequestLeavesDetails()
        {
            List<empRequestedLeaveDTo> result = new List<empRequestedLeaveDTo>();
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
                sb.AppendLine("isApprove");
                sb.AppendLine(" FROM tblRequestLeaves ");
                sb.AppendLine(" WHERE 1=1 ");
                sb.AppendLine(" AND (isApprove= 0)");

                SqlCommand command = new SqlCommand(sb.ToString(), ConnectionDetails.Conn);
                string cmdText = command.CommandText;
                ConnectionDetails.Conn.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader != null && reader.Read())
                    {
                        empRequestedLeaveDTo oempRequestedLeaveDTo = new empRequestedLeaveDTo();
                        oempRequestedLeaveDTo.empId = reader["empId"].ToString();
                        oempRequestedLeaveDTo.leaveType = Convert.ToInt32(reader["leaveType"]);
                        oempRequestedLeaveDTo.leaveTypeText = Enum.GetName(typeof(Enums.LeaveType), oempRequestedLeaveDTo.leaveType);
                        oempRequestedLeaveDTo.isFullDay = Convert.ToInt32(reader["isFullDay"]);
                        oempRequestedLeaveDTo.isFullDayText = Enum.GetName(typeof(Enums.LeaveMode), oempRequestedLeaveDTo.isFullDay);
                        oempRequestedLeaveDTo.half = Convert.ToInt32(reader["half"]);
                        oempRequestedLeaveDTo.halfText = Enum.GetName(typeof(Enums.LeaveHalf), oempRequestedLeaveDTo.half);
                        oempRequestedLeaveDTo.fromDate = Convert.ToDateTime(reader["fromDate"]);
                        oempRequestedLeaveDTo.toDate = Convert.ToDateTime(reader["toDate"]);
                        oempRequestedLeaveDTo.isApprove = Convert.ToInt32(reader["isApprove"]);
                        oempRequestedLeaveDTo.discription = Convert.ToString(reader["discription"]);
                        result.Add(oempRequestedLeaveDTo);
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

        public bool ApproveLeave(empRequestedLeaveDTo oempRequestedLeaveDTo)
        {
            StringBuilder sb = new StringBuilder();
            bool result = false;
            try
            {
                sb.Clear();
                sb.AppendLine(" UPDATE tblRequestLeaves");
                sb.AppendLine(" SET ");
                sb.AppendLine("isApprove=@isApprove,");
                sb.AppendLine("modifiedDateTime=@modifiedDateTime,");
                sb.AppendLine("modifiedUser=@modifiedUser,");
                sb.AppendLine("modifiedMachine=@modifiedMachine");
                sb.AppendLine(" WHERE 1=1");
                sb.AppendLine(" AND (empId=@empId)");
                sb.AppendLine(" AND (fromDate=@fromDate)");

                using (SqlCommand command = new SqlCommand(sb.ToString(), ConnectionDetails.Conn))
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("empId", oempRequestedLeaveDTo.empId);
                    command.Parameters.AddWithValue("fromDate", oempRequestedLeaveDTo.fromDate);
                    command.Parameters.AddWithValue("isApprove", oempRequestedLeaveDTo.isApprove);
                    command.Parameters.AddWithValue("modifiedDateTime", oempRequestedLeaveDTo.modifiedDateTime);
                    command.Parameters.AddWithValue("modifiedUser", oempRequestedLeaveDTo.modifiedUser);
                    command.Parameters.AddWithValue("modifiedMachine", oempRequestedLeaveDTo.modifiedMachine);

                    ConnectionDetails.Conn.Open();
                    if (command.ExecuteNonQuery() > 0)
                        result = true;

                    if (oempRequestedLeaveDTo.leaveTypeText != Enums.LeaveType.NoPay.ToString())
                    {
                        DeductLeave(oempRequestedLeaveDTo);
                    }

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

        public int GetNoPaysById(string empId)
        {
            int result = 0;
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.Clear();
                sb.Append("SELECT \n");
                sb.Append("count(*) as Nopay \n");
                sb.Append("FROM tblRequestLeaves \n");
                sb.Append("WHERE empId = @empId \n");
                sb.Append("AND leaveType = @leaveType");

                SqlCommand command = new SqlCommand(sb.ToString(), ConnectionDetails.Conn);
                command.Parameters.Clear();
                command.Parameters.AddWithValue("empId", empId);
                command.Parameters.AddWithValue("leaveType", Convert.ToInt32(Enums.LeaveType.NoPay));
                string cmdText = command.CommandText;
                ConnectionDetails.Conn.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader != null && reader.Read())
                    {
                        result = Convert.ToInt32(reader["Nopay"]);
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

        public bool DeductLeave(empRequestedLeaveDTo oempRequestedLeaveDTo)
        {
            StringBuilder sb = new StringBuilder();
            bool result = false;
            try
            {
                sb.Clear();
                sb.AppendLine(" UPDATE tblEmployeeLeaves");
                sb.AppendLine(" SET ");
                if (oempRequestedLeaveDTo.leaveTypeText == Enums.LeaveType.Casual.ToString())
                {
                    sb.AppendLine("casualLeaveBal=casualLeaveBal -1,"); 
                }
                else if (oempRequestedLeaveDTo.leaveTypeText == Enums.LeaveType.Medical.ToString())
                {
                    sb.AppendLine("medicalLeaveBal=medicalLeaveBal -1,");
                }
                else if (oempRequestedLeaveDTo.leaveTypeText == Enums.LeaveType.Anual.ToString())
                {
                    sb.AppendLine("anualLeaveBal=anualLeaveBal -1,");
                }
                else if (oempRequestedLeaveDTo.leaveTypeText == Enums.LeaveType.Short.ToString())
                {
                    sb.AppendLine("shortLeave=shortLeave -1,");
                }
                sb.AppendLine("modifiedDateTime=@modifiedDateTime,");
                sb.AppendLine("modifiedUser=@modifiedUser,");
                sb.AppendLine("modifiedMachine=@modifiedMachine");
                sb.AppendLine(" WHERE 1=1");
                sb.AppendLine(" AND (empId=@empId)");

                using (SqlCommand command = new SqlCommand(sb.ToString(), ConnectionDetails.Conn))
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("empId", oempRequestedLeaveDTo.empId);
                    command.Parameters.AddWithValue("modifiedDateTime", oempRequestedLeaveDTo.modifiedDateTime);
                    command.Parameters.AddWithValue("modifiedUser", oempRequestedLeaveDTo.modifiedUser);
                    command.Parameters.AddWithValue("modifiedMachine", oempRequestedLeaveDTo.modifiedMachine);

                    if (command.ExecuteNonQuery() > 0)
                        result = true;
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
    }
}
