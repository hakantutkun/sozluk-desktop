using SozlukDesktop.DBAccess.Manager;
using SozlukDesktop.Entities.Models;
using SozlukDesktop.UI.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace SozlukDesktop.UI
{
    /// <summary>
    /// Default summary for SearchInputViewModel.cs
    /// </summary>
    public class SearchInputViewModel : BaseViewModel
    {
        #region Singleton

        /// <summary>
        /// Create a static instance of viewModel
        /// </summary>
        private static SearchInputViewModel _searchInputViewModel;

        /// <summary>
        /// To get properties of this view model
        /// </summary>
        /// <returns></returns>
        public static SearchInputViewModel GetSearchInputViewModel()
        {
            if (_searchInputViewModel == null)
            {
                _searchInputViewModel = new SearchInputViewModel();
            }
            return _searchInputViewModel;
        }

        #endregion

        #region Private Members

        /// <summary>
        /// placeholder text of Search Input
        /// </summary>
        private string _placeHolderText = "Kelime giriniz...";

        /// <summary>
        /// The content text of the Search Input
        /// </summary>
        private string _contentText;

        /// <summary>
        /// A flag that controls clear button visibility
        /// </summary>
        private bool _clearButtonVisibility;

        /// <summary>
        /// An instance of <see cref="SearchAreaViewModel"/>
        /// </summary>
        public SearchAreaViewModel SearchAreaViewModel { get; set; }

        /// <summary>
        /// An instance of <see cref="SearchAreaViewModel"/>
        /// </summary>
        public WordTabViewModel WordTabViewModel { get; set; }

        /// <summary>
        /// A flag that indicates if searching is active or not
        /// </summary>
        private bool _isSearching;

        /// <summary>
        /// A list that holds result words
        /// </summary>
        private ObservableCollection<Kelime> _wordList;

        #endregion

        #region Public Properties

        /// <summary>
        /// The placeholder of searchInput
        /// </summary>
        public string PlaceHolderText
        {
            get { return _placeHolderText; }
            set { _placeHolderText = value; OnPropertyChanged(nameof(PlaceHolderText)); }
        }

        /// <summary>
        /// The content text of the Search Input
        /// </summary>
        public string ContentText
        {
            get { return _contentText; }
            set
            {
                // set the content text with given value
                _contentText = value;

                ContentTextChanged(value);

                // fire off onpropertychanged event
                OnPropertyChanged(nameof(ContentText));
            }
        }

        /// <summary>
        /// A flag that controls clear button visibility
        /// </summary>
        public bool ClearButtonVisibility
        {
            get { return _clearButtonVisibility; }
            set
            {
                _clearButtonVisibility = value;
                OnPropertyChanged(nameof(ClearButtonVisibility));
            }
        }

        /// <summary>
        /// Complementary word for placeholder complementing while typing
        /// </summary>
        public string ComplementaryWord { get; set; }


        /// <summary>
        /// A flag that indicates if searching is active or not
        /// </summary>
        public bool IsSearching
        {
            get { return _isSearching; }
            set { _isSearching = value; OnPropertyChanged(nameof(IsSearching)); }
        }

        /// <summary>
        /// A list that holds result words
        /// </summary>
        public ObservableCollection<Kelime> WordList
        {
            get { return _wordList; }
            set { _wordList = value; OnPropertyChanged(nameof(WordList)); }
        }

        #endregion

        #region Commands

        /// <summary>
        /// Clears input textbox content
        /// </summary>
        public ICommand ClearCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SearchInputViewModel()
        {
            // get an instance of search area view model
            SearchAreaViewModel = SearchAreaViewModel.GetSearchAreaViewModel();

            // get an instance of search area view model
            WordTabViewModel = WordTabViewModel.GetWordTabViewModel();

            // Create commands
            ClearCommand = new RelayCommand(Clear);
        }
        #endregion

        #region Command Methods

        private void Clear()
        {
            // Clear content text of search input
            ContentText = string.Empty;

            // Normalize search area again
            SearchAreaViewModel.IsExpanded = false;
            SearchAreaViewModel.IsShrank = false;

            // Make title of search area visible
            SearchAreaViewModel.TitleVisibility = true;
        }


        #endregion

        #region Private Helpers

        /// <summary>
        /// Fires relevant processes for searching process
        /// </summary>
        /// <param name="value">current search bar text </param>
        private void ContentTextChanged(string value)
        {
            // Check if the content of textbox is empty or null
            if (string.IsNullOrEmpty(value))
            {
                // Set searching process to false
                IsSearching = false;

                // Set default placeholder if content of textbox empty or null
                PlaceHolderText = "Kelime giriniz...";

                // If text box empty, make clear button invisible
                ClearButtonVisibility = false;

                // reset search area back
                SearchAreaViewModel.IsExpanded = false;
                SearchAreaViewModel.IsShrank = false;

            }
            else
            {
                // Set is searching flag to true to indicate that search process is active
                IsSearching = true;

                // Fetch relevant words from database
                WordList = new ObservableCollection<Kelime>(DBManager.LoadWordsLike(value));

                // Set shrank flag to false
                SearchAreaViewModel.IsShrank = false;

                // Expand search area when something is typed
                SearchAreaViewModel.IsExpanded = true;

                // If text box is filled, then make clear button visible
                ClearButtonVisibility = true;

                // get the length of the current content of text box
                var length = value.Length;

                // Null reference control
                if (WordList.Count != 0)
                {
                    // Set complementary word with the most close one
                    ComplementaryWord = WordList.FirstOrDefault().KaracaycaAnlam;

                    // get the substring of best close result 
                    var tempText = ComplementaryWord.Substring(0, length);

                    // Check if this two value equals
                    if (value == tempText)
                        // If values are equal, then we can show the placeholder as a guess
                        PlaceHolderText = ComplementaryWord;
                    else
                        // otherwise do not show anything to user
                        PlaceHolderText = String.Empty;
                }
                else
                {
                    // If any words found, set placeholder text to empty
                    PlaceHolderText = string.Empty;
                }

            }
        }

        /// <summary>
        /// Prepares selected word item
        /// </summary>
        internal void PrepareSelectedWordItem(Kelime selectedWord)
        {
            // Set expanded flag to false
            SearchAreaViewModel.IsExpanded = false;

            // Shrink the search area
            SearchAreaViewModel.IsShrank = true;

            // Hide title of search area
            SearchAreaViewModel.TitleVisibility = false;

            // End search process
            IsSearching = false;

            // Set the selected word for tab view changes
            WordTabViewModel.SelectedWord = selectedWord;
        }

        #endregion

    }
}
