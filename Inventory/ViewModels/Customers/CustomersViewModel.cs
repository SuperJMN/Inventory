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
            CustomerPages = Enumerable.Range(0, Math.Min(5, count)).Select(x => new CustomerPageViewModel(dataService, x, PageSize)).ToList().AsReadOnly();
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
    }

    public class CustomerPageViewModel : ViewModelBase
    {
        private readonly IDataService dataservice;
        public int Ordinal { get; }
        private IReadOnlyList<CustomerViewModel> customers;
        private CustomerViewModel selectedCustomer;

        public CustomerPageViewModel(IDataService dataservice, int ordinal, int pageSize)
        {
            this.dataservice = dataservice;
            Ordinal = ordinal;
            PageSize = pageSize;
            LoadCustomersCommand = new DelegateCommand(async () => Customers = await LoadCustomers());
        }

        private async Task<IReadOnlyList<CustomerViewModel>> LoadCustomers()
        {
            IsBusy = true;

            var listRequest = new ListRequest() { Skip = PageSize * Ordinal, Take = PageSize };
            var loadCustomers = await dataservice.GetCustomers(listRequest);
            var vms = loadCustomers.Select(x => new CustomerViewModel()
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                CustomerId = x.CustomerId,
                Email = x.Email,
                Thumbnail = x.Thumbnail,
                Picture = x.Picture,                
                Phone = x.Phone,
                AddressLine1 = x.AddressLine1,
                CountryName = x.CountryName,
            }).ToList().AsReadOnly();

            IsBusy = false;

            return vms;
        }

        public int PageSize { get; set; }

        public IReadOnlyList<CustomerViewModel> Customers
        {
            get => customers;
            set
            {
                customers = value;
                OnPropertyChanged();
            }
        }

     

        public ICommand LoadCustomersCommand { get; }

        public CustomerViewModel SelectedCustomer
        {
            get => selectedCustomer;
            set
            {
                selectedCustomer = value;
                OnPropertyChanged();
            }
        }
    }
}