using BusinessObjects.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface IOrderRepository

    {
        public CreateOrderResponse CreateOrder(CreateOrderRequest createOrderRequest);
        public List<OrderResponse> GetOrdersByUserId(int userId, string? status);
        public bool UpdateOrderStatus(int orderId, int? staffId,string status);
        public OrderResponse GetOrderById(int id);
        public List<OrderResponse> GetOrders(string? status);
        public bool ConfirmOrder(int orderId);
    }
}
