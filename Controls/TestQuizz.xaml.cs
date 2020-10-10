using Enzo.Business;
using System.Windows.Controls;

namespace Enzo.Controls
{
    /// <summary>
    /// Interaction logic for Quizz.xaml
    /// </summary>
    public partial class TestQuizz : UserControl
    {
        #region Fields

        private const int c_BlurOffset = 120 / 5;
        private readonly INavigator _navigator;

        #endregion Fields

        #region Constructors

        public TestQuizz(Business.INavigator navigator)
        {
            InitializeComponent();
            _navigator = navigator;
        }

        #endregion Constructors

        #region Methods

        private void GetAnswer(ComboBox combobox)
        {
            if (combobox.SelectedItem is ComboBoxItem answer
                && answer.Tag is string v
                && bool.TryParse(v, out var isTrue))
            {
                if (isTrue)
                {
                    _blur.Radius -= c_BlurOffset;
                    combobox.IsEnabled = false;
                }
            }

            _pasword.Visibility = (_blur.Radius == 0)
                    ? System.Windows.Visibility.Visible
                    : System.Windows.Visibility.Collapsed;
        }

        private void OnGoPassword(object sender, System.Windows.RoutedEventArgs e)
        {
            _navigator.Goto(new Password(_navigator));
        }

        private void OnQuestion(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox combobox)
            {
                GetAnswer(combobox);
            }
        }

        #endregion Methods
    }
}