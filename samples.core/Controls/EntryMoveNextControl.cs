using System;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace samples.core.Controls
{
    public class EntryMoveNextControl : Entry
    {
        public static readonly BindableProperty NextEntryProperty = BindableProperty.Create(nameof(NextEntry), typeof(View), typeof(Entry));
        public View NextEntry
        {
            get => (View)GetValue(NextEntryProperty);
            set => SetValue(NextEntryProperty, value);
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
        }

        public void OnNext()
        {
            NextEntry?.Focus();
        }
    }
}
