using BusinessObjects.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface ICategoryRepository
    {
        public CategoryResponse GetCategoryById(int id);
        public bool CreateCategory(CreateCategoryRequest createCategoryRequest);
        public bool UpdateCategory(UpdateCategoryRequest updateCategoryRequest);
        public bool DeleteCategory(int id);
    }
}
