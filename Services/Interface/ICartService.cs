using BusinessObjects.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface ICartService
    {
        public List<CartItemResponse> GetCartByUserId(int userId);
        public bool RemoveCartByUserId(int userId);
        public CreateCartResponse CreateUserCart(List<CartItem> cart);
        public bool UpdateUserCart(List<CartItemResponse> cart);
        public bool RemoveCartItems(int[] itemIds);
    }
}
