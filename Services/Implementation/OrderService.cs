using BusinessObjects.DTOs;
using Repositories.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class OrderService : IOrderService
    {   private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public bool ConfirmOrder(int orderId)
        {
            return _orderRepository.ConfirmOrder(orderId);
        }

        public CreateOrderResponse CreateOrder(CreateOrderRequest createOrderRequest)
        {
          return  _orderRepository.CreateOrder(createOrderRequest);
        }

        public OrderResponse GetOrderById(int id)
        {
            return _orderRepository.GetOrderById(id);
        }

        public List<OrderResponse> GetOrders(string? status)
        {
            return _orderRepository.GetOrders(status);
        }

        public List<OrderResponse> GetOrdersByUserId(int userId, string? status)
        {
           return _orderRepository.GetOrdersByUserId(userId,status);
        }

        public bool UpdateOrderStatus(int orderId, int? staffId, string status)
        {
            return _orderRepository.UpdateOrderStatus(orderId,staffId,status);
        }
    }
}
