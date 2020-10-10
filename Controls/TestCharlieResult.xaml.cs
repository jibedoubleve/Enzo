using Enzo.Business;
using System.Windows;
using System.Windows.Controls;

namespace Enzo.Controls
{
    /// <summary>
    /// Interaction logic for TestCharlieResult.xaml
    /// </summary>
    public partial class TestCharlieResult : UserControl
    {
        #region Fields

        private readonly INavigator _navigator;

        #endregion Fields

        #region Constructors

        public TestCharlieResult(INavigator navigator)
        {
            InitializeComponent();
            _navigator = navigator;
        }

        #endregion Constructors

        #region Methods

        private void OnGo(object sender, RoutedEventArgs e)
        {
            _navigator.Goto(new Password(_navigator));
        }

        #endregion Methods
    }
}