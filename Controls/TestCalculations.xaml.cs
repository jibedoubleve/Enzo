using Enzo.Business;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Enzo.Controls
{
    /// <summary>
    /// Interaction logic for Calculations.xaml
    /// </summary>
    public partial class TestCalculations : UserControl
    {
        #region Fields

        private readonly INavigator _navigator;

        #endregion Fields

        #region Constructors

        public TestCalculations(INavigator navigator)
        {
            InitializeComponent();

            _navigator = navigator;
        }

        #endregion Constructors

        #region Methods

        private void OnPassword(object sender, RoutedEventArgs e)
        {
            _navigator.Goto(new Password(_navigator));
        }

        private void OnResult(object sender, RoutedEventArgs e)
        {
            var t1 = Evaluator.Evaluate(calculus_1.Text, result_1.Text);
            var t2 = Evaluator.Evaluate(calculus_2.Text, result_2.Text);
            var t3 = Evaluator.Evaluate(calculus_3.Text, result_3.Text);

            validation_1.Fill = t1 ? Brushes.Green : Brushes.Red;
            validation_2.Fill = t2 ? Brushes.Green : Brushes.Red;
            validation_3.Fill = t3 ? Brushes.Green : Brushes.Red;

            photo.Visibility = (t1 && t2 && t3)
                    ? Visibility.Visible
                    : Visibility.Collapsed;

            _upperSide.Visibility = (t1 && t2 && t3)
                ? Visibility.Collapsed
                : Visibility.Visible;
        }

        #endregion Methods
    }
}