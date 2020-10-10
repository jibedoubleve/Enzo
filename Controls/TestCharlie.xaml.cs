using Enzo.Business;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Enzo.Controls
{
    /// <summary>
    /// Interaction logic for Charlie.xaml
    /// </summary>
    public partial class TestCharlie : UserControl
    {
        private readonly INavigator _navigator;
        #region Constructors

        public TestCharlie(Business.INavigator navigator)
        {
            InitializeComponent();
            _navigator = navigator;
        }

        #endregion Constructors

        #region Methods

        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _navigator.Goto(new TestCharlieResult(_navigator));
        }

        #endregion Methods
    }
}