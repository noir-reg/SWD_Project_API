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
                Age = createProductRequest.Age,
                Size = createProductRequest.Size,
                Description = createProductRequest.Description,
                Brand = createProductRequest.Brand,
                Origin = createProductRequest.Origin,
                IsPreorder = createProductRequest.IsPreorder,
                IsGift = createProductRequest.IsGift,
                GiftPoint = createProductRequest.GiftPoint,
                Capacity = createProductRequest.Capacity

            });
            if (_context.SaveChanges() >= 1)
                return true;
            return false;
        }

        public ProductResponse GetProductById(int id)
        {
            return _context.Products.Where(x => x.Id == id && x.IsAvailable != 0).Select(x => new ProductResponse
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Discount = x.Discount,
                Category = x.Category,
                Stock = x.Stock,
                IsAvailable = x.IsAvailable,
                QuantitySold = x.QuantitySold ,
                Image = x.Image,
                Age = x.Age,
                Size = x.Size,
                Description = x.Description,
                Brand = x.Brand,
                Origin = x.Origin,
                IsPreorder = x.IsPreorder,
                IsGift = x.IsGift,
                GiftPoint = x.GiftPoint,
                Capacity = x.Capacity


            }).FirstOrDefault();
        }
     
        public bool UpdateProduct(UpdateProductRequest updateProductRequest)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == updateProductRequest.Id);
            if (product == null)
                return false;

            // Update only the properties that are provided in the request
            if (updateProductRequest.Name != null)
                product.Name = updateProductRequest.Name;

            if (updateProductRequest.Price != null)
                product.Price = updateProductRequest.Price;

            if (updateProductRequest.Discount != null)
                product.Discount = updateProductRequest.Discount;

            if (updateProductRequest.Category != null)
                product.Category = updateProductRequest.Category.Value;

            if (updateProductRequest.Stock != null)
                product.Stock = updateProductRequest.Stock;

            if (updateProductRequest.IsAvailable != null)
                product.IsAvailable = updateProductRequest.IsAvailable;

            if (updateProductRequest.QuantitySold != null)
                product.QuantitySold = updateProductRequest.QuantitySold;

            if (updateProductRequest.Image != null)
                product.Image = updateProductRequest.Image;

            if (updateProductRequest.Age != null)
                product.Age = updateProductRequest.Age.Value;

            if (updateProductRequest.Size != null)
                product.Size = updateProductRequest.Size;

            if (updateProductRequest.Description != null)
                product.Description = updateProductRequest.Description;

            if (updateProductRequest.Brand != null)
                product.Brand = updateProductRequest.Brand;

            if (updateProductRequest.Origin != null)
                product.Origin = updateProductRequest.Origin;

            if (updateProductRequest.IsPreorder != null)
                product.IsPreorder = updateProductRequest.IsPreorder;

            if (updateProductRequest.IsGift != null)
                product.IsGift = updateProductRequest.IsGift;

            if (updateProductRequest.GiftPoint != null)
                product.GiftPoint = updateProductRequest.GiftPoint;

            if (updateProductRequest.Capacity != null)
                product.Capacity = updateProductRequest.Capacity;

            // Save changes and return success if at least one property was updated
            if (_context.SaveChanges() >= 1)
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
                Image = p.Image,
                Age = p.Age,
                Size = p.Size,
                Description = p.Description,
                Brand = p.Brand,
                Origin = p.Origin,
                IsPreorder = p.IsPreorder,
                IsGift = p.IsGift,
                GiftPoint = p.GiftPoint,
                Capacity = p.Capacity
            }).ToList();
    }
        public IEnumerable<ProductResponse> GetProductsByQuantitySold(int topN)
        {
            return _context.Products
                .Include(p => p.CategoryNavigation)
                 .Where(p => p.IsAvailable != 0)// Include the Category entity
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
                    Image = p.Image,
                    Age = p.Age,
                    Size = p.Size,
                    Description = p.Description,
                    Brand = p.Brand,
                    Origin = p.Origin,
                    IsPreorder = p.IsPreorder,
                    IsGift = p.IsGift,
                    GiftPoint = p.GiftPoint,
                    Capacity = p.Capacity
                }).ToList();
        }
        public IEnumerable<ProductResponse> GetProductsByCategory(int categoryId)
        {
            return _context.Products
                .Include(p => p.CategoryNavigation) // Include the Category entity
                .Where(p => p.Category == categoryId && p.IsAvailable != 0)
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
                    Image = p.Image,
                    Age = p.Age,
                    Size = p.Size,
                    Description = p.Description,
                    Brand = p.Brand,
                    Origin = p.Origin,
                    IsPreorder = p.IsPreorder,
                    IsGift = p.IsGift,
                    GiftPoint = p.GiftPoint,
                    Capacity = p.Capacity
                }).ToList();
        }
        public IEnumerable<ProductResponse> FilterbyCapacity(int CapacityID)
        {
            return _context.Products
               .Where(p => p.Capacity == CapacityID && p.IsAvailable != 0) // Add condition for IsAvailable
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
                    Image = p.Image,
                    Age = p.Age,
                    Size = p.Size,
                    Description = p.Description,
                    Brand = p.Brand,
                    Origin = p.Origin,
                    IsPreorder = p.IsPreorder,
                    IsGift = p.IsGift,
                    GiftPoint = p.GiftPoint,
                    Capacity = p.Capacity
                }).ToList();
        }
        public IEnumerable<ProductResponse> FilterbyAge(int AgeID)
        {
            return _context.Products
               .Where(p => p.Age == AgeID && p.IsAvailable != 0) // Add condition for IsAvailable
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
                    Image = p.Image,
                    Age = p.Age,
                    Size = p.Size,
                    Description = p.Description,
                    Brand = p.Brand,
                    Origin = p.Origin,
                    IsPreorder = p.IsPreorder,
                    IsGift = p.IsGift,
                    GiftPoint = p.GiftPoint,
                    Capacity = p.Capacity
                }).ToList();
        }
        public IEnumerable<ProductResponse> FilterbyBrand(string BrandID)
        {
            return _context.Products
               .Where(p => p.Brand == BrandID && p.IsAvailable != 0) // Add condition for IsAvailable
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
                   Image = p.Image,
                   Age = p.Age,
                   Size = p.Size,
                   Description = p.Description,
                   Brand = p.Brand,
                   Origin = p.Origin,
                   IsPreorder = p.IsPreorder,
                   IsGift = p.IsGift,
                   GiftPoint = p.GiftPoint,
                   Capacity = p.Capacity
               }).ToList();
        }
        public IEnumerable<ProductResponse> FilterbyOrigin(string OriginID)
        {
            return _context.Products
               .Where(p => p.Origin == OriginID && p.IsAvailable != 0) // Add condition for IsAvailable
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
                   Image = p.Image,
                   Age = p.Age,
                   Size = p.Size,
                   Description = p.Description,
                   Brand = p.Brand,
                   Origin = p.Origin,
                   IsPreorder = p.IsPreorder,
                   IsGift = p.IsGift,
                   GiftPoint = p.GiftPoint,
                   Capacity = p.Capacity
               }).ToList();
        }
        public IEnumerable<ProductResponse> FilterbySize(string SizeID)
        {
            return _context.Products
               .Where(p => p.Size == SizeID && p.IsAvailable != 0) // Add condition for IsAvailable
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
                   Image = p.Image,
                   Age = p.Age,
                   Size = p.Size,
                   Description = p.Description,
                   Brand = p.Brand,
                   Origin = p.Origin,
                   IsPreorder = p.IsPreorder,
                   IsGift = p.IsGift,
                   GiftPoint = p.GiftPoint,
                   Capacity = p.Capacity
               }).ToList();
        }
        public IEnumerable<ProductResponse> GetAllProducts()
        {
            return _context.Products
                .Where(p => p.IsAvailable != 0)
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
                     Image = p.Image,
                     Age = p.Age,
                     Size = p.Size,
                     Description = p.Description,
                     Brand = p.Brand,
                     Origin = p.Origin,
                     IsPreorder = p.IsPreorder,
                     IsGift = p.IsGift,
                     GiftPoint = p.GiftPoint,
                     Capacity = p.Capacity
                 }).ToList();
        }
        public IEnumerable<ProductResponse> IsGift()
        {
            return _context.Products
            .Where(p => p.IsGift == true)
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
                 Image = p.Image,
                 Age = p.Age,
                 Size = p.Size,
                 Description = p.Description,
                 Brand = p.Brand,
                 Origin = p.Origin,
                 IsPreorder = p.IsPreorder,
                 IsGift = p.IsGift,
                 GiftPoint = p.GiftPoint,
                 Capacity = p.Capacity
             }).ToList();


        }
    }
}
