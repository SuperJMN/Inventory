namespace Inventory
{
    public class SectionViewModel : ViewModelBase
    {
        public ViewModelBase ViewModel { get; }
        public Section Section { get; }

        public SectionViewModel(Section section, ViewModelBase viewModel)
        {
            this.ViewModel = viewModel;
            Section = section;
        }

        public string Name => Section.Name;
        public object Key => Section.Key;
    }
}