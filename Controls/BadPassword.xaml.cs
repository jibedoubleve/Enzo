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
    /// Interaction logic for BadPassword.xaml
    /// </summary>
    public partial class BadPassword : UserControl
    {
        private readonly INavigator _navigator;

        public BadPassword(INavigator navigator)
        {
            InitializeComponent();
            _navigator = navigator;
        }

        private void OnRetry(object sender, RoutedEventArgs e)
        {
            _navigator.GoBack();
        }
    }
}
