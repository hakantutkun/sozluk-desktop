using SozlukDesktop.Entities.Models;
using System;

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
        /// Selected word for changing the content of tab view
        /// </summary>
        private Kelime _selectedWord;

        /// <summary>
        /// The display information of the selected word
        /// </summary>
        private string _wordInformation;

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
        /// Selected word for changing the content of tab view
        /// </summary>
        public Kelime SelectedWord
        {
            get { return _selectedWord; }
            set 
            { 
                _selectedWord = value;

                OnPropertyChanged(nameof(SelectedWord));

                SelectedWordChanged(value);
            }
        }

        /// <summary>
        /// The display information of the selected word
        /// </summary>
        public string WordInformation
        {
            get { return _wordInformation; }
            set 
            { 
                _wordInformation = value; 

                OnPropertyChanged(nameof(WordInformation));
            }
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

        /// <summary>
        /// Arranges all changes at tab view according to selected word
        /// </summary>
        /// <param name="selectedWord">Selected Word</param>
        private void SelectedWordChanged(Kelime selectedWord)
        {
            WordInformation = selectedWord.TurkceAnlam;
        }

        #endregion

    }
}
