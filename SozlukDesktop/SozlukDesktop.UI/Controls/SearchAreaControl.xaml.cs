using SozlukDesktop.UI.ViewModels;
using System.Windows.Controls;

namespace SozlukDesktop.UI
{
    /// <summary>
    /// Interaction logic for SearchAreaControl.xaml
    /// </summary>
    public partial class SearchAreaControl : UserControl
    {
        public SearchAreaControl()
        {
            InitializeComponent();

            // Set the datacontext of usercontrol
            DataContext = SearchAreaViewModel.GetSearchAreaViewModel();
        }
    }
}
