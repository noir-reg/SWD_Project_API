using BusinessObjects.DTOs;
using Repositories.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public CategoryResponse GetCategoryById(int id)
        {
            return _categoryRepository.GetCategoryById(id);
        }

        public bool CreateCategory(CreateCategoryRequest createCategoryRequest)
        {
            return _categoryRepository.CreateCategory(createCategoryRequest);
        }

        public bool UpdateCategory(UpdateCategoryRequest updateCategoryRequest)
        {
            return _categoryRepository.UpdateCategory(updateCategoryRequest);
        }

        public bool DeleteCategory(int id)
        {
            return _categoryRepository.DeleteCategory(id);
        }
    }
}
