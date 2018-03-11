namespace Inventory
{
    public class SectionViewModel : ViewModelBase
    {
        public object ViewModel { get; }
        public Section Section { get; }

        public SectionViewModel(Section section, object viewModel)
        {
            this.ViewModel = viewModel;
            Section = section;
        }

        public string Name => Section.Name;
        public object Key => Section.Key;
    }
}