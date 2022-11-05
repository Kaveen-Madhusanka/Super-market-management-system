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
    public class OrderController : ApiController
    {
        orderBL oorderBL = new orderBL();
        [HttpPost]
        public IHttpActionResult addOrder(List<orderDTO> order)
        {
            return this.Ok(oorderBL.addOrder(order));
        }

        [HttpPut]
        public IHttpActionResult updateProductQuntity(List<orderDTO> order)
        {
            return this.Ok(oorderBL.updateProductQuntity(order));
        }
    }
}
