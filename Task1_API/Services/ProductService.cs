using Task1_API.ViewModels.Products;
using Task1_API.ViewModels;
using Task1_API.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Task1_API.Services
{
    public class ProductService : IProductService
    {
        private readonly DBContext _context;
        private readonly IMapper _mapper;

        public ProductService(DBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ProductViewModel> GetProductById(int id)
        {
            try
            {
                var product = await _context.Products.FirstOrDefaultAsync(product => product.Id == id);
                if (product == null)
                {
                    throw new Exception();
                }
                return _mapper.Map<ProductViewModel>(product);
            }
            catch
            {
                throw new Exception(message: "Error - Invalid Product Id.");
            }
        }
        public async Task<IEnumerable<ProductViewModel>> GetProducts()
        {
            try
            {
                var products = await _context.Products.ToListAsync();
                return _mapper.Map<List<ProductViewModel>>(products);
            }
            catch
            {
                throw new Exception(message: "Error - Cannot get Products List.");
            }
        }
        public async Task<ProductViewModel> CreateProduct(CreateProductRequest request)
        {
            try
            {
                var product = new Product
                {
                    Name = request.Name,
                    Price = request.Price,
                };
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return _mapper.Map<ProductViewModel>(product);
            }
            catch
            {
                throw new Exception(message: "Error - Cannot create Product");
            }
        }        
        public async Task<ProductViewModel> UpdateProduct(int id, UpdateProductRequest request)
        {
            try
            {
                var product = await _context.Products.FirstOrDefaultAsync(item => item.Id == id);
                if (product == null)
                {
                    throw new Exception();
                }
                product.Name = request.Name;
                product.Price = request.Price;
                _context.Products.Update(product);
                await _context.SaveChangesAsync();
                return _mapper.Map<ProductViewModel>(product);
            }
            catch
            {
                throw new Exception(message: "Error - Cannot update Product.");
            }
        }
        public async Task DeleteProduct(int id)
        {
            try
            {
                var product = await _context.Products.FirstOrDefaultAsync(item => item.Id == id);
                if (product == null)
                {
                    throw new Exception();
                }
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw new Exception(message: "Error - Cannot delete Product.");
            }
        }        
    }
}
