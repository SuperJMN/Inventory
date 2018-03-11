namespace Inventory
{
    public class Section
    {
        public SectionKey SectionKey { get; }

        public Section(string name, SectionKey sectionKey)
        {
            Name = name;
            SectionKey = sectionKey;
        }

        public string Name { get; }
        public object Key { get; }
    }
}