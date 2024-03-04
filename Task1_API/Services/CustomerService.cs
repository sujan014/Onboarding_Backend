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
        public async Task<CustomerViewModel?> GetCustomerById(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(customer => customer.Id == id);
            return _mapper.Map<CustomerViewModel>(customer);
            //return customer == null ? null : customer;
            //return customer ?? null;
        }
        public async Task<CustomerViewModel?> GetCustomer(CustomerViewModel request)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(customer =>
                customer.Name == request.Name &&
                customer.Address == request.Address
            );

            //return customer == null ? null : customer;
            return _mapper.Map<CustomerViewModel>(customer);
        }
        public async Task<IEnumerable<CustomerViewModel>> GetCustomers()
        {
            var customers = await _context.Customers.ToListAsync();
            return _mapper.Map<List<CustomerViewModel>>(customers);
            //return customers;
        }
        public async Task<CustomerViewModel?> CreateCustomer(CreateCustomerRequest request)
        {
            var customer = new Customer
            {
                Name = request.Name,
                Address = request.Address
            };
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            //return customer;
            return _mapper.Map<CustomerViewModel>(customer);
        }
        public async Task<CustomerViewModel?> UpdateCustomer(int id, UpdateCustomerRequest request)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(entity => entity.Id == id);
            if (customer == null)
            {
                return null;
            }
            customer.Name = request.Name;
            customer.Address = request.Address;
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
            //return customer;
            return _mapper.Map<CustomerViewModel>(customer);
        }
        public async Task DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(item => item.Id == id);
            if (customer == null)
            {
                throw new Exception("Invalid Id.");
            }
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }
    }
}
