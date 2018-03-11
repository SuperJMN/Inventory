using System.Collections.ObjectModel;

namespace Inventory
{
    public class CustomersViewModel : ViewModelBase
    {
        public ObservableCollection<CustomerViewModel> Customers { get;  } = new ObservableCollection<CustomerViewModel>()
        {
            new CustomerViewModel()
            {
                Name = "Pepito",
                CustomerId = 123,
                Email = "superjmn@outlook.com"
            }
        };
    }
}