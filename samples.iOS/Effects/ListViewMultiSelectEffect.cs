using System;
using System.ComponentModel;
using samples.iOS.Effects;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportEffect(typeof(ListViewMultiSelectEffect), nameof(ListViewMultiSelectEffect))]
namespace samples.iOS.Effects
{
    public class ListViewMultiSelectEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            var listView = (UITableView)Control;

            listView.AllowsMultipleSelection = true;
        }

        protected override void OnDetached()
        {
            
        }

		protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
		{
			base.OnElementPropertyChanged(args);

            System.Diagnostics.Debug.WriteLine(args.PropertyName);
		}
	}
}
