using System;
using System.Web.Http;
using Bill.Core.Interfaces;
using log4net;

namespace Bill.API.Controllers
{
    namespace Controllers
    {
        public class BillController : ApiController
        {
            private readonly IBillService _billService;
            private readonly ILog _log;
            public BillController(IBillService billService, ILog log)
            {
                _billService = billService;
                _log = log;
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
                catch (Exception ex)
                {
                    _log.Error("BillController - error in Get method", ex);
                    return BadRequest();
                }                
            }
        }
    }
}