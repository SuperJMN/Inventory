using AutoMapper;
using Inventory.Data;
using Inventory.Data.Sqlite.Model;
using Inventory.ViewModels.Orders;

namespace Inventory.Mapping
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderDto, OrderViewModel>();
            CreateMap<Order, OrderDto>()
                .ForMember(x => x.CustomerId, x => x.MapFrom(y => y.CustomerID))
                .ForMember(x => x.OrderId, x => x.MapFrom(y => y.OrderID));
        }
    }
}