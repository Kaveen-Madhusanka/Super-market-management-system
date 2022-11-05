using SMMS.Common;
using SMMS.SalesMGT.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMMS.SalesMGT.DAL
{
    public class SalesDAL
    {
        public bool addSales(_SalesDTO o_SalesDTO)
        {
            StringBuilder sb = new StringBuilder();
            bool result = false;
            try
            {
                sb.Clear();
                sb.AppendLine(" INSERT INTO tblSales VALUES(");
                sb.AppendLine("@billNo,");
                sb.AppendLine("@cashier,");
                sb.AppendLine("@total,");
                sb.AppendLine("@discount,");
                sb.AppendLine("@modifiedDateTime,");
                sb.AppendLine("@modifiedUser,");
                sb.AppendLine("@modifiedMachine)");


                using (SqlCommand command = new SqlCommand(sb.ToString(), ConnectionDetails.Conn))
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("billNo", o_SalesDTO.billNo);
                    command.Parameters.AddWithValue("cashier", o_SalesDTO.cashier);
                    command.Parameters.AddWithValue("total", o_SalesDTO.total);
                    command.Parameters.AddWithValue("discount", o_SalesDTO.discount);
                    command.Parameters.AddWithValue("modifiedDateTime", o_SalesDTO.modifiedDateTime);
                    command.Parameters.AddWithValue("modifiedUser", o_SalesDTO.modifiedUser);
                    command.Parameters.AddWithValue("modifiedMachine", o_SalesDTO.modifiedMachine);

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

        public string GetLastBillNO(string userID)
        {
            string result = string.Empty;
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.Clear();
                sb.Append("SELECT \n");
                sb.Append("MAX(CAST(billNo as INT)) AS billNo \n");
                sb.Append("FROM tblSales \n");
                sb.Append("WHERE LEFT(billNo,2) = @userID \n");
                sb.Append("ORDER BY billNo DESC;");

                SqlCommand command = new SqlCommand(sb.ToString(), ConnectionDetails.Conn);
                command.Parameters.AddWithValue("userID", userID);
                ConnectionDetails.Conn.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader != null && reader.Read())
                    {
                        result = reader["billNo"].ToString();
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

        public List<_SalesDTO> GetDataToSalesReport(int year , int month)
        {
            List<_SalesDTO> result = new List<_SalesDTO>();
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.Clear();
                sb.Append("SELECT * \n");
                sb.Append("FROM tblSales \n");
                sb.Append("WHERE 1=1 \n");
                if (month != 0)
                {
                    sb.Append("AND MONTH(modifiedDateTime) = @Month \n"); 
                }
                sb.Append("AND YEAR(modifiedDateTime) = @Year");

                SqlCommand command = new SqlCommand(sb.ToString(), ConnectionDetails.Conn);
                if (month != 0)
                {
                    command.Parameters.AddWithValue("Month", month); 
                }
                command.Parameters.AddWithValue("Year", year);
                ConnectionDetails.Conn.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader != null && reader.Read())
                    {
                        _SalesDTO sales = new _SalesDTO();
                        sales.billNo = reader["billNo"].ToString();
                        sales.cashier = reader["cashier"].ToString();
                        sales.total =Convert.ToDouble(reader["total"]);
                        sales.discount =Convert.ToDouble(reader["discount"]);
                        sales.modifiedDateTime =Convert.ToDateTime(reader["modifiedDateTime"]);
                        result.Add(sales);
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
