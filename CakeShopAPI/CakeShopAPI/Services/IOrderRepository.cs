using CakeShopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShopAPI.Services
{
    public interface IOrderRepository
    {
        List<OrderVM> GetOrders();
        PlaceOrderResponseVM Create(OrderVM order);
        void Update(OrderVM order);
        void Delete(OrderVM order);
    }
}
