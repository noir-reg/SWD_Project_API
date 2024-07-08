using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.DTOs;
using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Interface;

namespace Repositories.Implementation
{
    public class DeliveryRepository : IDeliveryRepository
    {
        private readonly MilkShopContext _context = new();



        public bool CreateDelivery(int orderId, int deliveryManId)
        {
            var check = _context.Deliveries.Where(x => x.OrderId == orderId).FirstOrDefault();
            if (check != null)
                return false;
            var deliveryMan = _context.Accounts.Find(deliveryManId);
            if (deliveryMan != null)
            {
                if (deliveryMan.Roleid != 4)
                    return false;
                var orderStatus = _context.OrderStatuses.Where(x => x.OrderId == orderId).Select(x => x.OrderStatus1)
                    .FirstOrDefault();
                if (orderStatus == null)
                    return false;
                if (orderStatus.Equals("Accepted", StringComparison.OrdinalIgnoreCase))
                {
                    _context.Deliveries.Add(new Delivery
                    {
                        OrderId = orderId,
                        DeliveryManId = deliveryManId
                    });
                    var oldOrderStatus = _context.OrderStatuses.FirstOrDefault(x => x.OrderId == orderId);
                    oldOrderStatus.OrderStatus1 = "On-delivering";
                    return (_context.SaveChanges() >= 1);
                }
            }
            return false;
        }

        public bool DeleteDelivery(int deliveryId)
        {
            var delivery = _context.Deliveries.Include(x => x.Order).ThenInclude(x => x.OrderStatuses).FirstOrDefault(x => x.Id == deliveryId);
            if (delivery == null) return false;
            var status = delivery.Order.OrderStatuses.FirstOrDefault().OrderStatus1;
            if (status.Equals("On-delivering", StringComparison.OrdinalIgnoreCase))
            {
                _context.Deliveries.Remove(delivery);
                var oldStatus = _context.OrderStatuses.FirstOrDefault(x => x.OrderId == delivery.OrderId);
                oldStatus.OrderStatus1 = "Accepted";
                return _context.SaveChanges() >= 1;
            }

            return false;
        }

        public List<DeliveryOrder> GetAllDeliveryOrders()
        {
            return _context.Deliveries
                .Include(x => x.Order).ThenInclude(x => x.OrderStatuses)
                .Include(x => x.Order).ThenInclude(x => x.Customer)
                .Include(x => x.DeliveryMan)
                .Include(x => x.Order).ThenInclude(x => x.Payment)
                .Select(x => new DeliveryOrder
                {
                    Id = x.Id,
                    CustomerName = x.Order.Customer.Fullname,
                    CustomerId = x.Order.CustomerId,
                    DeliveryManName = x.DeliveryMan.Fullname,
                    DeliveryManId = x.DeliveryManId,
                    OrderId = x.OrderId,
                    Phone = x.Order.Customer.Phone,
                    Address = x.Order.Customer.Address,
                    Total = x.Order.Total,
                    PaymentMethod = x.Order.Payment.Method,
                    Status = x.Order.OrderStatuses.FirstOrDefault().OrderStatus1
                }).ToList();
        }

        public List<DeliveryOrder> GetDeliveryOrdersByDeliveryManId(int deliveryManId)
        {
            return _context.Deliveries

                .Include(x => x.Order).ThenInclude(x => x.OrderStatuses)
                .Include(x => x.Order).ThenInclude(x => x.Customer)
                .Include(x => x.DeliveryMan)
                .Include(x => x.Order).ThenInclude(x => x.Payment).Where(x => x.DeliveryManId == deliveryManId && x.Order.OrderStatuses.FirstOrDefault().OrderStatus1
                    .Equals("On-delivering"))
                .Select(x => new DeliveryOrder
                {
                    Id = x.Id,
                    CustomerName = x.Order.Customer.Fullname,
                    CustomerId = x.Order.CustomerId,
                    DeliveryManName = x.DeliveryMan.Fullname,
                    DeliveryManId = x.DeliveryManId,
                    OrderId = x.OrderId,
                    Phone = x.Order.Customer.Phone,
                    Address = x.Order.Customer.Address,
                    Total = x.Order.Total,
                    PaymentMethod = x.Order.Payment.Method,
                    Status = x.Order.OrderStatuses.FirstOrDefault().OrderStatus1
                }).ToList();
        }
        public List<DeliveryOrder> GetDeliveredOrdersByDeliveryManId(int deliveryManId)
        {
            return _context.Deliveries

                .Include(x => x.Order).ThenInclude(x => x.OrderStatuses)
                .Include(x => x.Order).ThenInclude(x => x.Customer)
                .Include(x => x.DeliveryMan)
                .Include(x => x.Order).ThenInclude(x => x.Payment).Where(x => x.DeliveryManId == deliveryManId && x.Order.OrderStatuses.FirstOrDefault().OrderStatus1
                    .Equals("Delivered"))
                .Select(x => new DeliveryOrder
                {
                    Id = x.Id,
                    CustomerName = x.Order.Customer.Fullname,
                    CustomerId = x.Order.CustomerId,
                    DeliveryManName = x.DeliveryMan.Fullname,
                    DeliveryManId = x.DeliveryManId,
                    OrderId = x.OrderId,
                    Phone = x.Order.Customer.Phone,
                    Address = x.Order.Customer.Address,
                    Total = x.Order.Total,
                    PaymentMethod = x.Order.Payment.Method,
                    Status = x.Order.OrderStatuses.FirstOrDefault().OrderStatus1
                }).ToList();
        }
    }
}
