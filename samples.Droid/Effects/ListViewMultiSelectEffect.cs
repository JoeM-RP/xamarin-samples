using System;
using Android.Widget;
using samples.Droid.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportEffect(typeof(ListViewMultiSelectEffect), nameof(ListViewMultiSelectEffect))]
namespace samples.Droid.Effects
{
    public class ListViewMultiSelectEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            var listView = (Android.Widget.ListView)Control;

            listView.ChoiceMode = ChoiceMode.Multiple;
        }

        protected override void OnDetached()
        {

        }
    }
}

