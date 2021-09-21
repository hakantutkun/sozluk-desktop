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

        /// <summary>
        /// Keeps the index before tab selection changed
        /// </summary>
        private int _previousSelectedIndex = 0;

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

        #region Private Helpers

        /// <summary>
        /// Arranges the direction of animation
        /// </summary>
        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                // get selected tab index
                int selectedIndex = ((TabControl)sender).SelectedIndex;

                if (selectedIndex > _previousSelectedIndex)
                {
                    // arrange the direction flag to right
                    _viewModel.IsToRight = true;
                }
                //otherwise
                else
                {
                    // arrange the direction flag to left
                    _viewModel.IsToRight = false;
                }

                // Finally, set the previous selected index to current index
                _previousSelectedIndex = selectedIndex;
            }
            catch (System.Exception ex )
            {
                Trace.WriteLine("Ex: " + ex.Message);
                throw;
            }
        }

        #endregion

    }
}
