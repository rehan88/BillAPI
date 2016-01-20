using System;
using System.Web.Http;
using Bill.Core.Interfaces;

namespace Bill.API.Controllers
{
    namespace Controllers
    {
        public class BillController : ApiController
        {
            private readonly IBillService _billService;
            public BillController(IBillService billService)
            {
                _billService = billService;                
            }

            [HttpGet]         
            public IHttpActionResult Get()
            {
                try
                {
                    var bill = _billService.GetBill();
                    if (string.IsNullOrEmpty(bill))
                    {
                        return BadRequest();
                    }
                    return Ok(bill);
                }
                catch (Exception)
                {
                    return BadRequest();
                }                
            }
        }
    }
}