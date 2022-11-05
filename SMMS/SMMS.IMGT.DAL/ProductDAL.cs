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
    public class ProductDAL
    {
        public bool addProduct(productDTO oproductDTO)
        {
            
            
            StringBuilder sb = new StringBuilder();
            bool result = false;
            try
            {
                sb.Clear();
                sb.Append("INSERT INTO [tblProduct]");
                sb.Append(" VALUES (");
                sb.Append(" @pId,");
                sb.Append(" @pName,");
                sb.Append(" @pCategoery,");
                sb.Append(" @pQuntityType,");
                sb.Append(" @pQuntity,");
                sb.Append(" @pPrice,");
                sb.Append(" @pBarcode,");
                sb.Append(" @sId,");
                sb.Append(" @modifiedDateTime,");
                sb.Append(" @modifiedUser,");
                sb.Append(" @modifiedMachine");
                sb.Append(" )");

                using (SqlCommand command = new SqlCommand(sb.ToString(), ConnectionDetails.Conn))
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("pId", oproductDTO.pId);
                    command.Parameters.AddWithValue("pName", oproductDTO.pName);
                    command.Parameters.AddWithValue("pCategoery", oproductDTO.pCategoery);
                    command.Parameters.AddWithValue("pQuntityType", oproductDTO.pQuntityType);
                    command.Parameters.AddWithValue("pQuntity", oproductDTO.pQuntity);
                    command.Parameters.AddWithValue("pBarcode", oproductDTO.pBarcode);
                    command.Parameters.AddWithValue("pPrice", oproductDTO.pPrice);
                    command.Parameters.AddWithValue("sId", oproductDTO.sId);
                    command.Parameters.AddWithValue("modifiedDateTime", oproductDTO.modifiedDateTime);
                    command.Parameters.AddWithValue("modifiedUser", oproductDTO.modifiedUser);
                    command.Parameters.AddWithValue("modifiedMachine", oproductDTO.modifiedMachine);

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

        public bool deleteProduct(string pId)
        {


            StringBuilder sb = new StringBuilder();
            bool result = false;
            try
            {
                sb.Clear();
                sb.Append("DELETE FROM  [tblProduct]");
                sb.Append("WHERE 1=1");
                sb.Append("AND pId = @pId");

                using (SqlCommand command = new SqlCommand(sb.ToString(), ConnectionDetails.Conn))
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("pId",pId);
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

        public bool updateProduct(productDTO oproductDTO)
        {


            StringBuilder sb = new StringBuilder();
            bool result = false;
            try
            {
                sb.Clear();
                sb.Append("UPDATE [tblProduct]");
                sb.Append(" SET ");
                sb.Append(" pName=@pName,");
                sb.Append(" pCategoery=@pCategoery,");
                sb.Append(" pQuntityType=@pQuntityType,");
                sb.Append(" pQuntity=@pQuntity,");
                sb.Append(" pBarcode=@pBarcode,");
                sb.Append(" pPrice=@pPrice,");
                sb.Append(" sId=@sId,");
                sb.Append(" modifiedDateTime=@modifiedDateTime,");
                sb.Append(" modifiedUser=@modifiedUser,");
                sb.Append(" modifiedMachine=@modifiedMachine ");
                sb.Append(" WHERE pId = @pId");

                using (SqlCommand command = new SqlCommand(sb.ToString(), ConnectionDetails.Conn))
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("pId", oproductDTO.pId);
                    command.Parameters.AddWithValue("pName", oproductDTO.pName);
                    command.Parameters.AddWithValue("pCategoery", oproductDTO.pCategoery);
                    command.Parameters.AddWithValue("pQuntityType", oproductDTO.pQuntityType);
                    command.Parameters.AddWithValue("pQuntity", oproductDTO.pQuntity);
                    command.Parameters.AddWithValue("pBarcode", oproductDTO.pBarcode);
                    command.Parameters.AddWithValue("pPrice", oproductDTO.pPrice);
                    command.Parameters.AddWithValue("sId", oproductDTO.sId);
                    command.Parameters.AddWithValue("modifiedDateTime", oproductDTO.modifiedDateTime);
                    command.Parameters.AddWithValue("modifiedUser", oproductDTO.modifiedUser);
                    command.Parameters.AddWithValue("modifiedMachine", oproductDTO.modifiedMachine);

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

        public List<productDTO> searchProduct(string pId)
        {
           List<productDTO> result = new List<productDTO>();
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.Clear();
                sb.Append("SELECT ");
                sb.Append(" pId,");
                sb.Append(" pName,");
                sb.Append(" pCategoery,");
                sb.Append(" pQuntityType,");
                sb.Append(" pQuntity,");
                sb.Append(" pPrice,");
                sb.Append(" pBarcode,");
                sb.Append(" sId");
                sb.Append(" FROM [tblProduct]");
                sb.Append(" WHERE pId = @pId");

                SqlCommand command = new SqlCommand(sb.ToString(), ConnectionDetails.Conn);
                command.Parameters.AddWithValue("pId", pId);
                ConnectionDetails.Conn.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader != null && reader.Read())
                    {
                        productDTO product = new productDTO();
                        product.pId = reader["pId"].ToString();
                        product.pName = reader["pName"].ToString();
                        product.pCategoery = Convert.ToInt32(reader["pCategoery"]);
                        product.pCategoeryText = Enum.GetName(typeof(Enums.ProductCatogery), product.pCategoery);
                        product.pQuntityType = Convert.ToInt32(reader["pQuntityType"].ToString());
                        product.pQuntityTypeText = Enum.GetName(typeof(Enums.QunitiType), product.pQuntityType);
                        product.pQuntity = Convert.ToDouble(reader["pQuntity"]);
                        product.pPrice = Convert.ToDouble(reader["pPrice"]);
                        product.pBarcode = reader["pBarcode"].ToString();
                        product.sId = reader["sId"].ToString();
                        result.Add(product);
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

        public List<productDTO> GetProducts()
        {
            List<productDTO> result = new List<productDTO>();
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.Clear();
                sb.Append("SELECT ");
                sb.Append(" pId,");
                sb.Append(" pName,");
                sb.Append(" pCategoery,");
                sb.Append(" pQuntityType,");
                sb.Append(" pQuntity,");
                sb.Append(" pPrice,");
                sb.Append(" pBarcode,");
                sb.Append(" sId");
                sb.Append(" FROM [tblProduct]");

                SqlCommand command = new SqlCommand(sb.ToString(), ConnectionDetails.Conn);
                ConnectionDetails.Conn.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader != null && reader.Read())
                    {
                        productDTO product = new productDTO();
                        product.pId = reader["pId"].ToString();
                        product.pName = reader["pName"].ToString();
                        product.pCategoery = Convert.ToInt32(reader["pCategoery"]);
                        product.pCategoeryText = Enum.GetName(typeof(Enums.ProductCatogery), product.pCategoery);
                        product.pQuntityType = Convert.ToInt32(reader["pQuntityType"].ToString());
                        product.pQuntityTypeText = Enum.GetName(typeof(Enums.QunitiType), product.pQuntityType);
                        product.pQuntity = Convert.ToDouble(reader["pQuntity"]);
                        product.pPrice = Convert.ToDouble(reader["pPrice"]);
                        product.pBarcode = reader["pBarcode"].ToString();
                        product.sId = reader["sId"].ToString();
                        result.Add(product);
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
