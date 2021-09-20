namespace SozlukDesktop.UI
{
    /// <summary>
    /// Default summary for SearchInputDesignModel.cs
    /// </summary>
    public class SearchInputDesignModel : SearchInputViewModel
    {
        #region Singleton

        /// <summary>
        /// a single instance of the design model
        /// a single version of get property
        /// </summary>
        public static SearchInputDesignModel Instance => new SearchInputDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public SearchInputDesignModel()
        {
            ClearButtonVisibility = true;
            ContentText = "Deneme";
        }

        #endregion
    }
}
