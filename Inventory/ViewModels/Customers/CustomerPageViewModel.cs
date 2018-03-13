using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Inventory.Data;
using Microsoft.Practices.Prism.Commands;

namespace Inventory.ViewModels.Customers
{
    public class CustomerPageViewModel : ViewModelBase
    {
        private readonly IDataService dataservice;
        public int PageId { get; }
        private IReadOnlyList<CustomerViewModel> customers;
        private CustomerViewModel selectedCustomer;

        public CustomerPageViewModel(IDataService dataservice, int pageId, int pageSize)
        {
            this.dataservice = dataservice;
            PageId = pageId;
            PageSize = pageSize;
            LoadCustomersCommand = new DelegateCommand(async () =>
            {
                Customers = await LoadCustomers();
                SelectedCustomer = Customers.FirstOrDefault();
            });
        }

        public int Skip { get; set; }

        private async Task<IReadOnlyList<CustomerViewModel>> LoadCustomers()
        {
            IsBusy = true;

            var listRequest = new ListRequest { Skip = PageSize * (PageId - 1), Take = PageSize };
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
                MiddleName = x.MiddleName,
            }).ToList().AsReadOnly();

            IsBusy = false;

            return vms;
        }

        public int PageSize { get; }

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