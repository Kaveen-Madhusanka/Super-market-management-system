using SMMS.Common;
using SMMS.IMGT.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMMS.IMGT.DAL
{
    public class supplierDAL
    {
        public bool addSupplier(supplierDTO oSupplierDTO)
        {


            StringBuilder sb = new StringBuilder();
            bool result = false;
            try
            {
                sb.Clear();
                sb.Append("INSERT INTO [tblSupplier]");
                sb.Append(" VALUES (");
                sb.Append(" @sId,");
                sb.Append(" @sName,");
                sb.Append(" @sAddress,");
                sb.Append(" @sContactNo,");
                sb.Append(" @sEmail,");
                sb.Append(" @pId,");
                sb.Append(" @modifiedDateTime,");
                sb.Append(" @modifiedUser,");
                sb.Append(" @modifiedMachine");
                sb.Append(" )");


                using (SqlCommand command = new SqlCommand(sb.ToString(), ConnectionDetails.Conn))
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("sId", oSupplierDTO.sId);
                    command.Parameters.AddWithValue("sName", oSupplierDTO.sName);
                    command.Parameters.AddWithValue("sAddress", oSupplierDTO.sAddress);
                    command.Parameters.AddWithValue("sContactNo", oSupplierDTO.sContactNo);
                    command.Parameters.AddWithValue("sEmail", oSupplierDTO.sEmail);
                    command.Parameters.AddWithValue("pId", oSupplierDTO.pId);
                    command.Parameters.AddWithValue("modifiedDateTime", oSupplierDTO.modifiedDateTime);
                    command.Parameters.AddWithValue("modifiedUser", oSupplierDTO.modifiedUser);
                    command.Parameters.AddWithValue("modifiedMachine", oSupplierDTO.modifiedMachine);

                    ConnectionDetails.Conn.Open();
                    if (command.ExecuteNonQuery() > 0)
                        result = true;

                    ConnectionDetails.Conn.Close();
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                ConnectionDetails.Conn.Close();
            }
            return result;
        }

        public bool deleteSupplier(string sId)
        {


            StringBuilder sb = new StringBuilder();
            bool result = false;
            try
            {
                sb.Clear();
                sb.Append("DELETE FROM  [tblSupplier]");
                sb.Append("WHERE 1=1");
                sb.Append("AND sId = @sId");

                using (SqlCommand command = new SqlCommand(sb.ToString(), ConnectionDetails.Conn))
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("sId", sId);
                    ConnectionDetails.Conn.Open();
                    if (command.ExecuteNonQuery() > 0)
                        result = true;

                    ConnectionDetails.Conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ConnectionDetails.Conn.Close();
            }
            return result;
        }

        public bool updateSupplier(supplierDTO oSupplierDTO)
        {

            StringBuilder sb = new StringBuilder();
            bool result = false;
            try
            {
                sb.Clear();
                sb.Append("UPDATE [tblSupplier]");
                sb.Append(" SET ");
                sb.Append(" sName=@sName,");
                sb.Append(" sAddress=@sAddress,");
                sb.Append(" sContactNo=@sContactNo,");
                sb.Append(" sEmail=@sEmail,");
                sb.Append(" pId=@pId,");
                sb.Append(" modifiedDateTime=@modifiedDateTime,");
                sb.Append(" modifiedUser=@modifiedUser,");
                sb.Append(" modifiedMachine=@modifiedMachine ");
                sb.Append(" WHERE sId = @sId");

                using (SqlCommand command = new SqlCommand(sb.ToString(), ConnectionDetails.Conn))
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("sId", oSupplierDTO.sId);
                    command.Parameters.AddWithValue("sName", oSupplierDTO.sName);
                    command.Parameters.AddWithValue("sAddress", oSupplierDTO.sAddress);
                    command.Parameters.AddWithValue("sContactNo", oSupplierDTO.sContactNo);
                    command.Parameters.AddWithValue("sEmail", oSupplierDTO.sEmail);
                    command.Parameters.AddWithValue("pId", oSupplierDTO.pId);
                    command.Parameters.AddWithValue("modifiedDateTime", oSupplierDTO.modifiedDateTime);
                    command.Parameters.AddWithValue("modifiedUser", oSupplierDTO.modifiedUser);
                    command.Parameters.AddWithValue("modifiedMachine", oSupplierDTO.modifiedMachine);

                    ConnectionDetails.Conn.Open();
                    if (command.ExecuteNonQuery() > 0)
                        result = true;

                    ConnectionDetails.Conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ConnectionDetails.Conn.Close();
            }
            return result;
        }

        public List<supplierDTO> searchSupplier(string sId)
        {
            List<supplierDTO> result = new List<supplierDTO>();
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.Clear();
                sb.Append("SELECT ");
                sb.Append(" sId,");
                sb.Append(" sName,");
                sb.Append(" sAddress,");
                sb.Append(" sContactNo,");
                sb.Append(" sEmail,");
                sb.Append(" pId");
                sb.Append(" FROM [tblSupplier]");
                sb.Append(" WHERE sId = @sId");

                SqlCommand command = new SqlCommand(sb.ToString(), ConnectionDetails.Conn);
                command.Parameters.AddWithValue("sId", sId);
                ConnectionDetails.Conn.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader != null && reader.Read())
                    {
                        supplierDTO osupplierDTO = new supplierDTO();
                        osupplierDTO.sId = reader["sId"].ToString();
                        osupplierDTO.sName = reader["sName"].ToString();
                        osupplierDTO.sAddress = reader["sAddress"].ToString();
                        osupplierDTO.sContactNo = Convert.ToInt32(reader["sContactNo"].ToString());
                        osupplierDTO.sEmail = reader["sEmail"].ToString();
                        osupplierDTO.pId = reader["pId"].ToString();
                        result.Add(osupplierDTO);
                    }
                    ConnectionDetails.Conn.Close();
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ConnectionDetails.Conn.Close();
            }
        }

        public List<supplierDTO> GetSupplier()
        {
            List<supplierDTO> result = new List<supplierDTO>();
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.Clear();
                sb.Append("SELECT ");
                sb.Append(" sId,");
                sb.Append(" sName,");
                sb.Append(" sAddress,");
                sb.Append(" sContactNo,");
                sb.Append(" sEmail,");
                sb.Append(" pId");
                sb.Append(" FROM [tblSupplier]");

                SqlCommand command = new SqlCommand(sb.ToString(), ConnectionDetails.Conn);
                ConnectionDetails.Conn.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader != null && reader.Read())
                    {
                        supplierDTO osupplierDTO = new supplierDTO();
                        osupplierDTO.sId = reader["sId"].ToString();
                        osupplierDTO.sName = reader["sName"].ToString();
                        osupplierDTO.sAddress = reader["sAddress"].ToString();
                        osupplierDTO.sContactNo = Convert.ToInt32(reader["sContactNo"].ToString());
                        osupplierDTO.sEmail = reader["sEmail"].ToString();
                        osupplierDTO.pId = reader["pId"].ToString();
                        result.Add(osupplierDTO);
                    }
                    ConnectionDetails.Conn.Close();
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ConnectionDetails.Conn.Close();
            }
        }
    }
}
