using SMMS.IMGT.DAL;
using SMMS.IMGT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SMMS_WebAPI.Controllers
{
    public class SupplierController : ApiController
    {
        supplierDAL osupplierDAL = new supplierDAL();

        [HttpPost]
        public IHttpActionResult addSupplier(supplierDTO oSupplierDTO)
        {
            if (osupplierDAL.addSupplier(oSupplierDTO))
            {
                return this.Ok(true);
            }
            else
            {
                return this.InternalServerError();
            }
            
        }

        [HttpDelete]
        public IHttpActionResult deleteSupplier(string sId)
        {
            return this.Ok(osupplierDAL.deleteSupplier(sId));
        }

        [HttpPut]
        public IHttpActionResult updateSupplier(supplierDTO oSupplierDTO)
        {
            return this.Ok(osupplierDAL.updateSupplier(oSupplierDTO));
        }

        [HttpGet]
        public IHttpActionResult searchSupplier(string sId)
        {
            return this.Ok(osupplierDAL.searchSupplier(sId));
        }

        [HttpGet]
        public IHttpActionResult GetSupplier()
        {
            return this.Ok(osupplierDAL.GetSupplier());
        }
    }
}
