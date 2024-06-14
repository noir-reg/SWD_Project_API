using BusinessObjects.DTOs;
using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementation
{
    public class ProductRepository : IProductRespository
    {
        private readonly MilkShopContext _context = new();
        public bool CreateProduct(CreateProductRequest createProductRequest)
        {
            _context.Products.Add(new Product
            {
                 
                  Name = createProductRequest.Name,
                  Price = createProductRequest.Price,
                  Discount = createProductRequest.Discount,
                  Category = createProductRequest.Category,
                  Stock = createProductRequest.Stock,
                  IsAvailable = createProductRequest.IsAvailable,
                  QuantitySold = createProductRequest.QuantitySold,
                  Image = createProductRequest.Image,
            });
            if (_context.SaveChanges() >= 1)
                return true;
            return false;
        }

        public ProductResponse GetProductById(int id)
        {
            return _context.Products.Where(x => x.Id == id).Select(x => new ProductResponse
            {
                Name = x.Name,
                Price = x.Price,
                Discount = x.Discount,
                Category = x.Category,
                Stock = x.Stock,
                IsAvailable = x.IsAvailable,
                QuantitySold = x.QuantitySold,
                Image = x.Image,


            }).FirstOrDefault();
        }
     
        public bool UpdateProduct(UpdateProductRequest updateProductRequest)
        {
            var acc = _context.Products.Where(x => x.Id == updateProductRequest.Id).FirstOrDefault();
            if (acc != null)
                return false;
            acc.Name = updateProductRequest.Name;
            acc.Price = updateProductRequest.Price;
            acc.Discount = updateProductRequest.Discount;
            acc.Category = updateProductRequest.Category;
            acc.Stock = updateProductRequest.Stock; 
            acc.IsAvailable = updateProductRequest.IsAvailable;
            acc.QuantitySold = updateProductRequest.QuantitySold;
            acc.Image = updateProductRequest.Image;
            if(_context.SaveChanges()>=1)
                return true;
            return false;
        }
        public bool DeleteProduct(int id)
        {
            
                var acc = _context.Products.Where(x => x.Id == id).FirstOrDefault();
                if (acc == null)
                    return false; // Return false if the product is not found

                _context.Products.Remove(acc);

                return _context.SaveChanges() >= 1;
            

        }
          public IEnumerable<ProductResponse> SearchProducts(string keyword)
    {
        return _context.Products
            .Where(p => p.Name.Contains(keyword) || p.CategoryNavigation.CategoryName.Contains(keyword))
            .Select(p => new ProductResponse
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Discount = p.Discount,
                Category = p.Category,
                Stock = p.Stock,
                IsAvailable = p.IsAvailable,
                QuantitySold = p.QuantitySold,
                Image = p.Image
            }).ToList();
    }
        public IEnumerable<ProductResponse> GetProductsByQuantitySold(int topN)
        {
            return _context.Products
                .Include(p => p.CategoryNavigation) // Include the Category entity
                .OrderByDescending(p => p.QuantitySold)
                .Take(topN)
                .Select(p => new ProductResponse
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Discount = p.Discount,
                    Category = p.Category,
                    Stock = p.Stock,
                    IsAvailable = p.IsAvailable,
                    QuantitySold = p.QuantitySold,
                    Image = p.Image
                }).ToList();
        }
        public IEnumerable<ProductResponse> GetProductsByCategory(int categoryId)
        {
            return _context.Products
                .Include(p => p.CategoryNavigation) // Include the Category entity
                .Where(p => p.Category == categoryId)
                .Select(p => new ProductResponse
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Discount = p.Discount,
                    Category = p.Category,
                    Stock = p.Stock,
                    IsAvailable = p.IsAvailable,
                    QuantitySold = p.QuantitySold,
                    Image = p.Image
                }).ToList();
        }
    }
}
