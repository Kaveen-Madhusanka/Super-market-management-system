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
    public class StockController : ApiController
    {
        StockBL oStockBL = new StockBL();

        [HttpPut]
        public IHttpActionResult updateStock(productDTO oproductDTO)
        {
            return this.Ok(oStockBL.updateStock(oproductDTO));
        }
    }
}
