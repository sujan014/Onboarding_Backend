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
        public async Task<StoreViewModel> GetStoreById(int id)
        {
            try
            {
                var store = await _context.Stores.FirstOrDefaultAsync(x => x.Id == id);
                if (store == null)
                {
                    throw new Exception();
                }
                return _mapper.Map<StoreViewModel>(store);
            }
            catch
            {
                throw new Exception(message: "Error - Invalid Store Id.");
            }
        }

        public async Task<IEnumerable<StoreViewModel>> GetStores()
        {
            try
            {
                var stores = await _context.Stores.ToListAsync();
                return _mapper.Map<List<StoreViewModel>>(stores);
            }
            catch
            {
                throw new Exception(message: "Error - Cannot get Stores List.");
            }
        }
        public async Task<StoreViewModel> CreateStore(CreateStoreRequest request)
        {
            try
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
            catch
            {
                throw new Exception(message: "Error - Cannot create Store");
            }
        }
        public async Task<StoreViewModel> UpdateStore(int id, UpdateStoreRequest request)
        {
            try
            {
                var store = await _context.Stores.FirstOrDefaultAsync(item => item.Id == id);
                if (store == null)
                {
                    throw new Exception();
                }
                store.Name = request.Name;
                store.Address = request.Address;
                _context.Stores.Update(store);
                await _context.SaveChangesAsync();
                return _mapper.Map<StoreViewModel>(store);
            }
            catch
            {
                throw new Exception(message: "Error - Cannot update Store.");
            }
        }

        public async Task DeleteStore(int id)
        {
            try
            {
                var store = await _context.Stores.FirstOrDefaultAsync(item => item.Id == id);
                if (store == null)
                {
                    throw new Exception();
                }
                _context.Stores.Remove(store);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw new Exception(message: "Error - Cannot delete Store.");
            }
        }
    }
}
