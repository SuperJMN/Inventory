using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Data
{
    public interface IDataService
    {
        Task<List<OrderDto>> GetOrder(int orderId);
        Task<List<CustomerDto>> GetCustomers(ListRequest request);
        Task<int> GetTotalCustomers();        
    }
}