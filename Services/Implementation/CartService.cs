using BusinessObjects.DTOs;
using BusinessObjects.Models;
using Repositories.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class CartService : ICartService
    {   private readonly ICartRepository _repository;
        public CartService(ICartRepository repository) {  _repository = repository; }
        public CreateCartResponse CreateUserCart(List<CartItem> cart)
        {
           return _repository.CreateUserCart(cart);
        }

        public List<CartItemResponse> GetCartByUserId(int userId)
        {
            return _repository.GetCartByUserId(userId);
        }

        public bool RemoveCartByUserId(int userId)
        {
            return _repository.RemoveCartByUserId(userId);
        }

        public bool RemoveCartItems(int[] itemIds)
        {
           return (_repository.RemoveCartItems(itemIds));
        }

        public bool UpdateUserCart(List<CartItemResponse> cart)
        {
            return _repository.UpdateUserCart(cart);
        }
    }
}
