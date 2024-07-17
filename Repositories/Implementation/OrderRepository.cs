using BusinessObjects.DTOs;
using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementation;

public class OrderRepository : IOrderRepository
{
    private readonly MilkShopContext _context = new();

    public CreateOrderResponse CreateOrder(CreateOrderRequest createOrderRequest)
    { // Create new order
         
        
        using var transaction = _context.Database.BeginTransaction();
        try
        {
            var newOrder = new Order
            {
                CustomerId = createOrderRequest.CustomerId,
                PaymentId = createOrderRequest.PaymentId,
                Total = createOrderRequest.Total
            };
            _context.Orders.Add(newOrder);
            _context.SaveChanges();
            // Add order status
            var newOrderStatus = new OrderStatus
            {
                OrderId = newOrder.Id,
                OrderDate = createOrderRequest.OrderDate,
                OrderStatus1 = createOrderRequest.OrderStatus1
            };
            _context.OrderStatuses.Add(newOrderStatus);

            // Add order details and update related entities
            foreach (var detail in createOrderRequest.OrderDetails)
            {
                var newOrderDetail = new OrderDetail
                {
                    Quantity = detail.Quantity,
                    OrderId = newOrder.Id,
                    Price = detail.Price,
                    ProductId = detail.ProductId
                };
                _context.OrderDetails.Add(newOrderDetail);

                // Remove item from cart
                var cartItem = _context.Carts
                    .Where(x => x.ProductId == detail.ProductId && x.AccountId == createOrderRequest.CustomerId)
                    .FirstOrDefault();
                if (cartItem != null)
                {
                    _context.Carts.Remove(cartItem);
                }

                // Update product stock and quantity sold
                var product = _context.Products.Find(detail.ProductId);
                if (product != null)
                {
                    product.Stock = product.Stock - detail.Quantity < 0 ? 0 : product.Stock - detail.Quantity;
                    product.QuantitySold += detail.Quantity;
                }
            }


            //transaction.Commit();
            
            transaction.CommitAsync();
           
            return new CreateOrderResponse { OrederId = newOrder.Id - 1 };
        }
        catch (Exception)
        {
            transaction.Rollback();
            
            return null;
        }
    }



    public OrderResponse GetOrderById(int id)
    {
        var result = _context.Orders.Include(x => x.OrderStatuses).Include(x => x.OrderDetails).Include(x => x.Payment).
           Where(x => x.Id == id && x.OrderDetails.Any()).
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
                Where(x => x.OrderStatuses.FirstOrDefault().OrderStatus1.ToLower().Equals(status.ToLower()) && x.OrderDetails.Any()).Select(x => new OrderResponse
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
                Where(x => x.OrderStatuses.FirstOrDefault().OrderStatus1.ToLower().Equals(status.ToLower()) && x.CustomerId.Equals(userId) && x.OrderDetails.Any()).Select(x => new OrderResponse
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
