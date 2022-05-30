using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebshopTests.Stubs;
using WhiteLabelWebshopS3.BAL.Models;
using WhiteLabelWebshopS3.BAL.Services;

namespace WebshopTests
{
    [TestClass]
    public class ProductTests
    {

        [TestMethod]
        public async Task GetAllProducts()
        {
            //Arrange
            ProductStub products = new ProductStub();
            ProductService productService = new ProductService(products);

            //Act
            List<ProductModel> expectedList = new List<ProductModel>()
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

            List<ProductModel> foundproducts = await productService.Index();
            //Assert
            Assert.AreEqual(expectedList.Count, foundproducts.Count);
        }

        [TestMethod]
        public async Task GetOneProduct()
        {
            //Arrange
            ProductStub products = new ProductStub();
            ProductService productService = new ProductService(products);

            //Act
            ProductModel result = await productService.Get(1);
            var expectedresult = new ProductModel
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
            };
            //Assert
            Assert.AreEqual(expectedresult.Name, result.Name);
        }

        [TestMethod]
        public async Task AddNewProductAsync()
        {
            //Arrange
            ProductStub products = new ProductStub();
            ProductService productService = new ProductService(products);

            //Act
            ProductModel expectedresult = new ProductModel
            {
                Id = 5,
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
            };
            await productService.NewProduct(expectedresult);
            ProductModel result = await productService.Get(expectedresult.Id);

            //Assert
            Assert.AreEqual(expectedresult.Id, result.Id);
        }

        [TestMethod]
        public async Task UpdateProduct()
        {
            //Arrange
            ProductStub products = new ProductStub();
            ProductService productService = new ProductService(products);

            //Act
            ProductModel updateproduct = await productService.UpdateProduct(new ProductModel
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
            });
            ProductModel product = await productService.Get(1);
            //Assert
            Assert.AreEqual(product.Name, updateproduct.Name);
        }

        [TestMethod]
        public async Task DeleteProduct()
        {
            //Arrange
            ProductStub products = new ProductStub();
            ProductService productService = new ProductService(products);

            //Act
            await productService.Delete(2);

            List<ProductModel> expectedresult = await productService.Index();
            var result = 1;
            //Assert
            Assert.AreEqual(result, expectedresult.Count);
        }
    }
}