using Enzo.Business;
using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Enzo.Controls
{
    /// <summary>
    /// Interaction logic for ScrambledText.xaml
    /// </summary>
    public partial class TestScrambledText : UserControl
    {
        #region Fields

        private readonly INavigator _navigator;
        private Random _random = new Random();
        private int position = 0;

        #endregion Fields

        #region Constructors

        public TestScrambledText(INavigator navigator)
        {
            InitializeComponent();

            while (position == 0) { position = _random.Next(-10, 10); }
            _secretPlace.Text = Shift(position);
            _slider.Value = position;
            _navigator = navigator;
        }

        #endregion Constructors

        #region Methods

        private void OnGo(object sender, RoutedEventArgs e)
        {
            _navigator.Goto(new Password(_navigator));
        }

        private void OnLeft(object sender, RoutedEventArgs e) => _secretPlace.Text = Shift(-1);

        private void OnRight(object sender, RoutedEventArgs e) => _secretPlace.Text = Shift(1);

        private string Shift(int offset)
        {
            if (offset > 20 || offset < -20) { offset = 0; }

            var sb = new StringBuilder();
            foreach (var letter in _secretPlace.Text)
            {
                sb.Append((char)(letter + offset));
            }
            _slider.Value += offset;
            return sb.ToString();
        }

        #endregion Methods

        private void OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _photo.Visibility = (_slider.Value == 0)
                ? Visibility.Visible
                : Visibility.Collapsed;
        }
    }
}