using SMMS.IMGT.DAL;
using SMMS.IMGT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMMS.IMGT.BL
{
    public class StockBL
    {
        StockDAL oStockDAL = new StockDAL();
        public bool updateStock(productDTO oproductDTO)
        {
            return oStockDAL.updateStock(oproductDTO);
        }
    }
}
