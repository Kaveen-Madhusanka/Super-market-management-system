using SMMS.SalesMGT.DAL;
using SMMS.SalesMGT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMMS.SalesMGT.BL
{
    public class orderBL
    {
        orderDAL oorderDAL = new orderDAL();
        public bool addOrder(List<orderDTO> order)
        {
            return oorderDAL.addOrder(order);
        }

        public bool updateProductQuntity(List<orderDTO> order)
        {
            return oorderDAL.updateProductQuntity(order);
        }
    }
}
