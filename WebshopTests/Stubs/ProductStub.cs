using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteLabelWebshopS3.BAL.Interfaces;
using WhiteLabelWebshopS3.BAL.Models;

namespace WebshopTests.Stubs
{
    internal class ProductStub : IProducts
    {

        List<ProductModel> productModels = new List<ProductModel>()
        {
            new ProductModel
            {
                Id = 1,
                Name = "Product1",
                Description = "TestBeschrijving",
                Price = 12,
                Category = new List<CategoryModel>()
                {
                new CategoryModel
                {
                    Id =1,
                    Name = "Testcategorie"
                } 
                },
                OrderDetails = null,
                Brand = "TestBrand",
                Stock = 10
            },
            new ProductModel
            {
                Id = 2,
                Name = "Product1",
                Description = "TestBeschrijving",
                Price = 12,
                Category = new List<CategoryModel>()
                {
                new CategoryModel
                {
                    Id =1,
                    Name = "Testcategorie"
                }
                },
                OrderDetails = null,
                Brand = "TestBrand",
                Stock = 10
            }
        };

        public Task<ProductModel> Delete(int id)
        {
            productModels.Remove(productModels.First(product => product.Id == id));
            return Task.FromResult(new ProductModel
            {
                Id = id
            });
        }

        public Task<ProductModel>? Get(int id)
        {
            var product = productModels.Find(x => x.Id == id);
            if(product == null)
            {
                return null;
            }
            return Task.FromResult(product);


        }

        public Task<List<ProductModel>> Index()
        {
            return Task.FromResult(productModels);
        }

        public Task<ProductModel> NewProduct(ProductModel product)
        {
            productModels.Add(product);
            return Task.FromResult(product);
        }

        public Task<ProductModel> UpdateProduct(ProductModel product)
        {
            var findproduct = productModels.Find(x => x.Id == product.Id); 
            if (findproduct != null)
            {
                productModels[findproduct.Id] = product;
            }
            return Task.FromResult(product);
        }
    }
}
