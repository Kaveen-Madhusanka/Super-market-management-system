using SMMS.IMGT.DAL;
using SMMS.IMGT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMMS.IMGT.BL
{
    public class productBL
    {
        ProductDAL oProductDAL = new ProductDAL();
        public bool addProduct(productDTO oproductDTO)
        {
            return oProductDAL.addProduct(oproductDTO);
        }

        public bool deleteProduct(string pId)
        {
            return oProductDAL.deleteProduct(pId);
        }
        public bool updateProduct(productDTO oproductDTO)
        {
            return oProductDAL.updateProduct(oproductDTO);
        }

        public List<productDTO> searchProduct(string pId)
        {
            return oProductDAL.searchProduct(pId);
        }

        public List<productDTO> GetProducts()
        {
            return oProductDAL.GetProducts();
        }
    }
}
