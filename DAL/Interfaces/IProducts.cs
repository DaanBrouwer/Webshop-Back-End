using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhiteLabelWebshopS3.BAL.Models;

namespace WhiteLabelWebshopS3.BAL.Interfaces
{
    public interface IProducts
    {
        Task<ProductModel> Delete(int id);
        Task<ProductModel> Get(int id);
        Task<List<ProductModel>> Index();
        Task NewProduct(ProductModel product);
        Task UpdateProduct(ProductModel product, List<CategoryModel> categoryModels);
    }
}