using SMMS.SalesMGT.DAL;
using SMMS.SalesMGT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMMS.SalesMGT.BL
{
    public class SalesBL
    {
        SalesDAL oSalesDAL = new SalesDAL();

        public bool addSales(_SalesDTO o_SalesDTO)
        {
            return oSalesDAL.addSales(o_SalesDTO);
        }

        public string GetLastBillNO(string userID)
        {
            return oSalesDAL.GetLastBillNO(userID);
        }

        public List<_SalesDTO> GetDataToSalesReport(int year, int month)
        {
            return oSalesDAL.GetDataToSalesReport(year, month);
        }
    }
}
