using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShopAPI.Services
{
    public interface IInvoiceRepository
    {
        void CreateInvoiceFromMoMo(string partnerCode, string orderId, string requestId,
            long amount, string orderInfo, string orderType, long transId, int resultCode,
            string message, string payType, long responseTime, string extraData, string signature);
    }
}
