using Enzo.Business;
using Enzo.Controls;
using System.Windows;

namespace Enzo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : INavigator
    {
        #region Constructors

        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Methods

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            Goto(new Welcome(this));
        }

        private void OnMetroWindowLoaded(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Maximized;
            ResizeMode = ResizeMode.NoResize;
            ShowMaxRestoreButton = false;
            ShowMinButton = false;
        }

        public void GoBack()
        {
            if (_navigationHost.CanGoBack)
            {
                _navigationHost.GoBack();
            }
            else { _navigationHost.Navigate(new Welcome(this)); }
        }

        public void Goto(object destination)
        {
            _navigationHost.Navigate(destination);
        }

        #endregion Methods
    }
}