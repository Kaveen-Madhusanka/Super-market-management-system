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
    public class StockDAL
    {
        public bool updateStock(productDTO oproductDTO)
        {
            StringBuilder sb = new StringBuilder();
            bool result = false;
            try
            {
                sb.Clear();
                sb.Append("UPDATE [tblProduct]");
                sb.Append(" SET ");
                sb.Append(" pQuntity=@pQuntity,");
                sb.Append(" modifiedDateTime=@modifiedDateTime,");
                sb.Append(" modifiedUser=@modifiedUser,");
                sb.Append(" modifiedMachine=@modifiedMachine ");
                sb.Append(" WHERE pId = @pId");

                using (SqlCommand command = new SqlCommand(sb.ToString(), ConnectionDetails.Conn))
                {
                    command.Parameters.Clear();
                    string x = command.CommandText;
                    command.Parameters.AddWithValue("pId", oproductDTO.pId);
                    command.Parameters.AddWithValue("pQuntity", oproductDTO.pQuntity);
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
    }
}
