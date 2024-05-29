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

            public CreateOrderResponse CreateOrder(CreateOrderRequest createOrderRequest)
        {
          return  _orderRepository.CreateOrder(createOrderRequest);
        }

        public List<OrderResponse> GetOrdersByUserId(int userId, string? status)
        {
           return _orderRepository.GetOrdersByUserId(userId,status);
        }

        public bool UpdateOrderStatus(int orderId, string status)
        {
            return _orderRepository.UpdateOrderStatus(orderId,status);
        }
    }
}
