using BusinessObjects.DTOs;
using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementation;

public class OrderRepository : IOrderRepository
{
    private readonly MilkShopContext _context = new();
    public CreateOrderResponse CreateOrder(CreateOrderRequest createOrderRequest)
    {
        try
        {
            var order = _context.Orders.Add(new Order
            {
                CustomerId = createOrderRequest.CustomerId,
                PaymentId = createOrderRequest.PaymentId,
                StaffId = createOrderRequest.StaffId,
                Total = createOrderRequest.Total
            });
            if (_context.SaveChanges() <= 0)
                return null;
            _context.OrderStatuses.Add(new OrderStatus
            {
                OrderId = order.Entity.Id,
                OrderDate = createOrderRequest.OrderDate,
                OrderStatus1 = createOrderRequest.OrderStatus1
            });
            if (_context.SaveChanges() >= 1)
                return new CreateOrderResponse { OrederId = order.Entity.Id };
            _context.Remove(order);
        }
        catch (Exception ex)
        {
            throw;
        }
        return null;
    }

    public List<OrderResponse> GetOrdersByUserId(int userId, string? status)
    {
        if (status != null)
        {
            return _context.Orders.Include(x => x.OrderStatuses).Include(x => x.OrderDetails).Include(x => x.Payment).
                Where(x => x.OrderStatuses.FirstOrDefault().OrderStatus1.ToLower().Equals(status.ToLower()) && x.CustomerId.Equals(userId)).Select(x => new OrderResponse
                {
                    CustomerId = x.CustomerId,
                    Id = x.Id,
                    OrderDetails = x.OrderDetails.ToList(),
                    Payment = x.Payment.Method,
                    Status = x.OrderStatuses.FirstOrDefault(),
                    Total = x.Total
                }).ToList();
        }
        return _context.Orders.Include(x => x.OrderStatuses).Include(x => x.OrderDetails).Include(x => x.Payment).
            Where(x => x.CustomerId.Equals(userId)).
               Select(x => new OrderResponse
               {
                   CustomerId = x.CustomerId,
                   Id = x.Id,
                   OrderDetails = x.OrderDetails.ToList(),
                   Payment = x.Payment.Method,
                   Status = x.OrderStatuses.FirstOrDefault(),
                   Total = x.Total
               }).ToList();
    }

    public bool UpdateOrderStatus(int orderId, string status)
    {
        var order = _context.Orders.Include(x => x.OrderStatuses).FirstOrDefault(x => x.Id == orderId);
        order.OrderStatuses.FirstOrDefault().OrderStatus1 = status;
        if (_context.SaveChanges() >= 1)
            return true;
        return false;
    }
}
