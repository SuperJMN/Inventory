using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Inventory
{
    public class DataService : IDataService
    {
        private InventoryContext CreateContext()
        {
            var builder = new DbContextOptionsBuilder().UseSqlite("Data Source=VanArsdel.db");
            return new InventoryContext(builder.Options);
        }

        public async Task<List<CustomerDto>> GetCustomers(ListRequest listRequest)
        {
            using (var context = CreateContext())
            {
                var customerDtos = context.Customers
                    .Skip(listRequest.Skip)
                    .Take(listRequest.Take)
                    .Select(x => new CustomerDto()
                    {
                        CustomerId = x.CustomerID,
                        Name = string.Join(" ", x.FirstName, x.LastName),
                        Thumbnail = x.Thumbnail,
                    });

                var results = await customerDtos.ToListAsync();
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

    public class ListRequest
    {
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}