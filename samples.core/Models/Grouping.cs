using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace samples.core.Models
{
    /// <summary>
    /// An object that represents grouped items for a list
    /// </summary>
    /// <remarks>
    /// Source: https://montemagno.com/enhancing-xamarin-forms-listview-with-grouping/
    /// </remarks>
    public class Grouping<K, T> : ObservableCollection<T>
    {
        public K Key { get; private set; }

        public bool IsVisible { get; set; } = true;

        public Grouping(K key, IEnumerable<T> items)
        {
            Key = key;

            foreach (var item in items)
                this.Items.Add(item);
        }
    }
}
