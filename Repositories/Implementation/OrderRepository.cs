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
            {
                foreach (var detail in createOrderRequest.OrderDetails)
                {
                    _context.OrderDetails.Add(new OrderDetail
                    {
                        Quantity = detail.Quantity,
                        OrderId = order.Entity.Id,
                        Price = detail.Price,
                        ProductId = detail.ProductId
                    });
                    if (_context.SaveChanges() >= 1)
                    {
                        var cartItem = _context.Carts.
                            Where(x => x.ProductId == detail.ProductId && x.AccountId == createOrderRequest.CustomerId).FirstOrDefault();
                        if (cartItem != null)
                        {
                            _context.Carts.Remove(cartItem);
                            _context.SaveChanges();
                        }
                        var product = _context.Products.Find(detail.ProductId);
                        product.Stock = product.Stock - detail.Quantity < 0 ? 0 : product.Stock - detail.Quantity;
                        product.QuantitySold += detail.Quantity;
                        if (_context.SaveChanges() >= 1)

                            return new CreateOrderResponse { OrederId = order.Entity.Id };
                    }
                }

            }


        }
        catch (Exception ex)
        {
            _context.Database.RollbackTransaction();
        }
        return null;
    }

    public OrderResponse GetOrderById(int id)
    {
        var result = _context.Orders.Include(x => x.OrderStatuses).Include(x => x.OrderDetails).Include(x => x.Payment).
           Where(x => x.Id == id).
              Select(x => new OrderResponse
              {
                  CustomerId = x.CustomerId,
                  Id = x.Id,
                  OrderDetails = x.OrderDetails.ToList(),
                  Payment = x.Payment.Method,
                  Status = x.OrderStatuses.FirstOrDefault(),
                  Total = x.Total
              }).FirstOrDefault();
        return result;
    }

    public List<OrderResponse> GetOrders(string? status)
    {
        if (status != null)
        {
            return _context.Orders.Include(x => x.OrderStatuses).Include(x => x.OrderDetails).Include(x => x.Payment).
                Where(x => x.OrderStatuses.FirstOrDefault().OrderStatus1.ToLower().Equals(status.ToLower())).Select(x => new OrderResponse
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

    public bool UpdateOrderStatus(int orderId, int? staffId, string status)
    {
        var order = _context.Orders.Include(x => x.OrderStatuses).FirstOrDefault(x => x.Id == orderId);
        order.OrderStatuses.FirstOrDefault().OrderStatus1 = status;
        order.StaffId = staffId;
        if (_context.SaveChanges() >= 1)
            return true;
        return false;
    }
    public bool ConfirmOrder(int orderId)
    {
        var order = _context.Orders.Include(x => x.OrderStatuses).FirstOrDefault(x => x.Id == orderId);
        order.OrderStatuses.FirstOrDefault().OrderStatus1 = "Delivered";
        
        if (_context.SaveChanges() >= 1)
            return true;
        return false;
    }
}
