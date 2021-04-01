using System;
using System.Collections.Generic;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

using Xamarin.Forms;

namespace samples.core.Views
{
    public partial class EntryMoveNextView : ContentPage
    {
        public EntryMoveNextView()
        {
            InitializeComponent();

            Entry_First.ReturnCommand = new Command(() => Entry_Second.Focus());

            // Custom entry "Next" behavior
            Entry_Second.NextEntry = Entry_Third;
            Entry_Second.Effects.Add(Effect.Resolve("Effects.EntryMoveNextEffect"));
            // end


            On<iOS>().SetUseSafeArea(true);
        }
    }
}
