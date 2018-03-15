using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using AutoMapper;
using Inventory.Data;
using Inventory.ViewModels.Customers;
using Microsoft.Practices.Prism.Commands;

namespace Inventory.ViewModels.Orders
{
    public class OrderPageViewModel : ViewModelBase
    {
        private readonly IDataService dataservice;
        private readonly long customerId;
        public int PageId { get; }
        private IReadOnlyList<OrderViewModel> customers;
        private OrderViewModel selectedOrder;

        public OrderPageViewModel(IDataService dataservice, long customerId, int pageId, int pageSize)
        {
            this.dataservice = dataservice;
            this.customerId = customerId;
            PageId = pageId;
            PageSize = pageSize;
            LoadOrdersCommand = new DelegateCommand(async () =>
            {
                Orders = await LoadCustomers();
                SelectedOrder = Orders.FirstOrDefault();
            });
        }

        public int Skip { get; set; }

        private async Task<IReadOnlyList<OrderViewModel>> LoadCustomers()
        {
            IsBusy = true;

            var listRequest = new ListRequest { Skip = PageSize * (PageId - 1), Take = PageSize };
            var loadCustomers = await dataservice.GetOrdersByCustomer(customerId, listRequest);
            var vms = Mapper.Map<IEnumerable<OrderViewModel>>(loadCustomers).ToList().AsReadOnly();

            IsBusy = false;

            return vms;
        }

        public int PageSize { get; }

        public IReadOnlyList<OrderViewModel> Orders
        {
            get => customers;
            set
            {
                customers = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoadOrdersCommand { get; }

        public OrderViewModel SelectedOrder
        {
            get => selectedOrder;
            set
            {
                selectedOrder = value;
                OnPropertyChanged();
            }
        }
    }
}