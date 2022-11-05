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
    public class productInfoDAL
    {
        public bool AddProductInfo(productInfoDTO otblProductInfoDTOs)
        {
            bool result = false;
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(" INSERT INTO tblProductInfo VALUES(");
                sb.AppendLine("@pId,");
                sb.AppendLine("@uQuntity,");
                sb.AppendLine("@minQuntity,");
                sb.AppendLine("@maxQuntity,");
                sb.AppendLine("@modifiedDateTime,");
                sb.AppendLine("@modifiedUser,");
                sb.AppendLine("@modifiedMachine)");

                string CommandText = sb.ToString();
                using (SqlCommand command = new SqlCommand(sb.ToString(), ConnectionDetails.Conn))
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("pId", otblProductInfoDTOs.pId);
                    command.Parameters.AddWithValue("uQuntity", otblProductInfoDTOs.uQuntity);
                    command.Parameters.AddWithValue("minQuntity", otblProductInfoDTOs.minQuntity);
                    command.Parameters.AddWithValue("maxQuntity", otblProductInfoDTOs.maxQuntity);
                    command.Parameters.AddWithValue("modifiedDateTime", otblProductInfoDTOs.modifiedDateTime);
                    command.Parameters.AddWithValue("modifiedUser", otblProductInfoDTOs.modifiedUser);
                    command.Parameters.AddWithValue("modifiedMachine", otblProductInfoDTOs.modifiedMachine);
                    ConnectionDetails.Conn.Open();
                    if (command.ExecuteNonQuery() > 0)
                        result = true;

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

        public bool deleteProductInfo(string pId)
        {
            bool result = false;
            try
            {

                StringBuilder sb = new StringBuilder();
                sb.AppendLine(" DELETE FROM tblProductInfo");
                sb.AppendLine(" WHERE 1=1");
                sb.AppendLine(" AND (pId=@pId)");

                string CommandText = sb.ToString();

                using (SqlCommand command = new SqlCommand(sb.ToString(), ConnectionDetails.Conn))
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("pId", pId);
                    ConnectionDetails.Conn.Open();
                    if (command.ExecuteNonQuery() > 0)
                        result = true;

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

        public bool UpdateProductInfo(productInfoDTO otblProductInfoDTO)
        {
            try
            {
                bool result = false;
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(" UPDATE tblProductInfo");
                sb.AppendLine(" SET ");
                sb.AppendLine("uQuntity=@uQuntity,");
                sb.AppendLine("minQuntity=@minQuntity,");
                sb.AppendLine("maxQuntity=@maxQuntity,");
                sb.AppendLine("modifiedDateTime=@modifiedDateTime,");
                sb.AppendLine("modifiedUser=@modifiedUser,");
                sb.AppendLine("modifiedMachine=@modifiedMachine");
                sb.AppendLine(" WHERE 1=1");
                sb.AppendLine(" AND (pId=@pId)");

                using (SqlCommand command = new SqlCommand(sb.ToString(), ConnectionDetails.Conn))
                {
                    string CommandText = sb.ToString();
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("pId", otblProductInfoDTO.pId);
                    command.Parameters.AddWithValue("uQuntity", otblProductInfoDTO.uQuntity);
                    command.Parameters.AddWithValue("minQuntity", otblProductInfoDTO.minQuntity);
                    command.Parameters.AddWithValue("maxQuntity", otblProductInfoDTO.maxQuntity);
                    command.Parameters.AddWithValue("modifiedDateTime", otblProductInfoDTO.modifiedDateTime);
                    command.Parameters.AddWithValue("modifiedUser", otblProductInfoDTO.modifiedUser);
                    command.Parameters.AddWithValue("modifiedMachine", otblProductInfoDTO.modifiedMachine);
                    ConnectionDetails.Conn.Open();
                    if (command.ExecuteNonQuery() > 0)
                        result = true;

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

        public List<productInfoDTO> GetProductInfo()
        {
            List<productInfoDTO> results = new List<productInfoDTO>();
            try
            {

                StringBuilder sb = new StringBuilder();
                sb.AppendLine(" SELECT ");
                sb.AppendLine("pId,");
                sb.AppendLine("uQuntity,");
                sb.AppendLine("minQuntity,");
                sb.AppendLine("maxQuntity,");
                sb.AppendLine("modifiedDateTime,");
                sb.AppendLine("modifiedUser,");
                sb.AppendLine("modifiedMachine");
                sb.AppendLine("  FROM tblProductInfo ");

                SqlCommand command = new SqlCommand(sb.ToString(), ConnectionDetails.Conn);
                ConnectionDetails.Conn.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader != null && reader.Read())
                    {
                        productInfoDTO result = new productInfoDTO();
                        result.pId = reader["pId"].ToString();
                        result.uQuntity = Convert.ToInt32(reader["uQuntity"]);
                        result.minQuntity = Convert.ToInt32(reader["minQuntity"].ToString());
                        result.maxQuntity = Convert.ToInt32(reader["maxQuntity"]);
                        results.Add(result);
                    }
                    ConnectionDetails.Conn.Close();
                }

                return results;
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

        public List<productInfoDTO> SearchProductInfo(string pId)
        {
            List<productInfoDTO> results = new List<productInfoDTO>();
            try
            {

                StringBuilder sb = new StringBuilder();
                sb.AppendLine(" SELECT ");
                sb.AppendLine("pId,");
                sb.AppendLine("uQuntity,");
                sb.AppendLine("minQuntity,");
                sb.AppendLine("maxQuntity,");
                sb.AppendLine("modifiedDateTime,");
                sb.AppendLine("modifiedUser,");
                sb.AppendLine("modifiedMachine");
                sb.AppendLine("  FROM tblProductInfo ");
                sb.AppendLine(" WHERE 1=1");
                sb.AppendLine(" AND (pId=@pId)");

                SqlCommand command = new SqlCommand(sb.ToString(), ConnectionDetails.Conn);
                string CommandText = sb.ToString();
                command.Parameters.AddWithValue("pId", pId);
                ConnectionDetails.Conn.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader != null && reader.Read())
                    {
                        productInfoDTO result = new productInfoDTO();
                        result.pId = reader["pId"].ToString();
                        result.uQuntity = Convert.ToInt32(reader["uQuntity"]);
                        result.minQuntity = Convert.ToInt32(reader["minQuntity"].ToString());
                        result.maxQuntity = Convert.ToInt32(reader["maxQuntity"]);
                        results.Add(result);
                    }
                    ConnectionDetails.Conn.Close();
                }

                return results;
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
