using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventory
{
    public interface IDataService
    {
        Task<IReadOnlyList<CustomerDto>> GetCustomers();
    }
}