using SMMS.SalesMGT.BL;
using SMMS.SalesMGT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SMMS_WebAPI.Controllers
{
    public class SalesController : ApiController
    {
        SalesBL oSalesBL = new SalesBL();
        [HttpPost]
        public IHttpActionResult addSales(_SalesDTO o_SalesDTO)
        {
            return this.Ok(oSalesBL.addSales(o_SalesDTO));
        }
        [HttpGet]
        public IHttpActionResult GetLastBillNO(string userID)
        {
            return this.Ok(oSalesBL.GetLastBillNO(userID));
        }
        [HttpGet]
        public List<_SalesDTO> GetDataToSalesReport(int year, int month)
        {
            return oSalesBL.GetDataToSalesReport(year, month);
        }
    }
}
