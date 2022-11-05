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
    public class orderDAL
    {
        public bool addOrder(List<orderDTO> order)
        {
            StringBuilder sb = new StringBuilder();
            bool result = false;
            try
            {
                sb.Clear();
                sb.AppendLine(" INSERT INTO tblOrder VALUES(");
                sb.AppendLine("@billNo,");
                sb.AppendLine("@pid,");
                sb.AppendLine("@quantity,");
                sb.AppendLine("@discount,");
                sb.AppendLine("@subTotal,");
                sb.AppendLine("@modifiedDateTime,");
                sb.AppendLine("@modifiedUser,");
                sb.AppendLine("@modifiedMachine)");


                using (SqlCommand command = new SqlCommand(sb.ToString(), ConnectionDetails.Conn))
                {
                    ConnectionDetails.Conn.Open();
                    for (int i = 0; i < order.Count; i++)
                    {
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("billNo", order[i].billNo);
                        command.Parameters.AddWithValue("pid", order[i].pid);
                        command.Parameters.AddWithValue("quantity", order[i].quantity);
                        command.Parameters.AddWithValue("discount", order[i].discount);
                        command.Parameters.AddWithValue("subTotal", order[i].subTotal);
                        command.Parameters.AddWithValue("modifiedDateTime", order[i].modifiedDateTime);
                        command.Parameters.AddWithValue("modifiedUser", order[i].modifiedUser);
                        command.Parameters.AddWithValue("modifiedMachine", order[i].modifiedMachine);


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

        public bool updateProductQuntity(List<orderDTO> order)
        {
            StringBuilder sb = new StringBuilder();
            bool result = false;
            try
            {
                sb.Clear();
                sb.Append("UPDATE tblProduct \n");
                sb.Append("SET pQuntity = pQuntity - @pQuntity \n");
                sb.Append("WHERE pId = @pId");

                using (SqlCommand command = new SqlCommand(sb.ToString(), ConnectionDetails.Conn))
                {
                    ConnectionDetails.Conn.Open();
                    for (int i = 0; i < order.Count; i++)
                    {
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("pid", order[i].pid);
                        command.Parameters.AddWithValue("pQuntity", order[i].quantity);
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
    }
}
