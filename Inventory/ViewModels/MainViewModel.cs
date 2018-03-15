using System.Collections.Generic;
using System.Linq;
using Inventory.ViewModels.Customers;
using Inventory.ViewModels.Main;

namespace Inventory.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(CustomersViewModel customersViewModel)
        {
            Sections = new List<SectionViewModel>()
            {
                new SectionViewModel(new Section("Customers", SectionKey.Customers), customersViewModel),
                new SectionViewModel(new Section("Orders", SectionKey.Orders), null) 
            };

            SelectedSection = Sections.FirstOrDefault();
        }

        private SectionViewModel selectedSection;
        
        public IEnumerable<SectionViewModel> Sections { get; } 

        public SectionViewModel SelectedSection
        {
            get => selectedSection;
            set
            {
                selectedSection = value;
                OnPropertyChanged();
            }
        }
    }
}

