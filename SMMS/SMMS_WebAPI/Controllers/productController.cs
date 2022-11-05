using SMMS.IMGT.BL;
using SMMS.IMGT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SMMS_WebAPI.Controllers
{
    public class productController : ApiController
    {
        productBL oproductBL = new productBL();

        [HttpPost]
        public bool addProduct(productDTO oproductDTO)
        {
            return oproductBL.addProduct(oproductDTO);
        }
        [HttpDelete]
        public bool deleteProduct(string pId)
        {
            return oproductBL.deleteProduct(pId);
        }

        [HttpPut]
        public bool updateProduct(productDTO oproductDTO)
        {
            return oproductBL.updateProduct(oproductDTO);
        }

        [HttpGet]
        public List<productDTO> searchProduct(string pId)
        {
            return oproductBL.searchProduct(pId);
        }

        [HttpGet]
        public IHttpActionResult GetProducts()
        {
            return this.Ok(oproductBL.GetProducts());
        }
    }
}
