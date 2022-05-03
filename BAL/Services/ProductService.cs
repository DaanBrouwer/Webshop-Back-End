using System.Collections.Generic;
using System.Threading.Tasks;
using WhiteLabelWebshopS3.BAL.Interfaces;
using WhiteLabelWebshopS3.BAL.Models;

namespace WhiteLabelWebshopS3.BAL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProducts _products;

        public ProductService(IProducts products)
        {
            _products = products;
        }

        public async Task<List<ProductModel>> Index()
        {
            return await _products.Index();
        }

        public async Task<ProductModel> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ProductModel> NewProduct(ProductModel product)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ProductModel> UpdateProduct(ProductModel product, List<CategoryModel> categoryModels)
        {
            throw new System.NotImplementedException();
        }
        public async Task<ProductModel> Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
