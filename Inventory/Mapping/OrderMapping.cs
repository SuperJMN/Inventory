using AutoMapper;
using Inventory.Data;
using Inventory.Data.Sqlite.Model;

namespace Inventory.Mapping
{
    public class OrderMapping : Profile
    {
        public OrderMapping()
        {
            CreateMap<Order, OrderDto>()
                .ForMember(x => x.CustomerId, x => x.MapFrom(y => y.CustomerID))
                .ForMember(x => x.OrderId, x => x.MapFrom(y => y.OrderID));
        }
    }
}