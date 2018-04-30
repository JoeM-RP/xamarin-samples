using System;
using samples.iOS.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportEffect(typeof(ListViewSelectNoneEffect), nameof(ListViewSelectNoneEffect))]
namespace samples.iOS.Effects
{
    public class ListViewSelectNoneEffect : PlatformEffect
    {

        protected override void OnAttached()
        {
            var listView = (UIKit.UITableView)Control;

            listView.AllowsSelection = false;
        }

        protected override void OnDetached()
        {
            
        }
    }
}
