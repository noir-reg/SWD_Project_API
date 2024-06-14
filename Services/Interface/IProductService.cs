using BusinessObjects.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IProductService
    {
        public ProductResponse GetProcutById(int id);
        public bool CreateProduct(CreateProductRequest createProductRequest);
        public bool UpdateProduct(UpdateProductRequest updateProductRequest);
        public bool DeleteProduct(int id);
        IEnumerable<ProductResponse> SearchProducts(string keyword);
        IEnumerable<ProductResponse> GetProductsByQuantitySold(int topN);
        IEnumerable<ProductResponse> GetProductsByCategory(int categoryId);
    }
}
