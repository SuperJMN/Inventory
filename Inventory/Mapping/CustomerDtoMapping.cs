using AutoMapper;
using Inventory.Data;
using Inventory.ViewModels.Customers;

namespace Inventory.Mapping
{
    public class CustomerDtoMapping : Profile
    {
        public CustomerDtoMapping()
        {
            CreateMap<CustomerDto, CustomerViewModel>();
        }
    }
}