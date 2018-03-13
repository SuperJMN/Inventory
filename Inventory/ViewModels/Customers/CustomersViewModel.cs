using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Inventory.Data;
using Microsoft.Practices.Prism.Commands;

namespace Inventory.ViewModels.Customers
{
    public class CustomersViewModel : ViewModelBase
    {
        private readonly IDataService dataService;
        private int pageSize;
        private IReadOnlyList<CustomerPageViewModel> customerPages;
        private CustomerViewModel selectedCustomer;
        private CustomerPageViewModel selectedPage;

        public CustomersViewModel(IDataService dataService)
        {
            this.dataService = dataService;
            CreatePagesCommand = new DelegateCommand(async () => await CreatePages());
            PageSize = 20;
        }

        private async Task CreatePages()
        {
            IsBusy = true;
            var count = await dataService.GetTotalCustomers();
            CustomerPages = Enumerable.Range(1, Math.Min(5, count)).Select(x => new CustomerPageViewModel(dataService, x, PageSize)).ToList().AsReadOnly();
            IsBusy = false;
        }

        public int PageSize
        {
            get => pageSize;
            set => pageSize = value;
        }

        public IReadOnlyList<CustomerPageViewModel> CustomerPages
        {
            get => customerPages;
            private set
            {
                customerPages = value;
                OnPropertyChanged();
            }
        }

        public ICommand CreatePagesCommand { get; }

        public CustomerPageViewModel SelectedPage
        {
            get => selectedPage;
            set
            {
                selectedPage = value;
                OnPropertyChanged();
            }
        }
    }
}