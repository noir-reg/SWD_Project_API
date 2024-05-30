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
    public class CartRepository : ICartRepository
    {
        private readonly MilkShopContext _context = new();

        public CreateCartResponse CreateUserCart(List<CartItem> cart)
        {
            try
            {
                if (_context.Carts.FirstOrDefault(x => x.AccountId == cart.FirstOrDefault().AccountId) != null)
                {
                    return new CreateCartResponse
                    {
                        IsSuccess = false,
                        Message = "You have already had a cart. Remove or submit an order for this cart before create a new one"
                    };
                }

                foreach (var item in cart)
                {
                    _context.Carts.Add(new Cart
                    {
                        Quantity = item.Quantity,
                        AccountId = item.AccountId,
                        Price = item.Price,
                        ProductId = item.ProductId,
                    });
                }
                if (_context.SaveChanges() >= 1)
                {
                    return new CreateCartResponse
                    {
                        IsSuccess = true,
                        Message = "Create successfully"
                    };
                }
            }
            catch (Exception ex)
            {
                _context.Database.RollbackTransaction();
            }
            return new CreateCartResponse
            {
                IsSuccess = false,
                Message = "Can not create cart"
            };
        }

        public List<CartItemResponse> GetCartByUserId(int userId)
        {
            return _context.Carts.Where(x => x.AccountId == userId).Select(x => new CartItemResponse
            {
                Quantity = x.Quantity,
                AccountId = x.AccountId,
                Id = x.Id,
                Price = x.Price,
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

        public bool RemoveCartItem(int itemId)
        {
            var item = _context.Carts.Find(itemId);
            _context.Carts.Remove(item);
            if (_context.SaveChanges() >= 1)
                return true;
            return false;

        }

        public bool UpdateUserCart(List<CartItemResponse> cart)
        {
            try
            {
                var currentCart = _context.Carts.Where(x => x.AccountId == cart.FirstOrDefault().AccountId)
                    .Select(x => x.Id
                    ).ToList();
                if(currentCart==null)
                    return false;
                foreach (var item in cart)
                {
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
