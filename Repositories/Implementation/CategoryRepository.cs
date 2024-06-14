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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MilkShopContext _context ;

        public CategoryRepository(MilkShopContext context)
        {
            _context = context;
        }
        public bool CreateCategory(CreateCategoryRequest createCategoryRequest)
        {
            var category = new Category
            {
                CategoryName = createCategoryRequest.CategoryName
            };

            _context.Categories.Add(category);
            return _context.SaveChanges() >= 1;
        }

        public bool DeleteCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null) return false;

            _context.Categories.Remove(category);
            return _context.SaveChanges() >= 1;
        }

        public CategoryResponse GetCategoryById(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null) return null;

            return new CategoryResponse
            {
                Id = category.Id,
                CategoryName = category.CategoryName
            };
        }

        public bool UpdateCategory(UpdateCategoryRequest updateCategoryRequest)
        {
            var category = _context.Categories.Find(updateCategoryRequest.Id);
            if (category == null) return false;

            category.CategoryName = updateCategoryRequest.CategoryName;
            return _context.SaveChanges() >= 1;
        }
    }
}
