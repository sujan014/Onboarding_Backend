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
        public async Task<SalesViewModel> GetSalesById(int id)
        {
            try
            {
                var sales = await _context.Sales.FirstOrDefaultAsync(product => product.Id == id);
                if (sales == null)
                {
                    throw new Exception();
                }
                return _mapper.Map<SalesViewModel>(sales);
            }
            catch
            {
                throw new Exception(message: "Error - Invalid Sales Id.");
            }
        }
        public async Task<IEnumerable<SalesViewModel>> GetSales()
        {
            try
            {
                var sales = await _context.Sales.ToListAsync();
                return _mapper.Map<List<SalesViewModel>>(sales);
            }
            catch
            {
                throw new Exception(message: "Error - Cannot get Sales List.");
            }
        }
        
        public async Task<SalesViewModel> CreateSales(CreateSalesRequest request)
        {
            try
            {
                var sales = new Sales
                {
                    ProductId = request.ProductId,
                    CustomerId = request.CustomerId,
                    StoreId = request.StoreId,
                    DateSold = request.DateSold,
                };
                _context.Sales.Add(sales);
                await _context.SaveChangesAsync();
                return _mapper.Map<SalesViewModel>(sales);
            }
            catch
            {
                throw new Exception(message: "Error - Cannot create Sales");
            }
        }                

        public async Task<SalesViewModel?> UpdateSales(int id, UpdateSalesRequest request)
        {
            try
            {
                var sales = await _context.Sales.FirstOrDefaultAsync(item => item.Id == id);
                if (sales == null)
                {
                    throw new Exception();
                }
                sales.ProductId = request.ProductId;
                sales.CustomerId = request.CustomerId;
                sales.StoreId = request.StoreId;
                sales.DateSold = request.DateSold;
                _context.Sales.Update(sales);
                await _context.SaveChangesAsync();
                return _mapper.Map<SalesViewModel>(sales);
            }
            catch
            {
                throw new Exception(message: "Error - Cannot update Sales");
            }
        }
        public async Task DeleteSales(int id)
        {
            try
            {
                var sales = await _context.Sales.FirstOrDefaultAsync(item => item.Id == id);
                if (sales == null)
                {
                    throw new Exception();
                }
                _context.Sales.Remove(sales);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw new Exception(message: "Error - Cannot delete Sales.");
            }
        }
    }
}
