using System.Windows;
using System.Windows.Input;

namespace SozlukDesktop.UI
{
    /// <summary>
    /// A View model for Window element
    /// </summary>
    public class WindowViewModel : BaseViewModel
    {
        #region Private Members

        /// <summary>
        /// The windows this view model controls
        /// </summary>
        private Window mWindow;

        #endregion

        #region Public Properties

        /// <summary>
        /// The corner radius for window when minimized
        /// </summary>
        public int WindowCornerRadius { get; set; } = 0;

        /// <summary>
        /// Margin for showing shadow when window minimized
        /// </summary>
        public int WindowOuterMarginSize { get; set; } = 10;

        /// <summary>
        /// The title height of the window
        /// </summary>
        public int TitleHeightGridLength { get; set; } = 40;
        /// <summary>
        /// The minimum width of the window
        /// </summary>
        public int WindowMinWidth { get; set; } = 700;

        /// <summary>
        /// The minimum height of the window
        /// </summary>
        public int WindowMinHeight { get; set; } = 550;

        /// <summary>
        /// The height of the main border
        /// </summary>
        public int MainBorderHeight { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// The command to minimize the window
        /// </summary>
        public ICommand MinimizeCommand { get; set; }

        /// <summary>
        /// The command to maximize the window
        /// </summary>
        public ICommand MaximizeCommand { get; set; }

        /// <summary>
        /// The command to close the window
        /// </summary>
        public ICommand CloseCommand { get; set; }

        /// <summary>
        /// The command to minimize te window
        /// </summary>
        public ICommand MenuCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// A constructor that controls relevant window
        /// </summary>
        public WindowViewModel(Window window)
        {
            mWindow = window;

            // Set the mainborder height initially 
            MainBorderHeight = (int)(mWindow.Height / 2);

            // Listen out for the window resizing
            mWindow.StateChanged += (sender, e) =>
            {
                // Fire off events for all properties that are affected by a resize
                OnPropertyChanged(nameof(WindowCornerRadius));
                OnPropertyChanged(nameof(WindowOuterMarginSize));
            };

            // Create commands
            MinimizeCommand = new RelayCommand(() => mWindow.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => mWindow.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => mWindow.Close());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(mWindow, GetMousePosition()));
        }

        #endregion

        #region Private Helpers

        /// <summary>
        /// Gets the current mouse position
        /// </summary>
        private Point GetMousePosition()
        {
            // position of the mouse relative to the window
            var position = Mouse.GetPosition(mWindow);

            // add the window position so its a "ToScreen"
            return new Point(position.X + mWindow.Left, position.Y + mWindow.Top);
        }

        #endregion

    }
}
