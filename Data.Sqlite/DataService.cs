using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Data.Sqlite
{
    public class DataService : IDataService
    {
        private InventoryContext CreateContext()
        {
            var builder = new DbContextOptionsBuilder().UseSqlite("Data Source=VanArsdel.db");
            return new InventoryContext(builder.Options);
        }

        public async Task<List<OrderDto>> GetOrder(int orderId)
        {
            using (var context = CreateContext())
            {
                return await context.Orders
                    .Where(x => x.OrderID == orderId)
                    .ProjectTo<OrderDto>()
                    .ToListAsync();
            }
        }

        public async Task<List<CustomerDto>> GetCustomers(ListRequest listRequest)
        {
            using (var context = CreateContext())
            {
                var results = await context.Customers
                    .OrderBy(x => x.FirstName)
                    .Skip(listRequest.Skip)
                    .Take(listRequest.Take)
                    .ProjectTo<CustomerDto>()
                    .ToListAsync();

                return results;
            }
        }

        public async Task<int> GetTotalCustomers()
        {
            using (var context = CreateContext())
            {
                return await context.Customers.CountAsync();
            }
        }
    }

    public class PagedList<T>
    {
        private readonly List<T> results;
        private readonly int count;

        public PagedList(List<T> results, int count)
        {
            this.results = results;
            this.count = count;
            throw new System.NotImplementedException();
        }

        public ReadOnlyCollection<T> Results => results.AsReadOnly();
        public int Count => count;
    }
}