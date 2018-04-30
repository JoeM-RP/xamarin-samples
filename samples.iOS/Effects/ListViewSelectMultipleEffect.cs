using System.ComponentModel;
using samples.iOS.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportEffect(typeof(ListViewSelectMultipleEffect), nameof(ListViewSelectMultipleEffect))]
namespace samples.iOS.Effects
{
    public class ListViewSelectMultipleEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            var listView = (UIKit.UITableView)Control;

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
