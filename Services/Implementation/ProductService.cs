using BusinessObjects.DTOs;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IProductService _repository;
        public ProductService(IProductService repository)
        {
            _repository = repository;
        }
        public bool CreateProduct(CreateProductRequest createProductRequest)
        {
            return _repository.CreateProduct(createProductRequest);
        }

        public ProductResponse GetProcutById(int id)
        {
            return _repository.GetProcutById(id);
        }

        public bool UpdateProduct(UpdateProductRequest updateProductRequest)
        {
            return _repository.UpdateProduct(updateProductRequest);
        }
        public bool DeleteProduct(int id)
        {
            return _repository.DeleteProduct(id);
        }
        public IEnumerable<ProductResponse> SearchProducts(string keyword)
        {
            return _repository.SearchProducts(keyword);
        }
        public IEnumerable<ProductResponse> GetProductsByQuantitySold(int topN)
        {
            return _repository.GetProductsByQuantitySold(topN);
        }
        public IEnumerable<ProductResponse> GetProductsByCategory(int categoryId)
        {
            return _repository.GetProductsByCategory(categoryId);
        }
    }
}
