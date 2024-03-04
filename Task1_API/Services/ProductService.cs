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
        public async Task<ProductViewModel?> GetProductById(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(product => product.Id == id);
            return _mapper.Map<ProductViewModel>(product);
        }
        public async Task<IEnumerable<ProductViewModel?>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductViewModel>>(products);
        }
        public async Task<ProductViewModel?> CreateProduct(CreateProductRequest request)
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
        public async Task<ProductViewModel?> UpdateProduct(int id, UpdateProductRequest request)
        {
            var product = await _context.Products.FirstOrDefaultAsync(item => item.Id == id);
            if (product == null)
            {
                return null;
            }
            product.Name = request.Name;
            product.Price = request.Price;
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductViewModel>(product);
        }
        public async Task DeleteProduct(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(item => item.Id == id);            
            if (product == null)
            {
                throw new Exception("Invalid Id.");
            }            
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();            
        }        
    }
}
