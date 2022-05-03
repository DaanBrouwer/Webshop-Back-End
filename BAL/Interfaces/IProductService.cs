using System.Collections.Generic;
using System.Threading.Tasks;
using WhiteLabelWebshopS3.BAL.Models;

namespace WhiteLabelWebshopS3.BAL.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductModel>> Index();
        Task<ProductModel> Get(int id);
        Task<ProductModel> NewProduct(ProductModel product);
        Task<ProductModel> UpdateProduct(ProductModel product, List<CategoryModel> categoryModels);
        Task<ProductModel> Delete(int id);

    }
}
