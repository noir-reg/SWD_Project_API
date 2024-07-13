using BusinessObjects.DTOs;
using BusinessObjects.Models;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Repositories.Implementation
{
    public class CartRepository : ICartRepository
    {
        private readonly MilkShopContext _context = new();

        public bool CreateUserCart(List<CartItem> cart)
        {


            try
            {
                var currentCart = _context.Carts.Where(x => x.AccountId == cart.FirstOrDefault().AccountId)
                    .Select(x => x.Id
                    ).ToList();
                if (currentCart.Any())
                    return false;
                foreach (var item in cart)
                {
                    if (item.Quantity==0)
                    {
                        return false;
                    }
                    _context.Carts.Add(new Cart
                    {
                        Quantity = item.Quantity,
                        AccountId = item.AccountId,
                        Price = item.Price,
                        ProductId = item.ProductId
                    });



                }
                if (_context.SaveChanges() >= 1)
                    return true;
            }
            catch (Exception ex)
            {
                _context.Database.RollbackTransaction();
            }
            return false;



        }


        public List<CartItemResponse> GetCartByUserId(int userId)
        {
            return _context.Carts.Where(x => x.AccountId == userId).Select(x => new CartItemResponse
            {
                Quantity = x.Quantity,
                AccountId = x.AccountId,
                Id = x.Id,
                Price = (decimal)x.Price,
                ProductId = x.ProductId
            }).ToList();
        }

        public bool RemoveCartByUserId(int userId)
        {
            var cart = _context.Carts.Where(x => x.ProductId == userId).ToList();
            _context.RemoveRange(cart);
            if (_context.SaveChanges() >= 1)
                return true;
            return false;

        }

        public bool RemoveCartItems(int[] itemIds)
        {
            if (itemIds.Length == 0)
                return false;
            foreach (var itemId in itemIds)
            {
                var item = _context.Carts.Find(itemId);
                if (item != null)
                    _context.Carts.Remove(item);

            }

            return _context.SaveChanges() >= 1;

        }

        public bool UpdateUserCart(List<CartItemResponse> cart)
        {
            try
            {
                var currentCart = _context.Carts.Where(x => x.AccountId == cart.FirstOrDefault().AccountId)
                    .Select(x => x.Id
                    ).ToList();
                if (!currentCart.Any())
                    return false;
                foreach (var item in cart)
                {
                    if (item.Quantity == 0)
                    {
                        return false;
                    }
                    if (!currentCart.Contains(item.Id))
                    {
                        _context.Carts.Add(new Cart
                        {
                            Quantity = item.Quantity,
                            AccountId = item.AccountId,
                            Price = item.Price,
                            ProductId = item.ProductId
                        });

                    }
                    else
                    {
                        var currentItem = _context.Carts.Find(item.Id);
                        currentItem.Quantity = item.Quantity;
                        currentItem.Price = item.Price;

                    }
                }
                if (_context.SaveChanges() >= 1)
                    return true;
            }
            catch (Exception ex)
            {
                _context.Database.RollbackTransaction();
            }
            return false;
        }


    }
}
