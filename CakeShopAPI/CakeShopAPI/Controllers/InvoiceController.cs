using CakeShopAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceController(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        [HttpPost]
        public IActionResult CreateInvoiceMoMo(string partnerCode, string orderId,
            string requestId, long amount, string orderInfo, string orderType,
            long transId, int resultCode, string message, string payType,
            long responseTime, string extraData, string signature)
        {
            try
            {
                _invoiceRepository.CreateInvoiceFromMoMo(partnerCode, orderId,
                    requestId, amount, orderInfo, orderType,
                    transId, resultCode, message, payType,
                    responseTime, extraData, signature);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
