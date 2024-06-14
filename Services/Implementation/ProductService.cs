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
    public class ProductService : IProductService
    {
        private readonly IProductRespository _repository;
        public ProductService(IProductRespository repository)
        {
            _repository = repository;
        }
        public bool CreateProduct(CreateProductRequest createProductRequest)
        {
            return _repository.CreateProduct(createProductRequest);
        }

        public ProductResponse GetProductById(int id)
        {
            return _repository.GetProductById(id);
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
        public IEnumerable<ProductResponse> FilterbyAge(int AgeID)
        {
            return _repository.FilterbyAge(AgeID);
        }
        public IEnumerable<ProductResponse> FilterbyBrand(string BrandID)
        {
            return _repository.FilterbyBrand(BrandID);
        }
        public IEnumerable<ProductResponse> FilterbyOrigin(string OriginID)
        {
            return _repository.FilterbyOrigin(OriginID);
        }
        public IEnumerable<ProductResponse> FilterbyCapacity(int CapacityID)
        {
            return _repository.FilterbyCapacity(CapacityID);
        }
        public IEnumerable<ProductResponse> FilterbySize(string SizeID)
        {
            return _repository.FilterbySize(SizeID);
        }
        public IEnumerable<ProductResponse> GetAllProducts()
        {
            return _repository.GetAllProducts();
        }
        public IEnumerable<ProductResponse> IsGift()
        {
            return _repository.IsGift();
        }

    }
}
