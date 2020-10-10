using Enzo.Business;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Enzo.Controls
{
    /// <summary>
    /// Interaction logic for Welcome.xaml
    /// </summary>
    public partial class Welcome : UserControl
    {
        private readonly INavigator _navigator;

        public Welcome(INavigator navigator)
        {
            InitializeComponent();
            _navigator = navigator;

        }

        private void CheckAge()
        {

            if (int.TryParse(_age.Text, out var age))
            {
                if (age == 7) { _navigator.Goto(new Password(_navigator)); }
                else { _age.Text = string.Empty; }
            }
        }


        private void OnSendKey(object sender, System.Windows.RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is string value)
            {
                if (int.TryParse(value, out var output))
                {
                    _age.Text += output;
                }
                else if (value.ToLower() == "clear")
                {
                    _age.Text = string.Empty;
                }
                else if (value.ToLower() == "send")
                {
                    CheckAge();
                }
            }
        }
    }
}
