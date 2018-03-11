using System.Collections.Generic;
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

        public async Task<IReadOnlyList<CustomerDto>> GetCustomers()
        {
            using (var context = CreateContext())
            {
                var customerDtos = context.Customers.Select(x => new CustomerDto()
                {
                    Name = x.FirstName,
                    Thumbnail = x.Thumbnail,
                });

                return await customerDtos.ToListAsync();
            }
        }
    }
}