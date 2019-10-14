using lesson1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.Entitys;

namespace lesson1.Infrastructure.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<Order> GetOrders(string UserName);
        Order GetOrderById(int Id);
        Order CreateOrder(OrderDetailsViewModel OrderDetails, string UserName);

    }
}
