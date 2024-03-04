using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Task1_API.Models;
using Task1_API.ViewModels.Store;

namespace Task1_API.Services
{
    public class StoreService : IStoreService
    {
        private readonly DBContext _context;
        private readonly IMapper _mapper;

        public StoreService(DBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<StoreViewModel?> GetStoreById(int id)
        {
            var store = await _context.Stores.FirstOrDefaultAsync(x => x.Id == id);            
            return _mapper.Map<StoreViewModel>(store);
        }

        public async Task<IEnumerable<StoreViewModel?>> GetStores()
        {
            var stores = await _context.Stores.ToListAsync();
            return _mapper.Map<List<StoreViewModel>>(stores);
        }
        public async Task<StoreViewModel?> CreateStore(CreateStoreRequest request)
        {
            var store = new Store
            {
                Name = request.Name,
                Address = request.Address,
            };
            _context.Stores.Add(store);
            await _context.SaveChangesAsync();
            return _mapper.Map<StoreViewModel>(store);
        }
        public async Task<StoreViewModel?> UpdateStore(int id, UpdateStoreRequest request)
        {
            var store = await _context.Stores.FirstOrDefaultAsync(item => item.Id == id);
            if (store == null)
            {
                return null;
            }
            store.Name = request.Name;
            store.Address = request.Address;
            _context.Stores.Update(store);
            await _context.SaveChangesAsync();            
            return _mapper.Map<StoreViewModel>(store);
        }

        public async Task DeleteStore(int id)
        {
            var store = await _context.Stores.FirstOrDefaultAsync(item => item.Id == id);
            if (store == null)
            {
                throw new Exception("Invalid Id.");
            }
            _context.Stores.Remove(store);
            await _context.SaveChangesAsync();
        }
    }
}
