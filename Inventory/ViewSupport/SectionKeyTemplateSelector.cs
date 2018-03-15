using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Inventory.ViewSupport
{
    public class SectionKeyTemplateSelector : DataTemplateSelector
    {
        public ResourceDictionary Items { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            if (item == null)
            {
                return base.SelectTemplateCore(container);
            }

            var dict = (IDictionary<object, object>) Items;

            var name = item.GetType().Name.Replace("ViewModel", "");
            if (dict.TryGetValue(name, out var t))
            {
                return (DataTemplate) t;
            }

            return base.SelectTemplateCore(item, container);
        }
    }
}