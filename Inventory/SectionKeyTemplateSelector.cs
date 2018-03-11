using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Inventory
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

            //var vm = (SectionViewModel) item;
            //var key = (SectionKey)vm.Key;
            var itemName = Enum.GetName(typeof(SectionKey), item);

            if (dict.TryGetValue(itemName, out var t))
            {
                return (DataTemplate) t;
            }

            return base.SelectTemplateCore(item, container);
        }
    }
}