using System.Windows;

namespace SozlukDesktop.UI.ViewModels
{
    /// <summary>
    /// Default summary for MainWindowViewModel.cs
    /// </summary>
    public class MainWindowViewModel : WindowViewModel
    {
        #region Singleton

        /// <summary>
        /// Create a static instance of viewModel
        /// </summary>
        private static MainWindowViewModel _mainWindowViewModel;

        /// <summary>
        /// To get properties of this view model
        /// </summary>
        /// <returns></returns>
        public static MainWindowViewModel GetMainWindowViewModel(Window mWindow)
        {
            if (_mainWindowViewModel == null)
            {
                _mainWindowViewModel = new MainWindowViewModel(mWindow);
            }
            return _mainWindowViewModel;
        }

        #endregion


        #region Private Members

        /// <summary>
        /// A flag that controls main tab view visibility
        /// </summary>
        private bool _tabViewVisibility;

        #endregion

        #region Public Properties

        /// <summary>
        /// Main TabView Visibility
        /// </summary>
        public bool TabViewVisibility
        {
            get { return _tabViewVisibility; }
            set { _tabViewVisibility = value; OnPropertyChanged(nameof(TabViewVisibility)); }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public MainWindowViewModel(Window mWindow) : base(mWindow)
        {
        }

        #endregion

    }
}
