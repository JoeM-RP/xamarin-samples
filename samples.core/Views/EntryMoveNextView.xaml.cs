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

            Entry_First.Effects.Add(Effect.Resolve("Effects.EntryMoveNextEffect"));
            Entry_First.NextEntry = Entry_Second;

            Entry_Second.Effects.Add(Effect.Resolve("Effects.EntryMoveNextEffect"));
            Entry_Second.NextEntry = Entry_Third;

            Entry_Third.Effects.Add(Effect.Resolve("Effects.EntryMoveNextEffect"));
        }
    }
}
