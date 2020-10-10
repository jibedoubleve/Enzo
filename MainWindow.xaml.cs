using enzo.Business;
using System.Windows;
using System.Windows.Media;

namespace enzo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructors

        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Methods

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
        }

        #endregion Methods
    }
}