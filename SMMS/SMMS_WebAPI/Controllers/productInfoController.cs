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
    public class productInfoController : ApiController
    {
        productInfoBL oproductInfoBL = new productInfoBL();

        [HttpPost]
        public IHttpActionResult AddProductInfo(productInfoDTO otblProductInfoDTOs)
        {
            try
            {
                return this.Ok(oproductInfoBL.AddProductInfo(otblProductInfoDTOs));
            }
            catch (Exception ex)
            {

                return this.InternalServerError(ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult deleteProductInfo(string pId)
        {
            try
            {
                return this.Ok(oproductInfoBL.deleteProductInfo(pId));
            }
            catch (Exception ex)
            {

                return this.InternalServerError(ex);
            }
        }

        [HttpPut]
        public IHttpActionResult UpdateProductInfo(productInfoDTO otblProductInfoDTO)
        {
            try
            {
                return this.Ok(oproductInfoBL.UpdateProductInfo( otblProductInfoDTO));
            }
            catch (Exception ex)
            {

                return this.InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult GetProductInfo()
        {
            try
            {
                return this.Ok(oproductInfoBL.GetProductInfo());
            }
            catch (Exception ex)
            {

                return this.InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult SearchProductInfo(string pId)
        {
            try
            {
                return this.Ok(oproductInfoBL.SearchProductInfo(pId));
            }
            catch (Exception ex)
            {

                return this.InternalServerError(ex);
            }
        }

    }
}
