using DragDropAdornerPoC.ViewModels;
using System.Windows;

namespace DragDropAdornerPoC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Ctor
        public MainWindow()
        {
            InitializeComponent();
            SetupDataContext();
        }
        #endregion

        #region Private Methods
        private void SetupDataContext()
        {
            this.DataContext = new MainWindowViewModel();
        }
        #endregion
    }
}
