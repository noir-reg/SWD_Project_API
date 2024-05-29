using BusinessObjects.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IOrderService
    {
        public CreateOrderResponse CreateOrder(CreateOrderRequest createOrderRequest);
        public List<OrderResponse> GetOrdersByUserId(int userId,string? status);
    }
}
