using SMMS.IMGT.DAL;
using SMMS.IMGT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMMS.IMGT.BL
{
    public class productInfoBL
    {
        productInfoDAL oproductInfoDAL = new productInfoDAL();
        public bool AddProductInfo(productInfoDTO otblProductInfoDTOs)
        {
            return oproductInfoDAL.AddProductInfo(otblProductInfoDTOs);
        }

        public bool deleteProductInfo(string pId)
        {
            return oproductInfoDAL.deleteProductInfo(pId);
        }

        public bool UpdateProductInfo(productInfoDTO otblProductInfoDTO)
        {
            return oproductInfoDAL.UpdateProductInfo(otblProductInfoDTO);
        }

        public List<productInfoDTO> GetProductInfo()
        {
            return oproductInfoDAL.GetProductInfo();
        }

        public List<productInfoDTO> SearchProductInfo(string pId)
        {
            return oproductInfoDAL.SearchProductInfo(pId);
        }
    }
}
