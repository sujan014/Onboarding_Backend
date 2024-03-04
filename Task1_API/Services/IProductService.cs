using Task1_API.Models;
using Task1_API.ViewModels;
using Task1_API.ViewModels.Products;

namespace Task1_API.Services
{
    public interface IProductService
    {
        Task<ProductViewModel?> GetProductById(int id);
        Task<IEnumerable<ProductViewModel?>> GetProducts();
        Task<ProductViewModel?> CreateProduct(CreateProductRequest request);
        Task<ProductViewModel?> UpdateProduct(int id, UpdateProductRequest request);
        Task DeleteProduct(int id);
    }
}
