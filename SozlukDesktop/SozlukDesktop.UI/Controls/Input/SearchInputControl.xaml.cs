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

            // cast it to model
            var content = (WordModel)(item.Content);

            // Show test message box
            MessageBox.Show(content.Word);

            // Default usage
            if (item != null && item.IsSelected)
            {
                //Do your stuff
            }
        }
    }
}
