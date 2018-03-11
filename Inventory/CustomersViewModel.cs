using System.Collections.ObjectModel;
using System.Linq;

namespace Inventory
{
    public class CustomersViewModel : ViewModelBase
    {
        private readonly IDataService dataService;

        public CustomersViewModel(IDataService dataService)
        {
            this.dataService = dataService;
        }

        public ObservableCollection<CustomerViewModel> Customers
        {
            get
            {
                return new ObservableCollection<CustomerViewModel>(dataService.GetCustomers().Result.Select(x => new CustomerViewModel()
                {
                    Name = x.Name,
                    Thumbnail = x.Thumbnail,
                }));
            }
        }
    }
}