using AutoMapper;
using Inventory.Data;
using Inventory.Data.Sqlite.Model;

namespace Inventory.Mapping
{
    public class CustomerMapping : Profile
    {
        public CustomerMapping()
        {
            CreateMap<Customer, CustomerDto>()
                .ForMember(x => x.CustomerId, x => x.MapFrom(y => y.CustomerID))
                .ForMember(x => x.Email, x => x.MapFrom(y => y.EmailAddress))
                .ForMember(x => x.CountryName, x => x.MapFrom(y => y.EmailAddress));
        }
    }
}