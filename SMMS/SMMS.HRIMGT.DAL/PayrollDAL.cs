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
    public class PayrollDAL
    {
        public bool AddSalary(List<SalaryDTO> salary)
        {
            StringBuilder sb = new StringBuilder();
            bool result = false;
            try
            {
                sb.Clear();
                sb.AppendLine(" INSERT INTO tblSalary VALUES(");
                sb.AppendLine("@empId,");
                sb.AppendLine("@noOfFullDay,");
                sb.AppendLine("@noOfHalfDay,");
                sb.AppendLine("@NoPay,");
                sb.AppendLine("@Basic,");
                sb.AppendLine("@bonus,");
                sb.AppendLine("@deduction,");
                sb.AppendLine("@salary,");
                sb.AppendLine("@discription1,");
                sb.AppendLine("@discription2,");
                sb.AppendLine("@month,");
                sb.AppendLine("@year,");
                sb.AppendLine("@modifiedDateTime,");
                sb.AppendLine("@modifiedUser,");
                sb.AppendLine("@modifiedMachine)");

                using (SqlCommand command = new SqlCommand(sb.ToString(), ConnectionDetails.Conn))
                {
                    ConnectionDetails.Conn.Open();

                    for (int i = 0; i < salary.Count; i++)
                    {
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("empId", salary[i].empId);
                        command.Parameters.AddWithValue("noOfFullDay", salary[i].noOfFullDay);
                        command.Parameters.AddWithValue("noOfHalfDay", salary[i].noOfHalfDay);
                        command.Parameters.AddWithValue("NoPay", salary[i].NoPay);
                        command.Parameters.AddWithValue("Basic", salary[i].Basic);
                        command.Parameters.AddWithValue("bonus", salary[i].bonus);
                        command.Parameters.AddWithValue("deduction", salary[i].deduction);
                        command.Parameters.AddWithValue("salary", salary[i].salary);
                        command.Parameters.AddWithValue("discription1", (salary[i].discription1) ?? "");
                        command.Parameters.AddWithValue("discription2", (salary[i].discription2) ?? "");
                        command.Parameters.AddWithValue("month", salary[i].month);
                        command.Parameters.AddWithValue("year", salary[i].year);
                        command.Parameters.AddWithValue("modifiedDateTime", salary[i].modifiedDateTime);
                        command.Parameters.AddWithValue("modifiedUser", salary[i].modifiedUser);
                        command.Parameters.AddWithValue("modifiedMachine", salary[i].modifiedMachine);

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
            BackupAttendance();
            return result;
        }

        public bool BackupAttendance()
        {
            StringBuilder sb = new StringBuilder();
            bool result = false;
            try
            {
                sb.Clear();
                sb.AppendLine("INSERT INTO tblHistoryAttendance");
                sb.AppendLine("SELECT * FROM tblAttendance");

                using (SqlCommand command = new SqlCommand(sb.ToString(), ConnectionDetails.Conn))
                {
                    ConnectionDetails.Conn.Open();

                    if (command.ExecuteNonQuery() > 0)
                        result = true;
                        TruncateAttendance();

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
        public bool TruncateAttendance()
        {
            StringBuilder sb = new StringBuilder();
            bool result = false;
            try
            {
                sb.Clear();
                sb.AppendLine("TRUNCATE TABLE tblAttendance");

                using (SqlCommand command = new SqlCommand(sb.ToString(), ConnectionDetails.Conn))
                {

                    if (command.ExecuteNonQuery() > 0)
                        result = true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }
    }
}
