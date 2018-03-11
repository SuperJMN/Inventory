namespace Inventory
{
    public class SectionViewModel : ViewModelBase
    {
        public Section Section { get; }

        public SectionViewModel(Section section)
        {
            Section = section;
        }

        public string Name => Section.Name;
        public object Key => Section.Key;
    }
}