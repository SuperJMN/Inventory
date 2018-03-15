using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Inventory.Data;
using Inventory.ViewModels.Customers;
using Microsoft.Practices.Prism.Commands;

namespace Inventory.ViewModels.Orders
{
    public class OrdersViewModel : ViewModelBase
    {
        private readonly IDataService dataService;
        private readonly long customerId;
        private int pageSize;
        private ReadOnlyCollection<OrderPageViewModel> orderPages;
        private CustomerPageViewModel selectedPage;
        private OrderPageViewModel orderPage;

        public OrdersViewModel(IDataService dataService, long customerId)
        {
            this.dataService = dataService;
            this.customerId = customerId;
            CreatePagesCommand = new DelegateCommand(async () => await CreatePages());
            PageSize = 20;
        }

        private async Task CreatePages()
        {
            IsBusy = true;
            await Task.Delay(4000);
            var count = await dataService.GetTotalOrders();
            OrderPages = Enumerable.Range(1, Math.Min(5, count)).Select(x => new OrderPageViewModel(dataService, customerId, x, PageSize)).ToList().AsReadOnly();
            IsBusy = false;
        }

        public int PageSize
        {
            get => pageSize;
            set => pageSize = value;
        }

        public ReadOnlyCollection<OrderPageViewModel> OrderPages
        {
            get => orderPages;
            private set
            {
                orderPages = value;
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