using DragDropAdornerPoC.CustomEventArgs;
using System.Windows;
using System.Windows.Input;

namespace DragDropAdornerPoC.Behaviors
{
    public class DragBehaviour
    {
        #region DragEnter
        public static readonly DependencyProperty DragEnterCommandProperty =
            DependencyProperty.RegisterAttached("DragEnterCommand", typeof(ICommand), typeof(DragBehaviour), new FrameworkPropertyMetadata(new PropertyChangedCallback(DragEnterCommandChanged)));

        private static void DragEnterCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = (FrameworkElement)d;
            if (element != null)
            {
                element.DragEnter += Element_DragEnter;
            }
        }

        private static void Element_DragEnter(object sender, DragEventArgs e)
        {
            var element = (FrameworkElement)sender;
            if (element != null)
            {
                ICommand command = GetDragEnterCommand(element);
                if (command != null)
                {
                    command.Execute(new DragEventArguments(sender, e));
                }
            }
        }

        public static void SetDragEnterCommand(UIElement element, ICommand value)
        {
            element.SetValue(DragEnterCommandProperty, value);
        }

        public static ICommand GetDragEnterCommand(UIElement element)
        {
            return (ICommand)element.GetValue(DragEnterCommandProperty);
        }
        #endregion

        #region DragOver
        public static readonly DependencyProperty DragOverCommandProperty =
            DependencyProperty.RegisterAttached("DragOverCommand", typeof(ICommand), typeof(DragBehaviour), new FrameworkPropertyMetadata(new PropertyChangedCallback(DragOverCommandChanged)));

        private static void DragOverCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = (FrameworkElement)d;
            if (element != null)
            {
                element.DragOver += Element_DragOver;
            }
        }

        private static void Element_DragOver(object sender, DragEventArgs e)
        {
            var element = (FrameworkElement)sender;
            if (element != null)
            {
                ICommand command = GetDragOverCommand(element);
                if (command != null)
                {
                    command.Execute(new DragEventArguments(sender, e));
                }
            }
        }

        public static void SetDragOverCommand(UIElement element, ICommand value)
        {
            element.SetValue(DragOverCommandProperty, value);
        }

        public static ICommand GetDragOverCommand(UIElement element)
        {
            return (ICommand)element.GetValue(DragOverCommandProperty);
        }
        #endregion

        #region DragLeave
        public static readonly DependencyProperty DragLeaveCommandProperty =
            DependencyProperty.RegisterAttached("DragLeaveCommand", typeof(ICommand), typeof(DragBehaviour), new FrameworkPropertyMetadata(new PropertyChangedCallback(DragLeaveCommandChanged)));

        private static void DragLeaveCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = (FrameworkElement)d;
            if (element != null)
            {
                element.DragLeave += Element_DragLeave;
            }
        }

        private static void Element_DragLeave(object sender, DragEventArgs e)
        {
            var element = (FrameworkElement)sender;
            if (element != null)
            {
                ICommand command = GetDragLeaveCommand(element);
                if (command != null)
                {
                    command.Execute(new DragEventArguments(sender, e));
                }
            }
        }

        public static void SetDragLeaveCommand(UIElement element, ICommand value)
        {
            element.SetValue(DragLeaveCommandProperty, value);
        }

        public static ICommand GetDragLeaveCommand(UIElement element)
        {
            return (ICommand)element.GetValue(DragLeaveCommandProperty);
        }
        #endregion

        #region Drop
        public static readonly DependencyProperty DropCommandProperty =
            DependencyProperty.RegisterAttached("DropCommand", typeof(ICommand), typeof(DragBehaviour), new FrameworkPropertyMetadata(new PropertyChangedCallback(DropCommandChanged)));

        private static void DropCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = (FrameworkElement)d;
            if (element != null)
            {
                element.Drop += Element_Drop;
            }
        }

        private static void Element_Drop(object sender, DragEventArgs e)
        {
            var element = (FrameworkElement)sender;
            if (element != null)
            {
                ICommand command = GetDropCommand(element);
                if (command != null)
                {
                    command.Execute(new DragEventArguments(sender, e));
                }
            }
        }

        public static void SetDropCommand(UIElement element, ICommand value)
        {
            element.SetValue(DropCommandProperty, value);
        }

        public static ICommand GetDropCommand(UIElement element)
        {
            return (ICommand)element.GetValue(DropCommandProperty);
        }
        #endregion
    }
}
