using CakeShopAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShopAPI.Services
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly CakeShopDbContext _dbContext;

        public InvoiceRepository(CakeShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateInvoiceFromMoMo(string partnerCode, string orderId, 
            string requestId, long amount, string orderInfo, string orderType, 
            long transId, int resultCode, string message, string payType, 
            long responseTime, string extraData, string signature)
        {
            Invoice newInvoice = new Invoice()
            {
                PaymentDate = DateTime.Now,
                OrderGuid = Guid.Parse(orderId)
            };

            _dbContext.Invoices.Add(newInvoice);
            _dbContext.SaveChanges();
        }
    }
}
