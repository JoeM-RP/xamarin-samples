using System;
using samples.core.Controls;
using samples.Droid.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportEffect(typeof(EntryMoveNextEffect), nameof(EntryMoveNextEffect))]
namespace samples.Droid.Effects
{
    public class EntryMoveNextEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            // Check if the attached element is of the expected type and has the NextEntry
            // property set. if so, configure the keyboard to indicate there is another entry
            // in the form and the dismiss action to focus on the next entry
            if (base.Element is EntryMoveNextControl xfControl && xfControl.NextEntry != null)
            {
                var entry = (Android.Widget.EditText)Control;

                entry.ImeOptions = Android.Views.InputMethods.ImeAction.Next;
                entry.EditorAction += (sender, args) =>
                {
                    xfControl.OnNext();
                };
            }
        }

        protected override void OnDetached()
        {
            // Intentionally empty
        }
    }
}

