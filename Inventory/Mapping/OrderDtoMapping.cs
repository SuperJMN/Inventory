using AutoMapper;
using Inventory.Data;
using Inventory.ViewModels.Customers;
using Inventory.ViewModels.Orders;

namespace Inventory.Mapping
{
    public class OrderDtoMapping : Profile
    {
        public OrderDtoMapping()
        {
            CreateMap<OrderDto, OrderViewModel>();
        }
    }
}