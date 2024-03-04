using Task1_API.ViewModels.Sales;

namespace Task1_API.Services
{
    public interface ISalesService
    {
        Task<SalesViewModel?> GetSalesById(int id);
        Task<IEnumerable<SalesViewModel?>> GetSales();
        Task<SalesViewModel?> CreateSales(CreateSalesRequest request);
        Task<SalesViewModel?> UpdateSales(int id, UpdateSalesRequest request);
        Task DeleteSales(int id);
    }
}
