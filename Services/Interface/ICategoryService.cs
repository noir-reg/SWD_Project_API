using BusinessObjects.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface ICategoryService
    {
        CategoryResponse GetCategoryById(int id);
        bool CreateCategory(CreateCategoryRequest createCategoryRequest);
        bool UpdateCategory(UpdateCategoryRequest updateCategoryRequest);
        bool DeleteCategory(int id);
    }
}
