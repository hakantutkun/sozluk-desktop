namespace SozlukDesktop.UI.ViewModels
{
    /// <summary>
    /// Default summary for SearchAreaViewModel.cs
    /// </summary>
    public class SearchAreaViewModel : BaseViewModel
    {
        #region Singleton

        /// <summary>
        /// Create a static instance of viewModel
        /// </summary>
        private static SearchAreaViewModel _searchAreaViewModel;

        /// <summary>
        /// To get properties of this view model
        /// </summary>
        /// <returns></returns>
        public static SearchAreaViewModel GetSearchAreaViewModel()
        {
            if (_searchAreaViewModel == null)
            {
                _searchAreaViewModel = new SearchAreaViewModel();
            }
            return _searchAreaViewModel;
        }

        #endregion

        #region Private Members

        /// <summary>
        /// A flag that controls the expand animation of SearchArea
        /// </summary>
        private bool _isExpanded;

        #endregion

        #region Public Properties

        /// <summary>
        /// A flag that controls the expand animation of SearchArea
        /// </summary>
        public bool IsExpanded
        {
            get { return _isExpanded; }
            set { _isExpanded = value; OnPropertyChanged(nameof(IsExpanded)); }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SearchAreaViewModel()
        {
        }

        #endregion

        #region Helper Functions

        public void ShrinkArea()
        {

        }

        #endregion

    }
}
