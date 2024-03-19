using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Task1_API.Models;
using Task1_API.ViewModels.Customers;

namespace Task1_API.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly DBContext _context;
        private readonly IMapper _mapper;

        public CustomerService(DBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<CustomerViewModel> GetCustomerById(int id)
        {
            try
            {
                var customer = await _context.Customers.FirstOrDefaultAsync(customer => customer.Id == id);
                if (customer == null)
                {
                    throw new Exception();
                }
                return _mapper.Map<CustomerViewModel>(customer);
            }
            catch
            {
                throw new Exception(message: "Error - Invalid Customer Id.");
            }
        }        
        public async Task<IEnumerable<CustomerViewModel>> GetCustomers()
        {
            try
            {
                var customers = await _context.Customers.ToListAsync();
                return _mapper.Map<List<CustomerViewModel>>(customers);
            }
            catch
            {
                throw new Exception(message: "Error - Cannot get Customers List.");
            }
        }
        public async Task<CustomerViewModel> CreateCustomer(CreateCustomerRequest request)
        {
            try
            {
                var customer = new Customer
                {
                    Name = request.Name,
                    Address = request.Address
                };
                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();
                return _mapper.Map<CustomerViewModel>(customer);
            }
            catch
            {
                throw new Exception(message: "Error - Cannot create Customer");
            }
        }
        public async Task<CustomerViewModel> UpdateCustomer(int id, UpdateCustomerRequest request)
        {
            try
            {
                var customer = await _context.Customers.FirstOrDefaultAsync(entity => entity.Id == id);
                if (customer == null)
                {
                    throw new Exception();
                }
                customer.Name = request.Name;
                customer.Address = request.Address;
                _context.Customers.Update(customer);
                await _context.SaveChangesAsync();
                return _mapper.Map<CustomerViewModel>(customer);
            }
            catch
            {
                throw new Exception(message: "Error - Cannot update Customer.");
            }
        }
        public async Task DeleteCustomer(int id)
        {
            try
            {
                var customer = await _context.Customers.FirstOrDefaultAsync(item => item.Id == id);
                if (customer == null)
                {
                    throw new Exception();
                }
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw new Exception(message: "Error - Cannot delete customer.");
            }
        }
    }
}
