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
    public class EmployeeDAL
    {
        public bool AddEmployee(EmployeeDTO employee)
        {
            StringBuilder sb = new StringBuilder();
            bool result = false;
            try
            {
                sb.Clear();
                sb.AppendLine(" INSERT INTO tblEmployee VALUES(");
                sb.AppendLine("@empId,");
                sb.AppendLine("@empName,");
                sb.AppendLine("@empEmail,");
                sb.AppendLine("@empContact,");
                sb.AppendLine("@empAddress,");
                sb.AppendLine("@empDepartment,");
                sb.AppendLine("@empType,");
                sb.AppendLine("@empDOB,");
                sb.AppendLine("@modifiedDateTime,");
                sb.AppendLine("@modifiedUser,");
                sb.AppendLine("@modifiedMachine)");

                using (SqlCommand command = new SqlCommand(sb.ToString(), ConnectionDetails.Conn))
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("empId", employee.empId);
                    command.Parameters.AddWithValue("empName", employee.empName);
                    command.Parameters.AddWithValue("empEmail", employee.empEmail);
                    command.Parameters.AddWithValue("empContact", employee.empContact);
                    command.Parameters.AddWithValue("empAddress", employee.empAddress);
                    command.Parameters.AddWithValue("empDepartment", employee.empDepartment);
                    command.Parameters.AddWithValue("empType", employee.empType);
                    command.Parameters.AddWithValue("empDOB", employee.empDOB);
                    command.Parameters.AddWithValue("modifiedDateTime", employee.modifiedDateTime);
                    command.Parameters.AddWithValue("modifiedUser", employee.modifiedUser);
                    command.Parameters.AddWithValue("modifiedMachine", employee.modifiedMachine);

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
        public bool UpdateEmployee(EmployeeDTO employee)
        {
            StringBuilder sb = new StringBuilder();
            bool result = false;
            try
            {
                sb.Clear();
                sb.AppendLine(" UPDATE tblEmployee");
                sb.AppendLine(" SET ");
                sb.AppendLine("empName=@empName,");
                sb.AppendLine("empEmail=@empEmail,");
                sb.AppendLine("empContact=@empContact,");
                sb.AppendLine("empAddress=@empAddress,");
                sb.AppendLine("empDepartment=@empDepartment,");
                sb.AppendLine("empType=@empType,");
                sb.AppendLine("empDOB=@empDOB,");
                sb.AppendLine("modifiedDateTime=@modifiedDateTime,");
                sb.AppendLine("modifiedUser=@modifiedUser,");
                sb.AppendLine("modifiedMachine=@modifiedMachine");
                sb.AppendLine(" WHERE 1=1");
                sb.AppendLine(" AND (empId=@empId)");

                using (SqlCommand command = new SqlCommand(sb.ToString(), ConnectionDetails.Conn))
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("empName", employee.empName);
                    command.Parameters.AddWithValue("empEmail", employee.empEmail);
                    command.Parameters.AddWithValue("empContact", employee.empContact);
                    command.Parameters.AddWithValue("empAddress", employee.empAddress);
                    command.Parameters.AddWithValue("empDepartment", employee.empDepartment);
                    command.Parameters.AddWithValue("empType", employee.empType);
                    command.Parameters.AddWithValue("empDOB", employee.empDOB);
                    command.Parameters.AddWithValue("empId", employee.empId);
                    command.Parameters.AddWithValue("modifiedDateTime", employee.modifiedDateTime);
                    command.Parameters.AddWithValue("modifiedUser", employee.modifiedUser);
                    command.Parameters.AddWithValue("modifiedMachine", employee.modifiedMachine);

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
        public bool DeleteEmployee(string empId)
        {
            StringBuilder sb = new StringBuilder();
            bool result = false;
            try
            {
                sb.Clear();
                sb.Append("DELETE FROM  [tblEmployee]");
                sb.Append("WHERE 1=1");
                sb.Append("AND empId = @empId");

                using (SqlCommand command = new SqlCommand(sb.ToString(), ConnectionDetails.Conn))
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("empId", empId);
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
        public List<EmployeeDTO> SearchEmployee(EmployeeDTO employee)
        {
            try
            {
                List<EmployeeDTO> result = new List<EmployeeDTO>();
                StringBuilder sb = new StringBuilder();
                try
                {
                    sb.Clear();
                    sb.AppendLine(" SELECT ");
                    sb.AppendLine("empId,");
                    sb.AppendLine("empName,");
                    sb.AppendLine("empEmail,");
                    sb.AppendLine("empContact,");
                    sb.AppendLine("empAddress,");
                    sb.AppendLine("empDepartment,");
                    sb.AppendLine("empType,");
                    sb.AppendLine("empDOB");
                    sb.AppendLine(" FROM tblEmployee ");
                    sb.AppendLine(" WHERE 1=1 ");
                    sb.AppendLine(" AND (empId=@empId)");

                    SqlCommand command = new SqlCommand(sb.ToString(), ConnectionDetails.Conn);
                    command.Parameters.AddWithValue("empId", employee.empId);
                    ConnectionDetails.Conn.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader != null && reader.Read())
                        {
                            EmployeeDTO oemployee = new EmployeeDTO();
                            oemployee.empId = reader["empId"].ToString();
                            oemployee.empName = reader["empName"].ToString();
                            oemployee.empEmail = reader["empEmail"].ToString();
                            oemployee.empContact = reader["empContact"].ToString();
                            oemployee.empAddress = reader["empAddress"].ToString();
                            oemployee.empDepartment = reader["empDepartment"].ToString();
                            oemployee.empType = Convert.ToInt32(reader["empType"]);
                            oemployee.empTypeText = Enum.GetName(typeof(Enums.EmployeeType), oemployee.empType);
                            oemployee.empDOB = Convert.ToDateTime(reader["empDOB"]);
                            result.Add(oemployee);
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
        public List<EmployeeDTO> GetEmployees()
        {
            try
            {
                List<EmployeeDTO> result = new List<EmployeeDTO>();
                StringBuilder sb = new StringBuilder();
                try
                {
                    sb.Clear();
                    sb.AppendLine(" SELECT ");
                    sb.AppendLine("empId,");
                    sb.AppendLine("empName,");
                    sb.AppendLine("empEmail,");
                    sb.AppendLine("empContact,");
                    sb.AppendLine("empAddress,");
                    sb.AppendLine("empDepartment,");
                    sb.AppendLine("empType,");
                    sb.AppendLine("empDOB");
                    sb.AppendLine(" FROM tblEmployee ");

                    SqlCommand command = new SqlCommand(sb.ToString(), ConnectionDetails.Conn);
                    ConnectionDetails.Conn.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader != null && reader.Read())
                        {
                            EmployeeDTO oemployee = new EmployeeDTO();
                            oemployee.empId = reader["empId"].ToString();
                            oemployee.empName = reader["empName"].ToString();
                            oemployee.empEmail = reader["empEmail"].ToString();
                            oemployee.empContact = reader["empContact"].ToString();
                            oemployee.empAddress = reader["empAddress"].ToString();
                            oemployee.empDepartment = reader["empDepartment"].ToString();
                            oemployee.empType = Convert.ToInt32(reader["empType"]);
                            oemployee.empTypeText = Enum.GetName(typeof(Enums.EmployeeType), oemployee.empType);
                            oemployee.empDOB = Convert.ToDateTime(reader["empDOB"]);
                            result.Add(oemployee);
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
        public EmployeeDTO GetEmployee(string empId)
        {
            try
            {
                EmployeeDTO oemployee = new EmployeeDTO();
                StringBuilder sb = new StringBuilder();
                try
                {
                    sb.Clear();
                    sb.AppendLine(" SELECT ");
                    sb.AppendLine("empId,");
                    sb.AppendLine("empName,");
                    sb.AppendLine("empEmail,");
                    sb.AppendLine("empContact,");
                    sb.AppendLine("empAddress,");
                    sb.AppendLine("empDepartment,");
                    sb.AppendLine("empType,");
                    sb.AppendLine("empDOB");
                    sb.AppendLine(" FROM tblEmployee ");
                    sb.AppendLine(" WHERE 1=1 ");
                    sb.AppendLine(" AND (empId=@empId)");

                    SqlCommand command = new SqlCommand(sb.ToString(), ConnectionDetails.Conn);
                    command.Parameters.AddWithValue("empId", empId);
                    ConnectionDetails.Conn.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader != null && reader.Read())
                        {
                            oemployee.empId = reader["empId"].ToString();
                            oemployee.empName = reader["empName"].ToString();
                            oemployee.empEmail = reader["empEmail"].ToString();
                            oemployee.empContact = reader["empContact"].ToString();
                            oemployee.empAddress = reader["empAddress"].ToString();
                            oemployee.empDepartment = reader["empDepartment"].ToString();
                            oemployee.empType = Convert.ToInt32(reader["empType"]);
                            oemployee.empTypeText = Enum.GetName(typeof(Enums.EmployeeType), oemployee.empType);
                            oemployee.empDOB = Convert.ToDateTime(reader["empDOB"]);
                        }
                        ConnectionDetails.Conn.Close();
                    }

                    return oemployee;
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
