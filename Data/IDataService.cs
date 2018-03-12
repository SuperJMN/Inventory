using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventory.Data
{
    public interface IDataService
    {
        Task<List<CustomerDto>> GetCustomers(ListRequest request);
        Task<int> GetTotalCustomers();
    }
}