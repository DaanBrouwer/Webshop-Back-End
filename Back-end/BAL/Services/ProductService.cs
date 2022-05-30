using System.Collections.Generic;
using System.Threading.Tasks;
using WhiteLabelWebshopS3.BAL.Interfaces;
using WhiteLabelWebshopS3.BAL.Models;
using WhiteLabelWebshopS3.DTOs;

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
            //List<ProductModel> allproducts = await _products.Index();
            //List<ProductDTO> productDTOs = new List<ProductDTO>();
            
            //foreach (ProductModel product in allproducts)
            //{
            //    new ProductDTO
            //    {
            //        Id = product.Id,
            //        Name = product.Name,
            //        Description = product.Description,
            //        Price = product.Price,


            //        Brand = product.Brand,
            //        Stock = product.Stock,
                    
            //    }
            //}
            return await _products.Index();
        }

        public async Task<ProductModel> Get(int id)
        {
            return await _products.Get(id);
        }

        public async Task<ProductModel> NewProduct(ProductModel product)
        {
            return await _products.NewProduct(product);
        }

        public async Task<ProductModel> UpdateProduct(ProductModel product)
        {
            return await _products.UpdateProduct(product);
        }
        public async Task<ProductModel> Delete(int id)
        {
            return await _products.Delete(id);
        }
    }
}
