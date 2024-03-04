using Task1_API.Models;
using Task1_API.ViewModels.Customers;

namespace Task1_API.Services
{
    public interface ICustomerService
    {        
        Task<CustomerViewModel?> GetCustomerById(int id);
        Task<CustomerViewModel?> GetCustomer(CustomerViewModel request);
        Task<IEnumerable<CustomerViewModel?>> GetCustomers();
        Task<CustomerViewModel?> CreateCustomer(CreateCustomerRequest request);

        Task<CustomerViewModel?> UpdateCustomer(int id, UpdateCustomerRequest request);

        Task DeleteCustomer(int id);
    }
}
