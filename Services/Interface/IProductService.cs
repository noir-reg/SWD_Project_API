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
        public ProductResponse GetProductById(int id);
        public bool CreateProduct(CreateProductRequest createProductRequest);
        public bool UpdateProduct(UpdateProductRequest updateProductRequest);
        public bool DeleteProduct(int id);
        IEnumerable<ProductResponse> SearchProducts(string keyword);
        IEnumerable<ProductResponse> GetProductsByQuantitySold(int topN);
        IEnumerable<ProductResponse> GetProductsByCategory(int categoryId);
        IEnumerable<ProductResponse> FilterbyCapacity(int CapacityID);

        IEnumerable<ProductResponse> FilterbyAge(int AgeID);
        IEnumerable<ProductResponse> FilterbyBrand(string BrandID);
        IEnumerable<ProductResponse> FilterbyOrigin(string OriginID);
        IEnumerable<ProductResponse> FilterbySize(string SizeID);
        IEnumerable<ProductResponse> GetAllProducts();
        IEnumerable<ProductResponse> IsGift();
    }
}
