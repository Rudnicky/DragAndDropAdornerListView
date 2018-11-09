using System.Windows;
using System.Windows.Media;

namespace DragDropAdornerPoC.Helpers
{
    public static class TreeHelper
    {
        // Helper to search up the VisualTree
        public static T FindAnchestor<T>(DependencyObject current) where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);
            return null;
        }
    }
}
