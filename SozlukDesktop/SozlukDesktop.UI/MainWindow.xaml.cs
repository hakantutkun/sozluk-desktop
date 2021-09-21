using System.Windows;

namespace SozlukDesktop.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Set the datacontext of this window
            DataContext = new WindowViewModel(this);
        }
    }
}
