using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using CoreGraphics;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(samples.core.Controls.MultiPickerControl), typeof(samples.iOS.Controls.Picker.MultiPickerRenderer))]
namespace samples.iOS.Controls.Picker
{
    /// <summary>
    /// Multi picker renderer.
    /// </summary>
    /// <remarks>
    /// References:
    ///   https://docs.microsoft.com/en-us/xamarin/ios/user-interface/controls/picker#working-with-a-picker-control
    ///   https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/custom-renderer/entry
    /// </remarks>
    public class MultiPickerRenderer : ViewRenderer
    {
        static UIPickerView pickerControl;
        static PeopleModel pickerModel = new PeopleModel(new UILabel());

        public MultiPickerRenderer()
        {
            pickerControl = new UIPickerView(
                new CGRect(
                    UIScreen.MainScreen.Bounds.X - UIScreen.MainScreen.Bounds.Width,
                    UIScreen.MainScreen.Bounds.Height - 230,
                    UIScreen.MainScreen.Bounds.Width,
                    180))
            {
                Model = pickerModel
            };
        }

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);

            if(Control != null)
            {
                Control.Add(pickerControl);
            }

            if(e.NewElement != null)
            {
                (e.NewElement as StackLayout).Children.Add(pickerControl);
            }
        }
    }
}
