using SozlukDesktop.Entities.Models;
using SozlukDesktop.UI.Models;
using System.Windows;
using System.Windows.Controls;

namespace SozlukDesktop.UI
{
    /// <summary>
    /// Interaction logic for SearchInput.xaml
    /// </summary>
    public partial class SearchInputControl : UserControl
    {
        public SearchInputControl()
        {
            InitializeComponent();

            // Set the datacontext of control
            DataContext = new SearchInputViewModel();
        }

        /// <summary>
        /// Runs when a word selected from list view
        /// </summary>
        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // get selected item 
            var item = sender as ListViewItem;

            // Default usage
            if (item != null && item.IsSelected)
            {
                ((SearchInputViewModel)DataContext).PrepareSelectedWordItem((Kelime)(item.Content));
            }
        }
    }
}
