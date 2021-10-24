using SozlukDesktop.UI.ViewModels;
using System.Diagnostics;
using System.Windows.Controls;

namespace SozlukDesktop.UI
{
    /// <summary>
    /// Interaction logic for WordTabControl.xaml
    /// </summary>
    public partial class WordTabControl : UserControl
    {

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public WordTabControl()
        {
            InitializeComponent();

            // Set the datacontext
            DataContext = WordTabViewModel.GetWordTabViewModel();
        }

        #endregion

    }
}
