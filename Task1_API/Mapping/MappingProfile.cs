using AutoMapper;
using Task1_API.Models;
using Task1_API.ViewModels.Customers;
using Task1_API.ViewModels.Products;
using Task1_API.ViewModels.Sales;
using Task1_API.ViewModels.Store;

namespace Task1_API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerViewModel>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<Store, StoreViewModel>();
            CreateMap<Sales, SalesViewModel>();
        }
    }
}
