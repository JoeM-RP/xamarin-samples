using System;
using System.Linq;
using System.Collections.Generic;
using samples.core.Models;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using System.Collections.ObjectModel;

namespace samples.core.Views
{
    public partial class RadioButtonView : ContentPage
    {
        private ObservableCollection<Grouping<string, RadioOption>> RadioOptionsList = new ObservableCollection<Grouping<string, RadioOption>>();

        public RadioButtonView()
        {
            InitializeComponent();

            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

            Initialize();
        }

        public async void Handle_Clicked(object sender, EventArgs e)
        {
            await this.DisplayAlert("", "Your selections have been saved", "OK");
            Initialize();
        }

        /// <summary>
        /// Handles the item tapped.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        public void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as RadioOption;

            if (item == null)
                return;

            // Somewhat inefficient way of ensuring only one item per group is 
            // selected. You could also perform logic to toggle state (assuming
            // it is within reason to slect many per group.
            //
            // If we were using an MVVM framework, it would be smart ot move this
            // logic to the ViewModel
            foreach (var group in RadioOptionsList)
            {
                if (group.Contains(item))
                {
                    foreach (var s in group.Where(x => x.IsSelected))
                    {
                        s.IsSelected = false;
                    }

                    item.IsSelected = true;
                }
            }
        }

        public void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // Clear selected item so we don't have a lingering highlight of the last
            // item tapped
            ListView_Radio.SelectedItem = null;
        }

        private void Initialize()
        {
            // Build a list of items
            var items = new List<RadioOption>()
            {
                new RadioOption(RadioCategory.CategoryA, "Red", true),
                new RadioOption(RadioCategory.CategoryA, "Blue"),
                new RadioOption(RadioCategory.CategoryA, "Green"),
                new RadioOption(RadioCategory.CategoryA, "Yellow"),
                new RadioOption(RadioCategory.CategoryA, "Transparent"),

                new RadioOption(RadioCategory.CategoryB, "Marvel", true),
                new RadioOption(RadioCategory.CategoryB, "DC"),


                new RadioOption(RadioCategory.CategoryC, "Chicken", true),
                new RadioOption(RadioCategory.CategoryC, "Steak"),
                new RadioOption(RadioCategory.CategoryC, "Fish"),
                new RadioOption(RadioCategory.CategoryC, "Vegetarian/Vegan"),
            };

            // Copy items into a grouping
            var sorted = from item in items 
                group item by item.Category into radioGroups 
                select new Grouping<string, RadioOption>(radioGroups.Key.ToString(), radioGroups);

            // Add to list
            RadioOptionsList = new ObservableCollection<Grouping<string, RadioOption>>(sorted);
            ListView_Radio.ItemsSource = RadioOptionsList;
        }
    }
}
