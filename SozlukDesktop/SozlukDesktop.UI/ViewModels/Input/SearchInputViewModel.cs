using SozlukDesktop.UI.Models;
using SozlukDesktop.UI.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

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

        public SearchAreaViewModel SearchAreaViewModel { get; set; } = SearchAreaViewModel.GetSearchAreaViewModel();

        /// <summary>
        /// A flag that indicates if searching is active or not
        /// </summary>
        private bool _isSearching;

        /// <summary>
        /// A list that holds result words
        /// </summary>
        private ObservableCollection<WordModel> _wordList;

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

                ContentTexxtChanged(value);

                // fire off onpropertychanged event
                OnPropertyChanged(nameof(ContentText));
            }
        }
       
        /// <summary>
        /// A flag that controls clear button visibility
        /// </summary>
        public bool ClearButtonVisibility 
        {
            get { return _clearButtonVisibility;  } 
            set 
            { 
                _clearButtonVisibility = value;  
                OnPropertyChanged(nameof(ClearButtonVisibility));
            } 
        }

        /// <summary>
        /// A temporary word for placeholder complementin while typing
        /// TODO: Bind to dynamically best close result 
        /// </summary>
        public string TemporaryWord { get; set; } = "inspire";


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
        public ObservableCollection<WordModel> WordList
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

            // Create commands
            ClearCommand = new RelayCommand(Clear);

            // TODO: Fill dynamically when database implemented
            // create an instance of the result list
            _wordList = new ObservableCollection<WordModel>();

            WordList.Add(new WordModel { Word = "biyçe", TypeOfWord = "İsim" });
            WordList.Add(new WordModel { Word = "tavruh", TypeOfWord = "İsim" });
            WordList.Add(new WordModel { Word = "çapğan", TypeOfWord = "Fiil" });
            WordList.Add(new WordModel { Word = "cürek", TypeOfWord = "İsim" });
            WordList.Add(new WordModel { Word = "castık", TypeOfWord = "İsim" });
            WordList.Add(new WordModel { Word = "cücek", TypeOfWord = "İsim" });
        }
        #endregion

        #region Command Methods

        private void Clear()
        {
            // Clear content text of search input
            ContentText = string.Empty;
        }


        #endregion

        #region Private Helpers

        /// <summary>
        /// Fires relevant processes for searching process
        /// </summary>
        /// <param name="value">current search bar text </param>
        private void ContentTexxtChanged(string value)
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

                // Shrink search area back
                SearchAreaViewModel.IsExpanded = false;

            }
            else
            {

                // Simulate searhing

                Task task = new Task(() =>
                {
                    AddDummyDataToWordList();
                });

                task.Start();


                // Expand search area when something is typed
                SearchAreaViewModel.IsExpanded = true;

                // If text box is filled, then make clear button visible
                ClearButtonVisibility = true;

                // get the length of the current content of text box
                var length = value.Length;

                // TODO: Change guess word as dynamic...
                // get the substring of best close result 
                var tempText = TemporaryWord.Substring(0, length);

                // Check if this two value equals
                if (value == tempText)
                    // If values are equal, then we can show the placeholder as a guess
                    PlaceHolderText = TemporaryWord;
                else
                    // otherwise do not show anything to user
                    PlaceHolderText = String.Empty;
            }
        }

        /// <summary>
        /// Adds dummy data to simulate searching 
        /// </summary>
        private void AddDummyDataToWordList()
        {

            // make user to wait some time before fetched the words
            Thread.Sleep(0);

            // Set is searching flag to true to indicate that search process is active
            IsSearching = true;

        }

        #endregion

    }
}
