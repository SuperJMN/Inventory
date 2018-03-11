namespace Inventory
{
    public class Section
    {
        public Section(string name, SectionKey key)
        {
            Name = name;
            Key = key;
        }

        public string Name { get; }
        public object Key { get; }
    }
}