namespace SozlukDesktop.UI.ViewModels
{
    /// <summary>
    /// The view model for WordTab Control
    /// </summary>
    public class WordTabViewModel : BaseViewModel
    {

        #region Singleton

        /// <summary>
        /// Create a static instance of viewModel
        /// </summary>
        private static WordTabViewModel _wordTabViewModel;

        /// <summary>
        /// To get properties of this view model
        /// </summary>
        /// <returns></returns>
        public static WordTabViewModel GetWordTabViewModel()
        {
            if (_wordTabViewModel == null)
            {
                _wordTabViewModel = new WordTabViewModel();
            }
            return _wordTabViewModel;
        }

        #endregion

        #region Private Members

        /// <summary>
        /// Keeps the selected tab index
        /// </summary>
        private int _selectedTabIndex;

        /// <summary>
        /// Determines the tab bar animation direction
        /// If true, animation direction will be right. Otherwise it will be to left.
        /// </summary>
        private bool _isToRight;

        #endregion

        #region Public Properties

        /// <summary>
        /// Keeps the selected tab index
        /// </summary>
        public int SelectedTabIndex
        {
            get { return _selectedTabIndex; }
            set { _selectedTabIndex = value; OnPropertyChanged(nameof(SelectedTabIndex)); }
        }

        /// <summary>
        /// Determines the tab bar animation direction
        /// If true, animation direction will be right. Otherwise it will be to left.
        /// </summary>
        public bool IsToRight
        {
            get { return _isToRight; }
            set 
            { 
                _isToRight = value;

                if (_isToRight == value)
                    return;

                OnPropertyChanged(nameof(IsToRight)); }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public WordTabViewModel()
        {

        }

        #endregion

        #region Helper Functions

        #endregion

    }
}
