using CakeShopAPI.Data;
using CakeShopAPI.Models;
using CakeShopAPI.ThirdPartyServices.PaymentGateway.MoMo;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShopAPI.Services
{
    public class OrderRepository : IOrderRepository
    {
        private readonly CakeShopDbContext _dbContext;

        public OrderRepository(CakeShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public PlaceOrderResponseVM Create(OrderVM order)
        {
            Guid orderId = Guid.NewGuid();
            int payMethodId = GetPayMethodId(order.PaymentMethod);
            string paymentLink = null;

            #region CreateOrderHeader
            Order newOrder = new Order()
            {
                guidOrder = orderId,
                UserId = order.UserId,
                Date = DateTime.Now,
                TotalCost = order.TotalCost,
                PaymentMethodId = payMethodId,
            };
            _dbContext.Orders.Add(newOrder);
            #endregion

            #region CreateOrderLines
            foreach (var orderLine in order.orderLines)
            {
                OrderLine newOrderLine = new OrderLine()
                {
                    OrderGuid = orderId,
                    Quantity = orderLine.Quantity,
                    SizeId = GetSizeId(orderLine.Size),
                    ProductId = orderLine.ProductId
                };

                _dbContext.OrderLines.Add(newOrderLine);
            }
            #endregion

            _dbContext.SaveChanges();


            if(order.PaymentMethod == "momo")
            {
                MoMo moMo = new MoMo(order.TotalCost.ToString(), 
                    "Thanh toán tại Tiệm bánh 101", orderId.ToString());
                JObject response = JObject.Parse(moMo.GetResponseFromMoMo());
                paymentLink = response.GetValue("payUrl").ToString();
            }

            PlaceOrderResponseVM placeOrderResponse = new PlaceOrderResponseVM()
            {
                PaymentLink = paymentLink
            };

            return placeOrderResponse;
        }

        public void Delete(OrderVM order)
        {
            throw new NotImplementedException();
        }

        public List<OrderVM> GetOrders()
        {
            throw new NotImplementedException();
        }

        public void Update(OrderVM order)
        {
            throw new NotImplementedException();
        }

        private int GetSizeId(string sizeName)
        {
            int sizeId = (from size in _dbContext.Sizes
                          where size.Name == sizeName
                          select size.Id).FirstOrDefault();

            return sizeId;
        }

        private int GetPayMethodId(string payMethod)
        {
            int payMethodId = (from payMeth in _dbContext.PaymentMethods
                               where payMeth.Name == payMethod
                               select payMeth.Id).FirstOrDefault();

            return payMethodId;
        }

        private void CreateInvoice(Guid orderId)
        {
            Invoice invoice = new Invoice()
            {
                PaymentDate = DateTime.Now,
                OrderGuid = orderId
            };

            _dbContext.Invoices.Add(invoice);
            _dbContext.SaveChanges();
        }

        //private double GetProductPrice(int productId)
        //{
        //    double price = (from pro in _dbContext.Products
        //                    where pro.Id == productId
        //                    select pro.Price).FirstOrDefault();

        //    return price;
        //}
    }
}
