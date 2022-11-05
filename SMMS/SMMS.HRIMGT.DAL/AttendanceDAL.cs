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
    public class AttendanceDAL
    {
        public bool AddAttendance(List<AttendanceDTO> attendance)
        {
            StringBuilder sb = new StringBuilder();
            bool result = false;
            try
            {
                sb.Clear(); 
                sb.AppendLine(" INSERT INTO tblAttendance VALUES(");
                sb.AppendLine("@empID,");
                sb.AppendLine("@inTime,");
                sb.AppendLine("@outTime,");
                sb.AppendLine("@dateType,");
                sb.AppendLine("@date,");
                sb.AppendLine("@modifiedDateTime,");
                sb.AppendLine("@modifiedUser,");
                sb.AppendLine("@modifiedMachine)");

                using (SqlCommand command = new SqlCommand(sb.ToString(), ConnectionDetails.Conn))
                {
                    ConnectionDetails.Conn.Open();

                    for (int i = 0; i < attendance.Count; i++)
                    {
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("empID", attendance[i].empID);
                        command.Parameters.AddWithValue("inTime", attendance[i].inTime);
                        command.Parameters.AddWithValue("outTime", attendance[i].outTime);
                        command.Parameters.AddWithValue("dateType", attendance[i].dateType);
                        command.Parameters.AddWithValue("date", attendance[i].date);
                        command.Parameters.AddWithValue("modifiedDateTime", attendance[i].modifiedDateTime);
                        command.Parameters.AddWithValue("modifiedUser", attendance[i].modifiedUser);
                        command.Parameters.AddWithValue("modifiedMachine", attendance[i].modifiedMachine);

                        if (command.ExecuteNonQuery() > 0)
                            result = true;
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

        public List<AttendanceDTO> GetAttendance()
        {
            try
            {
                List<AttendanceDTO> result = new List<AttendanceDTO>();
                StringBuilder sb = new StringBuilder();
                try
                {
                    sb.Clear();
                    sb.AppendLine(" SELECT ");
                    sb.AppendLine("*");
                    sb.AppendLine(" FROM tblAttendance ");

                    SqlCommand command = new SqlCommand(sb.ToString(), ConnectionDetails.Conn);
                    ConnectionDetails.Conn.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader != null && reader.Read())
                        {
                            AttendanceDTO oAttendanceDTO = new AttendanceDTO();
                            oAttendanceDTO.empID = reader["empID"].ToString();
                            oAttendanceDTO.inTime = reader["inTime"].ToString();
                            oAttendanceDTO.outTime = reader["outTime"].ToString();
                            oAttendanceDTO.dateType = reader["dateType"].ToString();
                            oAttendanceDTO.date = reader["date"].ToString();
                            result.Add(oAttendanceDTO);
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
            catch (Exception)
            {

                throw;
            }
        }
    }
}
