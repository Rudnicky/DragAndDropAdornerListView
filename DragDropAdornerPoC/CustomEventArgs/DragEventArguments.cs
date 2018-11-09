using System;
using System.Windows;

namespace DragDropAdornerPoC.CustomEventArgs
{
    public class DragEventArguments : EventArgs
    {
        public object Sender { get; set; }

        public DragEventArgs E { get; set; }

        public DragEventArguments(object sender, DragEventArgs e)
        {
            this.Sender = sender;
            this.E = e;
        }
    }
}
