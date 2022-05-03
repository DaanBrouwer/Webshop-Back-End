using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhiteLabelWebshopS3.BAL.Interfaces;
using WhiteLabelWebshopS3.BAL.Models;
using WhiteLabelWebshopS3.DAL;
using WhiteLabelWebshopS3.DAL.Entities;

namespace WhiteLabelWebshopS3.DAL.Repositories
{
    public class ProductRepository : IProducts
    {
        private readonly StoreContext _storeContext;

        public ProductRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public async Task<ProductModel> Delete(int id)
        {
            var entity = _storeContext.Remove(new Product { Id = id }).Entity;
            await _storeContext.SaveChangesAsync();
            return new ProductModel
            {
                Id = entity.Id
            };
        }

        public async Task<ProductModel> Get(int id)
        {
            var product = _storeContext.Products.Select(product => new ProductModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Category = product.Category.Select(c => new CategoryModel
                {
                    Id = c.Id,
                    Name = c.Name
                }),
                Brand = product.Brand,
                Stock = product.Stock
            }).SingleOrDefaultAsync(x => x.Id == id);

            return await product;
        }

        public async Task<List<ProductModel>> Index()
        {

            var products = _storeContext.Products
                .Select(product => new ProductModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Category = product.Category.Select(c => new CategoryModel
                    {
                        Id = c.Id,
                        Name = c.Name
                    }),
                    Brand = product.Brand,
                    Stock = product.Stock

                }).ToListAsync();

            return await products;
        }


        public async Task NewProduct(ProductModel product)
        {
            _storeContext.Add(new Product
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Brand = product.Brand,
                Stock = product.Stock
            });
            await _storeContext.SaveChangesAsync();

        }

        public async Task UpdateProduct(ProductModel product, List<CategoryModel> categoryModels)
        {
            var updateproduct = _storeContext.Products.Update(new Product()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                //Category = updaten van category?
                Brand = product.Brand,
                Stock = product.Stock
            });

            await _storeContext.SaveChangesAsync();

        }
    }
}
