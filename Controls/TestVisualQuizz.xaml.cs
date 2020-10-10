using Enzo.Business;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Enzo.Controls
{
    /// <summary>
    /// Interaction logic for VisualQuizz.xaml
    /// </summary>
    public partial class TestVisualQuizz : UserControl
    {
        private readonly INavigator _navigator;

        #region Fields

        private Point _clickPosition;
        private bool _isDragging;
        private TranslateTransform _originTT;

        #endregion Fields

        #region Constructors

        public TestVisualQuizz(Business.INavigator navigator)
        {
            InitializeComponent();
            _navigator = navigator;
        }

        #endregion Constructors

        #region Methods

        private static Rect BoundsRelativeTo(FrameworkElement element, Visual relativeTo)
        {
            return element.TransformToVisual(relativeTo).TransformBounds(new Rect(element.RenderSize));
        }

        private void OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var draggableControl = sender as Shape;
            _originTT = draggableControl.RenderTransform as TranslateTransform ?? new TranslateTransform();
            _isDragging = true;
            _clickPosition = e.GetPosition(this);
            draggableControl.CaptureMouse();
        }

        private void OnPreviewMouseMove(object sender, MouseEventArgs e)
        {
            var draggableControl = sender as Shape;
            if (_isDragging && draggableControl != null)
            {
                Point currentPosition = e.GetPosition(this);
                var transform = draggableControl.RenderTransform as TranslateTransform ?? new TranslateTransform();
                transform.X = _originTT.X + (currentPosition.X - _clickPosition.X);
                transform.Y = _originTT.Y + (currentPosition.Y - _clickPosition.Y);
                draggableControl.RenderTransform = new TranslateTransform(transform.X, transform.Y);
            }
        }

        private void OnPreviewMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            _isDragging = false;
            var draggable = sender as Shape;
            draggable.ReleaseMouseCapture();

            var answer = BoundsRelativeTo(draggable, _canvas);
            var target = BoundsRelativeTo(_solution, _canvas);

            if (answer.IntersectsWith(target)
                && draggable.Tag is string value
                && bool.TryParse(value, out var isTrue)
             )
            {
                if (isTrue) { _result.Visibility = Visibility; }
                else { draggable.RenderTransform = new TranslateTransform(0, 0); }
            }
        }

        private void OnSuccess(object sender, RoutedEventArgs e)
        {
            _navigator.Goto(new Password(_navigator));
        }
    }

    #endregion Methods
}