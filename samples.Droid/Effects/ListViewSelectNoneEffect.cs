using System;
using Android.Widget;
using samples.Droid.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportEffect(typeof(ListViewSelectNoneEffect), nameof(ListViewSelectNoneEffect))]
namespace samples.Droid.Effects
{
    public class ListViewSelectNoneEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            var listView = (Android.Widget.ListView)Control;

            listView.ChoiceMode = ChoiceMode.None;
        }

        protected override void OnDetached()
        {
            
        }
    }
}
