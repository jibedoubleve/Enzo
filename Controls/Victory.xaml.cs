using Enzo.Business;
using System.Windows.Controls;

namespace Enzo.Controls
{
    /// <summary>
    /// Interaction logic for Victory.xaml
    /// </summary>
    public partial class Victory : UserControl
    {
        #region Fields

        private readonly INavigator _navigator;

        #endregion Fields

        #region Constructors

        public Victory(INavigator navigator)
        {
            InitializeComponent();
            _navigator = navigator;
        }

        #endregion Constructors

        #region Methods

        private void OnShow(object sender, System.Windows.RoutedEventArgs e)
        {
            _image.Visibility = System.Windows.Visibility.Visible;
            _showButton.Visibility = System.Windows.Visibility.Collapsed;
        }

        #endregion Methods
    }
}