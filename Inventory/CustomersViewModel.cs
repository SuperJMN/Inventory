using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;

namespace Inventory
{
    public class CustomersViewModel : ViewModelBase
    {
        private readonly IDataService dataService;
        private ObservableCollection<CustomerViewModel> customers;
        private bool isBusy;

        public CustomersViewModel(IDataService dataService)
        {
            this.dataService = dataService;
            LoadCustomersCommand = new DelegateCommand(async () => Customers = await LoadCustomers());            
        }

        private async Task<ObservableCollection<CustomerViewModel>> LoadCustomers()
        {
            IsBusy = true;
            var dtos = await dataService.GetCustomers();

            var customerViewModels = new ObservableCollection<CustomerViewModel>(dtos.Select(x => new CustomerViewModel()
            {
                CustomerId = x.CustomerId,
                Name = x.Name,
                Thumbnail = x.Thumbnail,
            }));

            IsBusy = false;

            return customerViewModels;
            
        }

        public bool IsBusy
        {
            get => isBusy;
            set
            {
                isBusy = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<CustomerViewModel> Customers
        {
            get => customers;
            private set
            {
                customers = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoadCustomersCommand { get; }
    }
}