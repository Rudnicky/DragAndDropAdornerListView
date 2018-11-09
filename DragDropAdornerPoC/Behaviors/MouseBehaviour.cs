using DragDropAdornerPoC.CustomEventArgs;
using System.Windows;
using System.Windows.Input;

namespace DragDropAdornerPoC.Behaviors
{
    public class MouseBehavior
    {
        #region MouseUp
        public static readonly DependencyProperty MouseUpCommandProperty =
            DependencyProperty.RegisterAttached("MouseUpCommand", typeof(ICommand), typeof(MouseBehavior), new FrameworkPropertyMetadata(new PropertyChangedCallback(MouseUpCommandChanged)));

        private static void MouseUpCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = (FrameworkElement)d;
            if (element != null)
            {
                element.MouseUp += Element_MouseUp;
            }
        }

        static void Element_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var element = (FrameworkElement)sender;
            if (element != null)
            {
                ICommand command = GetMouseUpCommand(element);
                if (command != null)
                {
                    command.Execute(new MouseEventArguments(sender, e));
                }
            }
        }

        public static void SetMouseUpCommand(UIElement element, ICommand value)
        {
            element.SetValue(MouseUpCommandProperty, value);
        }

        public static ICommand GetMouseUpCommand(UIElement element)
        {
            return (ICommand)element.GetValue(MouseUpCommandProperty);
        }
        #endregion

        #region MouseDown
        public static readonly DependencyProperty MouseDownCommandProperty =
            DependencyProperty.RegisterAttached("MouseDownCommand", typeof(ICommand), typeof(MouseBehavior), new FrameworkPropertyMetadata(new PropertyChangedCallback(MouseDownCommandChanged)));

        private static void MouseDownCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = (FrameworkElement)d;
            if (element != null)
            {
                element.MouseDown += Element_MouseDown;
            }
        }

        static void Element_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var element = (FrameworkElement)sender;
            if (element != null)
            {
                ICommand command = GetMouseDownCommand(element);
                if (command != null)
                {
                    command.Execute(new MouseEventArguments(sender, e));
                }
            }
        }

        public static void SetMouseDownCommand(UIElement element, ICommand value)
        {
            element.SetValue(MouseDownCommandProperty, value);
        }

        public static ICommand GetMouseDownCommand(UIElement element)
        {
            return (ICommand)element.GetValue(MouseDownCommandProperty);
        }
        #endregion

        #region MouseMove
        public static readonly DependencyProperty MouseMoveCommandProperty =
            DependencyProperty.RegisterAttached("MouseMoveCommand", typeof(ICommand), typeof(MouseBehavior), new FrameworkPropertyMetadata(new PropertyChangedCallback(MouseMoveCommandChanged)));

        private static void MouseMoveCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = (FrameworkElement)d;
            if (element != null)
            {
                element.MouseMove += Element_MouseMove;
            }
        }

        private static void Element_MouseMove(object sender, MouseEventArgs e)
        {
            var element = (FrameworkElement)sender;
            if (element != null)
            {
                ICommand command = GetMouseMoveCommand(element);
                if (command != null)
                {
                    command.Execute(new MouseEventArguments(sender, e));
                }
            }
        }

        public static void SetMouseMoveCommand(UIElement element, ICommand value)
        {
            element.SetValue(MouseMoveCommandProperty, value);
        }

        public static ICommand GetMouseMoveCommand(UIElement element)
        {
            return (ICommand)element.GetValue(MouseMoveCommandProperty);
        }
        #endregion

        #region PreviewMouseLeftButtonDown
        public static readonly DependencyProperty PreviewMouseLeftButtonDownCommandProperty =
          DependencyProperty.RegisterAttached("PreviewMouseLeftButtonDownCommand", typeof(ICommand), typeof(MouseBehavior), new FrameworkPropertyMetadata(new PropertyChangedCallback(PreviewMouseLeftButtonDownCommandChanged)));

        private static void PreviewMouseLeftButtonDownCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = (FrameworkElement)d;
            if (element != null)
            {
                element.PreviewMouseLeftButtonDown += Element_PreviewMouseLeftButtonDown;
            }
        }

        static void Element_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var element = (FrameworkElement)sender;
            if (element != null)
            {
                ICommand command = GetPreviewMouseLeftButtonDownCommand(element);
                if (command != null)
                {
                    command.Execute(new MouseEventArguments(sender, e));
                }
            }
        }

        public static void SetPreviewMouseLeftButtonDownCommand(UIElement element, ICommand value)
        {
            element.SetValue(PreviewMouseLeftButtonDownCommandProperty, value);
        }

        public static ICommand GetPreviewMouseLeftButtonDownCommand(UIElement element)
        {
            return (ICommand)element.GetValue(PreviewMouseLeftButtonDownCommandProperty);
        }
        #endregion

        #region PreviewMouseMove
        public static readonly DependencyProperty PreviewMouseMoveCommandProperty =
          DependencyProperty.RegisterAttached("PreviewMouseMoveCommand", typeof(ICommand), typeof(MouseBehavior), new FrameworkPropertyMetadata(new PropertyChangedCallback(PreviewMouseMoveCommandChanged)));

        private static void PreviewMouseMoveCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = (FrameworkElement)d;
            if (element != null)
            {
                element.PreviewMouseMove += Element_PreviewMouseMove;
            }
        }

        private static void Element_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            var element = (FrameworkElement)sender;
            if (element != null)
            {
                ICommand command = GetPreviewMouseMoveCommand(element);
                if (command != null)
                {
                    command.Execute(new MouseEventArguments(sender, e));
                }
            }
        }

        public static void SetPreviewMouseMoveCommand(UIElement element, ICommand value)
        {
            element.SetValue(PreviewMouseMoveCommandProperty, value);
        }

        public static ICommand GetPreviewMouseMoveCommand(UIElement element)
        {
            return (ICommand)element.GetValue(PreviewMouseMoveCommandProperty);
        }
        #endregion

        #region PreviewMouseLeftButtonUp
        public static readonly DependencyProperty PreviewMouseLeftButtonUpCommandProperty =
          DependencyProperty.RegisterAttached("PreviewMouseLeftButtonUpCommand", typeof(ICommand), typeof(MouseBehavior), new FrameworkPropertyMetadata(new PropertyChangedCallback(PreviewMouseLeftButtonUpCommandChanged)));

        private static void PreviewMouseLeftButtonUpCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = (FrameworkElement)d;
            if (element != null)
            {
                element.PreviewMouseLeftButtonUp += Element_PreviewMouseLeftButtonUp;
            }
        }

        private static void Element_PreviewMouseLeftButtonUp(object sender, MouseEventArgs e)
        {
            var element = (FrameworkElement)sender;
            if (element != null)
            {
                ICommand command = GetPreviewMouseLeftButtonUpCommand(element);
                if (command != null)
                {
                    command.Execute(new MouseEventArguments(sender, e));
                }
            }
        }

        public static void SetPreviewMouseLeftButtonUpCommand(UIElement element, ICommand value)
        {
            element.SetValue(PreviewMouseLeftButtonUpCommandProperty, value);
        }

        public static ICommand GetPreviewMouseLeftButtonUpCommand(UIElement element)
        {
            return (ICommand)element.GetValue(PreviewMouseLeftButtonUpCommandProperty);
        }
        #endregion
    }
}
