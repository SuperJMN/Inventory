using System.Collections.Generic;

namespace Inventory
{
    public class MainViewModel : ViewModelBase
    {

        private SectionViewModel selectedSection;
        
        public IEnumerable<SectionViewModel> Sections { get; } = new List<SectionViewModel>()
        {
            new SectionViewModel(new Section("Customers", SectionKey.Customers)),
            new SectionViewModel(new Section("Orders", SectionKey.Orders)) 
        };

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

