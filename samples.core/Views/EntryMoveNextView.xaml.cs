using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace samples.core.Views
{
    public partial class EntryMoveNextView : ContentPage
    {
        public EntryMoveNextView()
        {
            InitializeComponent();

            Entry_First.ReturnCommand = new Command(() => Entry_Second.Focus());
            Entry_Second.ReturnCommand = new Command(() => Entry_Third.Focus());
        }
    }
}
