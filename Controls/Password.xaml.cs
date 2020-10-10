using Enzo.Business;
using System.Linq;
using System.Printing;
using System.Windows.Controls;

namespace Enzo.Controls
{
    /// <summary>
    /// Interaction logic for Password.xaml
    /// </summary>
    public partial class Password : UserControl
    {
        #region Fields

        private readonly INavigator _navigator;

        #endregion Fields

        #region Constructors

        public Password(INavigator navigator)
        {
            InitializeComponent();
            _navigator = navigator;
        }

        #endregion Constructors

        #region Methods

        private void CheckPassword()
        {
            switch (_password.Text.ToUpper())
            {
                case "4652":
                    _navigator.Goto(new TestScrambledText(_navigator));
                    break;

                case "2917":
                    _navigator.Goto(new TestQuizz(_navigator)); ;
                    break;

                case "9817":
                    _navigator.Goto(new TestCalculations(_navigator));
                    break;

                case "1431":
                    _navigator.Goto(new TestCharlie(_navigator));
                    break;

                case "7946":
                    _navigator.Goto(new TestVisualQuizz(_navigator));
                    break;

                case "4372":
                    _navigator.Goto(new Victory(_navigator));
                    break;
                default:
                    _navigator.Goto(new BadPassword(_navigator));
                    break;
            }
        }

        #endregion Methods

        private void OnSendKey(object sender, System.Windows.RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is string value)
            {
                if (int.TryParse(value, out var output))
                {
                    _password.Text += output;
                }
                else if (value.ToLower() == "clear")
                {
                    _password.Text = string.Empty;
                }
                else if (value.ToLower() == "send")
                {
                    CheckPassword();
                }
            }
        }
    }
}