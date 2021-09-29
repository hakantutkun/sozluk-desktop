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
        #region Private Members

        private WordTabViewModel _viewModel = WordTabViewModel.GetWordTabViewModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public WordTabControl()
        {
            InitializeComponent();

            // Set the datacontext
            _viewModel = new WordTabViewModel();
        }

        #endregion

    }
}
