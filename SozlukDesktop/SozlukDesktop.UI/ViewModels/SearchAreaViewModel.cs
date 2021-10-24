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

        /// <summary>
        /// A flag that controls the shrink animation of SearchArea
        /// </summary>
        private bool _isShrank;

        /// <summary>
        /// A flag that keeps title visibility
        /// </summary>
        private bool _titleVisibility = true;

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

        /// <summary>
        /// A flag that controls the shrink animation of SearchArea
        /// </summary>
        public bool IsShrank
        {
            get { return _isShrank; }
            set { _isShrank = value; OnPropertyChanged(nameof(IsShrank)); }
        }

        /// <summary>
        /// A flag that keeps title visibility
        /// </summary>
        public bool TitleVisibility
        {
            get { return _titleVisibility; }
            set 
            { 
                _titleVisibility = value;
                OnPropertyChanged(nameof(TitleVisibility)); 
            }
        }

        #endregion

    }
}
