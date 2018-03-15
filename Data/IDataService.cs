using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Data
{
    public interface IDataService
    {
        Task<List<CustomerDto>> GetCustomers(ListRequest request);
        Task<int> GetTotalCustomers();
        Task<List<OrderDto>> GetOrdersByCustomer(long customerCustomerId, ListRequest listRequest);
        Task<int> GetTotalOrders();
        Task UpdateCustomer(CustomerDto map);
    }
}