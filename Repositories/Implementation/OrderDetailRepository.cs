using BusinessObjects.DTOs;
using BusinessObjects.Models;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementation
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly MilkShopContext _context = new();


        public bool CreateOrderDetail(CreateOrderDetailRequest createOrderDetailRequest)
        {
            _context.OrderDetails.Add(new OrderDetail
            {
                Quantity = createOrderDetailRequest.Quantity,
               // OrderId = createOrderDetailRequest.OrderId,
                Price = createOrderDetailRequest.Price,
                ProductId = createOrderDetailRequest.ProductId

            });
            if (_context.SaveChanges() >= 1)
            {
                ////var cartItem = _context.Carts.
                //// //   Where(x => x.ProductId == createOrderDetailRequest.ProductId && x.AccountId == createOrderDetailRequest.AccountId).FirstOrDefault();
                //if (cartItem != null)
                //{
                //    _context.Carts.Remove(cartItem);
                //    _context.SaveChanges();
                //}
                var product = _context.Products.Find(createOrderDetailRequest.ProductId);
                product.Stock = product.Stock - createOrderDetailRequest.Quantity < 0 ? 0 : product.Stock - createOrderDetailRequest.Quantity;
                product.QuantitySold += createOrderDetailRequest.Quantity;
                if (_context.SaveChanges() >= 1)

                    return true;
            }
            return false;
        }
    }
}
