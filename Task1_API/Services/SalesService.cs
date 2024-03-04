using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Task1_API.Models;
using Task1_API.ViewModels.Products;
using Task1_API.ViewModels.Sales;

namespace Task1_API.Services
{
    public class SalesService : ISalesService
    {
        private readonly DBContext _context;
        private readonly IMapper _mapper;
        public SalesService(DBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<SalesViewModel?> GetSalesById(int id)
        {
            var sales = await _context.Sales.FirstOrDefaultAsync(product => product.Id == id);
            return _mapper.Map<SalesViewModel>(sales);
        }
        public async Task<IEnumerable<SalesViewModel?>> GetSales()
        {
            var sales = await _context.Sales.ToListAsync();
            return _mapper.Map<List<SalesViewModel>>(sales);
        }
        
        public async Task<SalesViewModel?> CreateSales(CreateSalesRequest request)
        {
            var sales = new Sales
            {
                ProductId = request.ProductId,
                CustomerId= request.CustomerId,
                StoreId =request.StoreId,
                DateSold= request.DateSold,
            };
            _context.Sales.Add(sales);
            await _context.SaveChangesAsync();
            return _mapper.Map<SalesViewModel>(sales);
        }                

        public async Task<SalesViewModel?> UpdateSales(int id, UpdateSalesRequest request)
        {
            var sales = await _context.Sales.FirstOrDefaultAsync(item => item.Id == id);
            if (sales == null)
            {
                return null;
            }
            sales.ProductId = request.ProductId;
            sales.CustomerId = request.CustomerId;
            sales.StoreId = request.StoreId;
            sales.DateSold = request.DateSold;
            _context.Sales.Update(sales);
            await _context.SaveChangesAsync();
            return _mapper.Map<SalesViewModel>(sales);
        }
        public async Task DeleteSales(int id)
        {
            var sales = await _context.Sales.FirstOrDefaultAsync(item => item.Id==id);
            if (sales == null)
            {
                throw new Exception("Invalid ID");
            }
            _context.Sales.Remove(sales);
            await _context.SaveChangesAsync();
        }
    }
}
