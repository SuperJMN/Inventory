using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
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
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Thumbnail = x.Thumbnail,
                        Picture = x.Picture,
                        Phone = x.Phone,
                        Email = x.EmailAddress,
                        AddressLine1 = x.AddressLine1,
                        AddressLine2 = x.AddressLine2,
                        CountryName = x.CountryCode,
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
}