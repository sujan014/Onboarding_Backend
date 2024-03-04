using Task1_API.ViewModels.Products;
using Task1_API.ViewModels.Store;

namespace Task1_API.Services
{
    public interface IStoreService
    {
        Task<StoreViewModel?> GetStoreById(int id);
        Task<IEnumerable<StoreViewModel?>> GetStores();
        Task<StoreViewModel?> CreateStore(CreateStoreRequest request);
        Task<StoreViewModel?> UpdateStore(int id, UpdateStoreRequest request);
        Task DeleteStore(int id);
    }
}
