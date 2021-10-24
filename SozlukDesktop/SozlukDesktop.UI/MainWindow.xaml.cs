using SozlukDesktop.UI.ViewModels;
using System.Windows;

namespace SozlukDesktop.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public MainWindow()
        {
            // Set the datacontext of this window
            DataContext = MainWindowViewModel.GetMainWindowViewModel(this);

            // Initialize components
            InitializeComponent();
        }

        #endregion
    }
}
