using System.Windows.Input;
using AutoMapper;
using Inventory.Data;
using Inventory.ViewModels.Orders;
using Microsoft.Practices.Prism.Commands;

namespace Inventory.ViewModels.Customers
{
    public class CustomerItemViewModel : ViewModelBase
    {
        private OrdersViewModel orders;
        private bool isEditing;
        private CustomerViewModel @new = new CustomerViewModel();
        private CustomerViewModel current;

        public CustomerItemViewModel(IDataService dataservice, long customerId)
        {
            Orders = new OrdersViewModel(dataservice, customerId);
            SaveCommand = new DelegateCommand(async () =>
            {
                IsBusy = true;
                Mapper.Map(New, Current);
                await dataservice.UpdateCustomer(Mapper.Map<CustomerDto>(Current));
                IsEditing = false;
                IsBusy = false;
            });

            ToggleEditModeCommand = new DelegateCommand(() =>
            {
                IsEditing = !IsEditing;
                if (IsEditing)
                {
                    Mapper.Map(Current, New);
                }                
            });
        }

        public CustomerViewModel Current
        {
            get => current;
            set
            {
                current = value;
                OnPropertyChanged();
            }
        }

        public CustomerViewModel New
        {
            get => @new;
            set
            {
                @new = value;
                OnPropertyChanged();
            }
        }

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

        public ICommand SaveCommand { get; }
    }
}