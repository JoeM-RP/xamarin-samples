using System;
using CoreGraphics;
using samples.core.Controls;
using samples.iOS.Effects;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportEffect(typeof(EntryMoveNextEffect), nameof(EntryMoveNextEffect))]
namespace samples.iOS.Effects
{
    public class EntryMoveNextEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            var entry = (UITextField)Control;

            // Change return key to Don key
            entry.ReturnKeyType = UIReturnKeyType.Done;

            // Add the "done" button to the toolbar easily dismiss the keyboard
            // when it may not have a return key
            if (entry.KeyboardType == UIKeyboardType.NumberPad)
            {
                entry.InputAccessoryView = BuildDismiss();
            }

            // Check if the attached element is of the expected type and has the NextEntry
            // property set. if so, configure the keyboard to indicate there is another entry
            // in the form and the dismiss action to focus on the next entry
            if (base.Element is EntryMoveNextControl xfControl && xfControl.NextEntry != null)
            {
                entry.ReturnKeyType = UIReturnKeyType.Next;
                entry.ShouldReturn += (textField) => 
                {
                    xfControl.OnNext();
                    return true;
                };
            }
        }

        protected override void OnDetached()
        {
            // Intentionally empty
        }

        private UIToolbar BuildDismiss()
        {
            var toolbar = new UIToolbar(new CGRect(0.0f, 0.0f, Control.Frame.Size.Width, 44.0f));

            toolbar.Items = new[]
            {
                new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace),
                new UIBarButtonItem(UIBarButtonSystemItem.Done, delegate { Control.ResignFirstResponder(); })
            };

            return toolbar;
        }
    }
}

