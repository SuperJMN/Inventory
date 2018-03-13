using System.Windows.Input;
using Inventory.Data;
using Inventory.ViewModels.Orders;
using Microsoft.Practices.Prism.Commands;

namespace Inventory.ViewModels.Customers
{
    public class CustomerViewModel : ViewModelBase
    {
        public IDataService Dataservice { get; }
        private OrdersViewModel orders;
        private bool isEditing;

        public CustomerViewModel(IDataService dataservice, long customerId)
        {
            Dataservice = dataservice;
            Orders = new OrdersViewModel(dataservice, customerId);
            ToggleEditModeCommand = new DelegateCommand(() => IsEditing = !IsEditing);
        }

        public string FirstName { get; set; }
        public string Email { get; set; }
        public long CustomerId { get; set; }
        public byte[] Thumbnail { get; set; }
        public string Initials { get; set; }
        public string FullName => string.Join(" ", FirstName, LastName);
        public string LastName { get; set; }
        public byte[] Picture { get; set; }
        public string Phone { get; set; }
        public string AddressLine1 { get;set; }
        public string CountryName { get; set; }
        public string MiddleName { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; }

        public OrdersViewModel Orders
        {
            get => orders;
            set => orders = value;
        }

        public bool IsEditing
        {
            get => isEditing;
            set
            {
                isEditing = value;
                OnPropertyChanged();
            }
        }

        public ICommand ToggleEditModeCommand { get; }
    }
}